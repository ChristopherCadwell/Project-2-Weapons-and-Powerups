using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : Weapons
{
    [Header("Projectile Behavior")]
    public float speed = 1;
    public float ttl = 1;
    public float projectileDamage = 1;
    public GameObject owner;
    public Rigidbody rb;

    public bool thrown = true;
    // Start is called before the first frame update
    public override void Start()
    {
        rb = GetComponent<Rigidbody>();

        Destroy(gameObject, ttl);//destroy after time to live expires
        rb.velocity = transform.forward * speed;//set velocity to forward * speed
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        
        base.Update();
    }

    public override void OnTriggerEnter(Collider other)
    {
        GameObject collidedWith = other.gameObject;//reference what we hit
        Health collidedWithHealth = collidedWith.GetComponent<Health>();//reference the health component on other object

        if (collidedWithHealth != null)//if object has health
        {
            collidedWithHealth.Damage(projectileDamage);//send projectile damage to other objects damage function
        }
        
        

        Destroy(gameObject);//destroy projectile

       
    }
    

}
