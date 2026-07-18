using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gun : MonoBehaviour
{
    public float shootCooldown;
    public float projectileSpeed;
    public GameObject Bullet;
    public bool canShoot;
    public Slider cooldownSlider;
    public GameObject cooldownSliderObject;
    public float cooldownTime = 1.0f;
    public float currentCooldown = 0.0f;
    public bool isCooldownActive = false;
    void Start()
    {
        canShoot = true;
        cooldownSlider.value = 1.0f;
        cooldownSliderObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooldownActive)
        {
            currentCooldown -= Time.deltaTime;
            cooldownSlider.value = currentCooldown / cooldownTime; 
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse1) && canShoot)
        {
        Instantiate(Bullet, transform.position, transform.rotation);
        isCooldownActive = true;
        canShoot = false;
        StartCoroutine(ShootCooldown());
        cooldownSliderObject.SetActive(true);
        
        }
    }
    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(1.0f);
        canShoot = true;
        cooldownSliderObject.SetActive(false);
        isCooldownActive = false;
        currentCooldown = 1.0f;
    }
}
