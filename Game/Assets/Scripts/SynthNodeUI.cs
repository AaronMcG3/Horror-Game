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

    public AudioClip clickClip, correctAnswer;
    public AudioSource interfaceClick;

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

    public int GetEnvelopeMax(){
        return 3;
    }

    public int GetEffectMax(){
        return 3;
    }

    public int GetWaveTypeMax(){
        return 4;
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
            return 1;
        else if (aDSREn.isOn)
            return 2;
        else if (glitchEn.isOn)
            return 3;
        else
            return 4;
    }

    public int GetEffectCurr()
    {
        if (noneEn.isOn)
            return 1;
        else if (distortionEn.isOn)
            return 2;
        else if (noiseEn.isOn)
            return 3;
        else
            return 4;
    }

    public int GetWaveTypeCurr()
    {
        if (sineEn.isOn)
            return 1;
        else if (sawEn.isOn)
            return 2;
        else if (triEn.isOn)
            return 3;
        else if (rectEn.isOn)
            return 4;
        else
            return 5;
    }
}
