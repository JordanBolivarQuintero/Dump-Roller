using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class SideControl : MonoBehaviour

{
    public float value = 0f;
    public float sameValue = 1f;
    GameObject button;
    Button buttonComp;
    bool isPressed;
    void Start()
    {
        buttonComp = GetComponent<Button>();   
    }

    void Update()
    {
        if(isPressed == true)
        {
           //Debug.Log(value);
        }

    }
    public void onPointerDown()
    {
        isPressed = true;
        value = sameValue;
    }
    public void onPointerUp()
    {
        isPressed = false;
        value = 0f;
    }
    /*public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("aquistoy");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("aquimefui");
    }*/
    /*
    public void ActualValue()
    {
       value = sameValue; 
    }
    public float ButtonValue()
    {
        return value;
    }*/
}
