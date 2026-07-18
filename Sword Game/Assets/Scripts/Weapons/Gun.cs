using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gun : MonoBehaviour
{
    public float shootCooldown;
    public float projectileSpeed;
    public GameObject Bullet;
    public bool canShoot;
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && canShoot)
        {
        Instantiate(Bullet, transform.position, transform.rotation);
        canShoot = false;
        StartCoroutine(ShootCooldown());
        }
    }
    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(1.0f);
        canShoot = true;
    }
}
