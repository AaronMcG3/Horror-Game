using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SynthNodeUI : MonoBehaviour {

    [SerializeField] private GameObject playerEvent;

    [SerializeField] private Slider frequency;
    [SerializeField] private Text currtFrequency;

    [SerializeField] private Slider speed;
    [SerializeField] private Text currtSpeed;

    [SerializeField] private Slider volume;
    [SerializeField] private Text currtVolume;

    [SerializeField] private Button complete;

    // Use this for initialization
    void Start () {
        complete.onClick.AddListener(CompleteClick);
	}
	
	// Update is called once per frame
	void Update () {
        currtFrequency.text = frequency.value.ToString();
        currtSpeed.text = speed.value.ToString();
        currtVolume.text = volume.value.ToString();
    }

    void CompleteClick(){
        playerEvent.GetComponent<PlayerEvent>().SetPlayer(false);
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public float getFrequency(){
        return frequency.value;
    }

    public float getSpeed(){
        return speed.value;
    }

    public float getVolume(){
        return volume.value;
    }
}
