using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PausaMenu : MonoBehaviour
{
    public static bool pausa;
    public GameObject pausaMenu;
    public bool tuto = false;
    private void Start()
    {
        bntContinuar();
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Pause();         
        }
    }
    public void Pause()
    {
        tuto = true;
        if (pausa)
        {
            bntContinuar();           
        }
        else
        {
            btnPausa();
        }
    }
    void bntContinuar()
    {
        pausaMenu.SetActive(false);
        Time.timeScale = 1;
        pausa = false;
      
    }
    void btnPausa()
    {
        pausaMenu.SetActive(true);
        Time.timeScale = 0;
        pausa = true;    
    }
    public void retornoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void reiniciarAlpha()
    {
        SceneManager.LoadScene("Alpha");
    }
    public void reiniciarAlpha1()
    {
        SceneManager.LoadScene("Alpha level2");
    }
    public void reiniciarAlpha2()
    {
        SceneManager.LoadScene("Alpha level3");
    }
    public void reiniciartuto()
    {
        SceneManager.LoadScene("New Second Mode");
    }
    public void reiniciar1()
    {
        SceneManager.LoadScene("New Second Mode 1");
    }
    public void reiniciar2()
    {
        SceneManager.LoadScene("New Second Mode 2");
    }
    public void reiniciar3()
    {
        SceneManager.LoadScene("New Second Mode 3");
    }

}
