using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletManager : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        player.transform.position = GameObject.Find("InitPosition").transform.position;
        player.transform.rotation = GameObject.Find("InitPosition").transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
