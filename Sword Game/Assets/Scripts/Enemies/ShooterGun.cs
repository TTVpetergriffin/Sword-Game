using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterGun : MonoBehaviour
{
    public float health;
    public bool danger;
    private GameObject player;
    public GameObject EnemyBullet;
    public bool CanShoot;
    // Start is called before the first frame update
    void Start()
    {
        danger = false;
        player = GameObject.Find("Main Character");
    }

    // Update is called once per frame
    void Update()
    {
        if (danger == true)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        }
        if (danger == true && CanShoot)
        {
            Instantiate(EnemyBullet, transform.position, transform.rotation);
            CanShoot = false;
            StartCoroutine(ShootCooldown());
        }
    }
    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "dangerzone")
        {
            danger = true;

        }
    }
    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(.5f);
        CanShoot = true;
    }

}
