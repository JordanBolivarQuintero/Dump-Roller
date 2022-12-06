using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTime : MonoBehaviour
{
    [SerializeField] float seconds=0f;

    private void OnTriggerEnter(Collider other)
    {
        Timer.timerInstance.AddSecondsToTimer(seconds);
        Destroy(gameObject);
    }
}
