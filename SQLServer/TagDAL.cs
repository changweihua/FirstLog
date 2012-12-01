using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirstClogIDAL;
using FirstClogModel;
using System.Data.SqlClient;
using System.Data;
using FirstClogDBUtility;

namespace SQLServer
{
    /*************************************************************************************
    * CLR版本：        4.0.30319.269
    * 类 名 称：       TagDAL
    * 机器名称：       HSERVER
    * 命名空间：       SQLServer
    * 文 件 名：       TagDAL
    * 创建时间：       2012/8/14 9:09:49
    * 作    者：      常伟华 Changweihua
    * 
    * 修改时间：
    * 修 改 人：
   *************************************************************************************/
    /// <summary>
    /// 添加类描述
    /// </summary>
    public class TagDAL : ITag
    {

        public int Insert(Tag tag)
        {
            int affectRow = 0;
            
            string sqlString = "insert into tbTag (TagName, ArticleId) values (@TagName, @ArticleId)";
            SqlParameter[] sqlParams = new SqlParameter[] { 
                new SqlParameter("@TagName",tag.TagName),
                new SqlParameter("@ArticleId",tag.ArticleId)
            };

            affectRow = SqlHelper.ExecuteNonQuery(CommandType.Text, sqlString, sqlParams);

            return affectRow;
        }

        public int Update(Tag tag)
        {
            throw new NotImplementedException();
        }

        public int Delete(Tag tag)
        {
            throw new NotImplementedException();
        }

        public List<Tag> Select()
        {
            StringBuilder sqlBuilder = new StringBuilder("select * from tbTag");
            SqlParameter[] sqlParams = null;

            SqlDataReader reader = SqlHelper.ExecuteGetReader(CommandType.Text, sqlBuilder.ToString(), sqlParams);

            List<Tag> tags = new List<Tag>();
            Tag tag = null;

            while (reader.Read())
            {
                tag = new Tag { ArticleId = Convert.ToInt32(reader["articleid"]), TagId = Convert.ToInt32(reader["tagid"]), TagName = Convert.ToString(reader["tagname"]) };
                
                tags.Add(tag);
            }

            return tags;
        }


        public List<Tag> Select(int articleId)
        {
            throw new NotImplementedException();
        }
    }
}
