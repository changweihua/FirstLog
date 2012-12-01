using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirstClogModel;

namespace FirstClogIDAL
{
    public interface ILink
    {
        /// <summary>
        /// 插入友链
        /// </summary>
        /// <param name="link">友链</param>
        /// <returns></returns>
        int Insert(Link link);


        /// <summary>
        /// 删除友链
        /// </summary>
        /// <param name="linkId">友链编号</param>
        /// <returns></returns>
        int Delete(int linkId);


        /// <summary>
        /// 更新友链
        /// </summary>
        /// <param name="link">友链</param>
        /// <returns></returns>
        int Update(Link link);


        /// <summary>
        /// 查询友链
        /// </summary>
        /// <param name="linkId">友链编号</param>
        /// <returns></returns>
        Link Select(int linkId);

        /// <summary>
        /// 查询所有友链
        /// </summary>
        /// <returns></returns>
        List<Link> Select();
    }
}
