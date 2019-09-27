using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{


    // public RawImage Image;
    VideoPlayer video;
    //AudioSource audio;

    //Boolean isPaused = false;
    Boolean isStarted = false;

    void Awake()
    {
        //Image = GetComponent<RawImage>();
        video = FindObjectOfType<VideoPlayer>();
        //audio = gameObject.AddComponent<AudioSource>();
        video.playOnAwake = false;
        //audio.playOnAwake = false;
        //audio.Pause();
        StartCoroutine(Prepare());
        //PlayVideo();
    }

    internal double getCurrentTime()
    {
        if(video == null)
        {
            return 0;
        }
        return video.time;
    }

    public void PlayVideo()
    {
        if(!isStarted)
        {
            StartCoroutine(playVideo());
            isStarted = true;
        } else
        {
            video.Play();
        }
        
    }

    internal void AdjustSpeedByTimeDiff(double timeDiff, double treshold)
    {
        String log = "AdjustSpeed - ";
        log += "playbackspeed:" + video.playbackSpeed.ToString("F1");
        log += ", curtime:" + video.time;
        log += ", timediff:" + timeDiff;
        Debug.Log(log);

        if (Math.Abs(timeDiff) < treshold)
        {
            video.playbackSpeed = 1;
            return;
        }

        if (timeDiff > 0)
        {
            video.playbackSpeed = 1.1f;
        } else
        {
            video.playbackSpeed = 0.9f;
        }
    }


    internal void PauseVideo()
    {
        if(isStarted)
        {
            video.Pause();
        }
    }

    private IEnumerator Prepare()
    {
        video.source = VideoSource.Url;
        video.url = "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4";
        //video.url = "file://C:/Users/idept/Downloads/SKYFALL.mp4";
        video.audioOutputMode = VideoAudioOutputMode.AudioSource;

        video.EnableAudioTrack(0, true);
        //video.SetTargetAudioSource(0, audio);
        video.Prepare();
        WaitForSeconds waitTime = new WaitForSeconds(1.0f);

        while (!video.isPrepared)
        {       
            Debug.Log("동영상 준비중...");
            yield return waitTime;
        }

        Debug.Log("동영상이 준비가 끝났습니다.");
    }

    IEnumerator playVideo()
    {


        //Image.texture = video.texture;
        video.Play();
        //audio.Play();

        Debug.Log("동영상이 재생됩니다.");

        //video.time = video.time + 100; 

        while (video.time < video.length)
        {
            //Debug.Log("동영상 재생 시간 : " + Mathf.FloorToInt((float)video.time) + "/" + Mathf.FloorToInt((float)video.length));
            //Debug.Log("동영상 재생 시간 : " + (float)video.time + "/" + Mathf.FloorToInt((float)video.length));
            yield return null;
        }
        Debug.Log("영상이 끝났습니다.");

    }
}
