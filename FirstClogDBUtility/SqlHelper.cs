﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace FirstClogDBUtility
{
    /*************************************************************************************
    * CLR版本：        4.0.30319.269
    * 类 名 称：       SqlHelper
    * 机器名称：       HSERVER
    * 命名空间：       FirstClogDBUtility
    * 文 件 名：       SqlHelper
    * 创建时间：       2012/8/4 10:34:46
    * 作    者：       常伟华 Changweihua
    * 
    * 修改时间：
    * 修 改 人：
   *************************************************************************************/

    /// <summary>
    /// SqlHelper类是专门提供给用于高性能、可升级的sql数据操作
    /// </summary>
    public static class SqlHelper
    {
        //数据库连接字符串。
        //连接字符串在界面层的webConfig的配置文件中。[设计为public是为了创建带事务的连接，因为连接将在DAL相关类中创建]
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["SQLServerConnection"].ConnectionString;

        #region 执行SQL语句或存储过程，返回影响的行数
        /// <summary>
        /// 执行SQL语句或存储过程，返回影响的行数
        /// </summary>
        /// <param name="commandType">命令类型(存储过程, 文本, 表或视图)</param>
        /// <param name="commandText">存储过程名称或者sql命令语句</param>
        /// <param name="paras">执行命令所用参数的集合</param>
        /// <returns>执行命令所影响的行数</returns>
        public static int ExecuteNonQuery(CommandType commandType, string commandText, params SqlParameter[] paras)
        {
            SqlCommand command = new SqlCommand();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                //为什么要调用准备执行命令这个方法：因为在此处可以加入一个事务控制。
                PrepareCommand(command, connection, null, commandType, commandText, paras);
                int val = command.ExecuteNonQuery();
                command.Parameters.Clear();
                return val;
            }
        }
        #endregion

        #region 执行一个返回读取器的sql命令
        /// <summary>
        /// 用执行的数据库连接执行一个返回读取器的sql命令
        /// </summary>
        /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="commandText">存储过程名称或者sql命令语句</param>
        /// <param name="paras">执行命令所用参数的集合</param>
        /// <returns>包含结果的读取器</returns>
        public static SqlDataReader ExecuteGetReader(CommandType commandType, string commandText, params SqlParameter[] paras)
        {
            //创建一个SqlCommand对象
            SqlCommand command = new SqlCommand();
            //创建一个SqlConnection对象
            SqlConnection connection = new SqlConnection(ConnectionString);

            //在这里我们用一个try/catch结构执行sql文本命令/存储过程，因为如果这个方法产生一个异常我们要关闭连接，因为没有读取器存在，
            //因此commandBehaviour.CloseConnection 就不会执行
            try
            {
                //调用 PrepareCommand 方法，对 SqlCommand 对象设置参数
                PrepareCommand(command, connection, null, commandType, commandText, paras);

                //调用 SqlCommand  的 ExecuteReader 方法
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                //清除参数
                command.Parameters.Clear();
                return reader;  //注意不能关闭连接，否则调用方无法读取数据。
            }
            catch
            {
                //关闭连接，抛出异常
                connection.Close();
                throw;
            }
        }
        #endregion

        #region 执行一个命令并返回第一列
        /// <summary>
        /// 用指定的数据库连接字符串执行一个命令并返回一个数据集的第一列
        /// </summary>
        ///<param name="ConnectionString">一个有效的连接字符串</param>
        /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="commandText">存储过程名称或者sql命令语句</param>
        /// <param name="paras">执行命令所用参数的集合</param>
        /// <returns>用 Convert.To{Type}把类型转换为想要的 </returns>
        public static object ExecuteScalar(CommandType commandType, string commandText, params SqlParameter[] paras)
        {
            SqlCommand command = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                PrepareCommand(command, connection, null, commandType, commandText, paras);
                object val = command.ExecuteScalar();
                command.Parameters.Clear();
                return val;
            }
        }
        #endregion

        #region 使用现有的SQL事务执行一个sql命令,返回影响的行数
        /// <summary>
        ///使用现有的SQL事务执行一个sql命令
        /// </summary>
        /// <param name="transaction">一个现有的事务</param>
        /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="commandText">存储过程名称或者sql命令语句</param>
        /// <param name="paras">执行命令所用参数的集合</param>
        /// <returns>执行命令所影响的行数</returns>
        public static int ExecuteNonQuery(SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] paras)
        {
            //这里不能关闭连接，因为事务还没有完成，此连接将一直为本次事务提供服务。
            //连接将在相关的DAL数据模块中创建，然后传入本方法，所以本类的连接字符串要为Public
            SqlCommand command = new SqlCommand();
            PrepareCommand(command, connection, transaction, commandType, commandText, paras);
            int val = command.ExecuteNonQuery();
            command.Parameters.Clear();
            return val;
        }
        #endregion

        #region 准备执行一个命令
        /// <summary>
        /// 准备执行一个命令
        /// </summary>
        /// <param name="cmd">sql命令</param>
        /// <param name="conn">Sql连接</param>
        /// <param name="trans">Sql事务</param>
        /// <param name="cmdType">命令类型例如 存储过程或者文本</param>
        /// <param name="cmdText">命令文本</param>
        /// <param name="cmdParms">执行命令的参数</param>
        private static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] paras)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Close();
                connection.Open();
            }

            command.Connection = connection;
            command.CommandText = commandText;

            if (transaction != null)
                command.Transaction = transaction;

            command.CommandType = commandType;
            command.Parameters.Clear();

            if (paras != null)
                command.Parameters.AddRange(paras);
        }
        #endregion

        #region 使用现有的SQL事务执行一个sql命令,返回第一列
        /// <summary>
        ///使用现有的SQL事务执行一个sql命令
        /// </summary>
        /// <param name="transaction">一个现有的事务</param>
        /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="commandText">存储过程名称或者sql命令语句</param>
        /// <param name="paras">执行命令所用参数的集合</param>
        /// <returns>执行命令所影响的行数</returns>
        public static object ExecuteScalar(SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] paras)
        {
            //这里不能关闭连接，因为事务还没有完成，此连接将一直为本次事务提供服务。
            //连接将在相关的DAL数据模块中创建，然后传入本方法，所以本类的连接字符串要为Public
            SqlCommand command = new SqlCommand();
            PrepareCommand(command, connection, transaction, commandType, commandText, paras);
            object val = command.ExecuteScalar();
            command.Parameters.Clear();
            return val;
        }
        #endregion

    }

}
