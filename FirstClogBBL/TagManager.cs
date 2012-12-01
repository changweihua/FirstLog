using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirstClogModel;
using SQLServer;

namespace FirstClogBBL
{
    /*************************************************************************************
     * CLR 版本:       4.0.30319.269
     * 类 名 称:       TagManager
     * 机器名称:       HSERVER
     * 命名空间:       FirstClogBBL
     * 文 件 名:       TagManager
     * 创建时间:       2012/8/23 15:37:53
     * 作    者:       常伟华 Changweihua
     * 签    名:       To be or not, it is not a problem !
     * 网    站:       http://www.cmono.net
     * 邮    箱:       changweihua@outlook.com
     * 
     * 修改时间:
     * 修 改 人:
     * 
     ************************************************************************************/
    /// <summary>
    /// 添加类描述
    /// </summary>
    public class TagManager
    {
        private static readonly TagDAL tagDAL = new TagDAL();


        /// <summary>
        /// 获取所有标签
        /// </summary>
        /// <returns></returns>
        public static List<Tag> GetAllTag()
        {
            List<Tag> tags = new List<Tag>();

            tags = tagDAL.Select();

            return tags;
        }


        public static Tag GetTagByTagId(int tagId)
        {

            List<Tag> tags = GetAllTag();

            var tag = tags.Find(t => t.TagId == tagId);

            return tag;
        }

        public static bool InsertTag(Tag tag)
        {
            int affectRow = tagDAL.Insert(tag);

            return affectRow == 1 ? true : false;
        }

        public static bool InsertTags(List<Tag> tags)
        {
            int affectRow = 0;

            foreach (Tag tag in tags)
            {
                affectRow += tagDAL.Insert(tag);
            }

            return affectRow == tags.Count ? true : false;
        }

    }
}
