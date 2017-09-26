using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastMessage : Message {

	// Use this for initialization
	void Start () {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<cakeslice.Outline>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        subTitle = "적당히좀 하지.. 짜증나";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Enable()
    {
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<cakeslice.Outline>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name.Contains("Player") && Input.GetKeyDown(KeyCode.Q))
        {
            other.GetComponent<PlayerControl>().AddCount();
            GetMsg(subTitle);
            GameObject.Find("DoorLock").GetComponent<BoxCollider>().enabled = true;
            Destroy(this.gameObject);
        }
    }

}
