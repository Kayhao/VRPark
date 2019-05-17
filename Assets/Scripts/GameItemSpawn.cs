using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameItemSpawn : MonoBehaviour {

    public static GameItemSpawn Instance;
    public Material[] gameItems;
    public GameObject go_gameItem;
    private float angel;
    public int index = 0;

    private void Awake()
    {
        Instance = this;
        angel=360.0f / gameItems.Length;
        for (int i = 0; i < gameItems.Length; i++)
        {
            GameObject go = GameObject.Instantiate(go_gameItem,transform);
            go.transform.localEulerAngles = new Vector3(0,i*angel,0);
            go.GetComponentInChildren<MeshRenderer>().material = gameItems[i];
            go.GetComponentInChildren<GameItem>().SetVideoName(gameItems[i].name);
            go.GetComponentInChildren<GameItem>().index = i;
        }
    }
    public void RotateRight()
    {
        index++;
        //if (index>=gameItems.Length)
        //{
        //    index = 0;
        //}
        index %= gameItems.Length;
        transform.DORotate(new Vector3(0,-index*angel,0),0.5f);
    }
    public void RotateLeft()
    {
        index--;
        if (index < 0)
        {
            index = gameItems.Length-1;
        }
        transform.DORotate(new Vector3(0, -index * angel, 0), 0.5f);
    }

}
