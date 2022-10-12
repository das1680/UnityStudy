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

    // 마우스 조작을 위한 이동위치벡터, 메인 카메라
    public Vector3 movePoint;
    public Camera mainCamera;

    public void Die()
    {
        if (!isSuper)
        {
            gameObject.SetActive(false);

            GameManager.instance.EndGame();
        }
        
    }


    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();

        // 오브젝트 렌더러에서 머티리얼 뽑아옴
        material = GetComponent<Renderer>().material;
        color = material.color;

        // 메인카메라 설정
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameMode) // 게임모드가 true면 키보드 조작
        {
            float xInput = Input.GetAxis("Horizontal");
            float zInput = Input.GetAxis("Vertical");

            playerRigidbody.velocity = new Vector3(xInput, 0f, zInput).normalized * speed;
        }
        else
        {
            if (Input.GetMouseButton(1))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

                if(Physics.Raycast(ray, out RaycastHit raycastHit))
                {
                    movePoint = raycastHit.point;
                    movePoint = new Vector3(movePoint.x, 1, movePoint.z);
                }

                playerRigidbody.velocity = (movePoint - transform.position).normalized * speed;
            }
            if(Vector3.Distance(movePoint, transform.position) < 0.08f)
            {
                playerRigidbody.velocity = Vector3.zero;
            }
        }


        // 무적상태에서 한번 더 쓰면 모든 총알 제거
        if (Input.GetKeyDown(KeyCode.Space) && isSuper == true)
        {
            superReloadTimer += 10f;

            Bullet[] bullets = FindObjectsOfType<Bullet>();

            foreach (Bullet i in bullets)
            {
                Destroy(i.gameObject);
            }

            HellBullet[] hellBullets = FindObjectsOfType<HellBullet>();

            foreach (HellBullet i in hellBullets)
            {
                Destroy(i.gameObject);
            }
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
