using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HR.Util
{
    /*************************************************************************************
     * CLR 版本:       4.0.30319.269
     * 类 名 称:       ExceptionHelper
     * 机器名称:       HSERVER
     * 命名空间:       HR.Util
     * 文 件 名:       ExceptionHelper
     * 创建时间:       2012/10/13 9:04:42
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
    /// 添加类描述
    /// </summary>
    class ExceptionHelper
    {
        /// <summary>
        /// 把一个异常的堆栈信息处理后返回一个字符串
        /// 一个异常可能是另一个异常实例引发的,这里通过递归把所有的异常消息都处理并返回信息,最后形成一个包含异常足够多信息的字符串
        /// </summary>
        /// <param name="ex">传输的异常</param>
        /// <returns>返回的字符串</returns>
        public static string ExpandStackTrace(Exception ex)
        {
            StringBuilder buffer = new StringBuilder(1024);
            while (ex != null)
            {
                if (buffer.Length > 0)
                {
                    buffer.Insert(0, ex.StackTrace + "\nRe-Thrown (" + ex.Message + ")\n");
                }
                else
                {
                    buffer.Insert(0, ex.StackTrace + "\n");
                }
                ex = ex.InnerException;
            }
            buffer.Replace(" in ", "\n\tin\n");
            return buffer.ToString();
        }

    }
}
