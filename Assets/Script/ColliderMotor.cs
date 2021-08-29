using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMotor : MonoBehaviour
{
   // public GameObject collisionExplosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //Cannot shoot self
        if (other.gameObject.CompareTag("Player")) return;
        
        // var t = transform;
        // Instantiate(collisionExplosion, t.position, t.rotation);
        
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
