using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusNoteBook : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<MeshRenderer> ().enabled = false;
		GetComponent<MeshCollider> ().enabled = false;
		//GetComponent<cakeslice.Outline>().enabled = false;
	}

	public void EnableMesh(){
		GetComponent<MeshRenderer> ().enabled = true;
		GetComponent<MeshCollider> ().enabled = true;
		GetComponent<cakeslice.Outline> ().enabled = true;
	}

	public void DisableMesh(){
		GetComponent<MeshRenderer> ().enabled = false;
		GetComponent<MeshCollider> ().enabled = false;
	}
	// Update is called once per frame
	void Update () {

	}
}
