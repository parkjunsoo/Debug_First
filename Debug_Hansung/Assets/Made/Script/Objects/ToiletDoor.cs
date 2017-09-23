using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletDoor : MonoBehaviour {

    bool canOpen;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (canOpen && gameObject.transform.rotation.eulerAngles.y > 60)
            Open();

    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Q))
            canOpen = true;
    }

    void Open()
    {
        transform.Rotate(0f, -1f, 0f);
    }
}
