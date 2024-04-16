using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip _clickSound;
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _circleCollisionSound;
    [SerializeField] private AudioClip _finihsCollisionSound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ClickSound()
    {
        audioSource.PlayOneShot(_clickSound);
    }

    public void JumpSound()
    {
        audioSource.PlayOneShot(_jumpSound);
    }

    public void CircleCollisionSound()
    {
        audioSource.PlayOneShot(_circleCollisionSound);
    }

    public void FinishCollisionSound()
    {
        audioSource.PlayOneShot(_finihsCollisionSound);
    }
}
