using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CommonVariables
{
    public const float InitializedTime = 0.1f;
    public const int MaxFishNumber = 6;
    
    public static bool GamePlaying { get; set; } = false; // Playing game
    public static float DepthHook { get; set; } = 1f; // Hook movement base
    public static int Score { get; set; } // Score game
    public static int Gold { get; set; } // Gold
    public static  int FishNumber { get; set; } // Number of fish
}
