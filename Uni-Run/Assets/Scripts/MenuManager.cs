using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager menuInstance;
    public bool isMenu;

    public GameObject pause;
    public GameObject resume;
    public GameObject menu;

    // Start is called before the first frame update
    private void Awake()
    {
        if (menuInstance == null) menuInstance = this;
        else Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenu = !isMenu;
            MenuUpdate();
        }
    }

    public void MenuUpdate()
    {
        if (isMenu)
        {
            menu.SetActive(true);
            pause.SetActive(false);
            resume.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            menu.SetActive(false);
            pause.SetActive(true);
            resume.SetActive(false);
            Time.timeScale = GameManager.instance.timescale;
        }
    }

    public void MenuClick()
    {
        isMenu = !isMenu;
        MenuUpdate();
    }
}