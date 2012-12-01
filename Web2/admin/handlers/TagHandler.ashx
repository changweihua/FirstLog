<%@ WebHandler Language="C#" Class="TagHandler" %>

using System;
using System.Web;
using FirstClogCommon;
using FirstClogModel;
using System.Collections.Generic;
using FirstClogBBL;

public class TagHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        
        context.Response.ContentType = "text/plain";

        List<Tag> tags = TagManager.GetAllTag();

        JsonHelper jsonHelper = Singleton<JsonHelper>.Instance;

        //string temp = jsonHelper.ObjectToJson<Tag>(new Tag { ArticleId = 2, TagId = 1, TagName = "C#" });
        
        //context.Response.Write(temp);

        //context.Response.Write(jsonHelper.JsonToObject<Tag>(temp).TagName);


        string result = jsonHelper.ObjectsToJson<Tag>(tags, "");
        context.Response.Write(result);

        //tags = null;

        //tags = jsonHelper.JsonToObjects<Tag>(result);

        //context.Response.Write(tags[0].TagName);
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}