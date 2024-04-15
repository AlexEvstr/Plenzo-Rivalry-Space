using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsData : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _platforms;
    [SerializeField] private Sprite[] _sprites;

    private void Start()
    {
        int platform = PlayerPrefs.GetInt("Platform", 0);
        foreach (var item in _platforms)
        {
            item.sprite = _sprites[platform];
        }
    }
}
