using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirstClogModel;

namespace FirstClogIDAL
{
    public interface IOption
    {
        /// <summary>
        /// 插入网站设置
        /// </summary>
        /// <param name="option">网站设置</param>
        /// <returns></returns>
        int Insert(Option option);


        /// <summary>
        /// 更新网站设置
        /// </summary>
        /// <param name="option">网站设置</param>
        /// <returns></returns>
        int Update(Option option);


        /// <summary>
        /// 查询网站设置
        /// </summary>
        /// <returns>网站设置集合</returns>
        List<Option> Select();

    }
}
