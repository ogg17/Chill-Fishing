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
   Blop
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
            soundPlayer.volume = 0.7f; 
            soundPlayer.PlayOneShot(lose);
         }
         else if (type == SoundType.Blop)
         {
            soundPlayer.volume = 0.7f; 
            soundPlayer.PlayOneShot(blop);
         }
      }
   }

   public void PlayCrack()
   {
      soundPlayer.volume = 0.4f; 
      soundPlayer.PlayOneShot(crack);
   }
}
