using UnityEngine;
using System.Collections;


public class ChanScript : MonoBehaviour
{
    // allows for selecting differnt game modes to be easier and accessable in the inspector
    public enum minigame
    {
        Oli1, Oli2,
        Lucas1, Lucas2,
        Nathan1, Nathan2
    }

    public minigame mikuGame;

    [Header("Miku Chan Sprites")]
    [SerializeField] Sprite[] mesmerizerSpri;
    [SerializeField] Sprite[] popipoSpri;
    [SerializeField] Sprite[] loseSpri;

    SpriteRenderer mySprite;


    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
    }


    int i = 0;
    float testSptiteTimer;
    float testSpriteTime = 0.3f;
    public int popipoper; // flips chan
    // Update is called once per frame
    void Update()
    {
        testSptiteTimer += Time.deltaTime;
        if (testSptiteTimer >= 0.4 && mikuGame == minigame.Lucas1)
        {
            mySprite.sprite = mesmerizerSpri[i];
            if (i < mesmerizerSpri.Length - 1) i++;
            else i = 0;

            testSptiteTimer = 0;
        } 
    }
}
