using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvent : MonoBehaviour {

    [SerializeField] private Transform point;
    [SerializeField] private GameObject playercamera, playerMovement;
    [SerializeField] private Animator anim;

    private RaycastHit hit;

    public Camera camera;

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
        
        //RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        //if (Physics.Raycast(ray, out hit, 3f, 1))
        //{
           // Debug.Log("Hit 3");
            //Transform objectHit = hit.transform;

            // Do something with the object that was hit by the raycast.
        //}
        

        Vector3 fwd = playercamera.transform.TransformDirection(transform.forward);

        if (Input.GetButtonDown("Fire1") && setHit == false) {
            if (Physics.Raycast(ray, out hit, 3f, 1)) { 

            //if (Physics.Raycast(transform.position, fwd, out hit, 1.5f, 1)) {

                if (hit.collider.tag == "SynthNode") {
                    SetPlayer(true);
                    hit.collider.GetComponent<SynthNode>().Hit();
                }

                if(hit.collider.tag == "OpenOut"){
                    Debug.Log("Hit Tag");
                    hit.collider.GetComponentInParent<DoorTrigger>().OpenDoorOut();
                    //hit.collider.GetComponent<Animator>().SetTrigger("Open Out");
                }

                if (hit.collider.tag == "OpenIn")
                {
                    Debug.Log("Hit Tag");
                    hit.collider.GetComponentInParent<DoorTrigger>().OpenDoorIn();
                    //hit.collider.GetComponent<Animator>().SetTrigger("Open Out");
                }

                if (hit.transform.tag.Equals("OpenOut"))
                {
                    Debug.Log("Hit");
                    //hit.collider.GetComponent<Animator>().SetTrigger("Open Out");
                }

                if (hit.transform.tag.Equals("OpenIn"))
                {
                    Debug.Log("Hit");
                    //hit.collider.GetComponent<Animator>().SetTrigger("Open Out");
                }
                Debug.Log("Did Hit");

                //Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
                //Debug.DrawRay(ray.origin, ray.direction * 3 Color.yellow);
            }
        }
        else if (Physics.Raycast(ray, out hit, 3f, 1))
            Interactable();
        else
            setIconHand(true);

        Debug.DrawRay(ray.origin, ray.direction * 3f, Color.yellow);
        //}
        //else
        //   anim.SetBool("Idle", true);
    }

    private void Interactable()
    {
        switch (hit.collider.tag)
        {
            case "SynthNode":
                setIconHand(false);
                break;
            case "OpenOut":
                setIconHand(false);
                break;
            case "OpenIn":
                setIconHand(false);
                break;
            default:
                setIconHand(true);
                break;
        }
    }

    private void setIconHand(bool set){
        anim.SetBool("Idle", set);
    }

    public void SetPlayer(bool set){
        setHit = set;
        playercamera.GetComponent<PlayerLook>().SetLockPlayer(set);
        GetComponent<PlayerMove>().SetLockMovement(set);
    }
}
