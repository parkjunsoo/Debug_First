using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEDControl : MonoBehaviour {

    public GameObject InnerLED;
    public GameObject OuterLED;

    float inner = 0.7f;
    float outer = 1.0f;

    float innerIntensity;
    float outerIntensity;

	// Use this for initialization
	void Start () {
        InnerLED = GameObject.Find("InnerLED");
        OuterLED = GameObject.Find("OuterLED");

        innerIntensity = inner;
        outerIntensity = outer;

        InnerLED.GetComponent<Light>().intensity = innerIntensity;
        OuterLED.GetComponent<Light>().intensity = outerIntensity;
	}
	
	// Update is called once per frame
	void Update () {

	}
    
    IEnumerator LowBattery()
    {
        for(int i = 0; i < 5; i++)
        {

        }
    }

}
