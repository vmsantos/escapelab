using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenu : MonoBehaviour {

	public AudioClip meuAudioClip;
    public AudioSource meuAudioSource;
	// Use this for initialization
	void Start () {
		meuAudioSource.clip = meuAudioClip;
        meuAudioSource.Play();
	}

}
