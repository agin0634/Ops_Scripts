using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickSound : MonoBehaviour {

    public AudioClip sound;

    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource aS { get { return GetComponent<AudioSource>(); } }
    
	void Start ()
    {
        gameObject.AddComponent<AudioSource>();
        aS.clip = sound;
        aS.playOnAwake = false;
        button.onClick.AddListener(() => PlaySound());
	}
	
	void PlaySound()
    {
        aS.PlayOneShot(sound);
    }
}
