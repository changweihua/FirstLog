using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace FirstClogCommon
{
    /*************************************************************************************
    * CLR版本：         4.0.30319.269
    * 类 名 称：       XmlDoc
    * 机器名称：       HSERVER
    * 命名空间：       FirstClogCommon
    * 文 件 名：       XmlDoc
    * 创建时间：       2012/7/26 8:17:48
    * 作    者：       常伟华 Changweihua
    * 
    * 修改时间：
    * 修 改 人：
   *************************************************************************************/
    /// <summary>
    /// 添加类描述
    /// </summary>
    public class XmlDoc
    {
        XmlDocument doc = null;
        string xmlFileName = string.Empty;
        readonly string xmlRootName = string.Empty;
        public XmlNode xmlRoot = null;

        //设置XML文件
        public string FileName
        {
            set
            {
                this.xmlFileName = value;
            }
        }

        /// <summary>
        /// 类初始化
        /// </summary>
        /// <param name="fileName">xml文件完整路径</param>
        /// <param name="root">xml根节点</param>
        public XmlDoc(string fileName, string root)
        {
            xmlRootName = root;
            xmlFileName = fileName;
            doc = new XmlDocument();
            try
            {
                doc.Load(xmlFileName);
            }
            catch
            {
                doc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\" ?><" + root + "></" + root + ">");
            }
            xmlRoot = doc.SelectSingleNode(xmlRootName);
        }

        /// <summary>
        /// 类初始化(从内容实例化XML)
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="root">xml根节点</param>
        //public XmlDoc(string content, string root)
        //{
        //    xmlRootName = root;
        //    doc = new XmlDocument();
        //    try
        //    {
        //        doc.LoadXml(content);
        //    }
        //    catch
        //    {
        //        doc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\" ?><" + xmlRootName + "></" + xmlRootName + ">");
        //    }
        //    xmlRoot = doc.SelectSingleNode(xmlRootName);
        //    xmlFileName = root + ".xml";
        //}
    }
}
