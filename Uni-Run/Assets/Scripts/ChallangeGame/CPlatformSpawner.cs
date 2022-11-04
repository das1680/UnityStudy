using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public int count = 5;

    public float timeBetSpawn=0.955f;

    private float xPos = 14f;

    private GameObject[] platforms;
    private int currentIndex = 0;

    private Vector2 poolPosition = new Vector2(0, -25);
    private float lastSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        platforms = new GameObject[count];

        for(int i =0; i < count; i++)
        {
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);
        }

        lastSpawnTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameover) return;

        if (Time.time >= lastSpawnTime + timeBetSpawn)
        {
            lastSpawnTime = Time.time;

            float yPos = -1f;

            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);

            platforms[currentIndex].transform.position = new Vector2(xPos, yPos);

            currentIndex++;

            if (currentIndex >= count) currentIndex = 0;
        }
    }
}
