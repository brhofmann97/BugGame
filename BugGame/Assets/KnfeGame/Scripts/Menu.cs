using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public bool gotomainmenu = false;

    public Text scoreText;
    public AudioSource scoreSound;

    public GameObject letterGrade;
    public Text letterGradeText;


    public Button nextLevel;

    private int score;
    private int phase = 1;
    void Update()
    {
        if (phase == 1)
        {
            if (score < 1634522)
            {
                score += UnityEngine.Random.Range(1, 51000);
            }
            else
            {
                phase += 1;
                scoreSound.Stop();
            }

            scoreText.text = score.ToString();

        }
        else if (phase == 2)
        {
            letterGrade.SetActive(true);

            char c = (char)('A' + UnityEngine.Random.Range(0, 26));
            int grade = UnityEngine.Random.Range(1, 4);
            Debug.Log(grade);
            if (grade == 1)
                letterGradeText.text = c.ToString() + "-";
            else if (grade == 2)
                letterGradeText.text = c.ToString();
            else if (grade == 3)
                letterGradeText.text = c.ToString() + "+";

            phase += 1;
        }
        else if (phase == 3)
        {
            nextLevel.interactable = true;
            phase += 1;
        }

    }


    public void ChangeLevel()
    {
        if (gotomainmenu)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));
        }
    }
}
