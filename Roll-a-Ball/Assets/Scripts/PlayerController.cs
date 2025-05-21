using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject resetText;
    public GameObject winTextObject;
    private Scene scene;
    private int stage;
    private Vector3 vector3;

    public Transform playerSpawn;
    public AudioSource death;
    public AudioSource Level1Music;
    public AudioSource collect;
    public AudioSource Level2Music;
    public AudioSource Level3Music;
    public AudioSource Level4Music;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        scene = SceneManager.GetActiveScene();

        if (scene.name.Equals("Minigame"))
        {
            stage = 1;
            Level1Music.Play();
        }
        else if (scene.name.Equals("Level 2"))
        {
            stage = 2;
            Level2Music.Play();
        }
        else if (scene.name.Equals("Level 3"))
        {
            stage = 3;
            Level3Music.Play();
        }
        else if (scene.name.Equals("Level 4"))
        {
            stage = 4;
            Level4Music.Play();
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }
    private void Update()
    {
        if (stage == 1)
        {
            if (gameObject.transform.position.y < 10)
            {
                gameObject.transform.position = playerSpawn.transform.position;
            }
        }

        if (stage == 2)
        {
            if (gameObject.transform.position.y < 5)
            {
                gameObject.transform.position = playerSpawn.transform.position;
            }
        }

        if (stage == 3)
        {
            if (gameObject.transform.position.y < -4)
            {
                gameObject.transform.position = playerSpawn.transform.position;
            }
        }

        if (stage == 4)
        {
            if (gameObject.transform.position.y < -20)
            {
                Debug.Log("detected");
                gameObject.transform.position = playerSpawn.transform.position;
            }
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            collect.Play();
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        if (stage == 1)
        {
            if (count >= 6)
            {
                winTextObject.SetActive(true);
                winTextObject.GetComponent<TextMeshProUGUI>().text = "You Win!\nTeleporting...";
                Destroy(GameObject.FindGameObjectWithTag("Enemy"));
                StartCoroutine(NextScene(3));
            }
        }
        if (stage == 2)
        {
            if (count >= 13)
            {
                winTextObject.SetActive(true);
                winTextObject.GetComponent<TextMeshProUGUI>().text = "You Win!\nTeleporting...";
                Destroy(GameObject.FindGameObjectWithTag("Enemy"));
                StartCoroutine(NextScene(3));
            }
        }
        if (stage == 3)
        {
            if (count >= 12)
            {
                winTextObject.SetActive(true);
                resetText.SetActive(false);
                winTextObject.GetComponent<TextMeshProUGUI>().text = "You Win!\nTeleporting...";
                StartCoroutine(NextScene(3));
            }

        }
        if (stage == 4)
        {
            if (count >= 11)
            {
                winTextObject.SetActive(true);
                resetText.SetActive(false);
                winTextObject.GetComponent<TextMeshProUGUI>().text = "You Win!";
                StartCoroutine(GameEndScene(3));
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            death.Play();
            StartCoroutine(GameOverScene(3));
            Debug.Log("timer start");
            // Destroy the current object
            gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            // Update the winText to display "You Lose!"
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
            
        }
    }

    public IEnumerator NextScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(stage);
    }

    public IEnumerator GameOverScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("timer end");
        SceneManager.LoadScene("GameOver");
        Debug.Log("change scene");
    }
    public IEnumerator GameEndScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameEnd");
    }
}


