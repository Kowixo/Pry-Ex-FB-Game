using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    GameManagerScript gmScr;

    [SerializeField] int jumpForce;
    [SerializeField] int speed;

    bool hasGameStarted = false;
    bool hasGameOver = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gmScr = FindObjectOfType<GameManagerScript>();
    }

    private void Update()
    {
        if (hasGameStarted && !hasGameOver)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            hasGameOver = true;
            gmScr.GameOver();
        }
    }

    public Vector2 GetPosition()
    {
        return transform.position;
    }

    public void StartGame()
    {
        hasGameStarted = true;
        rb.simulated = true;
    }
}
