// A simple data container type to be attached to objects at run time when building out UI elements. I redeclared this enum in 
// the statholderscript.cs.. Any changes here require updates to that one as well. I wanted to avoid this. However each script would
// then require the xmlobject reference. Something I'll likely change at some point.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public enum MyEnum { DetailInput, DetailDropDown, Physical, Social, Mental, Talents, Skills, Knowledges, Discipline, Background, Virtue, OtherTraits, Humanity, Willpower, BloodPool, Health, Experiance };
    public MyEnum StatType;
    public string StatName;
    public int DisplayValue;
}
