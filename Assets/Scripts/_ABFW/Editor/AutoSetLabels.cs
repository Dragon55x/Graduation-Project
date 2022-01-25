/***
 *   Title: "AssetBundle简单框架"项目
 *           自动给资源文件添加标记
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;//编辑器命名空间
using System.IO;  //文件与目录操作命名空间

namespace ABFW
{
	public class AutoSetLabels
	{
        [MenuItem("AssetBundelTools/Set AB Label")]
        public static void SetABLabel()
        {
            AssetDatabase.RemoveUnusedAssetBundleNames();       //删除资源数据库中所有未使用的 assetBundle 名称
            
            string strNeedSetLabelRoot = PathTools.GetABResourcesPath();//文件夹根目录。
            DirectoryInfo dirTempInfo = new DirectoryInfo(strNeedSetLabelRoot);//根文件夹
            DirectoryInfo[] dirScenesDIRArray = dirTempInfo.GetDirectories(); //根目录的所有文件夹

            //遍历根目录下每个文件夹
            foreach (DirectoryInfo currentDIR in dirScenesDIRArray)
            {
                JudgeDIRorFileByRecursive(currentDIR, currentDIR.Name);    //递归调用方法，找到文件，使用AssetImporter类，标记“包名”与“后缀名”
            }
         
            AssetDatabase.Refresh();
            Debug.Log("AssetBundle 本次操作设置标记完成！");
        }

        private static void JudgeDIRorFileByRecursive(FileSystemInfo fileSysInfo , string rootFileName)
        {
            DirectoryInfo dirInfoObj= fileSysInfo as DirectoryInfo;                         //文件“夹”信息转换为目录信息
            FileSystemInfo[] fileSysArray = dirInfoObj.GetFileSystemInfos();                //得到该目录下文件“夹”信息
            foreach (FileSystemInfo fileInfo in fileSysArray)
            {
                FileInfo fileinfoObj=fileInfo as FileInfo;   
                if (fileinfoObj!=null)//是文件
                {
                    SetFileABLabel(fileinfoObj,rootFileName); //打标签
                }
                else//是目录
                {
                    JudgeDIRorFileByRecursive(fileInfo, rootFileName);  //递归
                }
            }
        }

        private static void SetFileABLabel(FileInfo fileinfoObj, string rootFileName)
        { 
            if (fileinfoObj.Extension == ".meta") return;   //*.meta 文件不做处理
            string strABName = GetABName(fileinfoObj,rootFileName);//计算合法AB包名称

            //获取资源文件的相对路径Assets为开头
            int tmpIndex = fileinfoObj.FullName.IndexOf("Assets");
            string strAssetFilePath = fileinfoObj.FullName.Substring(tmpIndex);                  
           
            AssetImporter tmpImporterObj = AssetImporter.GetAtPath(strAssetFilePath);   // 使用 AssetImporter 进行设置

            //给资源文件设置AB名称以及扩展名                                                                          
            tmpImporterObj.assetBundleName = strABName;//赋予AB包的名称
           
            if (fileinfoObj.Extension == ".unity")   //定义AB包的扩展名    （待修改）
            {
                tmpImporterObj.assetBundleVariant = "u3d";
            }
            else
            {
                tmpImporterObj.assetBundleVariant = "ab";
            }
        }
        private static string  GetABName(FileInfo fileinfoObj, string rootFileName)         //AB包名=“二级目录名称”+“三级目录名称”
        {
            string strABName = string.Empty;
            string tmpWinPath = fileinfoObj.FullName;               //Win路径是"\"         

            int tmpSceneNamePostion = tmpWinPath.IndexOf(rootFileName)+ rootFileName.Length;  //定位“二级目录名称”后面字符位置  
            string strABFileNameArea = tmpWinPath.Substring(tmpSceneNamePostion+1);   //截取后面字符串

            if (strABFileNameArea.Contains("\\"))
            {
                string[] tempStrArray = strABFileNameArea.Split('\\');
                strABName = rootFileName + "/" + tempStrArray[0];   //AB包名称正式形成
            }
            else {
                strABName = rootFileName + "/" + rootFileName;      //没有三级
            }
            return strABName;
        }
    }
}


