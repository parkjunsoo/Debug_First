using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	GameObject radio;

	public AudioSource a; 

	void Awake () {
		radio = GameObject.Find ("radio");
		a = radio.GetComponent<AudioSource> ();

		a.volume = 0.2f;
	}

	private void OnTriggerEnter(Collider other){
		if (other.name.Contains ("Player")) {
			a.volume = 0.4f;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		
	}

	private void OnTriggerExit(Collider other){
	}
		
}
