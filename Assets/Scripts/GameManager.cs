using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Weapon Prefabs")]
    public Object LongSwordPre;
    public Object SpearPre;
    public Object DaggerPre;
    public Object HarmPre;
    public Object HealPre;
    public Object DummyPre;

    [Header("SpawnPoints")]
    public Transform spearSpawn;
    public Transform longSwordSpawn;
    public Transform daggerSpawn;
    public Transform harmSpawn;
    public Transform healSpawn;
    public Transform DummySpawn;

    [Header("Spawn Timing")]
    public float pickupSpawnDelay = 5;
    [SerializeField]
    private float nextSpawnTime;

    //arrays to hold objects
    GameObject[] spears;
    GameObject[] longSwords;
    GameObject[] daggers;
    GameObject[] harms;
    GameObject[] heals;
    GameObject[] dummys;


    public static GameManager instance = null;

    //Singleton  only one instance
    void Awake()
    {
        if (GameManager.instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        //load prefabs into objects
        LongSwordPre = Resources.Load("Prefabs/PULongsword");
        DaggerPre = Resources.Load("Prefabs/PUDagger");
        SpearPre = Resources.Load("Prefabs/PUSpear");
        HealPre = Resources.Load("Prefabs/HealPre");
        HarmPre = Resources.Load("Prefabs/HarmPre");
        DummyPre = Resources.Load("Prefabs/Vampire");
        nextSpawnTime = Time.time + pickupSpawnDelay;//set timer for next spawn
    }

    // Update is called once per frame
    private void Update()
    {
        
    }


    void FixedUpdate()
    {
        

        //get a count of objects
        spears = GameObject.FindGameObjectsWithTag("Spear");
        daggers = GameObject.FindGameObjectsWithTag("Dagger");
        longSwords = GameObject.FindGameObjectsWithTag("LongSword");
        harms = GameObject.FindGameObjectsWithTag("Harm");
        heals = GameObject.FindGameObjectsWithTag("Heal");
        dummys = GameObject.FindGameObjectsWithTag("Dummy");

        if (Time.time > nextSpawnTime)//time to spawn
        {
            //weapons

            // if no weapon
            if (spears.Length == 0)
            {
                //create a new spear at the spear spawn point
                GameObject Spear = (GameObject)Instantiate(SpearPre, spearSpawn.position, spearSpawn.rotation);
            }

            if (daggers.Length == 0)
            {
                //create a new dagger at the dagger spawn point
                GameObject Dagger = (GameObject)Instantiate(DaggerPre, daggerSpawn.position, daggerSpawn.rotation);
            }

            if (longSwords.Length == 0)
            {
                //create a new sword at the sword spawn point
                GameObject LongSword = (GameObject)Instantiate(LongSwordPre, longSwordSpawn.position, longSwordSpawn.rotation);
            }
            
            //Pickups
            
            
            if (harms.Length == 0)
            {
                //create a new harm pickup at the harm spawn point
                GameObject Harm = (GameObject)Instantiate(HarmPre, harmSpawn.position, harmSpawn.rotation);
            }
            if (heals.Length == 0)
            {
                //create a new heal pickup at the heal spawn point
                GameObject Heal = (GameObject)Instantiate(HealPre, healSpawn.position, healSpawn.rotation);
            }


            //enemies

            if (dummys.Length == 0)//no training dummies
            {
                GameObject Dummy = (GameObject)Instantiate(DummyPre, DummySpawn.position, DummySpawn.rotation);//spawn dummy at dummy spawn point
            }
            
            
            
            
            
            
            nextSpawnTime = Time.time + pickupSpawnDelay;//reset timer for next spawn
        }
    }
    
}


