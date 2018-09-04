using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetNumber : MonoBehaviour {

    private CalculationMethod cm;
    private int[] NumberPool = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public int Difficulty = 4;
    public List<int> Ref_Numbers;

    void DrawBall()
    {
        for(int i = 1; i <= Difficulty; i++)
        {
            int x = Random.Range(0, NumberPool.Length-1);
            int Number_Drawn = NumberPool[x];
            Ref_Numbers.Add(Number_Drawn);
            
            Debug.Log(Ref_Numbers[i-1]);
        }
    }

	// Use this for initialization
	void Start () {
        DrawBall();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
