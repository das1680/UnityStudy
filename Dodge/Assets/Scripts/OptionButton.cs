using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton : MonoBehaviour
{
    public GameObject inGameUI;
    public GameObject menuUI;

    private bool isMenu;

    // Start is called before the first frame update
    void Start()
    {
        isMenu = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) OptionClick();
    }

    public void OptionClick()
    {
        if (isMenu)
        {
            inGameUI.SetActive(true);
            menuUI.SetActive(false);
            isMenu = false;
            Time.timeScale = 1;
        }
        else
        {
            inGameUI.SetActive(false);
            menuUI.SetActive(true);
            isMenu = true;
            Time.timeScale = 0;
        }
    }
}
