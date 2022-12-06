using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjsScript : MonoBehaviour, IPickablesSG
{
    Rigidbody rg;

    public void Grab(GameObject newParent)
    {
        gameObject.transform.position = newParent.transform.position;
        gameObject.transform.SetParent(newParent.transform);
    }

    public void Throw()
    {
        gameObject.transform.parent = null;
        rg = gameObject.GetComponent<Rigidbody>();
        rg.AddForce(Vector3.forward * 300);
    }
}
