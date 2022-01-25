//根据标签打AB包
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;   
using System.IO;     

namespace ABFW
{
    public class BuildAssetBundle {
        public static void BuildAllAB(BuildTarget buildTarget)
        {
            //打包AB输出路径
            string strABOutPathDIR = PathTools.GetABOutPath();

            //判断生成输出目录文件夹
            if (!Directory.Exists(strABOutPathDIR))
            {
                Directory.CreateDirectory(strABOutPathDIR);
            }
            BuildPipeline.BuildAssetBundles(strABOutPathDIR, BuildAssetBundleOptions.None, buildTarget);
        }

        [MenuItem("AssetBundelTools/BuildAllAssetBundles/PC")]
        public static void BuildAB_PC()
        {
            BuildAllAB(BuildTarget.StandaloneWindows);
        }

        [MenuItem("AssetBundelTools/BuildAllAssetBundles/Android")]
        public static void BuildAB_Android()
        {
            BuildAllAB(BuildTarget.Android);
        }

        [MenuItem("AssetBundelTools/BuildAllAssetBundles/IOS")]
        public static void BuildAB_ios()
        {
            BuildAllAB(BuildTarget.iOS);
        }
        [MenuItem("AssetBundelTools/BuildAllAssetBundles/MAC")]
        public static void BuildAB_MAC()
        {
            BuildAllAB(BuildTarget.StandaloneOSX);
        }
        
    }
}
