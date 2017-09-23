using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletOutSubtitle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Player"))
        {
            if (other.GetComponent<PlayerControl>().GetMsgCount() == 1)
                GameObject.Find("SubTitle").GetComponent<Subtitle>().Printing("남자친구가 사라졌다. 1층을 수색해보자");
        }
    }
}
