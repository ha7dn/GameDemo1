using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    [SerializeField] int LevelBricks;

    SceneLoader sceneLoader;

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
