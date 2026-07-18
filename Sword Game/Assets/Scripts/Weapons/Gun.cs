using UnityEngine;

public class Gun : MonoBehaviour
{
    public float shootCooldown;
    public float projectileSpeed;
    public GameObject Bullet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
        Instantiate(Bullet, transform.position, transform.rotation);
        }
    }
}
