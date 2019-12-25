using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class CharacterShop
{
    public bool[] IceShards = new bool[7];
    public bool BuyCharacter = false;
    public int ShardCount = 5;
    public int CrushShardCount = 0;
    public int ShardPrice = 30;
}
[System.Serializable]
public class CommonVariables
{
    public const float InitializedTime = 0.005f;
    public const int CharacterCount = 30;
    public const int MaxIcePieceCount = 7;
    public const int PacksCount = 10;

    public static bool GamePlaying { get; set; } = false; // Playing game
    public static float DepthHook { get; set; } = 1f; // Hook movement base
    public static float CoinPos { get; set; } = 2f; // Current  position coin
    public static int Score { get; set; } // Score game
    public static int Record { get; set; } // Record game
    public static int GoldSession { get; set; } // Gold count given in one session game
    public static int GoldGift { set; get; }
    public static int Gold { get; set; } = 5000; // Gold
    public static int CurrentIndexPanel { get; set; } // Current scroll index panel
    public static int CurrentPanel { get; set; } // Current panel in pack
    public static int CurrentPack { get; set; } // Current pack in skin menu
    public static int EquippedSkin { get; set; } // Current equipped skin
    public static List<CharacterShop> CharacterShops { get; set; } = new List<CharacterShop>(); // Data of shop buys
    public static SystemLanguage GameLanguage { get; set; } = SystemLanguage.Russian;
    public static int[] CharacterPacks { get; set; } = {3, 3, 3, 3, 3, 3, 3, 3, 3, 3};
    public static bool OnUnderWater = false;
    public static bool OnClickPanel { get; set; } = false; // Clicked on panel in skin menu
    public static bool OnMusic { get; set; } = true; // on/off music
    public static bool OnSound { get; set; } = true; // on/off Sound
    public static bool OnVibration { get; set; } = false; // on/off Vibration
    
    // non-static temp variables:

    public int tmpGold = 0;
    public int tmpRecord = 0;
    public int tmpEqpSkin = 0;
    public List<CharacterShop> tmpCharacterShops = new List<CharacterShop>();

    public CommonVariables()
    {
        tmpGold = Gold;
        tmpRecord = Record;
        tmpEqpSkin = EquippedSkin;
        tmpCharacterShops = CharacterShops;
    }

    public string SaveVariables()
    {
        return JsonUtility.ToJson(this);
    }

    public void LoadVariables()
    {
        Gold = tmpGold;
        Record = tmpRecord;
        EquippedSkin = tmpEqpSkin;
        CharacterShops = tmpCharacterShops;
    }
}
