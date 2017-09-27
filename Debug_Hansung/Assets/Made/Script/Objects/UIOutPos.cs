using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOutPos : MonoBehaviour {

    public static UIOutPos instance = null;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
