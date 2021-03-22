using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapons : MonoBehaviour
{
    //private bool isAttacking = false;//later use


    [Header("Damage")]
    public float weaponDamage = 1;


    public Transform origin;
    public GameObject projectilePrefab;

    [Header("IK Points")]
    public Transform rightHandPoint;
    public Transform leftHandPoint;

    [Header("Events")]
    public UnityEvent OnMainAttackDown;
    public UnityEvent OnMainAttackUp;
    public UnityEvent OnAltAttackDown;
    public UnityEvent OnAltAttackUp;

    [Header("Character")]
    public Pawn pawn;

    

    // Start is called before the first frame update
    public virtual void Start()
    {
        pawn = transform.root.GetComponent<Pawn>();
        origin = GameObject.FindGameObjectWithTag("Origin").transform;
    }

    // Update is called once per frame
    public virtual void Update()
    {

    }
    public virtual void MainAttackDown()
    {
        OnMainAttackDown.Invoke();
    }
    public virtual void MainAttackUp()
    {
        OnMainAttackUp.Invoke();
    }
    public virtual void AltAttackDown()
    {
        OnAltAttackDown.Invoke();
    }
    public virtual void AltAttackUp()
    {
        OnAltAttackUp.Invoke();
    }
    public virtual void OnCollisionEnter(Collision collision)
    {

    }

    //Longsword
    public virtual void LongSwordAttackStart()
    {
        if (!pawn.anim.GetBool("LongSwordAttack"))//if not attacking
        {
            pawn.anim.SetBool("LongSwordAttack", true);//play attack animation
        }
    }

    public virtual void LongSwordAttackEnd()
    {
        if (pawn.anim.GetBool("LongSwordAttack"))//if attacking
        {
            pawn.anim.SetBool("LongSwordAttack", false);//stop attack animation
        }
    }
    public virtual void LongSwordAltStart()
    {
        //block
        pawn.anim.SetBool("SwordBlock", true);//start block anim
    }

    public virtual void LongSwordAltEnd()
    {
        //return to normal
        if (pawn.anim.GetBool("SwordBlock"))//make sure blocking is happening
        {
            pawn.anim.SetBool("SwordBlock", false);//stop block animation
        }
    }


    //dagger

    public virtual void DaggerAttackStart()
    {
        if (!pawn.anim.GetBool("DaggerAttack"))//if not attacking
        {
            pawn.anim.SetBool("DaggerAttack", true);//play attack animation
        }
    }

    public virtual void DaggerAttackEnd()
    {
        if (pawn.anim.GetBool("DaggerAttack"))//if attacking
        {
            pawn.anim.SetBool("DaggerAttack", false);//stop attack animation
        }
    }

    public virtual void DaggerAltStart()
    {
        //nothing this attack happens on button up
    }

    public virtual void DaggerAltEnd()
    {
        //throw
        Throw();
    }

    //spear

    public virtual void SpearAttackStart()
    {
        if (!pawn.anim.GetBool("SpearAttack"))//if not attacking
        {
            pawn.anim.SetBool("SpearAttack", true);//play attack animation
        }
    }

    public virtual void SpearAttackEnd()
    {
        if (pawn.anim.GetBool("SpearAttack"))//if attacking
        {
            pawn.anim.SetBool("SpearAttack", false);//stop attack animation
        }
    }

    public virtual void SpearAltStart()
    {
        //throw
        Throw();
    }

    public virtual void SpearAltEnd()
    {
        //nothing -- This fires on attack down
    }


    
    
    //projectile
    public virtual void Throw()
    {
        GameObject ThrownProjectile = Instantiate(projectilePrefab, origin.position, origin.rotation);//create projectile object
        Ammo ThrownProjectileScript = ThrownProjectile.GetComponent<Ammo>();//get component from new projectile
    }



    //collision events
    public virtual void OnTriggerEnter(Collider thingWeHit)//make sure to use collider and not collision.  Pass in weapon damage from weapon
    {
        Pawn hitTarget = thingWeHit.GetComponent<Pawn>();//set the target to the the thing we hit
        Debug.Log("we hit a " + thingWeHit);
        if (hitTarget.transform.root.GetComponent<Health>())//if target has a health component
        {
            Health health = hitTarget.transform.root.GetComponent<Health>();//reference for health component of object we are hitting
            health.Damage(weaponDamage);//call objects damage function, give it the weapon damage of equipped weapon
        }

    }
}
