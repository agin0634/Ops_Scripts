using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LicenseLink : MonoBehaviour {

    private Button button { get { return GetComponent<Button>(); } }

    void Start ()
    {
        button.onClick.AddListener(() => OpenLink());
    }
	
    void OpenLink()
    {
        Application.OpenURL("https://creativecommons.org/licenses/by-sa/4.0/");
    }

}
