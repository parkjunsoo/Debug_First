using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour {

    FadeManager fade;
    PlayerControl player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerControl>();
        fade = GameObject.Find("FadeManager").GetComponent<FadeManager>();
        StartCoroutine(Intro());
        player.isPaused = true;
        //SceneManager.LoadScene("FirstFloor");
	}
	
	// Update is called once per frame
	void Update () {
        //Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
	}

    IEnumerator Intro()
    {
        yield return new WaitForSeconds(2f);
        fade.Fade(true, 2f);
        yield return new WaitForSeconds(2f);
        player.isPaused = false;
        SceneManager.LoadScene("BeforeStartScene");
    }
}
