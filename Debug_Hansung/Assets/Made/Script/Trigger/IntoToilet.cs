using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntoToilet : SceneChange {

	// Use this for initialization
	void Start () {
        changeSceneName = "Toilet";
        if(player.GetComponent<PlayerControl>().GetMsgCount() < 1)
            canChangeScene = true;
        //startPos = "ToiletInitPosition";
	}
}
