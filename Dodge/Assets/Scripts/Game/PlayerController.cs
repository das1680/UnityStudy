using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 12f;



    // ���콺 ������ ���� �̵���ġ����, ���� ī�޶�
    private Vector3 movePoint;
    private Camera mainCamera;

    public void Die()
    {
        if (!AbilityManager.instance.isSuper)
        {
            gameObject.SetActive(false);

            GameManager.instance.EndGame();
        }
        
    }


    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();



        // ����ī�޶� ����
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameMode) // ���Ӹ�尡 true�� Ű���� ����
        {
            KeyboardControl();
        }
        else
        {
            MouseControl();
        }

        
        
    }

    private void KeyboardControl()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        playerRigidbody.velocity = Vector3.zero;

        playerRigidbody.velocity = new Vector3(xInput, 0f, zInput).normalized * speed;
    }

    private void MouseControl()
    {
        if (Input.GetMouseButton(1))
        {
            int layerMask = (-1) - (1 << LayerMask.NameToLayer("Ignore Raycast"));

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, layerMask))
            {
                movePoint = raycastHit.point;
                movePoint = new Vector3(movePoint.x, 1, movePoint.z);
            }

            playerRigidbody.velocity = (movePoint - transform.position).normalized * speed;
        }
        if (Vector3.Distance(movePoint, transform.position) < 0.15f)
        {
            playerRigidbody.velocity = Vector3.zero;
        }
    }

    public void ResetPlayer()
    {
        AbilityManager.instance.superReloadTimer = 0f;
        playerRigidbody.velocity = Vector3.zero;
    }
}
