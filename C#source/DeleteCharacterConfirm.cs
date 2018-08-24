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
        XMLObject = GameObject.Find("XMLObject");
        MyCanvas = this.gameObject.GetComponent<CanvasGroup>();
        HideConfirm();
	}
	
    public void HideConfirm()
    {
        MyCanvas.alpha = 0;
        MyCanvas.interactable = false;
        MyCanvas.blocksRaycasts = false;
    }

    public void ShowConfirm(Character a) 
    {
        CharToDelete = a;
        transform.Find("Image").gameObject.transform.Find("TMP_CharName").GetComponent<TextMeshProUGUI>().text = a.Name;
        MyCanvas.alpha = 1;
        MyCanvas.interactable = true;
        MyCanvas.blocksRaycasts = true;
    }
    public void DeleteConfirmed()
    {
        if (XMLObject.GetComponent<XMLSerializerScript>().MyCharacters.CharacterList.Contains(CharToDelete))
        {
            XMLObject.GetComponent<XMLSerializerScript>().DeleteCharacter(CharToDelete);
            GameObject.Find("ViewCharacterCanvas").gameObject.GetComponent<CharacterDisplayScript>().UpdateCharacterView();
            HideConfirm();
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
