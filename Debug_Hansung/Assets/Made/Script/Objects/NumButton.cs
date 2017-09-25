using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumButton : MonoBehaviour {

    public string number;
    cakeslice.Outline outline;
    TextMesh pwText;
    NumberPad numberPad;
    PlayerControl player;

	// Use this for initialization
	void Start () {
        numberPad = GameObject.Find("NumberPad").GetComponent<NumberPad>();
        outline = GetComponent<cakeslice.Outline>();
        outline.enabled = false;
        pwText = GameObject.Find("PWText").GetComponent<TextMesh>();
        player = GameObject.Find("Player").GetComponent<PlayerControl>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(numberPad.isEnabled)
            outline.enabled = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F) && numberPad.isEnabled)
        {
            if (number == "#")
            {
                if (numberPad.password.Equals(numberPad.inputTxt))
                {
                    player.isPaused = false;
                    numberPad.isEnabled = false;
                    pwText.text = "PassWord : ";
                    numberPad.inputTxt = "";
                    outline.enabled = false;
                    GameObject.Find("DoorLock").GetComponent<DoorLock>().SetCanOpen(true);

                }
            }
            else if (number == "*")
            {
                player.isPaused = false;
                numberPad.isEnabled = false;
                pwText.text = "PassWord : ";
                numberPad.inputTxt = "";
                outline.enabled = false;
                GameObject.Find("DoorLock").GetComponent<DoorLock>().Disable();
            }
            else
            {
                numberPad.inputTxt += number;
                pwText.text += number;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        outline.enabled = false;
    }
}
