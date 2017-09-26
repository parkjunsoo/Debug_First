using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceTrigger : MonoBehaviour {

    AudioSource voice;
    bool isPlayed;

	// Use this for initialization
	void Start () {
        voice = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("Player") && !isPlayed)
        {
            voice.Play();
            isPlayed = true;
        }
    }
}
