using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    public float lookRadius = 10f;
    private Transform target;
    [SerializeField]float rotationalDamp =.5f;
    [SerializeField] float moveSpeed = 10f;
  
    private bool aggro;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            aggro = true;
        }
    
        if (aggro)
        {
            Turn();
            Move();
            AttackTarget();
        }
    }

    void Turn()
    {
        Vector3 pos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
    }

    void Move() {
       transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void AttackTarget()
    {
        if (timeBtwShots <= 0) {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
 
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }



}
