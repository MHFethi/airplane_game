using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public GameObject textDisplay;
    public int secondsLeft = 30;
    public bool takingAway = false;

    // Start is called before the first frame update
    void Start()
    {
        textDisplay.GetComponent<Text>().text = "" + secondsLeft;
    }

    // Update is called once per frame
    void Update()
    {
       if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(timerTake());
        }
    }

    IEnumerator timerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        textDisplay.GetComponent<Text>().text = ""+secondsLeft;
        takingAway = false;
    }

    public int GetSecondLeft()
    {
        return secondsLeft;
    }

    public void SetSecondLeft(int timer)
    {
        this.secondsLeft = timer;
    }

}
