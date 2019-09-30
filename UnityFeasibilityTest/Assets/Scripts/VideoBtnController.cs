using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoBtnController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayButtonClicked()
    {
        Debug.Log("OnPlayButtonClicked() - ");

        var remoteController = FindObjectOfType<RemoteVideoController>();
        if (remoteController == null)
        {
            Debug.Log("remoteController is not ready");
            return;
        }
            

        if(remoteController.isServer) { 
            var video = FindObjectOfType<VideoController>();
            video.PlayVideo();
            remoteController.OnClickPlay();
        } else
        {
            Debug.Log("Client cannot play");
        }
    }

    public void OnPauseButtonClicked()
    {
        Debug.Log("OnPauseButtonClicked() - ");
        var remoteController = FindObjectOfType<RemoteVideoController>();
        if (remoteController == null)
        {
            Debug.Log("remoteController is not ready");
            return;
        }

        if (remoteController.isServer)
        {
            var video = FindObjectOfType<VideoController>();
            video.PauseVideo();
            remoteController.OnClickPause();
        }
        else
        {
            Debug.Log("Client cannot pause");
        }
    }
}
