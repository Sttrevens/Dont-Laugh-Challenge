using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappinessBar : MonoBehaviour
{
    private RectTransform healthBarRect;
    private float originalScaleX;

    void Awake()
    {
        healthBarRect = GetComponent<RectTransform>();
        originalScaleX = healthBarRect.localScale.x;
        healthBarRect.localScale = new Vector3(0f, healthBarRect.localScale.y, healthBarRect.localScale.z);
    }

    public void SetHealth(float currentHealth, float maxHealth)
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        float scaleX = (currentHealth / maxHealth) * originalScaleX;
        healthBarRect.localScale = new Vector3(scaleX, healthBarRect.localScale.y, healthBarRect.localScale.z);
    }
}