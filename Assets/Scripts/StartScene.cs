using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour {

    private Button btn_Start;
    private Button btn_Exit;

    private void Awake()
    {
        btn_Start = transform.Find("btn_Start").GetComponent<Button>();
        btn_Exit = transform.Find("btn_Exit").GetComponent<Button>();

        btn_Start.onClick.AddListener(()=>
        {
            SceneManager.LoadScene(1);
        }
        );

        btn_Exit.onClick.AddListener(() =>
        {
            Application.Quit();
        }
        );
    }


}
