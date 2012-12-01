using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///检查用户是否登录
/// </summary>
public class UserAuthorizationModule : IHttpModule
{
	public UserAuthorizationModule()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    #region IHttpModule 成员

    public void Dispose()
    {
        
    }

    public void Init(HttpApplication context)
    {
        context.AcquireRequestState+=new EventHandler(context_AcquireRequestState);
    }

    #endregion

    void context_AcquireRequestState(object sender,EventArgs e)
    {
        //获取应用程序
        HttpApplication application = sender as HttpApplication;

        //检查用户是否已经登录
        if (application.Context.Session["UserName"] == null || application.Context.Session["UserName"].ToString().Trim() == "")
        {
            //获取URL
            string requestUrl = application.Request.Url.ToString();
            string requestPage = requestUrl.Substring(requestUrl.LastIndexOf('/') + 1);

            //如果请求的不是登录页面，则重定向至登录页
            if (requestPage != "Login.aspx")
            {
                application.Server.Transfer("Login.aspx");
            }
           
        }
        else
        {
            //已经登录
            application.Response.Write("欢迎");
        }

    }

    
}