using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour
{
    public GameObject LeftArrow;
    public GameObject RightArrow;
    public GameObject UpArrow;
    public GameObject DownArrow;
    public Transform parentObject;
    public TMPro.TextMeshProUGUI Lives;
    public int LivesCount = GlobalMetrics.lives;
    public TMPro.TextMeshProUGUI TimeText;
    static public float TimeGame;

    public float spawnInterval = 0.5f;
    static public float timer = 0f;

    private List<GameObject> spawnedArrows = new List<GameObject>();
    private void Start()
    {
        TimeGame = 5f;
    }
    void Update()
    {
        Lives.text = "Lives: " + GlobalMetrics.lives.ToString();
        TimeGame -= Time.deltaTime;
        TimeText.text = "Time: " + Mathf.RoundToInt(TimeGame).ToString();
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnRandomArrow();
            timer = 0f;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RemoveFirstArrowWithTag("Left");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RemoveFirstArrowWithTag("Right");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            RemoveFirstArrowWithTag("Up");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            RemoveFirstArrowWithTag("Down");
        }
        if (TimeGame <= 0)
        {
            TimeText.text = "Time: 0";
            foreach (GameObject arrow in spawnedArrows)
            {
                Destroy(arrow);
            }
            spawnedArrows.Clear();
            Lives.text = "Lives: " + GlobalMetrics.lives.ToString();
        }
    }

    void SpawnRandomArrow()
    {
        GameObject[] arrowPrefabs = { LeftArrow, RightArrow, UpArrow, DownArrow };
        string[] arrowTags = { "Left", "Right", "Up", "Down" };
        int randomIndex = Random.Range(0, arrowPrefabs.Length);

        GameObject newArrow = Instantiate(arrowPrefabs[randomIndex], parentObject);
        newArrow.transform.localPosition = new Vector3(Random.Range(-200f, 200f), Random.Range(-500f, 500f), 0f);

        newArrow.tag = arrowTags[randomIndex];
        spawnedArrows.Add(newArrow);
    }

    void RemoveFirstArrowWithTag(string tag)
    {
        for (int i = 0; i < spawnedArrows.Count; i++)
        {
            if (spawnedArrows[i] != null && spawnedArrows[i].tag == tag)
            {
                Destroy(spawnedArrows[i]);
                spawnedArrows.RemoveAt(i);
                break;
            }
        }
    }
}
