using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DotScript : MonoBehaviour {
    public Image InDot;
    public bool isDot = true;
    public bool isSquare = false;
	// Use this for initialization
	void Awake () {
        if (isDot)
        {
            InDot = transform.Find("In-Dot").GetComponent<Image>();
        }
        if (isSquare)
        {
            InDot = transform.Find("In-Square").GetComponent<Image>();
        }

	}
}
