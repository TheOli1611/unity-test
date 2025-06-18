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

public class FindChan : MonoBehaviour
{
    //OLI'S SCRIPT AGAIN!!!!
    //im insane
    [Header("Chan Buttons")]
    public Button chanButton1;
    public GameObject chanButtonUI;
    public RectTransform buttonPos;
    public RectTransform lvl1Pos;
    public RectTransform lvl2Pos;
    public RectTransform lvl3Pos;
    [Header("Chan Images")]
    public UnityEngine.UI.Image chanImage1;
    public Sprite chanSprite;
    public Sprite chanSprite2;
    public Sprite chanSprite3;
    [Header("Levels")]
    public GameObject startUI;
    public GameObject level1;
    [Header("Time")]
    public float currentTime;
    public float timeStart = 7f;
    public TextMeshProUGUI timerText;
    public bool timeRun = false;
    public bool timeEnd = false;
    [Header("Extras")]
    public bool found = false;
    public AudioSource check;
    public AudioSource yippie;
    public AudioSource lose;
    public Animator bgAnim;
    public TextMeshProUGUI winloseText;
    public GameObject winloseUI;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startUI.SetActive(true);
        chanImage1.sprite = chanSprite;
        chanButtonUI.SetActive(false);
        winloseUI.SetActive(false);
        level1.SetActive(true);

        if (GlobalMetrics.level == 1)
        {
            timeStart = 7f;
        }
        else if (GlobalMetrics.level == 2)
        {
            timeStart = 5f;
        }
        else if (GlobalMetrics.level == 3)
        {
            timeStart = 3f;
        }

        currentTime = timeStart;
        TimeTextUpdate(currentTime);
        timeEnd = false;
        GlobalMetrics.totalLevelsPlayed += 1;
        StartCoroutine(StartUI(2));
    }

    // Update is called once per frame
    void Update()
    {
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
            }
        }
        if (timeEnd == true && found == false)
        {
            bgAnim.SetTrigger("bgEnd");
            chanImage1.sprite = chanSprite3;
            check.Stop();
            lose.Play();
            winloseText.text = "Didn't find him :(";
            winloseUI.SetActive(true);
            GlobalMetrics.winner = false;
        }
    }

    public void ChanFound()
    {
        if (timeEnd != true)
        {
            found = true;
            chanButton1.interactable = false;
            chanImage1.sprite = chanSprite2;
            Debug.Log("Found!");
            bgAnim.SetTrigger("bgEnd");
            timeRun = false;
            yippie.time = 1f;
            yippie.Play();
            check.Stop();
            winloseText.text = "Found!";
            winloseUI.SetActive(true);
            GlobalMetrics.winner = true;
        }
    }

    public void TimeTextUpdate(float currentTime)
    {
        int minutes = Mathf.FloorToInt(currentTime);
        timerText.text = minutes.ToString();
    }

    public IEnumerator StartUI(float delay)
    {
        yield return new WaitForSeconds(delay);
        startUI.SetActive(false);
        if (GlobalMetrics.level == 1)
        {
            timeRun = true;
            check.time = 74f;
            check.Play();
            buttonPos.anchoredPosition = lvl1Pos.anchoredPosition;
            chanButtonUI.SetActive(true);
            bgAnim.SetTrigger("bgStart");
        }
        else if (GlobalMetrics.level == 2)
        {
            timeRun = true;
            check.time = 74f;
            check.Play();
            buttonPos.anchoredPosition = lvl2Pos.anchoredPosition;
            chanButtonUI.SetActive(true);
            bgAnim.SetTrigger("bgStart2");
        }
        else if (GlobalMetrics.level == 3)
        {
            timeRun = true;
            check.time = 74f;
            check.Play();
            buttonPos.anchoredPosition = lvl3Pos.anchoredPosition;
            chanButtonUI.SetActive(true);
            bgAnim.SetTrigger("bgStart3");
        }
    }
}
