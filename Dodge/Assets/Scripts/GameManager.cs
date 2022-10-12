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

    // ���� ��ɰ� ���õ� �ؽ�Ʈ ǥ�ø� ���� ������
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

        // ���� ���� �ؽ�Ʈ ǥ��
        supertime = playerController.GetSuperReloadTimer();
        if (supertime <= 0f)
        {
            superText.text = "�����̽��ٸ� ���� ����!";
        }
        else
        {
            superText.text = "�������� " + string.Format("{0:0.0}", supertime) + "��";
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

        recordText.text = difficulty + " �ְ���: " + bestTime + "��";
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

        // ���� ����۽� ���� ȸ�� �ʱ�ȭ
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

        // �����ð� �ʱ�ȭ
        playerController.SetSuperReloadTimer(0f);
    }
}
