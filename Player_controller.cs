using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_controller : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text livesText;
    public Text winText;

    private Rigidbody2D rb2d;
    private int lives;
    private int count;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        count = 0;
        winText.text = "";
        lives = 3;
        SetCountText();
        SetLivesText();
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
       
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
        other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
       else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetLivesText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count == 12)
        {

            transform.position = new Vector2(70.0f, 0.0f);
        }

        else if (count >= 20)
        {
            Destroy(GetComponent<Rigidbody2D>());
            winText.text = "You Win! Game created by Amelia Stephens!";
        }
    }
        void SetLivesText()
        {
            if (lives <= 0)
            {
                Destroy(this.gameObject);
                winText.text = "You Lose! Game created by Amelia Stephens!";
            }
            livesText.text = "Lives: " + lives.ToString();
        }
}
