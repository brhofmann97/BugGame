using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBlock : MonoBehaviour
{
    private int count = 0;
    public GameObject spaceIcon;
    // Update is called once per frame
    void Update()
    {
        if (count > 0)
            spaceIcon.SetActive(true);
        else
            spaceIcon.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        count += 1;
    }

    private void OnTriggerExit(Collider other)
    {
        count -= 1;
    }
}
