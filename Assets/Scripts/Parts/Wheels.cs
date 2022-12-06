using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wheels : MonoBehaviour, IParts
{
    [SerializeField] public Vector3 carPos = new Vector3(0, 1, 0);
    [SerializeField] public Vector3 carRot = new Vector3(0, 0, 0);

    public bool grabbed;
    public bool able;
    Collider collider;

    [SerializeField] GameObject button; //modified
    Button buttonComp;

    CarryPlayer carryPlayer;
    CarBase carBase;

    public float drag_ = 6.3f;

    [SerializeField] Texture texture;

    [SerializeField] SpawnPoint spawn;
    public AudioSource audioS;

    public int refernce;

    void Start()
    {
        carryPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<CarryPlayer>();
        carBase = GameObject.FindGameObjectWithTag("Base").GetComponent<CarBase>();
        collider = gameObject.GetComponent<Collider>();


        buttonComp = button.GetComponent<Button>();
        buttonComp.onClick.AddListener(ButtonCall);//modified

        if (carBase.gameObject.GetComponent<LevelLogic>().secondMode == false && carBase.gameObject.GetComponent<LevelLogic>().tutorial == false)
        {
            spawn.Locate(transform);
        }
        audioS = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (able && carryPlayer.part == null)
        {
            if (Input.GetKeyDown(KeyCode.E))
                Grab();
        }
    }
    public void ButtonCall() //modified
    {
        if (able && carryPlayer.part == null)
            Grab();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && carBase.wheelsB == null && carryPlayer.part == null)
        {
            able = true;
            button.SetActive(true); //modified
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            able = false;
            button.SetActive(false); //modified
        }
    }
    public void Grab()
    {
        if (carBase.wheelsF == null || carBase.wheelsB == false)
        {
            Carry();
        }
    }
    public void Carry()
    {
        grabbed = true;
        carryPlayer.part = gameObject;
        gameObject.transform.position = new Vector3(0, -50, 0);


    }
    public void Place()
    {
        if (carBase.wheelsF == null) //front
        {
            carBase.wheelsF = gameObject;
            if (carBase.carBodies == null)
            {
                transform.position = new Vector3(0, 0, 0);                                                          //carBase.gameObject.transform.position - new Vector3(0, carBase.gameObject.transform.position.y, 0);
                transform.GetChild(0).transform.position = carPos;                                                                          //coll wheel FR
                transform.GetChild(1).transform.position = new Vector3(-carPos.x, carPos.y, carPos.z);                                      //coll wheel FL                
            }
            else
            {
                transform.position = new Vector3(0, 0, 0);                                                          //carBase.gameObject.transform.position - new Vector3(0, carBase.gameObject.transform.position.y, 0);
                transform.GetChild(0).transform.position = carBase.carBodies.GetComponent<CarBodies>().wheelFRPos.transform.position;
                transform.GetChild(1).transform.position = carBase.carBodies.GetComponent<CarBodies>().wheelFLPos.transform.position;              
            }
        }
        else //back
        {
            carBase.wheelsB = gameObject;
            if (carBase.carBodies == null)
            {
                transform.position = new Vector3(0, 0, 0);                                                          //carBase.gameObject.transform.position - new Vector3(0, carBase.gameObject.transform.position.y, 0);
                transform.GetChild(0).transform.position = new Vector3(carPos.x, carPos.y, -carPos.z);                                       //coll wheel BR
                transform.GetChild(1).transform.position = new Vector3(-carPos.x, carPos.y, -carPos.z);                                      //coll wheel BL
            }
            else
            {
                transform.position = new Vector3(0, 0, 0);                                                          //carBase.gameObject.transform.position - new Vector3(0, carBase.gameObject.transform.position.y, 0);
                transform.GetChild(0).transform.position = carBase.carBodies.GetComponent<CarBodies>().wheelBRPos.transform.position;
                transform.GetChild(1).transform.position = carBase.carBodies.GetComponent<CarBodies>().wheelBLPos.transform.position;
            }
        }

        gameObject.transform.rotation = Quaternion.Euler(carRot);
        transform.GetChild(0).transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        transform.GetChild(1).transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

        grabbed = false;
        carryPlayer.part = null;
        //
        able = false;
        collider.enabled = false;
        //gameObject.GetComponent<Wheels>().enabled = false;
    }

    public void TurnOff()
    {
        gameObject.GetComponent<Wheels>().enabled = false;
    }

    public Texture GetTexture()
    {
        return texture;
    }
}
