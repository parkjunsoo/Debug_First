using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondMessage : Message {

	// Use this for initialization
	void Start () {
        if (GameObject.Find("Player").GetComponent<PlayerControl>().getBattery == false)
            GetComponent<MeshRenderer>().enabled = false;
        GetComponent<cakeslice.Outline>().enabled = false;
        subTitle = "또 쪽지네.. 일단 잠겼으니 빨리 3층으로 돌아서 나가자";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
}
