using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace HR.Util
{
    /*************************************************************************************
     * CLR 版本:       4.0.30319.269
     * 类 名 称:       BindDataHelper
     * 机器名称:       HSERVER
     * 命名空间:       HR.Util
     * 文 件 名:       BindDataHelper
     * 创建时间:       2012/10/12 20:00:24
     * 作    者:       常伟华 Changweihua
     * 签    名:       To be or not, it is not a problem !
     * 网    站:       http://www.cmono.net
     * 邮    箱:       changweihua@outlook.com
     * 
     * 修改时间:
     * 修 改 人:
     * 
     * 不    足:      可以使用拓展类，拓展方法
     ************************************************************************************/
    /// <summary>
    /// 自定义Data Bind 类
    /// </summary>
    public class DropDownListHelper
    {
        /// <summary>
        /// 绑定DropDownList控件
        /// </summary>
        /// <typeparam name="T">模型类</typeparam>
        /// <param name="ddl">需要绑定数据的控件</param>
        /// <param name="list">数据列表</param>
        /// <param name="valueField">值</param>
        /// <param name="textField">文本</param>
        public static void BindDropDownList<T>(DropDownList ddl, IList<T> list, string valueField, string textField)
        {
            ddl.DataSource = list;
            ddl.DataValueField = valueField;
            ddl.DataTextField = textField;
            ddl.DataBind();
        }

        /// <summary>
        /// 绑定DropDownList控件
        /// </summary>
        /// <typeparam name="T">模型类</typeparam>
        /// <param name="ddl">需要绑定数据的控件</param>
        /// <param name="list">数据列表</param>
        /// <param name="valueField">值</param>
        /// <param name="textField">文本</param>
        /// <param name="isInsertBlank">是否插入空白项</param>
        public static void BindDropDownList<T>(DropDownList ddl, IList<T> list, string valueField, string textField, bool isInsertBlank)
        {
            ddl.DataSource = list;
            ddl.DataValueField = valueField;
            ddl.DataTextField = textField;
            
            if (isInsertBlank)
            {
                ddl.Items.Add(new ListItem("请选择", "-1"));
            }
            ddl.DataBind();
        }


        /// <summary>
        /// 返回整型的值
        /// </summary>
        /// <param name="ddl">需要获取的下拉列表控件</param>
        /// <returns></returns>
        public static int GetSelectedValueByInteger(DropDownList ddl)
        {
            return Convert.ToInt32(ddl.SelectedValue);
        }

    }
}
