using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Net;
using Google.Protobuf;
using Network;
using System.Threading;

namespace Communication
{
    public class Client1 : MonoBehaviour
    {
        //连接
        static Socket send = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //static Socket receive = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static Socket connect = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
       // static CommuManager commuManager = new Communication.CommuManager();
        public static void awake()
        {
            Thread thread1 = new Thread(ReceiveMessage);
            thread1.Start();
        }
        //接收消息
        public static void ReceiveMessage()
        {
            //1111接收端口
            IPEndPoint endPoint = new IPEndPoint(GetIPV4(), 1111);
            Socket receive = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            receive.Bind(endPoint);
            receive.Listen(2);
            print("开始监听" + receive.Blocking);
            while (true)
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                if (!socket.Connected)
                {
                    socket = receive.Accept();
                }
                Message message1 = new Message();
                while (socket.Available == 0) { }
                byte[] data = new byte[socket.Available];
                socket.Receive(data, 0, data.Length, SocketFlags.Partial);

                using (CodedInputStream inputStream = new CodedInputStream(data))
                {
                    message1.MergeFrom(inputStream);
                }
                print("难道从这里卡住了？" + message1.MyMessage);
                CommuManager.Show(message1.MyName, message1.MyMessage);
            }
        }
        public static void SendMessage(string name, string message)
        {
            Message tmpmessage = new Message();
            tmpmessage.MyMessage = message;
            tmpmessage.MyName = name;
            if (!send.Connected)
            {
                send.Connect("192.168.192.143", 33678);//服务器监听端口
            }

            send.Send(tmpmessage.ToByteArray());
            //byte[] data = new byte[tmpmessage.CalculateSize()];
            //////第一次握手，接收到数据确认链接成功
            //using (CodedInputStream inputStream = new CodedInputStream(data))
            //{
            //    tmpmessage.MergeFrom(inputStream);
            //}
            //connect.Receive(data, 0, data.Length, SocketFlags.Partial);
        }
        public static IPAddress GetIPV4()
        {
            //获取主机名
            string name = Dns.GetHostName();
            //ip地址集合
            IPAddress[] ipadrlist = Dns.GetHostAddresses(name);
            //寻找IPV4
            foreach (IPAddress ipa in ipadrlist)
            {
                if (ipa.AddressFamily == AddressFamily.InterNetwork)
                    return ipa;
            }
            return null;
        }

        public static void SendLoginInfo(string name, IPAddress ip)
        {
            Message tmpmessage = new Message();
            tmpmessage.MyIp = ip.ToString();
            tmpmessage.MyName = name;
            print(connect.Connected);
            if (!connect.Connected)
            {
                connect.Connect("192.168.192.143", 33666);//服务器监听端口
            }
            connect.Send(tmpmessage.ToByteArray());
        }

    }
}
