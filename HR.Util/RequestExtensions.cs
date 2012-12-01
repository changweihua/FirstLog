using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HR.Util
{
    /*************************************************************************************
     * CLR 版本:       4.0.30319.269
     * 类 名 称:       RequestExtensions
     * 机器名称:       HSERVER
     * 命名空间:       HR.Util
     * 文 件 名:       RequestExtensions
     * 创建时间:       2012/10/12 20:52:21
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
    public static class RequestExtensions
    {
        /// <summary>
        /// 在重定向前检测重定向页面是否合法
        /// </summary>
        /// <param name="request">HTTP请求</param>
        /// <param name="url">请求地址</param>
        /// <returns></returns>
        public static bool IsUrlLocalToHost(this HttpRequest request, string url)
        {
            if (String.IsNullOrEmpty(url))
            {
                return false;
            }

            Uri absoluteUri;
            if (Uri.TryCreate(url, UriKind.Absolute, out absoluteUri))
            {
                return String.Equals(request.Url.Host, absoluteUri.Host, StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                bool isLocal = !url.StartsWith("http:", StringComparison.OrdinalIgnoreCase)
                    && !url.StartsWith("https:", StringComparison.OrdinalIgnoreCase)
                    && Uri.IsWellFormedUriString(url, UriKind.Relative);
                return isLocal;
            }

        }

    }
}
