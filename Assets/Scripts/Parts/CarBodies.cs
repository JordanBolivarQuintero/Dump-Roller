using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarBodies : MonoBehaviour, IParts
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

    //pos
    public GameObject steeringWheelPos;
    public GameObject playerPos;
    public GameObject wheelFRPos;
    public GameObject wheelFLPos;
    public GameObject wheelBRPos;
    public GameObject wheelBLPos;
    //

    public float mass_ = 1500;
    public float maxVel_ = 9.5f;
    public Vector3 colliderSize = new Vector3(1.5f, 2f, 4f);
    public Vector3 colliderCenter = new Vector3(0f, 1.5f, 0.1f);

    [SerializeField] Texture texture;

    public int refernce;

    [SerializeField] SpawnPoint spawn;
    public AudioSource audioS;

    void Start()
    {
        carryPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<CarryPlayer>();
        carBase = GameObject.FindGameObjectWithTag("Base").GetComponent<CarBase>();
        collider = gameObject.GetComponent<Collider>();
        steeringWheelPos = transform.GetChild(0).gameObject;
        playerPos = transform.GetChild(1).gameObject;
        wheelFRPos = transform.GetChild(2).gameObject;
        wheelFLPos = transform.GetChild(3).gameObject;
        wheelBRPos = transform.GetChild(4).gameObject;
        wheelBLPos = transform.GetChild(5).gameObject;
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
        buttonComp.onClick.AddListener(ButtonCall);
    }

    public void ButtonCall() //modified
    {
        if (able && carryPlayer.part == null)
            Grab();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && carBase.carBodies == null && carryPlayer.part == null) {
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
        if (carBase.carBodies == null)
        {
            Carry();
        }
        //Debug.Log("vieja guanga");
    }
    public void Carry()
    {
        grabbed = true;
        carryPlayer.part = gameObject;
        gameObject.transform.position = new Vector3(0, -50, 0);
        

    }
    public void Place()
    {
        carBase.carBodies = gameObject;
        gameObject.transform.position = carPos;
        gameObject.transform.rotation = Quaternion.Euler(carRot);
        grabbed = false;
        carryPlayer.part = null;
        //
        able = false;
        collider.enabled = false;
        //gameObject.GetComponent<CarBodies>().enabled = false;
    }

    public void TurnOff()
    {
        gameObject.GetComponent<CarBodies>().enabled = false;
    }
    public Texture GetTexture()
    {
        return texture;
    }
}
