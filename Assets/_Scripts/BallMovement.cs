using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private TMP_Text _gemsLOSTText;
    [SerializeField] private TMP_Text _gemsWINText;
    private Rigidbody2D _ball;

    private float _speed = 1.5f;
    private float _jumpForce = 5f;
    private bool isGround;

    private void Start()
    {
        _ball = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _ball.AddForce(Vector2.right * Time.deltaTime * _speed, ForceMode2D.Impulse);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    public void JumpButton()
    {
        if (isGround)
        {
            _ball.AddForce(Vector2.up *_jumpForce, ForceMode2D.Impulse);
            isGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            _speed = 0;
            GemsData.GemsCount += int.Parse(collision.gameObject.name);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            _gemsWINText.text = $"{int.Parse(collision.gameObject.name)}";
            PlayerPrefs.SetInt("Gems", GemsData.GemsCount);
            _winPanel.SetActive(true);
            Time.timeScale = 0;
        }

        else if (collision.gameObject.CompareTag("Border"))
        {
            _speed = 0;
            GemsData.GemsCount -= 1;
            if (GemsData.GemsCount < 0)
            {
                GemsData.GemsCount = 0;
                _gemsLOSTText.text = $"0";
            }
            else
            {
                _gemsLOSTText.text = $"-1";
            }
            PlayerPrefs.SetInt("Gems", GemsData.GemsCount);
            _losePanel.SetActive(true);
            Time.timeScale = 0;

        }
    }
}