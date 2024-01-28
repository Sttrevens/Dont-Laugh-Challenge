using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageCommentManager : MonoBehaviour
{
    public GameObject commentPrefab; // Assign your comment prefab
    public Sprite[] commentImages; // Array of your pre-designed comment images
    public float commentSpeed = 1f; // Speed at which comments move
    public float commentLifetime = 5f; // Time before a comment fades out
    public float baseHeight = 50f; // Base height for scaling comments

    void Start()
    {
        StartCoroutine(GenerateComments());
    }

    IEnumerator GenerateComments()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // Time between comments

            // Instantiate a new comment
            GameObject newComment = Instantiate(commentPrefab, transform.position, Quaternion.identity, transform);
            Image commentImage = newComment.GetComponent<Image>();
            RectTransform rectTransform = newComment.GetComponent<RectTransform>();
            commentImage.preserveAspect = true;

            // Set the comment image based on your condition
            Sprite selectedSprite = YourCondition() ? commentImages[Random.Range(0, 6)] : commentImages[Random.Range(6, 12)];
            commentImage.sprite = selectedSprite;

            // Adjust size and align to the left
            AdjustSizeAndAlignLeft(commentImage, rectTransform);

            // Start the animation coroutine
            StartCoroutine(MoveAndFadeComment(newComment));
        }
    }

    void AdjustSizeAndAlignLeft(Image image, RectTransform rectTransform)
    {
        float aspectRatio = image.sprite.bounds.size.x / image.sprite.bounds.size.y;
        float height = baseHeight;
        float width = height * aspectRatio;
        rectTransform.sizeDelta = new Vector2(width, height);

        // Set pivot and anchor to left
        rectTransform.pivot = new Vector2(0, 0.5f);
        rectTransform.anchorMin = new Vector2(0, 0.5f);
        rectTransform.anchorMax = new Vector2(0, 0.5f);
        rectTransform.anchoredPosition = Vector2.zero; // Align to the left
    }

    IEnumerator MoveAndFadeComment(GameObject comment)
    {
        float elapsedTime = 0;
        CanvasGroup canvasGroup = comment.AddComponent<CanvasGroup>(); // For fading

        while (elapsedTime < commentLifetime)
        {
            comment.transform.Translate(Vector3.up * commentSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;

            // Fade out effect in the last seconds
            if (elapsedTime > commentLifetime - 1)
            {
                canvasGroup.alpha = 1 - (elapsedTime - (commentLifetime - 1));
            }

            yield return null;
        }

        Destroy(comment);
    }

    bool YourCondition()
    {
        // Implement your condition here
        return true; // Placeholder
    }
}
