﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitToilet : SceneChange {

	// Use this for initialization
	void Start () {
        changeSceneName = "FirstFloor";
	}

    private void FixedUpdate()
    {
        if (player.GetMsgCount() == 1)
            canChangeScene = true;
    }

}