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
        var video = FindObjectOfType<VideoController>();
        video.PlayVideo();
    }

    public void OnPauseButtonClicked()
    {
        Debug.Log("OnPauseButtonClicked() - ");
        var video = FindObjectOfType<VideoController>();
        video.PauseVideo();
    }
}
