using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeManager : StageManager {
    
    private void Start()
    {
        Camera.main.GetComponent<OVRScreenFade>().StartFadeIn();
        SetPlayerTransform("OfficeInitPosition");
        GameObject.Find("Player").GetComponent<PlayerControl>().sceneName = "Office";
    }

    // Update is called once per frame
    void Update () {
		
	}
}
