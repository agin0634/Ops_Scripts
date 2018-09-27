using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMoveBlock : MonoBehaviour {

    public GameObject BlockPrefab;
    public BlockManager BM;
    public MainGameManager GameManager;
    private bool SpawnDone = false;
    public TargetNumber TN;
    public int BlockCount;

    // Use this for initialization
    void Start () {
        if (GameManager)
        {
            TN = GameManager.GetComponent<TargetNumber>();
            BlockCount = GameManager.GameDifficulty;

            for(int i = 0; i < BlockCount; i++)
            {
                Instantiate(BlockPrefab, BM.Block_Movable[i].transform.position, BM.Block_Movable[i].transform.rotation);
            }

            SpawnDone = true;
        }
	}

    void Update()
    {
        if (SpawnDone)
        {
            GiveBlockNumber();
            SpawnDone = false;
        }
    }

    void GiveBlockNumber()
    {
        GameObject[] AllBlock_M = GameObject.FindGameObjectsWithTag("Block_M");

        for(int i = 0; i <= AllBlock_M.Length-1; i++)
        {
            //int j = TN.Ref_Numbers[i];
            AllBlock_M[i].GetComponent<TextWithBlock>().BlockNumber = TN.Ref_Numbers[i];
        }
    }
}
