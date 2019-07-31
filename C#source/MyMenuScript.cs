/// The following script acts as a controller for my main UI panels. Each section of the application is added to the list via Inspector.
/// By keeping each panel's canvasgroup component in reference I am able to set one as active. Then Cycle through the list setting each 
/// panel to the appropriate state invis/no click and visa versa.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMenuScript : MonoBehaviour {
    public List<CanvasGroup> MyMenus = new List<CanvasGroup>();/// Add each panel to the list in inspector to track.
    public CanvasGroup SelectedCanvas; /// This is set in inspector to default the main panel. After which it dynamicly updates on button use.

    /// Set up all panels.
    public void Start()
    {
        MakeSelectedVisible();
    }
    
    /// Method that sanity checks we are not mashing the same button. Then loads a new canvas group.
    public void SetSelectedTool(CanvasGroup a)
        
    {
        if (a != SelectedCanvas)
        {
            SelectedCanvas = a;
            MakeSelectedVisible();
        }
    }
    /// The following will loop through all panels. If not the currenly selected panel. They become invis/no click. else visa versa.
    public void MakeSelectedVisible()
    {
        foreach (CanvasGroup b in MyMenus)
        {
            if (b != SelectedCanvas)
            {
                b.alpha = 0;
                b.interactable = false;
                b.blocksRaycasts = false;
            }
            else
            {
                b.alpha = 1;
                b.interactable = true;
                b.blocksRaycasts = true;
            }

        }
    }
    /// method called externally to finally close application if exit button was clicked.
    public void ExitApp()
    {
        Application.Quit();
    }

}
