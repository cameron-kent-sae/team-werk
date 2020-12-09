using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{

    public string menuScene;

    void Update()
    {
        //when ESC key pressed - loads main menu screen
        if (Input.GetKeyDown("Cancel"))
            SceneManager.LoadScene(menuScene);

    }

}
