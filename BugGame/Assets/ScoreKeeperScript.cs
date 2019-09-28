using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeperScript : MonoBehaviour
{
    //scores are in range from 0 - 1
    // 0 = 0%, 1 = 100%
    List<float> scores;
    // Start is called before the first frame update
    void Start()
    {
        scores = new List<float>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void addScore(float f)
    {
        scores.Add(f);
    }

    float scoreAverage()
    {
        float avg = 0.0f;
        foreach (float f in scores)
        {
            avg += f;
        }
        avg /= scores.Count;
        return avg;
    }

    char getLetterGrade(float f)
    {
        //doesnt even use float
        return (char)Random.Range(65, 90);
    }
}