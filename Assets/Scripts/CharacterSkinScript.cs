using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkinScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer characterSkin;

    public void SetCharacterSkin()
    {
        characterSkin.sprite =
            GameSprites.gameSprites.characterSprites[CommonVariables.EquippedSkin].characterGameSprite;
    }
}
