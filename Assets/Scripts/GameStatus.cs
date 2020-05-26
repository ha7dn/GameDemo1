using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;

    [SerializeField] int Score = 0;
    [SerializeField] int PointsPerBrick = 3;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
            DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void AddToScore()
    {
        Score += PointsPerBrick;
        scoreText.text = Score.ToString();

    }

    public void resetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
