using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleCheck : MonoBehaviour {

    public Toggle To;
    public GameObject Go;
    
    public int isOn;
    private bool switching = false;

    private float handleSize;
    public float handleOffset;

    private float onPosX;
    private float offPosX;

    private float onScale = 1f;
    private float offScale = 0.4f;

    public float speed = 3f;
    static float t = 0.0f;

    public RectTransform HandleRect;
    public RectTransform ToRect;

    void Awake()
    {
        To = gameObject.GetComponent<Toggle>();
       
        HandleRect = Go.GetComponent<RectTransform>();
        ToRect = To.GetComponent<RectTransform>();
        handleSize = HandleRect.sizeDelta.x;
        float toggleSizeX = ToRect.sizeDelta.x;
        onPosX = (toggleSizeX / 2) - (handleSize / 2) + handleOffset;
        offPosX = onPosX * -1;
        
    }

    void Start ()
    {
        /*
        if (To.isOn)
        {
            isOn = 1;
        }
        else
        {
            isOn = 0;
        }*/

        if (isOn == 1 )
        {
            Go.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(onPosX, 0f, 0f);
            Go.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            Go.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(offPosX, 0f, 0f);
            Go.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
    }
	
    void FixedUpdate()
    {
        if (switching)
        {
            Toggle(isOn == 1);
        }
    }

    public void Toggle(bool toggleStatus)
    {
        if (toggleStatus)
        {
            Go.transform.localScale = SmoothScale(onScale, offScale);
            Go.GetComponent<RectTransform>().anchoredPosition3D = SmoothMove(onPosX, offPosX);
        }
        else
        {
            Go.transform.localScale = SmoothScale(offScale, onScale);
            Go.GetComponent<RectTransform>().anchoredPosition3D = SmoothMove(offPosX, onPosX);
        }
        
    }

    public void Switching()
    {
        switching = true;
    }

    Vector3 SmoothMove(float startPosX, float endPosX)
    {

        Vector3 position = new Vector3(Mathf.Lerp(startPosX, endPosX, t += speed * Time.deltaTime), 0f, 0f);
        StopSwitching();
        return position;
    }

    Vector3 SmoothScale(float StartScale, float EndScale)
    {
        Vector3 scale = new Vector3(Mathf.Lerp(StartScale, EndScale, t += speed * Time.deltaTime),
                                    Mathf.Lerp(StartScale, EndScale, t += speed * Time.deltaTime), 1f);
        return scale;
    }

    void StopSwitching()
    {
        if (t > 1.0f)
        {
            switching = false;

            t = 0.0f;
            switch (isOn)
            {
                case 1:
                    isOn = 0;
                    break;

                case 0:
                    isOn = 1;
                    break;
            }

        }
    }
}
