using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollition : MonoBehaviour
{
    private GameManager gameManager;
    private AudioManager audioManager;

    void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            audioManager.PlayCoinSound();
            gameManager.AddPoin(1);
            //Debug.Log(" + 1 ");
        }       
       
        else if(collision.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            //Debug.Log("Winnnnnnnnnn!!!");
            gameManager.GameWin();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    if (collision.gameObject.CompareTag("Enemy") ||
        collision.gameObject.CompareTag("Zone"))
        {
            gameManager.GameOver();
        }
}   
}
