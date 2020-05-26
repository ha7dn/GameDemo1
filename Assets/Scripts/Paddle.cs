using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Orthographic Camera Size = 1/2 height
    // 108px per Unit

    // Config parameters 
    float TotalWidth = 35.55f;
    float MaxX = 33.05f;
    float PaddleWidth = 2.5f;
    float mousePos;

    private void Update()
    {
        mousePos = Input.mousePosition.x / Screen.width * TotalWidth;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), PaddleWidth - TotalWidth, MaxX);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (FindObjectOfType<GameStatus>().IsAutoPlayEnabled())
            return FindObjectOfType<Ball>().transform.position.x;
        else
            return mousePos;
    }
}
