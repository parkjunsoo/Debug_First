using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour {

    FadeManager fade;
    PlayerControl player;
    float time;
    bool change;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerControl>();
        fade = GameObject.Find("FadeManager").GetComponent<FadeManager>();
        //Camera.main.GetComponent<OVRScreenFade>().StartFadeIn();
        StartCoroutine(IntroFirst());
        player.isPaused = true;
        //SceneManager.LoadScene("FirstFloor");
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if (time > 4f && !change)
        {
            change = true;
            StartCoroutine(IntroSecond());
        }
        //Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        //if (Input.GetKeyDown(KeyCode.Q))
        //    StartCoroutine(IntroSecond());
	}

    IEnumerator IntroFirst()
    {
        Camera.main.GetComponent<OVRScreenFade>().StartFadeIn();
        yield return new WaitForSeconds(2f);
        //fade.Fade(true, 2f);
        Debug.Log("Waited");
    }
    IEnumerator IntroSecond()
    { 
        Camera.main.GetComponent<OVRScreenFade>().StartFadeOut();
        yield return new WaitForSeconds(2f);
        player.isPaused = false;
        SceneManager.LoadScene("BeforeStartScene");
        yield return null;
    }
    
}
