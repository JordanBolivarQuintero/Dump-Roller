using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anuncios : MonoBehaviour
{
    
    [SerializeField]
    private bool activo;
    public Text frase;
   public void Start()
    {
        activo = true; 
        
    }
    public void quitar()
    {
        if (activo)
        {
            if (Input.anyKeyDown)
            {
                Limpiar();
            }
        }
    }
    
    private void Limpiar()
    {
        activo = false;
    }
}
