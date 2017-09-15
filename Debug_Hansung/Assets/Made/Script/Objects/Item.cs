using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Item : MonoBehaviour {

    protected abstract void PickUp();
    protected GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        GetComponent<cakeslice.Outline>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<cakeslice.Outline>().enabled = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PickUp();
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<cakeslice.Outline>().enabled = false;
    }

}
