﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToiletFadeManager : MonoBehaviour
{

    public static ToiletFadeManager Instance { set; get; }

    public Image fadeImage;
    private bool isInTransition;
    private float transition;
    private bool isShowing;
    private float duration;

    float time;

    GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
        StartCoroutine(Init());
        Instance = this;
    }

    public void Fade(bool showing, float duration)                  //true일 경우 어두워짐, false일 경우 밝아짐, duration = 어두워지는(밝아지는)데 걸리는 시간
    {
        isShowing = showing;
        isInTransition = true;
        this.duration = duration;
        transition = (isShowing) ? 0 : 1;

    }

    // Use this for initialization
    void Start()
    {
        player.GetComponent<PlayerControl>().isPaused = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (!isInTransition)
            return;

        transition += (isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
        fadeImage.color = Color.Lerp(new Color(1, 1, 1, 0), Color.black, transition);

        if (transition > 1 || transition < 0)
            isInTransition = false;

        time += Time.deltaTime;
    }
    IEnumerator Init()
    {
        Fade(true, 0f);
        Debug.Log("paused");
        yield return new WaitForSeconds(8.0f);
        Fade(false, 1.0f);
        player.GetComponent<PlayerControl>().isPaused = false;
        Debug.Log("start");
        yield return null;
    }

}
