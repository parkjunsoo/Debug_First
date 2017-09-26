using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
	void Start () {
		GetComponent<MeshRenderer> ().enabled = true;
		GetComponent<MeshCollider> ().enabled = true;
		GetComponent<cakeslice.Outline>().enabled = true;
	}
		

	private void OnTriggerEnter(Collider other)
	{
		if (other.name.Contains("Player")&&other.GetComponent<PlayerControl>().getBattery)
		{
			//만약 배터리 획득시 기존 문 메시 지우고 블러드 도어 메쉬 생성
			DisableMesh ();
			GameObject.Find ("Blood_Door").GetComponent<BloodDoor> ().EnableMesh ();
		}

	}

	public void DisableMesh(){
		GetComponent<MeshRenderer> ().enabled = false;
		GetComponent<MeshCollider> ().enabled = false;
	}
	// Update is called once per frame
	void Update () {

	}
}
