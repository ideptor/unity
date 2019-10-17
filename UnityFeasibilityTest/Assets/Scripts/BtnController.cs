using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnController : MonoBehaviour
{

    //public SpawnObjTestNetManager networkManager;
    SpawnObjTestNetManager networkManager;


    // Start is called before the first frame update
    void Start()
    {

        networkManager = FindObjectOfType<SpawnObjTestNetManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStartServer()
    {
        networkManager.StartServer();
    }

    public void OnClickStartClient()
    {
        networkManager.StartClient();
    }

    public void OnClickStartHost()
    {
        networkManager.StartHost();
    }
}
