using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCharacterController : MonoBehaviour
{
    private new Rigidbody rigidbody;
    CharacterController controller;
    public float speed = 6f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        /*Vector3 rot = new Vector3(0f, hor, 0f).normalized;
        Vector3 mov = new Vector3(0f, 0f, ver).normalized;
        
        if (rot.magnitude > 0)
        {
            transform.Rotate(rot * rotSpeed * Time.deltaTime);
        }

        if (mov.magnitude > 0)
        {
            controller.Move(mov * speed * Time.deltaTime);
        }*/

        Vector3 dir = new Vector3(hor, 0f, ver).normalized;

        if (dir.magnitude > 0.01)
        {
            controller.Move(dir * speed * Time.deltaTime);
        }


    }
}
