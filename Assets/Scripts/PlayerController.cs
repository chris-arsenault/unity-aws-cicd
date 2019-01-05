using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        winText.enabled = false;
        count = 0;
        SetCountText();
    }

    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            if (count >= 4)
            {
                countText.enabled = false;
                winText.enabled = true;
            }
            else
            {
                SetCountText();
            }
        }
    }

    private void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
