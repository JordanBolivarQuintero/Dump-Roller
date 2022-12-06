using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveRestart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Guard"))
        {
            gameObject.SetActive(false);
        }
            
    }
}
