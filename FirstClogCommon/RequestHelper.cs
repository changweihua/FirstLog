using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace FirstClogCommon
{
    /*************************************************************************************
    * CLR版本：         4.0.30319.269
    * 类 名 称：       RequestHelper
    * 机器名称：       HSERVER
    * 命名空间：       FirstClogCommon
    * 文 件 名：       RequestHelper
    * 创建时间：       2012/8/8 10:23:22
    * 作    者：       常伟华 Changweihua
    * 
    * 修改时间：
    * 修 改 人：
   *************************************************************************************/
    /// <summary>
    /// 添加类描述
    /// </summary>
    public class RequestHelper
    {
        /// <summary>
        /// 判断当前页面是否接收到了POST请求
        /// </summary>
        /// <returns></returns>
        public static bool IsPost()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("POST");
        }

        /// <summary>
        /// 判断当前页面是否接收到了Get请求
        /// </summary>
        /// <returns></returns>
        public static bool IsGet()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("GET");
        }


        /// <summary>
        /// 取得指定的服务器变量信息
        /// </summary>
        /// <param name="serverVariableName">服务器变量名</param>
        /// <returns></returns>
        public static string GetServerString(string serverVariableName)
        {
            if (HttpContext.Current.Request.ServerVariables[serverVariableName] == null)
            {
                return "";
            }

            return HttpContext.Current.Request.ServerVariables[serverVariableName].ToString();
        }

        /// <summary>
        /// 返回上一个页面的地址
        /// </summary>
        /// <returns></returns>
        public static string GetUrlReferrer()
        {
            string url = null;

            url = HttpContext.Current.Request.UrlReferrer.ToString();

            if (url == null)
            {
                return "";
            }

            return url;

        }

        /// <summary>
        /// 得到完整的主机头
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentFullHost()
        {
            HttpRequest request = HttpContext.Current.Request;

            if (!request.Url.IsDefaultPort)
            {
                return string.Format("{0}:{1}", request.Url.Host, request.Url.Port); ;
            }

            return request.Url.Host;

        }

        /// <summary>
        /// 获取主机头
        /// </summary>
        /// <returns></returns>
        public static string GetHost()
        {
            return HttpContext.Current.Request.Url.Host;
        }


        /// <summary>
        /// 按照当前请求的原始URL(URL中域信息之后的部分，包括查询字符串)
        /// </summary>
        /// <returns></returns>
        public static string GetRawUrl()
        {
            return HttpContext.Current.Request.RawUrl;
        }


        /// <summary>
        /// 判断当前访问是否来自浏览器软件
        /// </summary>
        /// <returns></returns>
        public static bool IsBrowserGet()
        {
            string[] browserName = { "ie", "opera", "netscape", "mozilla", "konqueror", "firefox" };

            string currentBrowser = HttpContext.Current.Request.Browser.Type.ToLower();

            foreach (string browser in browserName)
            {
                if (currentBrowser.IndexOf(browser) >= 0)
                {
                    return true;
                }
            }

            return false;

        }


        /// <summary>
        /// 判断是否来自搜索引擎链接,可能存在未知的搜索引擎，有待于改进
        /// </summary>
        /// <returns></returns>
        public static bool IsSearchEngineGet()
        {
            if (HttpContext.Current.Request.UrlReferrer == null)
            {
                return true;
            }

            string[] searchEngine = { "google", "yahoo", "msn", "baidu", "sogou", "sohu", "sina", "163", "yisou", "lycos", "tom", "iask", "soso", "gougou", "zhongsou" };

            string tempUrlReferrer = HttpContext.Current.Request.UrlReferrer.ToString().ToLower();

            foreach (string engine in searchEngine)
            {
                if (tempUrlReferrer.IndexOf(engine) >= 0)
                {
                    return true;
                }
            }

            return false;

        }

        /// <summary>
        /// 取得当前完整的URL地址
        /// </summary>
        /// <returns></returns>
        public static string GetUrl()
        {
            return HttpContext.Current.Request.Url.ToString();
        }


        /// <summary>
        /// 获取指定URL参数的值
        /// </summary>
        /// <param name="paramName">URL参数名称</param>
        /// <returns></returns>
        public static string GetQueryString(string paramName)
        {
            return GetQueryString(paramName, false);
        }


        /// <summary>
        /// 获取指定URL的参数的值
        /// </summary>
        /// <param name="paramName">参数名</param>
        /// <param name="sqlSafeCheck">是否进行SQL安全检查</param>
        /// <returns></returns>
        public static string GetQueryString(string paramName, bool sqlSafeCheck)
        {
            if (HttpContext.Current.Request.QueryString[paramName] == null)
            {
                return "";
            }

            /*检查安全*/

            return HttpContext.Current.Request.QueryString[paramName].ToString();

        } 
   

        /// <summary>
        /// 获取当前页面的名称
        /// </summary>
        /// <returns></returns>
        public static string GetPageName()
        {
            string[] urlArray = HttpContext.Current.Request.Url.AbsolutePath.Split('/');

            return urlArray[urlArray.Length - 1].ToLower();
        }


        /// <summary>
        /// 返回表单或URL参数的总个数
        /// </summary>
        /// <returns></returns>
        public static int GetParamCount()
        {
            return HttpContext.Current.Request.Form.Count + HttpContext.Current.Request.QueryString.Count;
        }


        /// <summary>
        /// 获取指定表单参数的值
        /// </summary>
        /// <param name="paramName">参数名</param>
        /// <returns></returns>
        public static string GetFormString(string paramName)
        {
            return GetFormString(paramName, false);
        }

        /// <summary>
        /// 获取指定表单参数的值
        /// </summary>
        /// <param name="paramName">表单参数名</param>
        /// <param name="sqlSafeCheck">是否进行SQL安全检查</param>
        /// <returns></returns>
        public static string GetFormString(string paramName, bool sqlSafeCheck)
        {
            if (HttpContext.Current.Request.Form[paramName] == null)
                return "";

            //SQL安全检查

            return HttpContext.Current.Request.Form[paramName].ToString() ;
        }


        /// <summary>
        /// 获取URL或表单参数的值，先判断URL参数是否为空字符串，如果为空，则返回表单参数的值
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public static string GetString(string paramName)
        {
            return GetString(paramName, false);
        }


        /// <summary>
        /// 获取URL或表单参数的值，先判断URL参数是否为空字符串，如果为空，则返回表单参数的值
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="isSafeCheck">是否开启SQL安全检查</param>
        /// <returns></returns>
        public static string GetString(string paramName, bool isSafeCheck)
        {
            if ("".Equals(GetQueryString(paramName)))
            {
                return GetFormString(paramName, isSafeCheck);
            }
            else
            {
                return GetQueryString(paramName, isSafeCheck);
            }
        }



        public static int GetQueryInt(string paramName)
        {
            return 0;
        }

        public static int GetQueryInt(string paramName, int defValue)
        {
            return 0;
        }

        public static int GetFormInt(string paramName, int defValue)
        {
            return 0;
        }

        /// <summary>
        /// 获得指定Url或表单参数的int类型值, 先判断Url参数是否为缺省值, 如为True则返回表单参数的值
        /// </summary>
        /// <param name="paramName">Url或表单参数</param>
        /// <param name="defaultValue">缺省值</param>
        /// <returns>Url或表单参数的int类型值</returns>
        public static int GetInt(string paramName, int defaultValue)
        {
            if (GetQueryInt(paramName, defaultValue) == defaultValue)
                return GetFormInt(paramName, defaultValue);
            else
                return GetQueryInt(paramName, defaultValue);
        }


        /// <summary>
        /// 获得当前页面客户端的IP
        /// </summary>
        /// <returns>当前页面客户端的IP</returns>
        public static string GetIP()
        {
            string result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            //if (string.IsNullOrEmpty(result))
            //    result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            //if (string.IsNullOrEmpty(result))
            //    result = HttpContext.Current.Request.UserHostAddress;

            //if (string.IsNullOrEmpty(result) || !Utils.IsIP(result))
            //    return "127.0.0.1";

            return result;
        }

        /// <summary>
        /// 保存用户上传的文件
        /// </summary>
        /// <param name="path">保存路径</param>
        public static void SaveRequestFile(string path)
        {
            if (HttpContext.Current.Request.Files.Count > 0)
            {
                HttpContext.Current.Request.Files[0].SaveAs(path);
            }
        }

    }
}
