using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBase : MonoBehaviour
{
    public GameObject wheelsF = null, wheelsB = null, carBodies = null, steeringWheel = null;

    GameObject[] carParts = new GameObject[4];
    public GameObject car;
    NEWCARCONTROLLER carController;
    //GameObject stratLine;

    bool repo = false;
    bool done = false;

    void Awake()
    {
        car = transform.GetChild(0).gameObject;
        carController = gameObject.GetComponent<LevelLogic>().car.GetComponent<NEWCARCONTROLLER>();
    }
    private void Update()
    {
        if (!repo && carBodies != null)
        {
            Reposition();
        }
        if (wheelsF != null && wheelsB != null && carBodies != null && steeringWheel != null && !done)
        {
            Create();
        }
    }

    void Create()
    {
        //car.transform.parent = null;////////////
        gameObject.GetComponent<LevelLogic>().car.transform.parent = null;
        car.transform.parent = gameObject.GetComponent<LevelLogic>().car.transform;
        carParts[0] = carBodies;
        carParts[1] = steeringWheel;
        carParts[2] = wheelsF;
        carParts[3] = wheelsB;
        for (int i = 0; i < carParts.Length; i++)
        {
            carParts[i].transform.SetParent(car.transform);
        }
        done = true;

        carControllerAssign();

        gameObject.GetComponent<LevelLogic>().state = LevelLogic.LevelState.Run;
    }
    void Reposition()
    {
        if (steeringWheel != null)
        {
            steeringWheel.GetComponent<IParts>().Place();
        }
        if (wheelsF != null)
        {
            wheelsF.transform.position = new Vector3(0, 0, 0);
            wheelsF.transform.GetChild(0).transform.position = carBodies.GetComponent<CarBodies>().wheelFRPos.transform.position;
            wheelsF.transform.GetChild(1).transform.position = carBodies.GetComponent<CarBodies>().wheelFLPos.transform.position;
        }
        if (wheelsB != null)
        {
            wheelsB.transform.position = new Vector3(0, 0, 0);
            wheelsB.transform.GetChild(0).transform.position = carBodies.GetComponent<CarBodies>().wheelBRPos.transform.position;
            wheelsB.transform.GetChild(1).transform.position = carBodies.GetComponent<CarBodies>().wheelBLPos.transform.position;;
        }
        //
        repo = true;
    }
    void carControllerAssign()
    {
        carController.fR_wheelTransform = wheelsF.transform.GetChild(0).transform;
        carController.fL_wheelTransform = wheelsF.transform.GetChild(1).transform;

        carController.bR_wheelTransform = wheelsB.transform.GetChild(0).transform;
        carController.bL_wheelTransform = wheelsB.transform.GetChild(1).transform;
    }
}
