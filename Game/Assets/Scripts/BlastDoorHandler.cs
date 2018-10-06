using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastDoorHandler : MonoBehaviour {

    [SerializeField] private GameObject synthNode1;

    public Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if(synthNode1.GetComponent<SynthNode>().IsDone())
            anim.SetTrigger("Open");
        //synthNode1.GetComponent<SynthNode>().IsDone();
    }

    //synthNode1.GetComponent<SynthNode>().IsDone();
}
