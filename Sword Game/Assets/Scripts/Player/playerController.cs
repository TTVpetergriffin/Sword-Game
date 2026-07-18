using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data.SqlTypes;

public class playerController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public float horizontalInput;
    public float forwardInput;
    public bool tomfoolery;
    public bool IsWalking;
    public int health;
    public GameObject GameOver;
    public TextMeshProUGUI healthtext;
    public GameObject TheActualPlayer;
    private CapsuleCollider hitbox;
    public float money;
    public TextMeshProUGUI moneytext;
    // Start is called before the first frame update
    void Start()
    {
        tomfoolery = false;
        IsWalking = false;
        health = 3;
        UpdateHealth(0);
        UpdateMoney(0);
    }

    // Update is called once per frame
void Update()
{
        horizontalInput = Input.GetAxis("Horizontal");
    forwardInput = Input.GetAxis("Vertical");

        // Check if there's any movement input
        if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(forwardInput) > 0.1f)
        {
            // If there's movement input, set isWalking to true
            IsWalking = true;
        }
        else
        {
            // If there's no movement input, set isWalking to false
            IsWalking = false;
        }

            // Moving forward and backward
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

    // Turning left and right
    transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

    if (tomfoolery == true)
    {
        speed = 1;
    }
        // Crouching
        if (Input.GetKey(KeyCode.LeftControl))
        {
            //CapsuleCollider.height = 1.0f;
        }

        // Moving left and right
        if (Input.GetKey(KeyCode.A))
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
    else if (Input.GetKey(KeyCode.D))
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
        if (health < 1)
        {
            Instantiate(GameOver, transform.position, transform.rotation);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Destroy(TheActualPlayer.gameObject);
        }
}
    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "5g")
        {
            speed = 1;
            tomfoolery = true;
        }
        if (trigger.gameObject.tag == "5gsoftball")
        {
            speed = 1;
            StartCoroutine(Soaft());
        }
    }
    private void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.tag == "5g")
        {
            speed = 5;
            tomfoolery = false;
        }
    }
    IEnumerator Soaft()
    {
        yield return new WaitForSeconds(2);
        speed = 5;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health--;
            UpdateHealth(0);
        }
        if (collision.gameObject.tag == "Wall")
        {
        }
    }
    private void UpdateHealth(int healthToSteal)
    {
        health += healthToSteal;
        healthtext.text = "Health: " + health;
    }
    public void UpdateMoney(int MoneyDollar)
    {
        money += MoneyDollar;
        moneytext.text = ": " + money;
    }
}

