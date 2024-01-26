using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlinkingIcon : MonoBehaviour
{
    public Image timerIcon; // Assign in the inspector
    public float blinkInterval = 1.0f; // Time in seconds for each blink

    void Start()
    {
        // Start the blinking coroutine
        StartCoroutine(BlinkTimerIcon());
    }

    IEnumerator BlinkTimerIcon()
    {
        // Loop indefinitely
        while (true)
        {
            // Toggle the visibility
            timerIcon.enabled = !timerIcon.enabled;

            // Wait for the specified interval
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}