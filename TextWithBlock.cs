using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWithBlock : MonoBehaviour {

    public Text NumberText;
    public int BlockNumber = 0;

	// Update is called once per frame
	void Update () {
        Vector3 NumberPosition = Camera.main.WorldToScreenPoint(this.transform.position);
        NumberText.transform.position = NumberPosition;

        if (BlockNumber < 0)
        {
            NumberText.text = "N/A";
            return;
        }
        else if (BlockNumber != 0)
        {
            NumberText.text = BlockNumber.ToString();
            return;
        }
    }
}
