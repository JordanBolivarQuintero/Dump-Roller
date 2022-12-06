using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Fungus;

public class LevelLogic : MonoBehaviour
{
    public enum LevelState { Assemble, Run, Lose, Win}
    public LevelState state;

    //Santiago
    [SerializeField] bool animatorON = false; //modified
    public bool tuto = false; //modified
    public bool tutorial = false;
    private Animator anim;
    public bool secondMode = false;
    [SerializeField] GameObject timerSecondMode;
    private float timer;
    private Flowchart fc;
    private bool cond = false;
    GameObject guardia;
    private GameObject restart, joystick;
    /*---------------------------------------*/
    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject startLine;
    [SerializeField] GameObject finishLine;

    [SerializeField] GameObject guard;
    [SerializeField] AudioSource audS;
    [SerializeField] AudioClip winJingle;
    [SerializeField] AudioClip loseJingle;

//player stuff
GameObject player;
    //MovementCharacterController playerController;
    CapsuleCollider playerCollider;
    CharacterController playerCC;

    //old car stuff
    public GameObject car;
    //CarController carController;
    //Rigidbody carRB;
    //Collider carCollider;
    Transform PilotTransform;

    //new car
    NEWCARCONTROLLER NewCarController;
    GameObject sphere;
    GameObject carModel;

    CarBase carBase;
    [SerializeField] SavedData PartsCod; 

    bool runStart = false;
    public bool lose = false;
    bool win = false;

    //Victory and Lose
    [SerializeField] GameObject uiVictory;
    [SerializeField] GameObject uiLose;
    //[SerializeField] GameObject restart;

    //Cameras
    [SerializeField] GameObject camera1;
    [SerializeField] GameObject cameraRace;
    [SerializeField] GameObject cameraGuard;
    [SerializeField] GameObject cameraFinishline;
    [SerializeField] GameObject cameraTrack;
    [SerializeField] GameObject dollyCart;
    [SerializeField] Text conter;
    [SerializeField] ParticleSystem particle;

    //for run
    bool perCinematic = true;
    bool cinematic = false;
    bool postCinematic = false;
    int c = 0;

    Values stats;

    void Awake() 
    {
        stats = gameObject.GetComponent<Values>();
        if (GameObject.FindGameObjectWithTag("FungusSecondMode") != null)
        {
            fc = GameObject.FindGameObjectWithTag("FungusSecondMode").GetComponent<Flowchart>();
            cond = true;
        }

        if(GameObject.FindGameObjectWithTag("Guardia") != null)
        {
            guardia = GameObject.FindGameObjectWithTag("Guardia");
        }
        state = LevelState.Assemble;

        /*carController = car.GetComponent<CarController>();
        carRB = car.GetComponent<Rigidbody>();
        carCollider = car.GetComponent<Collider>();*/

        carBase = gameObject.GetComponent<CarBase>();

        // new
        //car = carBase.car;
        NewCarController = car.GetComponent<NEWCARCONTROLLER>();
        sphere = NewCarController.rb.gameObject;
        //

        player = GameObject.FindGameObjectWithTag("Player");
        guardia = GameObject.FindGameObjectWithTag("Guardia");
        restart = GameObject.FindGameObjectWithTag("Restart");
        joystick = GameObject.FindGameObjectWithTag("Joystick");
        restart.SetActive(false);
        //playerController = player.GetComponent<MovementCharacterController>();
        playerCollider = player.GetComponent<CapsuleCollider>();
        playerCC = player.GetComponent<CharacterController>();

        GameObject.FindGameObjectWithTag("Player").transform.position = spawnPoint.transform.position;
        if (animatorON == true)
        {
           anim = player.GetComponent<Animator>();
        }

        carModel = GameObject.FindGameObjectWithTag("CarModel");
    }

    void Update()
    {
        Logic();
        if (lose)
        {
            state = LevelState.Lose;
        }
        else if (win)
        {
            state = LevelState.Win;
        }

    }

    void Logic()
    {
        switch (state)
        {
            case LevelState.Assemble:
                Assemble(); 
                break;
            case LevelState.Run:
                Run();
                break;
            case LevelState.Lose:
                Lose();
                break;
            case LevelState.Win:
                Win();
                break;
        }
    }

    void Assemble() { }
    void Run()
    {
        if (!runStart)
        {//                                         AUDIOOOOO
            //Dar valores||tepear cosas||modo tieso
            if (perCinematic)
            {
                // new car
                car.SetActive(true);
                carBase.car.transform.position = new Vector3(carBase.car.transform.position.x, carBase.car.transform.position.y - 1, carBase.car.transform.position.z);
                car.transform.position = startLine.transform.position;
                //car value
                NewCarController.turnStrenght = carBase.steeringWheel.GetComponent<SteeringWheel>().angle_;
                NewCarController.forwardAccel = carBase.carBodies.GetComponent<CarBodies>().maxVel_;
                NewCarController.rb.angularDrag = carBase.wheelsF.GetComponent<Wheels>().drag_;
                NewCarController.rb.drag = carBase.wheelsB.GetComponent<Wheels>().drag_;
                NewCarController.rb.mass = carBase.carBodies.GetComponent<CarBodies>().mass_;

                PilotTransform = carBase.carBodies.GetComponent<CarBodies>().playerPos.transform;

                playerCC.enabled = false;
                playerCollider.enabled = false;

                player.GetComponent<AnimationsMovement>().enabled = false;                                  //quitar la velocidad 
                player.transform.position = new Vector3(0, 0, 0);

                //Invoke("Reposition", 0.5f);

                if (animatorON == true)
                {
                    anim.SetBool("isDriving", true);
                }
                //MODO TIESO
                NewCarController.rb.gameObject.SetActive(false);
                NewCarController.enabled = false;

                perCinematic = false;
                cinematic = true;

                joystick.SetActive(false);
            }


            //Guardia
            guardia.GetComponent<GuardCinematic>().enabled = true;

            //timer & cinematica?
            if (cinematic)
            {

                timer += Time.deltaTime;
                Reposition();
                if (c == 0)
                {
                    camera1.SetActive(false);
                    cameraRace.SetActive(false);
                    cameraTrack.SetActive(false);
                    if (!secondMode)
                    {
                        cameraGuard.SetActive(false);
                    }
                    particle.Play();
                    c = 1;
                }
                //camara meta
                if (timer >= 2f && c == 1)
                {
                    cameraTrack.SetActive(true);
                    dollyCart.SetActive(true);
                    c = 2;
                }
                if (timer >= 10f && c == 2)
                {
                    if (!secondMode)
                    {
                        cameraGuard.SetActive(true);
                        //animcaion guardia 
                    }
                    else
                        timer += 8.5f;
                    c = 3;
                }
                if (timer >= 14f && c == 3 )//&& animacion guardia termino && en tuto quito los mensajes
                {
                    cameraRace.SetActive(true);
                    conter.rectTransform.parent.gameObject.SetActive(true);
                    conter.text = ((int)(18 - timer)).ToString();
                    stats.StatsValues();
                }
                if (timer >= 17f)
                {
                    conter.rectTransform.parent.gameObject.SetActive(false);
                    //efecto go
                    cinematic = false;
                    postCinematic = true;
                }

                //Fungus
                if (cond == true)
                {
                    fc.ExecuteBlock("Segundo Texto");
                    cond = false;
                }

            }

            //quitar modo tieso
            if (postCinematic)
            {
                stats.AnimationActive();
                NewCarController.enabled = true;
                NewCarController.rb.gameObject.SetActive(true);
                NewCarController.rb.transform.GetChild(0).localScale = carBase.carBodies.GetComponent<CarBodies>().colliderSize;

                tuto = true; //modified
                restart.SetActive(true);
                joystick.SetActive(true);


                if (secondMode == true)
                    timerSecondMode.SetActive(true);

                if (!secondMode)
                    guard.GetComponent<GuardFollow>().enabled = true;

                //temp
                carModel.transform.GetChild(0).GetComponent<AudioSource>().Play();
                carModel.transform.GetChild(2).GetComponent<AudioSource>().Play();
                carModel.transform.GetChild(3).GetComponent<AudioSource>().Play();

                runStart = true;
            }
        }
    }
    void Reposition()
    {
        player.transform.position = PilotTransform.position;
        player.transform.rotation = Quaternion.Euler(new Vector3(0, PilotTransform.rotation.y, 0));
        player.transform.SetParent(car.transform);
    }
    void Lose()
    {
        if (!win)
        {
            audS.Stop();
            audS.clip = loseJingle;
            audS.loop = false;
            audS.Play();
            uiLose.SetActive(true);
            NewCarController.enabled = false;
            lose = true;
        }
        else
            state = LevelState.Win;
        gameObject.GetComponent<LevelLogic>().enabled = false;
    }
    void Win()
    {
        if (!lose)
        {
            audS.Stop();
            audS.clip = winJingle;
            audS.loop = false;
            audS.Play();
            uiVictory.SetActive(true);
            win = true;
            int a = 0;

            //show parts

            /*uiVictory.transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite.texture = carModel.transform.GetChild(0).GetComponent<CarBodies>().GetTexture();
            carModel.transform.GetChild(1).GetComponent<SteeringWheel>().GetTexture;
            carModel.transform.GetChild(2).GetComponent<Wheels>().GetTexture;
            carModel.transform.GetChild(3).GetComponent<Wheels>().GetTexture;*/

            switch (carModel.transform.GetChild(0).GetComponent<CarBodies>().refernce)
            {
                case 0:
                    //mercado
                    uiVictory.transform.GetChild(1).transform.GetChild(3).gameObject.SetActive(true);
                    break;
                case 1:
                    //lavadora
                    uiVictory.transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(true);
                    break;
                case 2:
                    //caja
                    uiVictory.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
                    break;
                case 3:
                    //barco
                    uiVictory.transform.GetChild(1).transform.GetChild(2).gameObject.SetActive(true);
                    break;
            }
            switch (carModel.transform.GetChild(1).GetComponent<SteeringWheel>().refernce)
            {
                case 4:
                    //timon
                    uiVictory.transform.GetChild(1).transform.GetChild(6).gameObject.SetActive(true);
                    break;
                case 5:
                    //carro
                    uiVictory.transform.GetChild(1).transform.GetChild(5).gameObject.SetActive(true);
                    break;
                case 6:
                    //moto
                    uiVictory.transform.GetChild(1).transform.GetChild(4).gameObject.SetActive(true);
                    break;
            }
            switch (carModel.transform.GetChild(2).GetComponent<Wheels>().refernce)
            {
                case 7:
                    //bici
                    uiVictory.transform.GetChild(1).transform.GetChild(7).gameObject.SetActive(true);
                    break;
                case 8:
                    //rin
                    uiVictory.transform.GetChild(1).transform.GetChild(8).gameObject.SetActive(true);
                    break;
            }
            switch (carModel.transform.GetChild(3).GetComponent<Wheels>().refernce)
            {
                case 7:
                    //bici1
                    uiVictory.transform.GetChild(1).transform.GetChild(7).gameObject.SetActive(true);
                    break;
                case 8:
                    //rin1
                    uiVictory.transform.GetChild(1).transform.GetChild(8).gameObject.SetActive(true);
                    break;
            }

            //save parts
            for (int i = 0; i < PartsCod.parts.Count || i == 0; i++)
            {
                if(PartsCod.parts.Count == 0) { }
                else if (PartsCod.parts[i] == carModel.transform.GetChild(0).GetComponent<CarBodies>().refernce)
                    break;
                else
                    a++;

                if (a >= PartsCod.parts.Count)
                {
                    PartsCod.parts.Add(carModel.transform.GetChild(0).GetComponent<CarBodies>().refernce);
                }
                //print(a + " - " + PartsCod.saved.Count);
            }

            a = 0;
            for (int i = 0; i < PartsCod.parts.Count || i == 0; i++)
            {
                if (PartsCod.parts.Count == 0) { }
                else if (PartsCod.parts[i] == carModel.transform.GetChild(1).GetComponent<SteeringWheel>().refernce)
                    break;
                else
                    a++;

                if (a >= PartsCod.parts.Count)
                {
                    PartsCod.parts.Add(carModel.transform.GetChild(1).GetComponent<SteeringWheel>().refernce);
                }
                //print(a + " - " + PartsCod.saved.Count);
            }

            a = 0;
            for (int i = 0; i < PartsCod.parts.Count || i == 0; i++)
            {
                if (PartsCod.parts.Count == 0) { }
                else if (PartsCod.parts[i] == carModel.transform.GetChild(2).GetComponent<Wheels>().refernce)
                    break;
                else
                    a++;

                if (a >= PartsCod.parts.Count)
                {
                    PartsCod.parts.Add(carModel.transform.GetChild(2).GetComponent<Wheels>().refernce);
                }
                //print(a + " - " + PartsCod.saved.Count);
            }

            a = 0;
            for (int i = 0; i < PartsCod.parts.Count || i == 0; i++)
            {
                if (PartsCod.parts.Count == 0) { }
                else if (PartsCod.parts[i] == carModel.transform.GetChild(3).GetComponent<Wheels>().refernce)
                    break;
                else
                    a++;

                if (a >= PartsCod.parts.Count)
                {
                    PartsCod.parts.Add(carModel.transform.GetChild(3).GetComponent<Wheels>().refernce);
                }
            }
            SavesManger.Save(PartsCod);
        }
        else
            state = LevelState.Lose;
        gameObject.GetComponent<LevelLogic>().enabled = false;
    }
}
