using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCup : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Active()
    {
        gameObject.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();

        if(playerController != null)
        {
            GameManager.Instance?.WinGame();
        }
    }
}
