 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace HR.Util
{
    /*************************************************************************************
     * CLR 版本:       4.0.30319.269
     * 类 名 称:       GridViewHelper
     * 机器名称:       HSERVER
     * 命名空间:       HR.Util
     * 文 件 名:       GridViewHelper
     * 创建时间:       2012/10/24 10:28:55
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
    /// GridView 帮助类
    /// </summary>
    public class GridViewHelper
    {
        /// <summary>
        /// 将IList绑定到GridView
        /// </summary>
        /// <typeparam name="T">IList的类型</typeparam>
        /// <param name="gridView">GridView实例</param>
        /// <param name="list">IList实例</param>
        public static void BindGridView<T>(GridView gridView, IList<T> list)
        {
            gridView.DataSource = list;
            gridView.DataBind();

        }
    }
}
