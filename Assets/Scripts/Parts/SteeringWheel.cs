using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SteeringWheel : MonoBehaviour, IParts
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

    public float angle_ = 30;

    [SerializeField] Texture texture;

    public int refernce;

    [SerializeField] SpawnPoint spawn;


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
        if (other.CompareTag("Player") && carBase.steeringWheel == null && carryPlayer.part == null)
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
        if (carBase.steeringWheel == null)
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
        carBase.steeringWheel = gameObject;
        if (carBase.carBodies != null)
            gameObject.transform.position = carBase.carBodies.GetComponent<CarBodies>().steeringWheelPos.transform.position;
        else
            gameObject.transform.position = carPos;
        gameObject.transform.rotation = Quaternion.Euler(carRot);
        grabbed = false;
        carryPlayer.part = null;
        //
        able = false;
        collider.enabled = false;
        //gameObject.GetComponent<SteeringWheel>().enabled = false;
    }

    public void TurnOff()
    {
        gameObject.GetComponent<SteeringWheel>().enabled = false;
    }
    public Texture GetTexture()
    {
        return texture;
    }
}
