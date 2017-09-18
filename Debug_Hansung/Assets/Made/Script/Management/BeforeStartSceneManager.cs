using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeStartSceneManager : MonoBehaviour {

    GameObject player;
    float time;
    float fadeTime;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        player.transform.position = new Vector3(0f, 0f, 0f);
        player.GetComponent<PlayerControl>().isPaused = true;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        player.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        if (Input.GetKeyDown(KeyCode.T))
        {
            fadeTime = time;
            GameObject.Find("FadeManager").GetComponent<FadeManager>().Fade(true, 1.25f);
        }

        if (time - fadeTime >= 1.25f && fadeTime != 0)
        {
            player.GetComponent<PlayerControl>().isPaused = false;
            UnityEngine.SceneManagement.SceneManager.LoadScene("FirstFloor");
        }
    }
}
