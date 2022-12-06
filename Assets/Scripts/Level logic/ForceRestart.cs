using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceRestart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            if (other.GetComponent<CheckPoint>().forceRestart == false)
            {
                other.GetComponent<CheckPoint>().forceRestart = true;
                Debug.Log(other.GetComponent<CheckPoint>().forceRestart);
            }
            else
                GameObject.FindGameObjectWithTag("Base").GetComponent<LevelLogic>().state = LevelLogic.LevelState.Lose;
        }
        if (other.CompareTag("ground"))
        {
            GameObject.FindGameObjectWithTag("Car").GetComponent<CheckPoint>().forceRestart = true;
        }
    }
}
