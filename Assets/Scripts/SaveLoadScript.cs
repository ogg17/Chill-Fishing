using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadScript : MonoBehaviour
{
    [SerializeField] private GameObject skinMenu;
    [SerializeField] private GameObject loadScreen;
    [SerializeField] private String keySave = "Save019";
    private void Awake()
    {
        //PlayerPrefs.DeleteAll();

        //CommonVariables.GameLanguage = Application.systemLanguage == SystemLanguage.Russian 
         //   ? SystemLanguage.Russian : SystemLanguage.English;
    }
    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        StartCoroutine(Initialized());
    }

    private IEnumerator Initialized()
    {
        yield return new WaitForSeconds(CommonVariables.InitializedTime);

        bool error = false;
        if (PlayerPrefs.HasKey(keySave))
        {
            CommonVariables tmp = JsonUtility.FromJson<CommonVariables>(PlayerPrefs.GetString("Save"));
            if (tmp.tmpCharacterShops == null)
            {
                error = true; 
                Debug.Log("Error: in class: " + PlayerPrefs.GetString("Save"));
            }
            else
            {
                tmp.LoadVariables();
                while (CommonVariables.CharacterShops.Count < CommonVariables.CharacterCount)
                {
                    CommonVariables.CharacterShops.Add(new CharacterShop());
                }
                Debug.Log("Successful");
            }
        }
        if(error || !PlayerPrefs.HasKey(keySave))
        {
            for (var i = 0; i < CommonVariables.PacksCount; i++)
            {
                for (var j = 0; j < CommonVariables.CharacterPacks[i]; j++)
                {
                    CommonVariables.CharacterShops.Add(new CharacterShop());
                }
            }
        }

        if (!PlayerPrefs.HasKey("guide"))
        {
            EventController.GameEvents.firstStartApp.Invoke(); 
        }
        //// Set ShardCount
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
            
        CommonVariables.CharacterShops[31].ShardCount = 3;
        CommonVariables.CharacterShops[32].ShardCount = 3;
        
        skinMenu.SetActive(true);
        EventController.GameEvents.startApp.Invoke();

        StartCoroutine(StopInitialized());
    }

    private IEnumerator StopInitialized()
    {
        yield return new WaitForSeconds(0.5f);
        skinMenu.SetActive(false);
        loadScreen.SetActive(false);
    }

    private void Save()
    {
        CommonVariables tmp = new CommonVariables();
        PlayerPrefs.SetString(keySave, tmp.SaveVariables());
        PlayerPrefs.Save();
    }
    private void OnApplicationQuit() => Save();

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus) Save();
    }
}
