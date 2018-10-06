using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvent : MonoBehaviour {

    [SerializeField] private Transform point;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Fire();
	}

        private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            if (Physics.Raycast(transform.position, fwd, out hit, 3f, 1))
            {
                //setHit = true;

                if (hit.collider.tag == "SynthNode")
                    hit.collider.GetComponent<SynthNode>().Hit();

                Debug.Log("Did Hit");
            }
        }
    }
}
