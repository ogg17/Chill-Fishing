using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterShop
{
    public bool[] IceShards { get; set; } = new bool[7];
    public bool BuyCharacter { get; set; } = false;
    public int ShardCount { get; set; } = 5;
    public int CrushShardCount { get; set; } = 0;
    public int ShardPrice { get; set; } = 30;
}
public static class CommonVariables
{
    public const float InitializedTime = 0.1f;
    public const int MaxFishNumber = 8;
    public const int CharacterCount = 30;
    public const int MaxIcePieceCount = 7;
    public const int PacksCount = 10;

    public static bool GamePlaying { get; set; } = false; // Playing game
    public static float DepthHook { get; set; } = 1f; // Hook movement base
    public static int Score { get; set; } // Score game
    public static int Gold { get; set; } = 1000; // Gold
    public static int CurrentPanel { get; set; } // Current scroll panel
    public static int EquippedSkin { get; set; } // Current equipped skin
    public static List<CharacterShop> CharacterShops { get; set; } = new List<CharacterShop>(); // Data of shop buys
    public static SystemLanguage GameLanguage { get; set; } = SystemLanguage.English;
    public static int[] CharacterPacks { get; set; } = {3, 3, 3, 3, 3, 3, 3, 3, 3, 3};
}
