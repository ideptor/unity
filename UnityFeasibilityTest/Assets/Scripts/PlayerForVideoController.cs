using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerForVideoController : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ClientRpc]
    public void RpcPlay()
    {
        var video = FindObjectOfType<VideoController>();
        video.PlayVideo();
    }

    [ClientRpc]
    public void RpcPause()
    {
        var video = FindObjectOfType<VideoController>();
        video.PauseVideo();
    }

    public void OnClickPlay()
    {
        RpcPlay();
    }

    public void OnClickPause()
    {
        RpcPause();
    }
}
