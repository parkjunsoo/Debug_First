using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderLight : MonoBehaviour {

    Light thunder;
    float thunderIntensity = 50f;

	// Use this for initialization
	void Awake () {
        thunder = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Thunder()
    {
        StartCoroutine(Thundering());
    }

    IEnumerator Thundering()
    {
        thunder.intensity = thunderIntensity;
        yield return new WaitForSeconds(0.5f);
        thunder.intensity = 0f;
    }
}
