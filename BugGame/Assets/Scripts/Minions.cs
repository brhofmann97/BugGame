using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minions : MonoBehaviour
{
    int dir;
    // Start is called before the first frame update
    void Start()
    {
        dir = -5;
        GetComponent<Rigidbody2D>().velocity = new Vector2(dir, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "wall")
        {
            Debug.Log("HIT A WALL DAMMIT");
            dir *= -1;
            //gameObject.transform.position = new Vector3((gameObject.transform.position.x - GetComponent<Rigidbody2D>().velocity.x * 10), gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(dir, 0);
        }
    }
}
