using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnObjTestNetManager : NetworkManager
{

    public override void OnServerConnect(NetworkConnection conn)
    {
        base.OnServerConnect(conn);
        // spawnPrefabs에 등록된 프리팹을 스폰한다.
        GameObject charObj = Instantiate(spawnPrefabs[0]);

        // 네트워크를 통해서 이 오브젝트가 생성되었음을 클라이언트에 알린다.
        NetworkServer.Spawn(charObj);
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
}
