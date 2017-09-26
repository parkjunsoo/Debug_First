using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingSceneManager : MonoBehaviour {

    AudioSource scream;

	// Use this for initialization
	void Start () {
        scream = GetComponent<AudioSource>();
        scream.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
