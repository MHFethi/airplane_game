using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePlayer : MonoBehaviour
{
    public GameObject laser;
    public Transform barrelRightEnd;
    public Transform barrelLeftEnd;

    public int bulletSpeed;
    public float despawnTime = 3.0f;

    public bool shootAble = true;
    public float waitBeforeNextShot = 0.25f;

    private float timePressed = 0.0f;
    private float timeLastPress = 0.0f;
    public float timeButtonDelayThreshold = 0.5f;
    private Dictionary<int, Vector2> activeTouches = new Dictionary<int, Vector2>();

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {                  // if we just starting pressing on the screen
                // Calcul time betwen two press 
                timePressed = Time.time - timeLastPress;
                activeTouches.Add(touch.fingerId, touch.position);
            }
            else if (touch.phase == TouchPhase.Ended)
            {            // if we remove our finger off the screen
                timeLastPress = Time.time;

                if (activeTouches.ContainsKey(touch.fingerId))
                    activeTouches.Remove(touch.fingerId);

                // If the press time is <= to delayPress then => it's for shooting action 
                if (timePressed <= timeButtonDelayThreshold)
                {
                    AttackTarget();
                }

            }
        }
    }


    public void AttackTarget()
    {
        if (shootAble)
        {
            shootAble = false;
            Shoot(barrelRightEnd);
            Shoot(barrelLeftEnd);
            StartCoroutine(ShootingYield());
        }
    }

    IEnumerator ShootingYield()
    {
        yield return new WaitForSeconds(waitBeforeNextShot);
        shootAble = true;
    }

    void Shoot(Transform barrel)
    {
        var bullet = Instantiate(laser, barrel.position, barrel.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
        Destroy(bullet, despawnTime);
        // Play audio
        laser.GetComponent<AudioSource>().Play();
    }

}
