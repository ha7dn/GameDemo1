using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    Level Level;
    GameStatus GameStatus;
    [SerializeField] GameObject[] BrickVFX;
    string BrickTag;
    int MaxHits;
    [SerializeField] int TimesHit;
    [SerializeField] Sprite HitSprite;


    private void Start()
    {
        GameStatus = FindObjectOfType<GameStatus>();
        Level = FindObjectOfType<Level>();
        Level.CountBricks();
        BrickTag = gameObject.tag;
        SetBrickMaxHits(BrickTag);
    }

    private void SetBrickMaxHits(string tag)
    {
        switch (tag)
        {
            case "Brick4":
                MaxHits = 2;
                break;

            default:
                MaxHits = 1;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TimesHit++;
        if (TimesHit == MaxHits)
            DestroyBrick();
        else
            ShowHitSprite();
    }

    private void ShowHitSprite()
    {
        if (HitSprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = HitSprite; 
        }
    }

    private void DestroyBrick()
    {
        Destroy(gameObject);
        Level.BrickDestroyed();
        GameStatus.AddToScore();
        TriggerVFX();
    }

    private void TriggerVFX()
    {
        GameObject particleVFX = new GameObject();
        switch (BrickTag)
        {
            case "Brick1":
                particleVFX = BrickVFX[0];
                break;
            case "Brick2":
                particleVFX = BrickVFX[1];

                break;
            case "Brick3":
                particleVFX = BrickVFX[2];

                break;
            case "Brick4":
                particleVFX = BrickVFX[3];

                break;
        }

        GameObject brickFX = Instantiate(particleVFX, transform.position, transform.rotation);

        Destroy(particleVFX, 2f);
    }
}
