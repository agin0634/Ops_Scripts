using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModeText : MonoBehaviour {

    private GameManager instance;
    private Text text { get { return GetComponent<Text>(); } }
    
	void Start ()
    {
        instance = FindObjectOfType<GameManager>();

        if(instance.GameMode == 0)
        {
            // Challenge
            text.text = "Level " + instance.CurrentLevel.ToString();
        }
        else if(instance.GameMode == 1)
        {
            // Training 
            text.text = "Training";
        }
        else if (instance.GameMode == 2)
        {
            // Tutorial
            if (instance.Difficulty == 4)
            {
                text.text = "Tutorial 2";
            }
            else
            {
                text.text = "Tutorial 1";
            }
        }
    }
}
