using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirstClogModel;

namespace FirstClogIDAL
{
    public interface IArticle
    {
        /// <summary>
        /// 插入日志
        /// </summary>
        /// <param name="article">日志</param>
        /// <returns></returns>
        int Insert(Article article);

        /// <summary>
        /// 更新日志
        /// </summary>
        /// <param name="article">日志</param>
        /// <returns></returns>
        int Update(Article article);

        /// <summary>
        /// 查询日志
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        List<Article> Select(Dictionary<string, object> condition);

        /// <summary>
        /// 获取指定日志
        /// </summary>
        /// <param name="articleId">日志编号</param>
        /// <returns></returns>
        Article Select(int articleId);

        /// <summary>
        /// 删除日志
        /// </summary>
        /// <param name="articleId">日志编号</param>
        /// <returns></returns>
        int Delete(int articleId);

    }
}
