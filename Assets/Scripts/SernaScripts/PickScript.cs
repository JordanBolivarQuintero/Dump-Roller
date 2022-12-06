using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickScript : MonoBehaviour
{
    ObjsScript obPickScript;
    [SerializeField] GameObject pickPosition;
    IPickablesSG pickable;
    bool handBusy = false;

    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKey(KeyCode.E))
        {
            pickable = other.gameObject.GetComponent<IPickablesSG>();
            if (pickable != null)
            {
                //other.enabled = false;
                pickable.Grab(pickPosition);
                handBusy = true;
            }
        }
    }

}
