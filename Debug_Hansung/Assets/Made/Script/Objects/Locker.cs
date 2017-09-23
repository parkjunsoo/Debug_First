using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour {

    public bool canOpen;
	public bool opening;
	// Use this for initialization
	void Start () {
		GetComponent<cakeslice.Outline>().enabled = false;
	}

	//y값 기준으로 -0.9까지

	// Update is called once per frame
	void Update () {
		if (opening && this.transform.rotation.y >= -0.9f)
			Open();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.name.Contains("Player") && GameObject.Find("Lock_Close").GetComponent<Lock>().isCut)
		{
			GetComponent<cakeslice.Outline>().enabled = true;
		}
	}

	private void OnTriggerStay(Collider other)
	{
<<<<<<< HEAD
		if (Input.GetKeyDown(KeyCode.R) && GameObject.Find("Lock_Close").GetComponent<Lock>().isCut)
=======
        if (other.name.Contains("Player") && GameObject.Find("Lock_Close").GetComponent<Lock>().isCut)
            GetComponent<cakeslice.Outline>().enabled = true;

		if (Input.GetKeyDown(KeyCode.Q) && GameObject.Find("Lock_Close").GetComponent<Lock>().isCut)
>>>>>>> 6c445c1e483910742b90ca5eda0a883180e21f33
		{
			opening = true;

		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.name.Contains("Player"))
			GetComponent<cakeslice.Outline>().enabled = false;
	}


	void Open()
	{
		this.transform.Rotate(0, -1f, 0);
	}


}
