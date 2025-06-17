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
    [Header("Chan Buttons")]
    public UnityEngine.UI.Image chanImage1;
    public Sprite chanSprite;
    public Sprite chanSprite2;
    [Header("Levels")]
    public GameObject startUI;
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    [Header("Time")]
    public float currentTime;
    public float timeStart = 7f;
    public TextMeshProUGUI timerText;
    public bool timeRun = false;
    public bool timeEnd = false;
    [Header("Extras")]
    public bool found = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startUI.SetActive(true);
        chanImage1.sprite = chanSprite;

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
        StartCoroutine(StartUI(3));
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
        if (timeEnd == true)
        {
            
        }
    }

    public void ChanFound()
    {
        if (timeEnd != true)
        {
            if (GlobalMetrics.level == 1)
            {
                found = true;
                chanButton1.interactable = false;
                chanImage1.sprite = chanSprite2;
                Debug.Log("Found!");
            }
            else if (GlobalMetrics.level == 2)
            {

            }
            else if (GlobalMetrics.level == 3)
            {

            }
            
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
            level1.SetActive(true);
            timeRun = true;
        }
        else if (GlobalMetrics.level == 2)
        {
            level2.SetActive(true);
            timeRun = true;
        }
        else if (GlobalMetrics.level == 3)
        {
            level3.SetActive(true);
            timeRun = true;
        }
    }
}
