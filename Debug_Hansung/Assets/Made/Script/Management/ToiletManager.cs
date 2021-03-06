﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletManager : StageManager {

    float time;
    public GameObject LampGroup;
    bool isFadein;
    //1.8,-0.2,-1.3
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        SetPlayerTransform("InitPosition");
        player.GetComponent<PlayerControl>().sceneName = "Toilet";
        player.GetComponent<PlayerControl>().isPaused = true;
        player.GetComponent<AudioSource>().volume = 0.2f;
        LampGroup.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time >= 8.0f && !isFadein)
        {
            LampGroup.SetActive(true);
            Camera.main.GetComponent<OVRScreenFade>().StartFadeIn();
            player.GetComponent<PlayerControl>().isPaused = false;
            player.GetComponent<PlayerControl>().isGameBegin = true;
            isFadein = true;
        }
	}
}
