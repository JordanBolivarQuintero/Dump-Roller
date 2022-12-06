using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clicked : MonoBehaviour
{
    [SerializeField] GameObject objeto;
    Animator animator;
    Button button;
    void Start()
    {
        animator = objeto.GetComponent<Animator>();
        button = GetComponent<Button>();
        button.onClick.AddListener(ClickedEvent);
    }

    void ClickedEvent()
    {
        animator.enabled = true;
    }
}
