using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    // Config parameters

    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 10f;
    [SerializeField]public GameObject brickOnCollision;
    [SerializeField] AudioClip[] clips;

    // State 
    Vector2 paddleToBall;
    bool hasGameStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        paddleToBall = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasGameStarted)
            LockBallToPaddle();

        LaunchOnClick();
    }

    private void LaunchOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            hasGameStarted = true;
        }
    }

    private void LockBallToPaddle()
    {

        var paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddleToBall + paddlePos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioClip clip = null;
        brickOnCollision = collision.gameObject;
        if (hasGameStarted)
        {
            switch (brickOnCollision.tag)
            {
                case "Brick1":
                    clip = clips[0];
                    break;
                case "Brick2":
                    clip = clips[1];
                    break;
                case "Brick3":
                    clip = clips[2];
                    break;
                case "Brick4":
                    clip = clips[3];
                    break;
                default:
                    clip = clips[4];
                    break;
            }
            AudioSource.PlayClipAtPoint(clip, new Vector3(), 1f);
        }

    }
}
