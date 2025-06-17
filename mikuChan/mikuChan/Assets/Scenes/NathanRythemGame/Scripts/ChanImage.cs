using UnityEngine;
using UnityEngine.UI;

public class ChanImage : MonoBehaviour
{
    public Image targetImage; 
    public Sprite leftSprite;
    public Sprite rightSprite;
    public Sprite upSprite;
    public Sprite downSprite;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            targetImage.sprite = leftSprite;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            targetImage.sprite = rightSprite;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            targetImage.sprite = upSprite;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            targetImage.sprite = downSprite;
        }
    }
}
