using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCancel : MonoBehaviour
{
    [SerializeField] Transform car;

    private void LateUpdate()
    {
        transform.rotation = car.rotation;
    }
}
