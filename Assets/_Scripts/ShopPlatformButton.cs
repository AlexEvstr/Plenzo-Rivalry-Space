using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopPlatformButton : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private GameObject _check;
    [SerializeField] private TMP_Text gemsText;
    public string _bought;
    public static int Gems;

    private void Start()
    {
        _bought = PlayerPrefs.GetString(gameObject.name, "");
        if (_bought != "")
        {
            GetComponent<Button>().enabled = true;
            transform.GetChild(1).gameObject.SetActive(false);
        }

        Gems = PlayerPrefs.GetInt("Gems", 0);
        gemsText.text = Gems.ToString();
        int index = PlayerPrefs.GetInt("Platform", 0);
        if (index == int.Parse(gameObject.name))
        {
            _check.transform.SetParent(transform);
        }

        if (_price < Gems)
        {
            GetComponent<Button>().enabled = true;
            transform.GetChild(1).GetComponent<Image>().color = new Color(1, 1, 1, 1);

        }
        else
        {
            GetComponent<Button>().enabled = false;
            transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
        }

        
    }

    public void ChoosePlatformButton()
    {
        if (_price <= Gems && _bought == "")
        {
            Gems -= _price;
            gemsText.text = Gems.ToString();
            PlayerPrefs.SetInt("Gems", Gems);
            _bought = "yep";
            PlayerPrefs.SetString(gameObject.name, _bought);
        }

        PlayerPrefs.SetInt("Platform", int.Parse(gameObject.name));
        _check.transform.SetParent(transform);


    }

    private void Update()
    { 
        if (transform.childCount == 3)
        {
            GetComponent<Button>().enabled = true;
            transform.GetChild(1).gameObject.SetActive(false);
            gameObject.GetComponent<Image>().color = new Color(0.5f, 0.7f, 1, 1);
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
    }


}
