using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.IO;

namespace FirstClogCommon
{
    /*************************************************************************************
    * CLR版本：         4.0.30319.269
    * 类 名 称：       DocHelper
    * 机器名称：       HSERVER
    * 命名空间：       FirstClogCommon
    * 文 件 名：       DocHelper
    * 创建时间：       2012/7/25 12:27:57
    * 作    者：       常伟华 Changweihua
    * 
    * 修改时间：
    * 修 改 人：
   *************************************************************************************/
    /// <summary>
    /// DOc帮助类
    /// 实现Word文档到HTML的转换
    /// Word COM 组件版本 12
    /// </summary>
    public class DocHelper
    {

        /// <summary>
        /// 需要转换的Word文档路径
        /// </summary>
        /// <param name="fileName">完整路径</param>
        /// <returns>HTML页面路径</returns>
        private static string WordToHtml(object fileName)
        {
            Word.Application word = new Word.Application();
            Type wordType = word.GetType();
            Word.Documents docs = word.Documents;

            //打开文件
            Type docsType = docs.GetType();
            Word.Document doc = (Word.Document)docsType.InvokeMember("Open", BindingFlags.InvokeMethod, null, docs, new object[] { fileName, true, true });

            //转换格式，另存
            Type docType = doc.GetType();
            string wordSaveFileName = fileName.ToString();
            string htmlSaveFileName = wordSaveFileName.Substring(0, wordSaveFileName.LastIndexOf(".") + 1) + "html";
            object saveFileName = (object)htmlSaveFileName;
            docType.InvokeMember("SaveAs", BindingFlags.InvokeMethod, null, doc, new object[] { saveFileName, Word.WdSaveFormat.wdFormatFilteredHTML });
            docType.InvokeMember("Close", BindingFlags.InvokeMethod, null, doc, null);

            //退出Word
            wordType.InvokeMember("Quit", BindingFlags.InvokeMethod, null, word, null);

            return saveFileName.ToString();

        }


        /// <summary>
        /// 打印HTML
        /// </summary>
        /// <returns>HTML文本</returns>
        public static string PrintHtml()
        {
            string html = string.Empty;
            string fileName = WordToHtml("F:\\rcs.doc");
            using (StreamReader sr = new StreamReader(fileName, Encoding.GetEncoding("gb2312")))
            {
                html = sr.ReadToEnd();
            }

            return html;
        }

    }
}
