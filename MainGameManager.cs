using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour {

    public int GameDifficulty = 4;
    public GameManager instance;

    void Awake()
    {
        instance = FindObjectOfType<GameManager>();
        if (instance)
        {
            GameDifficulty = instance.Difficulty;
        }
    }
    
	void Start ()
    {
        
    }

	void Update ()
    {
		
	}
}
