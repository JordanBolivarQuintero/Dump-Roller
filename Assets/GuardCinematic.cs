using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardCinematic : MonoBehaviour
{
    Animator animator;
    bool contador;
    GameObject moto;
    GameObject cameraGuard;
    LevelLogic levelLogic;
    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        moto = GameObject.FindGameObjectWithTag("Moto");
        cameraGuard = GameObject.FindGameObjectWithTag("CameraGuard");
        levelLogic = GameObject.FindGameObjectWithTag("Base").GetComponent<LevelLogic>();
    }

    void Update()
    {
        if (!levelLogic.secondMode)
        {

            if (cameraGuard.activeSelf)
            {
                AnimationOne();
            }
            /*
            time += Time.deltaTime;
            if(time >= counter)
            {
                AnimationOne();
            }*/
            if (animator.GetCurrentAnimatorStateInfo(2).IsName("Shaking Head No") && contador == false)
            {
                animator.SetBool("Cinematic", true);
                contador = true;
            }

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Stand Up"))
            {
                Invoke("Teleport", 5f);
            }
        }
    }

    void AnimationOne()
    {
        animator.SetBool("CinematicON", true);
    }

    void Teleport()
    {
        animator.SetBool("Driving", true);
        /*this.gameObject.transform.position = moto.transform.GetChild(6).position;
        this.gameObject.transform.rotation = moto.transform.GetChild(6).rotation;*/
        moto.transform.parent = this.gameObject.transform;
        moto.transform.position = this.gameObject.transform.GetChild(17).position;
        moto.transform.rotation = this.gameObject.transform.GetChild(17).rotation;
        moto.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

    }
}
