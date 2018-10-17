using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {

    public GameManager instance;
    
	void Start ()
    {
		if(PlayerPrefs.GetInt("IsNotFirstTime") == 1)
        {
            instance = FindObjectOfType<GameManager>();
            instance.GameMode = 2;
            instance.Difficulty = 2;
            SceneManager.LoadScene("TutorialScene");
        }
	}
	
	void Update ()
    {
		
	}

    public void OpenTutorial()
    {

    }
}
