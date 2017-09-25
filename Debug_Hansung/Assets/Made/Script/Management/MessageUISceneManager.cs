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
        Camera.main.GetComponent<OVRScreenFade>().StartFadeIn();
        player = GameObject.Find("Player").GetComponent<PlayerControl>();
        //Debug.Log(player.sceneTransform.position);
        player.messageUIOpened = true;
        player.transform.position = new Vector3(0f, 1.5f, 0f);
        player.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
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
            Camera.main.GetComponent<OVRScreenFade>().StartFadeOut();
            GameObject.Find("FadeManager").GetComponent<FadeManager>().Fade(true, 1.25f);
        }
        if(sceneTime - fadeTime >= 1.25f && fadeTime != 0) {
            if(player.GetComponent<PlayerControl>().isPaused)
                player.GetComponent<PlayerControl>().isPaused = false;
            SceneManager.LoadScene(player.sceneName);               //저장해 두었던 Scene으로 다시 이동        
        }
        
    }
}
