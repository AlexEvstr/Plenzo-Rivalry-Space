using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelsData : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelTEXT;
    public static int LevelCurrent;

    private void Start()
    {
        LevelCurrent = PlayerPrefs.GetInt("LevelCurrent", 1);
        _levelTEXT.text = LevelCurrent.ToString();
    }


}

