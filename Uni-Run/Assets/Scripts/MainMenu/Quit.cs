using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public GameObject menu;
    private void Update()
    {
        if(menu.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            QuitGame();
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
