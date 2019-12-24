using UnityEngine;

[System.Serializable]
public class TranslateString 
{
    [SerializeField] private string english;
    [SerializeField] private string russian;

    public TranslateString(string english, string russian)
    {
        this.english = english;
        this.russian = russian;
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
