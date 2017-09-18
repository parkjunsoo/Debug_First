using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFloorManager : StageManager {

    GameObject player;
    PlayerControl playerControl;
    GameObject InitGameCollider;

	// Use this for initialization
	void Start () {
        InitGameCollider = GameObject.Find("InitGameCollider");         //게임이 시작되었을 때, 시작 위치 뒤쪽에 있는 collider를 저장
        player = GameObject.Find("Player");
        playerControl = player.GetComponent<PlayerControl>();

        playerControl.sceneName = "FirstFloor";

        if (playerControl.GetMsgCount() == 0)
            SetPlayerTransform("InitPosition");

		else if (playerControl.getKey && playerControl.getKnife && !playerControl.getBattery)
        {
            Destroy(InitGameCollider);
            SetPlayerTransform("OfficeOutPosition");
        }

		else if (playerControl.GetMsgCount() == 1 && !playerControl.getBattery)       //화장실에 들어갔다 나왔을 경우(쪽지를 1개 획득했을 경우), InitGameCollider를 제거
        {
            Destroy(InitGameCollider);
            SetPlayerTransform("ToiletOutPosition");
        }

		else if(playerControl.getBattery && playerControl.getNipper)
		{
			Destroy(InitGameCollider);
			SetPlayerTransform("SecondOutPosition");
		}

        else if(playerControl.GetMsgCount() >= 1 && playerControl.getBattery)
        {
            Destroy(InitGameCollider);
            SetPlayerTransform("DownPosition");
        }
	}

    //void SetPlayerTransform(string obj)
    //{
    //    player.transform.position = GameObject.Find(obj).transform.position;
    //    player.transform.rotation = GameObject.Find(obj).transform.rotation;
    //}
	
	// Update is called once per frame
	void Update () {
		
	}
}
