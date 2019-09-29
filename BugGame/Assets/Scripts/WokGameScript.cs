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

    private float spawnTimer = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCountdown();
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
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            spawnTimer = Random.Range(0.1f, 0.7f);
            int which = Random.Range(1, 4);
            if (which == 1)
            {
                Instantiate(RightArrowObject);
            }
            else if (which == 2)
            {
                Instantiate(SpaceObject);
            }
            else
            if (which == 3)
            {
                Instantiate(LeftArrowObject);
            }
        }
    }
}
