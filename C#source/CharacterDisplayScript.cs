using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CharacterDisplayScript : MonoBehaviour {
    public XMLSerializerScript MyXML;
    public Transform CharListTransform;
    public List<GameObject> CharObjects = new List<GameObject>();
    public bool NeedsUpdate = false;
	// Use this for initialization
	void Start () {
        MyXML = GameObject.Find("XMLObject").gameObject.GetComponent<XMLSerializerScript>();
        foreach (Character a in MyXML.MyCharacters.CharacterList)
        {
            GameObject newCharItem = Resources.Load("Char_Item") as GameObject;
            //newCharItem.GetComponent<CharItemScript>().CharItem = a; Doesn't Work here
            newCharItem.GetComponent<CharItemScript>().CharacterName = a.Name;
            GameObject BuildObject = Instantiate(newCharItem, CharListTransform.position, Quaternion.identity) as GameObject;
            BuildObject.GetComponent<CharItemScript>().CharItem = a;//works here ???s
            BuildObject.transform.SetParent(CharListTransform);
            CharObjects.Add(BuildObject);
        }
	}
    public void UpdateCharacterView()
    {
        foreach(GameObject clearObjects in CharObjects)
        {
          // CharObjects.Remove(clearObjects);
            Destroy(clearObjects.gameObject);
        }
        CharObjects.Clear();
        foreach (Character a in MyXML.MyCharacters.CharacterList)
        {
            GameObject newCharItem = Resources.Load("Char_Item") as GameObject;
            //newCharItem.GetComponent<CharItemScript>().CharItem = a; Doesn't Work here
            newCharItem.GetComponent<CharItemScript>().CharacterName = a.Name;
            GameObject BuildObject = Instantiate(newCharItem, CharListTransform.position, Quaternion.identity) as GameObject;
            BuildObject.GetComponent<CharItemScript>().CharItem = a;//works here ???s
            BuildObject.transform.SetParent(CharListTransform);
            CharObjects.Add(BuildObject);
        }
    }

	// Update is called once per frame
	void Update () {   

	}
}
