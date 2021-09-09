using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor2 : MonoBehaviour
{
    private CharacterController controller;
    public float baseSpeed = 25.0f;
    private float rotSpeedX = 30.0f;
    private float rotSpeedY = 30.0f;
    
    public PlayerHP playerHP;
    public int maxHP = 5;
    public int currentHP;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentHP = maxHP;
        playerHP.SetMaxHP(maxHP);
    }

    // Update is called once per frame
    void Update()
    {
        // Give the player forward velocity
         Vector3 moveVector = transform.forward * baseSpeed;

        // Gather player's input
        Vector3 inputs = Manager.Instance.GetPlayerInput();

        // Get the delta direction 
        Vector3 yaw = inputs.x * transform.right * rotSpeedX * Time.deltaTime;
        Vector3 pitch = inputs.y * transform.up * rotSpeedY * Time.deltaTime;
        Vector3 dir = yaw + pitch;

        // Make sure we limit the player from ding a loop
        float maxX = Quaternion.LookRotation(moveVector + dir).eulerAngles.x;
        // if he is not gooing too far up/down, add the directioon too the moveVector
        if(maxX < 90 && maxX > 70 || maxX > 270 && maxX < 290)
        {
            // Too far! don't do anything
        }
        else
        {
            // Add the direction to the current move
            moveVector += dir;
            // Gave the player face where he is going
            transform.rotation = Quaternion.LookRotation(moveVector);
        }
        // Move him
        controller.Move(moveVector * Time.deltaTime);
    }

    /* public void AttackTarget()
    {
        GameObject laser = Instantiate(projectile_player, transform) as GameObject;
        Rigidbody rb = laser.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * 20;
    }*/


}
