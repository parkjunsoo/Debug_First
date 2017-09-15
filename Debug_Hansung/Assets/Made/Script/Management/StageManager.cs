using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Awake () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected void SetPlayerTransform(string obj)
    {
        player.transform.position = GameObject.Find(obj).transform.position;
        player.transform.rotation = GameObject.Find(obj).transform.rotation;
    }
}
