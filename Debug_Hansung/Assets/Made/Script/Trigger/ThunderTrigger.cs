using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderTrigger : MonoBehaviour {

    PlayerControl player;
    public GameObject thunder;
    OfficeLamp[] ofLamp;
    AudioSource thunderSound;
    bool isThundered;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerControl>();
        thunder = GameObject.Find("ThunderLight");
        ofLamp = GameObject.Find("LampGroup").GetComponentsInChildren<OfficeLamp>();
        thunderSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (!isThundered)
        {
            //thunder.GetComponent<ThunderLight>().Thunder();
            //player.getKey = true;
            //player.getKnife = true;
            if (player.getKey && player.getKnife)
            {
                thunder.GetComponent<ThunderLight>().Thunder();
                player.GetComponent<PlayerControl>().blackOut = true;
                foreach (OfficeLamp lamp in ofLamp)
                {
                    lamp.BlackOut();
                }
                thunderSound.Play();
                isThundered = true;
            }
        }
    }
}
