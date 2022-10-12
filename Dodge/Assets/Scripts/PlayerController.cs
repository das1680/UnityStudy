using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 12f;


    // ��������, �������ӽð�, ���� ��Ÿ��
    private bool isSuper;
    private float superTimer = 0f;
    private float superReloadTimer = 0f;

    // �� ������ ���� ��Ƽ����� ���� �� ������ ���� Color
    private Material material;
    private Color color;

    // ���콺 ������ ���� �̵���ġ����, ���� ī�޶�
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

        // ������Ʈ ���������� ��Ƽ���� �̾ƿ�
        material = GetComponent<Renderer>().material;
        color = material.color;

        // ����ī�޶� ����
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameMode) // ���Ӹ�尡 true�� Ű���� ����
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


        // �������¿��� �ѹ� �� ���� ��� �Ѿ� ����
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
        superTimer -= Time.deltaTime;
        superReloadTimer -= Time.deltaTime;

        if (isSuper == true && superTimer <= 0f)
        {
            isSuper = false;

            // ���� ����� �Բ� ���� ������ ���ư�;
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
