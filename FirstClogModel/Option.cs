using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstClogModel
{
    /*************************************************************************************
    * CLR版本：         4.0.30319.269
    * 类 名 称：       Option
    * 机器名称：       HSERVER
    * 命名空间：       FirstClogModel
    * 文 件 名：       Option
    * 创建时间：       2012/7/24 21:39:10
    * 作    者：       常伟华 Changweihua
    * 
    * 修改时间：
    * 修 改 人：
   *************************************************************************************/
    /// <summary>
    /// 位置设置类
    /// </summary>
    public class Option
    {
        /// <summary>
        /// 设置编号
        /// </summary>
        public int OptionId { get; set; }
        /// <summary>
        /// 设置名
        /// </summary>
        public string OptionName { get; set; }
        /// <summary>
        /// 设置值
        /// </summary>
        public string OptionValue { get; set; }
    }
}
