using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using VRTK;
using System.IO;

public class GameItem : MonoBehaviour
{


    private VideoPlayer videoPlayer;
    public int index;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        //GameObject.Find("ControllerRight").GetComponent<VRTK_ControllerEvents>().TouchpadReleased += GameItem_TouchpadReleased;
        //GameObject.Find("ControllerLeft").GetComponent<VRTK_ControllerEvents>().TouchpadReleased += GameItem_TouchpadReleased;

    }

    private void Update()
    {
        if (index == GameItemSpawn.Instance.index)
        {
            GetComponent<MeshCollider>().enabled = true;
            GetComponent<MeshRenderer>().material.color = Color.white;
        }
        else
        {
            GetComponent<MeshCollider>().enabled = false;
            GetComponent<MeshRenderer>().material.color = Color.gray;
        }
    }

    //private void GameItem_TouchpadReleased(object sender, ControllerInteractionEventArgs e)
    //{
    //    videoPlayer.Pause();  //抬起就暂停
    //}

    public void SetVideoName(string videoName)
    {
        videoPlayer.url = GetVideoPath(videoName);
    }
    private string GetVideoPath(string videoName)
    {
        return Application.dataPath + "/StreamingAssets/" + videoName + ".mp4";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (File.Exists(videoPlayer.url) == false)
        {
            return;
        }
        if (!videoPlayer.isPlaying)
        {
            videoPlayer.Play();
        }
        else
        {
            videoPlayer.Pause();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        videoPlayer.Pause();
    }
}
