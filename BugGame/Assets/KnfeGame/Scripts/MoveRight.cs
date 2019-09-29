using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{

    public GameObject left, right;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(15,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        GameObject leftSide = GameObject.Instantiate(left);
        leftSide.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 7);
        leftSide.transform.position = transform.position;

        GameObject rightSide = GameObject.Instantiate(right);
        rightSide.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 7);
        rightSide.transform.position = transform.position;

        Destroy(leftSide, 3);
        Destroy(rightSide, 3);
    }
}
