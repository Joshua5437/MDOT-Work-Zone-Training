using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public bool rot;

	// Use this for initialization
	void Start () {
        rot = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (rot) { transform.Rotate(0f, 1f, 0f, Space.Self); }

    }
}
