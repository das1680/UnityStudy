using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutAnim : MonoBehaviour
{
    float time = 0f;
    public float _fadeTime = 1f;

    // Update is called once per frame
    void Update()
    {
        if(time < _fadeTime)
        {
            GetComponent<Text>().color = new Color(0, 0, 0, 1f - time/_fadeTime);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        time += Time.deltaTime;
    }

    private void OnEnable()
    {
        GetComponent<Text>().color = Color.black;
        time = 0f;
    }
}
