using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceImageScript : MonoBehaviour
{
    [SerializeField] private Image[] icePieceImage = new Image[7];
    [SerializeField] private Image characterImage;
    [SerializeField] private GameObject form;
    [SerializeField] private ParticleSystem iceParticle;
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
}
