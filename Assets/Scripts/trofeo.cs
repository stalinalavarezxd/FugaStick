using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trofeo : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject Trofeo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.gameOver = true;
            Debug.Log("GANASTE!!");
            Destroy(gameObject, 0.2f);
        }
    }
}
