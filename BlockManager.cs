using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {

    public int Difficulty = 4;
    public GameObject[] Block_Movable;
    public MainGameManager GameManager;
    
	// Use this for initialization
	void Start () {
        if (GameManager)
        {
            Difficulty = GameManager.GameDifficulty;
        }

		for (int i = 0; i <= Difficulty - 1 ; i++)
        {
            Block_Movable[i].SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
