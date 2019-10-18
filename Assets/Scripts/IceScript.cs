using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class IceScript : MonoBehaviour
{
    [SerializeField] private Image[] icePieceImage = new Image[7];
    [SerializeField] private Image characterImage;
    [SerializeField] private Animator characterAnimation;
    [SerializeField] private GameObject form;
    [SerializeField] private GameObject adButton;
    [SerializeField] private ParticleSystem iceParticle;
    [SerializeField] private ParticleSystem backParticle;
    [SerializeField] private Color unActiveColor;
    [SerializeField] private Image formImage;

    private void Start()
    {
        StartCoroutine(Initialized());
    }

    private IEnumerator Initialized()
    {
        yield return new WaitForSeconds(CommonVariables.InitializedTime);
        SetIcePieces();
    }

    public void SetIcePieces()
    {
        characterImage.sprite = GameSprites.gameSprites.characterSprites[CommonVariables.CurrentIndexPanel]
            .characterShopSprite;
        if (CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].BuyCharacter == false)
        {
            form.SetActive(true);
            formImage.enabled = true;
            characterImage.enabled = false;
            formImage.sprite = GameSprites.gameSprites.characterSprites[CommonVariables.CurrentIndexPanel]
                .characterFormSprite;
            for (int i = 0; i < CommonVariables.MaxIcePieceCount; i++)
            {
                if (CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].IceShards[i] == true)
                {
                    icePieceImage[i].enabled = true;
                    icePieceImage[i].sprite = GameSprites.gameSprites.characterSprites[CommonVariables.CurrentIndexPanel]
                        .icePieceSprites[i];
                }
                else icePieceImage[i].enabled = false;
            }

            if (CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].CrushShardCount >= 1)
            {
                characterImage.enabled = true;
                for (int i = 0; i < CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].ShardCount; i++)
                {
                    if (CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].CrushShardCount > i)
                        icePieceImage[i].enabled = false;
                }
            }
        }
        else
        {
            form.SetActive(false);
            formImage.enabled = false;
            characterImage.enabled = true;
        }
    }

    public void AnimationIceCrush()
    {
        if (CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].BuyCharacter == false)
        {
            int count = 0;
            for (int i = 0; i < CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].ShardCount; i++)
            {
                if (CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].IceShards[i] == true) count++;
            }

            if (count == CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].ShardCount)
            {
                CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].CrushShardCount++;
                iceParticle.Play();
            }

            if (CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].CrushShardCount ==
                CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].ShardCount)
            {
                CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].BuyCharacter = true;
            }
        }
    }

    public void ShowAdButton()
    {
        var backParticleMain = backParticle.main;
        var backParticleEmission = backParticle.emission;

        if (CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].BuyCharacter == false)
        {
            int count = 0;
            for (int i = 0; i < CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].ShardCount; i++)
            {
                if (CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].IceShards[i] == true) count++;
            }

            if (count == CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].ShardCount - 1)
                adButton.SetActive(true);
            else
                adButton.SetActive(false);

            if (count == CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].ShardCount)
                characterAnimation.enabled = true;
            else
                characterAnimation.enabled = false;
            
            backParticleEmission.rateOverTime = new ParticleSystem.MinMaxCurve(10f);
            backParticleMain.startColor = 
                CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].BuyCharacter?
                    GameSprites.gameSprites.characterSprites[CommonVariables.CurrentIndexPanel].characterBackgroundShopColor:
                Color.grey;
        }
        else
        {
            adButton.SetActive(false);
            characterAnimation.enabled = false;
            
            backParticleEmission.rateOverTime = new ParticleSystem.MinMaxCurve(50f);
            backParticleMain.startColor = GameSprites.gameSprites.characterSprites[CommonVariables.CurrentIndexPanel]
                .characterBackgroundShopColor;
        }
    }
}
