using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {

    public Animator anim; 

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        anim.SetTrigger("Open");
    }

    void OnTriggerExit(Collider col)
    {
        anim.SetTrigger("Close");
    }
}
