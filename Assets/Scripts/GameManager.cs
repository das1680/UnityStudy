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

    // 무적 기능과 관련된 텍스트 표시를 위한 변수들
    public Text superText;
    private PlayerController playerController;
    float supertime;

    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0;
        isGameover = false;
        Time.timeScale = 0;
        difficulty = "Newbie";

        bulletSpawners = FindObjectsOfType<BulletSpawner>();
        playerController = FindObjectOfType<PlayerController>();
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

        // 무적 관련 텍스트 표기
        supertime = playerController.GetSuperReloadTimer();
        if (supertime <= 0f)
        {
            superText.text = "스페이스바를 눌러 무적!";
        }
        else
        {
            superText.text = "무적까지 " + string.Format("{0:0.0}", supertime) + "초";
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

        recordText.text = difficulty + " 최고기록: " + bestTime + "초";
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

        // 무적시간 초기화
        playerController.SetSuperReloadTimer(0f);
    }
}
