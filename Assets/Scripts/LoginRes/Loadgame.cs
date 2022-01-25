using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Google.Protobuf;
using XProgect;

public class Loadgame : MonoBehaviour
{
   public static bool LoadGame(string name,  out int cin, out List<string> tower)
    {
        if(File.Exists(Application.dataPath+"/"+name))
        {
            byte[] read = File.ReadAllBytes(Application.dataPath + "/" + name);
            Gamedata message = new Gamedata();
            message.MergeFrom(read);
            cin = message.Coin;
            List<string> temp = new List<string>();
            for (int i = 0; i < message.Tower.Count; i++)
            {
                temp.Add(message.Tower[i]);
            }
            tower = temp;
            return true;
        }
        else
        {
            cin = 0;tower = null;
            return false;
        }
        
    }
}
