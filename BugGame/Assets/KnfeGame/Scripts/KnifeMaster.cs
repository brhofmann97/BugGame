using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeMaster : MonoBehaviour
{
    public GameObject gameOverScreen;

    public Transform spawnPoint;
    public GameObject points;
    public GameObject[] bugs;

    public AudioSource pointSound;
    public AudioSource music;
    public AudioSource chopSound;

    public AudioClip pointsOne;
    public AudioClip pointsTwo;


    public GameObject knifeUp;
    public GameObject knifeDown;
    private bool cut = false;

    private float musicTimer = 3.2f;
    private bool musicStarted = false;
    private float timer = 2.0f;
    private float levelTimer = 60;
    private bool levelEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!musicStarted)
        {
            if (musicTimer <= 0)
            {
                musicStarted = true;
                music.Play();
            }
            else
            musicTimer -= Time.deltaTime;
        }


        if (cut)
        {
            cut = false;
            knifeUp.SetActive(true);
            knifeDown.SetActive(false);
        }

        if (levelTimer > 0)
        {
            levelTimer -= Time.deltaTime;
            // input
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(GameObject.Find("bug"));

                cut = true;
                knifeUp.SetActive(false);
                knifeDown.SetActive(true);

                GameObject go = GameObject.Instantiate(points);
                go.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-5, 5), Random.Range(7, 20));
                //Destroy(go, 5);

                chopSound.Play();

                if (Random.Range(0, 2) > 0)
                {
                    pointSound.clip = pointsOne;
                    pointSound.Play();
                }
                else
                {
                    pointSound.clip = pointsTwo;
                    pointSound.Play();
                }
            }

            // bug spawning
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = Random.Range(0.15f, 1.5f);
                GameObject go = GameObject.Instantiate(bugs[Random.Range(0, 4)]);
                go.transform.position = spawnPoint.position;
                go.name = "bug";
                Destroy(go, 5);
            }
        }
        else
        {
            if (!levelEnded)
            {
                levelEnded = true;
                gameOverScreen.SetActive(true);
            }

            
        }
    }
}
