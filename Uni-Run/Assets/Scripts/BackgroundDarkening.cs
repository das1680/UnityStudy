using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundDarkening : MonoBehaviour
{
    private float time = 0f;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameover && time < 1.5)
        {
            GetComponent<SpriteRenderer>().color = new Color(1 - time / 2, 1 - time / 2, 1 - time / 2, 1f);
            time += Time.deltaTime;
        }
    }
}
