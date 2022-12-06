using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level_selector : MonoBehaviour
{
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorialsito");
       // Debug.Log("hola");
    }
    public void Nivel1()
    {
        SceneManager.LoadScene("Alpha");
    }
    public void Nivel2()
    {
        SceneManager.LoadScene("Second Mode new");
    }
}
