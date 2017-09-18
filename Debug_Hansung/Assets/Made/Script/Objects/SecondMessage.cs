using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondMessage : Message {

	// Use this for initialization
	void Start () {
        if (GameObject.Find("Player").GetComponent<PlayerControl>().getBattery == false)
            GetComponent<MeshRenderer>().enabled = false;
        GetComponent<cakeslice.Outline>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
