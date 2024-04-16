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

    [SerializeField] private GameObject _explosion;

    [SerializeField] private GameSoundManager gameSoundManager;
    [SerializeField] private VibroGameManager VibroGameManager;

    private int _bestLevel;
    private Rigidbody2D _ball;

    private float _speed = 1.5f;
    private float _jumpForce = 5f;
    private bool isGround;

    private void Start()
    {
        _bestLevel = PlayerPrefs.GetInt("bestLevel", 1);
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
            gameSoundManager.JumpSound();
            isGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            VibroGameManager.VibroFinish();
            _speed = 0;
            GemsData.GemsCount += int.Parse(collision.gameObject.name);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            _gemsWINText.text = $"{int.Parse(collision.gameObject.name)}";
            PlayerPrefs.SetInt("Gems", GemsData.GemsCount);

            LevelsData.LevelCurrent++;
            PlayerPrefs.SetInt("LevelCurrent", LevelsData.LevelCurrent);

            if (_bestLevel < LevelsData.LevelCurrent)
            {
                _bestLevel = LevelsData.LevelCurrent;
                PlayerPrefs.SetInt("bestLevel", _bestLevel);
            }

            StartCoroutine(MakeExplosionEffect());
            
        }

        else if (collision.gameObject.CompareTag("Border"))
        {
            _speed = 0;
            GemsData.GemsCount -= LevelsData.LevelCurrent;
            if (GemsData.GemsCount < 0)
            {
                GemsData.GemsCount = 0;
                _gemsLOSTText.text = $"0";
            }
            else
            {
                _gemsLOSTText.text = $"-{LevelsData.LevelCurrent}";
            }
            PlayerPrefs.SetInt("Gems", GemsData.GemsCount);
            VibroGameManager.VibroLose();
            _losePanel.SetActive(true);
            Time.timeScale = 0;

        }
    }

    private IEnumerator MakeExplosionEffect()
    {
        gameSoundManager.FinishCollisionSound();
        GameObject explosion = Instantiate(_explosion);
        explosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Destroy(explosion, 0.5f);
        yield return new WaitForSeconds(0.6f);
        VibroGameManager.VibroWin();
        _winPanel.SetActive(true);
        Time.timeScale = 0;
    }
}