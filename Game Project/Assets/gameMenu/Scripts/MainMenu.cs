using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour

{
    public Button playButton;
    public string gameScene;
    public void Start()
    {
        playButton = GameObject.Find("MB_StartGame").GetComponent<Button>();
        playButton.onClick.AddListener(PlayGame);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(gameScene);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

}
