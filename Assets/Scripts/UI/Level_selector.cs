using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_selector : MonoBehaviour
{
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorialsito");
    }
    public void Nivel1()
    {
        SceneManager.LoadScene("Alpha");
    }
    public void Nivel2()
    {
        SceneManager.LoadScene("newLevel");
    }
    public void Nivel3()
    {
        SceneManager.LoadScene("level2");
    }
    public void Modo2Tutorial()
    {
        SceneManager.LoadScene("Second Mode new");
    }
    public void ModoNivel1()
    {
        SceneManager.LoadScene("");
    }
    public void ModoNivel2()
    {
        SceneManager.LoadScene("");
    }
    public void ModoNivel3()
    {
        SceneManager.LoadScene("");
    }
    public void retornoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("me fui");
    }
}
