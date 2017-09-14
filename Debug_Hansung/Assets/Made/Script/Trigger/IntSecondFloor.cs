﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntoSecondFloor : SceneChange {

	// Use this for initialization
	void Start () {
        changeSceneName = "SecondFloor";
	}

    private void FixedUpdate()
    {
        if (player.getKey && player.getKnife)
            canChangeScene = true;
    }

}
