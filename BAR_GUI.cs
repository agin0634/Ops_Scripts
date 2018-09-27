using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BAR_GUI : MonoBehaviour {

    public Text Time_Text;
    public Text Level_Text;
    public GameManager instance;

    // Use this for initialization
    void Start () {
        instance = FindObjectOfType<GameManager>();
        if (PlayerPrefs.GetInt("Training_Timer") == 0)
        {
            Time_Text.text = "--:--";
        }
        if(instance.GameMode == 1)
        {
            Level_Text.text = "Training";
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
