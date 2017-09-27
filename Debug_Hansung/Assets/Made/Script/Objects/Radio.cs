using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour {
	public AudioSource a; 
	public AudioClip a1; //첫번째음성
	public AudioClip a2; //두번째 음성
	public bool offRadio; //라디오 온오프 판단 변수

	void Start(){
		offRadio = false;
		GetComponent<cakeslice.Outline>().enabled = false;

	}
	// Use this for initialization
	void Awake () {
		a = GameObject.Find("radio").GetComponent<AudioSource>();
		a.clip = a1;
		a.Play ();
	}

	private void OnTriggerEnter(Collider other){
		a.Stop();//첫번째 음성 멈춤
		a.volume = 0.6f;
		if (other.name.Contains("Player"))
		{
			GetComponent<cakeslice.Outline>().enabled = true;
			//AudioSource.PlayClipAtPoint (a2, transform.position); //두번째 음성 (위치마다 소리 크기 변경)
			a.clip=a2;
			a.Play ();
		}


	}

	private void OnTriggerStay(Collider other)
	{
		if (other.name.Contains("Player") && Input.GetKeyDown(KeyCode.Q))
		{
			offRadio = true;
			Debug.Log (offRadio);
		}


	}


	private void OnTriggerExit(Collider other){
		
		if (other.name.Contains ("Player")) 
		{
			GetComponent<cakeslice.Outline> ().enabled = false;
		}
	}

	void Update () {

		if (offRadio) {
			a.Stop ();
		}
	}



}
