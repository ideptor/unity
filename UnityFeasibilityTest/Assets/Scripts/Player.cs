using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Player : NetworkBehaviour
{
    int count = 0;

    [ClientRpc]
    public void RpcPlayerConnected()
    {
        Debug.Log("Client Rpc Call.");
    }

    
    [Command]
    public void CmdTestFunction(int i)
    {
        Debug.Log("Command Function Call. " + i);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            CmdTestFunction(count++);
            Debug.Log("Input A. " + count);
            Debug.Log(NetworkManager.singleton.networkAddress);
        }
    }
}



//출처: https://wergia.tistory.com/101?category=768883 [베르의 프로그래밍 노트]
