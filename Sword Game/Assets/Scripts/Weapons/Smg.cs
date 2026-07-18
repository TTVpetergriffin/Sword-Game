using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Smg : MonoBehaviour
{
    //public AudioSource reloadnoise;
    public GameObject bullet;
    public int Ammo;
    public bool shootcd;
    public TextMeshProUGUI AmmoText;
    public TextMeshProUGUI WeaponText;
    public int reloading;

    // Start is called before the first frame update
    void Start()
    {
        Ammo = 6;
        shootcd = true;
        reloading = 2;
        WeaponText.text = "Weapon: Shotgun";
        //reloadnoise = GetComponent<AudioSource>();
        UpdateAmmo(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (reloading > 1 && Input.GetKey(KeyCode.Mouse0) && Ammo > 0 && shootcd == true)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            shootcd = false;
            StartCoroutine(shootcool());
            Ammo--;
            UpdateAmmo(0);
        }
        if (Input.GetKey("r") && Ammo < 6)
        {
            StartCoroutine(reload());
            AmmoText.text = "Ammo: Reloading";
            reloading = 0;
        }
    }
    IEnumerator shootcool()
    {
        yield return new WaitForSeconds(1f);
        shootcd = true;
    }
    IEnumerator reload()
    {
        yield return new WaitForSeconds(1f);
        //reloadnoise.Play();
        Ammo = 6;
        UpdateAmmo(0);
        reloading = 2;
    }
    private void UpdateAmmo(int AmmoToLose)
    {
        Ammo += AmmoToLose;
        AmmoText.text = "Ammo: " + Ammo;
    }
}