using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveGame
{
    public bool SaveExist;

    public int Level;
    public float Timer;
    public int Difficulty;

    public List<int> Ref_Numbers;
    public int Target_Number;
    
}


