using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Play : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) PlayGame();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
}
