using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
        if (other.tag == "Player")   // 상대가 플레이어면
        {
            // 충돌한 대상의 PlayerController 컴포턴트 가져옴
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)   // 제대로 가져왔으면 플레이어 죽임
            {
                playerController.Die();
            }
        }
    }
}
