using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkMode_Game : MonoBehaviour {
    
    public Color32 Dark_Color = new Color32(38, 48, 54, 255);
    public Color32 Bright_Color = new Color32(190, 171, 145, 255);

    public GameObject[] bG;
    public GameObject[] bH;
    public GameObject[] Equal;
    public Image[] Ops_Circle;
    public GameObject[] Icon;
    public Shadow[] shadows;
    public Text[] Game_text;
    public Image[] Images;

    public void DarkOn()
    {
        for(int i = 0; i <= bG.Length - 1; i++)
        {
            bG[i].GetComponent<SpriteRenderer>().color = Dark_Color;
        }
        for (int j = 0; j <= bH.Length - 1; j++)
        {
            bH[j].GetComponent<Image>().color = Bright_Color;
        }
        for (int k = 0; k <= Game_text.Length - 1; k++)
        {
            Game_text[k].color = Bright_Color;
        }
        for (int g = 0; g <= Ops_Circle.Length - 1; g++)
        {
            Ops_Circle[g].color = Bright_Color;
            Equal[g].GetComponent<Image>().color = Bright_Color;
        }
        for(int m = 0; m <= Images.Length - 1; m++)
        {
            Images[m].color = Bright_Color;
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
        for (int i = 0; i <= bG.Length - 1; i++)
        {
            bG[i].GetComponent<SpriteRenderer>().color = Bright_Color;
        }
        for (int j = 0; j <= bH.Length - 1; j++)
        {
            bH[j].GetComponent<Image>().color = Dark_Color;
        }
        for (int k = 0; k <= Game_text.Length - 1; k++)
        {
            Game_text[k].color = Dark_Color;
        }
        for (int g = 0; g <= Ops_Circle.Length - 1; g++)
        {
            Ops_Circle[g].color = Dark_Color;
            Equal[g].GetComponent<Image>().color = Dark_Color;
        }
        for (int m = 0; m <= Images.Length - 1; m++)
        {
            Images[m].color = Dark_Color;
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
