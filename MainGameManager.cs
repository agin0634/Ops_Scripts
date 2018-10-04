using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour {

    public int GameDifficulty = 4;
    public GameManager instance;
    public TargetNumber tN;

    private BlockHolder[] bH;
    public List<BlockHolder> bH_Calculate;
    private MoveBlock[] mB;
    public List<MoveBlock> mB_F;
    
    public bool bIsDone = false;
    public bool bIsHitTarget = false;
    public bool bIsAllBlockUsed = false;
    public bool TimeStop = true;
    public bool bWin = false;

    void Awake()
    {
        instance = FindObjectOfType<GameManager>();
        if (instance)
        {
            GameDifficulty = instance.Difficulty;
        }
    }
    
	void Start ()
    {
        if (!tN)
        {
            tN = gameObject.GetComponent<TargetNumber>();
        }
    }

    void Update()
    {
        // Get all Block Holder and pick the tag is Block_Holder
        // Get all Move Block and pick the tag is Block_F
        if (!bIsDone)
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
                if(mB[j].transform.gameObject.tag == "Block_F")
                {
                    mB_F.Add(mB[j]);
                }
            }

            bIsDone = true;
        }

        // Check the block is or isn't using
        if (bIsDone)
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

            // Check Win
            if (bIsAllBlockUsed && bIsHitTarget)
            {
                TimeStop = true;
                bWin = true;
            }
        }
        
    }
}
