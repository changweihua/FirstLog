using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using FirstClogCommon;

/// <summary>
///BasePage 的摘要说明
/// </summary>
public class BasePage : System.Web.UI.Page
{
    protected void Page_Error(object sender, EventArgs e)
    {
        //获取最新的异常信息
        var ex = Server.GetLastError();
        //记录异常信息
        log4net.ILog log = (log4net.ILog)log4net.LogManager.GetLogger("LogToSqlite");

        //log4net.ILog log2 = (log4net.ILog)log4net.LogManager.GetLogger("LogAllToFile");
        log.Error(ex.Message, ex);
        //log2.Error("出现异常");

        //采集错误信息
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("<strong>异常信息</strong>:{0}<br />", ex.Message);
        sb.AppendFormat("<strong>异常发生时间</strong>:{0}<br />", DateTime.Now.ToString());
        sb.AppendFormat("<strong>IP</strong>:{0}<br />", Request.UserHostAddress);
        sb.AppendFormat("<strong>发生异常页</strong>:{0}<br />", Request.Url.ToString());
        string referUrl ="123456";
        sb.AppendFormat("<strong>上次请求的URL</strong>:{0}<br />", referUrl);
        sb.AppendFormat("<strong>堆栈跟踪</strong>:{0}<br />", ex.StackTrace.Replace("\r\n", "<br />").ToString());

        //发送
        Singleton<MailHelper>.Instance.SendMail(sb.ToString());

        //清空异常信息
        Server.ClearError();

        Response.Write( Singleton<MailHelper>.Instance.Result);

    }
}