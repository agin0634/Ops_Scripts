using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetNumber : MonoBehaviour {

    private CalculationMethod cm;
    private int[] NumberPool = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public int Difficulty = 4;
    public List<int> Ref_Numbers;

    // Draw balls from the pool, according to Difficulty
    public void DrawBall()
    {
        for(int i = 1; i <= Difficulty; i++)
        {
            int x = Random.Range(0, NumberPool.Length-1);
            int Number_Drawn = NumberPool[x];
            Ref_Numbers.Add(Number_Drawn);
            
            Debug.Log(Ref_Numbers[i-1]);
        }
    }

    public void CalculateTargetNumber()
    {
        for(int i = 1;i <= Difficulty - 1; i++)
        {
            int A; int B; int F;

            int x = Random.Range(0, Ref_Numbers.Count - 1);
            A = Ref_Numbers[x];
            Ref_Numbers.RemoveAt(x);
            Debug.Log(A);

            x = Random.Range(0, Ref_Numbers.Count - 1);
            B = Ref_Numbers[x];
            Ref_Numbers.RemoveAt(x);
            Debug.Log(B);

            if (A != B)
            {
                if (A % B == 0)
                {
                    Debug.Log("**A / B");
                    F = A / B;
                    Ref_Numbers.Add(F);
                }
                else if (A > B)
                {
                    Debug.Log("**A - B");
                    F = A - B;
                    Ref_Numbers.Add(F);
                }
                else if (A + B <= 10)
                {
                    Debug.Log("**A * B");
                    F = A * B;
                    Ref_Numbers.Add(F);
                }
                else
                {
                    Debug.Log("**A + B");
                    F = A + B;
                    Ref_Numbers.Add(F);
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
                        Ref_Numbers.Add(F);
                    }
                    else if (y == 2)
                    {
                        Debug.Log("**A * B");
                        F = A * B;
                        Ref_Numbers.Add(F);
                    }
                    else
                    {
                        Debug.Log("**A / B");
                        F = A / B;
                        Ref_Numbers.Add(F);
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
                        Ref_Numbers.Add(F);
                    }
                    else if (y == 2)
                    {
                        Debug.Log("**A * B");
                        F = A * B;
                        Ref_Numbers.Add(F);
                    }
                    else
                    {
                        Debug.Log("**A / B");
                        F = A / B;
                        Ref_Numbers.Add(F);
                    }
                }
            }
        }
        
    }



    // Use this for initialization
    void Start () {
        DrawBall();
        CalculateTargetNumber();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
