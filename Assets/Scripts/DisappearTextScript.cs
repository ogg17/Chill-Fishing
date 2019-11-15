using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisappearTextScript : MonoBehaviour
{ 
   [SerializeField] private Color color;
   [SerializeField] private float disappearSpeed;
   private Text text;

   private void Start()
   {
      text = GetComponent<Text>();
      text.color = color;
   }

   private void Update()
   {
      color.a = Mathf.Lerp(color.a, 0, disappearSpeed * Time.deltaTime);
      text.color = color;
   }

   public void SetGoldText()
   {
      text.text = "+" + CommonVariables.GoldGift;
      color.a = 1;
   }
}
