using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBullet : MonoBehaviour
{
    public float speed;
    public float posbound;
    public float negbound;
    // Start is called before the first frame update
    void Start()
    {
        speed = 50f;
        posbound = 50;
        negbound = -50;
    }

    // Update is called once per frame
    void Update()
    {
            transform.position += transform.forward * speed * Time.deltaTime;
        if (transform.position.x > posbound || transform.position.y > posbound || transform.position.z > posbound || transform.position.x < negbound || transform.position.y < negbound || transform.position.z < negbound)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("RedPlayer") || other.gameObject.CompareTag("BluePlayer") || other.gameObject.CompareTag("Shield"))
        {
            Destroy(this.gameObject);
            Debug.Log("suidh");
        }
    }
}
