using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugDoor : MonoBehaviour {
    
    GameObject doorLock;
    static bool doorOpening;
    bool isFading;
    PlayerControl player;

	// Use this for initialization
	void Start () {
        doorLock = GameObject.Find("DoorLock");
        player = GameObject.Find("Player").GetComponent<PlayerControl>();
	}
	
	// Update is called once per frame
	void Update () {
        if (doorOpening)
        {
            DoorOpen();
            //if (isFading)
            //{
            //    Camera.main.GetComponent<OVRScreenFade>().StartFadeOut();
            //    isFading = false;
            //}
        }
	}
    

    private void OnTriggerStay(Collider other)
    {
        if(other.name.Contains("Player") && Input.GetKeyDown(KeyCode.Q))
        {
            if (doorLock.GetComponent<DoorLock>().GetCanOpen())
            { 
                doorOpening = true;
                player.endingTime = player.gameTime;
                player.end = player.gameTime;
                //Camera.main.GetComponent<OVRScreenFade>().StartFadeOut();
            }
        }
    }

    void DoorOpen()
    {
        if (transform.rotation.eulerAngles.y <= 90)
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 5.0f, transform.rotation.eulerAngles.z);
        else
            GameObject.Find("Player").GetComponent<PlayerControl>().ending = true;
        /*
        if (transform.position.z < -12.3f)
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f * Time.deltaTime);
        else
        {
            GameObject.Find("Player").GetComponent<PlayerControl>().ending = true;
        }
        */
    }
}
