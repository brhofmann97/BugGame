using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    StopWatch JumpWatch;
    // Start is called before the first frame update
    Rigidbody2D rb;
    BoxCollider2D bc;
    float speed = 200f;
    List<GameObject> collisions;
    Animator ani;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        JumpWatch = GetComponent<StopWatch>();
        collisions = new List<GameObject>();
        ani = GetComponent<Animator>();
        JumpWatch.SetTimer(0.1f);
        JumpWatch.StartClock();
    }

    // Update is called once per frame
    void Update()
    {
        var input = Input.GetAxis("Horizontal");
        var movement = input * speed;
        
        if(movement != 0)
        {
            if (movement > 0)
            {
                ani.SetBool("left", false);
            }
            if (movement < 0)
            {
                ani.SetBool("left", true);
            }
            ani.SetBool("walk", true);
        }
        else
        {
            ani.SetBool("walk", false);
        }
        rb.velocity = new Vector2(movement, rb.velocity.y);
        if(Input.GetKey(KeyCode.W) & CanJump()){
            ani.SetBool("jump", true);
            JumpWatch.ResetClock();
            rb.AddForce(new Vector2(0,10000));
        }
    }

    bool CanJump()
    {
        if (JumpWatch.CheckClock())
        {
            foreach (GameObject o in collisions)
            {
                if (o.name == "Floor")
                {
                    ani.SetBool("jump", false);
                    return true;
                }
            }
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        collisions.Add(col.gameObject);
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        collisions.Remove(col.gameObject);
    }
}
