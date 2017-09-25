using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour {

    GameObject player;

	void Start () {
		GetComponent<cakeslice.Outline>().enabled = false;
        player = GameObject.Find("Player");
	}

	// Update is called once per frame
	void Update () {

	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.name.Contains("Player") && GameObject.Find("OpeningLocker").GetComponent<Locker>().opening)
		{
			GetComponent<cakeslice.Outline>().enabled = true;
		}
	}

	private void OnTriggerStay(Collider other)
	{
        if (GameObject.Find("OpeningLocker").GetComponent<Locker>().opening && other.name.Contains("Player"))
            GetComponent<cakeslice.Outline>().enabled = true;


		if (other.name.Contains("Player") && Input.GetKeyDown(KeyCode.Q))
		{
            if (GameObject.Find("OpeningLocker").GetComponent<Locker>().opening) {
                other.GetComponent<PlayerControl>().getBattery = true;                 //player.GetComponent ~~~로 했더니 잘 되다가 갑자기 에러나서 바꿈. 뭐여 씨벌
                player.GetComponent<LEDControl>().InnerLED.intensity = 0.7f;
                player.GetComponent<LEDControl>().OuterLED.intensity = 1.0f;
                Debug.Log("Destroy");
                Destroy(this.gameObject);
            }
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.name.Contains("Player"))
			GetComponent<cakeslice.Outline>().enabled = false;
	}
}
