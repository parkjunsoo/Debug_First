using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UptoThirdFloor : SceneChange {

	// Use this for initialization
	void Start () {
		changeSceneName = "ThirdFloor";
	}
		
	private void FixedUpdate()
	{
		if (player.GetMsgCount() ==2) //1층 로비에서 두번째 쪽지 획득시 3층 콜리더 해제 
			canChangeScene = true;
	}
		
}

