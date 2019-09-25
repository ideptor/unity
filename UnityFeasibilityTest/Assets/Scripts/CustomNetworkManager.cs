using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager
{
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        base.OnServerAddPlayer(conn, playerControllerId);

        Debug.Log("Add Player.");

        var players = FindObjectsOfType<Player>();
        foreach (var player in players)
        {
            //player.RpcPlayerConnected();
        }
    }

    //출처: https://wergia.tistory.com/101?category=768883 [베르의 프로그래밍 노트]
}
