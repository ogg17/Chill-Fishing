using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundCenter : MonoBehaviour
{
   public static SoundCenter sounds = null;
   
   [SerializeField] private SoundScript click;
   [SerializeField] private SoundScript bubble;
   [SerializeField] private SoundScript lose;
   [SerializeField] private SoundScript blop;
   [SerializeField] private SoundScript crack;
   [SerializeField] private SoundScript coin;
   [SerializeField] private SoundScript ice;
   [SerializeField] private SoundScript breakIce;
   [SerializeField] private SoundScript start;
   private void Start()
   {
      if (sounds == null)
      {
         sounds = this;
      }
      else if (sounds == this)
      {
         Destroy(gameObject);
      }
   }

   public void PlayClick()
   {
      if (CommonVariables.OnSound) click.PlaySound();
   }
   public void PlayBubble()
   {
      if (CommonVariables.OnSound) bubble.PlaySound();
   }
   public void PlayBlop()
   {
      if (CommonVariables.OnSound) blop.PlaySound();
   }
   public void PlayLose()
   {
      if (CommonVariables.OnSound) lose.PlaySound();
   }
   public void PlayCoin()
   {
      if (CommonVariables.OnSound) coin.PlaySound();
   }
   public void PlayCrack()
   {
      if (CommonVariables.OnSound) crack.PlaySound();
   }
   public void PlayIce()
   {
      if (CommonVariables.OnSound) ice.PlaySound();
   }

   public void PlayBreakIce()
   {
      if(CommonVariables.OnSound) breakIce.PlaySound();
   }
   public void PlayStart()
   {
      if (CommonVariables.OnSound) start.PlaySound();
   }
}
