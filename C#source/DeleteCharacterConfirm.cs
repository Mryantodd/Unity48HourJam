/// The following script is mostly a UI controller. It is attached to the delete confirmation window.
/// It holds a dynamic reference of a single character object from the character list. To call its delete function
/// If the user confirms the deletion of the current character.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeleteCharacterConfirm : MonoBehaviour {
    private CanvasGroup MyCanvas;
    private GameObject XMLObject;
    public Character CharToDelete;

	// Use this for initialization
	void Start () {
	/// again this method of finding a root object is not favored in 3d game environments.
        XMLObject = GameObject.Find("XMLObject");
	/// ref to the canvasgroup component to set values on click events.
        MyCanvas = this.gameObject.GetComponent<CanvasGroup>();
	/// run the hide method to start the panel off as invis/no click
        HideConfirm();
	}
    /// Method called for instantiation as well as on click events of related buttons on the UI
    public void HideConfirm()
    {
        MyCanvas.alpha = 0;/// set full alpha for invis.
        MyCanvas.interactable = false; /// stop extra event handling
        MyCanvas.blocksRaycasts = false; /// stops mouse event triggers
    }
    /// Method called when the delete button is pressed. This is called through another method on click event
    /// in the items and view portions of the respective object scripts.
    public void ShowConfirm(Character a) 
    {
	/// store the passed character data from either character object.
        CharToDelete = a;
	/// Set image to represent the character visualy for delete confirm
        transform.Find("Image").gameObject.transform.Find("TMP_CharName").GetComponent<TextMeshProUGUI>().text = a.Name;
	///Set canvas to viewable/click
        MyCanvas.alpha = 1;
        MyCanvas.interactable = true;
        MyCanvas.blocksRaycasts = true;
    }
    /// This is the final outcome method. Called once the confirmation has occured. It will reach out to the XMLObject
    /// calling the CRUD delete method of the class.	
    public void DeleteConfirmed()
    {
        if (XMLObject.GetComponent<XMLSerializerScript>().MyCharacters.CharacterList.Contains(CharToDelete))
        {
            XMLObject.GetComponent<XMLSerializerScript>().DeleteCharacter(CharToDelete);
            GameObject.Find("ViewCharacterCanvas").gameObject.GetComponent<CharacterDisplayScript>().UpdateCharacterView();
            HideConfirm();
        }
    }
}
