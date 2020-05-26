using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    // Config parameters

    [SerializeField] Paddle Paddle1;

    [SerializeField] AudioClip[] Clips;

    float  XPush = 2f;
    float  YPush = 50f;
    float RandomFactor = 2.56f;
    Rigidbody2D MyRigidBody;

     GameObject BrickOnCollision;


    // State 
    Vector2 PaddleToBall;
    bool    HasGameStarted = false;


    // Start is called before the first frame update
    void Start()
    {
        PaddleToBall = transform.position - Paddle1.transform.position;
        MyRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!HasGameStarted)
            LockBallToPaddle();

        LaunchOnClick();
    }

    private void LaunchOnClick()
    {

        if (Input.GetMouseButtonDown(0) && !HasGameStarted)
        {
            MyRigidBody.velocity = new Vector2(XPush, YPush);
            HasGameStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        var paddlePos = new Vector2(Paddle1.transform.position.x, Paddle1.transform.position.y);
        transform.position = PaddleToBall + paddlePos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var VelocityTweak = new Vector2(
                            Random.Range(0, RandomFactor),
                            Random.Range(0, RandomFactor));

        AudioClip clip = null;
        BrickOnCollision = collision.gameObject;
        if (HasGameStarted)
        {
            switch (BrickOnCollision.tag)
            {
                case "Brick1":
                    clip = Clips[0];
                    break;
                case "Brick2":
                    clip = Clips[1];
                    break;
                case "Brick3":
                    clip = Clips[2];
                    break;
                case "Brick4":
                    clip = Clips[3];
                    break;
                default:
                    clip = Clips[4];
                    break;
            }
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, 1f);
            MyRigidBody.velocity += VelocityTweak;
        }

    }
}
