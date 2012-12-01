using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLServer;
using FirstClogModel;

namespace FirstClogBBL
{
    /*************************************************************************************
    * CLR版本：         4.0.30319.269
    * 类 名 称：       CategoryManager
    * 机器名称：       HSERVER
    * 命名空间：       FirstClogBBL
    * 文 件 名：       CategoryManager
    * 创建时间：       2012/8/4 10:13:41
    * 作    者：       常伟华 Changweihua
    * 
    * 修改时间：
    * 修 改 人：
   *************************************************************************************/
    /// <summary>
    /// 添加类描述
    /// </summary>
    public class CategoryManager
    {

        private static readonly CategoryDAL categoryDAL = new CategoryDAL();

        public IList<Category> GetAllCategories()
        {
            return categoryDAL.Select("");
        }
    }
}
