using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuClick : MonoBehaviour
{
    public void Click()
    {
        MenuManager.menuInstance.MenuClick();
    }
}
