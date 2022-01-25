/***
 *
 *  Title: "热更新流程设计"课程项目
 *          静态帮助类
 *
 *  Description:
 *        功能：
 *           提供热更新需要的公共通用方法。
 *     
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Security.Cryptography;   //MD5 编码的命名空间
using System.Text;

namespace HotUpdateProcess
{
    public static class MD5Helper
    {
        // 根据路径 生成MD5编码
        public static string GetMD5Vlues(string filePath)
        {
            StringBuilder sb = new StringBuilder();
            filePath = filePath.Trim();

            using (FileStream fs=new FileStream(filePath,FileMode.Open))
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                //输入指定文件，转二进制
                byte[] result=md5.ComputeHash(fs);

                for (int i = 0; i < result.Length; i++)
                {
                    //“x2”表示输出按照16进制，且为2位对齐输出。
                    sb.Append(result[i].ToString("x2")); 
                }
            }
            return sb.ToString();
        }
    }
}


