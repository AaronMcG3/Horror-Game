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

    public GameObject blastDoor;

    public AudioClip clickClip, correctAnswer;
    public AudioSource interfaceClick;

    // Use this for initialization
    void Start () {
        complete.onClick.AddListener(CompleteClick);
        //interfaceClick.clip = clickClip;

    }
	
	// Update is called once per frame
	void Update () {
        currtFrequency.text = frequency.value.ToString();
        currtSpeed.text = speed.value.ToString();
        currtVolume.text = volume.value.ToString();
    }

    void CompleteClick(){
        interfaceClick.clip = clickClip;
        interfaceClick.Play();
        playerEvent.GetComponent<PlayerEvent>().SetPlayer(false);
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;

    }

    public Vector2 getFrequencyMinMax(){
        return new Vector2(frequency.minValue, frequency.maxValue);
    }

    public float getFrequencyCurr(){
        return frequency.value;
    }

    public Vector2 getSpeedMinMax(){
        return new Vector2(speed.minValue, speed.maxValue);
    }

    public float getSpeedCurr(){
        return speed.value;
    }

    public Vector2 getVolumeMinMax(){
        return new Vector2(volume.minValue, volume.maxValue);
    }

    public float getVolumeCurr(){
        return volume.value;
    }

    public void CorrectAnswer()
    {
        interfaceClick.clip = correctAnswer;
        interfaceClick.Play();
    }
}
