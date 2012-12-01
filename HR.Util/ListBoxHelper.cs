using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace HR.Util
{
    /*************************************************************************************
     * CLR 版本:       4.0.30319.269
     * 类 名 称:       ListBoxHelper
     * 机器名称:       HSERVER
     * 命名空间:       HR.Util
     * 文 件 名:       ListBoxHelper
     * 创建时间:       2012/10/26 12:12:24
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
    /// ListBox 帮助类
    /// </summary>
    public class ListBoxHelper
    {
        /// <summary>
        /// 绑定List到ListBox
        /// </summary>
        /// <typeparam name="T">数据集合类型</typeparam>
        /// <param name="listBox">待绑定的控件</param>
        /// <param name="list">数据</param>
        /// <param name="textField">文本域</param>
        /// <param name="valueField">值域</param>
        public static void BindListBox<T>(ListBox listBox, IList<T> list, string textField, string valueField)
        {
            listBox.DataSource = list;
            listBox.DataTextField = textField;
            listBox.DataValueField = valueField;
            listBox.DataBind();
        }
    }
}
