using MoodMe;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Created by Alberto Alvarado Jr
public class DetectionInput : MonoBehaviour
{
    //variables
    #region
    public EmotionsManager emotions;
    public Slider timeSlider;
    public Image emoImage;
    public Sprite sad, happy, neutral, surprised;
    public Text timerText, pointsText, passedText;
    public GameObject restartButton, results, playButton, pauseButton, closeButton, instructionText, slider ;
    bool playing, addPoint, endGame;
    float timeTillNext;
    float timer, waitTimer;
    int emotionCount;
    int prevEmotionCount;
    int curPoints, totalEmotionsDisplayed;
    AudioSource soundEffects;
    public AudioSource camAudio;
     public AudioClip right, wrong, fastSong;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        soundEffects = GetComponent<AudioSource>();
        emotionCount = Random.Range(0,4);
        timer = 20;
        emoImage.enabled = false;
        playing = false;
        slider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GamePlay();
        if (endGame)
            EndGame();

        if (timer < 0)
        {
            endGame = true;
            playing = false;
        }
     
    }   
    void GamePlay()
    {
        if (playing)
        {
            emoImage.enabled = true;
            slider.SetActive(true);
            passedText.enabled = false;
            timerText.enabled = true;
            pointsText.enabled = true;
            pauseButton.SetActive(true);
            timer -= Time.deltaTime;
            timeTillNext += Time.deltaTime;
            int a = (int)timer;
            timerText.text = a.ToString();
            timeSlider.value = timeTillNext;
            if (timeTillNext >= 5)
            {
                SwitchEmotions();
            }

            switch (emotionCount)
            {
                case 0:
                    waitTimer -= Time.deltaTime;
                    if(waitTimer <= 0)
                    {
                        emoImage.sprite = happy;
                        Happy();
                    }
                    break;
                case 1:
                    waitTimer -= Time.deltaTime;
                    if (waitTimer <= 0)
                    {
                        emoImage.sprite = surprised;
                        Surprised();
                    }
                    break;
                case 2:
                    waitTimer -= Time.deltaTime;
                    if (waitTimer <= 0)
                    {
                        emoImage.sprite = sad;
                        Sad();
                    }
                    break;
                case 3:
                    waitTimer -= Time.deltaTime;
                    if (waitTimer <= 0)
                    {
                        emoImage.sprite = neutral;
                        Neutral();
                    }
                    break;
            }
        }
       
    }

    void EndGame()
    {
        emoImage.enabled = false;
        timerText.enabled = false;
        pointsText.enabled = false;
        passedText.enabled = true;
        passedText.text = "Completed " + curPoints.ToString() + " out of " + totalEmotionsDisplayed.ToString() + " emotions!";
        results.SetActive(true);
        restartButton.SetActive(true);
        playButton.SetActive(false);
        pauseButton.SetActive(false);
        slider.SetActive(false);
    }
    void SwitchEmotions()
    {
        totalEmotionsDisplayed++;//counts how many emotions have been displayed
        prevEmotionCount = emotionCount;     
        emotionCount = Random.Range(0, 4);

        //checks if the previous emotion is the same as the new emotion. Then chooses another one if it is.
        if (prevEmotionCount == emotionCount) 
        {
            emotionCount = Random.Range(0, 4);
        }
        else
        {
            timeTillNext = 0;
            waitTimer = .5f;
        }
    }
    void Points(int points)
    {
        if (addPoint)
        {
            curPoints += points;
            pointsText.text = "Points: " + curPoints.ToString();
            addPoint = false;
        }
    }
  
    //emotions input from Emotion Manager Script
     #region
    void Neutral()
    {
        if (emotions.Neutral >= 0.5f && timeTillNext < 5)
        {
            soundEffects.clip = right;
            soundEffects.Play();
            addPoint = true;
            Points(1);//adds points
            SwitchEmotions();

        }
        else if (timeTillNext >= 4.5f && timeTillNext < 4.6f)
        {
            soundEffects.clip = wrong;
            soundEffects.Play();
        }
    }
    void Happy()
    {
        if (emotions.Happy >= 0.5f && timeTillNext < 5)
        {
            soundEffects.clip = right;
            soundEffects.Play();
            addPoint = true;
            Points(1);
            SwitchEmotions();

        }
        else if ( timeTillNext >= 4.5f && timeTillNext < 4.6f)
        {
            soundEffects.clip = wrong;
            soundEffects.Play();
        }
    }
    void Surprised()
    {

        if (emotions.Surprised >= 0.5f && timeTillNext < 5)
        {
            soundEffects.clip = right;
            soundEffects.Play();
            addPoint = true;
            Points(1);
            SwitchEmotions();
        }
        else if ( timeTillNext >= 4.5f && timeTillNext < 4.6f)
        {
            soundEffects.clip = wrong;
            soundEffects.Play();
        }
    }
    void Sad()
    {

        if (emotions.Sad >= 0.05f && timeTillNext < 5)
        {
            soundEffects.clip = right;
            soundEffects.Play();
            addPoint = true;
            Points(1);
            SwitchEmotions();
        }
        else if (timeTillNext >= 4.5f && timeTillNext < 4.6f)
        {
            soundEffects.clip = wrong;
            soundEffects.Play();
        }
    }
    #endregion 
    public void Play()
    {
        playing = true;
        playButton.SetActive(false);
        pauseButton.SetActive(true);
        instructionText.SetActive(false);
        camAudio.clip = fastSong;
        camAudio.Play();
    }
    public void Pause()
    {
        playing = false;
        pauseButton.SetActive(false);
        playButton.SetActive(true);
        camAudio.Pause();
        
    }
    public void QuitGame()
    {
        System.Diagnostics.Process.GetCurrentProcess().Kill();
    }
    public void Restart()
    {
        totalEmotionsDisplayed = 0;
        curPoints = 0;
        timeTillNext = 0;
        waitTimer = .5f;
        timer = 20;
        pointsText.text = "Points: " + curPoints.ToString();
        restartButton.SetActive(false);
        results.SetActive(false);
        emotionCount = Random.Range(0, 4);
        restartButton.SetActive(false);
        playing = true;
        endGame = false;
    }
}
