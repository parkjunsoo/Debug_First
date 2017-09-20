using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subtitle : MonoBehaviour {

    TextMesh subTitle;
    string subtitleText;
    MeshRenderer mesh;

	// Use this for initialization
	void Start () {
        mesh = GetComponent<MeshRenderer>();
        subTitle = GetComponent<TextMesh>();
        subtitleText = "";
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        //subTitle.color = new Color(subTitle.color.r, subTitle.color.g, subTitle.color.b, subTitle.color.a + 0.01f);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Printing("sample");
        }
	}

    public void Printing(string text)
    {
        StartCoroutine(Print(text));
    }

    IEnumerator Print(string txt)
    {
        subTitle.text = txt;

        while (subTitle.color.a < 1.0f)
        {
            subTitle.color = new Color(subTitle.color.r, subTitle.color.g, subTitle.color.b, subTitle.color.a + 0.2f);
            Debug.Log(subTitle.color.a);
            yield return new WaitForSeconds(0.1f);
        }
        Debug.Log("break");
        yield return new WaitForSeconds(2f);

        while(subTitle.color.a > 0f)
        {
            subTitle.color = new Color(subTitle.color.r, subTitle.color.g, subTitle.color.b, subTitle.color.a - 0.2f);
            Debug.Log(subTitle.color.a);
            yield return new WaitForSeconds(0.1f);
        }

        yield return null;
    }

}
