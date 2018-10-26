using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    public int GameMode;
    public int Difficulty = 4;
    public int Calulation_Diff = 0;
    public int CurrentLevel = 1;
    public float CurrentTime = 0f;
        
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

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");

        SaveGame Save = new SaveGame();
        Save.Level = CurrentLevel;
        Save.Timer = CurrentTime;
        Save.Difficulty = Difficulty;
        Save.Calculation_Diff = Calulation_Diff;

        Save.SaveExist = true;

        bf.Serialize(file, Save);
        file.Close();
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            SaveGame Save = (SaveGame)bf.Deserialize(file);
            file.Close();
            
            CurrentLevel = Save.Level;
            CurrentTime = Save.Timer;
            Difficulty = Save.Difficulty;
            Calulation_Diff = Save.Calculation_Diff;
        }
        else
        {
            Debug.Log("No game saved!");
        }
    }

    public void DeleteFile()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            File.Delete(Application.persistentDataPath + "/gamesave.save");

            //UnityEditor.AssetDatabase.Refresh();
        }
        else
        {
            Debug.Log("No game Delete!");
        }
    }

    public bool CheckSaveFile()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
