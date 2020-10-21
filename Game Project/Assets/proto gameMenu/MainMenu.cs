using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Button startBtn, optionsBtn, quitBtn;

    private void Start()
    {
        //Find the menu buttons and add listeners to click
        startBtn = GameObject.Find("Start").GetComponent<Button>();
        optionsBtn = GameObject.Find("Options").GetComponent<Button>();
        quitBtn = GameObject.Find("Quit").GetComponent<Button>();

        startBtn.onClick.AddListener(StartGame);
        optionsBtn.onClick.AddListener(StartOptions);
        quitBtn.onClick.AddListener(QuitGame);
    }

    //Load the game select menu
    public void StartGame()
    {
        SceneManager.LoadScene("p_LoadMenu");
    }

    //Load the game options menu
    public void StartOptions()
    {
        SceneManager.LoadScene("p_OptionsMenu");
    }

    //Quit the game
    public void QuitGame()
    {
        Application.Quit();
    }

}
