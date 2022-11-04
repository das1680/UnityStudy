using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoMenu : MonoBehaviour
{
    void Update()
    {
        if (MenuManager.menuInstance.isMenu && Input.GetKeyDown(KeyCode.Return))
        {
            GoMenu();
        }
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
