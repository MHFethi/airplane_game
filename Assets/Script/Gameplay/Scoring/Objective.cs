using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Objective : MonoBehaviour
{
    private List<Transform> rings = new List<Transform>();
    public Material activeRing;
    public Material inactiveRing;
    public Material finalRing; 
    private int ringPassed = 0;
    public SaveState state;


    public void Start()
    {

        // at the start of the level, assign inactive to all rngs
        foreach (Transform t in transform)
        {
            rings.Add(t);
            t.GetComponent<MeshRenderer>().material = inactiveRing;
        }
        Debug.Log(rings.Count);

        // Making sure we're not stupid;
        if (rings.Count == 0)
        {
            Debug.Log("There is no objectives assign to this level; make sure yoou put some rings under the objectives object");
            return;
        }

        // Activate the first ring
        rings[ringPassed].GetComponent<MeshRenderer>().material = activeRing;
        rings[ringPassed].GetComponent<Ring>().RingActived();
    }

    public void NextRing()
    {

        /* Let trigger animation on ring. After created the animation in Animation unity
         * Open our animation controller (here Ring in asset/animation/)
         * Make a transition between IdleRing and CompletedRing
         * Create a Param (type trigger) and named it "collectionTrigger)
         * Click on the arrow in the transition link and add collectionTrigger in the coondition list
         * Set the trigger in this script in the nextRing method
         */
        rings[ringPassed].GetComponent<Animator>().SetTrigger("collectionTrigger");

        // Increment the ringPassed
        ringPassed++;
        //If it is the final ring, let's call the victory
        if(ringPassed == rings.Count)
        {
            Victory();
            return;
        }

        //If this is the previous last, give the next ring the "Final ring" material
        if (ringPassed == rings.Count - 1)
            rings[ringPassed].GetComponent<MeshRenderer>().material = finalRing;
        else
            rings[ringPassed].GetComponent<MeshRenderer>().material = activeRing;
            
           
        
        // in both cases, we need to activate the ring
            rings[ringPassed].GetComponent<Ring>().RingActived();
        
        Debug.Log("SCORING:" + ringPassed);
    }


    public Transform GetCurrentRing()
    {
        if(rings.Count > 0)
        {
            return rings[ringPassed];

        }
        Debug.Log("no Current ring:" + rings.Count);

        return null;
        
    }
    private void Victory()
    {
        FindObjectOfType<SceneFader>().FadeTo("StageClear");
       // SceneManager.LoadScene("StageClear");
    }
}
