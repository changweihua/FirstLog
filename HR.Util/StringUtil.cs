using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace HR.Util
{
    /*************************************************************************************
     * CLR 版本:       4.0.30319.269
     * 类 名 称:       StringUtil
     * 机器名称:       HSERVER
     * 命名空间:       HR.Util
     * 文 件 名:       StringUtil
     * 创建时间:       2012/10/12 20:06:40
     * 作    者:       常伟华 Changweihua
     * 签    名:       To be or not, it is not a problem !
     * 网    站:       http://www.cmono.net
     * 邮    箱:       changweihua@outlook.com
     * 
     * 修改时间:
     * 修 改 人:
     * 
     ************************************************************************************/
    /// <summary>
    /// 字符串工具类
    /// </summary>
    public class StringUtil
    {
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str">需要截取的字符串</param>
        /// <param name="length">截取长度</param>
        /// <param name="defValue">长度不够，默认添加的值</param>
        /// <returns></returns>
        public static string GetSubString(string str, int length, string defValue)
        {
            int strLength = str.Length;
            StringBuilder sb = new StringBuilder(str);

            if (length >= strLength)
            {
                for (int i = 0; i < length - strLength; i++)
                {
                    sb.Append(defValue);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 清除字符串的HTML标记
        /// </summary>
        /// <param name="str">待清除的字符串</param>
        /// <returns>清除之后的字符串</returns>
        public static string RemoveHtmlMark(string str)
        {
            if (str != null)
            {
                str = Regex.Replace(str, @"<script[^>]*>[\s\S]*?</script>", "", RegexOptions.IgnoreCase);//删除脚本
                str = Regex.Replace(str, @"(<style)+[^<>]*>[^\0]*(<\/style>)+", "", RegexOptions.IgnoreCase);//删除样式
                str = Regex.Replace(str, @"<object.*?/object>", "", RegexOptions.IgnoreCase);//删除object
                str = Regex.Replace(str, @"<!--.*", "", RegexOptions.IgnoreCase);//删除开始注释
                str = Regex.Replace(str, @"-->", "", RegexOptions.IgnoreCase);//删除结尾注释
                //str = Regex.Replace(str, @"<\/*[^<>]*>", "", RegexOptions.IgnoreCase);//删除全部html
                //str = Regex.Replace(str, @"<(\/){0,1}div[^<>]*>", "", RegexOptions.IgnoreCase);//删除div
                //str = Regex.Replace(str, @"<(\/){0,1}a[^<>]*>", "", RegexOptions.IgnoreCase);//删除超链接
                //str = Regex.Replace(str, @"<(\/){0,1}font[^<>]*>", "", RegexOptions.IgnoreCase);//删除文字样式
                //str = Regex.Replace(str, @"(class=){1,}(""|\'){0,1}\S+(""|\'|>|\s){0,1}", "", RegexOptions.IgnoreCase);//删除class
                //str = Regex.Replace(str, @"(<iframe){1,}[^<>]*>[^\0]*(<\/iframe>){1,}", "", RegexOptions.IgnoreCase);//删除框架
                //str = Regex.Replace(str, @"(<script){1,}[^<>]*>[^\0]*(<\/script>){1,}", "", RegexOptions.IgnoreCase);//删除脚本
                str = Regex.Replace(str, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);//删除全部html
                str = Regex.Replace(str, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);//删除换行
                str = Regex.Replace(str, @"  ", "　", RegexOptions.IgnoreCase);//替换空格
            }
            return str;
        }

        /// <summary>
        /// 是否启用SQL注入过滤
        /// </summary>
        /// <param name="Inner"></param>
        /// <returns></returns>
        public static bool SafeInnerbool(string Inner)
        {
            return Inner.Equals(SafeInnerHtml(Inner)) ? true : false;
        }

        public static string SafeInnerHtml(string Inner)
        {
            if (!string.IsNullOrEmpty(Inner))
            {
                //删除脚本
                Inner = Regex.Replace(Inner, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);

                //删除HTML
                Inner = Regex.Replace(Inner, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, @"-->", "", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, @"<!--.*", "", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, @"&#(\d+);", "", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, "xp_cmdshell", "", RegexOptions.IgnoreCase);

                //删除与数据库相关的词
                Inner = Regex.Replace(Inner, "select", "", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, "insert", "", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, "delete from", "", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, "count''", "", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, "drop table", "", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, "truncate", "", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, "asc", "", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, "mid", "", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, "char", "", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, "xp_cmdshell", "", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, "exec master", "", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, "net localgroup administrators", "", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, "and", "", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, "net user", "", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, "or", "", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, "net", "", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, "*", "", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, "-", "", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, "delete", "", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, "drop", "", RegexOptions.IgnoreCase);
                Inner = Regex.Replace(Inner, "script", "", RegexOptions.IgnoreCase);

                //特殊的字符
                Inner = Inner.Replace("<", "");
                Inner = Inner.Replace(">", "");
                Inner = Inner.Replace("*", "");
                Inner = Inner.Replace("-", "");
                Inner = Inner.Replace("?", "");
                Inner = Inner.Replace("'", "''");
                Inner = Inner.Replace(",", "");
                Inner = Inner.Replace("/", "");
                Inner = Inner.Replace(";", "");
                Inner = Inner.Replace("*/", "");
                Inner = Inner.Replace("\r\n", "");
                Inner = HttpContext.Current.Server.HtmlEncode(Inner).Trim();
                return Inner;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 字符串长度(按字节算)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static int StrLength(string str)
        {
            int len = 0;
            byte[] b;

            for (int i = 0; i < str.Length; i++)
            {
                b = Encoding.Default.GetBytes(str.Substring(i, 1));
                if (b.Length > 1)
                    len += 2;
                else
                    len++;
            }

            return len;
        }

        /// <summary>
        /// 截取指定长度字符串(按字节算)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        static string StrCut(string str, int length)
        {
            int len = 0;
            byte[] b;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                b = Encoding.Default.GetBytes(str.Substring(i, 1));
                if (b.Length > 1)
                    len += 2;
                else
                    len++;

                if (len >= length)
                    break;

                sb.Append(str[i]);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 获得某个特定字符在指定字符串中出现的次数
        /// </summary>
        /// <param name="argString">指定字符串</param>
        /// <param name="argChar">特定字符</param>
        /// <returns>出现的次数</returns>
        public static int GetDisplayCount(string argString, char argChar)
        {
            if (argString == null || argString.Length == 0)
                return 0;

            int count = 0;
            int currentPos = 0;
            while (true)
            {
                currentPos = argString.IndexOf(argChar, currentPos) + 1;
                if (currentPos == 0)
                    break;
                else
                    count = count + 1;
            }
            return count;
        }



    }
}
