using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UptoSecondFloor : SceneChange {

	// Use this for initialization
	void Start () {
        changeSceneName = "SecondFloor";
	}

    private void FixedUpdate()
    {
        if (player.getKey && player.getKnife)
            canChangeScene = true;
    }

    // Update is called once per frame
    void Update () {
		
	}
}

