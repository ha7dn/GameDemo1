using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public Scene LastScene;
    [SerializeField] public string sceneName;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            PauseGame();
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    private void PauseGame()
    {
        SceneManager.LoadScene("GamePause");
    }
    public void ResumeGame()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}