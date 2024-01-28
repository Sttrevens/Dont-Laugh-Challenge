using UnityEngine;
using UnityEngine.UI;
using MoodMe;

public class AdjustMouthHeight : MonoBehaviour
{
    public EmotionsManager emotionsManager;
    public RectTransform mouthRectTransform; // RectTransform of the UI Image

    public int mouthSmileIndex = 2;

    public float minHeight = 2f;
    public float maxHeight = 200f;

    void Update()
    {
        if (emotionsManager != null && mouthRectTransform != null)
        {
            // Calculate the new height based on the float value
            float newHeight = Mathf.Lerp(minHeight, maxHeight, emotionsManager.Happy * mouthSmileIndex);
            // Adjust the height of the UI Image
            mouthRectTransform.sizeDelta = new Vector2(mouthRectTransform.sizeDelta.x, newHeight);
        }
    }
}