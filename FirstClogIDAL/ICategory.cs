using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirstClogModel;
using System.Data;

namespace FirstClogIDAL
{
    /// <summary>
    /// 分类接口
    /// </summary>
    public interface ICategory
    {
        
        /// <summary>
        /// 插入分类
        /// </summary>
        /// <param name="category">新分类</param>
        /// <returns>受影响的行数</returns>
        int Insert(Category category);

        /// <summary>
        /// 更新分类
        /// </summary>
        /// <param name="category">分类</param>
        /// <returns>受影响行数</returns>
        int Update(Category category);

        /// <summary>
        /// 搜索分类
        /// </summary>
        /// <param name="categoryName">分类名称</param>
        /// <returns>分类结果集合</returns>
        IList<Category> Select(string categoryName);

        /// <summary>
        /// 根据编号查找分类
        /// </summary>
        /// <param name="categoryId">分类编号</param>
        /// <returns>分类</returns>
        Category Select(int categoryId);

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="categoryId">分类编号</param>
        /// <returns>受影响行数</returns>
        int Delete(int categoryId);

    }
}
