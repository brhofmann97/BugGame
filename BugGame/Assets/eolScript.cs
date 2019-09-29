using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class eolScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gameOverScreen.SetActive(true);
        }
    }
}
