﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace FirstClogCommon
{
    /*************************************************************************************
    * CLR版本：         4.0.30319.269
    * 类 名 称：       ScriptHelper
    * 机器名称：       HSERVER
    * 命名空间：       FirstClogCommon
    * 文 件 名：       ScriptHelper
    * 创建时间：       2012/8/4 10:33:43
    * 作    者：       常伟华 Changweihua
    * 
    * 修改时间：
    * 修 改 人：
   *************************************************************************************/
    /// <summary>
    /// 添加类描述
    /// </summary>
    public class ScriptHelper
    {
        #region 旧版本
        /// <summary>
        /// 弹出JavaScript小窗口
        /// </summary>
        /// <param name="message">窗口信息</param>
        public static void Alert(string message)
        {
            #region
            string js = @"<script type='text/javascript'>
                    alert('" + message + "');</script>";
            HttpContext.Current.Response.Write(js);
            #endregion
        }

        /// <summary>
        /// 弹出消息框并且转向到新的URL
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="toURL">连接地址</param>
        public static void AlertAndRedirect(string message, string toURL)
        {
            #region
            string js = "<script type=javascript>alert('{0}');window.location.replace('{1}')</script>";
            HttpContext.Current.Response.Write(string.Format(js, message, toURL));
            #endregion
        }

        /// <summary>
        /// 回到历史页面
        /// </summary>
        /// <param name="value">-1/1</param>
        public static void GoHistory(int value)
        {
            #region
            string js = @"<script type='text/javascript'>
                    history.go({0});  
                  </script>";
            HttpContext.Current.Response.Write(string.Format(js, value));
            #endregion
        }

        /// <summary>
        /// 关闭当前窗口
        /// </summary>
        public static void CloseWindow()
        {
            #region
            string js = @"<script type='text/javascript'>
                    parent.opener=null;window.close();  
                  </script>";
            HttpContext.Current.Response.Write(js);
            HttpContext.Current.Response.End();
            #endregion
        }

        /// <summary>
        /// 刷新父窗口
        /// </summary>
        public static void RefreshParent(string url)
        {
            #region
            string js = @"<script type='text/javascript'>
                    window.opener.location.href='" + url + "';window.close();</script>";
            HttpContext.Current.Response.Write(js);
            #endregion
        }


        /// <summary>
        /// 刷新打开窗口
        /// </summary>
        public static void RefreshOpener()
        {
            #region
            string js = @"<script type='text/javascript'>
                    opener.location.reload();
                  </script>";
            HttpContext.Current.Response.Write(js);
            #endregion
        }


        /// <summary>
        /// 打开指定大小的新窗体
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="width">宽</param>
        /// <param name="heigth">高</param>
        /// <param name="top">头位置</param>
        /// <param name="left">左位置</param>
        public static void OpenWebFormSize(string url, int width, int heigth, int top, int left)
        {
            #region
            string js = @"<script type='text/javascript'>window.open('" + url + @"','','height=" + heigth + ",width=" + width + ",top=" + top + ",left=" + left + ",location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');</script>";

            HttpContext.Current.Response.Write(js);
            #endregion
        }


        /// <summary>
        /// 转向Url制定的页面
        /// </summary>
        /// <param name="url">连接地址</param>
        public static void JavaScriptLocationHref(string url)
        {
            #region
            string js = @"<script type='text/javascript'>
                    window.location.replace('{0}');
                  </script>";
            js = string.Format(js, url);
            HttpContext.Current.Response.Write(js);
            #endregion
        }

        /// <summary>
        /// 打开指定大小位置的模式对话框
        /// </summary>
        /// <param name="webFormUrl">连接地址</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <param name="top">距离上位置</param>
        /// <param name="left">距离左位置</param>
        public static void ShowModalDialogWindow(string webFormUrl, int width, int height, int top, int left)
        {
            #region
            string features = "dialogWidth:" + width.ToString() + "px"
                + ";dialogHeight:" + height.ToString() + "px"
                + ";dialogLeft:" + left.ToString() + "px"
                + ";dialogTop:" + top.ToString() + "px"
                + ";center:yes;help=no;resizable:no;status:no;scroll=yes";
            ShowModalDialogWindow(webFormUrl, features);
            #endregion
        }
        /// <summary>
        /// 弹出模态窗口
        /// </summary>
        /// <param name="webFormUrl"></param>
        /// <param name="features"></param>
        public static void ShowModalDialogWindow(string webFormUrl, string features)
        {
            string js = ShowModalDialogJavascript(webFormUrl, features);
            HttpContext.Current.Response.Write(js);
        }
        /// <summary>
        /// 弹出模态窗口
        /// </summary>
        /// <param name="webFormUrl"></param>
        /// <param name="features"></param>
        /// <returns></returns>
        public static string ShowModalDialogJavascript(string webFormUrl, string features)
        {
            #region
            string js = @"<script type=javascript>                            
                            showModalDialog('" + webFormUrl + "','','" + features + "');</script>";
            return js;
            #endregion
        }
        #endregion

        #region 新版本
        /// <summary>
        /// 弹出JavaScript小窗口
        /// </summary>
        /// <param name="message">窗口信息</param>
        /// <param name="page">Page类的实例</param>
        public static void Alert(string message, Page page)
        {
            #region
            string js = @"<script type='text/javascript'>
                    alert('" + message + "');</script>";
            if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "alert"))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "alert", js);
            }
            #endregion
        }

        /// <summary>
        /// 弹出消息框并且转向到新的URL
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="toURL">连接地址</param>
        /// <param name="page">Page类的实例</param> 
        public static void AlertAndRedirect(string message, string toURL, Page page)
        {
            #region
            string js = "<script type=javascript>alert('{0}');window.location.replace('{1}')</script>";
            if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "AlertAndRedirect"))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "AlertAndRedirect", string.Format(js, message, toURL));
            }
            #endregion
        }

        /// <summary>
        /// 回到历史页面
        /// </summary>
        /// <param name="value">-1/1</param>
        /// <param name="page">Page类的实例</param> 
        public static void GoHistory(int value, Page page)
        {
            #region
            string js = @"<script type='text/javascript'>
                    history.go({0});  
                  </script>";
            if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "GoHistory"))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "GoHistory", string.Format(js, value));
            }
            #endregion
        }

        /// <summary>
        /// 刷新父窗口
        /// </summary>
        /// <param name="url">要刷新的url</param>
        /// <param name="page">Page类的实例</param>
        public static void RefreshParent(string url, Page page)
        {
            #region
            string js = @"<script type='text/javascript'>
                    window.opener.location.href='" + url + "';window.close();</script>";
            //HttpContext.Current.Response.Write(js);
            if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "RefreshParent"))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "RefreshParent", js);
            }
            #endregion
        }


        /// <summary>
        /// 刷新打开窗口
        /// </summary>
        /// <param name="page">Page类的实例</param>
        public static void RefreshOpener(Page page)
        {
            #region
            string js = @"<script type='text/javascript'>
                    opener.location.reload();
                  </script>";
            //HttpContext.Current.Response.Write(js);
            if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "RefreshOpener"))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "RefreshOpener", js);
            }
            #endregion
        }


        /// <summary>
        /// 打开指定大小的新窗体
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="width">宽</param>
        /// <param name="heigth">高</param>
        /// <param name="top">头位置</param>
        /// <param name="left">左位置</param>
        /// <param name="page">Page类的实例</param>
        public static void OpenWebFormSize(string url, int width, int heigth, int top, int left, Page page)
        {
            #region
            string js = @"<script type='text/javascript'>window.open('" + url + @"','','height=" + heigth + ",width=" + width + ",top=" + top + ",left=" + left + ",location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');</script>";
            //HttpContext.Current.Response.Write(js);
            if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "OpenWebFormSize"))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "OpenWebFormSize", js);
            }
            #endregion
        }


        /// <summary>
        /// 转向Url制定的页面
        /// </summary>
        /// <param name="url">连接地址</param>
        /// <param name="page">Page类的实例</param>
        public static void JavaScriptLocationHref(string url, Page page)
        {
            #region
            string js = @"<script type='text/javascript'>
                    window.location.replace('{0}');
                  </script>";
            js = string.Format(js, url);
            if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "JavaScriptLocationHref"))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "JavaScriptLocationHref", js);
            }
            #endregion
        }

        /// <summary>
        /// 打开指定大小位置的模式对话框
        /// </summary>
        /// <param name="webFormUrl">连接地址</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <param name="top">距离上位置</param>
        /// <param name="left">距离左位置</param>
        /// <param name="page">Page类的实例</param>
        public static void ShowModalDialogWindow(string webFormUrl, int width, int height, int top, int left, Page page)
        {
            #region
            string features = "dialogWidth:" + width.ToString() + "px"
                + ";dialogHeight:" + height.ToString() + "px"
                + ";dialogLeft:" + left.ToString() + "px"
                + ";dialogTop:" + top.ToString() + "px"
                + ";center:yes;help=no;resizable:no;status:no;scroll=yes";
            ShowModalDialogWindow(webFormUrl, features, page);
            #endregion
        }
        /// <summary>
        /// 弹出模态窗口
        /// </summary>
        /// <param name="webFormUrl"></param>
        /// <param name="features"></param>
        /// <param name="page">Page类的实例</param>
        public static void ShowModalDialogWindow(string webFormUrl, string features, Page page)
        {
            string js = ShowModalDialogJavascript(webFormUrl, features);
            if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "ShowModalDialogWindow"))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "ShowModalDialogWindow", js);
            }
        }
        /// <summary>
        /// 向当前页面动态输出客户端脚本代码
        /// </summary>
        /// <param name="javascript">javascript脚本段</param>
        /// <param name="page">Page类的实例</param>
        /// <param name="afterForm">是否紧跟在&lt;form&gt;标记之后输出javascript脚本，如果不是则在&lt;/form&gt;标记之前输出脚本代码</param>
        public static void AppendScript(string javascript, Page page, bool afterForm)
        {
            if (afterForm)
            {
                page.ClientScript.RegisterClientScriptBlock(page.GetType(), page.ToString(), javascript);
            }
            else
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), page.ToString(), javascript);
            }
        }
        #endregion
    }
}
