using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtons : MonoBehaviour
{
    [SerializeField] private GameObject _pause;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        _pause.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        _pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void MenuSceneButton()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
