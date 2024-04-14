using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemsData : MonoBehaviour
{
    [SerializeField] private TMP_Text gemsText;

    public static int GemsCount;

    private void Start()
    {
        GemsCount = PlayerPrefs.GetInt("Gems", 0);
    }

    private void Update()
    {
        gemsText.text = GemsCount.ToString();
    }
}
