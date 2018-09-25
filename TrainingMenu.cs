using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrainingMenu : MonoBehaviour {

    public Text DifficultyText;
    public int Difficulty = 4;
    public GameManager instance;
    public Animator SubMenuAnim;
    public Animator GameLogoAnim;

    private bool bIsAnimExit = false;

    void Start ()
    {
        instance = FindObjectOfType<GameManager>();
	}
	
	void FixedUpdate ()
    {
        DifficultyText.text = Difficulty.ToString();

        if (bIsAnimExit)
        {
            Debug.Log(GameLogoAnim.GetCurrentAnimatorStateInfo(0).normalizedTime);
            
            if (GameLogoAnim.GetCurrentAnimatorStateInfo(0).IsName("GameLogoExit") && 
                GameLogoAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                SceneManager.LoadScene("ChallengeScene");
                bIsAnimExit = false;
            }
        }
	}

    public void DiffAdd()
    {
        if(Difficulty < 10)
        {
            Difficulty++;
        }
        else if (Difficulty == 10)
        {
            Difficulty = 4;
        }
    }

    public void DiffReduce()
    {
        if (Difficulty > 4)
        {
            Difficulty--;
        }
        else if (Difficulty == 4)
        {
            Difficulty = 10;
        }
    }

    public void TrainingStart()
    {
        instance.Difficulty = Difficulty;
        SubMenuAnim.SetBool("ButtonPressed", false);
        GameLogoAnim.SetBool("LogoExit", true);
        bIsAnimExit = true;
    }
    

}
