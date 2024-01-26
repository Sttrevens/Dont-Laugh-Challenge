using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TMP_Text timerText; // Assign this in the inspector
    private float elapsedTime;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateTimerDisplay(elapsedTime);
    }

    void UpdateTimerDisplay(float time)
    {
        int minutes = (int)(time / 60);
        int seconds = (int)(time % 60);
        timerText.text = string.Format("{0}:{1:00}", minutes, seconds);
    }
}