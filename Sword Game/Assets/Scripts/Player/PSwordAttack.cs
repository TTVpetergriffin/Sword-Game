using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSwordAttack : MonoBehaviour
{
    [SerializeField] private GameObject SwordSwingBasic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            SwordSwingBasic.SetActive(true);
            StartCoroutine(SwordStop());
        }
    }
    IEnumerator SwordStop()
    {
        yield return new WaitForSeconds(0.01f);
        SwordSwingBasic.SetActive(false);
    }
}
