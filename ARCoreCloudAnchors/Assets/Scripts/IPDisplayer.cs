using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using CUDLR;

public class IPDisplayer : MonoBehaviour
{
    public Text consoleText;

    // Start is called before the first frame update
    void Start()
    {
        string IP = LocalIPAddress();
        //string IP = NetworkManager.singleton.networkAddress;
        Debug.Log(IP);
        if(consoleText == null)
        {
            var lists = FindObjectsOfType<Text>();
            foreach( var item in lists)
            {
                Debug.Log("find:" + item.name);
                if(item.name == "ConsoleText")
                {
                    consoleText = item;
                }
            }
        }

        var CUDLRServer = GameObject.Find("CUDLRServer");
        var server = FindObjectOfType<Server>();

        string Port = server.Port.ToString();
        if (consoleText != null)
        {
            consoleText.text = "CUDLR - " + IP + ":" + Port;
            Debug.Log(consoleText.text);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public string LocalIPAddress()
    {
        IPHostEntry host;
        string localIP = "";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                localIP = ip.ToString();
                break;
            }
        }
        return localIP;
    }
}