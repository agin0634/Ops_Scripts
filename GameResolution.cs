using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResolution : MonoBehaviour {

    private CanvasScaler scaler { get { return GetComponent<CanvasScaler>(); } }

    void Awake()
    {
        float screenWidthScale = Screen.width / scaler.referenceResolution.x;
        float screenHeightScale = Screen.height / scaler.referenceResolution.y;
        scaler.matchWidthOrHeight = screenWidthScale > screenHeightScale ? 1 : 0;
    }
    
}
