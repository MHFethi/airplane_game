using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    private  Objective objectiveScript;
    private bool ringActive = false;

    private void Start()
    {
        objectiveScript = FindObjectOfType<Objective>();
    }


    public void RingActived()
    {
        Debug.Log("ringActive : " + ringActive);
        ringActive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");

        // if the ring is active 
        // Tell the objective script that is has been passed through
        if (ringActive)
          {
             objectiveScript.NextRing();
             Debug.Log("Enter ");
        }
    }   
}
