using Photon.Pun;
using UnityEngine;

public class Coin : MonoBehaviourPun, IItem
{
    public int score = 50;

    public void Use(GameObject target)
    {
        GameManager.instance.AddScore(score);
        PhotonNetwork.Destroy(gameObject);
    }
}
