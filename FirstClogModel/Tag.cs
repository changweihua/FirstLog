using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstClogModel
{
    /*************************************************************************************
    * CLR版本：         4.0.30319.269
    * 类 名 称：       Tag
    * 机器名称：       HSERVER
    * 命名空间：       FirstClogModel
    * 文 件 名：       Tag
    * 创建时间：       2012/7/24 21:57:55
    * 作    者：       常伟华 Changweihua
    * 
    * 修改时间：
    * 修 改 人：
   *************************************************************************************/
    /// <summary>
    /// 标签类
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// 标签编号
        /// </summary>
        public int TagId { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary>
        public string TagName { get; set; }
        /// <summary>
        /// 日志编号
        /// </summary>
        public int ArticleId { get; set; }
    }
}
