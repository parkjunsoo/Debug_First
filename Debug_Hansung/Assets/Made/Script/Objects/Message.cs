using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start () {
        GetComponent<cakeslice.Outline>().enabled = false;
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Player"))
        {
            GetComponent<cakeslice.Outline>().enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            player.GetComponent<PlayerControl>().AddCount();
            GameObject.Find("ExitToilet").GetComponent<ExitToilet>().canChangeScene = true;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("Player"))
            GetComponent<cakeslice.Outline>().enabled = false;
    }
}
