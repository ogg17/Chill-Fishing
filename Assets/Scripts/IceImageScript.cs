using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceImageScript : MonoBehaviour
{
    public Image[] icePieceImage = new Image[7];
    public Image characterImage;
    public GameObject form;
    public Image formImage;

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
        }
        else
        {
            form.SetActive(false);
        }
    }
}
