using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public Bullet bulletPrefab;
    public Rotator rotator;

    private GameManager gameManager;
    private OptionButton optionButton;

    void Start()
    {
        optionButton = FindObjectOfType<OptionButton>();
        gameManager = FindObjectOfType<GameManager>();
        rotator = FindObjectOfType<Rotator>();
    }

    public void Easy()
    {
        gameManager.difficulty = "easy";
        bulletPrefab.speed = 4f;
        optionButton.OptionClick();
        Time.timeScale = 1;

        rotator.rotationSpeed = 30f;

        gameManager.ReStart();
    }

    public void Normal()
    {
        gameManager.difficulty = "normal";
        bulletPrefab.speed = 8f;
        optionButton.OptionClick();
        Time.timeScale = 1;

        rotator.rotationSpeed = 60f;

        gameManager.ReStart();
    }

    public void Hard()
    {
        gameManager.difficulty = "hard";
        bulletPrefab.speed = 12f;
        optionButton.OptionClick();
        Time.timeScale = 1;

        rotator.rotationSpeed = 90f;

        gameManager.ReStart();
    }
}
