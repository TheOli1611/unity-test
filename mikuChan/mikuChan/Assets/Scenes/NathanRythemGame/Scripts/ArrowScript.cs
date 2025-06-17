using UnityEngine;
using TMPro;

public class ArrowScript : MonoBehaviour
{
    public float Uptime;
    public TextMeshProUGUI LeftText;
    public TextMeshProUGUI Righttext;
    public TextMeshProUGUI UpText;
    public TextMeshProUGUI DownText;
    void Start()
    {
        Uptime = 1f;
    }


    void Update()
    {
        Uptime -= Time.deltaTime;
        if (Uptime <= 0f)
        {
            GlobalMetrics.lives--;
            Destroy(gameObject);
            ArrowSpawn.TimeGame = 0f;
        }

        LeftText.text = Uptime.ToString();

    }
}
