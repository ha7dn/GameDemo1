using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    // cached reference
    Level Level;
    GameStatus GameStatus;
    private void Start()
    {
        GameStatus = FindObjectOfType<GameStatus>();
        Level = FindObjectOfType<Level>();
        Level.CountBricks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Level.BrickDestroyed();
        GameStatus.AddToScore();
    }
}
