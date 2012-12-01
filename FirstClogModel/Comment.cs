using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstClogModel
{
    /*************************************************************************************
    * CLR版本：         4.0.30319.269
    * 类 名 称：       Comment
    * 机器名称：       HSERVER
    * 命名空间：       FirstClogModel
    * 文 件 名：       Comment
    * 创建时间：       2012/7/24 21:27:15
    * 作    者：       常伟华 Changweihua
    * 
    * 修改时间：
    * 修 改 人：
   *************************************************************************************/
    /// <summary>
    /// 日志评论类
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// 评论编号
        /// </summary>
        public int CommentId { get; set; }
        /// <summary>
        /// 日志编号
        /// </summary>
        public int ArticleId { get; set; }
        /// <summary>
        /// 发表日期
        /// </summary>
        public DateTime CommentDate { get; set; }
        /// <summary>
        /// 评论者
        /// </summary>
        public string CommentPoster { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string CommentContent { get; set; }
        /// <summary>
        /// 评论者邮箱
        /// </summary>
        public string CommentMail { get; set; }
        /// <summary>
        /// 评论者个人网站
        /// </summary>
        public string CommentUrl { get; set; }
        /// <summary>
        /// 评论者IP
        /// </summary>
        public string CommentIp { get; set; }
        /// <summary>
        /// 是否隐藏评论
        /// </summary>
        public bool CommentHide { get; set; }
    }
}
