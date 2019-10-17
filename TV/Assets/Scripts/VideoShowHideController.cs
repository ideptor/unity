using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoShowHideController : MonoBehaviour
{
    public GameObject TVPanel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnShowButtonClicked()
    {
        Debug.Log("OnShowButtonClicked() - ");

        var video = FindObjectOfType<VideoController>();
        video.PlayVideo();

        TVPanel.SetActive(true);

    }

    public void OnHideButtonClicked()
    {
        Debug.Log("OnHideButtonClicked() - ");

        TVPanel.SetActive(false);

        var video = FindObjectOfType<VideoController>();
        video.PauseVideo();
    }

    public void OnSwitchButtonClicked()
    {
        Debug.Log("OnSwitchButtonClicked() - ");

        var video = FindObjectOfType<VideoController>();
        video.SwitchVideoClip();
    }

    public void OnChangeURLButtonClicked()
    {
        Debug.Log("OnChangeURLButtonClicked() - ");

        var video = FindObjectOfType<VideoController>();
        InputField inputField = FindObjectOfType<InputField>();

        string url = inputField.text;
        video.ChangeVideoUrl(url);

    }
}
