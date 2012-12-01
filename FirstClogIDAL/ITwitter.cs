using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirstClogModel;

namespace FirstClogIDAL
{
    public interface ITwitter
    {
        /// <summary>
        /// 插入新碎语
        /// </summary>
        /// <param name="twitter">碎语</param>
        /// <returns>插入记录数</returns>
        int Insert(Twitter twitter);

        /// <summary>
        /// 删除碎语
        /// </summary>
        /// <param name="twitterId">碎语编号</param>
        /// <returns>受影响函数</returns>
        int Delete(int twitterId);


        /// <summary>
        /// 根据日期筛选碎语
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <returns></returns>
        List<Twitter> Select(DateTime dateTime);

    }
}
