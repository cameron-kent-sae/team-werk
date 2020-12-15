using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitionsManager : MonoBehaviour
{
    // declare the next level to load in the editor
    public string nextLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(nextLevel);
    }
}
