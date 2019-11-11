using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterShop
{
    public bool[] IceShards { get; set; } = new bool[7];
    public bool BuyCharacter { get; set; } = false;
    private int shardCount = 5;
    public int ShardCount
    {
        get { return shardCount; }
        set
        {
            if (shardCount > 7) shardCount = 7;
            else shardCount = value;
        }
    }
    public int CrushShardCount { get; set; } = 0;
    public int ShardPrice { get; set; } = 30;
}
public static class CommonVariables
{
    public const float InitializedTime = 0.1f;
    public const int CharacterCount = 30;
    public const int MaxIcePieceCount = 7;
    public const int PacksCount = 10;

    public static bool GamePlaying { get; set; } = false; // Playing game
    public static float DepthHook { get; set; } = 1f; // Hook movement base
    public static float CoinPos { get; set; } = 2f; // Current  position coin
    public static int Score { get; set; } // Score game
    public static int Gold { get; set; } = 10000; // Gold
    public static int CurrentIndexPanel { get; set; } // Current scroll index panel
    public static int CurrentPanel { get; set; } // Current panel in pack
    public static int CurrentPack { get; set; } // Current pack in skin menu
    public static int EquippedSkin { get; set; } // Current equipped skin
    public static List<CharacterShop> CharacterShops { get; set; } = new List<CharacterShop>(); // Data of shop buys
    public static SystemLanguage GameLanguage { get; set; } = SystemLanguage.Russian;
    public static int[] CharacterPacks { get; set; } = {3, 3, 3, 3, 3, 3, 3, 3, 3, 3};
    public static bool OnClickPanel { get; set; } = false; // Clicked on panel in skin menu
    public static bool OnMusic { get; set; } = true; // on/off music
    public static bool OnSound { get; set; } = true; // on/off Sound
    public static bool OnVibration { get; set; } = true; // on/off Vibration
}
