using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirstClogModel;

namespace FirstClogIDAL
{
    public interface IReply
    {
        /// <summary>
        /// 插入碎语评论
        /// </summary>
        /// <param name="reply">回复</param>
        /// <returns></returns>
        int Insert(Reply reply);


        /// <summary>
        /// 删除碎语评论
        /// </summary>
        /// <param name="reply">碎语评论</param>
        /// <returns></returns>
        int Delete(Reply reply);



        /// <summary>
        /// 查询碎语评论
        /// </summary>
        /// <param name="twitterId">碎语编号</param>
        /// <returns></returns>
        List<Reply> Select(int twitterId);

    }
}
