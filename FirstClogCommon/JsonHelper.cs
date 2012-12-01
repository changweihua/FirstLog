using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;

namespace FirstClogCommon
{
    /*************************************************************************************
     * CLR 版本:       4.0.30319.269
     * 类 名 称:       JsonHelper
     * 机器名称:       HSERVER
     * 命名空间:       FirstClogCommon
     * 文 件 名:       JsonHelper
     * 创建时间:       2012/8/23 15:12:34
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
    /// Json帮助类
    /// 不足之处：数据类型支持不完全，有时间添加完整的数据支持
    ///         对于属性字段为引用类型以及枚举和结构，支持不足
    /// </summary>
    public class JsonHelper
    {
        /// <summary>
        /// Object集合转换Json数据
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="list">数据</param>
        /// <param name="name">记录名称</param>
        /// <returns>Json文本</returns>
        public string ObjectsToJson<T>(List<T> list, string name)
        {
            if (list == null || list.Count == 0 )
            {
                return "{}";
            }

            string rowsName = string.IsNullOrEmpty(name) ? "rows" : name;

            StringBuilder sb = new StringBuilder("{" + rowsName + ":[");


            foreach (T t in list)
            {
                sb.Append(ObjectToJson<T>(t));
                sb.Append(",");
            }
            sb = sb.Remove(sb.Length - 1, 1);
            sb.Append("]}");

            return sb.ToString();
        }


        /// <summary>
        /// Object集合转换成Json数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="name"></param>
        /// <param name="totalCountName">记录条数名称，为空或者长度为0，表示不添加</param>
        /// <returns></returns>
        public string ObjectsToJson<T>(List<T> list, string name,string totalCountName)
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(totalCountName))
            {
                sb.Append("[" + totalCountName + ":" + list.Count.ToString() + ",");
                sb.Append(ObjectsToJson<T>(list, name) + "]");
            }
            else
            {
                sb.Append(ObjectsToJson<T>(list, name));
            }

            return sb.ToString();
        }


        /// <summary>
        /// 单个对象转为Json对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public string ObjectToJson<T>(T t)
        {
            if (t == null)
            {
                return "{}";
            }

            StringBuilder sb = new StringBuilder();

            sb.Append("{");
            foreach (PropertyInfo property in t.GetType().GetProperties())
            {
                if (IsValueType(property.PropertyType))
                {
                    sb.Append(string.Format("{0}:{1},", property.Name, property.GetValue(t, null)));
                }
                else
                {
                    sb.Append(string.Format("{0}:'{1}',", property.Name, property.GetValue(t, null)));
                }
            }
            sb = sb.Remove(sb.Length - 1, 1);
            sb.Append("}");

            return sb.ToString();
        }


        /// <summary>
        /// Json对象转成Object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public T JsonToObject<T>(string json) where T : new()
        {
            T t = default(T);
            string temp = json.TrimStart('{').TrimEnd('}').Trim();
            if (temp.Length <= 0)
            {
                return t;
            }

            string[] arr = temp.Split(',');

            if (arr.Length <= 0)
            {
                return t;
            }

            Type type = typeof(T);
            List<string> properties = new List<string>();
            //获取 T 所有属性名
            foreach (PropertyInfo property in type.GetProperties())
            {
                properties.Add(property.Name);
            }

            //将Json数据转成属性值和属性名
            Dictionary<string, object> dict = new Dictionary<string, object>();

            for (int i = 0; i < arr.Length; i++)
            {
                Match match = Regex.Match(arr[i], @"(\w+):([\w|\W]+)");
                dict.Add(match.Groups[1].Value, match.Groups[2].Value.TrimStart('\'').TrimEnd('\''));
            }

            t = new T();

            foreach (PropertyInfo proper in type.GetProperties())
            {
                proper.SetValue(t, GetNonGenericValueFromObject(dict[proper.Name], proper.PropertyType), null);
            }

            return t;
        }


        public List<T> JsonToObjects<T>(string json) where T : new()
        {
            List<T> list = null;
            Match match = Regex.Match(json, @"(\[([\w|\W]*)\])");

            string json2 = match.Groups[2].Value;

            string temp = json2.TrimStart('{').TrimEnd('}').Trim();

            if (temp.Length <= 0)
            {
                return list;
            }

            string[] arr1 = Regex.Split(temp, @"\}\,\{");

            if (arr1.Length <= 0)
            {
                return list;
            }

            list = new List<T>();

            for (int i = 0; i < arr1.Length; i++)
            {

                T t = JsonToObject<T>("{" + arr1[i] + "}");
                list.Add(t);

            }

            return list;

        }


        /// <summary>
        /// 将Object转换成字符串类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private object GetString(object value)
        {
            return Convert.ToString(value);
        }


        private object GetEnum(object value,Type targetType)
        {
            return Enum.Parse(targetType, value.ToString());
        }

        private object GetBoolean(object value)
        {
            if(value is Boolean)
            {
                return value;
            }
            else
            {
                byte b = (byte)GetByte(value);
                if (b == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }


        private object GetByte(object value)
        {
            if (value is byte)
            {
                return value;
            }
            else
            {
                return byte.Parse(value.ToString());
            }
        }

        private object GetSByte(object value)
        {
            if (value is SByte)
            {
                return value;
            }
            else
            {
                return sbyte.Parse(value.ToString());
            }
        }

        private object GetChar(object value)
        {
            if (value is char)
            {
                return value;
            }
            else
            {
                return char.Parse(value.ToString());
            }
        }


        private object GetGuid(object value)
        {
            if (value is Guid)
            {
                return value;
            }
            else
            {
                return new Guid(value.ToString());
            }
        }

        private object GetInt16(object value)
        {
            if (value is Int16)
            {
                return value;
            }
            else
            {
                return Int16.Parse(value.ToString());
            }
        }

        private object GetUInt16(object value)
        {
            if (value is UInt16)
            {
                return value;
            }
            else
            {
                return UInt16.Parse(value.ToString());
            }
        }

        private object GetInt32(object value)
        {
            if (value is Int32)
            {
                return value;
            }
            else
            {
                return Int32.Parse(value.ToString());
            }
        }

        private object GetUInt32(object value)
        {
            if (value is UInt32)
            {
                return value;
            }
            else
            {
                return UInt32.Parse(value.ToString());
            }
        }


        private object GetInt64(object value)
        {
            if (value is Int64)
            {
                return value;
            }
            else
            {
                return Int64.Parse(value.ToString());
            }
        }

        private object GetUInt64(object value)
        {
            if (value is UInt64)
            {
                return value;
            }
            else
            {
                return UInt64.Parse(value.ToString());
            }
        }


        private object GetSingle(object value)
        {
            if (value is Single)
            {
                return value;
            }
            else
            {
                return Single.Parse(value.ToString());
            }
        }

        private object GetDouble(object value)
        {
            if (value is double)
            {
                return value;
            }
            else
            {
                return Double.Parse(value.ToString());
            }
        }

        private object GetDecimal(object value)
        {
            if (value is Decimal)
            {
                return value;
            }
            else
            {
                return Decimal.Parse(value.ToString());
            }
        }

        private object GetDateTime(object value)
        {
            if (value is DateTime)
            {
                return value;
            }
            else
            {
                return DateTime.Parse(value.ToString());
            }
        }

        private object GetTimeSpan(object value)
        {
            if (value is TimeSpan)
            {
                return value;
            }
            else
            {
                return TimeSpan.Parse(value.ToString());
            }
        }

        private object GetGenericValueFromObject(object value,Type targetType)
        {
            if (value == DBNull.Value)
            {
                return null;
            }
            else
            {
                return null;
            }
        }

        private object GetNonGenericValueFromObject(object value,Type targetType)
        {
            if (targetType.IsEnum)
            {
                return GetEnum(value, targetType);
            }
            else
            {
                switch (targetType.Name)
                {
                    case "Byte":
                        return GetByte(value);
                    case "SByte":
                        return GetSByte(value);
                    case "Char":
                        return GetChar(value);
                    case "Boolean":
                        return GetBoolean(value);
                    case "Guid":
                        return GetGuid(value);
                    case "Int16":
                        return GetInt16(value);
                    case "UInt16":
                        return GetUInt16(value);
                    case "Int32":
                        return GetInt32(value);
                    case "UInt32":
                        return GetUInt32(value);
                    case "Int64":
                        return GetInt64(value);
                    case "UInt64":
                        return GetUInt64(value);
                    case "Single":
                        return GetSingle(value);
                    case "Double":
                        return GetDouble(value);
                    case "Decimal":
                        return GetDecimal(value);
                    case "DateTime":
                        return GetDateTime(value);
                    case "TimeSpan":
                        return GetTimeSpan(value);
                    case "String":
                        return GetString(value);
                    default:
                        return null;
                }
            }
        }


        /// <summary>
        /// 判断属性是否为值类型，结构除外，若是，返回true
        /// </summary>
        /// <param name="type">需要判断的类型</param>
        /// <returns></returns>
        private bool IsValueType(Type type)
        {
            bool isValueType = false;

            switch (type.Name)
            {
                case "Byte":
                    isValueType = true;
                    break;
                case "SByte":
                    isValueType = true;
                    break;
                case "Boolean":
                    isValueType = false;
                    break;
                case "Guid":
                    isValueType = true;
                    break;
                case "Int16":
                    isValueType = true;
                    break;
                case "UInt16":
                    isValueType = true;
                    break;
                case "Int32":
                    isValueType = true;
                    break;
                case "UInt32":
                   isValueType = true;
                    break;
                case "Int64":
                    isValueType = true;
                    break;
                case "UInt64":
                    isValueType = true;
                    break;
                case "Single":
                   isValueType = true;
                    break;
                case "Double":
                    isValueType = true;
                    break;
                case "Decimal":
                    isValueType = true;
                    break;
                case "DateTime":
                    isValueType = false;
                    break;
                case "TimeSpan":
                    isValueType = true;
                    break;
                case "String":
                    isValueType = false;
                    break;
                default:
                    isValueType = false;
                    break;
            }

            return isValueType;
        }

    }
}
