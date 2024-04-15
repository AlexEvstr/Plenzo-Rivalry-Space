using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseLevelButton : MonoBehaviour
{
    private void Start()
    {
        if (int.Parse(gameObject.name) <= PlayerPrefs.GetInt("bestLevel", 1))
        {
            gameObject.GetComponent<Button>().enabled = true;
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);

        }
        else
        {
            gameObject.GetComponent<Button>().enabled = false;
            gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);    
        }
    }

    public void ChooseLevel()
    {
        PlayerPrefs.SetInt("LevelCurrent", int.Parse(gameObject.name));
        SceneManager.LoadScene("GameScene");
    }
}
