using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{

    //private const string MOVIE_FILE_RELATIVE_PATH = "Movies/SKYFALL.mp4";  // PC
    private const string MOVIE_FILE_RELATIVE_PATH = "Movies/Teamwork.mp4";  
    //private const string MOVIE_FILE_PATH = "C:/Users/idept/Downloads/SKYFALL.mp4";  // PC
    //private const string MOVIE_FILE_PATH = "file:///sdcard/Movies/SKYFALL.mp4";    // Android
    //private const string MOVIE_FILE_PATH = "/sdcard/Movies/SKYFALL.mp4";    // Android
    private string _movie_file_path;

    private const string MOVIE_STREAMING_ABSOLUTE_URL = "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4";

    private const float MOVIE_START_TIME = 100.0f;

    private Text indicatorText;
    private string movieUrl;

       
    VideoPlayer video;

    Boolean isStarted = false;

    private void Start()
    {


    }
    private string AndroidRootPath()
    {
        // 출처: https://knightk.tistory.com/37 [KnightK]
        string[] temp = (Application.persistentDataPath.Replace("Android", "")).Split(new string[] { "//" }, System.StringSplitOptions.None);
        Debug.Log("temp.length"+temp.Length);
        for (int i=0; i<temp.Length; i++)
        {
            Debug.Log("temp[" + i + "]: " + temp[i]);
        }
        return (temp[0] + "/");
    }


    

    private string GetMovieFilePath() {

        string _path;
            //타켓 폴더 패스 설정
        if (Application.platform == RuntimePlatform.Android) {
            //android일 경우 //
            _path = AndroidRootPath() + MOVIE_FILE_RELATIVE_PATH;
            Debug.Log("adnroid path: " + _path);
        } else {
            //unity일 경우 //
            _path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) +"/"+ MOVIE_FILE_RELATIVE_PATH;
            Debug.Log("unity path: " + _path);
        }

        return _path;
    }



    void Awake()
    {
        var textlists = FindObjectsOfType<Text>();
        foreach (Text text in textlists)
        {
            if (text.name == "IndicatorText")
            {
                indicatorText = text;
                Debug.Log("Found indicator");
            }
        }

        _movie_file_path = GetMovieFilePath();

        video = FindObjectOfType<VideoPlayer>();
        video.playOnAwake = false;

        StartCoroutine(Prepare());
        PlayVideo();
    }

    internal void ChangeVideoUrl(string url)
    {
        video.url = url;
        if (indicatorText != null)
        {
            movieUrl = video.url;
            indicatorText.text = movieUrl;
        }
        PlayVideo();
    }

    internal void SwitchVideoClip()
    {
        video.Stop();
        if (video.url == _movie_file_path)
        {
            ChangeVideoUrl(MOVIE_STREAMING_ABSOLUTE_URL);
        } else
        {
            ChangeVideoUrl(video.url = _movie_file_path);
        }
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

    public bool IsPlaying()
    {
        if(video == null)
        {
            return false;
        }
        return video.isPlaying;
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
        if (File.Exists(_movie_file_path.Replace("file://","")))
        {
            Debug.Log("'" + _movie_file_path + "' exists.");
            ChangeVideoUrl(_movie_file_path);
        }
        else
        {
            ChangeVideoUrl(MOVIE_STREAMING_ABSOLUTE_URL);
        }
            

        //video.url = MOVIE_STREAMING_URL;
        movieUrl = "video.url:" + video.url;
        Debug.Log(movieUrl);
        if(indicatorText != null)
            indicatorText.text = movieUrl;
        
       

        video.Prepare();
        
        WaitForSeconds waitTime = new WaitForSeconds(0.1f);

        while (!video.isPrepared)
        {       
            Debug.Log("동영상 준비중..." + DateTime.Now.Millisecond);
            yield return waitTime;
        }

        Debug.Log("동영상이 준비가 끝났습니다.");
    }

    public void Update()
    {
        if (indicatorText != null)
        {
            indicatorText.text = movieUrl + "\n동영상 재생 시간 : " + video.time.ToString("F3") + "/" + video.length.ToString("F3");
        }
    }
    IEnumerator playVideo()
    {

        video.Play();

        Debug.Log("동영상이 재생됩니다.");

        //video.time += MOVIE_START_TIME;
        //video.time = video.time + 100; 

        while (video.time < video.length)
        {
            Debug.Log("동영상 재생 시간 : " + (float)video.time + "/" + Mathf.FloorToInt((float)video.length));
            if (indicatorText != null)
            {
                indicatorText.text = movieUrl + "\n동영상 재생 시간 : " + video.time.ToString("F3") + "/" + video.length.ToString("F3");
            }
            yield return null;
        }
        Debug.Log("영상이 끝났습니다.");
        Debug.Log("dd동영상 재생 시간 : " + video.time.ToString("F3") + "/" + video.length.ToString("F3"));
    }
}
