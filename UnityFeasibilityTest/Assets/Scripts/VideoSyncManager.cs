using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoSyncManager : MonoBehaviour
{

    private const double SYNC_THRESHOLD_SECOND = 0.2;
    private const float SYNC_INTERVAL = 0.1f;
    private float syncCount;

    // Start is called before the first frame update
    void Start()
    {
        syncCount = SYNC_INTERVAL;
        
    }

    // Update is called once per frame
    void Update()
    {
        var remoteController = FindObjectOfType<RemoteVideoController>();
        if(remoteController != null && remoteController.isServer)
        {
            syncCount -= Time.deltaTime;
            if (syncCount < 0)
            {
                syncCount = SYNC_INTERVAL;
                var localController = FindObjectOfType<VideoController>();

                bool isPlaying = localController.IsPlaying();
                SyncPlayStatus(isPlaying, remoteController);

                double curTime = localController.getCurrentTime();
                remoteController.Sync(curTime, DateTime.Now.Millisecond, SYNC_THRESHOLD_SECOND);
            }

        }

    }

    private void SyncPlayStatus(bool isPlaying, RemoteVideoController remoteController)
    {
        if(isPlaying)
        {
            remoteController.RpcPlay();
        } else
        {
            remoteController.RpcPause();
        }
    }
}
