using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

    private int maxCount;

    void Start() {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        maxCount = GameObject.Find("Pickup Spawner").GetComponent<Spawner>().numberOfObjects;
    }

    void FixedUpdate()
    {
        //Input.GetAxis(...) was indicating input when there was none. (Bug?)
        //We use this instead to achieve the same effect.
        float moveHorizontal =
            (Input.GetKey("right") ? 1 : 0) - (Input.GetKey("left") ? 1 : 0);
        float moveVertical =
            (Input.GetKey ("up") ? 1 : 0) - (Input.GetKey ("down") ? 1 : 0);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText() {
        countText.text = "Count: " + count.ToString();

        if (count >= maxCount)
        {
            winText.text = "You Win!";
        }
    }
}
