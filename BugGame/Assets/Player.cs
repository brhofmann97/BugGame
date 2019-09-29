using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    StopWatch JumpWatch;
    StopWatch AttackWatch;
    // Start is called before the first frame update
    Rigidbody2D rb;
    BoxCollider2D bc;
    Camera cam;
    float speed = 10f;
    List<GameObject> collisions;
    Animator ani;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        collisions = new List<GameObject>();
        ani = GetComponent<Animator>();
        JumpWatch = GetComponent<StopWatch>();
        AttackWatch = GetComponent<StopWatch>();
        cam = Camera.main;
        JumpWatch.SetTimer(0.1f);
        AttackWatch.SetTimer(0.1f);
        JumpWatch.StartClock();
        AttackWatch.StartClock();
    }

    // Update is called once per frame
    void Update()
    {
        var input = Input.GetAxis("Horizontal");
        var movement = input * speed;
        Vector3 camPos = cam.transform.position;
        Vector3 playPos = this.transform.position;
        cam.transform.position = new Vector3(playPos.x,camPos.y,camPos.z);
        if (movement != 0)
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
            rb.AddForce(new Vector2(0,500));
        }
        if (Input.GetKey(KeyCode.Space) & CanAttack())
        {
            ani.SetTrigger("attack");
        }
    }

    bool CanAttack()
    {
        if (AttackWatch.CheckClock())
        {
            AttackWatch.ResetClock();
            return true;
        }
        return false;
    }

    bool CanJump()
    {
        if (JumpWatch.CheckClock())
        {
            foreach (GameObject o in collisions)
            {
                if (o.name == "Floor" || o.tag == "floor")
                {
                    ani.SetBool("jump", false);
                    return true;
                }
            }
        }
        return false;
    }

    void Hurt()
    {
        ani.SetTrigger("hurt");
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
