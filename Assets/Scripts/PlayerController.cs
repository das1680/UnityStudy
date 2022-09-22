using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 12f;


    // 무적여부, 무적지속시간, 무적 쿨타임
    private bool isSuper;
    private float superTimer = 0f;
    private float superReloadTimer = 0f;

    // 색 변경을 위한 머티리얼과 원래 색 저정을 위한 Color
    private Material material;
    private Color color;

    public void Die()
    {
        if (!isSuper)
        {
            gameObject.SetActive(false);

            GameManager gamemanager = FindObjectOfType<GameManager>();
            gamemanager.EndGame();
        }
        
    }


    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();

        // 오브젝트 렌더러에서 머티리얼 뽑아옴
        material = GetComponent<Renderer>().material;
        color = material.color;
    }

    // Update is called once per frame
    void Update()
    {

        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        playerRigidbody.velocity = newVelocity;


        // 무적 시간 설정
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (superReloadTimer <= 0f)
            {
                isSuper = true;
                superTimer = 2f;
                superReloadTimer = 10f;

                // 무적과 함께 노랑색으로 변경
                material.color = Color.yellow;
            }
        }
        superTimer -= Time.deltaTime;
        superReloadTimer -= Time.deltaTime;

        if (isSuper == true && superTimer <= 0f)
        {
            isSuper = false;

            // 무적 종료와 함께 원래 색으로 돌아감;
            material.color = color;//new Color(0 / 255f, 100 / 255f, 164 / 255f);
        }
    }

    public float GetSuperReloadTimer()
    {
        return superReloadTimer;
    }

    public void SetSuperReloadTimer(float a)
    {
        superReloadTimer = a;
    }
}
