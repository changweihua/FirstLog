using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstClogModel
{
    /*************************************************************************************
    * CLR版本：         4.0.30319.269
    * 类 名 称：       Link
    * 机器名称：       HSERVER
    * 命名空间：       FirstClogModel
    * 文 件 名：       Link
    * 创建时间：       2012/7/24 21:35:58
    * 作    者：       常伟华 Changweihua
    * 
    * 修改时间：
    * 修 改 人：
   *************************************************************************************/
    /// <summary>
    /// 友情链接类
    /// </summary>
    public class Link
    {
        /// <summary>
        /// 链接编号
        /// </summary>
        public int LinkId { get; set; }
        /// <summary>
        /// 链接名称
        /// </summary>
        public string LinkSiteName { get; set; }
        /// <summary>
        /// 链接地址
        /// </summary>
        public string LinkSiteUrl { get; set; }
        /// <summary>
        /// 链接描述
        /// </summary>
        public string LinkDescription { get; set; }
        /// <summary>
        /// 链接序号
        /// </summary>
        public int LinkSortNum { get; set; }
    }
}
