using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class Player : NetworkBehaviour
{
    public int hp;
    //public Text HPText;

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

    private void Start()
    {
        if(isServer)
        {
            hp = 100;
            RpcSyncHp(hp);
        }
    }

    [ClientRpc]
    public void RpcSyncHp(int hp)
    {
        this.hp = hp;
    }

    [Command]
    public void CmdDamaged(int dmg)
    {
        hp -= dmg;
        RpcSyncHp(hp);
        Debug.Log("Hp: " + hp);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            CmdTestFunction(count++);
            Debug.Log(">> Input A. " + count);
            string ip1 = NetworkManager.singleton.networkAddress;
            
            Debug.Log(ip1);
        }

        if (isServer && isLocalPlayer)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CmdDamaged(3);
            }
        }
        else if (isClient && isLocalPlayer)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                CmdDamaged(10);
            }
        }


    }
}



//출처: https://wergia.tistory.com/101?category=768883 [베르의 프로그래밍 노트]
