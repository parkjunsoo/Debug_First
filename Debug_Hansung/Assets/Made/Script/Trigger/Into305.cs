using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Into305 : SceneChange {

	// Use this for initialization
	void Start () {
        changeSceneName = "305";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.name.Contains("Player"))
            if (other.GetComponent<PlayerControl>().GetMsgCount() == 3)
                canChangeScene = true;
    }
}
