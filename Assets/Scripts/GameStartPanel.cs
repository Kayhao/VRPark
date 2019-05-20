using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartPanel : MonoBehaviour {

    private Button btn_Right;
    private Button btn_Left;
    private Button btn_Select;
    private string[] GameNames;
    private Text text_Title;

    private void Awake()
    {
        ReadName();
        Init();
    }

    private void Update()
    {
        text_Title.text = GameNames[GameItemSpawn.Instance.index];
    }
    private void Init()
    {
        text_Title = transform.Find("text_Title").GetComponent<Text>();
        btn_Right = transform.Find("btn_Right").GetComponent<Button>();
        btn_Left = transform.Find("btn_Left").GetComponent<Button>();
        btn_Select = transform.Find("btn_Select").GetComponent<Button>();

        btn_Right.onClick.AddListener(() =>
        {
            GameItemSpawn.Instance.RotateRight();
        }
        );

        btn_Left.onClick.AddListener(() =>
        {
            GameItemSpawn.Instance.RotateLeft();
        }
        );

        btn_Select.onClick.AddListener(() =>
        {
            //todo  跳进场景
            Loading.Instance.LoadScene();
        }
        );
    }
    private void ReadName()
    {
        TextAsset textAsset= Resources.Load<TextAsset>("GameName");
        GameNames=textAsset.text.Split('\n');
    }
}
