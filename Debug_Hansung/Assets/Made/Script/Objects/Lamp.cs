using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour {

    public Light[] lights;
    GameObject player;

	// Use this for initialization
	void Start () {
        lights = GetComponentsInChildren<Light>();
        player = GameObject.Find("Player");
        if (player.GetComponent<PlayerControl>().blackOut)
        {
            foreach(Light light in lights)
            {
                light.enabled = false;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BlackOut()
    {
        foreach (Light light in lights)
            light.enabled = false;
    }
}
