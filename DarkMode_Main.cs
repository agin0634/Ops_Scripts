using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkMode_Main : MonoBehaviour {

    public Color32 Dark_Color = new Color32(38, 48, 54, 255);
    public Color32 Bright_Color = new Color32(190, 171, 145, 255);
    
    public GameObject MainMenu;
    public GameObject GameLogo;
    public GameObject[] bG;
    public GameObject[] gO;
    public GameObject[] Icon;
    public Shadow[] shadows;
    public Text[] Game_text; 
        
    public void DarkOn()
    {
        MainMenu.GetComponent<Image>().color = Dark_Color;
        GameLogo.GetComponent<Image>().color = Bright_Color;

        for(int i = 0; i <= Game_text.Length - 1; i++)
        {
            Game_text[i].color = Bright_Color;
        }

        for (int j = 0; j <= gO.Length - 1; j++)
        {
            gO[j].GetComponent<Image>().color = Bright_Color;
        }

        for (int k = 0; k <= bG.Length - 1; k++)
        {
            bG[k].GetComponent<SpriteRenderer>().color = Dark_Color;
        }

        for (int y = 0; y <= Icon.Length - 1; y++)
        {
            Icon[y].GetComponent<Image>().color = Dark_Color;
        }

        for (int s = 0; s <= shadows.Length - 1; s++)
        {
            shadows[s].effectColor = new Color32(77, 77, 77, 130);
        }

    }

    public void DarkOff()
    {
        MainMenu.GetComponent<Image>().color = Bright_Color;
        GameLogo.GetComponent<Image>().color = Dark_Color;

        for (int i = 0; i <= Game_text.Length - 1; i++)
        {
            Game_text[i].color = Dark_Color;
        }

        for (int j = 0; j <= gO.Length - 1; j++)
        {
            gO[j].GetComponent<Image>().color = Dark_Color;
        }

        for (int k = 0; k <= bG.Length - 1; k++)
        {
            bG[k].GetComponent<SpriteRenderer>().color = Bright_Color;
        }

        for (int y = 0; y <= Icon.Length - 1; y++)
        {
            Icon[y].GetComponent<Image>().color = Bright_Color;
        }

        for (int s = 0; s <= shadows.Length - 1; s++)
        {
            shadows[s].effectColor = new Color32(77, 77, 77, 77);
        }
    }
}
