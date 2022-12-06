using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class managerJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Image imgJoystickBg;
    private Image imgJoystick;

    public bool onPointerDown_;

    private Vector2 posInput;
    void Start()
    {
        imgJoystickBg = GetComponent <Image>();
        imgJoystick = transform.GetChild(1).GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            imgJoystickBg.rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out posInput))
        {
            posInput.x = posInput.x / (imgJoystickBg.rectTransform.sizeDelta.x / 2.5f); // sensibilidad
            posInput.y = posInput.y / (imgJoystickBg.rectTransform.sizeDelta.y / 2.5f); // sensibilidad

            //Normalize
            if (posInput.magnitude > 1.0f)
            {
                posInput = posInput.normalized;
            }
                
                
            //joystick move
            imgJoystick.rectTransform.anchoredPosition = new Vector2(
                posInput.x * (imgJoystickBg.rectTransform.sizeDelta.x / 3), posInput.y * (imgJoystickBg.rectTransform.sizeDelta.y / 3));
        }
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        onPointerDown_ = true;
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        onPointerDown_ = false;
        posInput = Vector2.zero;
        imgJoystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float inputHorizontal()
    {
        if (posInput.x != 0)
            return posInput.x;
        else
            return Input.GetAxis("Horizontal");
    }

    public float inputVertical()
    {
        if (posInput.y != 0)
            return posInput.y;
        else
            return Input.GetAxis("Vertical");
    }
}

