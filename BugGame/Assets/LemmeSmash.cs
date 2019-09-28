using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemmeSmash : MonoBehaviour
{
    GameObject GO;
    GameObject GO2;
    SpriteRenderer SR;
    Sprite S;
    Sprite S2;
    Rect R;
    Vector2 V;
    Vector3 V3;
    bool clicked;

    // Start is called before the first frame update
    void Start()
    {
        GO = GameObject.Find("Thing");
        GO2 = GameObject.Find("star");
        //Instantiate(GO2);
        SR = GO.GetComponent<SpriteRenderer>();
        S = SR.sprite;
        R = S.rect;
        V3 = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), -19);
        /*V3 = V;
        V3.z = -19;*/
        clicked = false;
        Debug.Log(GO2.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
 
        if (clicked == true)
        {
            ChangePos();
            clicked = false;
        }
        /*Debug.Log(V);
        Debug.Log(V3);
        Debug.Log(GO2.transform.position);
        if (Input.GetKeyDown("space"))
        {
            ChangePos();
        }*/
    }

    void ChangePos()
    {
        V3 = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), -19);
    }

    void OnMouseDown()
    {
        clicked = true;
        GO2.transform.position = V3;
        Debug.Log(GO2.transform.position);
        //Destroy(GO2);
    }
}
