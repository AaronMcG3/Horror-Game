﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {

    [SerializeField] private string mouseXInputName, mouseYInputName;
    [SerializeField] private float mouseSensitivity;

    [SerializeField] private Transform playerBody;
	
	private float xAxisClamp;
    private bool lockPlayer;

    private void Awake(){
        mouseXInputName = "Mouse X";
        mouseYInputName = "Mouse Y";
        mouseSensitivity = 150f;
        xAxisClamp = 0.0f;
        lockPlayer = false;
        LockCursor();
    } 

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (lockPlayer == false)
            CamerRotation();
    }

    private void LockCursor(){
		Cursor.lockState = CursorLockMode.Locked;
    }

    private void CamerRotation(){
		float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

		xAxisClamp += mouseY;
		
		if(xAxisClamp > 90.0f){
			xAxisClamp = 90f;
			mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
		}
		else if(xAxisClamp < -90.0f){
			xAxisClamp = -90f;
			mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
		}
		
        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }
	
	private void ClampXAxisRotationToValue(float value){
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
	}

    public void SetLockPlayer(bool set){
        lockPlayer = set;
    }
}
