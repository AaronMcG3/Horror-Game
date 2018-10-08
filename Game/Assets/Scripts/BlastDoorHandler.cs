using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastDoorHandler : MonoBehaviour {

    [SerializeField] private GameObject synthNode1;
    [SerializeField] private GameObject synthNode2;
    [SerializeField] private GameObject synthNode3;
    [SerializeField] private GameObject synthNode4;
    [SerializeField] private GameObject synthNode5;
    [SerializeField] private GameObject synthNode6;
    [SerializeField] private GameObject synthNode7;
    [SerializeField] private GameObject synthNode8;

    public Light synthNodeLight1;
    public Light synthNodeLight2;
    public Light synthNodeLight3;
    public Light synthNodeLight4;
    public Light synthNodeLight5;
    public Light synthNodeLight6;
    public Light synthNodeLight7;
    public Light synthNodeLight8;

    public Animator anim;
    private bool[] done;
    private bool isDone;

    public AudioClip openingDoorClip;
    public AudioSource openingDoor;

    // Use this for initialization
    void Start()
    {
        synthNodeLight1.color = Color.red;
        synthNodeLight2.color = Color.red;
        synthNodeLight3.color = Color.red;
        synthNodeLight4.color = Color.red;
        synthNodeLight5.color = Color.red;
        synthNodeLight6.color = Color.red;
        synthNodeLight7.color = Color.red;
        synthNodeLight8.color = Color.red;


        isDone = false;
        done = new bool[8];
        openingDoor = this.GetComponent<AudioSource>();

        for (int i = 0; i < done.Length; i++)
        {
            done[i] = false;
        }

        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (synthNode1.GetComponent<SynthNode>().IsDone() && !done[0])
        {
            Debug.Log("synthNode1");
            done[0] = true;
            synthNodeLight1.color = Color.green;
        }

        if (synthNode2.GetComponent<SynthNode>().IsDone() && !done[1])
        {
            Debug.Log("synthNode2");
            done[1] = true;
            synthNodeLight2.color = Color.green;
        }

        if (synthNode3.GetComponent<SynthNode>().IsDone() && !done[2])
        {
            Debug.Log("synthNode3");
            done[2] = true;
            synthNodeLight3.color = Color.green;
        }

        if (synthNode4.GetComponent<SynthNode>().IsDone() && !done[3])
        {
            Debug.Log("synthNode4");
            done[3] = true;
            synthNodeLight4.color = Color.green;
        }

        if (synthNode5.GetComponent<SynthNode>().IsDone() && !done[4])
        {
            Debug.Log("synthNode5");
            done[4] = true;
            synthNodeLight5.color = Color.green;
        }

        if (synthNode6.GetComponent<SynthNode>().IsDone() && !done[5])
        {
            Debug.Log("synthNode5");
            done[5] = true;
            synthNodeLight6.color = Color.green;
        }

        if (synthNode7.GetComponent<SynthNode>().IsDone() && !done[6])
        {
            Debug.Log("synthNode5");
            done[6] = true;
            synthNodeLight7.color = Color.green;
        }

        if (synthNode8.GetComponent<SynthNode>().IsDone() && !done[7])
        {
            Debug.Log("synthNode5");
            done[7] = true;
            synthNodeLight8.color = Color.green;
        }

        if (OpenDoor() && !isDone)
        {
            openingDoor.Play();
            isDone = true;
            anim.SetTrigger("Open");
        }

    }

    public bool OpenDoor()
    {
        for (int i = 0; i < 8; i++)
        {
            if (!done[i])
                return false;
        }
            return true;
    }
}
