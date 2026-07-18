using UnityEngine;

public class SwordAnim : MonoBehaviour
{
    Animator anim1;
    void Start()
    {
        anim1 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            anim1.SetTrigger("Attack");
        }
    }
}
