using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using static Readme;
using System.Linq;

public enum VideoCategory
{
    A,
    B,
    C
}

[System.Serializable]
public class VideoEntry
{
    public VideoCategory category;
    public List<VideoClip> videoClips;
}

[System.Serializable]
public struct VideoHistoryEntry
{
    public VideoEntry videoEntry;
    public VideoClip videoClip;
}

public class VideoManager : MonoBehaviour
{
    public List<VideoEntry> videoPool;
    private Dictionary<VideoCategory, int> likeCounts;
    public RawImage displayImage;

    public RectTransform currentImageRectTransform;
    public RectTransform nextImageRectTransform;
    public float swipeSpeed = 1f;
    public Image likeButtonImage; // Assign in the inspector
    public Sprite likeSprite; // Assign in the inspector
    public Sprite likedSprite; // Assign in the inspector

    private Vector2 nextImageStartPosition;
    private float lastTapTime = 0f;
    private float tapTimeThreshold = 0.2f; // Time in seconds for double tap

    private VideoEntry currentVideoEntry;

    public CategoryUI categoryUI;
    private VideoCategory favoriteCategory;
    private float happinessValue;
    public HappinessBar happinessBar;
    public float maxHappinessValue = 10f;

    private float anxietyValue = 0f;
    private float maxAnxietyValue = 10f;
    private bool isMissFavoriteVideo = false;
    public AnxietyBar anxietyBar;

    private float elapsedTime;
    private float valueUpdateInterval = 1.0f;
    private float nextValueUpdateTime = 0;

    private Stack<VideoHistoryEntry> videoHistory = new Stack<VideoHistoryEntry>();
    private int currentTextureIndex = 0;

    public bool isOnTable = false;

    public FavoriteCategory favoriteCategoryClass;

    private bool isLike;

    public VideoPlayer currentVideoPlayer;
    public VideoPlayer nextVideoPlayer;

    public GameStartSwipeController gameStartSwipeController;

    private bool isEndGame;

    public Image winLosePanel;
    public List<Sprite> winLoseImages = new List<Sprite>();

    private int stupidCounter = 0;
    private bool isCurrentVideoPlayer = false;
    private bool isSwipeUp = false;

    void Start()
    {
        // Initialize likeCounts
        likeCounts = new Dictionary<VideoCategory, int>{
        {VideoCategory.A, 0},
        {VideoCategory.B, 0},
        {VideoCategory.C, 0}
    };

        // Set and play the first video
        VideoEntry firstVideoEntry = GetNextVideoEntry();
        PlayVideo(firstVideoEntry, currentVideoPlayer);

        currentVideoEntry = firstVideoEntry;

        PrepareNextVideo();
        DisplayNextPlaceholder();

        // Initialize values and favorite category
        InitializeValues();

        isLike = false;
        isEndGame = false;
    }

    private void PlayVideo(VideoEntry videoEntry, VideoPlayer videoPlayer)
    {
        int videoClipIndex = UnityEngine.Random.Range(0, videoEntry.videoClips.Count);
        videoPlayer.clip = videoEntry.videoClips[videoClipIndex];
        videoPlayer.Play();
    }

    private void PrepareNextVideo()
    {
        VideoEntry nextVideoEntry;
        do
        {
            nextVideoEntry = GetNextVideoEntry();
        }
        while (nextVideoEntry == currentVideoEntry); // Ensure the next video is not the same as the current one

        int nextVideoClipIndex = UnityEngine.Random.Range(0, nextVideoEntry.videoClips.Count);
        nextVideoPlayer.clip = nextVideoEntry.videoClips[nextVideoClipIndex];
        nextVideoPlayer.Prepare(); // Preload the video
    }

    private void InitializeValues()
    {
        anxietyValue = Mathf.Clamp(anxietyValue, 0, maxAnxietyValue);
        happinessValue = Mathf.Clamp(happinessValue, 0, maxHappinessValue);
        favoriteCategory = favoriteCategoryClass.favoriteCategory;
        Debug.Log("Actual favorite:" + favoriteCategory);
    }

    void Update()
    {
        // if (!isEndGame)
        // {
        //     if (!isOnTable)
        //     {
        //         elapsedTime += Time.deltaTime;

        //         float decreaseAmount = (0.25f * Time.deltaTime) / valueUpdateInterval;
        //         anxietyValue += decreaseAmount;

        //         UpdateAnxiety();

        //         if (elapsedTime >= nextValueUpdateTime)
        //         {
        //             nextValueUpdateTime += valueUpdateInterval;
        //         }
        //     }
        //     else
        //     {
        //         elapsedTime += Time.deltaTime;

        //         float decreaseAmount = (0.25f * Time.deltaTime) / valueUpdateInterval;
        //         anxietyValue -= decreaseAmount;

        //         UpdateAnxiety();

        //         if (elapsedTime >= nextValueUpdateTime)
        //         {
        //             nextValueUpdateTime += valueUpdateInterval;
        //         }
        //     }

        //     if (anxietyValue >= maxAnxietyValue)
        //     {
        //         anxietyValue = maxAnxietyValue;
        //         GameLose();
        //         isEndGame = true;
        //         anxietyValue = 0;
        //         happinessValue = 0;
        //     }
        //     else if (anxietyValue < 0)
        //     {
        //         anxietyValue = 0;
        //     }

        //     if (happinessValue >= maxHappinessValue)
        //     {
        //         happinessValue = maxHappinessValue;
        //         GameWin();
        //         isEndGame = true;
        //         anxietyValue = 0;
        //         happinessValue = 0;
        //     }
        //     else if (happinessValue < 0)
        //     {
        //         happinessValue = 0;
        //     }
        // }

        if ((Input.GetMouseButtonDown(0)) && isEndGame)
        {
            // Restart the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }

        Debug.Log("Is Current Video Player:" + isCurrentVideoPlayer);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2 && Time.time - lastTapTime < tapTimeThreshold)
        {
            LikeCurrentVideo();
            //StartCoroutine(LikeAnimation());
        }
        lastTapTime = Time.time;
    }

    public void LikeCurrentVideo()
    {
        if (!isLike)
        {
            isLike = true;
            //likeCounts[GetCurrentVideoCategory()]++;
            // Additional logic to update UI or other elements here
            Debug.Log("Liked video in category: " + GetCurrentVideoCategory());

            // if (GetCurrentVideoCategory() == favoriteCategory)
            // {
            //     UpdateHappiness();
            //     isMissFavoriteVideo = false;
            // }
            // else
            // {
            //     anxietyValue++;
            //     UpdateAnxiety();
            // }
        }
    }

    // Method to get the next video/placeholder.
    public VideoClip GetNextVideoClip()
    {
        List<VideoClip> weightedList = new List<VideoClip>();
        foreach (var entry in videoPool)
        {
            int likeValue = likeCounts[entry.category];
            int weight = Mathf.Max(1, 10 - likeValue);
            for (int i = 0; i < weight; i++)
            {
                weightedList.AddRange(entry.videoClips);
            }
        }

        int randomIndex = UnityEngine.Random.Range(0, weightedList.Count);
        return weightedList[randomIndex];
    }

    private VideoEntry GetNextVideoEntry()
    {
        List<VideoEntry> weightedList = new List<VideoEntry>();
        foreach (var entry in videoPool)
        {
            int likeValue = likeCounts[entry.category];
            // The lower the likes, the higher the chance to appear
            int weight = Mathf.Max(1, 10 - likeValue);
            for (int i = 0; i < weight; i++)
            {
                weightedList.Add(entry);
            }
        }

        // Randomly select from the weighted list
        int randomIndex = UnityEngine.Random.Range(0, weightedList.Count);
        return weightedList[randomIndex];
    }

    public void DisplayNextPlaceholder()
    {
        if (currentVideoEntry != null)
        {
            videoHistory.Push(new VideoHistoryEntry
            {
                videoEntry = currentVideoEntry,
                videoClip = currentVideoPlayer.clip
            });
        }

        StartCoroutine(SwipeTransition(() => {
            SwapVideoPlayers();

            // Find the VideoEntry that contains the clip currently playing
            currentVideoEntry = videoPool.FirstOrDefault(entry => entry.videoClips.Contains(currentVideoPlayer.clip));

            currentVideoPlayer.Play();
            PrepareNextVideo();
        }));
    }

    public void DisplayPreviousPlaceholder()
    {
        if (videoHistory.Count > 0)
        {
            VideoHistoryEntry previousEntry = videoHistory.Pop();

            StartCoroutine(SwipeTransitionDown(() => {
                SwapVideoPlayers();

                currentVideoPlayer.clip = previousEntry.videoClip;
                currentVideoPlayer.Play();

                // Find the VideoEntry that contains the clip currently playing
                currentVideoEntry = videoPool.FirstOrDefault(entry => entry.videoClips.Contains(currentVideoPlayer.clip));

                PrepareNextVideo();
            }));
        }
    }

    private void SwapVideoPlayers()
    {
            var temp = currentVideoPlayer;
            currentVideoPlayer = nextVideoPlayer;
            nextVideoPlayer = temp;
    }

    private VideoCategory GetCurrentVideoCategory()
    {
        // Simply return the category of the current video entry
        return currentVideoEntry.category;
    }

    IEnumerator SwipeTransition(Action onTransitionComplete)
    {
        //currentImageRectTransform.GetComponent<RawImage>().raycastTarget = false;
        //nextImageRectTransform.GetComponent<RawImage>().raycastTarget = false;

        float duration = 1f / swipeSpeed;
        float elapsed = 0f;

        float moveDistance = currentImageRectTransform.rect.height;

        // Starting positions
        Vector2 currentImageStartPos = currentImageRectTransform.anchoredPosition;
        Vector2 nextImageStartPos = new Vector2(currentImageStartPos.x, currentImageStartPos.y - moveDistance);

        // Ending positions
        Vector2 currentImageEndPos = currentImageStartPos + new Vector2(0, moveDistance);
        Vector2 nextImageEndPos = currentImageStartPos;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float normalizedTime = elapsed / duration;
            currentImageRectTransform.anchoredPosition = Vector2.Lerp(currentImageStartPos, currentImageEndPos, normalizedTime);
            nextImageRectTransform.anchoredPosition = Vector2.Lerp(nextImageStartPos, nextImageEndPos, normalizedTime);

            yield return null;
        }

        currentImageRectTransform.anchoredPosition = currentImageEndPos;
        nextImageRectTransform.anchoredPosition = nextImageEndPos;

        var tempRectTransform = currentImageRectTransform;
        currentImageRectTransform = nextImageRectTransform;
        nextImageRectTransform = tempRectTransform;

        //currentImageRectTransform.GetComponent<RawImage>().raycastTarget = true;

        isLike = false;
        likeButtonImage.sprite = likeSprite;

        if (isMissFavoriteVideo == true)
        {
            anxietyValue++;
            UpdateAnxiety();
        }

        if (currentVideoEntry.category != favoriteCategory)
        {
            isMissFavoriteVideo = false;
        }
        else
        {
            isMissFavoriteVideo = true;
        }

        onTransitionComplete?.Invoke();
    }

    IEnumerator SwipeTransitionDown(Action onTransitionComplete)
    {
        // Disable interaction during the transition
        currentImageRectTransform.GetComponent<RawImage>().raycastTarget = false;
        nextImageRectTransform.GetComponent<RawImage>().raycastTarget = false;

        float duration = 1f / swipeSpeed;
        float elapsed = 0f;

        // Calculate the exact move distance based on the current image's height
        float moveDistance = currentImageRectTransform.rect.height;

        // Starting positions
        Vector2 currentImageStartPos = currentImageRectTransform.anchoredPosition;
        Vector2 nextImageStartPos = new Vector2(currentImageStartPos.x, currentImageStartPos.y + moveDistance);

        // Ending positions
        Vector2 currentImageEndPos = currentImageStartPos - new Vector2(0, moveDistance);
        Vector2 nextImageEndPos = currentImageStartPos; // Next image moves to where the current image was

        while (elapsed < duration)
        {
            // Update elapsed time
            elapsed += Time.deltaTime;

            // Calculate the next position based on the elapsed time
            float normalizedTime = elapsed / duration;
            currentImageRectTransform.anchoredPosition = Vector2.Lerp(currentImageStartPos, currentImageEndPos, normalizedTime);
            nextImageRectTransform.anchoredPosition = Vector2.Lerp(nextImageStartPos, nextImageEndPos, normalizedTime);

            yield return null;
        }

        // After the transition, reposition and prepare for the next swipe
        currentImageRectTransform.anchoredPosition = currentImageEndPos;
        nextImageRectTransform.anchoredPosition = nextImageEndPos;

        // Swap references so next becomes current
        var tempRectTransform = currentImageRectTransform;
        currentImageRectTransform = nextImageRectTransform;
        nextImageRectTransform = tempRectTransform;

        // Enable interaction on the new current image
        currentImageRectTransform.GetComponent<RawImage>().raycastTarget = true;

        likeButtonImage.sprite = likeSprite;

        onTransitionComplete?.Invoke();
    }


    void UpdateHappiness()
    {
        happinessValue = (float)likeCounts[favoriteCategory];
        happinessBar.SetHealth(happinessValue, maxHappinessValue);
    }

    void UpdateAnxiety()
    {
        anxietyBar.SetHealth(anxietyValue, maxAnxietyValue);
    }

    void GameWin()
    {
        gameStartSwipeController.WinLose();
        winLosePanel.sprite = winLoseImages[0];
    }

    void GameLose()
    {
        gameStartSwipeController.WinLose();
        winLosePanel.sprite = winLoseImages[1];
    }
}