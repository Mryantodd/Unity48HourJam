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
