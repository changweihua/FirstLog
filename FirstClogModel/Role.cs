using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstClogModel
{
    /*************************************************************************************
    * CLR版本：         4.0.30319.269
    * 类 名 称：       Role
    * 机器名称：       HSERVER
    * 命名空间：       FirstClogModel
    * 文 件 名：       Role
    * 创建时间：       2012/7/24 22:24:22
    * 作    者：       常伟华 Changweihua
    * 
    * 修改时间：
    * 修 改 人：
   *************************************************************************************/
    /// <summary>
    /// 用户角色类
    /// </summary>
    public class Role
    {
        /// <summary>
        /// 角色编号
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 可访问的路径
        /// </summary>
        public string RolePath { get; set; }
    }
}
