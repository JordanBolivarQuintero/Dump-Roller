using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject pause; 
    [SerializeField] GameObject levelLogic;
    [SerializeField] GameObject carParts;
    [SerializeField] GameObject joystick;
    [SerializeField] GameObject character;
    Animator animator;
   // [SerializeField] GameObject manager;
    private bool cond1 = true, cond2 = true;
    private PausaMenu pausaBool;
    private LevelLogic lvl;
    [SerializeField] Flowchart fc;
    Vector3 vectorinicial;
    void Start()
    {
        pausaBool = pause.GetComponent<PausaMenu>();
        lvl = levelLogic.GetComponent<LevelLogic>();
        joystick.SetActive(false);
        animator = character.GetComponent<Animator>();
    }

    void Update()
    {
        if (pausaBool.tuto == true & cond1 == true)
        {
            PrimerEvento();
            fc.ExecuteBlock("Evento 1");
        }

        if(character.transform.position.x != 0 && cond2 == true)
        {
            Invoke("SegundoEvento", 5.0f);
            cond2 = false;
        }

        if(lvl.tuto == true)
        {
            Ending();
        }
    }

    private void PrimerEvento() {
        cond1 = false;
        joystick.SetActive(true);
        animator.SetBool("started", true);
       // manager.SetActive(true);
        cond2 = true;
        vectorinicial = character.transform.position;
    }
    private void SegundoEvento()
    {
        cond2 = false;
        carParts.SetActive(true);
        fc.ExecuteBlock("Evento 2");
    }
    private void Ending()
    {
        fc.ExecuteBlock("Evento 3");
        this.gameObject.SetActive(false);
    }
}
