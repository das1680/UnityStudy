using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayChallenge: MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("ChallengeGame");
        Time.timeScale = 1;
    }
}
