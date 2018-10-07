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

    [SerializeField] private Toggle aDEn, aDSREn, glitchEn;
    [SerializeField] private Toggle noneEn, distortionEn, noiseEn;
    [SerializeField] private Toggle sineEn, sawEn, triEn, rectEn;

    [SerializeField] private Button complete;


    private bool[] envelopeArr, effectArr, waveTypeArr;
    public AudioClip clickClip, correctAnswer;
    public AudioSource interfaceClick;

    // Use this for initialization
    void Start () {
        complete.onClick.AddListener(CompleteClick);
        envelopeArr = new bool[3];
        effectArr = new bool[3];
        waveTypeArr = new bool[4];
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

    public Vector2 GetFrequencyMinMax(){
        return new Vector2(frequency.minValue, frequency.maxValue);
    }

    public float GetFrequencyCurr(){
        return frequency.value;
    }

    public Vector2 GetSpeedMinMax(){
        return new Vector2(speed.minValue, speed.maxValue);
    }

    public float GetSpeedCurr(){
        return speed.value;
    }

    public Vector2 GetVolumeMinMax(){
        return new Vector2(volume.minValue, volume.maxValue);
    }

    public bool[] GetEnvelopeMax(){
        for(int i = 0; i < 3; i++)
            envelopeArr[i] = false;
        return envelopeArr;
    }

    public bool[] GetEffectMax(){
        for (int i = 0; i < 3; i++)
            effectArr[i] = false;
        return effectArr;
    }

    public bool[] GetWaveTypeMax(){
        for (int i = 4; i < 3; i++)
            waveTypeArr[i] = false;
        return waveTypeArr;
    }

    public float GetVolumeCurr(){
        return volume.value;
    }

    public void CorrectAnswer(){
        interfaceClick.clip = correctAnswer;
        interfaceClick.Play();
    }

    public int GetEnvelopeCurr()
    {
        if (aDEn.isOn)
            return 0;
        else if (aDSREn.isOn)
            return 1;
        else if (glitchEn.isOn)
            return 2;
        else
            return 3;
    }
}
