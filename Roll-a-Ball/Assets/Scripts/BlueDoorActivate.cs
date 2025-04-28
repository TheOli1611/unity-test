using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDoorActivate : MonoBehaviour
{
    public GameObject blueDoor;
    public GameObject blueButton;
    public GameObject box;
    public Transform location;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            box.transform.position = location.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BlueBox"))
        {
            blueButton.SetActive(false);
            blueDoor.SetActive(false);
        }
    }
}
