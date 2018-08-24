using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharItemScript : MonoBehaviour {
    public Character CharItem;
    private CharacterSheetScript myCharSheet;
    public string CharacterName;
    // Use this for initialization
    public void Start()
    {
        myCharSheet = GameObject.Find("ViewCharacterCanvas").gameObject.GetComponentInChildren<CharacterSheetScript>();
        this.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = CharacterName;
    }
    public void ShowCharacter()
    {
        myCharSheet.DisplayCharacter(CharItem);

    }
    public void RemoveCharacter()
    {
        myCharSheet.RemoveCharacter(CharItem);
    }
	
	// Update is called once per frame
	void Update () {
       
	}
}
