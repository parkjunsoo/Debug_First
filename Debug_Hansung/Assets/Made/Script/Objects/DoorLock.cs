using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour {

    GameObject numberPad;
    GameObject player;
    GameObject cursor;
    public bool canOpen;
    cakeslice.Outline outline;

	// Use this for initialization
	void Start () {
        outline = GetComponent<cakeslice.Outline>();
        cursor = GameObject.Find("Cursor");
        player = GameObject.Find("Player");
        numberPad = GameObject.Find("NumberPad");
        /*
        numberPad.GetComponent<MeshRenderer>().enabled = false;
        foreach (MeshRenderer mesh in numberPad.GetComponentsInChildren<MeshRenderer>())
            mesh.enabled = false;
        */
        outline.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("Player"))
            outline.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("Player"))
            outline.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && other.name.Contains("Player"))
        {
            cursor.GetComponent<cakeslice.Outline>().enabled = true;
            Enable();
        }
    }

    public void Enable()
    {
        player.GetComponent<PlayerControl>().isPaused = true;
        numberPad.GetComponent<NumberPad>().isEnabled = true;
        numberPad.GetComponent<MeshRenderer>().enabled = true;
        foreach (MeshRenderer mesh in GetComponentsInChildren<MeshRenderer>())
            mesh.enabled = true;
    }

    public void Disable()
    {
        cursor.GetComponent<cakeslice.Outline>().enabled = false;
        cursor.transform.position = new Vector3(0f, 0f, 0f);
        player.GetComponent<PlayerControl>().isPaused = false;
        numberPad.GetComponent<MeshRenderer>().enabled = false;
        numberPad.GetComponent<NumberPad>().isEnabled = false;
        foreach (MeshRenderer mesh in GetComponentsInChildren<MeshRenderer>())
            mesh.enabled = false;
        GetComponent<MeshRenderer>().enabled = true;
    }
}
