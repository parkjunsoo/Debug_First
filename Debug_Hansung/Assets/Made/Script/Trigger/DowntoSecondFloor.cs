using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DowntoSecondFloor : SceneChange {

	// Use this for initialization
	void Start () {
        changeSceneName = "SecondFloor";
	}

    private void FixedUpdate()
    {
        if (player.GetMsgCount() == 2)
            canChangeScene = true;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
