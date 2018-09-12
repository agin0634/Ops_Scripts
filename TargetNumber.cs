using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetNumber : MonoBehaviour
{

    private CalculationMethod cm;
    private int[] NumberPool = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public int Difficulty = 4;
    public int Target_Number;
    public List<int> Ref_Numbers;
    public List<int> Ref_Numbers_Temp;

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
            
            if (A != B)
            {
                if (A % B == 0)
                {
                    Debug.Log("**A / B");
                    F = A / B;
                    Ref_Numbers_Temp.Add(F);
                }
                else if (A > B)
                {
                    Debug.Log("**A - B");
                    F = A - B;
                    Ref_Numbers_Temp.Add(F);
                }
                else if (A + B <= 10)
                {
                    Debug.Log("**A * B");
                    F = A * B;
                    Ref_Numbers_Temp.Add(F);
                }
                else
                {
                    Debug.Log("**A + B");
                    F = A + B;
                    Ref_Numbers_Temp.Add(F);
                }

            }
            else
            {
                if (A + B >= 10)
                {
                    // + * /
                    // [5,5]、[6,6]、[7,7]、[8,8]、[9,9]
                    int y = Random.Range(1, 3);
                    if (y == 1)
                    {
                        Debug.Log("**A + B");
                        F = A + B;
                        Ref_Numbers_Temp.Add(F);
                    }
                    else if (y == 2)
                    {
                        Debug.Log("**A * B");
                        F = A * B;
                        Ref_Numbers_Temp.Add(F);
                    }
                    else
                    {
                        Debug.Log("**A / B");
                        F = A / B;
                        Ref_Numbers_Temp.Add(F);
                    }
                }
                else
                {
                    // * + /
                    // [1,1]、[2,2]、[3,3]、[4,4]
                    int y = Random.Range(1, 3);
                    if (y == 1)
                    {
                        Debug.Log("**A + B");
                        F = A + B;
                        Ref_Numbers_Temp.Add(F);
                    }
                    else if (y == 2)
                    {
                        Debug.Log("**A * B");
                        F = A * B;
                        Ref_Numbers_Temp.Add(F);
                    }
                    else
                    {
                        Debug.Log("**A / B");
                        F = A / B;
                        Ref_Numbers_Temp.Add(F);
                    }
                }
            }
        }

        Target_Number = Ref_Numbers_Temp[0];
    }

    void Start () {
        if (GameManager)
        {
            Difficulty = GameManager.GameDifficulty;
        }
        DrawBall();
        CalculateTargetNumber();
	}

	void Update () {
		
	}
}
