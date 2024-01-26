using UnityEngine;

public class SwipeController : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector2 currentSwipe;
    private bool isSwiping = false;

    public float minSwipeLength = 30f;
    public VideoManager videoManager;

    public GameStartSwipeController gameStartSwipeController;

    void Update()
    {
        StartSwipe();
        EndSwipe();

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!gameStartSwipeController.isCommentOpened)
            {
                Debug.Log("Simulate swipe up");
                videoManager.DisplayNextPlaceholder();
            }
            else
            {

            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (!gameStartSwipeController.isCommentOpened)
            {
                Debug.Log("Simulate swipe down");
                videoManager.DisplayPreviousPlaceholder();
            }
            else
            {
                gameStartSwipeController.OpenComment();
            }
        }
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

            if (currentSwipe.magnitude > minSwipeLength)
            {
                if (Mathf.Abs(currentSwipe.y) > Mathf.Abs(currentSwipe.x))
                {
                    if (currentSwipe.y > 0)
                    {
                        if (!gameStartSwipeController.isCommentOpened)
                        {
                            Debug.Log("Swipe Up");
                            videoManager.DisplayNextPlaceholder();
                        }
                        else
                        {

                        }
                    }
                    else if (currentSwipe.y < 0)
                    {
                        if (!gameStartSwipeController.isCommentOpened)
                        {
                            Debug.Log("Swipe Down");
                            videoManager.DisplayPreviousPlaceholder();
                        }
                        else
                        {
                            gameStartSwipeController.OpenComment();
                        }
                    }
                }
            }
        }
    }
}
