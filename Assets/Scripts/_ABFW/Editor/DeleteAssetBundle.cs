//删除AB包
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using System.IO;


namespace ABFW
{
	public class DeleteAssetBundle
	{
        [MenuItem("AssetBundelTools/DeleteAllAssetBundles")]
        public static void DelAssetBundle()
        {
            //删除AB包输出目录
            string strNeedDeleteDIR = PathTools.GetABOutPath();
                     
            Directory.Delete(strNeedDeleteDIR,true);         //"true"表示可以删除非空目录
            File.Delete(strNeedDeleteDIR + ".meta");
            
            AssetDatabase.Refresh();
            
        }
	}
}


