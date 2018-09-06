using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

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
