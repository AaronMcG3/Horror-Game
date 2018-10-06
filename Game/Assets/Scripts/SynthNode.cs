using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynthNode : MonoBehaviour {

    [SerializeField] private GameObject synthNodeUI;

    /*
    private void OnMouseDown()
    {
        Cursor.lockState = CursorLockMode.None;
        synthNodeUI.SetActive(true);
    }
    */

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Hit()
    {
        Cursor.lockState = CursorLockMode.None;
        synthNodeUI.SetActive(true);
    }
}
