using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    private ParticleSystem part;

    private void Start()
    {
        part = GetComponent<ParticleSystem>();
    }

    public void SetColorBackground()
    {
        var mainModule = part.main;
        var emission = part.emission;

        if (CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].BuyCharacter == true)
        {
            mainModule.startColor = GameSprites.gameSprites.characterSprites[CommonVariables.CurrentIndexPanel]
                .characterBackgroundShopColor;
            emission.rateOverTime = new ParticleSystem.MinMaxCurve(20);
        }
        else
        {
            mainModule.startColor = Color.gray;
            emission.rateOverTime = new ParticleSystem.MinMaxCurve(5);
        }
    }
}
