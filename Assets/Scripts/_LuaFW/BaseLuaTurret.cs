
using System.Collections.Generic;
using UnityEngine;



public class BaseLuaTurret : MonoBehaviour
{
    public List<GameObject> EnemyListC;

    private void Awake()
    {
        EnemyListC = new List<GameObject>();
    }
    private void Start()
    {
        //EnemyListC.Add(gameObject);
        //EnemyListC[1] = null;
    }

    public List<GameObject> GetEnemyList(ref List<GameObject> enemylist)
    {
        enemylist=EnemyListC;
        return enemylist;
    }

    //碰撞检测触发器
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("进入视野");
        if (other.tag == "Enemy")
        {
            EnemyListC.Add(other.gameObject);
        }

    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("推出视野");
        if (other.tag == "Enemy")
        {
            EnemyListC.Remove(other.gameObject);
        }
    }



}//Class_end
