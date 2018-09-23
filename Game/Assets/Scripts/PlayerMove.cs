using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    [SerializeField] private string horizontalInputName, verticalInputName;
    [SerializeField] private float movementSpeed, jumpMultiplier;
    [SerializeField] private AnimationCurve jumpFalloff;
    [SerializeField] private KeyCode jumpKey;

    private CharacterController charController;

    private bool isJuming;

    private void Awake(){

        charController = GetComponent<CharacterController>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        PlayerMovement();
		
	}

    private void PlayerMovement(){

        float horInput = Input.GetAxis(horizontalInputName) * movementSpeed;
        float verInput = Input.GetAxis(verticalInputName) * movementSpeed;

        Vector3 forwardMovement = transform.forward * verInput;
        Vector3 rightMovement = transform.right * horInput;

        charController.SimpleMove(forwardMovement + rightMovement);

        JumpInput();
    }
    
    private void JumpInput(){
        if(Input.GetKeyDown(jumpKey) && !isJuming)
        {
            isJuming = true;
            StartCoroutine(JumpEvent());
        }
    }

    private IEnumerator JumpEvent()
    {
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;

        do
        {
            float jumpFore = jumpFalloff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpFore * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime; 
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;
        isJuming = false;

    }
}
