using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynthNode : MonoBehaviour {

    [SerializeField] private GameObject synthNodeUI;
    private Vector2 frequency, speed, volume;

    private float frequencyAnswer, speedAnswer, volumeAnswer;
    private float frequencyCurr, speedCurr, volumeCurr;
    private bool frequencyCorr;

    // Use this for initialization
    void Start () {
        GetData();
        GenerateAnswers();
    }
	
	// Update is called once per frame
	void Update () {
        if (synthNodeUI.activeSelf)
        {
            getCurr();
            checkAnswers();
        }

    }

    private void GetData(){
        frequency = synthNodeUI.GetComponent<SynthNodeUI>().getFrequencyMinMax();
        speed = synthNodeUI.GetComponent<SynthNodeUI>().getSpeedMinMax();
        volume = synthNodeUI.GetComponent<SynthNodeUI>().getVolumeMinMax();

        frequencyCorr = false;
    }

    private void GenerateAnswers(){
        frequencyAnswer = Random.Range(frequency.x, frequency.y);
        speedAnswer = Random.Range(speed.x, speed.y);
        volumeAnswer = Random.Range(volume.x, volume.y);
    }

    private void getCurr(){
        frequencyCurr = synthNodeUI.GetComponent<SynthNodeUI>().getFrequencyCurr();
    }

    
    private void checkAnswers(){
        if (frequencyCurr < frequencyAnswer + 40 && frequencyCurr > frequencyAnswer - 40 && !frequencyCorr){
            synthNodeUI.GetComponent<SynthNodeUI>().CorrectAnswer();
            frequencyCorr = true;
        }

        //if value < maxValue and value > minValue:
    }


    public void Hit(){
        Cursor.lockState = CursorLockMode.None;
        synthNodeUI.SetActive(true);
    }



}
