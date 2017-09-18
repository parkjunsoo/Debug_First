using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdFloorManager : StageManager {

	// Use this for initialization
	void Start () {
        SetPlayerTransform("InitPosition");

        GameObject.Find("Player").GetComponent<PlayerControl>().sceneName = "ThirdFloor";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
