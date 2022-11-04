using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    private float time = 0f;
    private int stack = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) stack++;

        if(stack > 0) time += Time.deltaTime;
        if (time > 1f)
        {
            stack = 0;
            time = 0f;
        }

        if (stack >= 2) QuitGame();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
