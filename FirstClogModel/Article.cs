using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstClogModel
{
    /*************************************************************************************
    * CLR版本：         4.0.30319.269
    * 类 名 称：       Article
    * 机器名称：       HSERVER
    * 命名空间：       FirstClogModel
    * 文 件 名：       Article
    * 创建时间：       2012/7/24 21:11:18
    * 作    者：       常伟华 Changweihua
    * 
    * 修改时间：
    * 修 改 人：
   *************************************************************************************/
    /// <summary>
    /// 日志类
    /// </summary>
    public class Article
    {
        /// <summary>
        /// 日志编号
        /// </summary>
        public int ArticleId { get; set; }
        /// <summary>
        /// 日志标题
        /// </summary>
        public string ArticleTitle { get; set; }
        /// <summary>
        /// 发表时间
        /// </summary>
        public DateTime ArticleDate { get; set; }
        /// <summary>
        /// 日志内容
        /// </summary>
        public string ArticleContent { get; set; }
        /// <summary>
        /// 日志摘要
        /// </summary>
        public string ArticleSummary { get; set; }
        /// <summary>
        /// 链接别名
        /// </summary>
        public string ArticleAlias { get; set; }
        /// <summary>
        /// 作者编号
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 分类编号
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// 浏览次数
        /// </summary>
        public int ArticleViews { get; set; }
        /// <summary>
        /// 评论次数
        /// </summary>
        public int ArticleComments { get; set; }
        /// <summary>
        /// 引用次数
        /// </summary>
        public int QuoteCount { get; set; }
        /// <summary>
        /// 附件个数
        /// </summary>
        public int AttachmentCount { get; set; }
        /// <summary>
        /// 是否置顶
        /// </summary>
        public bool ArticleTop { get; set; }
        /// <summary>
        /// 是否隐藏
        /// </summary>
        public bool ArticleHide { get; set; }
        /// <summary>
        /// 是否允许评论
        /// </summary>
        public bool ArticleAllowComment { get; set; }
        /// <summary>
        /// 是否允许引用
        /// </summary>
        public bool ArticleAllowQuote { get; set; }
        /// <summary>
        /// 日志密码
        /// </summary>
        public string ArticlePassword { get; set; }
    }
}
