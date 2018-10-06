using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvent : MonoBehaviour {

    [SerializeField] private Transform point;
    [SerializeField] private GameObject playercamera, playerMovement;
    [SerializeField] private Animator anim;

    private bool setHit;

    private void Awake(){
        //playerMovement = GetComponent<GameObject>();
        setHit = false;
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Fire();
	}

    private void Fire()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Input.GetButtonDown("Fire1") && setHit == false) {

            if (Physics.Raycast(transform.position, fwd, out hit, 3f, 1)) {

                if (hit.collider.tag == "SynthNode") {
                    SetPlayer(true);
                    hit.collider.GetComponent<SynthNode>().Hit();
                }

                Debug.Log("Did Hit");
            }
        }
        else if (Physics.Raycast(transform.position, fwd, out hit, 3f, 1)){
            //anim.SetTrigger("To Hand");
            anim.SetBool("Idle", false);
        }
        else
            anim.SetBool("Idle", true);
        //anim.SetTrigger("To Idle");
    }

    public void SetPlayer(bool set){
        setHit = set;
        playercamera.GetComponent<PlayerLook>().SetLockPlayer(set);
        GetComponent<PlayerMove>().SetLockMovement(set);
    }
}
