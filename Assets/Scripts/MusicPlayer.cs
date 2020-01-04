using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource _player;
    private bool underwaterBloop = true;
    private AudioReverbFilter reverbFilter;
    private int _currentClip = -2;
    [SerializeField] AudioClip[] music = new AudioClip[10];
    [SerializeField] private AudioSource underwaterPlayer;
    void Start()
    {
        _player = GetComponent<AudioSource>();
        reverbFilter = GetComponent<AudioReverbFilter>();
        _player.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CommonVariables.OnMusic)
        {
            if (!_player.isPlaying)
            {
                int ranClip = 0;
                ranClip = Random.Range(0, music.Length);

                _player.clip = music[ranClip];
                _currentClip = ranClip;
                _player.Play();
            }

            if (CommonVariables.OnUnderWater)
            {
                if (!underwaterPlayer.isPlaying)
                {
                    _player.volume = 0.8f;
                    reverbFilter.reverbPreset = AudioReverbPreset.Underwater;
                    underwaterPlayer.Play();
                    if (underwaterBloop) 
                    {
                        SoundCenter.sounds.PlayBlop();
                        underwaterBloop = false;
                    }
                }
            }
            else
            {
                if (underwaterPlayer.isPlaying)
                {
                    _player.volume = 1f;
                    reverbFilter.reverbPreset = AudioReverbPreset.Off;
                    underwaterPlayer.Stop();
                    underwaterBloop = true;
                    SoundCenter.sounds.PlayBlop();
                }
            }
        }
        else
        {
            underwaterPlayer.Stop();
            _player.Stop();
        }
    }
}
