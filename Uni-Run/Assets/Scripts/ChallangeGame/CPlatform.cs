using UnityEngine;

// 발판으로서 필요한 동작을 담은 스크립트
public class CPlatform : MonoBehaviour {
    public GameObject[] obstacles; // 장애물 오브젝트들

    // 컴포넌트가 활성화될때 마다 매번 실행되는 메서드
    private void OnEnable()
    {
        for(int i =0; i < 3; i++)
        {
            if (Random.Range(0, 3) == 0)
            {
                obstacles[i].SetActive(true);
            }
            else
            {
                obstacles[i].SetActive(false);
            }
        }

        if (Random.Range(0, 10) == 0)
        {
            obstacles[3].SetActive(true);
            obstacles[4].SetActive(false);
            return;
        }
        else obstacles[3].SetActive(false);



        if (Random.Range(0, 10) == 0) obstacles[4].SetActive(true);
        else obstacles[4].SetActive(false);
    }
}