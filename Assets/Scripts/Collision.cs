using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Collision : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera raceCamera;
    [SerializeField] NEWCARCONTROLLER carController;

    CinemachineBasicMultiChannelPerlin noiseCamera;
    Rigidbody carRB;

    float x = 0;

    void Awake()
    {
        noiseCamera = raceCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        carRB = carController.rb;
    }

    private void Update()
    {
        if (noiseCamera.m_AmplitudeGain > 0)
        {
            noiseCamera.m_AmplitudeGain -= 3f * Time.deltaTime;
        }
        if (noiseCamera.m_AmplitudeGain < 0)
        {
            noiseCamera.m_AmplitudeGain = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        x = 2.5f * Mathf.Sqrt(carRB.velocity.magnitude - 7) / 4;
        if (other.CompareTag("Obstaculo"))
        {
            //SONIDO 
            if (x > 0)
            {
                noiseCamera.m_AmplitudeGain = x;
            }
            else
                noiseCamera.m_AmplitudeGain = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Obstaculo"))
        {
            if (carController.fDamping > 0)
            {
                carController.fDamping -= (((carRB.mass / 100) - 0.5f) + 0.2f) * Time.deltaTime;
            }
            else
                carController.fDamping = 0;
            
        } 
    }
}
