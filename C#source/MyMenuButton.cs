/// The following script is another UI controller for menu buttons. This one is purely for style as it only handles basic 
/// button behaviour. Such as normal/hover/and click states.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;

///Declaring our button class and implementing the appropriate mouse event interfaces.
public class MyMenuButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{
    public Color Normal;/// public color definition is set in Unity Inspector.
    public Color Hover;/// public color definition is set in Unity Inspector.
    public Color Click;/// public color definition is set in Unity Inspector.

    public CanvasGroup MyTarget;/// public reference to the canvasgroup this button will open/close is set in Unity Inspector.
    public bool ExitButton; /// bool value that is only set true in inspector on the Exit button UI element.

    /// Since every button performs the same action except the exit button. Check what was pressed and perform exit if that was clicked.
    /// Otherwise open the target panel set in inspector per button.
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
    ///The below method is a valid method though it performs at the end of the update frame of mouse release.
    /// There was an open bug on the below method. As once the down click was performed the upclick would ultimately
    /// perform the method regardless if the mouse moved away from the button. As such the above method functions the same
    /// without implying a regret movement that did not exist.
    public void OnPointerClick(PointerEventData eventData)
    {
        /// left as an example.
    }
    // Set color when hovering button
    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<Image>().color = Hover;
    }
    // Set color back when not hovering button.
    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<Image>().color = Normal;
    }
    // Set color on release of mouse button. This is also to counter act the button click color on downclick
    public void OnPointerUp(PointerEventData eventData)
    {
        this.GetComponent<Image>().color = Normal;
    }
}
