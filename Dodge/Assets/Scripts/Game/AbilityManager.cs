using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    static public AbilityManager instance;

    // ��������, �������ӽð�, ���� ��Ÿ��
    public bool isSuper;
    private float superTimer = 0f;
    public float superReloadTimer;

    // �� ������ ���� ��Ƽ����� ���� �� ������ ���� Color
    public GameObject player;
    private Material material;
    private Color color;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        superReloadTimer = 0f;

        // ������Ʈ ���������� ��Ƽ���� �̾ƿ�
        material = player.GetComponent<Renderer>().material;
        color = material.color;
    }


    void Update()
    {
        // �������¿��� �ѹ� �� ���� ��� �Ѿ� ����
        if (Input.GetKeyDown(KeyCode.Space) && isSuper == true)
        {
            superReloadTimer += 10f;

            GameManager.instance.CleanBullets();
        }

        // ���� �ð� ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (superReloadTimer <= 0f)
            {
                isSuper = true;
                superTimer = 1f;
                superReloadTimer = 5f;

                // ������ �Բ� ��������� ����
                material.color = Color.yellow;
            }
        }


        if (superTimer > 0) superTimer -= Time.deltaTime;
        if (superReloadTimer > 0) superReloadTimer -= Time.deltaTime;

        if (isSuper == true && superTimer <= 0f)
        {
            isSuper = false;

            // ���� ����� �Բ� ���� ������ ���ư�;
            material.color = Color.white; // new Color(0 / 255f, 100 / 255f, 164 / 255f);
        }

        if (!isSuper && superReloadTimer <= 0) material.color = color;
    }
}
