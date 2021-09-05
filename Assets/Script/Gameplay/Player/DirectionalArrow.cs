using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalArrow : MonoBehaviour
{
    public Objective objective;
    private Transform playerTransform;
    private Transform arrow;


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindObjectOfType<PlayerMotor2>().transform;
    }

    // Update is called once per frame
    void Update()
    {
         if(objective != null)
        {
            // if we have an objective
            // Rotate the arrow
            transform.LookAt(objective.GetCurrentRing().position);


            /* Vector3 dir = objective.GetCurrentRing().position;
             dir.y = transform.position.y;
             dir.x = transform.position.x;
             transform.LookAt(dir);
            */

        }
    }
}
