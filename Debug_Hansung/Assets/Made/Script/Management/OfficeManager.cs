using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeManager : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Awake () {
        player = GameObject.Find("Player");
        player.transform.position = GameObject.Find("OfficeInitPosition").transform.position;
    }

    private void Start()
    {
        player.transform.position = GameObject.Find("OfficeInitPosition").transform.position;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
