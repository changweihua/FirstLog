using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirstClogModel;

namespace FirstClogIDAL
{
    public interface ITag
    {
        /// <summary>
        /// 插入日志标签
        /// </summary>
        /// <param name="tag">日志标签</param>
        /// <returns></returns>
        int Insert(Tag tag);


        /// <summary>
        /// 更新日志标签
        /// </summary>
        /// <param name="tag">日志标签</param>
        /// <returns></returns>
        int Update(Tag tag);

        /// <summary>
        /// 删除日志标签
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        int Delete(Tag tag);


        /// <summary>
        /// 查询所有标签
        /// </summary>
        /// <returns></returns>
        List<Tag> Select();


        /// <summary>
        /// 查询指定日志的标签
        /// </summary>
        /// <param name="articleId">日志编号</param>
        /// <returns></returns>
        List<Tag> Select(int articleId);
    }
}
