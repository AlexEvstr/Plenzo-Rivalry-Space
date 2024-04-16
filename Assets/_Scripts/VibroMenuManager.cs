using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibroMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _vibroOff;
    public static bool CanVibro;

    private void Start()
    {
        Vibration.Init();
        string vibro = PlayerPrefs.GetString("vibro", "");
        if (vibro == "" || vibro == "on") VibroOn();
        else VibroOff();
    }

    public void VibroOff()
    {
        _vibroOff.SetActive(true);
        CanVibro = false;
        PlayerPrefs.SetString("vibro", "off");
    }

    public void VibroOn()
    {
        _vibroOff.SetActive(false);
        CanVibro = true;
        PlayerPrefs.SetString("vibro", "on");
    }

    public void VibroCLick()
    {
        if (CanVibro) Vibration.VibrateIOS(ImpactFeedbackStyle.Light);
    }
}