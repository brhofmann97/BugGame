using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WokGameScript : MonoBehaviour
{
    public GameObject countdown;
    public Sprite numTwo;
    public Sprite numOne;
    public Sprite go;

    // Start is called before the first frame update
    void Start()
    {
        StartCountdown();
    }

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
        StartCoroutine(ExecuteAfterTime(1));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
