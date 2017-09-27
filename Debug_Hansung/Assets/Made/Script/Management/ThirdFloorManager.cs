using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdFloorManager : StageManager {

	// Use this for initialization
	void Start () {
        SetPlayerTransform("InitPosition");
        Camera.main.GetComponent<OVRScreenFade>().StartFadeIn();
        player.GetComponent<PlayerControl>().sceneName = "ThirdFloor";

        if (player.GetComponent<PlayerControl>().GetMsgCount() >= 4)
            GameObject.Find("LastMessage").GetComponent<LastMessage>().Enable();
        //Debug.Log(player.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
