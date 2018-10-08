using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {

    public Animator anim;

    //public AudioClip openingDoorClip;
    public AudioSource openingDoor;

    // Use this for initialization
    void Start () {
		anim = gameObject.GetComponent<Animator>();
        openingDoor = this.GetComponent<AudioSource>();
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

    public void OpenDoorOut()
    {
        openingDoor.Play();
        anim.SetTrigger("Open Out");
    }

    public void OpenDoorIn()
    {
        openingDoor.Play();
        anim.SetTrigger("Open In");
    }
}
