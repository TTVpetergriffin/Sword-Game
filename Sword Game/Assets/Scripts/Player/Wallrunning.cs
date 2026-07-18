using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallrunning : MonoBehaviour
{
    public bool wallrunwork;
    public GameObject player;

    public bool onwallLeft;
    public bool onwallRight;
    public bool onwallZP;
    public bool onwallZN;
    // Start is called before the first frame update
    void Start()
    {
        wallrunwork = true;
        onwallLeft = false;
        onwallRight = false;
        onwallZP = false;
        onwallZN = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (onwallLeft == true)
        {
            GetComponent<Rigidbody>().AddForce(9.81f, 0.0f, 0.0f);
        }
        if (onwallRight == true)
        {
            GetComponent<Rigidbody>().AddForce(-9.81f, 0.0f, 0.0f);
        }
        if (onwallZP == true)
        {
            GetComponent<Rigidbody>().AddForce(0.0f, 0.0f, 9.81f);
        }
        if (onwallZN == true)
        {
            GetComponent<Rigidbody>().AddForce(0, 0.0f, -9.81f);

        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "wallLeft")
        {
            
            onwallLeft = true;
        }
        if (other.gameObject.tag == "wallRight")
        {
            onwallRight = true;
        }
        if (other.gameObject.tag == "WallrunZpositive")
        {
            onwallZP = true;
        }
        if (other.gameObject.tag == "WallrunZnegative")
        {
            onwallZN = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "wallLeft")
        {
            onwallLeft = false;
        }
        if (other.gameObject.tag == "wallRight")
        {
            onwallRight = false;
        }
        if (other.gameObject.tag == "WallrunZpositive")
        {
            onwallZP = false;
        }
        if (other.gameObject.tag == "WallrunZnegative")
        {
            onwallZN = false;
        }
    }
}
