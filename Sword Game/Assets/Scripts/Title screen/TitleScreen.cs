using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public void Training()
    {
        SceneManager.LoadScene("Siege");
    }
    public void SwordLoader()
    {
        SceneManager.LoadScene("Sword Test");
    }
}