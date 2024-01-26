using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class DoubleTapLike : MonoBehaviour, IPointerClickHandler
{
    public VideoManager videoManager;
    public Image likeButtonImage; // Assign in the inspector
    public Sprite likeSprite; // Assign in the inspector
    public Sprite likedSprite; // Assign in the inspector

    private float lastTapTime = 0f;
    private float tapTimeThreshold = 0.4f; // Time in seconds for double tap

    public GameObject likeGameObject; // Assign the like GameObject in the inspector

    public void OnPointerClick(PointerEventData eventData)
    {
        if ((Time.time - lastTapTime) < tapTimeThreshold)
        {
            HandleLike(eventData.position);
        }
        lastTapTime = Time.time;
    }

    private void HandleLike(Vector2 tapPosition)
    {
        Debug.Log("Liked!");

        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(tapPosition);

        likeGameObject.transform.position = worldPosition;
        likeGameObject.SetActive(true);

        videoManager.LikeCurrentVideo();

        StartCoroutine(LikeAnimation());
    }

    private IEnumerator LikeAnimation()
    {
        StartCoroutine(ButtonLikeAnimation());

        likeGameObject.transform.localScale = Vector3.one * 1.2f;

        yield return new WaitForSeconds(0.2f);

        likeGameObject.transform.localScale = Vector3.one;

        yield return new WaitForSeconds(0.2f);

        likeGameObject.SetActive(false);
    }

    public void LikeButtonClicked()
    {
        HandleLikeButton();
    }

    private void HandleLikeButton()
    {
        Debug.Log("Liked!");
        //if ((Time.time - lastTapTime) < tapTimeThreshold)
        //{
            videoManager.LikeCurrentVideo();

            StartCoroutine(ButtonLikeAnimation());
        //}

        lastTapTime = Time.time;
    }

    private IEnumerator ButtonLikeAnimation()
    {
        likeButtonImage.transform.localScale = new Vector3(1.2f, 1.2f, 1f);

        yield return new WaitForSeconds(0.1f);

        likeButtonImage.transform.localScale = Vector3.one;
        likeButtonImage.sprite = likedSprite;
    }
}
