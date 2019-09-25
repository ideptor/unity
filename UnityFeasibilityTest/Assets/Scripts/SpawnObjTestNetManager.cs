using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SpawnObjTestNetManager : NetworkManager
{
    [SerializeField]
    public InputField ipInputField;
    [SerializeField]
    public InputField portInputField;

    
    public override void OnServerConnect(NetworkConnection conn)
    {
        base.OnServerConnect(conn);
        Debug.Log("[Client]Connect Server Success");
        /*
        // spawnPrefabs에 등록된 프리팹을 스폰한다.
        GameObject charObj = Instantiate(spawnPrefabs[0]);

        // 네트워크를 통해서 이 오브젝트가 생성되었음을 클라이언트에 알린다.
        NetworkServer.Spawn(charObj);
        */
    }



    //출처: https://wergia.tistory.com/106?category=768883 [베르의 프로그래밍 노트]

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OpenServer()
    {
        networkPort = int.Parse(portInputField.text);
        StartServer();
    }

    public void OpenHost()
    {
        networkPort = int.Parse(portInputField.text);
        StartHost();
    }

    public void ConnectClientToServer()
    {
        networkAddress = ipInputField.text;
        networkPort = int.Parse(portInputField.text);
        StartClient();
    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        Debug.Log("[Server]Start Server");
    }

    public override void OnStartHost()
    {
        base.OnStartHost();
        Debug.Log("[Server]Start Host");
    }

    public override void OnStartClient(NetworkClient client)
    {
        base.OnStartClient(client);
        Debug.Log("[Client]Start Client");
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);
        Debug.Log("[Server]Connected Client");
    }

}
