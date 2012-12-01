using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HR.Util
{
    /*************************************************************************************
     * CLR 版本:       4.0.30319.269
     * 类 名 称:       Singleton
     * 机器名称:       HSERVER
     * 命名空间:       HR.Util
     * 文 件 名:       Singleton
     * 创建时间:       2012/10/12 20:04:11
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
    /// 泛型类，实现单例模式
    /// </summary>
    /// <typeparam name="T">需要实现单例的类</typeparam>
    public class Singleton<T> where T : new()
    {
        /// <summary>
        /// 实例
        /// </summary>
        public static T Instance
        {
            get { return SingletonCreator.instance; }
        }

        class SingletonCreator
        {
            internal static readonly T instance = new T();
        }
    }
}
