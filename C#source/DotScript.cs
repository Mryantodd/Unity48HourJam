/// This is a fairly simple type definition. The DotScript type is referenced throughout the project.

/// It is attached to every Dot and Square UI element while identifying its children components for direct access.
/// The major function of this script is to make each dot and square easily accessed. As each consist of 2 images.
/// A hollow circle/square layed over a solid one. To give the elements the correct look for point distribution.

/// This is how I cycle through each UI element to set their inner/outer state during I/O operations.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DotScript : MonoBehaviour {
    public Image InDot;
    public bool isDot = true;
    public bool isSquare = false;
	// Here we use awake to ensure this data is available in the initialization steps of other scripts.
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
