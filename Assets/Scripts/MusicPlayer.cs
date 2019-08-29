using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource _player;
    private int _currentClip = -2;
    [SerializeField] AudioClip[] music = new AudioClip[10];
    void Start()
    {
        _player = GetComponent<AudioSource>();
        _player.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_player.isPlaying)
        {
            bool end = false;
            int ranClip = 0;
            while (end == false)
            {
                ranClip = Random.Range(0, music.Length);
                if (ranClip - 1 > _currentClip || ranClip + 1 < _currentClip) end = true;
            }

            _player.clip = music[ranClip];
            _currentClip = ranClip;
            _player.Play();
        }
    }
}
