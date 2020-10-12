using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int lives;
    public float playTime;
    public int progress;

    public PlayerData(Player player)
    {
        lives = player.lives;
        playTime = player.playTime;
        progress = player.progress;
    }
}
