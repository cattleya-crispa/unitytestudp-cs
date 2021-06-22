using System.Net.Sockets;
using System.Threading;
using UnityEngine;
using System.Net;
public class UDPServer
{
    /// <summary>
    /// デリゲート 受信時イベント
    /// </summary>
    /// <param name="strMsg"></param>
    public delegate void ReceivedHandler(string strMsg);
    /// <summary>
    /// 受信時イベント
    /// </summary>
    public ReceivedHandler Received;
    /// <summary>
    /// 受信処理 スレッド
    /// </summary>
    private Thread thread;
    /// <summary>
    /// リッスンポート
    /// </summary>
    private int nListenPort;
    /// <summary>
    /// UDPクライアント
    /// </summary>
    private UdpClient client;
    //--------------------------------------------------------------------------
    /// <summary>
    /// UDPServer
    /// </summary>
    public UDPServer(int port = 3005)
    {
        nListenPort = port;
        client = null;
    }
    /// <summary>
    /// UDP受信 リッスン開始
    /// </summary>
    public void ListenStart()
    {
        client = new UdpClient(nListenPort);
        thread = new Thread(new ThreadStart(Thread));
        thread.Start();
        Debug.Log("UDP Receive thread start");
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
        while (true)
        {
            if (client != null)
            {
                try
                {
                    IPEndPoint ep = null;
                    byte[] rcvBytes = client.Receive(ref ep);
                    string rcvMsg = string.Empty;
                    rcvMsg = System.Text.Encoding.UTF8.GetString(rcvBytes);
                    if (rcvMsg != string.Empty)
                    {
                        Debug.Log("UDP受信メッセージ : " + rcvMsg);
                        Received?.Invoke(rcvMsg);
                    }
                }
                catch (System.Exception e)
                {
                    Debug.Log(e.Message);
                }
            }
            else
            {
                Debug.Log("Error:client = null");
            }
        }
    }
}

//
//https://chiritsumo-blog.com/unity-udp-server/