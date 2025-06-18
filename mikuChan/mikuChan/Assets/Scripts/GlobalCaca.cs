using Unity.VisualScripting;
using UnityEngine;
public static class GlobalMetrics // Global Variables
{
    static public int level = 1; // the level of the funny stuff
    static public float speed = 1.0f;// the speed for the minigames
    static public int totalLevelsPlayed = 0;// the total amount of levels;
    static public int lives = 4; // the amount of lives the player has

    static public bool winner = true; // what happens after the player finishes a mini game
}
