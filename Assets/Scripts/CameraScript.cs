using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    PlayerScript playerScr;
    [SerializeField] float xOffset;

    private void Awake()
    {
        playerScr = FindObjectOfType<PlayerScript>();
    }

    private void Update()
    {
        Vector2 playerPos = playerScr.GetPosition();
        transform.position = new Vector3(playerPos.x + xOffset, 0, -10);
    }
}
