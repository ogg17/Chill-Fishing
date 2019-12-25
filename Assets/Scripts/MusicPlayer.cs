using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource _player;
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
                _player.volume = 0.8f;
                reverbFilter.reverbPreset = AudioReverbPreset.Underwater;
                if (!underwaterPlayer.isPlaying)
                {
                    underwaterPlayer.Play();
                    SoundScript.sounds.PlaySound(SoundType.Blop);
                }
            }
            else
            {
                _player.volume = 1f;
                reverbFilter.reverbPreset = AudioReverbPreset.Off;
                if (underwaterPlayer.isPlaying)
                {
                    underwaterPlayer.Stop();
                    SoundScript.sounds.PlaySound(SoundType.Blop);
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
