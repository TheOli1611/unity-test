using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Threading;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Rendering;

public class TheEnd : MonoBehaviour
{
    //THIS IS OLI'S SCRIPT!!!!!!
    [Header("Video Player")]
    public VideoPlayer videoPlayer;

    [Header("Chan Images")]
    public UnityEngine.UI.Image image;
    public Sprite newSprite1;
    public Sprite newSprite2;
    public Sprite newSprite3;
    public Sprite newSprite4;
    public Sprite newSprite5;
    public int imageNum = 0;

    [Header("Clicker Images")]
    public UnityEngine.UI.Image clicker1;
    public UnityEngine.UI.Image clicker2;
    public Sprite clickerImage1;
    public Sprite clickerImage2;
    public Sprite clickerImage3;
    public Sprite clickerImage4;
    public int clickNum = 0;
    public Button clickButton;
    [Header("Ready UI")]
    public Button readyButton;
    public GameObject readyUI;
    [Header("Animation")]
    public Animator animator;
    public Animator chanAnimator;
    public Sprite passImage;
    public Sprite failImage;
    public Sprite failImage2;
    public bool played = false;
    public bool stopLog = false;
    [Header("Time")]
    public float currentTime;
    public float timeStart = 10f;
    public TextMeshProUGUI timerText;
    public bool timeRun = false;
    public bool timeEnd = false;
    [Header("Clicks")]
    public int clicks = 0;
    public bool pass = false;
    public TextMeshProUGUI counterText;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        videoPlayer.Stop();

        if (GlobalMetrics.level == 1)
        {
            timeStart = 10f;
        }
        else if (GlobalMetrics.level == 2)
        {
            timeStart = 7f;
        }
        else if (GlobalMetrics.level == 3)
        {
            timeStart = 5f;
        }

        //timeStart = 5f;
        currentTime = timeStart;
        TimeTextUpdate(currentTime);
        timeEnd = false;
        GlobalMetrics.totalLevelsPlayed += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.time > 153f)
        {
            videoPlayer.Stop();
        }

        if (timeRun == true)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                TimeTextUpdate(currentTime);
            }
            else
            {
                currentTime = 0;
                timeRun = false;
                TimeTextUpdate(currentTime);
                timeEnd = true;
                animator.SetTrigger("end");
            }
        }
        if (timeEnd == true)
        {
            clickButton.interactable = false;
            chanAnimator.SetTrigger("chanEnd");
        }
        if (GlobalMetrics.level == 1 && timeEnd == true)
        {
            if (timeEnd == true && clicks >= 45 && stopLog == false)
            {
                pass = true;
                videoPlayer.time = 150f;
                StartCoroutine(PassAnim(2));
                Debug.Log("pass");
                stopLog = true;
                GlobalMetrics.winner = true;
            }
            else if (timeEnd == true && clicks < 45 && stopLog == false)
            {
                videoPlayer.time = 153f;
                videoPlayer.Stop();
                pass = false;
                StartCoroutine(FailAnim(2));
                Debug.Log("fail");
                stopLog = true;
                GlobalMetrics.winner = false;
            }

        }
        else if (GlobalMetrics.level == 2)
        {
            if (timeEnd == true && clicks > 30 && stopLog == false)
            {
                pass = true;
                videoPlayer.time = 150f;
                StartCoroutine(PassAnim(2));
                Debug.Log("pass");
                stopLog = true;
                GlobalMetrics.winner = true;
            }
            else if (timeEnd == true && clicks < 30 && stopLog == false)
            {
                videoPlayer.time = 153f;
                videoPlayer.Stop();
                pass = false;
                StartCoroutine(FailAnim(2));
                Debug.Log("fail");
                stopLog = true;
                GlobalMetrics.winner = false;
            }
        }
        else if (GlobalMetrics.level == 3)
        {
            if (timeEnd == true && clicks > 25 && stopLog == false)
            {
                pass = true;
                videoPlayer.time = 150f;
                StartCoroutine(PassAnim(2));
                Debug.Log("pass");
                stopLog = true;
                GlobalMetrics.winner = true;
            }
            else if (timeEnd == true && clicks < 25 && stopLog == false)
            {
                videoPlayer.time = 153f;
                videoPlayer.Stop();
                pass = false;
                StartCoroutine(FailAnim(2));
                Debug.Log("fail");
                stopLog = true;
                GlobalMetrics.winner = false;
            }
        }
    }

    public void NewImage()
    {
        imageNum += 1;

        if (imageNum == 1)
        {
            image.sprite = newSprite1;
        }
        else if (imageNum == 2)
        {
            image.sprite = newSprite2;
        }
        else if (imageNum == 3)
        {
            image.sprite = newSprite3;
        }
        else if (imageNum == 4)
        {
            image.sprite = newSprite4;
        }
        else if (imageNum == 5)
        {
            image.sprite = newSprite5;
            imageNum = 0;
        }


        clickNum += 1;
        if (clickNum == 1)
        {
            clicker1.sprite = clickerImage1;
            clicker2.sprite = clickerImage4;
        }
        else if (clickNum == 2)
        {
            clicker1.sprite = clickerImage2;
            clicker2.sprite = clickerImage3;
            clickNum = 0;
        }

        clicks += 1;
        Debug.Log(clicks);
        counterText.text = clicks.ToString();
    }

    public void ReadyPress()
    {
        timeRun = true;
        videoPlayer.time = 120f;
        videoPlayer.Play();
        animator.SetTrigger("start");
        chanAnimator.SetTrigger("chanStart");
        readyUI.SetActive(false);
    }

    public void TimeTextUpdate(float currentTime)
    {
        int minutes = Mathf.FloorToInt(currentTime);
        timerText.text = minutes.ToString();
    }

    public IEnumerator PassAnim(float delay)
    {
        if (timeEnd == true)
        {
            yield return new WaitForSeconds(delay);
            image.sprite = passImage;
        }
        
    }
    public IEnumerator FailAnim(float delay)
    {
        if (timeEnd == true && played == false)
        {
            yield return new WaitForSeconds(delay);
            image.sprite = failImage;
            yield return new WaitForSeconds(delay - 1);
            image.sprite = failImage2;
            played = true;
        }
        if (played == true)
        {
            image.sprite = failImage2;
        }
        
    }
}
