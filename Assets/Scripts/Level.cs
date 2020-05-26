using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    [SerializeField] int LevelBricks;

    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        sceneLoader.LastScene = SceneManager.GetActiveScene();
        sceneLoader.sceneName = sceneLoader.LastScene.name;

    }

    public void CountBricks()
    {
        LevelBricks++;
    }

    public void BrickDestroyed()
    {
        LevelBricks--;

        if (LevelBricks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
