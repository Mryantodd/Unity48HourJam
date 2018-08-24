using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMenuScript : MonoBehaviour {
    public List<CanvasGroup> MyMenus = new List<CanvasGroup>();
    public CanvasGroup SelectedCanvas;

    public void Start()
    {
        MakeSelectedVisible();
    }

    public void SetSelectedTool(CanvasGroup a)
        
    {
        if (a != SelectedCanvas)
        {
            SelectedCanvas = a;
            MakeSelectedVisible();
        }
    }
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

    public void ExitApp()
    {
        Application.Quit();
    }

}
