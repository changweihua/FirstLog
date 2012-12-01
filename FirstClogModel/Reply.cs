using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstClogModel
{
    /*************************************************************************************
    * CLR版本：         4.0.30319.269
    * 类 名 称：       Reply
    * 机器名称：       HSERVER
    * 命名空间：       FirstClogModel
    * 文 件 名：       Reply
    * 创建时间：       2012/7/24 21:42:48
    * 作    者：       常伟华 Changweihua
    * 
    * 修改时间：
    * 修 改 人：
   *************************************************************************************/
    /// <summary>
    /// 碎语回复类
    /// </summary>
    public class Reply
    {
        /// <summary>
        /// 回复编号
        /// </summary>
        public int ReplyId { get; set; }
        /// <summary>
        /// 碎语编号
        /// </summary>
        public int TwitterId { get; set; }
        /// <summary>
        /// 回复时间
        /// </summary>
        public DateTime ReplyDate { get; set; }
        /// <summary>
        /// 回复者
        /// </summary>
        public string ReplyName { get; set; }
        /// <summary>
        /// 回复内容
        /// </summary>
        public string ReplyContent { get; set; }
        /// <summary>
        /// 是否隐藏
        /// </summary>
        public bool ReplyHide { get; set; }
        /// <summary>
        /// 回复者IP
        /// </summary>
        public string ReplyIp { get; set; }
    }
}
