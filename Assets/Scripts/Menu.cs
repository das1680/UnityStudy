using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public Bullet bulletPrefab;
    private Rotator rotator;

    private GameManager gameManager;
    private OptionButton optionButton;

    public GameObject hellLevel;

    void Start()
    {
        optionButton = FindObjectOfType<OptionButton>();
        gameManager = FindObjectOfType<GameManager>();
        rotator = FindObjectOfType<Rotator>();
    }

    public void Newbie()
    {
        gameManager.difficulty = "Newbie";
        bulletPrefab.speed = 6f;
        optionButton.OptionClick();
        Time.timeScale = 1;

        rotator.rotationSpeed = 0f;

        gameManager.BulletSpawnSetting(2f, 4f);

        hellLevel.SetActive(false);

        gameManager.ReStart();
    }

    public void Easy()
    {
        gameManager.difficulty = "easy";
        bulletPrefab.speed = 6f;
        optionButton.OptionClick();
        Time.timeScale = 1;

        rotator.rotationSpeed = 30f;

        gameManager.BulletSpawnSetting(1f, 3f);

        hellLevel.SetActive(false);

        gameManager.ReStart();
    }

    public void Normal()
    {
        gameManager.difficulty = "normal";
        bulletPrefab.speed = 8f;
        optionButton.OptionClick();
        Time.timeScale = 1;

        rotator.rotationSpeed = 60f;

        gameManager.BulletSpawnSetting(0.5f, 2.5f);

        hellLevel.SetActive(false);

        gameManager.ReStart();
    }

    public void Hard()
    {
        gameManager.difficulty = "hard";
        bulletPrefab.speed = 12f;
        optionButton.OptionClick();
        Time.timeScale = 1;

        rotator.rotationSpeed = 90f;

        gameManager.BulletSpawnSetting(0.5f, 3f);

        hellLevel.SetActive(false);

        gameManager.ReStart();
    }

    public void Hell()
    {
        gameManager.difficulty = "hell";
        bulletPrefab.speed = 12f;
        optionButton.OptionClick();
        Time.timeScale = 1;

        rotator.rotationSpeed = 90f;

        gameManager.BulletSpawnSetting(0.5f, 3f);

        hellLevel.SetActive(true);

        gameManager.ReStart();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
