using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace HR.Util
{
    /*************************************************************************************
     * CLR 版本:       4.0.30319.269
     * 类 名 称:       ValidatorHelper
     * 机器名称:       HSERVER
     * 命名空间:       HR.Util
     * 文 件 名:       ValidatorHelper
     * 创建时间:       2012/10/12 21:14:47
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
    /// 数据验证帮助类
    /// </summary>
    public class ValidatorHelper
    {
        /// <summary>
        /// 验证是否为正整数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumeric(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                return Regex.IsMatch(str, @"^[0-9]*$");
            }
            else return false;
        }

        /// <summary>
        /// 判断对象是否为Int32类型的数字
        /// </summary>
        /// <param name="expression">需验证数据</param>
        /// <returns></returns>
        public static bool IsInt(object expression)
        {
            if (expression != null)
            {
                string str = expression.ToString();
                if (str.Length > 0 && str.Length <= 11 && Regex.IsMatch(str, @"^[-]?[0-9]*[.]?[0-9]*$"))
                {
                    if ((str.Length < 10) || (str.Length == 10 && str[0] == '1') || (str.Length == 11 && str[0] == '-' && str[1] == '1'))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 是否为long类型
        /// </summary>
        /// <param name="str">需要判断的数据</param>
        /// <returns></returns>
        public static bool IsLong(string str)
        {
            long temp;
            try
            {
                temp = long.Parse(str);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 是否为float类型
        /// </summary>
        /// <param name="expression">要验证的字符串</param>
        /// <returns></returns>
        public static bool IsFloat(object expression)
        {
            if (expression != null)
            {
                return Regex.IsMatch(expression.ToString(), @"^([0-9])[0-9]*(\.\w*)?$");
            }
            return false;
        }

        /// <summary>
        /// 是否为Decimal类型
        /// </summary>
        /// <param name="input">需验证字符串</param>
        /// <returns>验证结果</returns>
        public static bool IsDecimal(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            if (Regex.IsMatch(input, "^([0-9]{1,})$"))
            {
                return true;
            }

            return Regex.IsMatch(input, "^[0-9]+[.]?[0-9]+$");
        }

        /// <summary>
        /// 验证字符串是否日期[2004-2-29|||2004-02-29 10:29:39 pm|||2004/12/31]
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns></returns>
        public static bool IsDate(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            string regexString = @"^((\d{2}(([02468][048])|([13579][26]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|([1-2][0-9])))))|(\d{2}(([02468][1235679])|([13579][01345789]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|(1[0-9])|(2[0-8]))))))(\s(((0?[1-9])|(1[0-2]))\:([0-5][0-9])((\s)|(\:([0-5][0-9])\s))([AM|PM|am|pm]{2,2})))?$";

            return Regex.IsMatch(input, regexString);
        }

        /// <summary>
        /// 是否为时间
        /// </summary>
        /// <returns></returns>
        public static bool IsTime(string timeval)
        {
            return Regex.IsMatch(timeval, @"^((([0-1]?[0-9])|(2[0-3])):([0-5]?[0-9])(:[0-5]?[0-9])?)$");
        }

        /// <summary>
        /// 检测是否为有效的手机号码
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static bool IsMobile(string mobile)
        {
            mobile = mobile.Trim();
            //如果号码长度大于11，移除第一位的0
            if (mobile.Length > 11)
            {
                if (mobile.Substring(0, 1) == "0")
                    mobile = mobile.Remove(0, 1);
            }

            //长度不等11
            if (mobile.Length != 11)
                return false;

            return Regex.IsMatch(mobile, @"^1[358]\d{9}$", RegexOptions.IgnoreCase);
        }


        /// <summary>
        /// 是否为邮箱地址
        /// </summary>
        /// <param name="input">需验证字符串</param>
        /// <returns>验证结果</returns>
        public static bool IsEmail(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            return Regex.IsMatch(input, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        /// <summary>
        /// 验证字符串是否为IP地址
        /// </summary>
        /// <param name="input">需验证字符串</param>
        /// <returns>验证结果</returns>
        public static bool IsIP(string input)
        {
            return Regex.IsMatch(input, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        /// <summary>
        /// 是否为邮政编码
        /// </summary>
        /// <param name="input">需验证字符串</param>
        /// <returns>验证结果</returns>
        public static bool IsPostcode(string input)
        {
            return (IsNumeric(input) && (input.Length == 6));
        }

        /// <summary>
        /// 判断是否为base64字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsBase64String(string str)
        {
            //A-Z, a-z, 0-9, +, /, =
            return Regex.IsMatch(str, @"[A-Za-z0-9\+\/\=]");
        }

        /// <summary>
        /// 判断文件流是否为UTF8字符集
        /// </summary>
        /// <param name="sbInputStream">文件流</param>
        /// <returns>判断结果</returns>
        private static bool IsUTF8(FileStream sbInputStream)
        {
            int i;
            byte cOctets;  // octets to go in this UTF-8 encoded character 
            byte chr;
            bool bAllAscii = true;
            long iLen = sbInputStream.Length;

            cOctets = 0;
            for (i = 0; i < iLen; i++)
            {
                chr = (byte)sbInputStream.ReadByte();

                if ((chr & 0x80) != 0)
                    bAllAscii = false;

                if (cOctets == 0)
                {
                    if (chr >= 0x80)
                    {
                        do
                        {
                            chr <<= 1;
                            cOctets++;
                        }
                        while ((chr & 0x80) != 0);

                        cOctets--;
                        if (cOctets == 0)
                            return false;
                    }
                }
                else
                {
                    if ((chr & 0xC0) != 0x80)
                    {
                        return false;
                    }
                    cOctets--;
                }
            }

            if (cOctets > 0)
            {
                return false;
            }

            if (bAllAscii)
            {
                return false;
            }

            return true;

        }

        /// <summary>
        /// 是否为URL网址
        /// </summary>
        /// <param name="input">需验证字符串</param>
        /// <returns>验证结果</returns>
        public static bool IsURL(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            return Regex.IsMatch(input, @"^(http|https)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&%\$#\=~_\-]+))*$");
        }

        /// <summary>
        /// 判断文件名是否为浏览器可以直接显示的图片文件名
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns>是否可以直接显示</returns>
        public static bool IsImgFilename(string filename)
        {
            filename = filename.Trim();
            if (filename.EndsWith(".") || filename.IndexOf(".") == -1)
            {
                return false;
            }
            string extname = filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
            return (extname == "jpg" || extname == "jpeg" || extname == "png" || extname == "bmp" || extname == "gif");
        }

        /// <summary>
        /// 验证是否为以,号间隔的数字数组
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumericArray(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                return Regex.IsMatch(str, @"^[0-9,]*$");
            }
            else return false;
        }
    }
}
