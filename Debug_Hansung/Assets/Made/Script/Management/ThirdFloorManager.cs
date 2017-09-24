using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdFloorManager : StageManager {

	// Use this for initialization
	void Start () {
        SetPlayerTransform("InitPosition");
        Camera.main.GetComponent<OVRScreenFade>().StartFadeIn();
        GameObject.Find("Player").GetComponent<PlayerControl>().sceneName = "ThirdFloor";
        Debug.Log(player.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
