using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBook : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<cakeslice.Outline>().enabled = false;
	}

	private void OnTriggerEnter(Collider other){

	}

	private void OnTriggerStay(Collider other)
	{
		if (other.name.Contains("Player")&& GameObject.Find("radio").GetComponent<Radio>().offRadio==true)
		{
			GetComponent<cakeslice.Outline>().enabled = true;
		}

		if (Input.GetKeyDown (KeyCode.R)){
			GameObject.Find ("plusNotebook").GetComponent<PlusNoteBook> ().EnableMesh ();
		}

	}


	private void OnTriggerExit(Collider other){
		if (other.name.Contains ("Player")) 
		{
			GetComponent<cakeslice.Outline> ().enabled = false;
		}
	}

	// Update is called once per frame
	void Update () {

	}


}