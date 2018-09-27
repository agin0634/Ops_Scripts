using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BAR_GUI : MonoBehaviour {

    public MainGameManager GameManager;
    public Text Time_Text;
    public Text Level_Text;
    public Text Target_s_Text;
    public GameManager instance;

    // Use this for initialization
    void Start () {
        if (!GameManager)
        {
            GameManager = FindObjectOfType<MainGameManager>();
        }

        instance = FindObjectOfType<GameManager>();

        if (PlayerPrefs.GetInt("Training_Timer") == 0)
        {
            Time_Text.text = "--:--";
        }
        if(instance.GameMode == 1)
        {
            Level_Text.text = "Training";
        }

        Target_s_Text.text = GameManager.GetComponent<TargetNumber>().Target_Number.ToString();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
