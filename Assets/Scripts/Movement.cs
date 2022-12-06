using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private new Rigidbody rigidbody;
    [SerializeField] float speed = 10f;
    [SerializeField] float movMin = 0.01f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(hor, 0f, ver).normalized;

        if (dir.magnitude >= movMin)
        { 
            rigidbody.MovePosition(transform.position + dir * speed * Time.deltaTime);
        }
    }

}
