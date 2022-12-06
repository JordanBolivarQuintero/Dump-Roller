using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTemplate : MonoBehaviour
{
    [SerializeField] Transform wheelsFR = null, wheelsFL = null, wheelsBR = null, wheelsBL = null, carBodies = null, steeringWheel = null;

    bool repo = false;
    CarBase carBase;

    private void Start()
    {
        carBase = gameObject.GetComponent<CarBase>();
    }
    private void Update()
    {
        if (carBase.carBodies != null)
        {
            carBodies.gameObject.SetActive(false);
        }        
        if (carBase.steeringWheel != null)
        {
            steeringWheel.gameObject.SetActive(false);
        }
        if (carBase.wheelsF != null)
        {
            wheelsFR.gameObject.SetActive(false);
            wheelsFL.gameObject.SetActive(false);
        }
        if (carBase.wheelsB != null)
        {
            wheelsBR.gameObject.SetActive(false);
            wheelsBL.gameObject.SetActive(false);
        }

        if (!repo && carBase.carBodies != null)
        {
            Reposition();
        }
        if (carBase.wheelsF != null && carBase.wheelsB != null && carBase.carBodies != null && carBase.steeringWheel != null)
        {
            Destroy(carBodies.parent.gameObject);
            gameObject.GetComponent<CarTemplate>().enabled = false;
        }
    }

    void Reposition()
    {
        if (carBase.steeringWheel != null)
        {
            steeringWheel.gameObject.transform.position = carBase.carBodies.GetComponent<CarBodies>().steeringWheelPos.transform.position;
        }
        if (carBase.wheelsF != null)
        {
            wheelsFR.gameObject.transform.position = carBase.carBodies.GetComponent<CarBodies>().wheelFRPos.transform.position;
            wheelsFL.gameObject.transform.position = carBase.carBodies.GetComponent<CarBodies>().wheelFLPos.transform.position;
        }
        if (carBase.wheelsB != null)
        {
            wheelsBR.gameObject.transform.position = carBase.carBodies.GetComponent<CarBodies>().wheelBRPos.transform.position;
            wheelsBL.gameObject.transform.position = carBase.carBodies.GetComponent<CarBodies>().wheelBLPos.transform.position;
        }
        //
        repo = true;
    }
}
