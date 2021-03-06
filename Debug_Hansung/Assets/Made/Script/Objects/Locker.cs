﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour {

    public bool canOpen;
	public bool opening;
	// Use this for initialization
	void Start () {
		GetComponent<cakeslice.Outline>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
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
        if (other.name.Contains("Player") && GameObject.Find("Lock_Close").GetComponent<Lock>().isCut)
            GetComponent<cakeslice.Outline>().enabled = true;

		if (Input.GetKeyDown(KeyCode.Q) && canOpen)
		{
			opening = true;
            GameObject.Find("Battery").GetComponent<BoxCollider>().enabled = true;
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
