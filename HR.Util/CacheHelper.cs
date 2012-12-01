using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace HR.Util
{
    /*************************************************************************************
     * CLR 版本:       4.0.30319.269
     * 类 名 称:       CacheHelper
     * 机器名称:       HSERVER
     * 命名空间:       HR.Util
     * 文 件 名:       CacheHelper
     * 创建时间:       2012/10/12 20:40:05
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
    /// 缓存帮助类
    /// </summary>
    public class CacheHelper
    {
        /// <summary>
        /// 清除浏览器缓存 
        /// </summary>
        /// <param name="page">当前页</param>
        public static void ClearClientPageCache(HttpResponse response)
        {
            response.Buffer = true;
            response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            response.Cache.SetExpires(DateTime.Now.AddDays(-1));
            response.Expires = 0;
            response.CacheControl = "no-cache";
            response.Cache.SetNoStore();
        }

        /// <summary>
        /// 禁止客户端缓存
        /// </summary>
        protected void DisablePageCache(HttpResponse response)
        {
            response.Expires = 0;
            response.Cache.SetNoStore();
            response.AppendHeader("Pragma", "no-cache");
        }

    }
}
