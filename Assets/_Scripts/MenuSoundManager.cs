using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip _clickSound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ClickSound()
    {
        audioSource.PlayOneShot(_clickSound);
    }
}
