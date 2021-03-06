using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    private  Objective objectiveScript;
    private bool ringActive = false;
    private CountdownTimer timer ;
    private int addtimer;

    private void Start()
    {
        timer = FindObjectOfType<CountdownTimer>();
        objectiveScript = FindObjectOfType<Objective>();
    }


    public void RingActived()
    {
        ringActive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // if the ring is active 
        // Tell the objective script that is has been passed through
        if (ringActive)
        {
            if (other.CompareTag("Player")) {
                ScoreCounter.scoreValue += 100; // add scoring
                addtimer = timer.GetSecondLeft() + 5; // add more time at timer
                timer.SetSecondLeft(addtimer);
                objectiveScript.NextRing(); // We passed to the next ring
            }                  
        }
    }   
}
