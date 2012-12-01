using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Data;

namespace FirstClogCommon
{
    /*************************************************************************************
    * CLR版本：         4.0.30319.269
    * 类 名 称：       MicroJsonHelper
    * 机器名称：       HSERVER
    * 命名空间：       FirstClogCommon
    * 文 件 名：       MicroJsonHelper
    * 创建时间：       2012/7/27 10:36:20
    * 作    者：       常伟华 Changweihua
    * 
    * 修改时间：
    * 修 改 人：
   *************************************************************************************/
    /// <summary>
    /// Json数据帮助类
    /// 使用微软自带的库
    /// </summary>
    public class MicroJsonHelper
    {
        /// <summary>
        /// 对象转JSON
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>JSON格式的字符串</returns>
        public static string ObjectToJson(object obj)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();

            try
            {
                return jsSerializer.Serialize(obj);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        /// <summary>
        /// 数据表转键值对集合
        /// 把DataTable转成List集合，存每一行
        /// 集合中存放的是键值对，存每一列
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Dictionary<string,object>> DataTableToList(DataTable dt)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

            foreach (DataRow dr in dt.Rows)
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    dict.Add(dc.ColumnName, dr[dc.ColumnName]);
                }
                list.Add(dict);
            }

            return list;
        }

        /// <summary>
        /// 数据集转键值对数组字典
        /// </summary>
        /// <param name="ds">数据集</param>
        /// <returns>键值对数组字典</returns>
        public static Dictionary<string, List<Dictionary<string,object>>> DataSetToDictionary(DataSet ds)
        {
            Dictionary<string, List<Dictionary<string, object>>> dict = new Dictionary<string, List<Dictionary<string, object>>>();

            foreach (DataTable dt in ds.Tables)
            {
                dict.Add(dt.TableName, DataTableToList(dt));
            }

            return dict;
        }

        /// <summary>
        /// 数据表转Json
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <returns>Json字符串</returns>
        public static string DataTableToJson(DataTable dt)
        {
            return ObjectToJson(DataTableToJson(dt));
        }

        /// <summary>
        /// Json文本转对象，泛型方法
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="jsonText">Json文本</param>
        /// <returns>指定类型对象</returns>
        public static T JsonToObject<T>(string jsonText)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();

            try
            {
                return jsSerializer.Deserialize<T>(jsonText);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        /// <summary>
        /// Json文本转换为数据表数据
        /// </summary>
        /// <param name="jsonText">Json文本</param>
        /// <returns>数据表字典</returns>
        public static Dictionary<string , List<Dictionary<string ,object>>> JsonToTableData(string jsonText)
        {
            return JsonToObject<Dictionary<string, List<Dictionary<string, object>>>>(jsonText);
        }

        /// <summary>
        /// Json文本转成数据行
        /// </summary>
        /// <param name="jsonText">Json文本</param>
        /// <returns>数据行字典</returns>
        public static Dictionary<string ,object> JsonToDataRow(string jsonText)
        {
            return JsonToObject<Dictionary<string, object>>(jsonText);
        }

    }
}
