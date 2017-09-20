using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenToiletDoor : MonoBehaviour {

    bool isOpening;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isOpening && gameObject.transform.rotation.eulerAngles.y < 270)
            DoorOpen();
	}

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isOpening = true;
        }
    }

    void DoorOpen()
    {
        gameObject.transform.Rotate(0f, -1f, 0f);
    }

}
