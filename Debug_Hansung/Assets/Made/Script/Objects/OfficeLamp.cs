using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeLamp : MonoBehaviour {

    Light[] lights;

	// Use this for initialization
	void Start () {
        lights = GetComponentsInChildren<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BlackOut()
    {
        foreach (Light light in lights)
        {
            light.enabled = false;
        }
    }
}
