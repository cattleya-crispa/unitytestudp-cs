using System.Net.Sockets;
using System.Threading;
using UnityEngine;
using System.Net;
using System.Text;

public class UDPC
{
    /// <summary>
    /// デリゲート 受信時イベント
    /// </summary>
    /// <param name="strCMsg"></param>
    public delegate void SendHandler(string strCMsg);
    /// <summary>
    /// 受信時イベント
    /// </summary>
    public SendHandler SendMes;
    /// <summary>
    /// 受信処理 スレッド
    /// </summary>
    private Thread thread;
    /// <summary>
    /// リッスンポート
    /// </summary>
    private int sendPort;
    /// <summary>
    /// UDPクライアント
    /// </summary>
    private UdpClient client;
    public string host = "127.0.0.1";
    //--------------------------------------------------------------------------
    /// <summary>
    /// UDPServer
    /// </summary>
    public UDPC(int port = 3003)
    {
        sendPort = port;
        client = null;
    }
    /// <summary>
    /// UDP受信 リッスン開始
    /// </summary>
    public void SendStart()
    {
        client = new UdpClient();
        client.Connect(host, sendPort);
        thread = new Thread(new ThreadStart(Thread));
        thread.Start();
        Debug.Log("UDP send thread start");
    }
    /// <summary>
    /// 解放処理
    /// </summary>
    public void Dispose()
    {
        if (thread != null)
        {
            thread.Abort();
            thread = null;
        }
        if (client != null)
        {
            client.Close();
            client.Dispose();
            client = null;
        }
    }
    /// <summary>
    /// スレッド
    /// </summary>
    private void Thread()
    {
            if (client != null)
            {
                try
                {
                    byte[] dgram = System.Text.Encoding.UTF8.GetBytes("変数受け渡し" + SendMes);
                    client.Send(dgram, dgram.Length);
                }
                catch (System.Exception e)
                {
                    Debug.Log(e.Message);
                }
            }
            else
            {
                Debug.Log("送れなかったよ");
            }
    }
    void OnApplicationQuit()
    {
        client.Close();
    }
}

//
//https://chiritsumo-blog.com/unity-udp-server/using System.Collections;
