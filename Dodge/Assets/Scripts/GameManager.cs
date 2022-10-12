using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gameMode;

    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;
    public GameObject player;
    public string difficulty;
    public GameObject level;

    private float surviveTime;
    private bool isGameover;
    private BulletSpawner[] bulletSpawners;
    private HellBulletSpawner[] hellBulletSpawners;
    private Bullet[] bullets;
    private HellBullet[] hellBullets;

    // 무적 기능과 관련된 텍스트 표시를 위한 변수들
    public Text superText;
    private PlayerController playerController;
    float supertime;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0;
        isGameover = false;
        Time.timeScale = 0;

        bulletSpawners = FindObjectsOfType<BulletSpawner>();
        hellBulletSpawners = FindObjectsOfType<HellBulletSpawner>();
        playerController = FindObjectOfType<PlayerController>();

        BulletSpawnSetting(2f, 4f);
        difficulty = "Newbie";
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

    public void BulletSpawnSetting(float min, float max)
    {
        foreach (BulletSpawner i in bulletSpawners)
        {
            i.spawnRateMin = min;
            i.spawnRateMax = max;
        }
    }

    public void EndGame()
    {
        foreach (BulletSpawner i in bulletSpawners)
        {
            i.shoot = false;
        }

        foreach (HellBulletSpawner i in hellBulletSpawners)
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

    public void CleanBullets()
    {
        bullets = FindObjectsOfType<Bullet>();

        foreach (Bullet i in bullets)
        {
            Destroy(i.gameObject);
        }

        hellBullets = FindObjectsOfType<HellBullet>();

        foreach (HellBullet i in hellBullets)
        {
            Destroy(i.gameObject);
        }
    }

    public void ReStart()
    {
        surviveTime = 0f;

        isGameover = false;
        gameoverText.SetActive(false);
        player.SetActive(true);
        player.transform.position = new Vector3(0, 1, 0);

        // 게임 재시작시 레벨 회전 초기화
        level.transform.rotation = Quaternion.Euler(0, 0, 0);


        foreach(BulletSpawner i in bulletSpawners)
        {
            i.RestartBulletSpawner();
        }

        foreach (HellBulletSpawner i in hellBulletSpawners)
        {
            i.RestartBulletSpawner();
        }

        CleanBullets();

        // 무적시간 초기화
        playerController.SetSuperReloadTimer(0f);
    }
}
