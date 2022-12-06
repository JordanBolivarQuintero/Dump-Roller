using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    Transform lastCheckPoint;
    [SerializeField] Transform startLine;
    LevelLogic levelLogic;
    public bool forceRestart = false;
    bool buttonRestart = false;

    [SerializeField] GameObject carRB;
    [SerializeField] NEWCARCONTROLLER car;

    void Start()
    {
        lastCheckPoint = startLine;
        levelLogic = GameObject.FindGameObjectWithTag("Base").GetComponent<LevelLogic>();
    }

    private void Update()
    {
        Restart();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RestartPoint"))
        {
            lastCheckPoint = other.transform;
            //Debug.Log(lastCheckPoint.name + " restart take");
        }
    }

    void Restart()
    {
        if (levelLogic.state == LevelLogic.LevelState.Run && lastCheckPoint.gameObject.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.R) || forceRestart || buttonRestart)// o el input de celular
            {
                gameObject.transform.position = lastCheckPoint.position;
                gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                carRB.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                car.fDamping = car.fDamping / 4;
                gameObject.GetComponent<Rigidbody>().velocity = gameObject.GetComponent<Rigidbody>().velocity/4;                
                forceRestart = false;
                buttonRestart = false;
            }
        }
    }

    public void ButtonRestart_()
    {
        buttonRestart = true;
    }
}
