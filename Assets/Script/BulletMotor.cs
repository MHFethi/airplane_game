using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMotor : MonoBehaviour
{
    private float m_Speed;
    private float m_MaxDistance;
    private Vector3 m_StartPosition;
    
    // Start is called before the first frame update
    private void Start()
    {
        m_Speed = 40f;
        m_MaxDistance = 30f;
        m_StartPosition = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * m_Speed));
        OutOfBounds();
    }
    
    private void OutOfBounds()
    {
        var currentDistance = Vector3.Distance(m_StartPosition, transform.position);
        if(currentDistance > m_MaxDistance)
            Destroy(gameObject);
    }
    
}