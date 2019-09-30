using System;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine;

public class RemoteVideoController : NetworkBehaviour
{
    public Text indicator;

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

    [ClientRpc]
    public void RpcSync(double serverCurTime, int sendTime, double treshold)
    {
        var video = FindObjectOfType<VideoController>();
        
        int receiveTime = DateTime.Now.Millisecond;
        double clientCurTime = video.getCurrentTime();

        //double timeDiff = Math.Abs((serverCurTime + (receiveTime - sendTime) / 1000.0f) - clientCurTime);
        double timeDiff = serverCurTime - clientCurTime;
        video.AdjustSpeedByTimeDiff(timeDiff, treshold);


        String indicatorText = "";
        indicatorText += "server: " + serverCurTime.ToString("F2")+"s\n";
        indicatorText += "client: " + clientCurTime.ToString("F2") + "s\n";
        indicatorText += "diff  : " + timeDiff.ToString("F2") + "s\n";
        indicatorText += "network delay: " + (receiveTime - sendTime) + "ms\n";


        //Debug.Log(indicatorText);
        if (indicator != null)
        {
            indicator.text = indicatorText;
        }

    }

    public void OnClickPlay()
    {
        RpcPlay();
    }

    public void OnClickPause()
    {
        RpcPause();
    }

    internal void Sync(double serverCurTime, int sendTime, double treshold)
    {
        if(isServer)
        {
            RpcSync(serverCurTime, sendTime, treshold);
        }
            
    }
}
