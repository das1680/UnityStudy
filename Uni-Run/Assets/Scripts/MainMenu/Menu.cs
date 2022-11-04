using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject menubox;
    public static bool ismenu = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) MenuToggle(); 
    }

    public void MenuToggle()
    {
        ismenu = !ismenu;
        if (ismenu)
        {
            menubox.SetActive(true);
        }
        else
        {
            menubox.SetActive(false);
        }
    }
}
