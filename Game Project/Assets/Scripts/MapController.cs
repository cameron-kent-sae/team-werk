using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    public string menuScene, gameScene;

    void Update()
    {
        //when ESC key pressed - loads main menu screen
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene(menuScene);
        } else if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene(gameScene);
        }

    }
}
