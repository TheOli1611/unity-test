using UnityEngine;
using System.Collections;


public class ChanScript : MonoBehaviour
{
    [Header("Miku Chan Sprites")]
    [SerializeField] Sprite[] loseSpri;
    [SerializeField] Sprite[] normalSpri;

    SpriteRenderer mySprite;


    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
    }

    public void ChangeSprite(Sprite sprite) { 
    mySprite.sprite = sprite;
    }
}
