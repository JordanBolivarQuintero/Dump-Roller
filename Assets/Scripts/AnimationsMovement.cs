using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsMovement : MonoBehaviour
{
    Animator animator;
    private float inputX;
    private float inputZ;
    managerJoystick _managerJoystick;
    void Awake()
    {
        animator = GetComponent<Animator>();
        _managerJoystick = GameObject.Find("imgJoystickBg").GetComponent<managerJoystick>();
    }

    void Update()
    {
        InputVertical();
        InputHorizontal();
    }

    void InputVertical()
    {
        inputZ = _managerJoystick.inputVertical();
        float z = Input.GetAxis("Vertical");
        animator.SetFloat("Velocity", z);
        animator.SetFloat("Velocity", inputZ);
    }

    void InputHorizontal()
    {
        inputX = _managerJoystick.inputHorizontal();
        float x = Input.GetAxis("Horizontal");
        animator.SetFloat("Turn", x);
        animator.SetFloat("Turn", inputX);
    }
}
