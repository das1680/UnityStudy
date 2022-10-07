using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPosition : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        if (GameManager.instance.isHigh)
        {
            transform.position = new Vector2(player.transform.position.x, 4);
        }
        else
        {
            transform.position = new Vector2(player.transform.position.x, 10);
        }
    }
}
