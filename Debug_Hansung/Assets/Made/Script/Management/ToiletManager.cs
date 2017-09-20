using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletManager : StageManager {
    
    // Use this for initialization
    void Start () {
        SetPlayerTransform("InitPosition");
        GameObject.Find("Player").GetComponent<PlayerControl>().sceneName = "Toilet";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
