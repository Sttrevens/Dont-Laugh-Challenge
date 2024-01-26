using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxietyBar : MonoBehaviour
{
    private RectTransform healthBarRect;
    private float originalScaleX; // To keep the original X scale

    void Awake()
    {
        healthBarRect = GetComponent<RectTransform>();
        originalScaleX = healthBarRect.localScale.x; // Store the original X scale
        healthBarRect.localScale = new Vector3(0f, healthBarRect.localScale.y, healthBarRect.localScale.z);
    }

    public void SetHealth(float currentHealth, float maxHealth)
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure current health is within bounds

        // Calculate the new scale based on the current health
        float scaleX = (currentHealth / maxHealth) * originalScaleX;
        healthBarRect.localScale = new Vector3(scaleX, healthBarRect.localScale.y, healthBarRect.localScale.z);
    }
}