﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MiniGameCulprit : MonoBehaviour
{

    public Button miniGameCulpritUIButton1, miniGameCulpritUIButton2, miniGameCulpritUIButton3, restartCulpritGameUIButton;
    public GameObject miniGameCulpritUIQuestionText, miniGameCulpritUIWrongAnswerText, miniGameCulpritUIRightAnswerText, miniGameCulpritUIFinishedMessage;
    public Boolean isButtonPressed, isCulpritMiniGameCompleted;
    public bool isSpeechBuubleActive = false, isGamePartiallyCompleted = false, finishedItOnce = false;


    // Use this for initialization
    void Start()
    {
        miniGameCulpritUIButton1.gameObject.SetActive(false);
        miniGameCulpritUIButton2.gameObject.SetActive(false);
        miniGameCulpritUIButton3.gameObject.SetActive(false);
        restartCulpritGameUIButton.gameObject.SetActive(false);
        miniGameCulpritUIQuestionText.SetActive(false);
        miniGameCulpritUIWrongAnswerText.SetActive(false);
        miniGameCulpritUIRightAnswerText.SetActive(false);
        miniGameCulpritUIFinishedMessage.SetActive(false);
        isButtonPressed = false;
        isCulpritMiniGameCompleted = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (GameObject.Find("Startscreen").GetComponent<textBubble>().crime[0].current == false &&
            GameObject.Find("Startscreen").GetComponent<textBubble>().crime[1].current == false &&
            GameObject.Find("Startscreen").GetComponent<textBubble>().crime[2].current == false &&
            GameObject.Find("Startscreen").GetComponent<textBubble>().crime[3].current == false &&
            GameObject.Find("Startscreen").GetComponent<textBubble>().crime[4].current == false &&
            GameObject.Find("Startscreen").GetComponent<textBubble>().crime[5].current == false &&
            GameObject.Find("Startscreen").GetComponent<textBubble>().crime[6].current == false &&
            GameObject.Find("ImageTargetCulprit").GetComponent<CulpritDefaultTrackableEventHandler>().startMinigameCulprit == true &&
            isButtonPressed == false &&
            isCulpritMiniGameCompleted == false &&
            isGamePartiallyCompleted == false &&
            finishedItOnce == false)
        {

            miniGameCulpritUIButton1.gameObject.SetActive(true);
            miniGameCulpritUIButton2.gameObject.SetActive(true);
            miniGameCulpritUIButton3.gameObject.SetActive(true);
            miniGameCulpritUIQuestionText.SetActive(true);
            finishedItOnce = true;
           

            miniGameCulpritUIButton1.onClick.AddListener(wrongButton1);
            miniGameCulpritUIButton2.onClick.AddListener(wrongButton2);
            miniGameCulpritUIButton3.onClick.AddListener(correctButton);

        }

        if (GameObject.Find("ImageTargetCulprit").GetComponent<CulpritDefaultTrackableEventHandler>().startMinigameCulprit == true &&
            isGamePartiallyCompleted == true &&
            isButtonPressed == false &&
            isCulpritMiniGameCompleted == false)
        {
            miniGameCulpritUIButton1.gameObject.SetActive(true);
            miniGameCulpritUIButton2.gameObject.SetActive(true);
            miniGameCulpritUIButton3.gameObject.SetActive(true);
            miniGameCulpritUIQuestionText.SetActive(true);

            miniGameCulpritUIButton1.onClick.AddListener(wrongButton1);
            miniGameCulpritUIButton2.onClick.AddListener(wrongButton2);
            miniGameCulpritUIButton3.onClick.AddListener(correctButton);
        }

        if (GameObject.Find("ImageTargetCulprit").GetComponent<CulpritDefaultTrackableEventHandler>().startMinigameCulprit == true && isButtonPressed == false && isCulpritMiniGameCompleted == true)
        {
            miniGameCulpritUIFinishedMessage.SetActive(true);
        }


        if (GameObject.Find("ImageTargetCulprit").GetComponent<CulpritDefaultTrackableEventHandler>().startMinigameCulprit == false)
        {
            miniGameCulpritUIButton1.gameObject.SetActive(false);
            miniGameCulpritUIButton2.gameObject.SetActive(false);
            miniGameCulpritUIButton3.gameObject.SetActive(false);
            miniGameCulpritUIQuestionText.SetActive(false);
            miniGameCulpritUIFinishedMessage.SetActive(false);
        }

    }



    void correctButton()
    {
        isCulpritMiniGameCompleted = true;

        miniGameCulpritUIButton1.gameObject.SetActive(false);
        miniGameCulpritUIButton2.gameObject.SetActive(false);
        miniGameCulpritUIButton3.gameObject.SetActive(true);

        miniGameCulpritUIButton3.GetComponent<Text>().color = Color.green;

        miniGameCulpritUIQuestionText.SetActive(false);

        GameObject.Find("Startscreen").GetComponent<textBubble>().crime2[0].current = true;

    }

    void wrongButton1()
    {
        isButtonPressed = true;

        miniGameCulpritUIButton1.gameObject.SetActive(true);
        miniGameCulpritUIButton2.gameObject.SetActive(false);
        miniGameCulpritUIButton3.gameObject.SetActive(false);

        miniGameCulpritUIButton1.GetComponent<Text>().color = Color.red;

        miniGameCulpritUIQuestionText.SetActive(false);
        miniGameCulpritUIWrongAnswerText.SetActive(true);

        restartCulpritGameUIButton.gameObject.SetActive(true);
        restartCulpritGameUIButton.onClick.AddListener(restartGame);

    }

    void wrongButton2()
    {
        isButtonPressed = true;

        miniGameCulpritUIButton1.gameObject.SetActive(false);
        miniGameCulpritUIButton2.gameObject.SetActive(true);
        miniGameCulpritUIButton3.gameObject.SetActive(false);

        miniGameCulpritUIButton2.GetComponent<Text>().color = Color.red;

        miniGameCulpritUIQuestionText.SetActive(false);
        miniGameCulpritUIWrongAnswerText.SetActive(true);

        restartCulpritGameUIButton.gameObject.SetActive(true);
        restartCulpritGameUIButton.onClick.AddListener(restartGame);
    }

    void restartGame()
    {
        miniGameCulpritUIButton1.GetComponent<Text>().color = Color.white;
        miniGameCulpritUIButton2.GetComponent<Text>().color = Color.white;

        miniGameCulpritUIButton1.gameObject.SetActive(true);
        miniGameCulpritUIButton2.gameObject.SetActive(true);
        miniGameCulpritUIButton3.gameObject.SetActive(true);

        miniGameCulpritUIQuestionText.SetActive(true);
        miniGameCulpritUIWrongAnswerText.SetActive(false);
        miniGameCulpritUIRightAnswerText.SetActive(false);

        restartCulpritGameUIButton.gameObject.SetActive(false);

        isButtonPressed = false;
    }
}
