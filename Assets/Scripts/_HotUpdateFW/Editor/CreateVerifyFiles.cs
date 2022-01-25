//创建项目的校验文件。

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using ABFW;


namespace HotUpdateProcess
{
    public class CreateVerifyFiles 
    {
        static string abOutPath = PathTools.GetABOutPath();
        
        [MenuItem("HotUpdateProcess/Create Verify Files")]
        public static void CreateFileMethod()
        {
            List<string> fileList= new List<string>();                  //存储所有合法文件的全路径信息集合
            string verifyFileOutPath = abOutPath + HotUpdatePathTool.PROJECT_VERIFY_FILE;  //校验文件的输出路径

            //覆盖
            if (File.Exists(verifyFileOutPath))
            {
                File.Delete(verifyFileOutPath);
            }

            // 遍历当前文件夹（校验文件的输出路径），所有的文件，生成MD5编码。
            ListFile(new DirectoryInfo(abOutPath),ref fileList);

            //把文件的名称与对应的MD5编码，写入校验文件。
            WriteVerifyFile(verifyFileOutPath,fileList);
        }

        // 遍历热更文件的发布区，得到所有合法的文件
        private static void ListFile(FileSystemInfo fileSysInfo,ref List<string> fileList)
        {
            DirectoryInfo dirInfo=fileSysInfo as DirectoryInfo;
            FileSystemInfo[] fileSysInfos=dirInfo.GetFileSystemInfos();  
            foreach (FileSystemInfo item in fileSysInfos)
            {
                FileInfo fileInfo=item as FileInfo;
                if (fileInfo != null)   
                {
                    string strFileFullName = fileInfo.FullName.Replace(@"\","/");

                    string fileExt = Path.GetExtension(strFileFullName);
                    if (fileExt.EndsWith(".meta")|| (fileExt.EndsWith(".bak")))
                    {
                        continue;
                    } 
                    fileList.Add(strFileFullName);//合法类型文件
                }
                else {
                    ListFile(item,ref fileList);  
                }
            }
        }

        private static void WriteVerifyFile(string verifyFileOutPath, List<string> fileLists)  // 把文件的名称与对应的MD5编码，写入校验文件
        {
            using (FileStream fs=new FileStream(verifyFileOutPath,FileMode.CreateNew))
            {
                using (StreamWriter sw=new StreamWriter(fs))
                {
                    for (int i = 0; i < fileLists.Count; i++)
                    {
                        //获取文件的名称
                        string strFile = fileLists[i];
                        //生成此文件的对应MD5编码数值  
                        string strFileMD5 = MD5Helper.GetMD5Vlues(strFile);

                        //把文件中的全路径信息去除，保留相对路径。
                        string strTrueFileName = strFile.Replace(abOutPath + "/", string.Empty);

                        sw.WriteLine(strTrueFileName + "|" + strFileMD5);  //写入文件
                    }
                }
            }
            Debug.Log("CreateVerifyFiles.cs/WriteVerifyFile()/创建校验文件成功！");
            AssetDatabase.Refresh();
        }
    }
}


