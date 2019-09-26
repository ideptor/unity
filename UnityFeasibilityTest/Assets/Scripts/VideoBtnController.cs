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

        var player = FindObjectOfType<PlayerForVideoController>();
        if(player.isServer) { 
            var video = FindObjectOfType<VideoController>();
            video.PlayVideo();
            player.OnClickPlay();
        } else
        {
            Debug.Log("Client cannot play");
        }
    }

    public void OnPauseButtonClicked()
    {
        Debug.Log("OnPauseButtonClicked() - ");
        var player = FindObjectOfType<PlayerForVideoController>();

        if (player.isServer)
        {
            var video = FindObjectOfType<VideoController>();
            video.PauseVideo();
            player.OnClickPause();
        }
        else
        {
            Debug.Log("Client cannot pause");
        }
    }
}
