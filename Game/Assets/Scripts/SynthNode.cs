using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynthNode : MonoBehaviour {

    [SerializeField] private GameObject synthNodeUI;
    private Vector2 frequency, speed, volume;

    private float frequencyAnswer, speedAnswer, volumeAnswer;
    private float frequencyCurr, speedCurr, volumeCurr;
    private bool frequencyCorr, speedCorr, volumeCorr;

    private bool[] answered;

    // Use this for initialization
    void Start () {
        answered = new bool[6];
        GetData();
        GenerateAnswers();
    }
	
	// Update is called once per frame
	void Update () {
        if (synthNodeUI.activeSelf)
        {
            GetCurr();
            CheckAnswers();
        }

    }

    private void GetData(){
        frequency = synthNodeUI.GetComponent<SynthNodeUI>().getFrequencyMinMax();
        speed = synthNodeUI.GetComponent<SynthNodeUI>().getSpeedMinMax();
        volume = synthNodeUI.GetComponent<SynthNodeUI>().getVolumeMinMax();

        for (int i = 0; i < answered.Length; i++){
            answered[i] = false;
        }

        //frequencyCorr = false;
        //speedCorr = false;
        //volumeCorr = false;
    }

    private void GenerateAnswers(){
        frequencyAnswer = Random.Range(frequency.x, frequency.y);
        speedAnswer = Random.Range(speed.x, speed.y);
        volumeAnswer = Random.Range(volume.x, volume.y);
    }

    private void GetCurr(){
        frequencyCurr = synthNodeUI.GetComponent<SynthNodeUI>().getFrequencyCurr();
        speedCurr = synthNodeUI.GetComponent<SynthNodeUI>().getSpeedCurr();
        volumeCurr = synthNodeUI.GetComponent<SynthNodeUI>().getVolumeCurr();
    }

    private void CheckAnswers(){
        if (frequencyCurr < frequencyAnswer + 40f && frequencyCurr > frequencyAnswer - 40f && !answered[0])
        {
            synthNodeUI.GetComponent<SynthNodeUI>().CorrectAnswer();
            answered[0] = true;
        }

        if(speedCurr < speedAnswer + 0.5f && speedCurr > speedAnswer - 0.5f && !answered[1])
        {
            synthNodeUI.GetComponent<SynthNodeUI>().CorrectAnswer();
            answered[1] = true;
        }

        if (volumeCurr < volumeAnswer + 0.5f && volumeCurr > volumeAnswer - 0.5f && !answered[2])
        {
            synthNodeUI.GetComponent<SynthNodeUI>().CorrectAnswer();
            answered[2] = true;
        }

        //if value < maxValue and value > minValue:
    }

    public void Hit(){
        Cursor.lockState = CursorLockMode.None;
        synthNodeUI.SetActive(true);
    }

    public bool IsDone()
    {
        for (int i = 0; i < 1; i++){
            if (!answered[i])
                return false;
        }

        return true;
    }
}
