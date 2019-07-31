/// This script acts as an anchor in the UI. Its responsible for updating the ui for changes to any character list data. 
/// It also makes the xml data of the objects available for reference in other components. Many components reach back to update
/// the UI after save events.

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
	
	/// initialization
	void Start () {
	/// We find the master XMLObject storing a ref of its script XMLSerializerScript by name, as it exists outside of the UI making heirarchy target impossible.
	/// Performance heavy, naming dependent, no alternative to access something outside root.
        MyXML = GameObject.Find("XMLObject").gameObject.GetComponent<XMLSerializerScript>(); 
	/// Next we cycle through each character loaded by the XMLObject.	
        foreach (Character a in MyXML.MyCharacters.CharacterList)
        {
	    /// we grab our prefab gameObject with the CharItemScript attached.
            GameObject newCharItem = Resources.Load("Char_Item") as GameObject; 
		
	    ///newCharItem.GetComponent<CharItemScript>().CharItem = a; /// Doesn't Work here... UPDATE: too early in stack to call load data below.
		
	    /// set the name of the object for easier inspector identification at run time. no other affect.
            newCharItem.GetComponent<CharItemScript>().CharacterName = a.Name; 
	    /// bring the Object into the world at the position ofthe character list.
            GameObject BuildObject = Instantiate(newCharItem, CharListTransform.position, Quaternion.identity) as GameObject;
	    /// pass the data to the sub component of our new UI character list object.
            BuildObject.GetComponent<CharItemScript>().CharItem = a; /// works here ??? UPDATE: This component does not initialize until parent object instantiated.
	    /// set the parent of the new object to the character list transform to nest it into the UI panel.
            BuildObject.transform.SetParent(CharListTransform);
	    /// keep running track of all objects.
            CharObjects.Add(BuildObject);
        }
    }
    
    /// Public method to update UI on save events to keep new and deleted items out of list.
    public void UpdateCharacterView()
    {
	/// Clear all objects from list to prevent old data from hanging around.
        foreach(GameObject clearObjects in CharObjects)
        {
          // CharObjects.Remove(clearObjects);
            Destroy(clearObjects.gameObject);
        }
	//Clear our tracking list to rebuild fresh objects.
        CharObjects.Clear();
	 /// perform our initialization again to rebuild our list when needed.
        foreach (Character a in MyXML.MyCharacters.CharacterList)
        {
            GameObject newCharItem = Resources.Load("Char_Item") as GameObject;
            newCharItem.GetComponent<CharItemScript>().CharacterName = a.Name;
            GameObject BuildObject = Instantiate(newCharItem, CharListTransform.position, Quaternion.identity) as GameObject;
            BuildObject.GetComponent<CharItemScript>().CharItem = a;
            BuildObject.transform.SetParent(CharListTransform);
            CharObjects.Add(BuildObject);
        }
    }
}
