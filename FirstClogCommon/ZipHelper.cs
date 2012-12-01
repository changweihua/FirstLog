using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FirstClogCommon
{
    /*************************************************************************************
    * CLR版本：         4.0.30319.269
    * 类 名 称：       ZipHelper
    * 机器名称：       HSERVER
    * 命名空间：       FirstClogCommon
    * 文 件 名：       ZipHelper
    * 创建时间：       2012/7/25 10:50:25
    * 作    者：       常伟华 Changweihua
    * 
    * 修改时间：
    * 修 改 人：
   *************************************************************************************/
    /// <summary>
    /// 压缩和解压类
    /// </summary>
    public class ZipHelper
    {
        public static void Compress(FileInfo fi, DirectoryInfo di)
        {
            if (fi.Exists)
            {
                fi.Delete();
            }

         

        }
    }
}
