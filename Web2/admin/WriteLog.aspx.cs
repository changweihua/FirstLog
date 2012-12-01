using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FirstClogCommon;
using FirstClogModel;
using FirstClogBBL;

public partial class admin_WriteLog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitData();
            txtPublishDate.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //日志标题
        string articleTitle = this.txtLogTitle.Text.Trim().ToString();
        //分类编号
        string categoryId = this.ddlCateogry.SelectedValue.ToString();
        //标签
        string[] tags = this.txtTag.Text.ToString().Split(',', '，', ' ');
        //发布时间
        DateTime articledate = Convert.ToDateTime(this.txtPublishDate.Text.ToString());
        //日志内容
        string articleContent = Request.Params["content"].ToString();
        //日志摘要
        string articleSummary = Request.Params["summary"].ToString();
        //链接别名
        string articlealias = this.txtAlias.Text.Trim().ToString();
        //引用通告
        //访问密码
        string articlePassword = this.txtPwd.Text.Trim().ToString();
        //是否置顶
        int articletop = this.cbIsTop.Checked ? 1 : 0;
        //是否允许评论
        int articleallowcomment = this.cbAllowComment.Checked ? 1 : 0;
        //是否允许引用
        int articleallowquote = this.cbAllowQuote.Checked ? 1 : 0;

        ScriptHelper.Alert("提交", this);

    }

    private void InitData()
    {
        CategoryManager cm = new CategoryManager();

        BindDataHelper.BindDropDownList<Category>(this.ddlCateogry, cm.GetAllCategories(), "categoryid", "categoryname");
    }

}