using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
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
}