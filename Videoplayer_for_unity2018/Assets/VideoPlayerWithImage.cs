using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;



//출처: https://bikim0108.tistory.com/47 [신에게 영광이 있기를]
// https://docs.unity3d.com/Manual/class-VideoPlayer.html

public class VideoPlayerWithImage : MonoBehaviour
{
    public RawImage Image;
    VideoPlayer video;
    //AudioSource audio;

    void Awake()     {
        //Image = GetComponent<RawImage>();
        video = gameObject.AddComponent<VideoPlayer>();
        //audio = gameObject.AddComponent<AudioSource>();
        video.playOnAwake = false;
        //audio.playOnAwake = false;
        //audio.Pause();
        PlayVideo();

    }

    public void PlayVideo()    {

        StartCoroutine(playVideo());
    }

    IEnumerator playVideo()

    {

        video.source = VideoSource.Url;
        video.url = "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4";
        video.audioOutputMode = VideoAudioOutputMode.AudioSource;

        video.EnableAudioTrack(0, true);
        //video.SetTargetAudioSource(0, audio);
        video.Prepare();
        WaitForSeconds waitTime = new WaitForSeconds(1.0f);

        while (!video.isPrepared)        {
            Debug.Log("동영상 준비중...");
            yield return waitTime;
        }

        Debug.Log("동영상이 준비가 끝났습니다.");
        Image.texture = video.texture;
        video.Play();
        //audio.Play();

        Debug.Log("동영상이 재생됩니다.");

        while (video.isPlaying) {
            Debug.Log("동영상 재생 시간 : " + Mathf.FloorToInt((float)video.time));
            yield return null;
        }
        Debug.Log("영상이 끝났습니다.");

    }

}
