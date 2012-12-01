using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FirstClogCommon;

public partial class _Default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string str = "常伟华";
        string str2 = EncryptHelper.EncryptDES(str, "11001100");
        Response.Write(str2);
        Response.Write("<br />");
        Response.Write(EncryptHelper.DecryptDES(str2, "11001100"));
        Response.Write("<br />");
        Response.Write("MD5 16位 加密:" + EncryptHelper.GetMD5StringUpperCase(str) + "<br />");
        Response.Write("<br />");
        Response.Write("MD5 32位 加密:" + EncryptHelper.GetMD5String("有一种想念叫避而不见") + "<br />");
        Response.Write("<br />");
        string str3 = EncryptHelper.EncryptAES("有一种想念叫避而不见", "11001100110011001100110011001100");
        Response.Write("AES 加密:" + str3 + "<br />");
        Response.Write("<br />");
        Response.Write("AES 解密:" + EncryptHelper.DecryptAES(str3, "11001100110011001100110011001100") + "<br />");
        Response.Write("<br />");
        Response.Write("MD5 :" + EncryptHelper.GetMD5(str) + "<br />");
        Response.Write("<br />");
      //  Response.Write("Word To Html" + DocHelper.PrintHtml() + "<br />");
       // XmlHelper.Read(Server.MapPath("~") + @"\log4net.xml", "section", "");
    }
}