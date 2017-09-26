using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDoor : MonoBehaviour {

	void Start () {
		GetComponent<MeshRenderer> ().enabled = false;
		GetComponent<MeshCollider> ().enabled = false;
		GetComponent<cakeslice.Outline>().enabled = false;
	}

	public void EnableMesh(){
		GetComponent<MeshRenderer> ().enabled = true;
		GetComponent<MeshCollider> ().enabled = true;
		GetComponent<cakeslice.Outline> ().enabled = true;
	}
		
	// Update is called once per frame
	void Update () {

	}
}
