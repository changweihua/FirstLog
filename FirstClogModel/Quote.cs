using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstClogModel
{
    /*************************************************************************************
    * CLR版本：         4.0.30319.269
    * 类 名 称：       Quote
    * 机器名称：       HSERVER
    * 命名空间：       FirstClogModel
    * 文 件 名：       Quote
    * 创建时间：       2012/7/24 21:59:42
    * 作    者：       常伟华 Changweihua
    * 
    * 修改时间：
    * 修 改 人：
   *************************************************************************************/
    /// <summary>
    /// 引用类
    /// </summary>
    public class Quote
    {
        /// <summary>
        /// 引用编号
        /// </summary>
        public int QuoteId { get; set; }
        /// <summary>
        /// 日志编号
        /// </summary>
        public int ArticleId { get; set; }
        /// <summary>
        /// 引用标题
        /// </summary>
        public string QuoteTitle { get; set; }
        /// <summary>
        /// 引用日期
        /// </summary>
        public DateTime QuoteDate { get; set; }
        /// <summary>
        /// 摘要
        /// </summary>
        public string QuoteSummary { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string QuoteUrl { get; set; }
        /// <summary>
        /// 博客名称
        /// </summary>
        public string QuoteBlogName { get; set; }
        /// <summary>
        /// IP
        /// </summary>
        public string QuoteIp { get; set; }
    }
}
