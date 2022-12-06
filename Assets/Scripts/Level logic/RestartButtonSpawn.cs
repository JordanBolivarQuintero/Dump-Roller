using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButtonSpawn : MonoBehaviour
{
    [SerializeField] Rigidbody sphrRigidbody;
    [SerializeField] Button button;
    [SerializeField] float minVel;
    LevelLogic levelLogic;

    private void Awake()
    {
        //sphrRigidbody = gameObject.GetComponent<Rigidbody>();
        levelLogic = GameObject.FindGameObjectWithTag("Base").GetComponent<LevelLogic>();
    }
    private void Update()
    {
        if (sphrRigidbody.velocity.magnitude < minVel && levelLogic.state == LevelLogic.LevelState.Run)
            button.gameObject.SetActive(true);
        else
            button.gameObject.SetActive(false);
    }
}
