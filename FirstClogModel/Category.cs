using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstClogModel
{
    /*************************************************************************************
    * CLR版本：         4.0.30319.269
    * 类 名 称：       Category
    * 机器名称：       HSERVER
    * 命名空间：       FirstClogModel
    * 文 件 名：       Category
    * 创建时间：       2012/7/24 21:48:15
    * 作   者：       常伟华 Changweihua
    * 
    * 修改时间：
    * 修 改 人：
   *************************************************************************************/
    /// <summary>
    /// 日志类别类
    /// </summary>
    public class Category
    {
        /// <summary>
        /// 类别编号
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// 类别别名
        /// </summary>
        public string CategoryAlias { get; set; }
        /// <summary>
        /// 类别排序
        /// </summary>
        public int CategoryTaxis { get; set; }
    }
}
