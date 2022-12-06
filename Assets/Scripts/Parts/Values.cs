using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Values : MonoBehaviour
{
    CarBase carBase;
    public float turn, velocity, acceleration;
    [SerializeField] Image statsImage;
    Slider turnS, velocityS, accelerationS;

    private void Start()
    {
        carBase = gameObject.GetComponent<CarBase>();
        velocityS = statsImage.transform.GetChild(0).GetComponent<Slider>();
        accelerationS = statsImage.transform.GetChild(1).GetComponent<Slider>();
        turnS = statsImage.transform.GetChild(2).GetComponent<Slider>();
        statsImage.gameObject.SetActive(false);
    }

    void Calculate()
    {
        float turn_, velocity_, acceleration_;
        turn_ = ((carBase.wheelsF.GetComponent<Wheels>().drag_ + (carBase.wheelsB.GetComponent<Wheels>().drag_ / 4)) * carBase.carBodies.GetComponent<CarBodies>().mass_) + carBase.steeringWheel.GetComponent<SteeringWheel>().angle_;
        velocity_ = 100 - (carBase.carBodies.GetComponent<CarBodies>().mass_ + carBase.wheelsB.GetComponent<Wheels>().drag_);
        acceleration_ = carBase.carBodies.GetComponent<CarBodies>().mass_ - (carBase.wheelsB.GetComponent<Wheels>().drag_ / 4);

        turn = (turn_ - 518.75f) / (710 - 518.75f);
        velocity = (velocity_ - 13.5f) / (31.5f - 13.5f);
        acceleration = (acceleration_ - 60.875f) / (78.5f - 60.875f);
    }

    void Sliders()
    {
        turnS.value = turn;
        velocityS.value = velocity;
        accelerationS.value = acceleration;
    }

    public void StatsValues()
    {
        statsImage.gameObject.SetActive(true);
        Calculate();
        Sliders();
    }

    public void TurnOffImage()
    {
        statsImage.gameObject.SetActive(false);
    }

    public void AnimationActive()
    {
        statsImage.GetComponent<Animator>().enabled = true;
    }
}
