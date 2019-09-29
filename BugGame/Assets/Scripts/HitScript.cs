using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    public float screenBottom;
    public float targetHit;
    public bool kill = false;

    public int SkillReturn()
    {
        kill = true;
        if (transform.position.y <= -2f && transform.position.y >= -2.16)
        {
            Debug.Log("Exact");
            return 1;
        }
        else if (transform.position.y <= -1.9f && transform.position.y >= -2.25)
        {
            Debug.Log("Close");
            return 2;
        }
        else if (transform.position.y <= -1.6f && transform.position.y >= -2.5)
        {
            Debug.Log("Off");
            return 3;
        }
        else
        {
            Debug.Log("Miss");
            return 4;
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(0, -4.1f * Time.deltaTime, 0);       

        if (transform.position.y <= screenBottom || kill == true)
        {
            WokGameScript.remove();
            Destroy(gameObject);
        }
    }
}
