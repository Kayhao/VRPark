using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisPosition : MonoBehaviour {

    private void Awake()
    {
        UnityEngine.XR.InputTracking.disablePositionalTracking = true;
    }
    

}
