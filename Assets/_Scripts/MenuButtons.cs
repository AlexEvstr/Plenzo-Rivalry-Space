using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject _levelsPanel;
    [SerializeField] private GameObject _skinsPanel;
    [SerializeField] private GameObject _platformsShop;
    [SerializeField] private GameObject _settingsPanel;

    [SerializeField] private GameObject _onBoard_1;
    [SerializeField] private GameObject _onBoard_2;
    [SerializeField] private GameObject _onBoard_3;

    [SerializeField] private GameObject _tutorial;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Time.timeScale = 1;

        string firstEnter = PlayerPrefs.GetString("FirstEnter", "");
        if (firstEnter == "")
        {
            _onBoard_1.SetActive(true);
        }
    }

    public void OpenSecondOnBoard()
    {
        _onBoard_1.SetActive(false);
        _onBoard_2.SetActive(true);
    }

    public void OpenThirdOnBoard()
    {
        _onBoard_2.SetActive(false);
        _onBoard_3.SetActive(true);
    }

    public void CloseThirdOnBoard()
    {
        _onBoard_3.SetActive(false);
        PlayerPrefs.SetString("FirstEnter", "nope");
    }

    public void OpenGameScene()
    {
        _levelsPanel.SetActive(true);
    }

    public void OpenSkinsPanel()
    {
        _skinsPanel.SetActive(true);
    }

    public void CloseSkinsPanel()
    {
        _skinsPanel.SetActive(false);
    }

    public void NextPage()
    {
        _platformsShop.SetActive(true);
    }

    public void PrevPage()
    {
        _platformsShop.SetActive(false);
    }

    public void OpenSettingsPanel()
    {
        _settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        _settingsPanel.SetActive(false);
    }

    public void OpenTutorial()
    {
        _tutorial.SetActive(true);
    }

    public void CloseTutorial()
    {
        _tutorial.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}