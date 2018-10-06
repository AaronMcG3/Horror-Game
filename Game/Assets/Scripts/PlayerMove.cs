using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    [SerializeField] private string horizontalInputName, verticalInputName;
    [SerializeField] private float movementSpeed, jumpMultiplier;
    [SerializeField] private AnimationCurve jumpFalloff;
    [SerializeField] private KeyCode jumpKey;
    [SerializeField] private float slopeForce, slopeForceRayLengthy;

    private CharacterController charController;

    private bool isJuming, lockMovement;

    private void Awake(){

        lockMovement = false;
        charController = GetComponent<CharacterController>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(lockMovement == false)
            PlayerMovement();
	}

    private void PlayerMovement(){

        float horInput = Input.GetAxis(horizontalInputName);
        float verInput = Input.GetAxis(verticalInputName);

        Vector3 forwardMovement = transform.forward * verInput;
        Vector3 rightMovement = transform.right * horInput;

        charController.SimpleMove(Vector3.ClampMagnitude(forwardMovement + rightMovement, 1.0f) * movementSpeed);

        if ((verInput != 0 || horInput != 0) && OnSlope())
            charController.Move(Vector3.down * charController.height / 2 * slopeForce * Time.deltaTime);

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

    private bool OnSlope(){

        if (isJuming)
            return false;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, charController.height / 2 * slopeForceRayLengthy))
            if (hit.normal != Vector3.up)
                return true;

        return false;
    }

    public void SetLockMovement(bool set){
        lockMovement = set;
    }
}
