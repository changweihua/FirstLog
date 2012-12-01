using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace FirstClogCommon
{
    /*************************************************************************************
    * CLR版本：         4.0.30319.269
    * 类 名 称：       EncryptHelper
    * 机器名称：       HSERVER
    * 命名空间：       FirstClogCommon
    * 文 件 名：       EncryptHelper
    * 创建时间：       2012/7/24 23:25:56
    * 作    者：       常伟华 Changweihua
    * 
    * 修改时间：
    * 修 改 人：
   *************************************************************************************/
    /// <summary>
    /// 添加加密解密帮助类类描述
    /// 实现MD5、DES等加密
    /// </summary>
    public class EncryptHelper
    {
        #region DES加密解密字符串

        /// <summary>
        /// 默认密钥向量
        /// </summary>
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥，要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回null</returns>
        public static string EncryptDES(string encryptString, string encryptKey = "11001100")
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();

                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥，要求为8位，和加密密钥相同</param>
        /// <returns>解密成功后返回解密后的字符串，失败返回null</returns>
        public static string DecryptDES(string decryptString, string decryptKey = "11001100")
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();

                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return null;
            }

        }

        #endregion


        #region MD5加密

        /// <summary>
        /// MD5 16位加密 加密后代码为大写
        /// </summary>
        /// <param name="cryptString">待加密的字符串</param>
        /// <returns>密文</returns>
        public static string GetMD5StringUpperCase(string cryptString)
        {
            string result = string.Empty;

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider()) 
            {
                result = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(cryptString)), 4, 8);
                result = result.Replace("-", "");
            }

            return result;
        }

        /// <summary>
        /// MD5 16位加密 加密后代码为小写
        /// </summary>
        /// <param name="cryptString">待加密的字符串</param>
        /// <returns>密文</returns>
        public static string GetMD5StringLowerCase(string cryptString)
        {
            return GetMD5StringUpperCase(cryptString).ToLower();
        }

        /// <summary>
        /// MD5 32位加密
        /// </summary>
        /// <param name="cryptString">明文</param>
        /// <returns>密文</returns>
        public static string GetMD5String(string cryptString)
        {
            string result = string.Empty;

            //实例化一个MD5对象
            using (MD5 md5 = MD5.Create())
            {
                StringBuilder sb = new StringBuilder();
                //加密后是一个字节类型的数组
                byte[] cryptStringArray = md5.ComputeHash(Encoding.UTF8.GetBytes(cryptString));
                //通过循环，将字节类型的数组转换成字符串
                for (int i = 0; i < cryptStringArray.Length; i++)
                {
                    //将得到的字符串使用16进制类型格式
                    sb.Append(cryptStringArray[i].ToString("X"));
                }

                result = sb.ToString();

            }

            return result;
        }


        /// <summary>
        /// MD5
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMD5(string str)
        {
            byte[] b = Encoding.UTF8.GetBytes(str);
            b = new MD5CryptoServiceProvider().ComputeHash(b);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < b.Length; i++)
            {
                sb.Append(b[i].ToString("X").PadLeft(2, '0'));
            }

            return sb.ToString();
        }


        #endregion


        #region AES加解密

        private static byte[] AESKeys = { 0x41, 0x72, 0x65, 0x79, 0x6F, 0x75, 0x6D, 0x79, 0x53, 0x6E, 0x6F, 0x77, 0x6D, 0x61, 0x6E, 0x3F };

        public static string EncryptAES(string encryptString, string encryptKey = "11001100110011001100110011001100")
        {


            encryptKey = Utils.GetSubString(encryptKey, 32, "");
            encryptKey = encryptKey.PadRight(32, ' ');

            RijndaelManaged rijndaelProvider = new RijndaelManaged();

            rijndaelProvider.Key = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 32));
            rijndaelProvider.IV = AESKeys;

            ICryptoTransform rijndaelEncrypt = rijndaelProvider.CreateEncryptor();

            byte[] inputData = Encoding.UTF8.GetBytes(encryptString);
            byte[] encryptedData = rijndaelEncrypt.TransformFinalBlock(inputData, 0, inputData.Length);

            return Convert.ToBase64String(encryptedData);

        }

        public static string DecryptAES(string decryptString, string decryptKey = "11001100110011001100110011001100")
        {
            decryptKey = Utils.GetSubString(decryptKey, 32, "");
            decryptKey = decryptKey.PadRight(32, ' ');

            RijndaelManaged rijndaelProvider = new RijndaelManaged();

            rijndaelProvider.Key = Encoding.UTF8.GetBytes(decryptKey.Substring(0, 32));
            rijndaelProvider.IV = AESKeys;

            ICryptoTransform rijndaelDecrypt = rijndaelProvider.CreateDecryptor();

            byte[] inputData = Convert.FromBase64String(decryptString);
            byte[] decryptData = rijndaelDecrypt.TransformFinalBlock(inputData, 0, inputData.Length);

            return Encoding.UTF8.GetString(decryptData);

        }

        #endregion

    }
}
