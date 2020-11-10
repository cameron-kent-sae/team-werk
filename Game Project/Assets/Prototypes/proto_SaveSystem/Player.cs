using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int lives = 99;
    public float playTime = 0f;
    public int progress = 1;

    public Text livesText, playTimeText, progressText;

    void Start()
    {
        //Save Load Testing
        livesText = GameObject.Find("Lives").GetComponent<Text>();
        playTimeText = GameObject.Find("PlayTime").GetComponent<Text>();
        progressText = GameObject.Find("Progress").GetComponent<Text>();
    }

    private void Update()
    {
        //Save Load Testing
        livesText.text = lives.ToString();
        progressText.text = progress.ToString();
        playTime += Time.deltaTime;
        playTimeText.text = playTime.ToString("F2") + "s";
    }

    //these methods should go to a gameManager
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        lives = data.lives;
        playTime = data.playTime;
        progress = data.progress;
    }
}
