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
    public GameObject winTextObject;
    private Scene scene;
    private int stage;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>(); 
        count = 0; 
        SetCountText();
        winTextObject.SetActive(false);
        scene = SceneManager.GetActiveScene();

        if(scene.name.Equals("Minigame"))
        {
            stage = 1;
        }
        else if(scene.name.Equals("Level 2"))
        {
            stage = 2;
        }
        else if(scene.name.Equals("Level 3"))
        {
            stage = 3;
        }
    }

    // Update is called once per frame
    private void FixedUpdate() 
   {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed); 
   }

    void OnMove (InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>(); 
        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText() 
    {
        countText.text =  "Count: " + count.ToString();
        if(stage == 1)
        {
            if (count >= 6)
            {
                winTextObject.SetActive(true);
                winTextObject.GetComponent<TextMeshProUGUI>().text = "You Win!\nTeleporting...";
                Destroy(GameObject.FindGameObjectWithTag("Enemy"));
                StartCoroutine(NextScene(3));
            }
        }
        if(stage == 2)
        {
            if(count >= 13)
            {
                winTextObject.SetActive(true);
                winTextObject.GetComponent<TextMeshProUGUI>().text = "You Win!\nTeleporting...";
                Destroy(GameObject.FindGameObjectWithTag("Enemy"));
                StartCoroutine(NextScene(3));
            }
        }
        if(stage == 3)
        {
            if(count >= 12)
            {
                winTextObject.SetActive(true);
                winTextObject.GetComponent<TextMeshProUGUI>().text = "You Win!\nTeleporting...";
                StartCoroutine(NextScene(3));
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the current object
            Destroy(gameObject); 
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
}


