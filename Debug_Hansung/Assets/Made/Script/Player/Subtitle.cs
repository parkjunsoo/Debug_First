using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subtitle : MonoBehaviour {

    TextMesh newSubtitle;
    TextMesh subTitle;
    string subtitleText;
    MeshRenderer mesh;
    bool isPrinting;

	// Use this for initialization
	void Start () {
        newSubtitle = GameObject.Find("newSubtitle").GetComponent<TextMesh>();
        mesh = GetComponent<MeshRenderer>();
        subTitle = GetComponent<TextMesh>();
        subtitleText = "";

        //Printing("Testing");
	}
	
	// Update is called once per frame
	void Update ()
    {
        //subTitle.color = new Color(subTitle.color.r, subTitle.color.g, subTitle.color.b, subTitle.color.a + 0.01f);
        //GameObject.Find("SubtitleRot").transform.rotation = Quaternion.Euler(0f, Camera.main.transform.rotation.eulerAngles.y, 0f);
        //Debug.Log(GameObject.Find("SubtitleRot").transform.rotation.eulerAngles.y);
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    Printing("sample");
        //}
	}

    public void Printing(string text)
    {
        StartCoroutine(Print(text));
    }

    IEnumerator Print(string txt)
    {
        subTitle.text = txt;
        if (!isPrinting)
        {
            isPrinting = true;
            while (subTitle.color.a < 1.0f)
            {
                subTitle.color = new Color(subTitle.color.r, subTitle.color.g, subTitle.color.b, subTitle.color.a + 0.1f);
                newSubtitle.color = new Color(newSubtitle.color.r, newSubtitle.color.g, newSubtitle.color.b, newSubtitle.color.a + 0.1f);
                //Debug.Log(subTitle.color.a);
                yield return new WaitForSeconds(0.05f);
            }

            //Debug.Log("break");
            yield return new WaitForSeconds(1.5f);

            while (subTitle.color.a > 0f)
            {
                subTitle.color = new Color(subTitle.color.r, subTitle.color.g, subTitle.color.b, subTitle.color.a - 0.1f);
                newSubtitle.color = new Color(newSubtitle.color.r, newSubtitle.color.g, newSubtitle.color.b, newSubtitle.color.a - 0.1f);
                //Debug.Log(subTitle.color.a);
                yield return new WaitForSeconds(0.05f);
            }
            isPrinting = false;
        }
        yield return null;
    }

}
