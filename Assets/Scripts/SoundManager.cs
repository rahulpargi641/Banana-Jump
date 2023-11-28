using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip jumpClip, gameOverClip;

    public static SoundManager soundManager;

    private void Awake()
    {
        if(soundManager == null)
        {
            soundManager = this;
        }
    }

    public void JumpSoundFX()
    {
        audioSource.clip = jumpClip;
        audioSource.Play();
    }

    public void GameOverFX()
    {
        audioSource.clip = gameOverClip;
        audioSource.Play();
    }
}
