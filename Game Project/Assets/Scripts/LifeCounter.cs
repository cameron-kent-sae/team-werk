﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour
{
    public int playerLives = 99;
    public TMP_Text lifeCountText;

    private void Start()
    {
        lifeCountText = GameObject.Find("LifeCountText").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        UpdateLifeDisplay();
    }

    //Remove a life from the counter when the character dies
    public void LoseLife()
    {
        playerLives = playerLives - 1;
        UpdateLifeDisplay();
    }

    //Add a life to the counter when the character collects a 'black box'
    public void AddLife()
    {
        playerLives = playerLives + 1;
        UpdateLifeDisplay();
    }

    //Update the UI with the current life count
    public void UpdateLifeDisplay()
    {
        lifeCountText.text = playerLives.ToString();
        if (playerLives == 0)
        {
            SceneManager.LoadScene("menu_LoseCondition");
        }
    }
}