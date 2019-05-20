using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

    public static CountDown Instance;
    private Text countDown;
    private int time=3;

    private void Awake()
    {
        Instance = this;
        countDown = transform.Find("Text").GetComponent<Text>();
        gameObject.SetActive(false);
    }

    public void ShowTime()
    {
        if (time>0)
        {
            gameObject.SetActive(true);
            countDown.text = time.ToString();
            time--;
        }
    }
}
