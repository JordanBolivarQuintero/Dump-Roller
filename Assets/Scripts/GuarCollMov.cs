using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuarCollMov : MonoBehaviour
{
    [SerializeField] Transform guard;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = guard.position;
        transform.rotation = guard.rotation;
    }
}
