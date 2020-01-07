using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSetPackScript : MonoBehaviour
{
    private Text uiText;
    public int indx;
    void Start()
    {
        uiText = GetComponent<Text>();
        StartCoroutine(Initialized());
    }
    
    private IEnumerator Initialized()
    {
        yield return new WaitForSeconds(CommonVariables.InitializedTime);
        EventController.GameEvents.setLanguage.AddListener(SetLanguage);
        SetLanguage();
    }

    private void SetLanguage()
    {
        uiText.text = GameString.gameString.stringPacks.packs[indx].packName;
    }
}
