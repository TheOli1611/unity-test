using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{

    [SerializeField] private VideoClip win, lose, speedup, gameover, cheese;

    VideoPlayer vp;
    public RawImage image;
    float vpLength;
    bool playSpeedUp = false, playGameOver = false;

    void Start()
    {
        vp = GetComponent<VideoPlayer>();
        PlayVid();
    }

    // Update is called once per frame
    void Update()
    {
        if (vp.time >= vpLength)
        {
            Debug.Log("farts");
            if (playGameOver || playSpeedUp) PlayVid();
            else
            {
                image.color = Color.clear;
                Debug.Log("gay");
            }

        }
    }

    void PlayVid() {
        if (!playSpeedUp || !playGameOver)
        {
            // plays either lose, or loose when starting the game
            if (!GlobalMetrics.winner) vp.clip = lose;
            else if (GlobalMetrics.winner) vp.clip = win;
            else vp.clip = cheese;

            // checks otherthings because there is a second video
            if (GlobalMetrics.lives <= 0)
            {
                playGameOver = true;
                return;
            }
            else if (GlobalMetrics.totalLevelsPlayed % 5 == 0) playSpeedUp = true;
        }
        else {
            if (playGameOver) vp.clip = gameover;
            else if (playSpeedUp) vp.clip = speedup;
            playSpeedUp = false;
            playGameOver = false;

        }
        vpLength = (float)vp.length;
        vp.Play();
    }
}
