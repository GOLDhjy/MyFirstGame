using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using UnityEngine.UI;
using MyData;

/// <summary>
/// 网络脚本
/// </summary>
public class network : MonoBehaviour {

    public static Socket clientsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    private static byte[] buff=new byte [1024];
    private static byte[] buf=new byte[1024];
    static IPAddress ip = IPAddress.Parse("120.78.135.242");
    //static IPAddress ip = IPAddress.Parse("127.0.0.1");

    public static bool Connect()//连接
    {
        try
        {
            clientsocket.Connect(new IPEndPoint(ip, 2000));
            Debug.Log("连接成功");
        }
        catch (Exception e)
        {
            Debug.Log("连接失败");
            Debug.Log(e.Message);
            return false;
        }
        return true;
    }
    public static void sendmessage(string str)//验证口令
    {
        buff =Encoding.UTF8.GetBytes(str);
        try
        {
            clientsocket.Send(buff, str.Length, 0);
            Debug.Log("发送成功");
        }
        catch (Exception e)
        {
            Debug.Log("发送失败");
            Debug.Log(e.Message);
        }
    }
    public static bool Receivemessage()
    {
        while(true)
        {
            try
            {
                clientsocket.Receive(buf);
                Debug.Log("接收成功");
                //Debug.Log("@@@"+(Encoding.UTF8.GetString(buf).Substring(0, 5)));
                if (Encoding.UTF8.GetString(buf).Substring(0, 5) == "false")
                    return false;
                else
                    return true;
            }
            catch (Exception e)
            {
                Debug.Log("接收失败");
                Debug.Log(e.Message);
                
            }
        }
    }
    public static bool register_send(string str)//注册
    {
        str = str + "1";
        buff=Encoding.UTF8.GetBytes(str);
        try
        {
            clientsocket.Send(buff, str.Length, 0);
            Debug.Log("发送成功");
            return true;
        }
        catch (Exception e)
        {
            Debug.Log("发送失败");
            Debug.Log(e.Message);
            return false;
        }
    }
    public static void Closesocket()
    {
        Debug.Log("套接字已关闭");
        clientsocket.Shutdown(SocketShutdown.Both);
        clientsocket.Close();
    }
    public static void send_close(string str)
    {
        buff = Encoding.UTF8.GetBytes(str);
        try
        {
            clientsocket.Send(buff, str.Length, 0);
            Debug.Log("发送成功");
        }
        catch (Exception e)
        {
            Debug.Log("发送失败");
            Debug.Log(e.Message);
        }
    }
    public static StringBuilder Receive_rank()//接收排行榜
    {
        while (true)
        {
            try
            {
                int rn=clientsocket.Receive(buf);
                StringBuilder sb = new StringBuilder();
                string str = Encoding.UTF8.GetString(buf, 0, rn);
                sb.Append(str);
                string str_from_sb = sb.ToString();
                return sb;
            }
            catch (Exception e)
            {
                Debug.Log("接收失败");
                Debug.Log(e.Message);
                return null;
            }
        }

    }
    public static bool send_rank(mydata p)//发送分数信息
    {
        string jsonsend = JsonUtility.ToJson(p);
        buff = Encoding.UTF8.GetBytes(jsonsend+'5');
        try
        {
            clientsocket.Send(buff);
            return true;
        }
        catch(Exception e)
        {
            Debug.Log("接收失败");
            Debug.Log(e.Message);
            return false;
        }
    }

}

