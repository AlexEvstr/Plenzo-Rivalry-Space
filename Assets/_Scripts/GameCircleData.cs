using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCircleData : MonoBehaviour
{
    [SerializeField] private Material _circleMaterial;
    [SerializeField] private Color[] _colors;

    private void Start()
    {
        int color = PlayerPrefs.GetInt("CircleSkin", 1);
        _circleMaterial.color = _colors[color];  
    }
}
