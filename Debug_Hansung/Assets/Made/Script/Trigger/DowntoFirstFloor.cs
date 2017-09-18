using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DowntoFirstFloor : SceneChange {

	// Use this for initialization
	void Start () {
		changeSceneName = "FirstFloor";
	}

	private void FixedUpdate()
	{
		if (player.getBattery)
			canChangeScene = true;
	}
}
