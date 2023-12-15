using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip shootingSound;
    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Check if an audio clip is assigned
        if (audioSource.clip != null)
        {
            // Play the audio
            audioSource.Play();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(shootingSound, 0.5f);
        }
    }
}
