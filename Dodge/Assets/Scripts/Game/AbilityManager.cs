using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    static public AbilityManager instance;

    // 무적여부, 무적지속시간, 무적 쿨타임
    public bool isSuper;
    private float superTimer = 0f;
    public float superReloadTimer;

    // 색 변경을 위한 머티리얼과 원래 색 저정을 위한 Color
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

        // 오브젝트 렌더러에서 머티리얼 뽑아옴
        material = player.GetComponent<Renderer>().material;
        color = material.color;
    }


    void Update()
    {
        // 무적상태에서 한번 더 쓰면 모든 총알 제거
        if (Input.GetKeyDown(KeyCode.Space) && isSuper == true)
        {
            superReloadTimer += 10f;

            GameManager.instance.CleanBullets();
        }

        // 무적 시간 설정
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (superReloadTimer <= 0f)
            {
                isSuper = true;
                superTimer = 1f;
                superReloadTimer = 5f;

                // 무적과 함께 노랑색으로 변경
                material.color = Color.yellow;
            }
        }


        if (superTimer > 0) superTimer -= Time.deltaTime;
        if (superReloadTimer > 0) superReloadTimer -= Time.deltaTime;

        if (isSuper == true && superTimer <= 0f)
        {
            isSuper = false;

            // 무적 종료와 함께 원래 색으로 돌아감;
            material.color = Color.white; // new Color(0 / 255f, 100 / 255f, 164 / 255f);
        }

        if (!isSuper && superReloadTimer <= 0) material.color = color;
    }
}
