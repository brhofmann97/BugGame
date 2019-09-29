using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
     public bool gotomainmenu = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            if (gotomainmenu)
                SceneManager.LoadScene(0);
            else
                SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));
    }
}
