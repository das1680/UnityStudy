using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellBullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 6f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")   // ��밡 �÷��̾��
        {
            // �浹�� ����� PlayerController ������Ʈ ������
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)   // ����� ���������� �÷��̾� ����
            {
                playerController.Die();
            }
        }
    }
}