using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadScript : MonoBehaviour
{
    private void Awake()
    {
        for (var i = 0; i < CommonVariables.PacksCount; i++)
        {
            for (var j = 0; j < CommonVariables.CharacterPacks[i]; j++)
            {
                CommonVariables.CharacterShops.Add(new CharacterShop());
            }
        }

        CommonVariables.CharacterShops[0].BuyCharacter = true;
        
        CommonVariables.CharacterShops[12].ShardCount = 3;
        CommonVariables.CharacterShops[13].ShardCount = 3;
        CommonVariables.CharacterShops[14].ShardCount = 3;
        
        CommonVariables.CharacterShops[18].ShardCount = 3;
        CommonVariables.CharacterShops[19].ShardCount = 3;
        CommonVariables.CharacterShops[20].ShardCount = 3;
        
        CommonVariables.CharacterShops[21].ShardCount = 3;
        CommonVariables.CharacterShops[23].ShardCount = 3;
        
        CommonVariables.CharacterShops[27].ShardCount = 7;
        CommonVariables.CharacterShops[29].ShardCount = 7;

        //CommonVariables.GameLanguage = Application.systemLanguage == SystemLanguage.Russian 
         //   ? SystemLanguage.Russian : SystemLanguage.English;
    }
    private void Start()
    {
        CommonVariables tmp = JsonUtility.FromJson<CommonVariables>(PlayerPrefs.GetString("Save"));
        tmp.LoadVariables();
        
        StartCoroutine(Initialized());
    }

    private IEnumerator Initialized()
    {
        yield return new WaitForSeconds(CommonVariables.InitializedTime);
        EventController.GameEvents.startApp.Invoke();
    }

    private void Save()
    {
        CommonVariables tmp = new CommonVariables();
        PlayerPrefs.SetString("Save", tmp.SaveVariables());
        //Debug.Log(JsonUtility.ToJson(tmp));
        PlayerPrefs.Save();
    }
    private void OnApplicationQuit() => Save();

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus) Save();
    }
}
