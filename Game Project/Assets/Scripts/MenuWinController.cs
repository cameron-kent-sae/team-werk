using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuWinController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            SceneManager.LoadScene("menu_Main");
    }
}
