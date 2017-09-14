using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderTrigger : MonoBehaviour {

    PlayerControl player;
    public GameObject thunder;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerControl>();
        thunder = GameObject.Find("ThunderLight");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //thunder.GetComponent<ThunderLight>().Thunder();
        //player.getKey = true;
        //player.getKnife = true;
        if (player.getKey && player.getKnife)
        {
            thunder.GetComponent<ThunderLight>().Thunder();
        }
    }
}
