using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEWCARCONTROLLER : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardAccel, maxSpeed, turnStrenght, gravity;

    float inputForw, turnInput;
    float vertical, horizontal;
    public bool grounded;
    public LayerMask whatIsGround;
    public Transform raypoint;
    public float groundRayLenght = 0.5f;

    //
    Vector3 normal;
    float normalAngle;
    float normalValueForI = 0;

    Vector3 force;
    public float fDamping = 0; //choques 
    //

    private managerJoystick _managerJoystick; //Modified

    //move Whells
    public Transform fR_wheelTransform = null;
    public Transform fL_wheelTransform = null;
    public Transform bR_wheelTransform = null;
    public Transform bL_wheelTransform = null;
    
    //particle
    public ParticleSystem fR_wheelP = null;
    public ParticleSystem fL_wheelP = null;
    public ParticleSystem bR_wheelP = null;
    public ParticleSystem bL_wheelP = null;

    [SerializeField] ParticleSystem VelParticle_;


    void Start()
    {
        rb.transform.parent = null;
        gravity = 9.8f;
        _managerJoystick = GameObject.Find("imgJoystickBg").GetComponent<managerJoystick>(); //Modified     

        //
        fR_wheelP = fR_wheelTransform.GetChild(0).GetComponent<ParticleSystem>();
        fR_wheelP.transform.parent = gameObject.transform;
        fL_wheelP = fL_wheelTransform.GetChild(0).GetComponent<ParticleSystem>();
        fL_wheelP.transform.parent = gameObject.transform;
        bR_wheelP = bR_wheelTransform.GetChild(0).GetComponent<ParticleSystem>();
        bR_wheelP.transform.parent = gameObject.transform;
        bL_wheelP = bL_wheelTransform.GetChild(0).GetComponent<ParticleSystem>();
        bL_wheelP.transform.parent = gameObject.transform;
    }

    void Update()
    {
        horizontal = _managerJoystick.inputHorizontal();  //Modified
        vertical = _managerJoystick.inputVertical();

        transform.position = rb.transform.position;

        inputForw = forwardAccel * 1000f;


        turnInput = horizontal;

        if(grounded)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrenght * Time.deltaTime, 0f));
        }

        /*if(vertical>0)
        {
             inputForw = vertical * forwardAccel * 1000f;
        }
        else
        {
             //inputForw = vertical * reverseAc * 1000f; //Reversa
        }*/
    }

    private void FixedUpdate()
    {
        grounded = false;
        RaycastHit hit;

        if(Physics.Raycast(raypoint.position, -transform.up, out hit, groundRayLenght,whatIsGround))
        {
            grounded = true;
            normal = hit.normal;
            normalAngle = Mathf.Acos(normal.y);
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }

        if(grounded)
        {
            ParticleWheels();
            VelParticle();
            if (normalAngle >= normalValueForI)
            {
                normalValueForI = normalAngle;
            }
            else
            {
                normalValueForI -= 0.0002f;
            }

            if (fDamping <= 1)
            {
                fDamping += ((rb.mass/100) - 0.5f ) * Time.deltaTime;
            }

            force = transform.forward * inputForw * (normalValueForI * 1.5f + 1f) * fDamping;

            if (Mathf.Abs(inputForw) > 0)
            {
                rb.AddForce(force);
            }
        }
        else
        {
            rb.AddForce(Vector3.up * -gravity * 100f);
        }

        //print(normalAngle + " / " + normalValueForI);
        RotateWhells();
    }
    
    void RotateWhells()
    {
        fR_wheelTransform.Rotate(new Vector3(1, 0, 0) * rb.angularVelocity.magnitude);
        fL_wheelTransform.Rotate(new Vector3(1, 0, 0) * rb.angularVelocity.magnitude);
        bR_wheelTransform.Rotate(new Vector3(1, 0, 0) * rb.angularVelocity.magnitude);
        bL_wheelTransform.Rotate(new Vector3(1, 0, 0) * rb.angularVelocity.magnitude);

        fR_wheelTransform.rotation = Quaternion.Euler((transform.rotation.eulerAngles + new Vector3(0, (turnStrenght / 4 * horizontal), 0)));
        fL_wheelTransform.rotation = Quaternion.Euler((transform.rotation.eulerAngles + new Vector3(0, (turnStrenght / 4 * horizontal), 0)));
    }
    
    void ParticleWheels()
    {
        if (rb.velocity.magnitude >= 10f )
        {
            if (fR_wheelP.isStopped)
                fR_wheelP.Play();
            if (fL_wheelP.isStopped)
                fL_wheelP.Play();
            if (bR_wheelP.isStopped)
                bR_wheelP.Play();
            if (bL_wheelP.isStopped)
                bL_wheelP.Play();
        }
        else
        {
            fR_wheelP.Stop();
            fL_wheelP.Stop();
            bR_wheelP.Stop();
            bL_wheelP.Stop();
        }
    }
    void VelParticle()
    {
        if (rb.velocity.magnitude >= 28f)
        {
            if (VelParticle_.isStopped)
                VelParticle_.Play();
        }
        else
            VelParticle_.Stop();
    }

}
