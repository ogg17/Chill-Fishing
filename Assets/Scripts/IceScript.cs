using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    [SerializeField] private Color unactiveColor;
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
        characterImage.sprite = GameSprites.gameSprites.characterSprites[CommonVariables.CurrentPanel]
            .characterShopSprite;
        if (CommonVariables.CharacterShop[CommonVariables.CurrentPanel][7] == 0)
        {
            form.SetActive(true);
            formImage.enabled = true;
            characterImage.enabled = false;
            formImage.sprite = GameSprites.gameSprites.characterSprites[CommonVariables.CurrentPanel]
                .characterFormSprite;
            for (int i = 0; i < CommonVariables.MaxIcePieceCount; i++)
            {
                if (CommonVariables.CharacterShop[CommonVariables.CurrentPanel][i] == 1)
                {
                    icePieceImage[i].enabled = true;
                    icePieceImage[i].sprite = GameSprites.gameSprites.characterSprites[CommonVariables.CurrentPanel]
                        .icePieceSprites[i];
                }
                else icePieceImage[i].enabled = false;
            }

            if (CommonVariables.CharacterShop[CommonVariables.CurrentPanel][10] >= 1)
            {
                characterImage.enabled = true;
                for (int i = 0; i < CommonVariables.CharacterShop[CommonVariables.CurrentPanel][8]; i++)
                {
                    if (CommonVariables.CharacterShop[CommonVariables.CurrentPanel][10] > i)
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
        if (CommonVariables.CharacterShop[CommonVariables.CurrentPanel][7] == 0)
        {
            int count = 0;
            for (int i = 0; i < CommonVariables.CharacterShop[CommonVariables.CurrentPanel][8]; i++)
            {
                if (CommonVariables.CharacterShop[CommonVariables.CurrentPanel][i] == 1) count++;
            }

            if (count == CommonVariables.CharacterShop[CommonVariables.CurrentPanel][8])
            {
                CommonVariables.CharacterShop[CommonVariables.CurrentPanel][10]++;
                iceParticle.Play();
            }
            if (CommonVariables.CharacterShop[CommonVariables.CurrentPanel][10] ==
                CommonVariables.CharacterShop[CommonVariables.CurrentPanel][8])
                CommonVariables.CharacterShop[CommonVariables.CurrentPanel][7] = 1;
        }
    }

    public void ShowAdButton()
    {
        var backParticleMain = backParticle.main;
        var backParticleEmission = backParticle.emission;
        
        if (CommonVariables.CharacterShop[CommonVariables.CurrentPanel][7] == 0)
        {
            int count = 0;
            for (int i = 0; i < CommonVariables.CharacterShop[CommonVariables.CurrentPanel][8]; i++)
            {
                if (CommonVariables.CharacterShop[CommonVariables.CurrentPanel][i] == 1) count++;
            }

            if (count == CommonVariables.CharacterShop[CommonVariables.CurrentPanel][8] - 1)
                adButton.SetActive(true);
            else
                adButton.SetActive(false);

            if (count == CommonVariables.CharacterShop[CommonVariables.CurrentPanel][8])
                characterAnimation.enabled = true;
            else
                characterAnimation.enabled = false;
            
            backParticleEmission.rateOverTime = new ParticleSystem.MinMaxCurve(10f);
            backParticleMain.startColor = unactiveColor;
        }
        else
        {
            adButton.SetActive(false);
            characterAnimation.enabled = false;
            
            backParticleEmission.rateOverTime = new ParticleSystem.MinMaxCurve(50f);
            backParticleMain.startColor = GameSprites.gameSprites.characterSprites[CommonVariables.CurrentPanel]
                .characterBackgroundShopColor;
        }
    }
}
