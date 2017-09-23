﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour {

	public bool isCut;
	GameObject player;
	PlayerControl playerControl;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		playerControl = player.GetComponent<PlayerControl>();
        GetComponent<cakeslice.Outline>().enabled = false;
		isCut = false;
	}

	// Update is called once per frame
	void Update () {

	}

	public void Cut()
	{
		isCut = true;
		GetComponent<MeshFilter>().mesh = GameObject.Find("Lock_Open").GetComponent<MeshFilter>().mesh;
		GetComponent<Rigidbody>().useGravity = true;
		GetComponent<cakeslice.Outline>().enabled = false;
	}

	private void OnCollisionEnter(Collision collision)
	{
        if(collision.collider.name.Contains("Player"))
            GetComponent<cakeslice.Outline>().enabled = true;
        if (collision.collider.tag == "Plane")           //충돌한 collider의 tag가 'Plane'일 경우 호출
            Debug.Log("CollisionEnter in Script_Lock Called");
	}

	private void OnTriggerStay(Collider other)
	{
        if (other.name.Contains("Player") && other.GetComponent<PlayerControl>().getNipper)
            GetComponent<cakeslice.Outline>().enabled = true;
		if (other.name.Contains ("Player") && Input.GetKeyDown (KeyCode.Q)) {
			if (other.GetComponent<PlayerControl> ().getNipper) {
				Cut();
			}
		}
	}

}
