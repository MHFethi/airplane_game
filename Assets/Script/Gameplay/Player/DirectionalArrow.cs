using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalArrow : MonoBehaviour
{
    public Objective objective;
    private Transform playerTransform;


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindObjectOfType<PlayerMotor2>().transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (objective != null)
        {
            if (objective.GetCurrentRing() != null)
            {
                Vector3 dir = objective.GetCurrentRing().position;

                // if we have an objective, Rotate the arrow. with this, it will also tilt the arrow down or up depending on the Y position of objective
                transform.LookAt(dir);

                // Here the arrow does not tilt on the Y axis 
                dir.y = transform.position.y;
                dir.x = transform.position.x;
                transform.LookAt(dir);
            }
        } 
    }
}
