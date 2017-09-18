﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        GetComponent<cakeslice.Outline>().enabled = false;          
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Player"))
        {
            GetComponent<cakeslice.Outline>().enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name.Contains("Player") && Input.GetKeyDown(KeyCode.Q))
        {
            other.GetComponent<PlayerControl>().AddCount();                 //player.GetComponent ~~~로 했더니 잘 되다가 갑자기 에러나서 바꿈. 뭐여 씨벌
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("Player"))
            GetComponent<cakeslice.Outline>().enabled = false;
    }
}
