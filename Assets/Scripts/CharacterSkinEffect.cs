using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkinEffect : MonoBehaviour
{
    [SerializeField] private float scaleClick;
    [SerializeField] private float rotationClick;
    [SerializeField] private float positionClick;

    public void StartEffect()
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
                transform.localPosition = new Vector2(Random.Range(-positionClick, positionClick),
                    Random.Range(-positionClick, positionClick));
                transform.localScale = new Vector3(Random.Range(1, scaleClick), Random.Range(1, scaleClick), 1);
                transform.eulerAngles = new Vector3(0, 0, Random.Range(-rotationClick, rotationClick));
            }
        }
    }

    public void EndEffect()
    {
        if (CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].BuyCharacter == false)
        {
            transform.localPosition = Vector3.zero;
            transform.localScale = new Vector3(1, 1, 1);
            transform.eulerAngles = Vector3.zero;
        }
    }
}
