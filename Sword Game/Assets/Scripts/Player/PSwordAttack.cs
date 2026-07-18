using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSwordAttack : MonoBehaviour
{
    [SerializeField] private GameObject SwordSwingBasic;
    public bool CanSwing;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CanSwing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && CanSwing)
        {
            SwordSwingBasic.SetActive(true);
            CanSwing = false;
            StartCoroutine(SwordStop());

        }
    }
    IEnumerator SwordStop()
    {
        yield return new WaitForSeconds(0.01f);
        SwordSwingBasic.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        CanSwing = true;
    }
}
