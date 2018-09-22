using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    void FixedUpdate()
    {
        var z = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
        var x = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Translate(x, 0, z);
    }
}
