using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TheEnd : MonoBehaviour
{
    //THIS IS OLI'S SCRIPT!!!!!!
    public VideoPlayer videoPlayer;

    public UnityEngine.UI.Image image;
    public Sprite newSprite1;
    public Sprite newSprite2;
    public Sprite newSprite3;
    public int imageNum = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        videoPlayer.time = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.time > 150)
        {
            videoPlayer.Stop();
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
            imageNum = 0;
        }

       
    }
}
