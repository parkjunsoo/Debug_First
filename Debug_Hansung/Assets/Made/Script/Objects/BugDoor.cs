using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugDoor : MonoBehaviour {

    cakeslice.Outline outline;
    GameObject doorLock;

	// Use this for initialization
	void Start () {
        outline = GetComponent<cakeslice.Outline>();
        outline.enabled = false;
        doorLock = GameObject.Find("DoorLock");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Player"))
            outline.enabled = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.name.Contains("Player") && Input.GetKeyDown(KeyCode.Q))
        {
            doorLock.GetComponent<DoorLock>().Enable();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("Player"))
            outline.enabled = false;
    }
}
