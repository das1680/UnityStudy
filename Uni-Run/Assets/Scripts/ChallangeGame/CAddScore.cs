using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAddScore : MonoBehaviour
{
    private bool stepped;

    private void OnEnable()
    {
        stepped = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // 플레이어 캐릭터가 자신을 밟았을때 점수를 추가하는 처리
        Debug.Log(collider.tag);
        if (collider.tag == "Player" && !stepped)
        {
            stepped = true;
            GameManager.instance.AddScore(1);
            Time.timeScale = 1 + (float)((int)(GameManager.instance.score / 10))/10;
        }
    }
}
