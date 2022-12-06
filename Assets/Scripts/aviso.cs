using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aviso : MonoBehaviour
{
    private bool entro = false;
    public GameObject texto;
    private void Start()
    {
       texto.SetActive(false);
    }
    private void OnTriggerEnter()
    {
        entro = true;
    }
    private void OnTriggerExit()
    {
        entro = false;
    }
    public void Texto()
    {
       
    }
    private void Update()
    {
        if (entro == true)
        {
            texto.SetActive(true);
        }
        else
        {
            texto.SetActive(false);
        }
    }
}
