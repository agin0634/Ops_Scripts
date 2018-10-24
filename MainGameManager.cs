using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class MainGameManager : MonoBehaviour {

    public int GameDifficulty = 4;
    public GameManager instance;
    public AdmodManager admodManager;
    public TargetNumber tN { get { return GetComponent<TargetNumber>(); } }

    private BlockHolder[] bH;
    public List<BlockHolder> bH_Calculate;
    private MoveBlock[] mB;
    public List<MoveBlock> mB_F;
    
    public bool bIsDone = false;
    public bool bIsHitTarget = false;
    public bool bIsAllBlockUsed = false;
    public bool TimeStop = true;
    public bool bWin = false;
    public bool bChallengeWin = false;
    public bool bTutoialWin = false;
    public bool bIsNewBest = false;
    
    void Awake()
    {
        instance = FindObjectOfType<GameManager>();
        admodManager = FindObjectOfType<AdmodManager>();
        if (instance)
        {
            GameDifficulty = instance.Difficulty;
        }
    }
    
	void Start ()
    {
        admodManager.HideBanner();
    }

    void Update()
    {
        // Get all Block Holder and pick the tag is Block_Holder
        // Get all Move Block and pick the tag is Block_F
        if (!bIsDone)
        {
            GetBlock();
        }
        
        // Check the block is or isn't using
        if (bIsDone)
        {
            // Check Win
            if(!bWin)
            {
                CheckBlock();
            }
            
            if (instance.GameMode == 0)
            {
                // Challenge Mode
                if (bIsAllBlockUsed && bIsHitTarget)
                {
                    bIsAllBlockUsed = false;
                    bIsHitTarget = false;
                    TimeStop = true;
                    instance.CurrentTime = FindObjectOfType<Timer>().timer_f;

                    if (instance.Difficulty == 10)
                    {
                        bWin = true;
                        bChallengeWin = true;
                        ResetChallengeData();
                    }
                    else
                    {
                        bWin = true;
                        instance.CurrentLevel++;
                        instance.Difficulty++;
                    }
                }
            }
            else if(instance.GameMode == 1)
            {
                // Training Mode
                if (bIsAllBlockUsed && bIsHitTarget)
                {
                    bIsAllBlockUsed = false;
                    bIsHitTarget = false;
                    TimeStop = true;
                    bWin = true;
                }
            }
            else if (instance.GameMode == 2)
            {
                // Tutorial Mode
                if(bIsAllBlockUsed && bIsHitTarget)
                {
                    // TODO Win
                    bIsAllBlockUsed = false;
                    bIsHitTarget = false;
                    TimeStop = true;

                    if (instance.Difficulty == 4)
                    {
                        bWin = true;
                        bTutoialWin = true;
                    }
                    else
                    {
                        bWin = true;
                        instance.Difficulty = 4;
                    }
                }
            }
        }
    }

    void GetBlock()
    {
        bH = FindObjectsOfType<BlockHolder>();
        mB = FindObjectsOfType<MoveBlock>();

        for (int i = 0; i <= bH.Length - 1; i++)
        {
            if (bH[i].transform.gameObject.tag == "Block_Holder")
            {
                bH_Calculate.Add(bH[i]);
            }
        }

        for (int j = 0; j <= mB.Length - 1; j++)
        {
            if (mB[j].transform.gameObject.tag == "Block_F")
            {
                mB_F.Add(mB[j]);
            }
        }

        bIsDone = true;
    }

    void CheckBlock()
    {
        for (int i = 0; i <= bH_Calculate.Count - 1; i++)
        {
            if (bH_Calculate[i].CurrentBlockNumber <= 0)
            {
                bIsAllBlockUsed = false;
                break;
            }
            else
            {
                bIsAllBlockUsed = true;
            }
        }

        for (int j = 0; j <= mB_F.Count - 1; j++)
        {
            if (mB_F[j].GetComponent<TextWithBlock>().BlockNumber == tN.Target_Number)
            {
                if (!mB_F[j].GetComponent<MoveBlock>().bBlockIsHold)
                {
                    bIsHitTarget = true;
                    break;
                }
            }
            else
            {
                bIsHitTarget = false;
            }
        }
    }

    public void ResetChallengeData()
    {
        instance.Difficulty = 4;
        instance.CurrentLevel = 1;
        instance.CurrentTime = 0f;
    }

    void OnApplicationQuit()
    {
        if(instance.GameMode == 0)
        {
            // TODO Save
            instance.SaveGame();
            Debug.Log("Save!!!");
        }
    }
}
