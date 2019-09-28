using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatch : MonoBehaviour
{
    bool running = false;
    float starplatinum = 0f;
    float zawarudo = 0f;
    // Start is called before the first frame update
    public void SetTimer(float timer)
    {
        zawarudo = timer;
    }

    public void StartClock()
    {
        running = true;
    }

    public void StopClock()
    {
        running = false;
    }

    public float GetElapsed()
    {
        return starplatinum;
    }

    public void ResetClock()
    {
        starplatinum = 0;
    }

    public bool CheckClock()
    {
        if(starplatinum >= zawarudo)
        {
            return true;
        }
        return false;
    }

    void Start(){}

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            starplatinum += Time.deltaTime;
        }
    }
}
