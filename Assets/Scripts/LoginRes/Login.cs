using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Google.Protobuf;
using XProgect;
using Communication;

namespace LoginRes
{
    public class Login : MonoBehaviour
    {
        public static bool LogIn(string id, string password)
        {
            print(id + "   " + password);
            if (File.Exists(Application.streamingAssetsPath + "/ID/" + id))
            {
                byte[] read = File.ReadAllBytes(Application.streamingAssetsPath + "/ID/" + id);
                Gamedata message = new Gamedata();
                message.MergeFrom(read);
                if (password == message.Password)
                {
                    Client1.SendLoginInfo(message.Name,Client1.GetIPV4());
                    Client1.awake();
                    Communication.CommuManager.cur_name = message.Name;
                    print("登录成功");
                    return true;
                }
                print("密码错误");
                return false;
            }
            else
            {
                print("用户名不存在");
                return false;
            }
        }
    }
}

