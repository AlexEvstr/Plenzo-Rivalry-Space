using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowBall : MonoBehaviour
{
    [SerializeField] private Transform ball;

    private Vector3 _offset;
    private float _ballPosX;

    private void Start()
    {
        _ballPosX = ball.transform.position.x;
        _offset = transform.position - ball.position;
    }

    private void LateUpdate()
    {
        if (ball.transform.position.x > _ballPosX && ball.gameObject.activeInHierarchy && transform.position.x >= 0)
        {
            Vector3 newPos = Vector3.Lerp(transform.position, ball.position + _offset, 1f);
            transform.position = new Vector3(newPos.x, 0, newPos.z);

        }
    }
}
