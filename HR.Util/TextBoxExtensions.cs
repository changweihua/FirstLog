using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace HR.Util
{
    /*************************************************************************************
     * CLR 版本:       4.0.30319.269
     * 类 名 称:       TextBoxExtensions
     * 机器名称:       HSERVER
     * 命名空间:       HR.Util
     * 文 件 名:       TextBoxExtensions
     * 创建时间:       2012/10/21 10:37:26
     * 作    者:       常伟华 Changweihua
     * 签    名:       To be or not, it is not a problem !
     * 网    站:       http://www.cmono.net
     * 邮    箱:       changweihua@outlook.com
     * 
     * 修改时间:
     * 修 改 人:
     * 
     * 不    足: 数据验证支持不足，应当使用正则，有时间补上
     * 
     ************************************************************************************/
    /// <summary>
    /// 添加类描述
    /// </summary>
    public static class TextBoxExtensions
    {
        /// <summary>
        /// 泛型
        /// 获取指定类型的值
        /// </summary>
        /// <typeparam name="T">指定的值类型</typeparam>
        /// <param name="textBox"></param>
        /// <returns></returns>
        public static T GetValueAsT<T>(this TextBox textBox)
        {
            Type type = typeof(T);
            object obj = null;

            if (string.IsNullOrEmpty(textBox.Text))
            {
                return default(T);
            }

            switch (type.Name)
            {
                case "Int32":
                    obj = Convert.ToInt32(textBox.Text);
                    break;
                case "DateTime":
                    obj = Convert.ToDateTime(textBox.Text);
                    break;
                case "Double":
                    obj = Convert.ToDouble(textBox.Text);
                    break;
                default:
                    break;
            }

            return (T)obj;
        }
    }
}
