using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HR.Util
{
    /*************************************************************************************
     * CLR 版本:       4.0.30319.269
     * 类 名 称:       TypeConvertHelper
     * 机器名称:       HSERVER
     * 命名空间:       HR.Util
     * 文 件 名:       TypeConvertHelper
     * 创建时间:       2012/10/17 21:53:00
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
    /// 添加类描述
    /// </summary>
    public class TypeConvertHelper
    {
        public static object DictionaryToList<T>(Dictionary<object,object> dict)
        {
            List<T> list = null;

            

            return list;
        }

        public static T ToT<T>(object val)
        {
            Type type = typeof(T);
            object obj = null;

            if (DBNull.Value == val)
            {
                return default(T);
            }

            switch (type.Name)
            {
                case "Int32":
                    obj = Convert.ToInt32(val);
                    break;
                case "DateTime":
                    obj = Convert.ToDateTime(val);
                    break;
                default:
                    break;
            }

            return (T)obj;
        }

    }
}
