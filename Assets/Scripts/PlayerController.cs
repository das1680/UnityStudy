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

        // ������Ʈ ���������� ��Ƽ���� �̾ƿ�
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


        // ���� �ð� ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (superReloadTimer <= 0f)
            {
                isSuper = true;
                superTimer = 2f;
                superReloadTimer = 10f;

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
