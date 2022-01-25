using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XProgect;
using Google.Protobuf;
using System.IO;
using System;

namespace LoginRes
{
    public class Savegame : MonoBehaviour   //注册
    {
        public static bool SaveGame(string id, string name, string password, int cin, List<string> tower)
        {
            Gamedata gamedata = new Gamedata();
            gamedata.ID = id;
            gamedata.Name = name;
            gamedata.Password = password;
            gamedata.Coin = cin;
            if (tower != null)
            {
                foreach (var item in tower)
                {
                    gamedata.Tower.Add(item);
                }
            }
            try
            {
                byte[] tem = gamedata.ToByteArray();
                if (!Directory.Exists(Application.streamingAssetsPath + "/ID"))
                {
                    Directory.CreateDirectory(Application.streamingAssetsPath + "/ID");
                }
                FileStream stream = File.Create(Application.streamingAssetsPath + "/ID/" + id);
                stream.Write(tem, 0, tem.Length);
                print("注册成功");
            }
            catch (UnauthorizedAccessException e)
            {
                print(Application.streamingAssetsPath + "/ID/" + id);
                return false;
            }
            return true;
        }
    }

}
