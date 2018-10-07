using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynthNode : MonoBehaviour {

    [SerializeField] private GameObject synthNodeUI;
    private Vector2 frequency, speed, volume;

    private float frequencyAnswer, speedAnswer, volumeAnswer;
    private float envelopeAnswer, effectAnswer, waveTypeAnswer;
    private float frequencyCurr, speedCurr, volumeCurr;
    private int envelopeCurr, effectCurr, waveTypeCurr;
    //private bool frequencyCorr, speedCorr, volumeCorr;
    private int envelope, effect, waveType;

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
        frequency = synthNodeUI.GetComponent<SynthNodeUI>().GetFrequencyMinMax();
        speed = synthNodeUI.GetComponent<SynthNodeUI>().GetSpeedMinMax();
        volume = synthNodeUI.GetComponent<SynthNodeUI>().GetVolumeMinMax();
        envelope = synthNodeUI.GetComponent<SynthNodeUI>().GetEnvelopeMax();
        effect = synthNodeUI.GetComponent<SynthNodeUI>().GetEffectMax();
        waveType = synthNodeUI.GetComponent<SynthNodeUI>().GetWaveTypeMax();

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
        envelopeAnswer = Random.Range(1, envelope);
        effectAnswer = Random.Range(1, effect);
        waveTypeAnswer = Random.Range(1, waveType);
        //Debug.Log("frequencyAnswer " + frequencyAnswer);
        //Debug.Log("speedAnswer " + speedAnswer);
        //Debug.Log("volumeAnswer " + volumeAnswer);
        //Debug.Log("envelopeAnswer " + envelopeAnswer);
    }

    private void GetCurr(){
        frequencyCurr = synthNodeUI.GetComponent<SynthNodeUI>().GetFrequencyCurr();
        speedCurr = synthNodeUI.GetComponent<SynthNodeUI>().GetSpeedCurr();
        volumeCurr = synthNodeUI.GetComponent<SynthNodeUI>().GetVolumeCurr();
        envelopeCurr = synthNodeUI.GetComponent<SynthNodeUI>().GetEnvelopeCurr();
        effectCurr = synthNodeUI.GetComponent<SynthNodeUI>().GetEffectCurr();
        waveTypeCurr = synthNodeUI.GetComponent<SynthNodeUI>().GetWaveTypeCurr();
    }

    private void CheckAnswers(){
        if (frequencyCurr < frequencyAnswer + 40f && frequencyCurr > frequencyAnswer - 40f && !answered[0])
        {
            synthNodeUI.GetComponent<SynthNodeUI>().CorrectAnswer();
            answered[0] = true;
        }

        if(speedCurr < speedAnswer + 0.3f && speedCurr > speedAnswer - 0.3f && !answered[1])
        {
            synthNodeUI.GetComponent<SynthNodeUI>().CorrectAnswer();
            answered[1] = true;
        }

        if (volumeCurr < volumeAnswer + 0.3f && volumeCurr > volumeAnswer - 0.3f && !answered[2])
        {
            synthNodeUI.GetComponent<SynthNodeUI>().CorrectAnswer();
            answered[2] = true;
        }

        if((envelopeCurr == envelopeAnswer) && !answered[3])
        {
            synthNodeUI.GetComponent<SynthNodeUI>().CorrectAnswer();
            answered[3] = true;
        }

        if ((effectCurr == effectAnswer) && !answered[4])
        {
            synthNodeUI.GetComponent<SynthNodeUI>().CorrectAnswer();
            answered[4] = true;
        }

        if ((waveTypeCurr == waveTypeAnswer) && !answered[5])
        {
            synthNodeUI.GetComponent<SynthNodeUI>().CorrectAnswer();
            answered[5] = true;
        }

        //if value < maxValue and value > minValue:
    }

    public void Hit(){
        Cursor.lockState = CursorLockMode.None;
        synthNodeUI.SetActive(true);
    }

    public bool IsDone()
    {
        for (int i = 0; i < 6; i++){
            if (!answered[i])
                return false;
        }

        return true;
    }
}
