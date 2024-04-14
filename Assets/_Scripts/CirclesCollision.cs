using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclesCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            StartCoroutine(MakeBiggerSize());
        }
    }

    private IEnumerator MakeBiggerSize()
    {
        transform.localScale = new Vector3(0.65f, 0.65f, 0.65f);
        yield return new WaitForSeconds(0.25f);
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}
