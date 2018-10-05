using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    public int GameMode;
    public int Difficulty = 4;
    public int CurrentLevel = 1;
    public float CurrentTime = 0f;

	void Awake ()
    {
		if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
	}
	
}
