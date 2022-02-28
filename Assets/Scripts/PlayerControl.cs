using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D body;
    public TextMeshProUGUI Score;
    public GameObject WinText;

    public float moveSpeed;
    private float moveHorizontal;
    private float moveVertical;
    public float jumpForce;
    private bool isJumping;
    private int score;


    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();

        isJumping = false;
        score = 0;

        Text();
        WinText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            body.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Force);
        }

        if (moveVertical > 0.1f && !isJumping)
        {
            body.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Platform")
        {
            isJumping = false;
        }

        if (collision.gameObject.tag == "Banana")
        {
            score++;
            Text();
            
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }
    }

    public void Text()
    {
        Score.text = "Score: " + score.ToString();
        if (score >= 8)
        {
            WinText.SetActive(true);
        }
    }

}
