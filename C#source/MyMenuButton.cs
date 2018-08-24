using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class MyMenuButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{
    public Color Normal;
    public Color Hover;
    public Color Click;

    public CanvasGroup MyTarget;
    public bool ExitButton;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (ExitButton)
        {
            GameObject.Find("Canvas").GetComponent<MyMenuScript>().ExitApp();
        }
        else
        {
            this.GetComponent<Image>().color = Click;
            GameObject.Find("Canvas").GetComponent<MyMenuScript>().SetSelectedTool(MyTarget);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<Image>().color = Hover;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<Image>().color = Normal;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        this.GetComponent<Image>().color = Normal;
    }
}
