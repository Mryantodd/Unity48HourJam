/// The following script is fairly complex. The main purpose of this object is do define a single stat into an object.
/// It therefor handles all user interaction and updates the displayed data as changes occur/ or data is loaded.
/// Each Holder is declared on the character view in the inspector. Though each one is dynamicly created by cycling through the 
/// base list of available stats/attributes/skill categories.
/// As such this script defines the object and creates its subcomponent dots/squares at run time depending on its stat type. 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class StatHolderScript : MonoBehaviour, IPointerClickHandler
{
    // Enum for use in declaring a type for each stat category.
    public enum MyEnum { NULL, DetailInput, DetailDropDown, Physical, Social, Mental, Talents, Skills, Knowledges, Discipline, Background, Virtue, OtherTraits, Humanity, Willpower, BloodPool, Health, Experiance };
    /// The set type value for each stat component using the above enum.
    public MyEnum StatType;
    /// 
    public string StatName;
    public List<GameObject> MyDots = new List<GameObject>();
    public List<GameObject> MySquares = new List<GameObject>();
    public int DisplayValue = 0; // for use displaying dots available/spent
    public int DisplayValue2 = 0; // for use displaying dots available/spent
    public int DropValue = 0; // for use with tracking drop down selection in case not a dot object
    public int DotCount = 5; // used for -- loop while creating dots.
    public bool StateTrue = false; // bool for use in sanity check
    public int SquareCount = 0; // used for ++ loop while creating squares.
    public TMP_InputField UserInput; // used for display and user input when setting dot points.
    public string StringValue; // used for catching string data returned by user text field. 
    private Color setColor = Color.black; // quick reference to color value used on dots when points spent.
    private GameObject DotHolder; // ref to child object. That is parent to all dot objects.
    private GameObject SquareHolder; // ref to child object. That is parent to all square objects.
    public TMP_Dropdown DropDown; // ref to the drop down when value is selection based. Such as generation and clan
    public List<string> optionsList;
    
    
    // Each of the defined object types have differing UI elements associated. This whole script could be massively improved with more  
    /// time to convert to OOP classes based on a abstract base class. Something I can improve upon in future versions with more than 48 hours.
    void Awake()
    {
        //Determine if this object is a primary stat through the inspector set type on this holder object.
        if (StatType == MyEnum.Physical | StatType == MyEnum.Social | StatType == MyEnum.Mental | StatType == MyEnum.Talents | StatType == MyEnum.Skills | StatType == MyEnum.Knowledges | StatType == MyEnum.Virtue)
        {
            transform.Find("LabelHolder").gameObject.transform.Find("TMP-StatName").gameObject.GetComponent<TextMeshProUGUI>().text = StatName + ":";
            DotHolder = transform.Find("DotHolder").gameObject;
            for (int i = 0; i < DotCount; i++)
            {
                GameObject dotCreated = Instantiate(Resources.Load("Out-Dot"), this.transform.position, Quaternion.identity) as GameObject;
                dotCreated.transform.SetParent(DotHolder.transform);
                dotCreated.name = "Out-Dot-" + i.ToString();
                MyDots.Add(dotCreated);
            }
        }
        //Determine if this object is a stat but using DropDown UI element for display. set through the inspector as type on this holder object.
        if (StatType == MyEnum.Discipline | StatType == MyEnum.Background | StatType == MyEnum.Humanity)
        {
            DropDown = transform.Find("downHolder").gameObject.transform.Find("Dropdown").GetComponent<TMP_Dropdown>();
            DotHolder = transform.Find("DotHolder").gameObject;
            DropDown.AddOptions(optionsList);
            for (int i = 0; i < DotCount; i++)
            {
                GameObject dotCreated = Instantiate(Resources.Load("Out-Dot"), this.transform.position, Quaternion.identity) as GameObject;
                dotCreated.transform.SetParent(DotHolder.transform);
                dotCreated.name = "Out-Dot-" + i.ToString();
                MyDots.Add(dotCreated);
            }
        }
        //Determine if this object is a other stat but using DropDown UI without dots. set through the inspector as type on this holder object.
        if(StatType == MyEnum.OtherTraits)
        {
            DropDown = transform.Find("downHolder").gameObject.transform.Find("Dropdown").GetComponent<TMP_Dropdown>();
            DropDown.AddOptions(optionsList);
        }
        // Determine if this object is willpower which uses dots and squares for display
        if (StatType == MyEnum.Willpower)
        {
            DotHolder = transform.Find("DotHolder").gameObject;
            SquareHolder = transform.Find("SquareHolder").gameObject;
            for (int i = 0; i < DotCount; i++)
            {
                GameObject dotCreated = Instantiate(Resources.Load("Out-Dot"), this.transform.position, Quaternion.identity) as GameObject;
                dotCreated.transform.SetParent(DotHolder.transform);
                dotCreated.name = "Out-Dot-" + i.ToString();
                MyDots.Add(dotCreated);
            }
            for (int i = 0; i < SquareCount; i++)
            {
                GameObject SquareCreated = Instantiate(Resources.Load("Out-Square"), this.transform.position, Quaternion.identity) as GameObject;
                SquareCreated.transform.SetParent(SquareHolder.transform);
                SquareCreated.name = "Out-Square-" + i.ToString();
                MySquares.Add(SquareCreated);
            }

        }
        // Determine if this object is the blood pool which uses only squares.
        if (StatType == MyEnum.BloodPool)
        {
            SquareHolder = transform.Find("SquareHolder").gameObject;
            for (int i = 0; i < SquareCount; i++)
            {
                GameObject SquareCreated = Instantiate(Resources.Load("Out-Square"), this.transform.position, Quaternion.identity) as GameObject;
                SquareCreated.transform.SetParent(SquareHolder.transform);
                SquareCreated.name = "Out-Square-" + i.ToString();
                MySquares.Add(SquareCreated);
            }
        }
        // Determine if this object is the health pool. Which also uses only squares but has less than bloodpool
        if (StatType == MyEnum.Health)
        {
            transform.Find("LabelHolder").gameObject.transform.Find("TMP-StatName").gameObject.GetComponent<TextMeshProUGUI>().text = StatName + ":";
            SquareHolder = transform.Find("SquareHolder").gameObject;
            for (int i = 0; i < SquareCount; i++)
            {
                GameObject SquareCreated = Instantiate(Resources.Load("Out-Square"), this.transform.position, Quaternion.identity) as GameObject;
                SquareCreated.transform.SetParent(SquareHolder.transform);
                SquareCreated.name = "Out-Square-" + i.ToString();
                MySquares.Add(SquareCreated);
            }
        }
        
        if (StatType == MyEnum.DetailInput)
        {
            transform.Find("LabelHolder").gameObject.transform.Find("TMP-StatName").GetComponent<TextMeshProUGUI>().text = StatName + ":";
            // Debug.Log(StatName);
            UserInput = transform.Find("InputFieldHolder").gameObject.transform.Find("TMPIF").GetComponent<TMP_InputField>();
        }
        if (StatType == MyEnum.DetailDropDown)
        {
            transform.Find("LabelHolder").gameObject.transform.Find("TMP-StatName").GetComponent<TextMeshProUGUI>().text = StatName + ":";
            DropDown = transform.Find("DropDownHolder").gameObject.transform.Find("TMPDD").GetComponent<TMP_Dropdown>();
            DropDown.AddOptions(optionsList);

        }
        //DisplayValue = Random.Range(0, 20);
        //DisplayValue2 = Random.Range(0, 20);
        //DropValue = Random.Range(1, 5);
        UpdateValues();

    }
    public void UpdateValues()
    {
        foreach (GameObject a in MyDots)
        {
            a.GetComponent<DotScript>().InDot.color = Color.white;
        }
        foreach (GameObject b in MySquares)
        {
            b.GetComponent<DotScript>().InDot.color = Color.white;
        }
        if (StatType == MyEnum.Physical | StatType == MyEnum.Social | StatType == MyEnum.Mental | StatType == MyEnum.Talents | StatType == MyEnum.Skills | StatType == MyEnum.Knowledges | StatType == MyEnum.Virtue)
        {
            int z = 0;
            setColor = Color.black;
            for (int t = 0; t < DisplayValue; t++)
            {
                MyDots[z].GetComponent<DotScript>().InDot.color = setColor;
                z++;
                // Debug.Log("run count " + t.ToString()); 
                if (z == MyDots.Count)
                {
                    // Debug.Log("statswitch");
                    z = 0;
                    setColor = Color.red;
                }
            }
        }
        if (StatType == MyEnum.Discipline | StatType == MyEnum.Background | StatType == MyEnum.Humanity | StatType == MyEnum.OtherTraits)
        {
            int z = 0;
            setColor = Color.black;
            for (int t = 0; t < DisplayValue; t++)
            {
                MyDots[z].GetComponent<DotScript>().InDot.color = setColor;
                z++;
                // Debug.Log("run count " + t.ToString()); 
                if (z == MyDots.Count)
                {
                    // Debug.Log("dropswitch");
                    z = 0;
                    setColor = Color.red;
                }
            }
            DropDown.value = DropValue;
        }
        if (StatType == MyEnum.Willpower)
        {
            setColor = Color.black;
            int z = 0;

            for (int t = 0; t < DisplayValue; t++)
            {
                MyDots[z].GetComponent<DotScript>().InDot.color = setColor;
                z++;
                // Debug.Log("run count " + t.ToString()); 
                if (z == MyDots.Count)
                {
                    //  Debug.Log("Willswitch");
                    z = 0;
                    setColor = Color.red;
                }
            }
            int zy = 0;
            setColor = Color.black;
            for (int t = 0; t < DisplayValue2; t++)
            {
                MySquares[zy].GetComponent<DotScript>().InDot.color = setColor;
                zy++;
                // Debug.Log("run count " + t.ToString()); 
                if (zy == MySquares.Count)
                {
                    // Debug.Log("Willswitch2");
                    zy = 0;
                    setColor = Color.red;
                }
            }
        }
        if (StatType == MyEnum.BloodPool)
        {
            int zy = 0;
            setColor = Color.black;
            for (int t = 0; t < DisplayValue; t++)
            {
                MySquares[zy].GetComponent<DotScript>().InDot.color = setColor;
                zy++;
                // Debug.Log("run count " + t.ToString()); 
                if (zy == MyDots.Count)
                {
                    //s Debug.Log("bloodswitch");
                    zy = 0;
                    setColor = Color.red;
                }
            }
        }
        if (StatType == MyEnum.Health)
        {
            if (StateTrue)
            {
                MySquares[0].GetComponent<DotScript>().InDot.color = Color.black;
            }
            else
            {
                MySquares[0].GetComponent<DotScript>().InDot.color = Color.white;
            }

        }
        if (StatType == MyEnum.DetailDropDown)
        {
            DropDown.value = DisplayValue2;
        }
        if (StatType == MyEnum.DetailInput)
        {
            UserInput.text = StringValue;
        }
    }
    private void Update()
    {
        if (StatType == MyEnum.DetailInput)
        {
            StringValue = UserInput.text;
        }
        if (StatType == MyEnum.DetailDropDown)
        {
            DropValue = DropDown.value;
            DisplayValue2 = DropValue;
        }
        if (StatType == MyEnum.Discipline | StatType == MyEnum.Background | StatType == MyEnum.Humanity | StatType == MyEnum.OtherTraits)
        {
            DropValue = DropDown.value;
            DisplayValue2 = DropValue;

        }
    }
    public void SetDisplayValue(int a)
    {
        DisplayValue = a;
        UpdateValues();
    }
    public void SetDisplayValue2(int a)
    {
        DisplayValue2 = a;
        UpdateValues();
    }
    public void SetDropValue(int a)
    {
        DropValue = a;
        UpdateValues();
    }
    public void SetState(bool a)
    {
        StateTrue = a;
        UpdateValues();
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if(pointerEventData.button == PointerEventData.InputButton.Left)
        {
            if (StatType == MyEnum.Physical | StatType == MyEnum.Mental | StatType == MyEnum.Social)
            {
                gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.GetComponent<CharacterSheetScript>().IncreaseAttributeStat(this);
            }else if( StatType == MyEnum.Talents | StatType == MyEnum.Skills | StatType == MyEnum.Knowledges)
            {
                gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.GetComponent<CharacterSheetScript>().IncreaseAbilitiesStat(this);
            }else if(StatType == MyEnum.Discipline)
            {
                gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.GetComponent<CharacterSheetScript>().IncreaseDisciplineStat(this);
            }
            else if (StatType == MyEnum.Background)
            {
                gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.GetComponent<CharacterSheetScript>().IncreaseBackgroundStat(this);
            }
            else if (StatType == MyEnum.Virtue)
            {
                gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.GetComponent<CharacterSheetScript>().IncreaseVirtueStat(this);
            }
        }
        if (pointerEventData.button == PointerEventData.InputButton.Right)
        {
            if (StatType == MyEnum.Physical | StatType == MyEnum.Mental | StatType == MyEnum.Social)
            {
                gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.GetComponent<CharacterSheetScript>().DecreaseAttributeStat(this);
            }
            else if (StatType == MyEnum.Talents | StatType == MyEnum.Skills | StatType == MyEnum.Knowledges)
            {
                gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.GetComponent<CharacterSheetScript>().DecreaseAbilitiesStat(this);
            }
            else if (StatType == MyEnum.Discipline)
            {
                gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.GetComponent<CharacterSheetScript>().DecreaseDisciplineStat(this);
            }
            else if (StatType == MyEnum.Background)
            {
                gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.GetComponent<CharacterSheetScript>().DecreaseBackgroundStat(this);
            }
            else if (StatType == MyEnum.Virtue)
            {
                gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.GetComponent<CharacterSheetScript>().DecreaseVirtueStat(this);
            }
        }

    }

}
