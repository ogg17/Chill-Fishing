using UnityEngine;

[System.Serializable]
public class TranslateString 
{
    [SerializeField] private string english;
    [SerializeField] private string russian;
    [SerializeField] private int rusFontSize = 8;
    [SerializeField] private int engFontSize = 8;

    public TranslateString(string english, string russian)
    {
        this.english = english;
        this.russian = russian;
    }

    public int GetFontSize()
    {
        switch (CommonVariables.GameLanguage) {
            case SystemLanguage.English:
                return engFontSize;
            case SystemLanguage.Russian:
                return rusFontSize;
        }
        return engFontSize;
    }

    public static implicit operator string(TranslateString value)
    {
        switch (CommonVariables.GameLanguage) {
            case SystemLanguage.English:
                return value.english;
            case SystemLanguage.Russian:
                return value.russian;
        }
        return value.english;
    }
}
