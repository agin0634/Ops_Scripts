using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayTimeMode()
    {
        SceneManager.LoadScene("TimeScene");
    }

    public void PlaySample()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
