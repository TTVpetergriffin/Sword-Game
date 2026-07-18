using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pJump : MonoBehaviour
{
    // Start is called before the first frame update
    public float jumpForce;
    public float djumpForce;
    private Rigidbody playerRb;
    public float gravityModifier;
    public bool isOnGround;
    public bool djump;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        isOnGround = true;
        djump= false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            StartCoroutine(djumpstarter());
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isOnGround && djump)
        {
            playerRb.AddForce(Vector3.up * djumpForce, ForceMode.Impulse);
            djump = false;
        }

    }
    IEnumerator djumpstarter()
    {
        yield return new WaitForSeconds(0.01f);
        djump = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") )
        {
            isOnGround = true;
        }
    }
}
