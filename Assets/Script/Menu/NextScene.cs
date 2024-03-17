using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField] private GameObject audioManager;
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void StartGame()
    {
        DontDestroyOnLoad(audioManager);
        SceneManager.LoadScene("MainScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
