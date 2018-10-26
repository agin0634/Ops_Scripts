using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetNumber : MonoBehaviour
{

    private CalculationMethod cm { get { return GetComponent<CalculationMethod>(); } }
    private int[] NumberPool = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public bool bIsTutorial = false;
    public int Difficulty = 4;
    public int Target_Number;
    public List<int> Ref_Numbers;
    public List<int> Ref_Numbers_Temp;
    public GameManager instance;

    public MainGameManager GameManager;

    // Draw balls from the pool, according to Difficulty
    public void DrawBall()
    {
        for(int i = 1; i <= Difficulty; i++)
        {
            int x = Random.Range(0, NumberPool.Length-1);
            int Number_Drawn = NumberPool[x];
            Ref_Numbers.Add(Number_Drawn);
            Ref_Numbers_Temp.Add(Number_Drawn);
        }
    }

    public void CalculateTargetNumber()
    {
        for(int i = 1;i <= Difficulty - 1; i++)
        {
            int A; int B; int F;

            int x = Random.Range(0, Ref_Numbers_Temp.Count - 1);
            A = Ref_Numbers_Temp[x];
            Ref_Numbers_Temp.RemoveAt(x);
            
            x = Random.Range(0, Ref_Numbers_Temp.Count - 1);
            B = Ref_Numbers_Temp[x];
            Ref_Numbers_Temp.RemoveAt(x);
            
            switch (instance.Calulation_Diff)
            {
                case 0:
                    F =cm.easy_Calculation(A, B);
                    Ref_Numbers_Temp.Add(F);
                    break;
                case 1:
                    F = cm.medium_Calculation(A, B);
                    Ref_Numbers_Temp.Add(F);
                    break;
                case 2:
                    F = cm.Hard_Calculation(A, B);
                    Ref_Numbers_Temp.Add(F);
                    break;
                case 3:
                    // TODO insane cal
                    break;
            }

        }

        Target_Number = Ref_Numbers_Temp[0];
    }

    void Start () {
        if (GameManager)
        {
            Difficulty = GameManager.GameDifficulty;
        }

        instance = FindObjectOfType<GameManager>();
        

        if (instance.GameMode == 2)
        {
            if(Difficulty == 2)
            {
                DrawBall();
                Tutorial_Lv1();
            }
            else
            {
                DrawBall();
                Tutorial_Lv2();
            }
            
        }
        else
        {
            DrawBall();
            CalculateTargetNumber();
        }
	}

    void Tutorial_Lv1()
    {
        for (int i = 1; i <= Difficulty - 1; i++)
        {
            int A; int B; int F;

            int x = Random.Range(0, Ref_Numbers_Temp.Count - 1);
            A = Ref_Numbers_Temp[x];
            Ref_Numbers_Temp.RemoveAt(x);

            x = Random.Range(0, Ref_Numbers_Temp.Count - 1);
            B = Ref_Numbers_Temp[x];
            Ref_Numbers_Temp.RemoveAt(x);

            F = A * B;
            Ref_Numbers_Temp.Add(F);
        }

        Target_Number = Ref_Numbers_Temp[0];
    }

    void Tutorial_Lv2()
    {
        for (int i = 1; i <= Difficulty - 1; i++)
        {
            int A; int B; int F;

            int x = Random.Range(0, Ref_Numbers_Temp.Count - 1);
            A = Ref_Numbers_Temp[x];
            Ref_Numbers_Temp.RemoveAt(x);

            x = Random.Range(0, Ref_Numbers_Temp.Count - 1);
            B = Ref_Numbers_Temp[x];
            Ref_Numbers_Temp.RemoveAt(x);
            
            F = A + B;
            Ref_Numbers_Temp.Add(F);
            
        }

        Target_Number = Ref_Numbers_Temp[0];
    }
}
