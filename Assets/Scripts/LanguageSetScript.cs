using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSetScript : MonoBehaviour
{
    [SerializeField] private bool active;
    [SerializeField] private TranslateString text;

    private Text uiText;
    void Start()
    {
        uiText = GetComponent<Text>();
        SetLanguage();
        StartCoroutine(Initialized());
    }
    
    private IEnumerator Initialized()
    {
        yield return new WaitForSeconds(CommonVariables.InitializedTime);
        EventController.GameEvents.setLanguage.AddListener(SetLanguage);
    }

    private void SetLanguage()
    {
        if (active)
        {
            uiText.text = this.text;
            if (text.GetFontSize() != 0) uiText.fontSize = text.GetFontSize();
            else uiText.fontSize = 8;
        }
    }
}
