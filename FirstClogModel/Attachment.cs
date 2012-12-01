using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstClogModel
{
    /*************************************************************************************
    * CLR版本：        4.0.30319.269
    * 类 名 称：       Attachment
    * 机器名称：       HSERVER
    * 命名空间：       FirstClogModel
    * 文 件 名：       Attachment
    * 创建时间：       2012/7/24 20:53:23
    * 作    者：       常伟华 Changweihua
    * 
    * 修改时间：
    * 修 改 人：
   *************************************************************************************/
    /// <summary>
    /// 附件实体类
    /// </summary>
    public class Attachment
    {
        /// <summary>
        /// 附件编号
        /// </summary>
        public int AttachmentId { get; set; }
        /// <summary>
        /// 日志编号
        /// </summary>
        public int ArticleId { get; set; }
        /// <summary>
        /// 附件名称
        /// </summary>
        public string AttachmentFileName { get; set; }
        /// <summary>
        /// 附件大小
        /// </summary>
        public string AttachmentFileSize { get; set; }
        /// <summary>
        /// 附件路径
        /// </summary>
        public string AttachmentFilePath { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AttachmentAddTime { get; set; }
    }
}
