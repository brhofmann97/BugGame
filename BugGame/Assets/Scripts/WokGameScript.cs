using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WokGameScript : MonoBehaviour
{
    public GameObject countdown;
    public Sprite numTwo;
    public Sprite numOne;
    public Sprite go;
    public GameObject RightArrowObject;
    public GameObject LeftArrowObject;
    public GameObject SpaceObject;
    static public List<GameObject> KeyList = new List<GameObject>();
    GameObject holderS;
    GameObject holderR;
    GameObject holderL;
    private float levelTimer = 60;
    private bool levelEnded = false;

    public GameObject gameOverScreen;

    private float spawnTimer = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCountdown();
    }

    public static void remove()
    {
        KeyList.Remove(KeyList[0]);
    }

    // This will play first so the game doesn't just start as soon as the game opens. 
    // Giving player a chance to get ready to play.
    void StartCountdown()
    {  
        IEnumerator ExecuteAfterTime(float time)
        {
            yield return new WaitForSeconds(time);
            countdown.SetActive(true);
            yield return new WaitForSeconds(time);
            countdown.GetComponent<SpriteRenderer>().sprite = numTwo;
            yield return new WaitForSeconds(time);
            countdown.GetComponent<SpriteRenderer>().sprite = numOne;
            yield return new WaitForSeconds(time);
            countdown.GetComponent<SpriteRenderer>().sprite = go;
            yield return new WaitForSeconds(time);
            countdown.SetActive(false);
        }
        StartCoroutine(ExecuteAfterTime(1)); // Change number for longer pause for countdown.
    }

    // Update is called once per frame
    void Update()
    {
        if (levelTimer > 0)
        {
            levelTimer -= Time.deltaTime;

            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
                spawnTimer = Random.Range(0.1f, 0.7f);
                int which = Random.Range(1, 4);
                if (which == 1)
                {
                    holderR = Instantiate(RightArrowObject);
                    KeyList.Add(holderR);
                }
                else if (which == 2)
                {
                    holderS = Instantiate(SpaceObject);
                    KeyList.Add(holderS);
                }
                else
                if (which == 3)
                {
                    holderL = Instantiate(LeftArrowObject);
                    KeyList.Add(holderL);

                }

            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (KeyList.Count > 0 && KeyList[0].tag == "Space")
                {
                    Debug.Log(KeyList[0].tag);
                    Destroy(KeyList[0]);
                    KeyList.Remove(KeyList[0]);

                }
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (KeyList.Count > 0 && KeyList[0].tag == "Right")
                {
                    Debug.Log(KeyList[0].tag);
                    Destroy(KeyList[0]);
                    KeyList.Remove(KeyList[0]);

                }
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (KeyList.Count > 0 && KeyList[0].tag == "Left")
                {
                    Debug.Log(KeyList[0].tag);
                    Destroy(KeyList[0]);
                    KeyList.Remove(KeyList[0]);

                }
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
