using UnityEngine;
using System.Net.Sockets;
using System.Text;

public class udpClient : MonoBehaviour
{
    // broadcast address
    public string host = "127.0.0.1";
    public int port = 3002;
    private UdpClient client;

    public void Start()
    {
        client = new UdpClient();
        client.Connect(host, port);
    }

    void Update()
    {
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 40), "Send"))
        {
            byte[] dgram = Encoding.UTF8.GetBytes("hello!");
            client.Send(dgram, dgram.Length);

            DebugText("今日わ");
        }
    }

    public void UdpSendText(string sendmmm)
    {
            byte[] dgram = Encoding.UTF8.GetBytes(sendmmm);
            client.Send(dgram, dgram.Length);
    }

    void DebugText(string SendM)
    {

        Debug.Log(SendM + "を送信しました");

    }

    void OnApplicationQuit()
    {
        client.Close();
    }
}

//https://qiita.com/nenjiru/items/d9c4e8a22601deb0425b