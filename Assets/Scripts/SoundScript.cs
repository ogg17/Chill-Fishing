using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    [SerializeField] private List<AudioClip> sound;
    [SerializeField] private bool passPlaying;

    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlaySound()
    {
        if(!audioSource.isPlaying || passPlaying)
            audioSource.PlayOneShot(sound[Random.Range(0, sound.Count)]);
    }
}
