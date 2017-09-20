using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {
    
    float time;
    float enterTime;
    FadeManager fade;
    protected PlayerControl player;
    protected string changeSceneName;                  //바꿔줄 씬의 이름을 저장. 상속받은 각 Trigger 스크립트에서 설정할 것.
    //protected string startPos;                         //로드될 씬에서 player의 시작 위치를 저장. 상속받은 각 Trigger 스크립트에서 설정할 것.
    public bool canChangeScene;

	// Use this for initialization
	void Awake () {
        player = GameObject.Find("Player").GetComponent<PlayerControl>();
        fade = GameObject.Find("FadeManager").GetComponent<FadeManager>();
        time = 0f;
        enterTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {                        //상속받은 각 Trigger 스크립트에 Update를 없애야 돌아감.
        time += Time.deltaTime;
        if (time - enterTime >= 1.25f && enterTime != 0)
        {
            SceneManager.LoadScene(changeSceneName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canChangeScene)
        {
            enterTime = time;
            fade.Fade(true, 1.25f);
        }
        //player.SetStartPosition(startPos);
    }    
    
    public void CanChangeScene()
    {
        canChangeScene = true;
    }
}
