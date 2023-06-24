using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesScript : MonoBehaviour
{
    float screenBorder;
    float xOffset = 0.5f;

    GameManagerScript gmScr;

    private void Awake()
    {
        gmScr = FindObjectOfType<GameManagerScript>();
        screenBorder = Camera.main.orthographicSize * Camera.main.aspect;
    }

    private void Update()
    {
        if(transform.position.x < Camera.main.transform.position.x - screenBorder - xOffset)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gmScr.ScorePoint();
        }
    }
}
