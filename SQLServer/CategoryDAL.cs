using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FirstClogIDAL;
using FirstClogModel;
using System.Data.SqlClient;
using System.Data;
using FirstClogDBUtility;
using System.Reflection;

namespace SQLServer
{
    /*************************************************************************************
    * CLR版本：         4.0.30319.269
    * 类 名 称：       CategoryDAL
    * 机器名称：       HSERVER
    * 命名空间：       SQLServer
    * 文 件 名：       CategoryDAL
    * 创建时间：       2012/8/3 23:25:31
    * 作    者：       常伟华 Changweihua
    * 
    * 修改时间：
    * 修 改 人：
   *************************************************************************************/
    /// <summary>
    /// 添加类描述
    /// </summary>
    public class CategoryDAL : ICategory
    {

        /// <summary>
        /// 插入新分类
        /// </summary>
        /// <param name="category">分类</param>
        /// <returns></returns>
        public int Insert(Category category)
        {
            int count = 0;

            string sql = "insert from tbCategory where categoryid = @CategoryId";

            SqlParameter[] sqlParams = new SqlParameter[] { };

            count = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, sqlParams);

            return count;
        }



        /// <summary>
        /// 更新分类
        /// </summary>
        /// <param name="category">分类</param>
        /// <returns></returns>
        public int Update(Category category)
        {
            int count = 0;
            StringBuilder sqlBuilder = new StringBuilder("update tbCategory set ");

            

            string sql = "update tbCategory set categoryname = @CategoryName, categoryalias = @CategoryAlias, categorytaxis = @CategoryTaxis where categoryid = @CategoryId";

            SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@CategoryId", category.CategoryId) };

            count = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, sqlParams);

            return count;
        }


        /// <summary>
        /// 查询分类
        /// </summary>
        /// <param name="categoryName">分类名称关键字</param>
        /// <returns>分类集合</returns>
        public IList<Category> Select(string categoryName)
        {

            StringBuilder sqlBuilder = new StringBuilder("select * from tbCategory");
            SqlParameter[] sqlParams = null;

            if (!string.IsNullOrEmpty(categoryName))
            {
                sqlBuilder.Append(" where categoryname like @CategoryName");
                sqlParams = new SqlParameter[] {
                                                new SqlParameter("@CategoryName", "%%" + categoryName + "%%")
                };
            }

            SqlDataReader reader = SqlHelper.ExecuteGetReader(CommandType.Text, sqlBuilder.ToString(), sqlParams);

            IList<Category> categories = new List<Category>();
            Category category = null; 

            while (reader.Read())
            {
                category = new Category { CategoryId = Convert.ToInt32(reader["categoryid"]), CategoryName = Convert.ToString(reader["categoryname"]), CategoryAlias = Convert.ToString(reader["categoryalias"]), CategoryTaxis = Convert.ToInt32(reader["categorytaxis"]) };

                categories.Add(category);
            }

            return categories;
        }


        /// <summary>
        /// 获取指定编号的分类 
        /// </summary>
        /// <param name="categoryId">分类编号</param>
        /// <returns>分类信息</returns>
        public Category Select(int categoryId)
        {
            Category category = null;

            string sql = "select * from tbCategory where categoryid = @CategoryId";

            SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@CategoryId", categoryId) };

            using (SqlDataReader reader = SqlHelper.ExecuteGetReader(CommandType.Text, sql, sqlParams))
            {
                while (reader.Read())
                {
                    category = new Category { CategoryId = Convert.ToInt32(reader["categoryid"]), CategoryName = Convert.ToString(reader["categoryname"]), CategoryAlias = Convert.ToString(reader["categoryalias"]), CategoryTaxis = Convert.ToInt32(reader["categorytaxis"]) };
                }
            }

            return category;
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="categoryId">分类编号</param>
        /// <returns>删除记录数</returns>
        public int Delete(int categoryId)
        {
            int count = 0;

            string sql = "delete from tbCategory where categoryid = @CategoryId";

            SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@CategoryId", categoryId) };

            count = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, sqlParams);

            return count;
        }
    }
}
