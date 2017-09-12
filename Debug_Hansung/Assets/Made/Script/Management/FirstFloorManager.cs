using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFloorManager : MonoBehaviour {

    PlayerControl playerControl;
    GameObject InitGameCollider;

	// Use this for initialization
	void Start () {
        InitGameCollider = GameObject.Find("InitGameCollider");         //게임이 시작되었을 때, 시작 위치 뒤쪽에 있는 collider를 저장
        playerControl = GameObject.Find("Player").GetComponent<PlayerControl>();

        if (playerControl.GetMsgCount() == 1)        //화장실에 들어갔다 나왔을 경우(쪽지를 1개 획득했을 경우), InitGameCollider를 제거
            Destroy(InitGameCollider);        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
