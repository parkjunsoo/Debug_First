using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondFloorManager : StageManager {
	GameObject DownToFirstFloor;
	GameObject UpToThirdFloor;
	GameObject player;
	PlayerControl playerControl;

	// Use this for initialization
	void Start () {
		DownToFirstFloor = GameObject.Find ("DownToFirstFloor");
		UpToThirdFloor = GameObject.Find ("UpToThirdFloor");
		player = GameObject.Find ("Player");
		playerControl = player.GetComponent<PlayerControl> ();
        Camera.main.GetComponent<OVRScreenFade>().StartFadeIn();

		if (!playerControl.getBattery) { //2층 올라갔을때의 처음위치
			SetPlayerTransform ("SecondInitPosition");
		} 
		else if (playerControl.getBattery) {
			Destroy (DownToFirstFloor); //2층 배터리 찾으면 1층 내려감 가능
			SetPlayerTransform ("SecondInitPosition");
		}
		else if (playerControl.GetMsgCount() == 2)      //1층 로비에서 두번째 쪽지 획득시 3층 진입 가능
		{
			Destroy (DownToFirstFloor);
			Destroy(UpToThirdFloor);
			SetPlayerTransform ("SecondInitPosition");
		}
	}


}