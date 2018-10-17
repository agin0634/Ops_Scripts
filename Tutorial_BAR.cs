using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_BAR : MonoBehaviour {
    
    public MainGameManager GameManager;
    public Text Target_s_Text;

    void Start ()
    {
        if (!GameManager)
        {
            GameManager = FindObjectOfType<MainGameManager>();
        }

        Target_s_Text.text = GameManager.GetComponent<TargetNumber>().Target_Number.ToString();
    }
}
