using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstClogCommon
{
    /*************************************************************************************
    * CLR版本：         4.0.30319.269
    * 类 名 称：       Singleton
    * 机器名称：       HSERVER
    * 命名空间：       FirstClogCommon
    * 文 件 名：       Singleton
    * 创建时间：       2012/7/27 10:09:11
    * 作    者：       常伟华 Changweihua
    * 
    * 修改时间：
    * 修 改 人：
   *************************************************************************************/
    /// <summary>
    /// 泛型实现单例模式
    /// </summary>
    /// <typeparam name="T">需要实现单例的类</typeparam>
    public class Singleton<T> where T : new()
    {
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
