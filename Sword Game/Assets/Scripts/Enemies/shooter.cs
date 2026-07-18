using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.AI;

public class shooter : MonoBehaviour
{
    public float speed;
    public float health;
    private Rigidbody enemyRb;
    private GameObject player;
    public bool danger;
    public AudioSource Spotted;
    public AudioClip Rev;
    public bool SpottedPlayed;
    private NavMeshAgent Chaser;
    public Transform ThePlayer;
    public GameObject EnemyBullet;
    public bool CanShoot;
    [SerializeField] private playerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        
        speed = 1f;
        health = 2f;
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Main Character");
        danger = false;
        Chaser = GetComponent<NavMeshAgent>();
        CanShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(this.gameObject);
            playerControllerScript.money++;
            playerControllerScript.UpdateMoney(0);
        }
     if (danger == true)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            Chaser.SetDestination(ThePlayer.position);
        }
     if (danger == true && !SpottedPlayed)
        {
            Spotted.Play();
            SpottedPlayed = true;
        }
        if (danger == true && CanShoot)
        {
            Instantiate(EnemyBullet, transform.position, transform.rotation);
            CanShoot = false;
            StartCoroutine(ShootCooldown());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health--;
        }
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(hitstop());
        }
    }
    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "dangerzone")
        {
            danger = true;
        }
        if (trigger.gameObject.tag == "EnemyDamage")
        {
            health--;
        }
    }
    IEnumerator hitstop()
    {
        yield return new WaitForSeconds(0);
        speed = 0;
        StartCoroutine(hitrecovery());
    }
    IEnumerator hitrecovery()
    {
        yield return new WaitForSeconds(2);
        speed = 1f;
    }
    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(.5f);
        CanShoot = true;
    }
}
