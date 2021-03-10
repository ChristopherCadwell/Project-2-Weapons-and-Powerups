using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : Pickups
{
    [Header("Events")]
    [SerializeField, Tooltip("Raised when object is healed")]
    private UnityEvent onHeal;
    [SerializeField, Tooltip("Raised when object is damaged")]
    private UnityEvent onDamage;
    [SerializeField, Tooltip("Raised when object dies")]
    private UnityEvent onDie;



    [SerializeField, Tooltip("Current Health")]
    public float health;
    public float maxHealth = 100;


    public float percent;
    private float overKill;
    private float overHeal;

    //death sound
    public AudioSource aud;
    public AudioClip deathNoise;
    // Start is called before the first frame update
    public override void Start()
    {
        health = maxHealth;//give object some life
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        percent = health / maxHealth;
        base.Update();
    }

    //how to handle damage
    public void Damage(float damage)
    {
        damage = Mathf.Max(damage, 0);//make sure damage is a positive number

        if (damage > health)//if damage is greater than current health
        {
            overKill = damage - health;//get the amount of overkill damage
        }
        else//damage not more than current health
        {
            overKill = 0;//output 0
            health = Mathf.Clamp(health - damage, 0f, health);//subtract damage from health, making sure not to subtract more than current health value
        }
        Debug.Log("Damage done, new health value....");
        Debug.Log(health);
        SendMessage("OnDamage", SendMessageOptions.DontRequireReceiver);
        onDamage.Invoke();

        if (health == 0)//if health reaches 0
        {
            SendMessage("onDie", SendMessageOptions.DontRequireReceiver);//tell every object this is attched to to look for its onDie method -dont error if none
            onDie.Invoke();//call onDie
            Debug.Log("OnDie Message Sent");
        }
    }

    //how to handle healing
    public void Heal(float heal)
    {

        heal = Mathf.Max(heal, 0);//make sure the number is positive
        Debug.Log(heal);

        if (heal > (maxHealth - health))//if the ammount healed would put the target over max health
        {
            overHeal = heal - (maxHealth - health);//get amount of overhealing
        }
        else//if healing does not result in over heal
        {
            overHeal = 0;//no overheal
        }
        health = Mathf.Clamp(health + heal, 0, maxHealth);//heal for an ammount not to exceed max health
        SendMessage("OnHeal", SendMessageOptions.DontRequireReceiver);//tell every object this is attched to to look for its onDie method no error if not found
        onHeal.Invoke();
    }

    public void Death()
    {
        //need to add this to the player portion, destroy prevents audio from playing
        //aud.PlayOneShot(deathNoise) ;//play death sound

        Debug.Log("Called death function");

        GameObject.Destroy(this.gameObject);//destroy game object
       
    }
    

}
