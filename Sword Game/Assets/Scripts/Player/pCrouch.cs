using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
public class pCrouch : MonoBehaviour
{
    public float slideForce = 20.0f;
    public bool canSlide;
    private Rigidbody playerRb;
    [SerializeField] private pJump pJumpScript;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        canSlide = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && canSlide && pJumpScript.isOnGround == true)
        {
        playerRb.AddForce(Vector3.forward * slideForce, ForceMode.Impulse);
        canSlide = false;
        StartCoroutine(SlideWait());
        }
    }
    IEnumerator SlideWait()
    {
        yield return new WaitForSeconds(1f);
        canSlide = true;
    }
}
