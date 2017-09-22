using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberPad : MonoBehaviour {

    public GameObject cursor;
    public bool isEnabled;
    public float cursorSpeed;

    public string password;
    public string inputTxt;

	// Use this for initialization
	void Start () {
        cursor = GameObject.Find("Cursor");
        cursor.GetComponent<cakeslice.Outline>().enabled = false;
        isEnabled = false;
        inputTxt = "";
        foreach (MeshRenderer mesh in GetComponentsInChildren<MeshRenderer>())
        {
            mesh.enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (isEnabled)
            CursorMoving();
        else
            cursor.GetComponent<cakeslice.Outline>().enabled = false;
    }

    void CursorMoving()
    {
        if (Input.GetAxis("Horizontal") > 0 && cursor.transform.position.z < -9.47f)
            cursor.transform.position = new Vector3(cursor.transform.position.x, cursor.transform.position.y, cursor.transform.position.z + cursorSpeed * Time.deltaTime);
        else if (Input.GetAxis("Horizontal") < 0 && cursor.transform.position.z > -10.8f)
            cursor.transform.position = new Vector3(cursor.transform.position.x, cursor.transform.position.y, cursor.transform.position.z - cursorSpeed * Time.deltaTime);

        if (Input.GetAxis("Vertical") > 0 && cursor.transform.position.y < 3.6f)
            cursor.transform.position = new Vector3(cursor.transform.position.x, cursor.transform.position.y + cursorSpeed * Time.deltaTime, cursor.transform.position.z);
        else if (Input.GetAxis("Vertical") < 0 && cursor.transform.position.y > 2.4f)
            cursor.transform.position = new Vector3(cursor.transform.position.x, cursor.transform.position.y - cursorSpeed * Time.deltaTime, cursor.transform.position.z);
    }
}
