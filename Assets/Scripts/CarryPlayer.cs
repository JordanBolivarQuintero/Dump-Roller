using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryPlayer : MonoBehaviour
{
    public GameObject part = null;
    [SerializeField] ParticleSystem assembleParticle, partParticle;
    [SerializeField] Material partMaterial;
    [SerializeField] AudioSource audioS;

    private void Update()
    {
        if (part != null)
        {
            partParticle.Play();
            partMaterial.mainTexture = part.GetComponent<IParts>().GetTexture();
        }
        else
        {
            partParticle.Stop();
            partParticle.Clear();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Base") && part != null)
        {
            assembleParticle.Play();
            part.GetComponent<IParts>().Place();
            audioS.Play();
        }
    }
}
