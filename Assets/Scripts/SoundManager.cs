using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    #region Singleton
    public static SoundManager Instance;
    private void Awake()
    {
        if( Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public AudioClip jumpSfx;
    public void PlayJumpSfx()
    {
        audioSource.PlayOneShot(jumpSfx);
    }

    public AudioClip coinSfx;
    public void PlayCoinSfx()
    {
        audioSource.PlayOneShot(coinSfx);
    }
}
