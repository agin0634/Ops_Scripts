using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSound : MonoBehaviour {

    public AudioClip sound;

    private Toggle toggle  { get { return GetComponent<Toggle>(); } }
    private AudioSource aS { get { return GetComponent<AudioSource>(); } }
    private SFXPlayer sfx;
    
    void Start ()
    {
        sfx = FindObjectOfType<SFXPlayer>();
        gameObject.AddComponent<AudioSource>();
        aS.clip = sound;
        aS.playOnAwake = false;
        aS.volume = sfx.SFX_Volume;
        toggle.onValueChanged.AddListener(delegate { PlaySound(); });
    }

    void PlaySound()
    {
        aS.PlayOneShot(sound);
        aS.volume = sfx.SFX_Volume;
    }
}
