
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public Text LivesText;
    private Rigidbody2D rb2d;
    private int count;
    private int lives;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        lives = 3;
        winText.text = "";
        SetCountText();
        SetLivesText();

    }
   
    void FixedUpdate()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");      
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("Nets"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetLivesText();
        }
    }
    void SetLivesText()
    {
        LivesText.text = "Lives: " + lives.ToString();

        if (lives <= 0)
        {
            winText.text = "<b>Game Over!</b><i>Game created by Emily Woods!</i>";
                gameObject.SetActive(false);
            
        }
    }
    void SetCountText()
    { 
        countText.text = "<b>Count: </b>" + count.ToString();
        if (count == 12)
        { transform.position = new Vector2(50.0f, 50.0f); }
        if (count >= 20)
        {
            winText.text = "<b>You Win!!</b> <i>Game Created by Emily Woods!</i>";
        }
    }

}