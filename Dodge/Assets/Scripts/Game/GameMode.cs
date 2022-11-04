using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMode : MonoBehaviour
{
    public void ToggleClcik(bool isOn)
    {
        if (isOn)
        {
            GameManager.instance.gameMode = true;
        }
        else
        {
            GameManager.instance.gameMode = false;
        }
    }
}
