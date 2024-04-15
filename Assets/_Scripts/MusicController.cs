using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private GameObject _musicOff;

    private void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("music", 1);
        if (AudioListener.volume == 1)
        {
            _musicOff.SetActive(false);
        }
        else
        {
            _musicOff.SetActive(true);
        }
    }

    public void TurnOffMusic()
    {
        _musicOff.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetFloat("music", 0);
    }

    public void TurnOfMusic()
    {
        _musicOff.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetFloat("music", 1);
    }
}
