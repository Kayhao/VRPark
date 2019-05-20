using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimController : MonoBehaviour
{

    public AudioSource audio;
    private Animation anim;
    private float anim_time;
    private bool isAudio = false;
    private bool isEnd = false;

    private float timer = 0f;
    private void Awake()
    {
        anim = GetComponent<Animation>();
        anim_time = anim.clip.length;
    }


    void Update()
    {
        anim_time -= Time.deltaTime;
        if (anim_time <= 8 && isAudio == false)
        {
            audio.Play();
            isAudio = true;
        }
        if (anim_time <= 0 && isEnd == false)
        {
            UnityEngine.XR.InputTracking.disablePositionalTracking = false;
            SceneManager.LoadScene(1);
            isEnd = true;
        }
        if (anim_time <= 4)
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                //print(timer);
                timer = 0;
                CountDown.Instance.ShowTime();
            }
        }
    }
}
