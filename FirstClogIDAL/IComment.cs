using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirstClogModel;

namespace FirstClogIDAL
{
    public interface IComment
    {
        /// <summary>
        /// 插入评论
        /// </summary>
        /// <param name="comment">评论</param>
        /// <returns></returns>
        int Insert(Comment comment);


        /// <summary>
        /// 更新评论
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        int Update(Comment comment);


        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="commentId">评论编号</param>
        /// <returns></returns>
        int Delete(int commentId);

    }
}
