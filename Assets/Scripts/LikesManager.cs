using UnityEngine;
using TMPro;
using System.Collections;
using MoodMe;

public class LikesManager : MonoBehaviour
{
    public float threshold = 0.15f;
    public float checkDuration = 0.01f;// Duration to check for the threshold crossing
    private float lastTimeBelowThreshold = 3.0f;
    private bool isChecking = false; // Whether the threshold check is currently active

    public TextMeshProUGUI likesText; // Reference to the TextMeshProUGUI for displaying likes
    private int likesCount = 0; // Current number of likes

    public EmotionsManager emotionsManager;

    // Update is called once per frame
    void Update()
    {
        float yourFloatValue = GetYourFloatValue();

        if (yourFloatValue < threshold)
        {
            if (!isChecking)
            {
                isChecking = true;
                lastTimeBelowThreshold = Time.time;
                StartCoroutine(CheckThreshold());
            }
        }
        else
        {
            if (isChecking)
            {
                // Reset and stop checking if the value crosses the threshold
                isChecking = false;
                StopCoroutine(CheckThreshold());
                lastTimeBelowThreshold = Time.time; // Reset the timer
            }
        }
    }

    IEnumerator CheckThreshold()
    {
        float startTime = Time.time;

        while ((Time.time - startTime) < checkDuration)
        {
            yield return null;
        }

        // Start rapid incrementation of likes
        float rapidIncrementDuration = 2.0f; // Duration of rapid incrementation, e.g., 2 seconds
        float rapidIncrementEndTime = Time.time + rapidIncrementDuration;
        while (Time.time < rapidIncrementEndTime)
        {
            IncrementLikes(1); // Increment by 1 like each time

            // Wait for a very short amount of time before the next increment
            float rapidIncrementDelay = UnityEngine.Random.Range(0.01f, 0.02f);// Faster delay, e.g., between 0.05 and 0.1 seconds
            yield return new WaitForSeconds(rapidIncrementDelay);
        }

        isChecking = false;
    }

    void IncrementLikes(int incrementRate)
    {
        likesCount += incrementRate;
        likesText.text = $"{likesCount} Likes";
    }

    float GetYourFloatValue()
    {
        return emotionsManager.Happy;
    }
}