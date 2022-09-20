using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;
    public GameObject player;
    public string difficulty;

    private float surviveTime;
    private bool isGameover;
    private BulletSpawner[] bulletSpawners;
    public Bullet[] bullets;

    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0;
        isGameover = false;
        Time.timeScale = 0;

        bulletSpawners = FindObjectsOfType<BulletSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time: " + (int)surviveTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                ReStart();
            }
        }
    }

    public void EndGame()
    {
        foreach (BulletSpawner i in bulletSpawners)
        {
            i.shoot = false;
        }

        isGameover = true;
        gameoverText.SetActive(true);

        int bestTime = PlayerPrefs.GetInt(difficulty);

        if ((int)surviveTime > bestTime)
        {
            bestTime = (int)surviveTime;
            PlayerPrefs.SetInt(difficulty, bestTime);
        }
        if (difficulty == "easy")
        {
            recordText.text = "Easy 최고기록: " + bestTime + "초";
        }
        else if(difficulty == "normal")
        {
            recordText.text = "Normal 최고기록: " + bestTime + "초";
        }
        else
        {
            recordText.text = "Hard 최고기록: " + bestTime + "초";
        }
    }

    public void ReStart()
    {
        surviveTime = 0f;

        isGameover = false;
        gameoverText.SetActive(false);
        player.SetActive(true);
        player.transform.position = new Vector3(0, 1, 0);

        foreach(BulletSpawner i in bulletSpawners)
        {
            i.shoot = true;
        }

        bullets = FindObjectsOfType<Bullet>();

        foreach (Bullet i in bullets)
        {
            Destroy(i.gameObject);
        }
    }
}
