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

    private void Update()
    {
        var mousePos = Input.mousePosition.x / Screen.width * TotalWidth;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePos, PaddleWidth - TotalWidth, MaxX);
        transform.position = paddlePos;
    }


}
