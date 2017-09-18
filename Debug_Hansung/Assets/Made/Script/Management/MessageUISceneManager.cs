using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MessageUISceneManager : MonoBehaviour {

    PlayerControl player;
    float sceneTime;
    float fadeTime;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerControl>();
        player.fadeTime = 0f;
        if (!player.isPaused)
            player.isPaused = true;
	}

    // Update is called once per frame
    void Update()
    {
        sceneTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            fadeTime = sceneTime;
            GameObject.Find("FadeManager").GetComponent<FadeManager>().Fade(true, 1.25f);
        }
        if(sceneTime - fadeTime >= 1.25f && fadeTime != 0)
            SceneManager.LoadScene(player.sceneName);               //저장해 두었던 Scene으로 다시 이동        
        
    }
}
