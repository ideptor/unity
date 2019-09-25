using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class Player : NetworkBehaviour
{
    public delegate void OnChangeHp(int hp);

    public OnChangeHp onChangeHp;

    [SyncVar(hook ="ChangeHookHp")]
    public int hp;
    

    //1) 서버에서 변경여부가 클라이언트가 통지되었을때
    //2) 클라이언트에서만 실행
    //3) hook이 등록되어 있으면 해당 값은 자동으로 변경되지 않아 반드시 직접 대입해주어야 함.
    void ChangeHookHp(int hp)
    {
        this.hp = hp;

        // 만약 delegate event에 hp ui의 함수를 등록해두었다면 hp ui가 갱신될 것이다.
        onChangeHp(this.hp);
    }

    int count = 0;

    /*
    [ClientRpc]
    public void RpcPlayerConnected()
    {
        Debug.Log("Client Rpc Call.");
    }*/

    /*
    [Command]
    public void CmdTestFunction(int i)
    {
        Debug.Log("Command Function Call. " + i);
    }*/

    private void Start()
    {
        if(isServer)
        {
            hp = 100;
        }
    }


    [Command]
    public void CmdDamaged(int dmg)
    {
        hp -= dmg;
        Debug.Log("Hp: " + hp);
    }

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.A))
        {
            CmdTestFunction(count++);
            Debug.Log(">> Input A. " + count);
            string ip1 = NetworkManager.singleton.networkAddress;
            
            Debug.Log(ip1);
        }
        */
        if (isLocalPlayer)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(isServer)
                {
                    Debug.Log("server attack:");
                    hp -= 3;
                } else if (isClient)
                {
                    Debug.Log("client attack:");
                    CmdDamaged(10);
                }
            }
        }


    }
}