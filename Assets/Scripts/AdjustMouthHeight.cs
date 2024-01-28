using UnityEngine;
using UnityEngine.UI;
using MoodMe;

public class AdjustMouthHeight : MonoBehaviour
{
    public EmotionsManager emotionsManager;
    public RectTransform mouthRectTransform; // RectTransform of the UI Image

    private float minHeight = 2f;
    private float maxHeight = 60f;

    void Update()
    {
        if (emotionsManager != null && mouthRectTransform != null)
        {
            // Calculate the new height based on the float value
            float newHeight = Mathf.Lerp(minHeight, maxHeight, emotionsManager.Happy);
            // Adjust the height of the UI Image
            mouthRectTransform.sizeDelta = new Vector2(mouthRectTransform.sizeDelta.x, newHeight * 2);
        }
    }
}