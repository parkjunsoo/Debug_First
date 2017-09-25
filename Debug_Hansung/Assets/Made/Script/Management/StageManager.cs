using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Awake () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected void SetPlayerTransform(string obj)
    {
        if (player.GetComponent<PlayerControl>().messageUIOpened)
        {
            player.transform.position = GameObject.Find("MsgUIOut").transform.position;
            Debug.Log(GameObject.Find("MsgUIOut").transform.position);
            player.GetComponent<PlayerControl>().messageUIOpened = false;
        }
        else
        {
            player.transform.position = GameObject.Find(obj).transform.position;
            player.transform.rotation = GameObject.Find(obj).transform.rotation;
        }
    }
}
