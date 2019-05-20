using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {

    public static Loading Instance;

    private Image loadingBar;
    private AsyncOperation operation;
    private bool isLoading = false;

    private void Awake()
    {
        Instance = this;
        transform.localScale = Vector3.zero;
        loadingBar = transform.Find("LoadingBar").GetComponent<Image>();
    }

    public void LoadScene()
    {
        transform.DOScale(Vector3.one, 0.5f).OnComplete(()=>
        {
            StartCoroutine("Load");
        });
        
    }

    IEnumerator Load()  //开协程
    {
        int progress = -1;
        int progress_full = 100;
        while (progress<progress_full)
        {
            progress++;    //加1后进度从0开始
            show(progress);

            if (isLoading==false)  
            {
                operation = SceneManager.LoadSceneAsync(2);  //+GameItemSpawn.instance.index
                operation.allowSceneActivation = false;  //不允许马上跳场景
                isLoading = true;
            }
            yield return new WaitForEndOfFrame();
        }
        if (progress==100)
        {
            operation.allowSceneActivation = true;
            StopCoroutine("Load");
        }
    }

    private void show(int progress)
    {
        loadingBar.fillAmount = progress * 0.01f;
    }
}
