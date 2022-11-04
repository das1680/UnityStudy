using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMoveAnim : MonoBehaviour
{
    private Vector2 dir;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * Time.deltaTime * 20);
    }

    private void OnEnable()
    {
        GameObject player = FindObjectOfType<CPlayerController>().gameObject;
        transform.position = (Vector2)Camera.main.WorldToScreenPoint(player.transform.position) + new Vector2(0, 100);
         dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}