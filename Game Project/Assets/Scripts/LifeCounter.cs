using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeCounter : MonoBehaviour
{
    public int playerLives;
    public TMP_Text lifeCountText;

    private void Start()
    {
        playerLives = GameplayData.Lives;
        lifeCountText = GameObject.Find("LifeCountText").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        playerLives = GameplayData.Lives;
        UpdateLifeDisplay();
    }

    //Remove a life from the counter when the character dies
    public void LoseLife()
    {
        playerLives = playerLives - 1;
        GameplayData.Lives = playerLives;
        if (playerLives == 0)
        {
            SceneManager.LoadScene("menu_LoseCondition");
        }
        UpdateLifeDisplay();
    }

    //Add a life to the counter when the character collects a 'black box'
    public void AddLife()
    {
        playerLives = playerLives + 1;
        GameplayData.Lives = playerLives;
        UpdateLifeDisplay();
    }

    //Update the UI with the current life count
    public void UpdateLifeDisplay()
    {
        lifeCountText.text = playerLives.ToString();
    }
}
