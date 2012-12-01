using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstClogModel
{
    /*************************************************************************************
    * CLR版本：         4.0.30319.269
    * 类 名 称：       User
    * 机器名称：       HSERVER
    * 命名空间：       FirstClogModel
    * 文 件 名：       User
    * 创建时间：       2012/7/24 22:14:50
    * 作    者：       常伟华 Changweihua
    * 
    * 修改时间：
    * 修 改 人：
   *************************************************************************************/
    /// <summary>
    /// 用户类
    /// </summary>
    public class User
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string UserPwd { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string UserNickName { get; set; }
        /// <summary>
        /// 用户角色编号
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 用户头像
        /// </summary>
        public byte[] UserImage { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string UserMail { get; set; }
        /// <summary>
        /// 用户描述
        /// </summary>
        public string UserDescription { get; set; }
    }
}
