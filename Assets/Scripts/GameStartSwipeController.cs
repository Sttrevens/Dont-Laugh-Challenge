using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartSwipeController : MonoBehaviour
{
    public RectTransform menuScreen;
    public RectTransform goalImageScreen;
    public RectTransform gameScreen;
    public RectTransform winLoseScreen;
    public RectTransform commentScreen;

    public GameObject gameStartScreen;
    public GameObject nextVideoPlaceholder;

    public float transitDuration = 0.5f;

    private int currentScreen = 0;

    public AnimationCurve swingCurve;
    public AnimationCurve commentPanelSwingCurve;

    private Vector2 startTouchPosition;
    private Vector2 currentSwipe;
    private bool isSwiping = false;

    public float minSwipeLength = 30f;

    public float screenHeight = 2530f;

    public bool isCommentOpened = false;

    void Update()
    {
        StartSwipe();
        EndSwipe();

        if (Input.GetKeyDown(KeyCode.UpArrow)) // Use actual swipe detection here
        {
            SwipeDown();
        }

        if (currentScreen == 2)
        {
            // Start the game
            StartGame();
        }
    }

    void SwipeDown()
    {
        if (currentScreen == 0)
        {
            // First swipe - move the Menu screen down and reveal the Goal Image screen
            StartCoroutine(MovePanel(menuScreen, screenHeight));
            StartCoroutine(MovePanel(goalImageScreen, screenHeight));
            StartCoroutine(MovePanel(gameScreen, screenHeight));
            StartCoroutine(MovePanel(winLoseScreen, screenHeight));
            StartCoroutine(MoveCommentPanel(commentScreen, screenHeight));
            currentScreen++;
        }
        else if (currentScreen == 1)
        {
            // Second swipe - move the Goal Image screen down and reveal the Game screen
            StartCoroutine(MovePanel(menuScreen, screenHeight));
            StartCoroutine(MovePanel(goalImageScreen, screenHeight));
            StartCoroutine(MovePanel(gameScreen, screenHeight));
            StartCoroutine(MovePanel(winLoseScreen, screenHeight));
            StartCoroutine(MoveCommentPanel(commentScreen, screenHeight));
            currentScreen++;
        }
    }

    IEnumerator MovePanel(RectTransform panel, float newY)
    {
        float duration = transitDuration;
        float elapsed = 0;
        Vector2 startPosition = panel.anchoredPosition;
        Vector2 endPosition = new Vector2(startPosition.x, startPosition.y + newY);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float curveValue = swingCurve.Evaluate(elapsed / duration);
            panel.anchoredPosition = Vector2.LerpUnclamped(startPosition, endPosition, curveValue);
            yield return null;
        }

        // Ensure the panel is exactly at the end position when done
        panel.anchoredPosition = endPosition;
    }

    IEnumerator MoveCommentPanel(RectTransform panel, float newY)
    {
        float duration = 0.25f;
        float elapsed = 0;
        Vector2 startPosition = panel.anchoredPosition;
        Vector2 endPosition = new Vector2(startPosition.x, startPosition.y + newY);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float curveValue = commentPanelSwingCurve.Evaluate(elapsed / duration);
            panel.anchoredPosition = Vector2.LerpUnclamped(startPosition, endPosition, curveValue);
            yield return null;
        }

        // Ensure the panel is exactly at the end position when done
        panel.anchoredPosition = endPosition;
    }

    IEnumerator MoveCommentPanelDown(RectTransform panel, float newY)
    {
        float duration = 0.25f;
        float elapsed = 0;
        Vector2 startPosition = panel.anchoredPosition;
        Vector2 endPosition = new Vector2(startPosition.x, startPosition.y - newY);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float curveValue = commentPanelSwingCurve.Evaluate(elapsed / duration);
            panel.anchoredPosition = Vector2.LerpUnclamped(startPosition, endPosition, curveValue);
            yield return null;
        }

        // Ensure the panel is exactly at the end position when done
        panel.anchoredPosition = endPosition;
    }

    void StartGame()
    {
        // Logic to start the game
        Debug.Log("Game Started");

        gameStartScreen.SetActive(true);
    }

    void StartSwipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Record start position
            startTouchPosition = Input.mousePosition;
            isSwiping = true;
            Debug.Log("Start Position: " + startTouchPosition);
        }
    }

    void EndSwipe()
    {
        // Check for mouse input to end the swipe
        if (Input.GetMouseButtonUp(0) && isSwiping)
        {
            Vector2 endTouchPosition = Input.mousePosition;
            Debug.Log("End Position: " + endTouchPosition);

            isSwiping = false;
            currentSwipe = endTouchPosition - startTouchPosition;
            Debug.Log("Current Swipe:" + currentSwipe);

            // Check if the swipe is long enough to be considered a swipe
            if (currentSwipe.magnitude > minSwipeLength)
            {
                // Check if the swipe is primarily vertical
                if (Mathf.Abs(currentSwipe.y) > Mathf.Abs(currentSwipe.x))
                {
                    // Check if the swipe is upwards
                    if (currentSwipe.y > 0)
                    {
                        // Swipe up detected
                        Debug.Log("Swipe Up");
                        SwipeDown();
                    }
                }
            }
        }
    }

    public void OpenComment()
    {
        if (!isCommentOpened)
        {
            StartCoroutine(MoveCommentPanel(commentScreen, screenHeight));
            isCommentOpened = true;
        }
        else
        {
            StartCoroutine(MoveCommentPanelDown(commentScreen, screenHeight));
            isCommentOpened = false;
        }
    }

    public void WinLose()
    {
        gameStartScreen.SetActive(false);
        StartCoroutine(MovePanel(menuScreen, screenHeight));
        StartCoroutine(MovePanel(goalImageScreen, screenHeight));
        StartCoroutine(MovePanel(gameScreen, screenHeight));
        StartCoroutine(MovePanel(winLoseScreen, screenHeight));
    }
}
