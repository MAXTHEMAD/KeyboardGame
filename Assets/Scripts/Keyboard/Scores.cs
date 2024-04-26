using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Scores
{
    public static Dictionary<string, int> scoreOnSongs = new Dictionary<string, int>()
    {
        {"Lofi",0},
        {"Funk",0}
    };

    public static void transferScore(int score, string name)
    {
        scoreOnSongs[name] = score;
    }
}
