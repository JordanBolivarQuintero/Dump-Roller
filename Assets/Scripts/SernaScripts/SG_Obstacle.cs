using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG_Obstacle : MonoBehaviour
{
    [SerializeField] CheckPoint restart;

    private void OnTriggerEnter(Collider other)
    {
        GameObject obstacle = other.gameObject;
        if (obstacle.CompareTag("Car"))
        {
            restart.Invoke("CrashRestart", 0.2f);
            Debug.LogError("se reinicia");
            
        }
    }
}
