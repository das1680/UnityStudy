using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkAnim : MonoBehaviour
{
    float time;
    public float timer = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (time < timer)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 - time / timer);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, time / timer - 1);
            if (time > timer * 2)
            {
                time = 0;
            }
        }

        time += Time.deltaTime;
        
    }
}
