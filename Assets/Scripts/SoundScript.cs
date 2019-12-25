using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum SoundType
{
   Click,
   Bauble,
   Lose,
   Blop,
   Coin
}

public class SoundScript : MonoBehaviour
{
   public static SoundScript sounds = null;
   private AudioSource soundPlayer;
   [SerializeField] private AudioClip click;
   [SerializeField] private List<AudioClip> bubbles = new List<AudioClip>();
   [SerializeField] private AudioClip lose;
   [SerializeField] private AudioClip blop;
   [SerializeField] private AudioClip crack;
   [SerializeField] private AudioClip coin;
   [SerializeField] private List<AudioClip> ice = new List<AudioClip>();
   private void Start()
   {
      soundPlayer = GetComponent<AudioSource>();
      
      if (sounds == null)
      {
         sounds = this;
      }
      else if (sounds == this)
      {
         Destroy(gameObject);
      }
   }

   public void PlaySound(SoundType type)
   {
      if (CommonVariables.OnSound && !soundPlayer.isPlaying)
      {
         if (type == SoundType.Click)
         {
            soundPlayer.volume = 0.4f; 
            soundPlayer.PlayOneShot(click);
         }
         else if (type == SoundType.Bauble)
         {
            soundPlayer.volume = 0.8f; 
            soundPlayer.PlayOneShot(bubbles[Random.Range(0, bubbles.Count)]);
         }
         else if (type == SoundType.Lose)
         {
            soundPlayer.volume = 0.8f; 
            soundPlayer.PlayOneShot(lose);
         }
         else if (type == SoundType.Blop)
         {
            soundPlayer.volume = 0.7f; 
            soundPlayer.PlayOneShot(blop);
         }
         else if (type == SoundType.Coin)
         {
            soundPlayer.volume = 0.4f;
            soundPlayer.PlayOneShot(coin);
         }
      }
   }
   public void PlayCrack()
   {
      if (CommonVariables.OnSound)
      {
         soundPlayer.volume = 0.8f;
         soundPlayer.PlayOneShot(crack);
      }
   }

   public void PlayIce()
   {
      if (CommonVariables.OnSound)
      {
         soundPlayer.volume = 0.4f;
         soundPlayer.PlayOneShot(ice[Random.Range(0, ice.Count)]);
      }
   }
}
