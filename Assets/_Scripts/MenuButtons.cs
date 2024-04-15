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
    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Time.timeScale = 1;
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
}