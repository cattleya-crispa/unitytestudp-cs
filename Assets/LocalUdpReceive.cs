using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class LocalUdpReceive : MonoBehaviour
{
    //public string ip = "127.0.0.1";
    public int LOCA_LPORT = 3006;
    //int LOCA_LPORT = 3006;
    static UdpClient udp;
    Thread thread;

    public string ReceiveText = "def";

    UDPServer udpServer;
    //UDPC udpClient;
    udpClient udpClient2;

    void Start()
    {
        udp = new UdpClient(LOCA_LPORT);
        //udp.Client.ReceiveTimeout = 1000;
        thread = new Thread(new ThreadStart(ThreadMethod));
        thread.Start();

        udpServer = new UDPServer();
        udpServer.Received += ReceiveUdp;
        udpServer.ListenStart();

    }

    void Update()
    {
    }

    void OnApplicationQuit()
    {
        thread.Abort();
    }

    public void ThreadMethod()
    {
        while (true)
        {
            IPEndPoint remoteEP = null;
            byte[] data = udp.Receive(ref remoteEP);
            string text = Encoding.ASCII.GetString(data);
            Debug.Log("メイン受信"+text);

        }
    }


    public string GetReceiveText(string gtr) {
        Debug.Log("ゲット" + gtr);
        string Aiude = "aんんんん";
        gtr = Aiude;
        Debug.Log("GRT変数置き換え" + gtr);

        return gtr;
    }

    public void ReceiveUdp(string strMsg)
    {
        // UDPメッセージを受信したらこの関数が呼ばれる
        Debug.Log("ReceiveUdp関数呼ばれました"+strMsg);
        SendMesUdp(strMsg);
        string gtr = GetReceiveText(strMsg);
        Debug.Log(gtr);
        //udpClient2 = GameObject.Find("Main Camera").GetComponent<udpClient>();
        //udpClient udpClient2 = GetComponent<udpClient>();
        udpClient2 = new udpClient();
        udpClient2.Start();
        udpClient2.UdpSendText(strMsg);

    }

    public void SendMesUdp(string strCMsg)
    {
        //udpClient = new UDPC();
        //udpServer.Received += ReceiveUdp;
        //udpClient.SendMes += SendMesUdp;
        //udpClient.SendMes(strCMsg);
        //udpClient.SendStart();
        //udpClient.SendMes?.Invoke("成功");
        //Debug.Log("sendMesUdp関数呼ばれました" + strCMsg);

    }
}