using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitOffice : SceneChange {

	// Use this for initialization
	void Start () {
        changeSceneName = "FirstFloor";
    }

    private void FixedUpdate()
    {
        if (player.getKey && player.getKnife)
            canChangeScene = true;
    }

}
