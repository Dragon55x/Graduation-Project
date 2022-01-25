/***
 *               AssetBundle 关系类
 *              1: 存储指定AB包的所有依赖关系包
 *              2: 存储指定AB包所有的引用关系包
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ABFW
{
	public class ABRelation
	{
        //当前AsseetBundel 名称
        private string _ABName;
        //本包所有的依赖包集合
        private List<string> _LisAllDependenceAB;
       

        public ABRelation(string abName)   // 构造函数
        {
            _ABName = abName;
            _LisAllDependenceAB = new List<string>();
            
        }
   
        public void AddDependence(string abName)  // 增加依赖关系
        {
            if (!_LisAllDependenceAB.Contains(abName))
            {
                _LisAllDependenceAB.Add(abName);
            }
        }
        
       
    }
}


