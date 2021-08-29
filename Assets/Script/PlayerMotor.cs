using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private float m_Speed, m_RotationSpeed;

    //Keyboard inputs
    private KeyCode m_InputUp, m_InputDown, m_InputLeft, m_InputRight, m_InputS, m_InputD, m_FireInput;

    public GameObject bulletPrefab;
    
    // Start is called before the first frame update
    private void Start()
    {
        m_Speed = 5f;
        m_RotationSpeed = 100f;
        m_InputUp = KeyCode.UpArrow;
        m_InputDown = KeyCode.DownArrow;
        m_InputLeft = KeyCode.LeftArrow;
        m_InputRight = KeyCode.RightArrow;
        m_InputS = KeyCode.S;
        m_InputD = KeyCode.D;
        m_FireInput = KeyCode.Space;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        //Auto move forward
        transform.Translate(0, 0, Time.deltaTime * m_Speed);
        
        PlayerControls();
    }

    private void PlayerControls()
    {
        XAxisRotation();
        ZAxisRotation();
        YAxisRotation();
        ShootPrefab();
    }
    
    private void XAxisRotation()
    {
        if (Input.GetKey(m_InputDown))
        {
            //Unity API Vector3.right = shortcut for Vector3(1,0,0)
            transform.Rotate(Vector3.right * (m_RotationSpeed * Time.deltaTime));
        }

        if (Input.GetKey(m_InputUp))
        {
            //Unity API Vector3.left = shortcut for Vector3(-1,0,0)
            transform.Rotate(Vector3.left * (m_RotationSpeed * Time.deltaTime));
        }
    }

    private void ZAxisRotation()
    {
        if (Input.GetKey(m_InputLeft))
        {
            //Unity API Vector3.forward = shortcut for Vector3(0,0,1)
            transform.Rotate(Vector3.forward * (m_RotationSpeed * Time.deltaTime));
        }

        if (Input.GetKey(m_InputRight))
        {
            //Unity API Vector3.back = shortcut for Vector3(0,0,-1)
            transform.Rotate(Vector3.back * (m_RotationSpeed * Time.deltaTime));
        }
    }

    private void YAxisRotation()
    {
        if (Input.GetKey(m_InputD))
        {
            //Unity API Vector3.up = shortcut for Vector3(0,1,0)
            transform.Rotate(Vector3.up * (m_RotationSpeed * Time.deltaTime));
        }

        if (Input.GetKey(m_InputS))
        {
            //Unity API Vector3.down = shortcut for Vector3(0,-1,0)
            transform.Rotate(Vector3.down * (m_RotationSpeed * Time.deltaTime));
        }
    }

    private void ShootPrefab()
    {
        if (Input.GetKey(m_FireInput))
        {
            var t = transform;
            Instantiate(bulletPrefab, t.position, t.rotation);
        }
    }
    
}
