using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    public Image countdownImage;
    public Sprite[] countdownNumbers; // Assign sprites for 3, 2, 1 in the inspector
    public float timeBetweenNumbers = 1f; // Time between changing numbers

    private void Start()
    {
        StartCoroutine(CountdownRoutine());
    }

    private IEnumerator CountdownRoutine()
    {
        for (int i = 0; i < countdownNumbers.Length; i++)
        {
            countdownImage.sprite = countdownNumbers[i];
            yield return new WaitForSeconds(timeBetweenNumbers);
        }
        countdownImage.gameObject.SetActive(false); // Hide the image after countdown
    }
}
