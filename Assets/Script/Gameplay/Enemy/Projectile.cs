using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 100f;
    private Transform player;
    private PlayerMotor2 playerLife;

    private Vector3 target;
    private Vector3 m_StartPosition;
    private float m_MaxDistance;

    // Start is called before the first frame update
    void Start()
    {
        m_MaxDistance = 100f;
        m_StartPosition = transform.position;
        playerLife = FindObjectOfType<PlayerMotor2>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 sourceToDestination = player.position - transform.position;
        target = sourceToDestination.normalized * speed; // Speed must be at least 100
    }

    // Update is called once per frame 
    void Update()
    {
        transform.position += target * Time.deltaTime;
        transform.LookAt(player.transform);

        if (transform.position.x == target.x && transform.position.y == target.y && transform.position.z == target.z)
        {
            DestroyProjectile();
        }
        // detroys the projectile if the max distance is exceed
        OutOfBounds();
    }

    private void OutOfBounds()
    {
        var currentDistance = Vector3.Distance(m_StartPosition, transform.position);
        if (currentDistance > m_MaxDistance)
            DestroyProjectile();
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TOUCHE: "+ playerLife.currentHP);
        MakeDomage(1);
    }

    public void MakeDomage(int damage)
    {
        playerLife.currentHP -= damage;
        playerLife.playerHP.SetHP(playerLife.currentHP);

        if (playerLife.currentHP == 0)
        {
            FindObjectOfType<SceneFader>().FadeTo("GameOver");
        }
    }

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }


}
