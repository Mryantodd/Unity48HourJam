using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using TMPro;
using System.Text;

public class Archetype
{
    [XmlAttribute("name")]
    public string Name;
    [XmlElement("Description")]
    public string Description;

}
[XmlRoot("ArchetypeList")]
public class ArchetypesContainer
{
    [XmlArray("Archetypes")]
    [XmlArrayItem("Archetype")]
    public List<Archetype> ArchetypeList = new List<Archetype>();

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(CharacterContainer));
        var encoding = Encoding.GetEncoding("UTF-8");
        using (StreamWriter streamme = new StreamWriter(path, false, encoding))
        {
            serializer.Serialize(streamme, this);
        }
    }

    public static ArchetypesContainer Load(string path)
    {
        var serializer = new XmlSerializer(typeof(ArchetypesContainer));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as ArchetypesContainer;
        }
    }
    //Loads the xml directly from the given string. Useful in combination with www.text.
    public static ArchetypesContainer LoadFromText(string text)
    {
        var serializer = new XmlSerializer(typeof(ArchetypesContainer));
        return serializer.Deserialize(new StringReader(text)) as ArchetypesContainer;
    }
}

public class Background
{
    [XmlAttribute("name")]
    public string Name;
    [XmlElement("Description")]
    public string Description;
}
[XmlRoot("BackgroundList")]
public class BackgroundContainer
{
    [XmlArray("Backgrounds")]
    [XmlArrayItem("Background")]
    public List<Background> BackgroundList = new List<Background>();

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(BackgroundContainer));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }

    public static BackgroundContainer Load(string path)
    {
        var serializer = new XmlSerializer(typeof(BackgroundContainer));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as BackgroundContainer;
        }
    }
    //Loads the xml directly from the given string. Useful in combination with www.text.
    public static BackgroundContainer LoadFromText(string text)
    {
        var serializer = new XmlSerializer(typeof(BackgroundContainer));
        return serializer.Deserialize(new StringReader(text)) as BackgroundContainer;
    }
}

public class Clan
{
    [XmlAttribute("name")]
    public string Name;
    [XmlElement("Description")]
    public string Description;
    [XmlElement("StarterDiscipline0")]
    public int StarterDiscipline0;
    [XmlElement("StarterDiscipline1")]
    public int StarterDiscipline1;
    [XmlElement("StarterDiscipline2")]
    public int StarterDiscipline2;

}
[XmlRoot("ClanList")]
public class ClanContainer
{
    [XmlArray("Clans")]
    [XmlArrayItem("Clan")]
    public List<Clan> ClanList = new List<Clan>();

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(CharacterContainer));
        var encoding = Encoding.GetEncoding("UTF-8");
        using (StreamWriter streamme = new StreamWriter(path, false, encoding))
        {
            serializer.Serialize(streamme, this);
        }
    }

    public static ClanContainer Load(string path)
    {
        var serializer = new XmlSerializer(typeof(ClanContainer));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as ClanContainer;
        }
    }
    //Loads the xml directly from the given string. Useful in combination with www.text.
    public static ClanContainer LoadFromText(string text)
    {
        var serializer = new XmlSerializer(typeof(ClanContainer));
        return serializer.Deserialize(new StringReader(text)) as ClanContainer;
    }
}

public class Concept
{
    [XmlAttribute("name")]
    public string Name;
    [XmlElement("Description")]
    public string Description;


}
[XmlRoot("ConceptList")]
public class ConceptContainer
{
    [XmlArray("Concepts")]
    [XmlArrayItem("Concept")]
    public List<Concept> ConceptList = new List<Concept>();

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(CharacterContainer));
        var encoding = Encoding.GetEncoding("UTF-8");
        using (StreamWriter streamme = new StreamWriter(path, false, encoding))
        {
            serializer.Serialize(streamme, this);
        }
    }

    public static ConceptContainer Load(string path)
    {
        var serializer = new XmlSerializer(typeof(ConceptContainer));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as ConceptContainer;
        }
    }
    //Loads the xml directly from the given string. Useful in combination with www.text.
    public static ConceptContainer LoadFromText(string text)
    {
        var serializer = new XmlSerializer(typeof(ConceptContainer));
        return serializer.Deserialize(new StringReader(text)) as ConceptContainer;
    }
}

public class Discipline
{
    [XmlAttribute("name")]
    public string Name;
    [XmlElement("Description")]
    public string Description;

}
[XmlRoot("DisciplineList")]
public class DisciplineContainer
{
    [XmlArray("Disciplines")]
    [XmlArrayItem("Discipline")]
    public List<Discipline> DisciplineList = new List<Discipline>();

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(CharacterContainer));
        var encoding = Encoding.GetEncoding("UTF-8");
        using (StreamWriter streamme = new StreamWriter(path, false, encoding))
        {
            serializer.Serialize(streamme, this);
        }
    }

    public static DisciplineContainer Load(string path)
    {
        var serializer = new XmlSerializer(typeof(DisciplineContainer));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as DisciplineContainer;
        }
    }
    //Loads the xml directly from the given string. Useful in combination with www.text.
    public static DisciplineContainer LoadFromText(string text)
    {
        var serializer = new XmlSerializer(typeof(DisciplineContainer));
        return serializer.Deserialize(new StringReader(text)) as DisciplineContainer;
    }
}

public class Path
{
    [XmlAttribute("name")]
    public string Name;
    [XmlElement("Description")]
    public string Description;


}
[XmlRoot("PathList")]
public class PathsContainer
{
    [XmlArray("Paths")]
    [XmlArrayItem("path")]
    public List<Path> PathList = new List<Path>();

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(CharacterContainer));
        var encoding = Encoding.GetEncoding("UTF-8");
        using (StreamWriter streamme = new StreamWriter(path, false, encoding))
        {
            serializer.Serialize(streamme, this);
        }
    }

    public static PathsContainer Load(string path)
    {
        var serializer = new XmlSerializer(typeof(PathsContainer));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as PathsContainer;
        }
    }
    //Loads the xml directly from the given string. Useful in combination with www.text.
    public static PathsContainer LoadFromText(string text)
    {
        var serializer = new XmlSerializer(typeof(PathsContainer));
        return serializer.Deserialize(new StringReader(text)) as PathsContainer;
    }
}

public class MeritFlaw
{
    [XmlAttribute("category")]
    public string category;
    [XmlElement("title")]
    public string Title;
    [XmlElement("cost")]
    public int Cost;
    [XmlElement("description")]
    public string Description;
}
[XmlRoot("MeritsFlawsList")]
public class MeritFlawContainer
{
    [XmlArray("MeritsFlaws")]
    [XmlArrayItem("MeritFlaw")]
    public List<MeritFlaw> MeritFlawList = new List<MeritFlaw>();

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(CharacterContainer));
        var encoding = Encoding.GetEncoding("UTF-8");
        using (StreamWriter streamme = new StreamWriter(path, false, encoding))
        {
            serializer.Serialize(streamme, this);
        }
    }

    public static MeritFlawContainer Load(string path)
    {
        var serializer = new XmlSerializer(typeof(MeritFlawContainer));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as MeritFlawContainer;
        }
    }
    //Loads the xml directly from the given string. Useful in combination with www.text.
    public static MeritFlawContainer LoadFromText(string text)
    {
        var serializer = new XmlSerializer(typeof(MeritFlawContainer));
        return serializer.Deserialize(new StringReader(text)) as MeritFlawContainer;
    }
}

public class Stat
{
    [XmlAttribute("category")]
    public string category;
    [XmlElement("Name")]
    public string Name;
}
[XmlRoot("StatPool")]
public class StatContainer
{
    [XmlArray("Stats")]
    [XmlArrayItem("Stat")]
    public List<Stat> StatList = new List<Stat>();

    public void Save(string stat)
    {
        var serializer = new XmlSerializer(typeof(CharacterContainer));
        var encoding = Encoding.GetEncoding("UTF-8");
        using (StreamWriter streamme = new StreamWriter(stat, false, encoding))
        {
            serializer.Serialize(streamme, this);
        }
    }

    public static StatContainer Load(string stat)
    {
        var serializer = new XmlSerializer(typeof(StatContainer));
        using (var stream = new FileStream(stat, FileMode.Open))
        {
            return serializer.Deserialize(stream) as StatContainer;
        }
    }
    //Loads the xml directly from the given string. Useful in combination with www.text.
    public static StatContainer LoadFromText(string text)
    {
        var serializer = new XmlSerializer(typeof(StatContainer));
        return serializer.Deserialize(new StringReader(text)) as StatContainer;
    }
}

public class Character
{
    [XmlAttribute("name")]
    public string Name;
    [XmlElement("Player")]
    public string Player;
    [XmlElement("Chronicle")]
    public string Chronicle;
    [XmlElement("Nature")]
    public int Nature;
    [XmlElement("Demeanor")]
    public int Demeanor;
    [XmlElement("Concept")]
    public int Concept;
    [XmlElement("Clan")]
    public int Clan;
    [XmlElement("Generation")]
    public int Generation;
    [XmlElement("Haven")]
    public string Haven;
    [XmlElement("Strength")]
    public int Strength;
    [XmlElement("Dexterity")]
    public int Dexterity;
    [XmlElement("Stamina")]
    public int Stamina;
    [XmlElement("Charisma")]
    public int Charisma;
    [XmlElement("Manipulation")]
    public int Manipulation;
    [XmlElement("Appearance")]
    public int Appearance;
    [XmlElement("Perception")]
    public int Perception;
    [XmlElement("Intelligence")]
    public int Intelligence;
    [XmlElement("Wits")]
    public int Wits;
    [XmlElement("Alertness")]
    public int Alertness;
    [XmlElement("Athletics")]
    public int Athletics;
    [XmlElement("Dodge")]
    public int Dodge;
    [XmlElement("Brawl")]
    public int Brawl;
    [XmlElement("Empathy")]
    public int Empathy;
    [XmlElement("Expression")]
    public int Expression;
    [XmlElement("Intimidation")]
    public int Intimidation;
    [XmlElement("Leadership")]
    public int Leadership;
    [XmlElement("Streetwise")]
    public int Streetwise;
    [XmlElement("Subterfuge")]
    public int Subterfuge;
    [XmlElement("AnimalKen")]
    public int AnimalKen;
    [XmlElement("Crafts")]
    public int Crafts;
    [XmlElement("Drive")]
    public int Drive;
    [XmlElement("Etiquette")]
    public int Etiquette;
    [XmlElement("FireArms")]
    public int FireArms;
    [XmlElement("Melee")]
    public int Melee;
    [XmlElement("Performance")]
    public int Performance;
    [XmlElement("Security")]
    public int Security;
    [XmlElement("Stealth")]
    public int Stealth;
    [XmlElement("Survival")]
    public int Survival;
    [XmlElement("Academics")]
    public int Academics;
    [XmlElement("Computer")]
    public int Computer;
    [XmlElement("Finance")]
    public int Finance;
    [XmlElement("Investigation")]
    public int Investigation;
    [XmlElement("Law")]
    public int Law;
    [XmlElement("Linguistics")]
    public int Linguistics;
    [XmlElement("Medicine")]
    public int Medicine;
    [XmlElement("Occult")]
    public int Occult;
    [XmlElement("Politics")]
    public int Politics;
    [XmlElement("Science")]
    public int Science;
    [XmlElement("Discipline0Name")]
    public int Discipline0Name;
    [XmlElement("Discipline0Value")]
    public int Discipline0Value;
    [XmlElement("Discipline1Name")]
    public int Discipline1Name;
    [XmlElement("Discipline1Value")]
    public int Discipline1Value;
    [XmlElement("Discipline2Name")]
    public int Discipline2Name;
    [XmlElement("Discipline2Value")]
    public int Discipline2Value;
    [XmlElement("Discipline3Name")]
    public int Discipline3Name;
    [XmlElement("Discipline3Value")]
    public int Discipline3Value;
    [XmlElement("Discipline4Name")]
    public int Discipline4Name;
    [XmlElement("Discipline4Value")]
    public int Discipline4Value;
    [XmlElement("Discipline5Name")]
    public int Discipline5Name;
    [XmlElement("Discipline5Value")]
    public int Discipline5Value;
    [XmlElement("Background0Name")]
    public int Background0Name;
    [XmlElement("Background0Value")]
    public int Background0Value;
    [XmlElement("Background1Name")]
    public int Background1Name;
    [XmlElement("Background1Value")]
    public int Background1Value;
    [XmlElement("Background2Name")]
    public int Background2Name;
    [XmlElement("Background2Value")]
    public int Background2Value;
    [XmlElement("Background3Name")]
    public int Background3Name;
    [XmlElement("Background3Value")]
    public int Background3Value;
    [XmlElement("Background4Name")]
    public int Background4Name;
    [XmlElement("Background4Value")]
    public int Background4Value;
    [XmlElement("Background5Name")]
    public int Background5Name;
    [XmlElement("Background5Value")]
    public int Background5Value;
    [XmlElement("MaxConCov")]
    public int MaxConCov;
    [XmlElement("CurConCov")]
    public int CurConCov;
    [XmlElement("MaxSelfControl")]
    public int MaxSelfControl;
    [XmlElement("CurSelfControl")]
    public int CurSelfControl;
    [XmlElement("MaxCourage")]
    public int MaxCourage;
    [XmlElement("CurCourage")]
    public int CurCourage;
    [XmlElement("OtherTrait0Name")]
    public int OtherTrait0Name;
    [XmlElement("OtherTrait0Value")]
    public int OtherTrait0Value;
    [XmlElement("OtherTrait1Name")]
    public int OtherTrait1Name;
    [XmlElement("OtherTrait1Value")]
    public int OtherTrait1Value;
    [XmlElement("OtherTrait2Name")]
    public int OtherTrait2Name;
    [XmlElement("OtherTrait2Value")]
    public int OtherTrait2Value;
    [XmlElement("OtherTrait3Name")]
    public int OtherTrait3Name;
    [XmlElement("OtherTrait3Value")]
    public int OtherTrait3Value;
    [XmlElement("OtherTrait4Name")]
    public int OtherTrait4Name;
    [XmlElement("OtherTrait4Value")]
    public int OtherTrait4Value;
    [XmlElement("OtherTrait5Name")]
    public int OtherTrait5Name;
    [XmlElement("OtherTrait5Value")]
    public int OtherTrait5Value;
    [XmlElement("OtherTrait6Name")]
    public int OtherTrait6Name;
    [XmlElement("OtherTrait6Value")]
    public int OtherTrait6Value;
    [XmlElement("OtherTrait7Name")]
    public int OtherTrait7Name;
    [XmlElement("OtherTrait7Value")]
    public int OtherTrait7Value;
    [XmlElement("OtherTrait8Name")]
    public int OtherTrait8Name;
    [XmlElement("OtherTrait8Value")]
    public int OtherTrait8Value;
    [XmlElement("OtherTrait9Name")]
    public int OtherTrait9Name;
    [XmlElement("OtherTrait9Value")]
    public int OtherTrait9Value;
    [XmlElement("HumanityPathName")]
    public int HumanityPathName;
    [XmlElement("HumanityPathValue")]
    public int HumanityPathValue;
    [XmlElement("WillpowerDotsMaxValue")]
    public int WillpowerDotsMaxValue;
    [XmlElement("WillpowerDotsCurValue")]
    public int WillpowerDotsCurValue;
    [XmlElement("WillpowerMaxSquaresValue")]
    public int WillpowerMaxSquaresValue;
    [XmlElement("WillpowerCurSquaresValue")]
    public int WillpowerCurSquaresValue;
    [XmlElement("BloodPoolMax")]
    public int BloodPoolMax;
    [XmlElement("BloodPoolCur")]
    public int BloodPoolCur;
    [XmlElement("bruised")]
    public bool bruised;
    [XmlElement("hurt")]
    public bool hurt;
    [XmlElement("Injured")]
    public bool Injured;
    [XmlElement("Wounded")]
    public bool Wounded;
    [XmlElement("Mauled")]
    public bool Mauled;
    [XmlElement("Crippled")]
    public bool Crippled;
    [XmlElement("Incapacitated")]
    public bool Incapacitated;
    [XmlElement("Weakness")]
    public string Weakness;
    [XmlElement("Experiance")]
    public string Experiance;

   public Character()
    {
        Name = "";
        Player = "";
        Chronicle = "";
        Nature = 0;
        Demeanor = 0;
        Clan = 0;
        Generation = 0;
        Haven = "";
        Concept = 0;
        Strength = 0;
        Dexterity =0;
        Stamina = 0;
        Charisma = 0;
        Manipulation = 0;
        Appearance = 0;
        Perception = 0;
        Intelligence = 0;
        Wits = 0;
        Alertness = 0;
        Athletics = 0;
        Brawl = 0;
        Dodge = 0;
        Empathy = 0;
        Expression = 0;
        Intimidation = 0;
        Leadership = 0;
        Streetwise = 0;
        Subterfuge = 0;
        AnimalKen = 0;
        Crafts = 0;
        Drive = 0;
        Etiquette = 0;
        FireArms = 0;
        Melee = 0;
        Performance = 0;
        Security = 0;
        Stealth = 0;
        Survival = 0;
        Academics = 0;
        Computer = 0;
        Finance = 0;
        Investigation = 0;
        Law = 0;
        Linguistics = 0;
        Medicine = 0;
        Occult = 0;
        Politics = 0;
        Science = 0;
        Discipline0Name = 0;
        Discipline0Value = 0;
        Discipline1Name = 0;
        Discipline1Value = 0;
        Discipline2Name = 0;
        Discipline2Value = 0;
        Discipline3Name = 0;
        Discipline3Value = 0;
        Discipline4Name = 0;
        Discipline4Value = 0;
        Discipline5Name = 0;
        Discipline5Value = 0;
        Background0Name = 0;
        Background0Value = 0;
        Background1Name = 0;
        Background1Value = 0;
        Background2Name = 0;
        Background2Value = 0;
        Background3Name = 0;
        Background3Value = 0;
        Background4Name = 0;
        Background4Value = 0;
        Background5Name = 0;
        Background5Value = 0;
        MaxConCov = 0;
        CurConCov = 0;
        MaxSelfControl = 0;
        CurSelfControl = 0;
        MaxCourage = 0;
        CurCourage = 0;
        OtherTrait0Name = 0;
        OtherTrait0Value = 0;
        OtherTrait1Name = 0;
        OtherTrait1Value = 0;
        OtherTrait2Name = 0;
        OtherTrait2Value = 0;
        OtherTrait3Name = 0;
        OtherTrait3Value = 0;
        OtherTrait4Name = 0;
        OtherTrait4Value = 0;
        OtherTrait5Name = 0;
        OtherTrait5Value = 0;
        OtherTrait6Name = 0;
        OtherTrait6Value = 0;
        OtherTrait7Name = 0;
        OtherTrait7Value = 0;
        OtherTrait8Name = 0;
        OtherTrait8Value = 0;
        OtherTrait9Name = 0;
        OtherTrait9Value = 0;
        HumanityPathName = 0;
        HumanityPathValue = 0;
        WillpowerCurSquaresValue = 0;
        WillpowerMaxSquaresValue = 0;
        WillpowerDotsMaxValue = 0;
        WillpowerDotsCurValue = 0;
        BloodPoolCur = 0;
        BloodPoolMax = 0;
        bruised = false;
        hurt = false;
        Injured = false;
        Wounded = false;
        Mauled = false;
        Crippled = false;
        Incapacitated = false;
        Experiance = "0";
    }
}
[XmlRoot("CharacterPool")]
public class CharacterContainer
{
    [XmlArray("Characters")]
    [XmlArrayItem("Character")]
    public List<Character> CharacterList = new List<Character>();

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(CharacterContainer));
        var encoding = Encoding.GetEncoding("UTF-8");
        using (StreamWriter streamme = new StreamWriter(path, false, encoding))
        {
            serializer.Serialize(streamme, this);
        }
    }

    public static CharacterContainer Load(string path)
    {
        var serializer = new XmlSerializer(typeof(CharacterContainer));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as CharacterContainer;
        }
    }
    //Loads the xml directly from the given string. Useful in combination with www.text.
    public static CharacterContainer LoadFromText(string text)
    {
        var serializer = new XmlSerializer(typeof(CharacterContainer));
        return serializer.Deserialize(new StringReader(text)) as CharacterContainer;
    }
}

public class XMLSerializerScript : MonoBehaviour
{
    public bool Loaded = false;
    [Header("XML FILES")]
    public TextAsset CharacterXML;
    public TextAsset AchetypeXML;
    public TextAsset BackgroundXML;
    public TextAsset ClanXML;
    public TextAsset ConceptXML;
    public TextAsset DisciplineXML;
    public TextAsset PathXML;
    public TextAsset MeritFlawXML;
    public TextAsset StatsXML;

    private string CharacterXMLPath;
    private string AchetypeXMLPath;
    private string BackgroundXMLPath;
    private string ClanXMLPath;
    private string ConceptXMLPath;
    private string DisciplineXMLPath;
    private string PathXMLPath;
    private string MeritFlawXMLPath;
    private string StatsPath;


    public StatContainer MyStats;
    public ArchetypesContainer MyArchetypes;
    public BackgroundContainer MyBackgrounds;
    public ClanContainer MyClans;
    public ConceptContainer MyConcepts;
    public DisciplineContainer MyDisciplines;
    public PathsContainer MyPaths;
    public CharacterContainer MyCharacters;
    public MeritFlawContainer MyMeritFlaws;



    // Use this for initialization
    void Awake()
    {
        MyCharacters = new CharacterContainer();
        MyPaths = new PathsContainer();
        MyDisciplines = new DisciplineContainer();
        MyConcepts = new ConceptContainer();
        MyClans = new ClanContainer();
        MyBackgrounds = new BackgroundContainer();
        MyArchetypes = new ArchetypesContainer();
        MyMeritFlaws = new MeritFlawContainer();
        MyStats = new StatContainer();

        CharacterXMLPath = Application.dataPath + "/XML/Characters2.xml";
        AchetypeXMLPath = Application.dataPath + "/XML/Archetypes.xml";
        BackgroundXMLPath = Application.dataPath + "/XML/Backgrounds.xml";
        ClanXMLPath = Application.dataPath + "/XML/Clans.xml";
        ConceptXMLPath = Application.dataPath + "/XML/Concepts.xml";
        DisciplineXMLPath = Application.dataPath + "/XML/Disciplines.xml";
        PathXMLPath = Application.dataPath + "/XML/Paths.xml";
        MeritFlawXMLPath = Application.dataPath + "/XML/MeritsFlaws.xml";
        StatsPath = Application.dataPath + "/XML/Stats.xml";


        DirectoryInfo dirInf = new DirectoryInfo(Application.dataPath + "/XML");
        if (!dirInf.Exists)  //Check if directory exists
        {
            dirInf.Create();
        }
        if (!File.Exists(CharacterXMLPath))
        {
            //Debug.Log("No Character XML Data. Creating....");
            File.WriteAllText(CharacterXMLPath, CharacterXML.ToString());
            MyCharacters = CharacterContainer.Load(CharacterXMLPath);
        }
        else
        {
            //Debug.Log("Loading Character Data");
            MyCharacters = CharacterContainer.Load(CharacterXMLPath);
        }

        if (!File.Exists(AchetypeXMLPath))
        {
            //Debug.Log("No Archetype XML Data. Creating....");
            File.WriteAllText(AchetypeXMLPath, AchetypeXML.ToString());
            MyArchetypes = ArchetypesContainer.Load(AchetypeXMLPath);
        }
        else
        {
            //Debug.Log("Loading Archetype Data");
            MyArchetypes = ArchetypesContainer.Load(AchetypeXMLPath);
        }

        if (!File.Exists(BackgroundXMLPath))
        {
            //Debug.Log("No Backgrounds XML Data. Creating....");
            File.WriteAllText(BackgroundXMLPath, BackgroundXML.ToString());
            MyBackgrounds = BackgroundContainer.Load(BackgroundXMLPath);
        }
        else
        {
            //Debug.Log("Loading Background Data");
            MyBackgrounds = BackgroundContainer.Load(BackgroundXMLPath);
        }

        if (!File.Exists(ClanXMLPath))
        {
            //Debug.Log("No Clan XML Data. Creating....");
            File.WriteAllText(ClanXMLPath, ClanXML.ToString());
            MyClans = ClanContainer.Load(ClanXMLPath);
        }
        else
        {
            //Debug.Log("Loading Clan Data");
            MyClans = ClanContainer.Load(ClanXMLPath);
        }

        if (!File.Exists(DisciplineXMLPath))
        {
            //Debug.Log("No Discipline XML Data. Creating....");
            File.WriteAllText(DisciplineXMLPath, DisciplineXML.ToString());
            MyDisciplines = DisciplineContainer.Load(DisciplineXMLPath);
        }
        else
        {
            //Debug.Log("Loading Discipline Data");
            MyDisciplines = DisciplineContainer.Load(DisciplineXMLPath);
        }

        if (!File.Exists(PathXMLPath))
        {
            //Debug.Log("No Paths XML Data. Creating....");
            File.WriteAllText(PathXMLPath, PathXML.ToString());
            MyPaths = PathsContainer.Load(PathXMLPath);
        }
        else
        {
            //Debug.Log("Loading Paths Data");
            MyPaths = PathsContainer.Load(PathXMLPath);
        }

        if (!File.Exists(ConceptXMLPath))
        {
            //Debug.Log("No Concept XML Data. Creating....");
            File.WriteAllText(ConceptXMLPath, ConceptXML.ToString());
            MyConcepts = ConceptContainer.Load(ConceptXMLPath);
        }
        else
        {
            //Debug.Log("Loading Concept Data");
            MyConcepts = ConceptContainer.Load(ConceptXMLPath);
        }

        if (!File.Exists(MeritFlawXMLPath))
        {
            //Debug.Log("No MeritFlaw XML Data. Creating....");
            File.WriteAllText(MeritFlawXMLPath, MeritFlawXML.ToString());
            MyMeritFlaws = MeritFlawContainer.Load(MeritFlawXMLPath);
        }
        else
        {
            //Debug.Log("Loading MeritFlaw Data");
            MyMeritFlaws = MeritFlawContainer.Load(MeritFlawXMLPath);
        }
        if (!File.Exists(StatsPath))
        {
            //Debug.Log("No Stats XML Data. Creating....");
            File.WriteAllText(StatsPath, StatsXML.ToString());
            MyStats = StatContainer.Load(StatsPath);
        }
        else
        {
            //Debug.Log("Loading Stats XML Data");
            MyStats = StatContainer.Load(StatsPath);
        }
        Loaded = true;
    }

    public void SaveCharacter(Character a)
    {

        MyCharacters.CharacterList.Add(a);
        MyCharacters.Save(CharacterXMLPath);


    }
    public void DeleteCharacter(Character a)
    {
        MyCharacters.CharacterList.Remove(a);
        MyCharacters.Save(CharacterXMLPath);
    }

    public List<Clan> UpdateAndReturnClans()
    {
        MyClans = ClanContainer.Load(ClanXMLPath);
        List<Clan> ClanHolder = new List<Clan>();
        foreach(Clan a in MyClans.ClanList)
        {
            ClanHolder.Add(a);           
        }
        return ClanHolder;
    }
}