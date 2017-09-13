﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEDControl : MonoBehaviour {

    public Light InnerLED;
    public Light OuterLED;

    public float inner = 0.7f;
    public float outer = 1.0f;

    float innerIntensity;
    float outerIntensity;

	// Use this for initialization
	void Start () {
        InnerLED = GameObject.Find("InnerLED").GetComponent<Light>();
        OuterLED = GameObject.Find("OuterLED").GetComponent<Light>();

        innerIntensity = inner;
        outerIntensity = outer;

        InnerLED.intensity = innerIntensity;
        OuterLED.intensity = outerIntensity;

        //StartCoroutine(LowBattery());
	}
	
	// Update is called once per frame
	void Update () {

	}
    
    public void LowBatt()
    {
        StartCoroutine(LowBattery());
    }

    public IEnumerator LowBattery()
    {
        //while (InnerLED.intensity >= 0.2f)
        for(int i = 0; i < 19; i++)
        {
            //InnerLED.intensity -= Random.Range(0.05f, 0.1f);
            //OuterLED.intensity -= Random.Range(0.05f, 0.1f);
            InnerLED.intensity = 0.2f;
            OuterLED.intensity = 0.3f;
            InnerLED.enabled = !InnerLED.enabled;
            OuterLED.enabled = !OuterLED.enabled;
            yield return new WaitForSeconds(0.015f);
        }
        InnerLED.enabled = true;
        OuterLED.enabled = true;
        InnerLED.intensity = 0.2f;
        OuterLED.intensity = 0.3f;
        yield return null;
    }

}
