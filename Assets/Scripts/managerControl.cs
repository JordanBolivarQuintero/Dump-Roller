using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerControl : MonoBehaviour
{
    private CharacterController _characterController;
    private managerJoystick _managerJoystick;

    private Animator anim;
    [SerializeField] bool animatorON = false;


    //Variables
    private float inputX;
    private float inputZ;
    private Vector3 v_movementx, v_movementy;
    public Vector3 v_velocity;
    private float moveSpeed;
    private float gravity;
    void Start()
    {
        GameObject tempPlayer = GameObject.FindGameObjectWithTag("Player");
        _characterController = tempPlayer.GetComponent<CharacterController>();

        anim = tempPlayer.GetComponent<Animator>();

        moveSpeed = 4f;
        gravity = 0.5f;

        _managerJoystick = GameObject.Find("imgJoystickBg").GetComponent<managerJoystick>();
    }
    void Update()
    {
        //inputX = Input.GetAxis("Horizontal");
        //inputZ = Input.GetAxis("Vertical");

        inputX = _managerJoystick.inputHorizontal();
        inputZ = _managerJoystick.inputVertical();

       /* if (animatorON == true & (v_movementx != Vector3.zero || v_movementy != Vector3.zero)) anim.SetBool("isWalking", true);
        else if(animatorON == true & (v_movementx == Vector3.zero || v_movementy == Vector3.zero)) anim.SetBool("isWalking", false);*/
    }

    private void FixedUpdate()
    {
        if (_characterController.isGrounded)
        {
            v_velocity.y = 0f;
        }
        else
        {
            v_velocity.y -= gravity * Time.deltaTime;
        }
        
        v_movementy = _characterController.transform.forward * inputZ;
        v_movementx = _characterController.transform.right * inputX;

        // _characterController.transform.Rotate(Vector3.up * inputX * (100f * Time.deltaTime));

        _characterController.Move(v_movementy * moveSpeed * Time.deltaTime);

        _characterController.Move(v_movementx * moveSpeed * Time.deltaTime);

        _characterController.Move(v_velocity);
    }

}
