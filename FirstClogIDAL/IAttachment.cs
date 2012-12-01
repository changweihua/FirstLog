using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirstClogModel;

namespace FirstClogIDAL
{
    public interface IAttachment
    {
        /// <summary>
        /// 插入附件
        /// </summary>
        /// <param name="attachment">附件</param>
        /// <returns></returns>
        int Insert(Attachment attachment);

        /// <summary>
        /// 查询所有附件
        /// </summary>
        /// <returns></returns>
        List<Attachment> Select();

        /// <summary>
        /// 获取指定文章的附件
        /// </summary>
        /// <param name="articleId">日志编号</param>
        /// <returns></returns>
        List<Attachment> Select(int articleId);

        /// <summary>
        /// 删除附件
        /// </summary>
        /// <param name="attachmentId">附件编号</param>
        /// <returns></returns>
        int Delete(int attachmentId);


        /// <summary>
        /// 更新附件
        /// </summary>
        /// <param name="attachment">附件信息</param>
        /// <returns></returns>
        int Update(Attachment attachment);

    }
}
