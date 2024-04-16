using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibroGameManager : MonoBehaviour
{
    public static bool CanVibro;

    private void Start()
    {
        Vibration.Init();
        string vibro = PlayerPrefs.GetString("vibro", "");
        if (vibro == "" || vibro == "on") CanVibro = true;
        else CanVibro = false;
    }

    public void VibroCLick()
    {
        if (CanVibro) Vibration.VibrateIOS(ImpactFeedbackStyle.Light);
    }

    public void VibroJump()
    {
        if (CanVibro) Vibration.VibrateIOS(ImpactFeedbackStyle.Heavy);
    }

    public void VibroFinish()
    {
        if (CanVibro) Vibration.Vibrate();
    }

    public void VibroWin()
    {
        if (CanVibro) Vibration.VibrateIOS(NotificationFeedbackStyle.Success);
    }

    public void VibroLose()
    {
        Vibration.VibrateIOS(NotificationFeedbackStyle.Error);
    }

    public void VibroCircle()
    {
        Vibration.VibrateIOS(ImpactFeedbackStyle.Rigid);
    }
}
