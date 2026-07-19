using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class SwordAnim : MonoBehaviour
{
    Animator anim1;
    public GameObject Player;
    public bool swinging;
    void Start()
    {
        anim1 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        swinging = Player.GetComponent<PSwordAttack>().Swinging;
        if (Input.GetMouseButtonDown(0) && swinging == true)
        {
            anim1.SetTrigger("Attack");
        }
    }
}
