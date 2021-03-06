﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickSound : MonoBehaviour {

    public AudioClip sound;

    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource aS { get { return GetComponent<AudioSource>(); } }
    private SFXPlayer sfx;

    void Start ()
    {
        sfx = FindObjectOfType<SFXPlayer>();
        gameObject.AddComponent<AudioSource>();
        aS.clip = sound;
        aS.playOnAwake = false;
        aS.volume = sfx.SFX_Volume;
        button.onClick.AddListener(() => PlaySound());
	}
	
	void PlaySound()
    {
        aS.volume = sfx.SFX_Volume;
        aS.PlayOneShot(sound);
    }
}
