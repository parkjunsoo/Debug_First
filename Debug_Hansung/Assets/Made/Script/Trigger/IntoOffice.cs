using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntoOffice : SceneChange {

	// Use this for initialization
	void Start () {
        changeSceneName = "Office";
        if (player.GetMsgCount() > 0)
            canChangeScene = true;
        //startPos = "OfficeInitPosition";
	}
    
}
