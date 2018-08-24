using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class CharacterSheetScript : MonoBehaviour
{
    public bool DisplaySheet;
    public bool NewCharSheet;
    public bool EditCharSheet;
    public GameObject XMLObject;
    public Transform PhysicalArea;
    public Transform SocialArea;
    public Transform MentalArea;
    public Transform TalentsArea;
    public Transform SkillsArea;
    public Transform KnowledgesArea;
    public Transform DisciplineArea;
    public Transform BackgroundArea;
    public Transform VirtueArea;
    public Transform OtherTraitArea;
    public Transform HumanityArea;
    public Transform WillpowerArea;
    public Transform BloodpoolArea;
    public Transform HealthArea;
    public Transform DetailsArea;
    public List<GameObject> CharacterDetails = new List<GameObject>();
    public List<GameObject> PhysicalStats = new List<GameObject>();
    public List<GameObject> SocialStats = new List<GameObject>();
    public List<GameObject> MentalStats = new List<GameObject>();
    public List<GameObject> TalentStats = new List<GameObject>();
    public List<GameObject> SkillStats = new List<GameObject>();
    public List<GameObject> KnowledgeStats = new List<GameObject>();
    public List<GameObject> DisciplineStats = new List<GameObject>();
    public List<GameObject> BackgroundStats = new List<GameObject>();
    public List<GameObject> VirtueStats = new List<GameObject>();
    public List<GameObject> OtherTraitStats = new List<GameObject>();
    public GameObject HumanityStats;
    public GameObject WillpowerStats;
    public GameObject BloodpoolStats;
    public List<GameObject> HealthStats = new List<GameObject>();
    public Button SaveButton;

    private List<TMP_Dropdown> ClanDropdowns;
    private List<TMP_Dropdown> ConceptDropdowns;
    private List<TMP_Dropdown> ArchetypesDropdowns;

    public bool FreeMode = false;
    public bool DetailsFilled = false;
    public bool PrimaryAttributesSpent = false;
    public bool AttributesFull = false;
    public bool AbilitiesFull = false;
    public bool DisciplinesFull = false;
    public bool BackgroundsFull = false;
    public bool VirtuesFull = false;
    public bool OtherTraitsFull = false;
    public bool HumanityFull = false;
    public bool WillpowerFull = false;
    public bool BloodpoolFull = false;
    public bool HealthFull = false;
    public bool ExperianceFull = false;
    public bool FreebiePointFull = false;
    public int PrimaryAttributesPoints = 7;
    public int SecondaryAttributesPoints = 5;
    public int TeritaryAttributesPoints = 3;
    public int PrimaryAbilitiesPoints = 13;
    public int SecondaryAbilitiesPoints = 9;
    public int TeritaryAbilitiesPoints = 5;
    public int DisciplinePoints = 3;
    public int BackgroundPoints = 5;
    public int VirtuePoints = 7;

    public List<StatHolderScript.MyEnum> AttStatOrder = new List<StatHolderScript.MyEnum>();
    public List<StatHolderScript.MyEnum> AbilitiesOrder = new List<StatHolderScript.MyEnum>();

    public List<string> Names = new List<string>();
    public TextMeshProUGUI MessageBox;
    public bool trigger = false;
    public bool trigger2 = false;
    public bool trigger3 = false;
    public bool trigger4 = false;
    public bool trigger5 = false;
    public bool trigger6 = false;
    public bool buildNames = false;

    public CanvasGroup AttributeBlocker;
    public CanvasGroup AbillitiesBlocker;
    public CanvasGroup DisciplineBlocker;
    public CanvasGroup BackgroundBlocker;
    public CanvasGroup VirtueBlocker;
    public CanvasGroup OtherTraitBlocker;
    public CanvasGroup HumanityBlocker;
    public CanvasGroup HealthBlocker;
    public CanvasGroup ExperianceBlocker;

    public Character ThisCharacter;

    // Use this for initialization
    void Start()
    {
        if (NewCharSheet)
        {
            SaveButton = transform.Find("Button1").GetComponent<Button>();
        }

        AttStatOrder.Add(StatHolderScript.MyEnum.NULL);
        AttStatOrder.Add(StatHolderScript.MyEnum.NULL);
        AttStatOrder.Add(StatHolderScript.MyEnum.NULL);
        AbilitiesOrder.Add(StatHolderScript.MyEnum.NULL);
        AbilitiesOrder.Add(StatHolderScript.MyEnum.NULL);
        AbilitiesOrder.Add(StatHolderScript.MyEnum.NULL);
        MessageBox = GameObject.Find("MessageBox").GetComponent<TextMeshProUGUI>();
        XMLObject = GameObject.Find("XMLObject");
        List<string> charDetailsTemp = new List<string>();
        charDetailsTemp.Add("Name");
        charDetailsTemp.Add("Player");
        charDetailsTemp.Add("Chronicle");
        charDetailsTemp.Add("Nature");
        charDetailsTemp.Add("Demeanor");
        charDetailsTemp.Add("Clan");
        charDetailsTemp.Add("Generation");
        charDetailsTemp.Add("Haven");
        charDetailsTemp.Add("Concept");
        foreach (string a in charDetailsTemp)
        {
            if (a == "Name" | a == "Player" | a == "Chronicle" | a == "Haven")
            {
                GameObject newStatObject = Resources.Load("InputHolder") as GameObject;
                newStatObject.GetComponent<StatHolderScript>().StatName = a;
                newStatObject.GetComponent<StatHolderScript>().StatType = StatHolderScript.MyEnum.DetailInput;
                GameObject BuildObject = Instantiate(newStatObject, DetailsArea.transform.position, Quaternion.identity) as GameObject;
                BuildObject.transform.SetParent(DetailsArea);
                newStatObject.GetComponent<StatHolderScript>().StatType = StatHolderScript.MyEnum.DetailInput;
                BuildObject.name = a;
                CharacterDetails.Add(BuildObject);
            }

            if (a == "Nature" | a == "Demeanor" | a == "Concept" | a == "Clan" | a == "Generation")
            {


                GameObject newStatObject = Resources.Load("detailDrop") as GameObject;
                List<string> OptionsList = new List<string>();
                OptionsList = new List<string>();
                if (a == "Nature" | a == "Demeanor")
                {
                    OptionsList = new List<string>();
                    //Load all Archetype Data into archetype Dropdowns
                    foreach (Archetype newType in XMLObject.GetComponent<XMLSerializerScript>().MyArchetypes.ArchetypeList)
                    {
                        OptionsList.Add(newType.Name);
                    }

                }
                if (a == "Concept")
                {
                    OptionsList = new List<string>();
                    foreach (Concept newConcept in XMLObject.GetComponent<XMLSerializerScript>().MyConcepts.ConceptList)
                    {
                        OptionsList.Add(newConcept.Name);
                    }
                }
                if (a == "Clan")
                {
                    OptionsList = new List<string>();
                    //Load all Clan data into Clan dropdown
                    foreach (Clan newClan in XMLObject.GetComponent<XMLSerializerScript>().MyClans.ClanList)
                    {
                        OptionsList.Add(newClan.Name);
                    }
                }
                if (a == "Generation")
                {
                    OptionsList = new List<string>();
                    List<string> GenerationValues = new List<string>();
                    GenerationValues.Add("14th");
                    GenerationValues.Add("13th");
                    GenerationValues.Add("12th");
                    GenerationValues.Add("11th");
                    GenerationValues.Add("10th");
                    GenerationValues.Add("9th");
                    GenerationValues.Add("8th");
                    GenerationValues.Add("7th");
                    GenerationValues.Add("6th");
                    GenerationValues.Add("5th");
                    GenerationValues.Add("4th");
                    GenerationValues.Add("3rd");
                    GenerationValues.Add("2nd");
                    GenerationValues.Add("1st");
                    OptionsList = GenerationValues;
                }
                newStatObject.GetComponent<StatHolderScript>().StatName = a;
                newStatObject.GetComponent<StatHolderScript>().StatType = StatHolderScript.MyEnum.DetailDropDown;
                newStatObject.GetComponent<StatHolderScript>().DisplayValue2 = 0;
                newStatObject.GetComponent<StatHolderScript>().optionsList = OptionsList;
                GameObject BuildObject = Instantiate(newStatObject, DetailsArea.transform.position, Quaternion.identity) as GameObject;
                BuildObject.transform.SetParent(DetailsArea);
                BuildObject.name = a;
                CharacterDetails.Add(BuildObject);

            }
        }



        foreach (Stat a in XMLObject.GetComponent<XMLSerializerScript>().MyStats.StatList)
        {
            if (a.category == "Physical")
            {
                GameObject newStatObject = Resources.Load("StatHolder") as GameObject;
                newStatObject.GetComponent<StatHolderScript>().StatType = StatHolderScript.MyEnum.Physical;
                newStatObject.GetComponent<StatHolderScript>().StatName = a.Name;
                newStatObject.GetComponent<StatHolderScript>().DisplayValue = 1;
                GameObject BuildObject = Instantiate(newStatObject, PhysicalArea.transform.position, Quaternion.identity) as GameObject;
                BuildObject.transform.SetParent(PhysicalArea);
                BuildObject.name = a.Name + "Holder";
                PhysicalStats.Add(BuildObject);
            }
            if (a.category == "Social")
            {
                GameObject newStatObject = Resources.Load("StatHolder") as GameObject;
                newStatObject.GetComponent<StatHolderScript>().StatName = a.Name;
                newStatObject.GetComponent<StatHolderScript>().StatType = StatHolderScript.MyEnum.Social;
                newStatObject.GetComponent<StatHolderScript>().DisplayValue = 1;
                GameObject BuildObject = Instantiate(newStatObject, SocialArea.transform.position, Quaternion.identity) as GameObject;
                BuildObject.transform.SetParent(SocialArea);
                BuildObject.name = a.Name + "Holder";
                SocialStats.Add(BuildObject);
            }
            if (a.category == "Mental")
            {
                GameObject newStatObject = Resources.Load("StatHolder") as GameObject;
                newStatObject.GetComponent<StatHolderScript>().StatName = a.Name;
                newStatObject.GetComponent<StatHolderScript>().StatType = StatHolderScript.MyEnum.Mental;
                newStatObject.GetComponent<StatHolderScript>().DisplayValue = 1;
                GameObject BuildObject = Instantiate(newStatObject, MentalArea.transform.position, Quaternion.identity) as GameObject;
                BuildObject.transform.SetParent(MentalArea);
                BuildObject.name = a.Name + "Holder";
                MentalStats.Add(BuildObject);
            }
            if (a.category == "Talent")
            {
                GameObject newStatObject = Resources.Load("StatHolder") as GameObject;
                newStatObject.GetComponent<StatHolderScript>().StatName = a.Name;
                newStatObject.GetComponent<StatHolderScript>().StatType = StatHolderScript.MyEnum.Talents;
                newStatObject.GetComponent<StatHolderScript>().DisplayValue = 0;
                GameObject BuildObject = Instantiate(newStatObject, TalentsArea.transform.position, Quaternion.identity) as GameObject;
                BuildObject.transform.SetParent(TalentsArea);
                BuildObject.name = a.Name + "Holder";
                TalentStats.Add(BuildObject);
            }
            if (a.category == "Skills")
            {
                GameObject newStatObject = Resources.Load("StatHolder") as GameObject;
                newStatObject.GetComponent<StatHolderScript>().StatName = a.Name;
                newStatObject.GetComponent<StatHolderScript>().StatType = StatHolderScript.MyEnum.Skills;
                newStatObject.GetComponent<StatHolderScript>().DisplayValue = 0;
                GameObject BuildObject = Instantiate(newStatObject, SkillsArea.transform.position, Quaternion.identity) as GameObject;
                BuildObject.transform.SetParent(SkillsArea);
                BuildObject.name = a.Name + "Holder";
                SkillStats.Add(BuildObject);
            }
            if (a.category == "Knowledges")
            {
                GameObject newStatObject = Resources.Load("StatHolder") as GameObject;
                newStatObject.GetComponent<StatHolderScript>().StatName = a.Name;
                newStatObject.GetComponent<StatHolderScript>().StatType = StatHolderScript.MyEnum.Knowledges;
                newStatObject.GetComponent<StatHolderScript>().DisplayValue = 0;
                GameObject BuildObject = Instantiate(newStatObject, KnowledgesArea.transform.position, Quaternion.identity) as GameObject;
                BuildObject.transform.SetParent(KnowledgesArea);
                BuildObject.name = a.Name + "Holder";
                KnowledgeStats.Add(BuildObject);
            }

        }
        List<string> optionsList = new List<string>();
        optionsList = new List<string>();
        //load disciplines
        foreach (Discipline a in XMLObject.GetComponent<XMLSerializerScript>().MyDisciplines.DisciplineList)
        {
            optionsList.Add(a.Name);
        }
        for (int i = 0; i < 5; i++)
        {
            GameObject newStatObject = Resources.Load("DropHolder") as GameObject;

            newStatObject.GetComponent<StatHolderScript>().DisplayValue = 0;
            newStatObject.GetComponent<StatHolderScript>().StatName = "Discipline" + i.ToString();
            newStatObject.GetComponent<StatHolderScript>().StatType = StatHolderScript.MyEnum.Discipline;
            newStatObject.GetComponent<StatHolderScript>().optionsList = optionsList;
            GameObject BuildObject = Instantiate(newStatObject, DisciplineArea.transform.position, Quaternion.identity) as GameObject;
            BuildObject.transform.SetParent(DisciplineArea);
            //BuildObject.GetComponent<StatHolderScript>().optionsList = optionsList;
            BuildObject.name = "Discipline" + i.ToString();

            DisciplineStats.Add(BuildObject);
        }
        //Load Backgrounds;
        optionsList = new List<string>();

        foreach (Background a in XMLObject.GetComponent<XMLSerializerScript>().MyBackgrounds.BackgroundList)
        {
            optionsList.Add(a.Name);
        }
        for (int i = 0; i < 5; i++)
        {
            GameObject newStatObject = Resources.Load("DropHolder") as GameObject;

            newStatObject.GetComponent<StatHolderScript>().DisplayValue = 0;
            newStatObject.GetComponent<StatHolderScript>().StatName = "Background" + i.ToString();
            newStatObject.GetComponent<StatHolderScript>().StatType = StatHolderScript.MyEnum.Background;
            newStatObject.GetComponent<StatHolderScript>().optionsList = optionsList;
            GameObject BuildObject = Instantiate(newStatObject, BackgroundArea.transform.position, Quaternion.identity) as GameObject;
            BuildObject.transform.SetParent(BackgroundArea);
            //  BuildObject.GetComponent<StatHolderScript>().optionsList = optionsList;
            BuildObject.name = "Background" + i.ToString();
            BackgroundStats.Add(BuildObject);
        }
        //LoadVirtues
        List<string> virtueNameList = new List<string>();
        virtueNameList.Add("Conscience");
        virtueNameList.Add("Self-Control");
        virtueNameList.Add("Courage");
        for (int i = 0; i < 3; i++)
        {
            GameObject newStatObject = Resources.Load("VirtueHolder") as GameObject;
            newStatObject.GetComponent<StatHolderScript>().StatName = virtueNameList[i];
            newStatObject.GetComponent<StatHolderScript>().StatType = StatHolderScript.MyEnum.Virtue;
            GameObject BuildObject = Instantiate(newStatObject, VirtueArea.transform.position, Quaternion.identity) as GameObject;
            BuildObject.transform.SetParent(VirtueArea);
            //  BuildObject.GetComponent<StatHolderScript>().StatName = virtueNameList[i];
            BuildObject.name = virtueNameList[i];
            VirtueStats.Add(BuildObject);
        }
        optionsList = new List<string>();
        //load Other traits
        optionsList.Add("Select Traits");
        foreach (MeritFlaw a in XMLObject.GetComponent<XMLSerializerScript>().MyMeritFlaws.MeritFlawList)
        {
            optionsList.Add(a.Title + " " + a.Cost +"-Pt " +a.category);
        }
        for (int i = 0; i < 10; i++)
        {
            GameObject newStatObject = Resources.Load("OtherTraitDropHolder") as GameObject;
            newStatObject.GetComponent<StatHolderScript>().optionsList = optionsList;
            newStatObject.GetComponent<StatHolderScript>().StatType = StatHolderScript.MyEnum.OtherTraits;
            GameObject BuildObject = Instantiate(newStatObject, OtherTraitArea.transform.position, Quaternion.identity) as GameObject;
            BuildObject.transform.SetParent(OtherTraitArea);
            //BuildObject.GetComponent<StatHolderScript>().optionsList = optionsList;
            BuildObject.name = "OtherTrait" + i.ToString();
            OtherTraitStats.Add(BuildObject);
        }
        //
        optionsList = new List<string>();
        foreach (Path a in XMLObject.GetComponent<XMLSerializerScript>().MyPaths.PathList)
        {
            optionsList.Add(a.Name);
        }
        GameObject newStatObject2 = Resources.Load("HumanityHolder") as GameObject;
        newStatObject2.GetComponent<StatHolderScript>().optionsList = optionsList;
        newStatObject2.GetComponent<StatHolderScript>().StatType = StatHolderScript.MyEnum.Humanity;
        GameObject BuildObject2 = Instantiate(newStatObject2, HumanityArea.transform.position, Quaternion.identity) as GameObject;
        BuildObject2.transform.SetParent(HumanityArea);
        BuildObject2.GetComponent<StatHolderScript>().optionsList = optionsList;
        BuildObject2.name = "Humanity";
        HumanityStats = BuildObject2;
        GameObject newStatObject3 = Resources.Load("WillpowerHolder") as GameObject;
        newStatObject3.GetComponent<StatHolderScript>().StatType = StatHolderScript.MyEnum.Willpower;
        GameObject BuildObject3 = Instantiate(newStatObject3, WillpowerArea.transform.position, Quaternion.identity) as GameObject;
        BuildObject3.transform.SetParent(WillpowerArea);
        BuildObject3.name = "Willpower";
        WillpowerStats = BuildObject3;
        GameObject newStatObject4 = Resources.Load("BloodpoolHolder") as GameObject;
        newStatObject4.GetComponent<StatHolderScript>().StatType = StatHolderScript.MyEnum.BloodPool;
        GameObject BuildObject4 = Instantiate(newStatObject4, BloodpoolArea.transform.position, Quaternion.identity) as GameObject;
        BuildObject4.transform.SetParent(BloodpoolArea);
        BuildObject4.name = "Bloodpool";
        BloodpoolStats = BuildObject4;

        List<string> healthNameList = new List<string>();
        healthNameList.Add("Bruised");
        healthNameList.Add("Hurt");
        healthNameList.Add("Injured");
        healthNameList.Add("Wounded");
        healthNameList.Add("Mauled");
        healthNameList.Add("Crippled");
        healthNameList.Add("Incapacitated");
        foreach (string a in healthNameList)
        {
            GameObject newStatObject = Resources.Load("HealthHolder") as GameObject;
            newStatObject.GetComponent<StatHolderScript>().StatName = a;
            newStatObject.GetComponent<StatHolderScript>().StatType = StatHolderScript.MyEnum.Health;
            GameObject BuildObject = Instantiate(newStatObject, HealthArea.transform.position, Quaternion.identity) as GameObject;
            BuildObject.transform.SetParent(HealthArea);
            BuildObject.name = a + "Health";
            HealthStats.Add(BuildObject);
        }
        //  DisplayCharacter(XMLObject.GetComponent<XMLSerializerScript>().MyCharacters.CharacterList[0]);
    }
    public int ReturnCharacterIntVar(string detail)
    {
        if (detail == "Nature")
        {
            return CharacterDetails[3].GetComponent<StatHolderScript>().DisplayValue;
        }
        else if (detail == "Demeanor")
        {
            return CharacterDetails[4].GetComponent<StatHolderScript>().DisplayValue;

        }
        else if (detail == "Clan")
        {
            return CharacterDetails[5].GetComponent<StatHolderScript>().DisplayValue2;

        }
        else if (detail == "Generation")
        {
            return CharacterDetails[6].GetComponent<StatHolderScript>().DisplayValue;

        }
        else if (detail == "Concept")
        {
            return CharacterDetails[8].GetComponent<StatHolderScript>().DisplayValue;
        }
        else
        {
            return 0;
        }
    }
    public string ReturnCharacterStringVar(string detail)
    {
        if (detail == "Name")
        {
            return CharacterDetails[0].GetComponent<StatHolderScript>().UserInput.text;
        }
        if (detail == "Player")
        {
            return CharacterDetails[1].GetComponent<StatHolderScript>().UserInput.text;
        }
        if (detail == "Chronicle")
        {
            return CharacterDetails[2].GetComponent<StatHolderScript>().UserInput.text;
        }
        if (detail == "Haven")
        {
            return CharacterDetails[7].GetComponent<StatHolderScript>().UserInput.text;
        }
        else
        {
            return "";
        }
    }
    public void SaveCharacter()
    {
        Character NewCharacter = new Character();
        NewCharacter.Name = CharacterDetails[0].GetComponent<StatHolderScript>().StringValue;
        NewCharacter.Player = CharacterDetails[1].GetComponent<StatHolderScript>().StringValue;
        NewCharacter.Chronicle = CharacterDetails[2].GetComponent<StatHolderScript>().StringValue;
        NewCharacter.Nature = CharacterDetails[3].GetComponent<StatHolderScript>().DisplayValue2;
        NewCharacter.Demeanor = CharacterDetails[4].GetComponent<StatHolderScript>().DisplayValue2;
        NewCharacter.Clan = CharacterDetails[5].GetComponent<StatHolderScript>().DisplayValue2;
        NewCharacter.Generation = CharacterDetails[6].GetComponent<StatHolderScript>().DisplayValue2;
        NewCharacter.Haven = CharacterDetails[7].GetComponent<StatHolderScript>().StringValue;
        NewCharacter.Concept = CharacterDetails[8].GetComponent<StatHolderScript>().DisplayValue2;

        NewCharacter.Strength = PhysicalStats[0].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Dexterity = PhysicalStats[1].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Stamina = PhysicalStats[2].GetComponent<StatHolderScript>().DisplayValue;

        NewCharacter.Charisma = SocialStats[0].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Manipulation = SocialStats[1].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Appearance = SocialStats[2].GetComponent<StatHolderScript>().DisplayValue;

        NewCharacter.Perception = SocialStats[0].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Intelligence = SocialStats[1].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Wits = SocialStats[2].GetComponent<StatHolderScript>().DisplayValue;

        NewCharacter.Alertness = TalentStats[0].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Athletics = TalentStats[1].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Brawl = TalentStats[2].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Dodge = TalentStats[3].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Empathy = TalentStats[4].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Expression = TalentStats[5].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Intimidation = TalentStats[6].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Leadership = TalentStats[7].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Streetwise = TalentStats[8].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Subterfuge = TalentStats[9].GetComponent<StatHolderScript>().DisplayValue;

        NewCharacter.AnimalKen = SkillStats[0].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Crafts = SkillStats[1].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Drive = SkillStats[2].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Etiquette = SkillStats[3].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.FireArms = SkillStats[4].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Melee = SkillStats[5].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Performance = SkillStats[6].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Security = SkillStats[7].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Stealth = SkillStats[8].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Survival = SkillStats[9].GetComponent<StatHolderScript>().DisplayValue;

        NewCharacter.Academics = KnowledgeStats[0].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Computer = KnowledgeStats[1].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Finance = KnowledgeStats[2].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Investigation = KnowledgeStats[3].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Law = KnowledgeStats[4].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Linguistics = KnowledgeStats[5].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Medicine = KnowledgeStats[6].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Occult = KnowledgeStats[7].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Politics = KnowledgeStats[8].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Science = KnowledgeStats[9].GetComponent<StatHolderScript>().DisplayValue;

        NewCharacter.Discipline0Name = DisciplineStats[0].GetComponent<StatHolderScript>().DropValue;
        NewCharacter.Discipline0Value = DisciplineStats[0].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Discipline1Name = DisciplineStats[1].GetComponent<StatHolderScript>().DropValue;
        NewCharacter.Discipline1Value = DisciplineStats[1].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Discipline2Name = DisciplineStats[2].GetComponent<StatHolderScript>().DropValue;
        NewCharacter.Discipline2Value = DisciplineStats[2].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Discipline3Name = DisciplineStats[3].GetComponent<StatHolderScript>().DropValue;
        NewCharacter.Discipline3Value = DisciplineStats[3].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Discipline4Name = DisciplineStats[4].GetComponent<StatHolderScript>().DropValue;
        NewCharacter.Discipline4Value = DisciplineStats[4].GetComponent<StatHolderScript>().DisplayValue;

        NewCharacter.Background0Name = BackgroundStats[0].GetComponent<StatHolderScript>().DropValue;
        NewCharacter.Background0Value = BackgroundStats[0].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Background1Name = BackgroundStats[1].GetComponent<StatHolderScript>().DropValue;
        NewCharacter.Background1Value = BackgroundStats[1].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Background2Name = BackgroundStats[2].GetComponent<StatHolderScript>().DropValue;
        NewCharacter.Background2Value = BackgroundStats[2].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Background3Name = BackgroundStats[3].GetComponent<StatHolderScript>().DropValue;
        NewCharacter.Background3Value = BackgroundStats[3].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.Background4Name = BackgroundStats[4].GetComponent<StatHolderScript>().DropValue;
        NewCharacter.Background4Value = BackgroundStats[4].GetComponent<StatHolderScript>().DisplayValue;

        NewCharacter.MaxConCov = VirtueStats[0].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.MaxSelfControl = VirtueStats[1].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.MaxCourage = VirtueStats[0].GetComponent<StatHolderScript>().DisplayValue;

        NewCharacter.OtherTrait0Name = OtherTraitStats[0].GetComponent<StatHolderScript>().DropValue;
        NewCharacter.OtherTrait0Value = OtherTraitStats[0].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.OtherTrait1Name = OtherTraitStats[1].GetComponent<StatHolderScript>().DropValue;
        NewCharacter.OtherTrait1Value = OtherTraitStats[1].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.OtherTrait2Name = OtherTraitStats[2].GetComponent<StatHolderScript>().DropValue;
        NewCharacter.OtherTrait2Value = OtherTraitStats[2].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.OtherTrait3Name = OtherTraitStats[3].GetComponent<StatHolderScript>().DropValue;
        NewCharacter.OtherTrait3Value = OtherTraitStats[3].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.OtherTrait4Name = OtherTraitStats[4].GetComponent<StatHolderScript>().DropValue;
        NewCharacter.OtherTrait4Value = OtherTraitStats[4].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.OtherTrait5Name = OtherTraitStats[5].GetComponent<StatHolderScript>().DropValue;
        NewCharacter.OtherTrait5Value = OtherTraitStats[5].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.OtherTrait6Name = OtherTraitStats[6].GetComponent<StatHolderScript>().DropValue;
        NewCharacter.OtherTrait6Value = OtherTraitStats[6].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.OtherTrait7Name = OtherTraitStats[7].GetComponent<StatHolderScript>().DropValue;
        NewCharacter.OtherTrait7Value = OtherTraitStats[7].GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.OtherTrait8Name = OtherTraitStats[8].GetComponent<StatHolderScript>().DropValue;
        NewCharacter.OtherTrait8Value = OtherTraitStats[8].GetComponent<StatHolderScript>().DisplayValue;
        // NewCharacter.OtherTrait9Name = OtherTraitStats[9].GetComponent<StatHolderScript>().DropValue;
        // NewCharacter.OtherTrait9Value = OtherTraitStats[9].GetComponent<StatHolderScript>().DisplayValue;

        NewCharacter.HumanityPathName = HumanityStats.GetComponent<StatHolderScript>().DropValue;
        NewCharacter.HumanityPathValue = HumanityStats.GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.WillpowerMaxSquaresValue = WillpowerStats.GetComponent<StatHolderScript>().DisplayValue2;
        NewCharacter.WillpowerDotsMaxValue = WillpowerStats.GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.BloodPoolMax = BloodpoolStats.GetComponent<StatHolderScript>().DisplayValue;
        NewCharacter.bruised = HealthStats[0].GetComponent<StatHolderScript>().StateTrue;
        NewCharacter.hurt = HealthStats[1].GetComponent<StatHolderScript>().StateTrue;
        NewCharacter.Injured = HealthStats[2].GetComponent<StatHolderScript>().StateTrue;
        NewCharacter.Wounded = HealthStats[3].GetComponent<StatHolderScript>().StateTrue;
        NewCharacter.Mauled = HealthStats[4].GetComponent<StatHolderScript>().StateTrue;
        NewCharacter.Crippled = HealthStats[5].GetComponent<StatHolderScript>().StateTrue;
        NewCharacter.Incapacitated = HealthStats[6].GetComponent<StatHolderScript>().StateTrue;

        NewCharacter.Experiance = "0";

        XMLObject.GetComponent<XMLSerializerScript>().SaveCharacter(NewCharacter);
        if (NewCharSheet)
        {
            GameObject.Find("ViewCharacterCanvas").gameObject.GetComponent<CharacterDisplayScript>().UpdateCharacterView();
        }
    }
    public void DisplayCharacter(Character b)
    {
        CharacterDetails[0].GetComponent<StatHolderScript>().UserInput.text = b.Name;
        CharacterDetails[1].GetComponent<StatHolderScript>().UserInput.text = b.Player;
        CharacterDetails[2].GetComponent<StatHolderScript>().UserInput.text = b.Chronicle;
        CharacterDetails[3].GetComponent<StatHolderScript>().SetDisplayValue2(b.Nature);
        CharacterDetails[4].GetComponent<StatHolderScript>().DropDown.value = b.Demeanor;
        CharacterDetails[5].GetComponent<StatHolderScript>().DropDown.value = b.Clan;
        CharacterDetails[6].GetComponent<StatHolderScript>().DropDown.value = b.Generation;
        CharacterDetails[7].GetComponent<StatHolderScript>().UserInput.text = b.Haven;
        CharacterDetails[8].GetComponent<StatHolderScript>().DropDown.value = b.Concept;

        PhysicalStats[0].GetComponent<StatHolderScript>().SetDisplayValue(b.Strength);
        PhysicalStats[1].GetComponent<StatHolderScript>().SetDisplayValue(b.Dexterity);
        PhysicalStats[2].GetComponent<StatHolderScript>().SetDisplayValue(b.Stamina);

        SocialStats[0].GetComponent<StatHolderScript>().SetDisplayValue(b.Charisma);
        SocialStats[1].GetComponent<StatHolderScript>().SetDisplayValue(b.Manipulation);
        SocialStats[2].GetComponent<StatHolderScript>().SetDisplayValue(b.Appearance);

        MentalStats[0].GetComponent<StatHolderScript>().SetDisplayValue(b.Strength);
        MentalStats[1].GetComponent<StatHolderScript>().SetDisplayValue(b.Dexterity);
        MentalStats[2].GetComponent<StatHolderScript>().SetDisplayValue(b.Stamina);

        TalentStats[0].GetComponent<StatHolderScript>().SetDisplayValue(b.Alertness);
        TalentStats[1].GetComponent<StatHolderScript>().SetDisplayValue(b.Athletics);
        TalentStats[2].GetComponent<StatHolderScript>().SetDisplayValue(b.Brawl);
        TalentStats[3].GetComponent<StatHolderScript>().SetDisplayValue(b.Dodge);
        TalentStats[4].GetComponent<StatHolderScript>().SetDisplayValue(b.Empathy);
        TalentStats[5].GetComponent<StatHolderScript>().SetDisplayValue(b.Expression);
        TalentStats[6].GetComponent<StatHolderScript>().SetDisplayValue(b.Intimidation);
        TalentStats[7].GetComponent<StatHolderScript>().SetDisplayValue(b.Leadership);
        TalentStats[8].GetComponent<StatHolderScript>().SetDisplayValue(b.Streetwise);
        TalentStats[9].GetComponent<StatHolderScript>().SetDisplayValue(b.Subterfuge);

        SkillStats[0].GetComponent<StatHolderScript>().SetDisplayValue(b.AnimalKen);
        SkillStats[1].GetComponent<StatHolderScript>().SetDisplayValue(b.Crafts);
        SkillStats[2].GetComponent<StatHolderScript>().SetDisplayValue(b.Drive);
        SkillStats[3].GetComponent<StatHolderScript>().SetDisplayValue(b.Etiquette);
        SkillStats[4].GetComponent<StatHolderScript>().SetDisplayValue(b.FireArms);
        SkillStats[5].GetComponent<StatHolderScript>().SetDisplayValue(b.Melee);
        SkillStats[6].GetComponent<StatHolderScript>().SetDisplayValue(b.Performance);
        SkillStats[7].GetComponent<StatHolderScript>().SetDisplayValue(b.Security);
        SkillStats[8].GetComponent<StatHolderScript>().SetDisplayValue(b.Stealth);
        SkillStats[9].GetComponent<StatHolderScript>().SetDisplayValue(b.Survival);

        KnowledgeStats[0].GetComponent<StatHolderScript>().SetDisplayValue(b.Academics);
        KnowledgeStats[1].GetComponent<StatHolderScript>().SetDisplayValue(b.Computer);
        KnowledgeStats[2].GetComponent<StatHolderScript>().SetDisplayValue(b.Finance);
        KnowledgeStats[3].GetComponent<StatHolderScript>().SetDisplayValue(b.Investigation);
        KnowledgeStats[4].GetComponent<StatHolderScript>().SetDisplayValue(b.Law);
        KnowledgeStats[5].GetComponent<StatHolderScript>().SetDisplayValue(b.Linguistics);
        KnowledgeStats[6].GetComponent<StatHolderScript>().SetDisplayValue(b.Medicine);
        KnowledgeStats[7].GetComponent<StatHolderScript>().SetDisplayValue(b.Occult);
        KnowledgeStats[8].GetComponent<StatHolderScript>().SetDisplayValue(b.Politics);
        KnowledgeStats[9].GetComponent<StatHolderScript>().SetDisplayValue(b.Science);

        DisciplineStats[0].GetComponent<StatHolderScript>().SetDisplayValue(b.Discipline0Value);
        DisciplineStats[0].GetComponent<StatHolderScript>().DropDown.value = b.Discipline0Name;
        DisciplineStats[1].GetComponent<StatHolderScript>().SetDisplayValue(b.Discipline1Value);
        DisciplineStats[1].GetComponent<StatHolderScript>().DropDown.value = b.Discipline1Name;
        DisciplineStats[2].GetComponent<StatHolderScript>().SetDisplayValue(b.Discipline2Value);
        DisciplineStats[2].GetComponent<StatHolderScript>().DropDown.value = b.Discipline2Name;
        DisciplineStats[3].GetComponent<StatHolderScript>().SetDisplayValue(b.Discipline3Value);
        DisciplineStats[3].GetComponent<StatHolderScript>().DropDown.value = b.Discipline3Name;
        DisciplineStats[4].GetComponent<StatHolderScript>().SetDisplayValue(b.Discipline4Value);
        DisciplineStats[4].GetComponent<StatHolderScript>().DropDown.value = b.Discipline4Name;

        BackgroundStats[0].GetComponent<StatHolderScript>().SetDisplayValue(b.Background0Value);
        BackgroundStats[0].GetComponent<StatHolderScript>().DropDown.value = b.Background0Name;
        BackgroundStats[1].GetComponent<StatHolderScript>().SetDisplayValue(b.Background1Value);
        BackgroundStats[1].GetComponent<StatHolderScript>().DropDown.value = b.Background1Name;
        BackgroundStats[2].GetComponent<StatHolderScript>().SetDisplayValue(b.Background2Value);
        BackgroundStats[2].GetComponent<StatHolderScript>().DropDown.value = b.Background2Name;
        BackgroundStats[3].GetComponent<StatHolderScript>().SetDisplayValue(b.Background3Value);
        BackgroundStats[3].GetComponent<StatHolderScript>().DropDown.value = b.Background3Name;
        BackgroundStats[4].GetComponent<StatHolderScript>().SetDisplayValue(b.Background4Value);
        BackgroundStats[4].GetComponent<StatHolderScript>().DropDown.value = b.Background4Name;

        VirtueStats[0].GetComponent<StatHolderScript>().SetDisplayValue(b.MaxConCov);
        VirtueStats[1].GetComponent<StatHolderScript>().SetDisplayValue(b.MaxSelfControl);
        VirtueStats[2].GetComponent<StatHolderScript>().SetDisplayValue(b.MaxCourage);

        OtherTraitStats[0].GetComponent<StatHolderScript>().SetDisplayValue(b.OtherTrait0Value);
        OtherTraitStats[0].GetComponent<StatHolderScript>().DropDown.value = b.OtherTrait0Name;
        OtherTraitStats[1].GetComponent<StatHolderScript>().SetDisplayValue(b.OtherTrait1Value);
        OtherTraitStats[1].GetComponent<StatHolderScript>().DropDown.value = b.OtherTrait1Name;
        OtherTraitStats[2].GetComponent<StatHolderScript>().SetDisplayValue(b.OtherTrait2Value);
        OtherTraitStats[2].GetComponent<StatHolderScript>().DropDown.value = b.OtherTrait2Name;
        OtherTraitStats[3].GetComponent<StatHolderScript>().SetDisplayValue(b.OtherTrait3Value);
        OtherTraitStats[3].GetComponent<StatHolderScript>().DropDown.value = b.OtherTrait3Name;
        OtherTraitStats[4].GetComponent<StatHolderScript>().SetDisplayValue(b.OtherTrait4Value);
        OtherTraitStats[4].GetComponent<StatHolderScript>().DropDown.value = b.OtherTrait4Name;
        OtherTraitStats[5].GetComponent<StatHolderScript>().SetDisplayValue(b.OtherTrait5Value);
        OtherTraitStats[5].GetComponent<StatHolderScript>().DropDown.value = b.OtherTrait5Name;
        OtherTraitStats[6].GetComponent<StatHolderScript>().SetDisplayValue(b.OtherTrait6Value);
        OtherTraitStats[6].GetComponent<StatHolderScript>().DropDown.value = b.OtherTrait6Name;
        OtherTraitStats[7].GetComponent<StatHolderScript>().SetDisplayValue(b.OtherTrait7Value);
        OtherTraitStats[7].GetComponent<StatHolderScript>().DropDown.value = b.OtherTrait7Name;
        OtherTraitStats[8].GetComponent<StatHolderScript>().SetDisplayValue(b.OtherTrait8Value);
        OtherTraitStats[8].GetComponent<StatHolderScript>().DropDown.value = b.OtherTrait8Name;
        OtherTraitStats[9].GetComponent<StatHolderScript>().SetDisplayValue(b.OtherTrait9Value);
        OtherTraitStats[9].GetComponent<StatHolderScript>().DropDown.value = b.OtherTrait9Name;

        HumanityStats.GetComponent<StatHolderScript>().SetDisplayValue(b.HumanityPathValue);
        HumanityStats.GetComponent<StatHolderScript>().SetDropValue(b.HumanityPathName);
        WillpowerStats.GetComponent<StatHolderScript>().SetDisplayValue2(b.WillpowerMaxSquaresValue);
        WillpowerStats.GetComponent<StatHolderScript>().SetDisplayValue(b.WillpowerDotsMaxValue);
        BloodpoolStats.GetComponent<StatHolderScript>().SetDisplayValue(b.BloodPoolMax);


        HealthStats[0].GetComponent<StatHolderScript>().SetState(b.bruised);
        HealthStats[1].GetComponent<StatHolderScript>().SetState(b.hurt);
        HealthStats[2].GetComponent<StatHolderScript>().SetState(b.Injured);
        HealthStats[3].GetComponent<StatHolderScript>().SetState(b.Wounded);
        HealthStats[4].GetComponent<StatHolderScript>().SetState(b.Mauled);
        HealthStats[5].GetComponent<StatHolderScript>().SetState(b.Crippled);
        HealthStats[6].GetComponent<StatHolderScript>().SetState(b.Incapacitated);

    }
    public void RemoveCharacter(Character c)
    {
        transform.Find("ConfirmDelete").gameObject.GetComponent<DeleteCharacterConfirm>().ShowConfirm(c);
    }
    public void CloseCanvasGroup(CanvasGroup a)
    {
        a.alpha = 0;
        a.interactable = false;
        a.blocksRaycasts = false;
    }
    public void OpenCanvasGroup(CanvasGroup a)
    {
        a.alpha = 1;
        a.interactable = true;
        a.blocksRaycasts = true;
    }
    public void Update()
    {
        if (NewCharSheet)
        {
            if (!buildNames)
            {
                foreach (Character a in XMLObject.GetComponent<XMLSerializerScript>().MyCharacters.CharacterList)
                {
                    Names.Add(a.Name);
                }
                buildNames = true;
            }
            else
            {
                if (Names.Contains(CharacterDetails[0].GetComponent<StatHolderScript>().StringValue))
                {
                    MessageBox.text = "The character name \n" + CharacterDetails[0].GetComponent<StatHolderScript>().StringValue + " \n Is already taken.";
                }
            }

            if (!DetailsFilled)
            {
                MessageBox.text = CheckDetails();
                SaveButton.interactable = false;
            }
            else
            {
                List<Clan> TempClans = XMLObject.GetComponent<XMLSerializerScript>().UpdateAndReturnClans();
                int ClanValue = CharacterDetails[5].GetComponent<StatHolderScript>().DropDown.value;
                DisciplineStats[0].GetComponent<StatHolderScript>().DropDown.value = TempClans[ClanValue].StarterDiscipline0;
                //DisciplineStats[0].GetComponent<StatHolderScript>().UpdateValues();
                DisciplineStats[1].GetComponent<StatHolderScript>().DropDown.value = TempClans[ClanValue].StarterDiscipline1;
                // DisciplineStats[1].GetComponent<StatHolderScript>().UpdateValues();
                DisciplineStats[2].GetComponent<StatHolderScript>().DropDown.value = TempClans[ClanValue].StarterDiscipline2;
                // DisciplineStats[2].GetComponent<StatHolderScript>().UpdateValues();
                DisciplineStats[3].GetComponent<StatHolderScript>().DropDown.value = 0;
                DisciplineStats[4].GetComponent<StatHolderScript>().DropDown.value = 0;

                if (!trigger)
                {
                    MessageBox.text = "Please Spend Primary Attributes";
                    ToggleAttributes(false);
                    trigger = true;
                    // Debug.Log("Run Count");
                }
                if (!AttributesFull)
                {
                    MessageBox.text = CheckAttributePoints();
                    SaveButton.interactable = false;
                }
                else
                {
                    if (!trigger2)
                    {
                        MessageBox.text = "Please Spend Primary Abilitiy points";
                        ToggleAbilities(false);
                        trigger2 = true;
                        // Debug.Log("Run Count");
                    }
                    if (!AbilitiesFull)
                    {
                        MessageBox.text = CheckAbilitiePoints();
                        SaveButton.interactable = false;
                    }
                    else
                    {
                        if (!trigger3)
                        {
                            MessageBox.text = "Please Spend Discipline points";
                            ToggleDisciplines(false);
                            trigger3 = true;
                            // Debug.Log("Run Count");
                        }
                        if (!DisciplinesFull)
                        {
                            MessageBox.text = CheckDisciplines();
                            SaveButton.interactable = false;
                        }
                        else
                        {
                            if (!trigger4)
                            {
                                MessageBox.text = "Please Spend background points";
                                ToggleBackground(false);
                                trigger4 = true;
                                // Debug.Log("Run Count");
                            }
                            if (!BackgroundsFull)
                            {
                                MessageBox.text = CheckBackgrounds();
                                SaveButton.interactable = false;
                            }
                            else
                            {
                                if (!trigger5)
                                {
                                    MessageBox.text = "Please Spend Virtue points";
                                    ToggleVirtues(false);
                                    trigger5 = true;
                                    // Debug.Log("Run Count");
                                }
                                if (!VirtuesFull)
                                {
                                    MessageBox.text = CheckVirtuePoints();
                                    SaveButton.interactable = false;

                                }
                                else
                                {
                                    if (!trigger6)
                                    {
                                        MessageBox.text = "Adding up willpower and Humanity scores. Bloodpool randomized 1-10. You may now save.";
                                        HumanityStats.GetComponent<StatHolderScript>().DisplayValue = VirtueStats[0].GetComponent<StatHolderScript>().DisplayValue + VirtueStats[1].GetComponent<StatHolderScript>().DisplayValue;
                                        HumanityStats.GetComponent<StatHolderScript>().UpdateValues();
                                        WillpowerStats.GetComponent<StatHolderScript>().DisplayValue = VirtueStats[2].GetComponent<StatHolderScript>().DisplayValue;
                                        WillpowerStats.GetComponent<StatHolderScript>().DisplayValue2 = VirtueStats[2].GetComponent<StatHolderScript>().DisplayValue;
                                        WillpowerStats.GetComponent<StatHolderScript>().UpdateValues();
                                        BloodpoolStats.GetComponent<StatHolderScript>().DisplayValue = Random.Range(1, 10);
                                        BloodpoolStats.GetComponent<StatHolderScript>().UpdateValues();
                                        trigger6 = true;


                                        // Debug.Log("Run Count");
                                    }
                                    if (!FreebiePointFull)
                                    {
                                        ToggleOtherStats(false);
                                        ToggleHumanity(false);
                                    }
                                    SaveButton.interactable = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        else
        {
            //disable all blockers
        }
    }
    public string CheckBackgrounds()
    {
        if (BackgroundPoints > 0)
        {
            return "You have " + BackgroundPoints + " background points remaining.";
        }
        else
        {
            BackgroundsFull = true;
            return "Backgrounds spent";
        }
    }
    public string CheckDisciplines()
    {
        if (DisciplinePoints > 0)
        {
            return "You have " + DisciplinePoints + " discipline points remaining.";
        }
        else
        {
            DisciplinesFull = true;
            return "Disciplines spent";
        }
    }
    public string CheckAttributePoints()
    {
        if (PrimaryAttributesPoints > 0)
        {
            return "You have \n" + PrimaryAttributesPoints + "\n Primary attribute points remaining";

        }
        else if (SecondaryAttributesPoints > 0)
        {
            return "You have \n" + SecondaryAttributesPoints + " \n Secondary attribute points remaining";
        }
        else if (TeritaryAttributesPoints > 0)
        {
            return "You have \n" + TeritaryAttributesPoints + "\n Teritary attribute points remaining";
        }
        else
        {
            AttributesFull = true;
            return "Attributes Spent.";
        }
    }
    public string CheckAbilitiePoints()
    {
        if (PrimaryAbilitiesPoints > 0)
        {
            return "You have " + PrimaryAbilitiesPoints + " primary ability points remaining";

        }
        else if (SecondaryAbilitiesPoints > 0)
        {
            return "You have " + SecondaryAbilitiesPoints + " secondary ability points remaining";
        }
        else if (TeritaryAbilitiesPoints > 0)
        {
            return "You have " + TeritaryAbilitiesPoints + " teritary ability points remaining";
        }
        else
        {
            AbilitiesFull = true;
            return "Abilities Spent.";
        }
    }
    public string CheckVirtuePoints()
    {
        if (VirtuePoints > 0)
        {
            return "You have " + VirtuePoints + " virtue points remaining";

        }
        else
        {
            VirtuesFull = true;
            return "Virtues Spent.";
        }
    }
    public string CheckDetails()
    {

        if (!DetailsFilled)
        {
            if (CharacterDetails[0].GetComponent<StatHolderScript>().StringValue == "")
            {
                return "Please Enter a \n Character Name.";
            }
            else
            if (Names.Contains(CharacterDetails[0].GetComponent<StatHolderScript>().StringValue))
            {
                return "The character name \n" + CharacterDetails[0].GetComponent<StatHolderScript>().StringValue + "\n Is already in use.";
            }
            else if (CharacterDetails[1].GetComponent<StatHolderScript>().UserInput.text == "")
            {
                return "Please enter a \n Player name.";
            }
            else if (CharacterDetails[2].GetComponent<StatHolderScript>().UserInput.text == "")
            {
                return "Please enter a \n Chronicle.";
            }
            else if (CharacterDetails[3].GetComponent<StatHolderScript>().DisplayValue2 == 0)
            {
                return "Please select a \n Nature.";
            }
            else if (CharacterDetails[4].GetComponent<StatHolderScript>().DisplayValue2 == 0)
            {
                return "Please select a \n Demeanor.";
            }
            else if (CharacterDetails[5].GetComponent<StatHolderScript>().DisplayValue2 == 0)
            {
                return "Please select a \n clan.";
            }
            else if (CharacterDetails[7].GetComponent<StatHolderScript>().UserInput.text == "")
            {
                return "Please enter a \n Haven.";
            }
            else if (CharacterDetails[8].GetComponent<StatHolderScript>().DisplayValue2 == 0)
            {
                return "Please select a \n Concept.";
            }
            else
            {
                DetailsFilled = true;
                return "Please spend Primary Points.";

            }
        }
        else
        {

            return "Clear";
        }
    }
    public void IncreaseAttributeStat(StatHolderScript a)
    {
        if (!AttStatOrder.Contains(a.StatType))
        {
            if (AttStatOrder[0] == StatHolderScript.MyEnum.NULL)
            {
                AttStatOrder[0] = a.StatType;
            }
            else if (AttStatOrder[1] == StatHolderScript.MyEnum.NULL)
            {
                AttStatOrder[1] = a.StatType;
            }
            else if (AttStatOrder[2] == StatHolderScript.MyEnum.NULL)
            {
                AttStatOrder[2] = a.StatType;
            }
            else
            {
                Debug.Log("None of our options are null.");
            }
        }
        if (AttStatOrder[0] == a.StatType)
        {
            if (PrimaryAttributesPoints > 0 && a.DisplayValue < 5)
            {
                PrimaryAttributesPoints--;
                a.DisplayValue++;
                a.UpdateValues();
                Debug.Log("Primary point spent. on " + a.StatName.ToString() + " OF TYPE: " + a.StatType.ToString());
            }
            else
            {
                Debug.Log("Out of primary points.");
            }
        }
        if (AttStatOrder[1] == a.StatType && PrimaryAttributesPoints == 0)
        {
            if (SecondaryAttributesPoints > 0 && a.DisplayValue < 5)
            {
                SecondaryAttributesPoints--;
                a.DisplayValue++;
                a.UpdateValues();
                Debug.Log("Secondary point spent. on " + a.StatName.ToString() + " OF TYPE: " + a.StatType.ToString());
            }
            else
            {
                Debug.Log("Out of Secondary points.");
            }
        }
        if (AttStatOrder[2] == a.StatType && SecondaryAttributesPoints == 0)
        {
            if (TeritaryAttributesPoints > 0 && a.DisplayValue < 5)

            {
                TeritaryAttributesPoints--;
                a.DisplayValue++;
                a.UpdateValues();
                Debug.Log("Primary point spent. on " + a.StatName.ToString() + " OF TYPE: " + a.StatType.ToString());
            }
            else
            {
                Debug.Log("Out of teritary points.");
            }
        }
    }
    public void DecreaseAttributeStat(StatHolderScript a)
    {
        if (AttributesFull)
        {
            AttributesFull = false;
        }
        if (AttStatOrder[2] == a.StatType)
        {
            if (TeritaryAttributesPoints < 3 && a.DisplayValue > 1)
            {
                TeritaryAttributesPoints++;
                a.DisplayValue--;
                a.UpdateValues();
                Debug.Log("Teritery point refund on " + a.StatName.ToString() + ". Of TYPE: " + a.StatType.ToString());
                if (TeritaryAttributesPoints == 3)
                {
                    AttStatOrder[2] = StatHolderScript.MyEnum.NULL;
                }
            }
        }
        else
        if (AttStatOrder[1] == a.StatType && TeritaryAttributesPoints == 3)
        {
            if (SecondaryAttributesPoints < 5 && a.DisplayValue > 1)
            {
                SecondaryAttributesPoints++;
                a.DisplayValue--;
                a.UpdateValues();
                Debug.Log("Secondary point refund on " + a.StatName.ToString() + ". Of TYPE: " + a.StatType.ToString());
                if (SecondaryAttributesPoints == 5)
                {
                    AttStatOrder[1] = StatHolderScript.MyEnum.NULL;
                }
            }
        }
        else
        if (AttStatOrder[0] == a.StatType && SecondaryAttributesPoints == 5)
        {
            if (PrimaryAttributesPoints < 7 && a.DisplayValue > 1)
            {
                PrimaryAttributesPoints++;
                a.DisplayValue--;
                a.UpdateValues();
                Debug.Log("Primary point refund on " + a.StatName.ToString() + ". Of TYPE: " + a.StatType.ToString());
                if (PrimaryAttributesPoints == 7)
                {
                    AttStatOrder[0] = StatHolderScript.MyEnum.NULL;
                }
            }
        }
    }
    public void IncreaseAbilitiesStat(StatHolderScript a)
    {
        if (!AbilitiesOrder.Contains(a.StatType))
        {
            if (AbilitiesOrder[0] == StatHolderScript.MyEnum.NULL)
            {
                AbilitiesOrder[0] = a.StatType;
            }
            else if (AbilitiesOrder[1] == StatHolderScript.MyEnum.NULL)
            {
                AbilitiesOrder[1] = a.StatType;
            }
            else if (AbilitiesOrder[2] == StatHolderScript.MyEnum.NULL)
            {
                AbilitiesOrder[2] = a.StatType;
            }
            else
            {
                Debug.Log("None of our options are null.");
            }
        }
        if (AbilitiesOrder[0] == a.StatType)
        {
            if (PrimaryAbilitiesPoints > 0 && a.DisplayValue <3)
            {
                PrimaryAbilitiesPoints--;
                a.DisplayValue++;
                a.UpdateValues();
                Debug.Log("Primary point spent. on " + a.StatName.ToString() + " OF TYPE: " + a.StatType.ToString());
            }
            else
            {
                Debug.Log("Out of primary points.");
            }
        }
        if (AbilitiesOrder[1] == a.StatType && PrimaryAbilitiesPoints == 0)
        {
            if (SecondaryAbilitiesPoints > 0 && a.DisplayValue < 3)
            {
                SecondaryAbilitiesPoints--;
                a.DisplayValue++;
                a.UpdateValues();
                Debug.Log("Secondary point spent. on " + a.StatName.ToString() + " OF TYPE: " + a.StatType.ToString());
            }
            else
            {
                Debug.Log("Out of Secondary points.");
            }
        }
        if (AbilitiesOrder[2] == a.StatType && SecondaryAbilitiesPoints == 0)
        {
            if (TeritaryAbilitiesPoints > 0 && a.DisplayValue < 3)

            {
                TeritaryAbilitiesPoints--;
                a.DisplayValue++;
                a.UpdateValues();
                Debug.Log("Primary point spent. on " + a.StatName.ToString() + " OF TYPE: " + a.StatType.ToString());
            }
            else
            {
                Debug.Log("Out of teritary points.");
            }
        }

    }
    public void DecreaseAbilitiesStat(StatHolderScript a)
    {
        if (AbilitiesFull)
        {
            AbilitiesFull = false;
        }
        if (AbilitiesOrder[2] == a.StatType)
        {
            if (TeritaryAbilitiesPoints < 5 && a.DisplayValue > 0)
            {
                TeritaryAbilitiesPoints++;
                a.DisplayValue--;
                a.UpdateValues();
                Debug.Log("Teritery point refund on " + a.StatName.ToString() + ". Of TYPE: " + a.StatType.ToString());
                if (TeritaryAbilitiesPoints == 5)
                {
                    AbilitiesOrder[2] = StatHolderScript.MyEnum.NULL;
                }
            }
        }
        else
        if (AbilitiesOrder[1] == a.StatType && TeritaryAbilitiesPoints == 5)
        {
            if (SecondaryAbilitiesPoints < 9 && a.DisplayValue > 0)
            {
                SecondaryAbilitiesPoints++;
                a.DisplayValue--;
                a.UpdateValues();
                Debug.Log("Secondary point refund on " + a.StatName.ToString() + ". Of TYPE: " + a.StatType.ToString());
                if (SecondaryAbilitiesPoints == 9)
                {
                    AbilitiesOrder[1] = StatHolderScript.MyEnum.NULL;
                }
            }
        }
        else
        if (AbilitiesOrder[0] == a.StatType && SecondaryAbilitiesPoints == 9)
        {
            if (PrimaryAbilitiesPoints < 13 && a.DisplayValue > 0)
            {
                PrimaryAbilitiesPoints++;
                a.DisplayValue--;
                a.UpdateValues();
                Debug.Log("Primary point refund on " + a.StatName.ToString() + ". Of TYPE: " + a.StatType.ToString());
                if (PrimaryAbilitiesPoints == 13)
                {
                    AbilitiesOrder[0] = StatHolderScript.MyEnum.NULL;
                }
            }
        }
    }
    public void IncreaseDisciplineStat(StatHolderScript a)
    {
        if (DisciplinePoints > 0)
        {
            DisciplinePoints--;
            a.DisplayValue++;
            a.UpdateValues();
            Debug.Log("Discipline point spent. on " + a.StatName.ToString() + " OF TYPE: " + a.StatType.ToString());
        }
        else
        {

        }
    }
    public void DecreaseDisciplineStat(StatHolderScript a)
    {
        if (DisciplinesFull)
        {
            DisciplinesFull = false;
        }
        if (DisciplinePoints <= 2 && a.DisplayValue > 0)
        {
            DisciplinePoints++;
            a.DisplayValue--;
            a.UpdateValues();
            Debug.Log("Discipline point refund. on " + a.StatName.ToString() + " OF TYPE: " + a.StatType.ToString());
        }
        else
        {

        }
    }
    public void IncreaseBackgroundStat(StatHolderScript a)
    {
        if (BackgroundPoints > 0)
        {
            BackgroundPoints--;
            a.DisplayValue++;
            a.UpdateValues();
            Debug.Log("Background point spent. on " + a.StatName.ToString() + " OF TYPE: " + a.StatType.ToString());
        }
        else
        {

        }
    }
    public void DecreaseBackgroundStat(StatHolderScript a)
    {
        if (BackgroundsFull)
        {
            BackgroundsFull = false;
        }
        if (BackgroundPoints <= 2 && a.DisplayValue > 0)
        {
            BackgroundPoints++;
            a.DisplayValue--;
            a.UpdateValues();
            Debug.Log("Background point refund. on " + a.StatName.ToString() + " OF TYPE: " + a.StatType.ToString());
        }
        else
        {

        }
    }
    public void IncreaseVirtueStat(StatHolderScript a)
    {
        if (VirtuePoints > 0 && a.DisplayValue <= 4)
        {
            VirtuePoints--;
            a.DisplayValue++;
            a.UpdateValues();
            Debug.Log("Virtue point spent. on " + a.StatName.ToString() + " OF TYPE: " + a.StatType.ToString());
        }
        else
        {

        }
    }
    public void DecreaseVirtueStat(StatHolderScript a)
    {
        if (VirtuesFull)
        {
            VirtuesFull = false;
        }
        if (VirtuePoints <= 6 && a.DisplayValue > 0)
        {
            VirtuePoints++;
            a.DisplayValue--;
            a.UpdateValues();
            Debug.Log("Virtue point refund. on " + a.StatName.ToString() + " OF TYPE: " + a.StatType.ToString());
        }
        else
        {

        }
    }
    public void ToggleAttributes(bool a)
    {
        if(a == true)
        {
            AttributeBlocker.alpha = 1;
            AttributeBlocker.interactable = true;
            AttributeBlocker.blocksRaycasts = true;
        }
        else
        {
            AttributeBlocker.alpha = 0;
            AttributeBlocker.interactable = false;
            AttributeBlocker.blocksRaycasts = false;
        }
    }
    public void ToggleAbilities(bool a)
    {
        if (a == true)
        {
            AbillitiesBlocker.alpha = 1;
            AbillitiesBlocker.interactable = true;
            AbillitiesBlocker.blocksRaycasts = true;
        }
        else
        {
            AbillitiesBlocker.alpha = 0;
            AbillitiesBlocker.interactable = false;
            AbillitiesBlocker.blocksRaycasts = false;
        }
    }
    public void ToggleDisciplines(bool a)
    {
        if (a == true)
        {
            DisciplineBlocker.alpha = 1;
            DisciplineBlocker.interactable = true;
            DisciplineBlocker.blocksRaycasts = true;
        }
        else
        {
            DisciplineBlocker.alpha = 0;
            DisciplineBlocker.interactable = false;
            DisciplineBlocker.blocksRaycasts = false;
        }
    }
    public void ToggleBackground(bool a)
    {
        if (a == true)
        {
            BackgroundBlocker.alpha = 1;
            BackgroundBlocker.interactable = true;
            BackgroundBlocker.blocksRaycasts = true;
        }
        else
        {
            BackgroundBlocker.alpha = 0;
            BackgroundBlocker.interactable = false;
            BackgroundBlocker.blocksRaycasts = false;
        }
    }
    public void ToggleVirtues(bool a)
    {
        if (a == true)
        {
            VirtueBlocker.alpha = 1;
            VirtueBlocker.interactable = true;
            VirtueBlocker.blocksRaycasts = true;
        }
        else
        {
            VirtueBlocker.alpha = 0;
            VirtueBlocker.interactable = false;
            VirtueBlocker.blocksRaycasts = false;
        }
    }
    public void ToggleHumanity(bool a)
    {
        if (a == true)
        {
            HumanityBlocker.alpha = 1;
            HumanityBlocker.interactable = true;
            HumanityBlocker.blocksRaycasts = true;
        }
        else
        {
            HumanityBlocker.alpha = 0;
            HumanityBlocker.interactable = false;
            HumanityBlocker.blocksRaycasts = false;
        }
    }
    public void ToggleHealth(bool a)
    {
        if (a == true)
        {
            HealthBlocker.alpha = 1;
            HealthBlocker.interactable = true;
            HealthBlocker.blocksRaycasts = true;
        }
        else
        {
            HealthBlocker.alpha = 0;
            HealthBlocker.interactable = false;
            HealthBlocker.blocksRaycasts = false;
        }
    }
    public void ToggleOtherStats(bool a)
    {
        if (a == true)
        {
            OtherTraitBlocker.alpha = 1;
            OtherTraitBlocker.interactable = true;
            OtherTraitBlocker.blocksRaycasts = true;
        }
        else
        {
            OtherTraitBlocker.alpha = 0;
            OtherTraitBlocker.interactable = false;
            OtherTraitBlocker.blocksRaycasts = false;
        }
    }

    public void ResetNewCharacter()
    {
        DetailsFilled = false;
        AttributesFull = false;
        AbilitiesFull = false;
        DisciplinesFull = false;
        BackgroundsFull = false;
        VirtuesFull = false;
        trigger = false;
        trigger2 = false;
        trigger3 = false;
        trigger4 = false;
        trigger5 = false;
        trigger6 = false;
        ThisCharacter = new Character();
        foreach (GameObject a in CharacterDetails)
        {
            if (a.GetComponent<StatHolderScript>().StatType == StatHolderScript.MyEnum.DetailInput)
            {
                a.GetComponent<StatHolderScript>().UserInput.text = "";
                a.GetComponent<StatHolderScript>().StringValue = "";
                a.GetComponent<StatHolderScript>().UpdateValues();
            }
            else if (a.GetComponent<StatHolderScript>().StatType == StatHolderScript.MyEnum.DetailDropDown)
            {
                a.GetComponent<StatHolderScript>().DropDown.value = 0;
                a.GetComponent<StatHolderScript>().DropValue = 0;
                a.GetComponent<StatHolderScript>().DisplayValue2 = 0;
                a.GetComponent<StatHolderScript>().UpdateValues();
            }
        }

        foreach (GameObject a in PhysicalStats)
        {
            a.GetComponent<StatHolderScript>().DisplayValue = 1;
            a.GetComponent<StatHolderScript>().UpdateValues();
        }
        foreach (GameObject a in SocialStats)
        {
            a.GetComponent<StatHolderScript>().DisplayValue = 1;
            a.GetComponent<StatHolderScript>().UpdateValues();
        }
        foreach (GameObject a in MentalStats)
        {
            a.GetComponent<StatHolderScript>().DisplayValue = 1;
            a.GetComponent<StatHolderScript>().UpdateValues();
        }
        foreach (GameObject a in TalentStats)
        {
            a.GetComponent<StatHolderScript>().DisplayValue = 0;
            a.GetComponent<StatHolderScript>().UpdateValues();
        }
        foreach (GameObject a in SkillStats)
        {
            a.GetComponent<StatHolderScript>().DisplayValue = 0;
            a.GetComponent<StatHolderScript>().UpdateValues();
        }
        foreach (GameObject a in KnowledgeStats)
        {
            a.GetComponent<StatHolderScript>().DisplayValue = 0;
            a.GetComponent<StatHolderScript>().UpdateValues();
        }
        foreach (GameObject a in DisciplineStats)
        {
            a.GetComponent<StatHolderScript>().DropDown.value = 0;
            a.GetComponent<StatHolderScript>().DropValue = 0;
            a.GetComponent<StatHolderScript>().DisplayValue = 0;
            a.GetComponent<StatHolderScript>().UpdateValues();
        }
        foreach (GameObject a in BackgroundStats)
        {
            a.GetComponent<StatHolderScript>().DropDown.value = 0;
            a.GetComponent<StatHolderScript>().DropValue = 0;
            a.GetComponent<StatHolderScript>().DisplayValue = 0;
            a.GetComponent<StatHolderScript>().UpdateValues();
        }
        foreach (GameObject a in VirtueStats)
        {
            a.GetComponent<StatHolderScript>().DisplayValue = 0;
            a.GetComponent<StatHolderScript>().UpdateValues();
        }
        foreach (GameObject a in OtherTraitStats)
        {
            a.GetComponent<StatHolderScript>().DropDown.value = 0;
            a.GetComponent<StatHolderScript>().DropValue = 0;
            a.GetComponent<StatHolderScript>().DisplayValue = 0;
            a.GetComponent<StatHolderScript>().UpdateValues();
        }
        HumanityStats.GetComponent<StatHolderScript>().DisplayValue = 0;
        HumanityStats.GetComponent<StatHolderScript>().DisplayValue2 = 0;
        HumanityStats.GetComponent<StatHolderScript>().DropDown.value = 0;
        HumanityStats.GetComponent<StatHolderScript>().UpdateValues();
        WillpowerStats.GetComponent<StatHolderScript>().DisplayValue = 0;
        WillpowerStats.GetComponent<StatHolderScript>().DisplayValue2 = 0;
        WillpowerStats.GetComponent<StatHolderScript>().UpdateValues();
        BloodpoolStats.GetComponent<StatHolderScript>().DisplayValue = 0;
        BloodpoolStats.GetComponent<StatHolderScript>().UpdateValues();
        DetailsFilled = false;
        AttributesFull = false;
        AbilitiesFull = false;
        DisciplinesFull = false;
        BackgroundsFull = false;
        VirtuesFull = false;
        trigger = false;
        trigger2 = false;
        trigger3 = false;
        trigger4 = false;
        trigger5 = false;
        trigger6 = false;
        AttStatOrder[0] = StatHolderScript.MyEnum.NULL;
        AttStatOrder[1] = StatHolderScript.MyEnum.NULL;
        AttStatOrder[2] = StatHolderScript.MyEnum.NULL;
        AbilitiesOrder[0] = StatHolderScript.MyEnum.NULL;
        AbilitiesOrder[1] = StatHolderScript.MyEnum.NULL;
        AbilitiesOrder[2] = StatHolderScript.MyEnum.NULL;
        PrimaryAttributesPoints = 7;
        SecondaryAttributesPoints = 5;
        TeritaryAttributesPoints = 3;
        PrimaryAbilitiesPoints = 13;
        SecondaryAbilitiesPoints = 9;
        TeritaryAbilitiesPoints = 5;
        Names.RemoveRange(0, Names.Count);
        foreach (Character a in XMLObject.GetComponent<XMLSerializerScript>().MyCharacters.CharacterList)
        {
            Names.Add(a.Name);
        }
        ToggleAttributes(true);
        ToggleAbilities(true);
        ToggleDisciplines(true);
        ToggleBackground(true);
        ToggleVirtues(true);
    }
}