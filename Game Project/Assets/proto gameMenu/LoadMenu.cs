using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    private Button returnBtn;

    private void Start()
    {
        returnBtn = GameObject.Find("Button_Return").GetComponent<Button>();

        returnBtn.onClick.AddListener(ReturnMain);
    }

    private void ReturnMain()
    {
        SceneManager.LoadScene("p_MainMenu");
    }
}
