using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseSkinButton : MonoBehaviour
{
    [SerializeField] private GameObject _flagMark;
    private void Start()
    {
        CheckColor();
        int bestLevel = PlayerPrefs.GetInt("bestLevel", 1);
        if (int.Parse(gameObject.name) <= bestLevel)
        {
            gameObject.GetComponent<Button>().enabled = true;
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            if (transform.childCount > 1)
            {
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
        else
        {
            gameObject.GetComponent<Button>().enabled = false;
            gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
        }
    }

    public void ChooseSkin()
    {
        PlayerPrefs.SetInt("CircleSkin", int.Parse(gameObject.transform.GetChild(0).gameObject.name));
        _flagMark.transform.SetParent(transform);
    }

    private void Update()
    {
        if (transform.childCount == 3)
        {
            gameObject.GetComponent<Image>().color = new Color(0.5f, 0.7f, 1, 1);
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
    }

    private void CheckColor()
    {
        int color = PlayerPrefs.GetInt("CircleSkin", 1);
        if (int.Parse(transform.GetChild(0).name) == color) _flagMark.transform.SetParent(transform);
    }
}
