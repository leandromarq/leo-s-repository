using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundcontroller : MonoBehaviour
{
    public AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
     public void PlayExplosionSound()
    {
        // Asigna el archivo de sonido al AudioSource
        audioSource.clip = Resources.Load<AudioClip>("explosion");

        // Reproduce el sonido si no está sonando actualmente
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
