using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;

public class CreateCharater : MonoBehaviour
{

    public GameObject CreateCharaterPrefab;
    public GameObject EmptyGameObject;
    public OpenMsgBox OpenMsgBoxClone;
    public CharaterList CharaterListClone;
    public PublicFunction PublicFunctionClone;

    public Text Load_StrengthText;
    public Text Load_IntelligenceText;
    public Text Load_DexterityText;
    public Text Load_CharaterName;

    private Store StoreValue;
    private int CheckNum = 0;

    private int[] CharaterArmCreate;
    private int CharaterArmCountCreate;

    private void Awake()
    {
        CreateFunction.Few = 5;
    }

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void CreateCharaterFunction()
    {
        string StoreClone = "Store";

        PublicFunctionClone.ReadPlatformpersistentDataPath(StoreClone);   //找出在persistentDataPath裡面的Store.json檔案路徑

        string ReadFile = System.IO.File.ReadAllText(PublicFunction.persistentFilePath);

        StoreValue = JsonUtility.FromJson<Store>(ReadFile);
        
        for (CheckNum = 0; CheckNum < 5; CheckNum++)
        {
            if (StoreValue.CharaterList[CheckNum] == 0)
            {
                CreateCharaterFile(CheckNum + 1);
                StoreValue.CharaterList[CheckNum] = 1;
                StoreSave();
                SuccessCreate();
                Destroy(CreateCharaterPrefab);              //建立完角色後就應該回到角色列表
                return;
            }

            if (CheckNum == 4)      //因為角色上限只有5隻，必免造成超過角色數量上限的數字錯誤，所以要重製數字
            {
                CheckNum = 0;
            }
        }
    }

    public void CreateCharaterFile(int i)                                                          //創建角色時將創建角色時填入的數值轉成要序列化的數值
    {
        string FileName = "Charater_" + i;

        CharaterProperty Charater = new CharaterProperty();

        int CharaterStrength = Convert.ToInt32(Load_StrengthText.text);          //將創角畫面上玩家輸入的力量數值轉成Json檔裡正確的變數類型
        int CharaterIntelligence = Convert.ToInt32(Load_IntelligenceText.text);
        int CharaterDexterity = Convert.ToInt32(Load_DexterityText.text);
        string CharaterName = Convert.ToString(Load_CharaterName.text);

        Charater.CharaterNumber = i;
        Charater.Charater = "Charater_" + i;
        Charater.CharaterSex = CreateFunction.CharaterSex;
        Charater.CharaterProperty_Strength = CharaterStrength;                   //把創角畫面上玩家輸入的力量數值轉成角色Json檔案裡要儲存的數值
        Charater.CharaterProperty_Intelligence = CharaterIntelligence;           //把創角畫面上玩家輸入的智力數值轉成角色Json檔案裡要儲存的數值
        Charater.CharaterProperty_Dexterity = CharaterDexterity;                 //把創角畫面上玩家輸入的敏捷數值轉成角色Json檔案裡要儲存的數值
        Charater.HeadSprite = "Head_" + SpriteAtlasChange.Head;
        Charater.BodySprite = "Body_" + SpriteAtlasChange.Body;
        Charater.FootSprite = "Foot_" + SpriteAtlasChange.Foot;
        Charater.CharaterLevel = 1;
        Charater.CharaterName = CharaterName;
        Charater.CharaterJobName = "初心者";

        Charater.CharaterPhysicalDamgeMin = 0;
        Charater.CharaterPhysicalDamgeMax = 1;
        Charater.CharaterHp = 10;

        Charater.CharaterMagicDamgeMin = 0;
        Charater.CharaterMagicDamgeMax = 0;
        Charater.CharaterMp = 10;

        Charater.CharaterDodge = 0;
        Charater.CharaterDodgeMax = Charater.CharaterLevel * 10;

        Charater.CharaterCritical = 0;
        Charater.CharaterCriticalMax = Charater.CharaterLevel * 10;

        if (Charater.CharaterProperty_Strength != 0)
        {
            Charater.CharaterPhysicalDamgeMin = 0;
            Charater.CharaterPhysicalDamgeMax = (Charater.CharaterProperty_Strength * 10) + 1;
            Charater.CharaterHp = Charater.CharaterHp + (Charater.CharaterProperty_Strength * 10);
        }

        if (Charater.CharaterProperty_Dexterity != 0)
        {
            Charater.CharaterDodge = Charater.CharaterProperty_Dexterity;
            Charater.CharaterCritical = Charater.CharaterProperty_Dexterity;
            Charater.CharaterDodgeRate = (Charater.CharaterDodge / Charater.CharaterDodgeMax) * 100;
            Charater.CharaterDodgeRate = Mathf.Round(Charater.CharaterDodgeRate);
            Charater.CharaterCriticalRate = (Charater.CharaterCritical / Charater.CharaterCriticalMax) * 100;
            Charater.CharaterCriticalRate = Mathf.Round(Charater.CharaterCriticalRate);
        }

        if (Charater.CharaterProperty_Intelligence != 0)
        {
            Charater.CharaterMagicDamgeMin = Charater.CharaterProperty_Intelligence * 5;
            Charater.CharaterMagicDamgeMax = Charater.CharaterProperty_Intelligence * 10;
            Charater.CharaterMp = Charater.CharaterMp + (Charater.CharaterProperty_Intelligence * 10);
        }

        Charater.CharaterHpRecover = 1.0f;
        Charater.CharaterMpRecover = 1.0f;
        Charater.CharaterPhysicalResist = 0;
        Charater.CharaterPhysicalResistMax = Charater.CharaterLevel * 10;
        Charater.CharaterPhysicalResistRate = (Charater.CharaterPhysicalResist / Charater.CharaterPhysicalResistMax) * 100;
        Charater.CharaterPhysicalResistRate = Mathf.Round(Charater.CharaterPhysicalResistRate);
        Charater.CharaterMagicShield = 0;
        Charater.CharaterMagicShieldRecover = 1.0f;
        Charater.CharaterExp = 10;
        Charater.CharaterHpNow = Charater.CharaterHp;
        Charater.CharaterMpNow = Charater.CharaterMp;

        Charater.CharaterLastPoint = CreateFunction.Few;

        Charater.CharaterHpNowRate = (Charater.CharaterHp / Charater.CharaterHpNow) * 100;
        Charater.CharaterHpNowRate = Mathf.Round(Charater.CharaterHpNowRate);
        Charater.CharaterMpNowRate = (Charater.CharaterMp / Charater.CharaterMpNow) * 100;
        Charater.CharaterMpNowRate = Mathf.Round(Charater.CharaterMpNowRate);
        Charater.CharaterExpNow = 0;
        Charater.CharaterMagicShieldNow = 0;
        Charater.CharaterAttackSpeed = 1.0f;
        Charater.CharaterMoney = 1000;
        Charater.CharaterLastMap = 0;
        //-----

        //-----儲存角色裝備資料
        PublicFunctionClone.CreateCharaterArmFile(i);
        CreateCharaterArmOutfit(i, Charater.HeadSprite, Charater.BodySprite, Charater.FootSprite);
        //-----

        string data = JsonUtility.ToJson(Charater);
        PublicFunctionClone.ReadPlatformpersistentDataPath(FileName);
        File.WriteAllText(PublicFunction.persistentFilePath, data);
        Debug.Log("成功建立Charater_" + i + "的檔案!");
        PublicFunctionClone.ReadCharaterPropertyFileFunction(i);
        PublicFunctionClone.CharaterPropertyConversion();

        //-----給角色基礎裝備的詞墜給予詞綴數值
        CheckCharaterArmList();
        for (int ArmNum = 0; ArmNum < CharaterArmCountCreate; ArmNum++)
        {
            PublicFunctionClone.RandonArmPower(i, CharaterArmCreate[ArmNum]);
        }
        //-----

        //-----將裝備數值加到CharaterProperty裡面
        PublicFunctionClone.ReadCharaterPropertyFileFunction(i);
        PlusPlusArmInfoNewNew(i);
        PublicFunctionClone.CharaterPropertyStaticChange();
        string dataNew = JsonUtility.ToJson(PublicFunction.CharaterPropertyValue);
        PublicFunctionClone.ReadPlatformpersistentDataPath(FileName);
        File.WriteAllText(PublicFunction.persistentFilePath, dataNew);
        //-----

        //-----建立角色道具表
        PublicFunctionClone.CreateCharaterItemFile(i);
        //-----

        //----建立角色戰鬥技能表
        PublicFunctionClone.CreateCharaterBattleSkill(i);
        //----

        //----建立角色技能表
        PublicFunctionClone.CreateCharaterSkill(i);
        //----

        //-----建立角色基本能力表
        CreateCharaterBasicFile(i);
        //-----
    }

    public void StoreSave()                                                                        //將序列化好的數值轉成json檔
    {
        string filename = "Store";
        PublicFunctionClone.ReadPlatformpersistentDataPath(filename);

        string persistentStoreFile = JsonUtility.ToJson(StoreValue);
        System.IO.File.WriteAllText(PublicFunction.persistentFilePath, persistentStoreFile);
    }

    public void SuccessCreate()                                                                    //因為原本的MsgBox的層級是CreateCharater的子元件，如果要在成功建立角色後建立MsgBox就必須不能是子物件，避免被Destory
    {
        EmptyGameObject = GameObject.Find("UI/Prefab_CharaterList(Clone)");
        OpenMsgBoxClone = EmptyGameObject.GetComponent<OpenMsgBox>();
        OpenMsgBoxClone.CreateMsgBox(8);
        CharaterListClone = EmptyGameObject.GetComponent<CharaterList>();
        CharaterListClone.CheckCharaterCreate();
    }

    public void CreateCharaterArmOutfit(int CharaterNum, string Head, string Body, string Foot)    //這邊是用來將建立角色時所選擇的角色外觀轉換成角色裝備資料的功能
    {
        string CharaterArmFileName = "Charater_" + CharaterNum + "_Arm.json";
        string CharaterArmFilePath = Application.persistentDataPath + "/" + CharaterArmFileName;
        int ArmbasicidHead = 0;
        int ArmbasicidBody = 0;
        int ArmbasicidFoot = 0;

        if (Application.platform == RuntimePlatform.Android)
        {
            string jsonpath = Application.persistentDataPath;
            string datapath = Path.Combine(jsonpath, CharaterArmFileName);

            CharaterArmFilePath = datapath;
        }
        if (Application.platform != RuntimePlatform.Android)
        {
            string jsonpath = Application.persistentDataPath;
            string datapath = Path.Combine(jsonpath, CharaterArmFileName);

            CharaterArmFilePath = datapath;
        }

        string DataRead = File.ReadAllText(CharaterArmFilePath);

        JsonArm<CharaterArm> FileJson = JsonUtility.FromJson<JsonArm<CharaterArm>>(DataRead);

        if (SpriteAtlasChange.Head == 1)
        {
            ArmbasicidHead = 16;
        }
        if (SpriteAtlasChange.Head == 2)
        {
            ArmbasicidHead = 19;
        }
        if (SpriteAtlasChange.Head == 3)
        {
            ArmbasicidHead = 22;
        }
        if (SpriteAtlasChange.Body == 1)
        {
            ArmbasicidBody = 17;
        }
        if (SpriteAtlasChange.Body == 2)
        {
            ArmbasicidBody = 20;
        }
        if (SpriteAtlasChange.Body == 3)
        {
            ArmbasicidBody = 23;
        }
        if (SpriteAtlasChange.Foot == 1)
        {
            ArmbasicidFoot = 18;
        }
        if (SpriteAtlasChange.Foot == 2)
        {
            ArmbasicidFoot = 21;
        }
        if (SpriteAtlasChange.Foot == 3)
        {
            ArmbasicidFoot = 24;
        }

        FileJson.CharaterArm.Add(new CharaterArm()
        {
            id = 0,
            ArmPower_1 = 0,
            ArmPower_2 = 0,
            ArmPower_3 = 0,
            ArmPower_4 = 0,
            ArmPower_5 = 0,
            ArmPower_6 = 0,
            ArmEquip = true,
            ArmMain = 0,
            ArmBasicId = ArmbasicidHead,
            PowerMin_1 = 0f,
            PowerMax_1 = 0f,
            PowerMin_2 = 0f,
            PowerMax_2 = 0f,
            PowerMin_3 = 0f,
            PowerMax_3 = 0f,
            PowerMin_4 = 0f,
            PowerMax_4 = 0f,
            PowerMin_5 = 0f,
            PowerMax_5 = 0f,
            PowerMin_6 = 0f,
            PowerMax_6 = 0f
        });

        FileJson.CharaterArm.Add(new CharaterArm()
        {
            id = 1,
            ArmPower_1 = 0,
            ArmPower_2 = 0,
            ArmPower_3 = 0,
            ArmPower_4 = 0,
            ArmPower_5 = 0,
            ArmPower_6 = 0,
            ArmEquip = true,
            ArmMain = 0,
            ArmBasicId = ArmbasicidBody,
            PowerMin_1 = 0f,
            PowerMax_1 = 0f,
            PowerMin_2 = 0f,
            PowerMax_2 = 0f,
            PowerMin_3 = 0f,
            PowerMax_3 = 0f,
            PowerMin_4 = 0f,
            PowerMax_4 = 0f,
            PowerMin_5 = 0f,
            PowerMax_5 = 0f,
            PowerMin_6 = 0f,
            PowerMax_6 = 0f
        });

        FileJson.CharaterArm.Add(new CharaterArm()
        {
            id = 2,
            ArmPower_1 = 0,
            ArmPower_2 = 0,
            ArmPower_3 = 0,
            ArmPower_4 = 0,
            ArmPower_5 = 0,
            ArmPower_6 = 0,
            ArmEquip = true,
            ArmMain = 0,
            ArmBasicId = ArmbasicidFoot,
            PowerMin_1 = 0f,
            PowerMax_1 = 0f,
            PowerMin_2 = 0f,
            PowerMax_2 = 0f,
            PowerMin_3 = 0f,
            PowerMax_3 = 0f,
            PowerMin_4 = 0f,
            PowerMax_4 = 0f,
            PowerMin_5 = 0f,
            PowerMax_5 = 0f,
            PowerMin_6 = 0f,
            PowerMax_6 = 0f
        });

        DataRead = JsonUtility.ToJson(FileJson);
        File.WriteAllText(CharaterArmFilePath, DataRead);
    }

    public void Create()
    {
        OpenMsgBoxClone.CreateMsgBox(7);
    }

    public class JsonArm<T>                                                                        //角色裝備表所使用的List，來協助unity可以讀取陣列(Array)裡的資料
    {
        public List<T> CharaterArm;
    }

    public void CheckCharaterArmList()                                                             //用來檢查裝備檔案裡有多少裝備數量，記得之後製作獲得道具和失去道具功能後要使用此功能來修改裝備數量
    {
        string CharaterArmFileName = "Charater_" + CharaterPropertyStatic.CharaterNumber + "_Arm.json";
        string CharaterArmFilePath = Path.Combine(Application.persistentDataPath, CharaterArmFileName);

        if (Application.platform == RuntimePlatform.Android)
        {
            string jsonpath = Application.persistentDataPath;
            string datapath = Path.Combine(jsonpath, CharaterArmFileName);

            CharaterArmFilePath = datapath;
        }
        if (Application.platform != RuntimePlatform.Android)
        {
            string jsonpath = Application.persistentDataPath;
            string datapath = Path.Combine(jsonpath, CharaterArmFileName);

            CharaterArmFilePath = datapath;
        }

        string DataRead = File.ReadAllText(CharaterArmFilePath);

        JsonArm<CharaterArm> FileJson = JsonUtility.FromJson<JsonArm<CharaterArm>>(DataRead);

        CharaterArmCountCreate = FileJson.CharaterArm.Count;
        CharaterArmCreate = new int[CharaterArmCountCreate];

        for (int i = 0; i < CharaterArmCountCreate; i++)
        {
            CharaterArmCreate[i] = FileJson.CharaterArm[i].id;
        }
    }

    public void PlusPlusArmInfoNewNew(int CharaterNum)
	{
        CheckCharaterArmList();
        for (int ArmNum = 0; ArmNum < CharaterArmCountCreate; ArmNum++)
		{
            PublicFunctionClone.ReadCharaterArm(CharaterNum, CharaterArmCreate[ArmNum]);
            PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
            switch(CharaterArmStatic.ArmEquip)
			{
                case true:
					{
                        switch (ArmStatic.ArmType)
                        {
                            case 0:
                                {
                                    switch (CharaterPropertyStatic.CharaterPhysicalDamgeMin == 0)
                                    {
                                        case true:
                                            {
                                                CharaterPropertyStatic.CharaterPhysicalDamgeMin = ArmStatic.WeaponDamageMin;
                                                break;
                                            }
                                        case false:
                                            {
                                                CharaterPropertyStatic.CharaterPhysicalDamgeMin = CharaterPropertyStatic.CharaterPhysicalDamgeMin + ArmStatic.WeaponDamageMin;
                                                break;
                                            }
                                    }
                                    switch (CharaterPropertyStatic.CharaterPhysicalDamgeMax == 0)
                                    {
                                        case true:
                                            {
                                                CharaterPropertyStatic.CharaterPhysicalDamgeMax = ArmStatic.WeaponDamageMax;
                                                break;
                                            }
                                        case false:
                                            {
                                                CharaterPropertyStatic.CharaterPhysicalDamgeMax = CharaterPropertyStatic.CharaterPhysicalDamgeMax + ArmStatic.WeaponDamageMax;
                                                break;
                                            }
                                    }
                                    switch (ArmStatic.WeaponSpeed < CharaterPropertyStatic.CharaterAttackSpeed)
                                    {
                                        case true:
                                            {
                                                CharaterPropertyStatic.CharaterAttackSpeed = ArmStatic.WeaponSpeed;
                                                break;
                                            }
                                        case false:
                                            {
                                                break;
                                            }
                                    }
                                    PowerSwitchIdNew();
                                    break;
                                }
                            default:
                                {
                                    switch (CharaterPropertyStatic.CharaterPhysicalResist == 0)
                                    {
                                        case true:
                                            {
                                                CharaterPropertyStatic.CharaterPhysicalResist = ArmStatic.ArmArmor;
                                                break;
                                            }
                                        case false:
                                            {
                                                CharaterPropertyStatic.CharaterPhysicalResist = CharaterPropertyStatic.CharaterPhysicalResist + ArmStatic.ArmArmor;
                                                break;
                                            }
                                    }
                                    CharaterPropertyStatic.CharaterPhysicalResistRate = (CharaterPropertyStatic.CharaterPhysicalResist / CharaterPropertyStatic.CharaterPhysicalResistMax) * 100;
                                    switch (CharaterPropertyStatic.CharaterMagicShield == 0)
                                    {
                                        case true:
                                            {
                                                CharaterPropertyStatic.CharaterMagicShield = ArmStatic.ArmMagicShield;
                                                CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                                break;
                                            }
                                        case false:
                                            {
                                                CharaterPropertyStatic.CharaterMagicShield = CharaterPropertyStatic.CharaterMagicShield + ArmStatic.ArmMagicShield;
                                                CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                                break;
                                            }
                                    }
                                    switch (CharaterPropertyStatic.CharaterDodge == 0)
                                    {
                                        case true:
                                            {
                                                CharaterPropertyStatic.CharaterDodge = ArmStatic.ArmDodge;
                                                break;
                                            }
                                        case false:
                                            {
                                                CharaterPropertyStatic.CharaterDodge = CharaterPropertyStatic.CharaterDodge + ArmStatic.ArmDodge;
                                                break;
                                            }
                                    }
                                    CharaterPropertyStatic.CharaterDodgeRate = (CharaterPropertyStatic.CharaterDodge / CharaterPropertyStatic.CharaterDodgeMax) * 100;
                                    PowerSwitchIdNew();
                                    break;
                                }
                        }
                        break;
					}
                case false:
					{
                        break;
					}
			}
            
        }
    }

    public void PlusArmInfoNew(int CharaterNum)                                                    //將所有裝備上的數值都加到CharaterBattleProperty裡
    {
        CheckCharaterArmList();
        for (int ArmNum = 0; ArmNum < CharaterArmCountCreate; ArmNum++)
        {
            PublicFunctionClone.ReadCharaterArm(CharaterNum, CharaterArmCreate[ArmNum]);
            PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
            switch (CharaterArmCreate[ArmNum])
            {
                case 0:
                    {
                        switch (CharaterPropertyStatic.CharaterPhysicalDamgeMin == 0)
                        {
                            case true:
                                {
                                    CharaterPropertyStatic.CharaterPhysicalDamgeMin = ArmStatic.WeaponDamageMin;
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterPhysicalDamgeMin = CharaterPropertyStatic.CharaterPhysicalDamgeMin + ArmStatic.WeaponDamageMin;
                                    break;
                                }
                        }
                        switch (CharaterPropertyStatic.CharaterPhysicalDamgeMax == 0)
                        {
                            case true:
                                {
                                    CharaterPropertyStatic.CharaterPhysicalDamgeMax = ArmStatic.WeaponDamageMax;
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterPhysicalDamgeMax = CharaterPropertyStatic.CharaterPhysicalDamgeMax + ArmStatic.WeaponDamageMax;
                                    break;
                                }
                        }
                        //-----比較主手武器跟副手武器哪個攻擊速度較慢
                        float mainweaponspeed = ArmStatic.WeaponSpeed;
                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 1);
                        PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                        float secondweaponspeed = ArmStatic.WeaponSpeed;
                        bool secondweaponeuip = CharaterArmStatic.ArmEquip;
                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 0);
                        switch(secondweaponeuip)
                        {
                            case true:
                                {
                                    switch(secondweaponspeed > mainweaponspeed)
                                    {
                                        case true:
                                            {
                                                CharaterPropertyStatic.CharaterAttackSpeed = secondweaponspeed;
                                                break;
                                            }
                                        case false:
                                            {
                                                CharaterPropertyStatic.CharaterAttackSpeed = mainweaponspeed;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterAttackSpeed = mainweaponspeed;
                                    break;
                                }
                        }
                        //-----
                        PowerSwitchIdNew();
                        break;
                    }
                case 1:
                    {
                        switch (CharaterPropertyStatic.CharaterPhysicalDamgeMin == 0)
                        {
                            case true:
                                {
                                    CharaterPropertyStatic.CharaterPhysicalDamgeMin = ArmStatic.WeaponDamageMin;
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterPhysicalDamgeMin = CharaterPropertyStatic.CharaterPhysicalDamgeMin + ArmStatic.WeaponDamageMin;
                                    break;
                                }
                        }
                        switch (CharaterPropertyStatic.CharaterPhysicalDamgeMax == 0)
                        {
                            case true:
                                {
                                    CharaterPropertyStatic.CharaterPhysicalDamgeMax = ArmStatic.WeaponDamageMax;
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterPhysicalDamgeMax = CharaterPropertyStatic.CharaterPhysicalDamgeMax + ArmStatic.WeaponDamageMax;
                                    break;
                                }
                        }
                        //-----比較主手武器跟副手武器哪個攻擊速度較慢
                        float secondweaponspeed = ArmStatic.WeaponSpeed;
                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 0);
                        PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                        float mainweaponspeed = ArmStatic.WeaponSpeed;
                        bool mainweaponeuip = CharaterArmStatic.ArmEquip;
                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 1);
                        switch (mainweaponeuip)
                        {
                            case true:
                                {
                                    switch (secondweaponspeed > mainweaponspeed)
                                    {
                                        case true:
                                            {
                                                CharaterPropertyStatic.CharaterAttackSpeed = secondweaponspeed;
                                                break;
                                            }
                                        case false:
                                            {
                                                CharaterPropertyStatic.CharaterAttackSpeed = mainweaponspeed;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterAttackSpeed = secondweaponspeed;
                                    break;
                                }
                        }
                        //-----
                        PowerSwitchIdNew();
                        break;
                    }
                case 2:
                    {
                        switch (CharaterPropertyStatic.CharaterPhysicalResist == 0)
                        {
                            case true:
                                {
                                    CharaterPropertyStatic.CharaterPhysicalResist = ArmStatic.ArmArmor;
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterPhysicalResist = CharaterPropertyStatic.CharaterPhysicalResist + ArmStatic.ArmArmor;
                                    break;
                                }
                        }
                        CharaterPropertyStatic.CharaterPhysicalResistRate = (CharaterPropertyStatic.CharaterPhysicalResist / CharaterPropertyStatic.CharaterPhysicalResistMax) * 100;
                        switch (CharaterPropertyStatic.CharaterMagicShield == 0)
                        {
                            case true:
                                {
                                    CharaterPropertyStatic.CharaterMagicShield = ArmStatic.ArmMagicShield;
                                    CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterMagicShield = CharaterPropertyStatic.CharaterMagicShield + ArmStatic.ArmMagicShield;
                                    CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                    break;
                                }
                        }
                        switch (CharaterPropertyStatic.CharaterDodge == 0)
                        {
                            case true:
                                {
                                    CharaterPropertyStatic.CharaterDodge = ArmStatic.ArmDodge;
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterDodge = CharaterPropertyStatic.CharaterDodge + ArmStatic.ArmDodge;
                                    break;
                                }
                        }
                        CharaterPropertyStatic.CharaterDodgeRate = (CharaterPropertyStatic.CharaterDodge / CharaterPropertyStatic.CharaterDodgeMax) * 100;
                        PowerSwitchIdNew();
                        break;
                    }
                case 3:
                    {
                        switch (CharaterPropertyStatic.CharaterPhysicalResist == 0)
                        {
                            case true:
                                {
                                    CharaterPropertyStatic.CharaterPhysicalResist = ArmStatic.ArmArmor;
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterPhysicalResist = CharaterPropertyStatic.CharaterPhysicalResist + ArmStatic.ArmArmor;
                                    break;
                                }
                        }
                        CharaterPropertyStatic.CharaterPhysicalResistRate = (CharaterPropertyStatic.CharaterPhysicalResist / CharaterPropertyStatic.CharaterPhysicalResistMax) * 100;
                        switch (CharaterPropertyStatic.CharaterMagicShield == 0)
                        {
                            case true:
                                {
                                    CharaterPropertyStatic.CharaterMagicShield = ArmStatic.ArmMagicShield;
                                    CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterMagicShield = CharaterPropertyStatic.CharaterMagicShield + ArmStatic.ArmMagicShield;
                                    CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                    break;
                                }
                        }
                        switch (CharaterPropertyStatic.CharaterDodge == 0)
                        {
                            case true:
                                {
                                    CharaterPropertyStatic.CharaterDodge = ArmStatic.ArmDodge;
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterDodge = CharaterPropertyStatic.CharaterDodge + ArmStatic.ArmDodge;
                                    break;
                                }
                        }
                        CharaterPropertyStatic.CharaterDodgeRate = (CharaterPropertyStatic.CharaterDodge / CharaterPropertyStatic.CharaterDodgeMax) * 100;
                        PowerSwitchIdNew();
                        break;
                    }
                case 4:
                    {
                        switch (CharaterPropertyStatic.CharaterPhysicalResist == 0)
                        {
                            case true:
                                {
                                    CharaterPropertyStatic.CharaterPhysicalResist = ArmStatic.ArmArmor;
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterPhysicalResist = CharaterPropertyStatic.CharaterPhysicalResist + ArmStatic.ArmArmor;
                                    break;
                                }
                        }
                        CharaterPropertyStatic.CharaterPhysicalResistRate = (CharaterPropertyStatic.CharaterPhysicalResist / CharaterPropertyStatic.CharaterPhysicalResistMax) * 100;
                        switch (CharaterPropertyStatic.CharaterMagicShield == 0)
                        {
                            case true:
                                {
                                    CharaterPropertyStatic.CharaterMagicShield = ArmStatic.ArmMagicShield;
                                    CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterMagicShield = CharaterPropertyStatic.CharaterMagicShield + ArmStatic.ArmMagicShield;
                                    CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                    break;
                                }
                        }
                        switch (CharaterPropertyStatic.CharaterDodge == 0)
                        {
                            case true:
                                {
                                    CharaterPropertyStatic.CharaterDodge = ArmStatic.ArmDodge;
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterDodge = CharaterPropertyStatic.CharaterDodge + ArmStatic.ArmDodge;
                                    break;
                                }
                        }
                        CharaterPropertyStatic.CharaterDodgeRate = (CharaterPropertyStatic.CharaterDodge / CharaterPropertyStatic.CharaterDodgeMax) * 100;
                        PowerSwitchIdNew();
                        break;
                    }
                case 5:
                    {
                        switch (CharaterPropertyStatic.CharaterPhysicalResist == 0)
                        {
                            case true:
                                {
                                    CharaterPropertyStatic.CharaterPhysicalResist = ArmStatic.ArmArmor;
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterPhysicalResist = CharaterPropertyStatic.CharaterPhysicalResist + ArmStatic.ArmArmor;
                                    break;
                                }
                        }
                        CharaterPropertyStatic.CharaterPhysicalResistRate = (CharaterPropertyStatic.CharaterPhysicalResist / CharaterPropertyStatic.CharaterPhysicalResistMax) * 100;
                        switch (CharaterPropertyStatic.CharaterMagicShield == 0)
                        {
                            case true:
                                {
                                    CharaterPropertyStatic.CharaterMagicShield = ArmStatic.ArmMagicShield;
                                    CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterMagicShield = CharaterPropertyStatic.CharaterMagicShield + ArmStatic.ArmMagicShield;
                                    CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                    break;
                                }
                        }
                        switch (CharaterPropertyStatic.CharaterDodge == 0)
                        {
                            case true:
                                {
                                    CharaterPropertyStatic.CharaterDodge = ArmStatic.ArmDodge;
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterDodge = CharaterPropertyStatic.CharaterDodge + ArmStatic.ArmDodge;
                                    break;
                                }
                        }
                        CharaterPropertyStatic.CharaterDodgeRate = (CharaterPropertyStatic.CharaterDodge / CharaterPropertyStatic.CharaterDodgeMax) * 100;
                        PowerSwitchIdNew();
                        break;
                    }
                case 6:
                    {
                        switch (CharaterPropertyStatic.CharaterPhysicalResist == 0)
                        {
                            case true:
                                {
                                    CharaterPropertyStatic.CharaterPhysicalResist = ArmStatic.ArmArmor;
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterPhysicalResist = CharaterPropertyStatic.CharaterPhysicalResist + ArmStatic.ArmArmor;
                                    break;
                                }
                        }
                        CharaterPropertyStatic.CharaterPhysicalResistRate = (CharaterPropertyStatic.CharaterPhysicalResist / CharaterPropertyStatic.CharaterPhysicalResistMax) * 100;
                        switch (CharaterPropertyStatic.CharaterMagicShield == 0)
                        {
                            case true:
                                {
                                    CharaterPropertyStatic.CharaterMagicShield = ArmStatic.ArmMagicShield;
                                    CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterMagicShield = CharaterPropertyStatic.CharaterMagicShield + ArmStatic.ArmMagicShield;
                                    CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                    break;
                                }
                        }
                        switch (CharaterPropertyStatic.CharaterDodge == 0)
                        {
                            case true:
                                {
                                    CharaterPropertyStatic.CharaterDodge = ArmStatic.ArmDodge;
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterDodge = CharaterPropertyStatic.CharaterDodge + ArmStatic.ArmDodge;
                                    break;
                                }
                        }
                        CharaterPropertyStatic.CharaterDodgeRate = (CharaterPropertyStatic.CharaterDodge / CharaterPropertyStatic.CharaterDodgeMax) * 100;
                        PowerSwitchIdNew();
                        break;
                    }
                case 7:
                    {
                        switch (CharaterPropertyStatic.CharaterPhysicalResist == 0)
                        {
                            case true:
                                {
                                    CharaterPropertyStatic.CharaterPhysicalResist = ArmStatic.ArmArmor;
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterPhysicalResist = CharaterPropertyStatic.CharaterPhysicalResist + ArmStatic.ArmArmor;
                                    break;
                                }
                        }
                        CharaterPropertyStatic.CharaterPhysicalResistRate = (CharaterPropertyStatic.CharaterPhysicalResist / CharaterPropertyStatic.CharaterPhysicalResistMax) * 100;
                        switch (CharaterPropertyStatic.CharaterMagicShield == 0)
                        {
                            case true:
                                {
                                    CharaterPropertyStatic.CharaterMagicShield = ArmStatic.ArmMagicShield;
                                    CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterMagicShield = CharaterPropertyStatic.CharaterMagicShield + ArmStatic.ArmMagicShield;
                                    CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                    break;
                                }
                        }
                        switch (CharaterPropertyStatic.CharaterDodge == 0)
                        {
                            case true:
                                {
                                    CharaterPropertyStatic.CharaterDodge = ArmStatic.ArmDodge;
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterDodge = CharaterPropertyStatic.CharaterDodge + ArmStatic.ArmDodge;
                                    break;
                                }
                        }
                        CharaterPropertyStatic.CharaterDodgeRate = (CharaterPropertyStatic.CharaterDodge / CharaterPropertyStatic.CharaterDodgeMax) * 100;
                        PowerSwitchIdNew();
                        break;
                    }
                case 8:
                    {
                        switch (CharaterPropertyStatic.CharaterPhysicalResist == 0)
                        {
                            case true:
                                {
                                    CharaterPropertyStatic.CharaterPhysicalResist = ArmStatic.ArmArmor;
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterPhysicalResist = CharaterPropertyStatic.CharaterPhysicalResist + ArmStatic.ArmArmor;
                                    break;
                                }
                        }
                        CharaterPropertyStatic.CharaterPhysicalResistRate = (CharaterPropertyStatic.CharaterPhysicalResist / CharaterPropertyStatic.CharaterPhysicalResistMax) * 100;
                        switch (CharaterPropertyStatic.CharaterMagicShield == 0)
                        {
                            case true:
                                {
                                    CharaterPropertyStatic.CharaterMagicShield = ArmStatic.ArmMagicShield;
                                    CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterMagicShield = CharaterPropertyStatic.CharaterMagicShield + ArmStatic.ArmMagicShield;
                                    CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                    break;
                                }
                        }
                        switch (CharaterPropertyStatic.CharaterDodge == 0)
                        {
                            case true:
                                {
                                    CharaterPropertyStatic.CharaterDodge = ArmStatic.ArmDodge;
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterDodge = CharaterPropertyStatic.CharaterDodge + ArmStatic.ArmDodge;
                                    break;
                                }
                        }
                        CharaterPropertyStatic.CharaterDodgeRate = (CharaterPropertyStatic.CharaterDodge / CharaterPropertyStatic.CharaterDodgeMax) * 100;
                        PowerSwitchIdNew();
                        break;
                    }
                case 9:
                    {
                        switch (CharaterPropertyStatic.CharaterPhysicalResist == 0)
                        {
                            case true:
                                {
                                    CharaterPropertyStatic.CharaterPhysicalResist = ArmStatic.ArmArmor;
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterPhysicalResist = CharaterPropertyStatic.CharaterPhysicalResist + ArmStatic.ArmArmor;
                                    break;
                                }
                        }
                        CharaterPropertyStatic.CharaterPhysicalResistRate = (CharaterPropertyStatic.CharaterPhysicalResist / CharaterPropertyStatic.CharaterPhysicalResistMax) * 100;
                        switch (CharaterPropertyStatic.CharaterMagicShield == 0)
                        {
                            case true:
                                {
                                    CharaterPropertyStatic.CharaterMagicShield = ArmStatic.ArmMagicShield;
                                    CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterMagicShield = CharaterPropertyStatic.CharaterMagicShield + ArmStatic.ArmMagicShield;
                                    CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                    break;
                                }
                        }
                        switch (CharaterPropertyStatic.CharaterDodge == 0)
                        {
                            case true:
                                {
                                    CharaterPropertyStatic.CharaterDodge = ArmStatic.ArmDodge;
                                    break;
                                }
                            case false:
                                {
                                    CharaterPropertyStatic.CharaterDodge = CharaterPropertyStatic.CharaterDodge + ArmStatic.ArmDodge;
                                    break;
                                }
                        }
                        CharaterPropertyStatic.CharaterDodgeRate = (CharaterPropertyStatic.CharaterDodge / CharaterPropertyStatic.CharaterDodgeMax) * 100;
                        PowerSwitchIdNew();
                        break;
                    }
            }
        }
    }

    public void PowerListSwitchIdNew(int PowerId, float PowerMin, float PowerMax)                  //將該裝備上擁有的詞綴數值加到CharaterBattleProperty裡
    {
        switch (PowerId)
        {
            case 1:
                {
                    switch (CharaterPropertyStatic.CharaterProperty_Strength == 0)
                    {
                        case true:
                            {
                                CharaterPropertyStatic.CharaterProperty_Strength = PowerMin;
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterProperty_Strength = CharaterPropertyStatic.CharaterProperty_Strength + PowerMin;
                                CharaterPropertyStatic.CharaterHp = 10 + (CharaterPropertyStatic.CharaterProperty_Strength * 10);
                                CharaterPropertyStatic.CharaterHpNow = CharaterPropertyStatic.CharaterHp * (CharaterPropertyStatic.CharaterHpNowRate / 100);
                                CharaterPropertyStatic.CharaterPhysicalDamgeMax = 1 + (CharaterPropertyStatic.CharaterProperty_Strength * 10);
                                break;
                            }
                    }
                    break;
                }
            case 2:
                {
                    switch (CharaterPropertyStatic.CharaterProperty_Intelligence == 0)
                    {
                        case true:
                            {
                                CharaterPropertyStatic.CharaterProperty_Intelligence = PowerMin;
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterProperty_Intelligence = CharaterPropertyStatic.CharaterProperty_Intelligence + PowerMin;
                                CharaterPropertyStatic.CharaterMp = 10 + (CharaterPropertyStatic.CharaterProperty_Intelligence * 10);
                                CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMp * (CharaterPropertyStatic.CharaterMpNowRate / 100);
                                CharaterPropertyStatic.CharaterMagicDamgeMin = CharaterPropertyStatic.CharaterProperty_Intelligence * 5;
                                CharaterPropertyStatic.CharaterMagicDamgeMax = CharaterPropertyStatic.CharaterProperty_Intelligence * 10;
                                break;
                            }
                    }
                    break;
                }
            case 3:
                {
                    int OldDex = Convert.ToInt32(CharaterPropertyStatic.CharaterProperty_Dexterity);
                    switch (CharaterPropertyStatic.CharaterProperty_Dexterity == 0)
                    {
                        case true:
                            {
                                CharaterPropertyStatic.CharaterProperty_Dexterity = PowerMin;
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterProperty_Dexterity = CharaterPropertyStatic.CharaterProperty_Dexterity + PowerMin;
                                CharaterPropertyStatic.CharaterDodge = CharaterPropertyStatic.CharaterProperty_Dexterity + (CharaterPropertyStatic.CharaterDodge - OldDex);
                                CharaterPropertyStatic.CharaterDodgeRate = (CharaterPropertyStatic.CharaterDodge / CharaterPropertyStatic.CharaterDodgeMax) * 100;
                                CharaterPropertyStatic.CharaterDodgeRate = Mathf.Round(CharaterPropertyStatic.CharaterDodgeRate);
                                CharaterPropertyStatic.CharaterCritical = CharaterPropertyStatic.CharaterProperty_Dexterity + (CharaterPropertyStatic.CharaterCritical - OldDex);
                                CharaterPropertyStatic.CharaterCriticalRate = (CharaterPropertyStatic.CharaterCritical / CharaterPropertyStatic.CharaterCriticalMax) * 100;
                                CharaterPropertyStatic.CharaterCriticalRate = Mathf.Round(CharaterPropertyStatic.CharaterCriticalRate);
                                break;
                            }
                    }
                    break;
                }
            case 4:
                {
                    switch (CharaterPropertyStatic.CharaterHp == 0)
                    {
                        case true:
                            {
                                CharaterPropertyStatic.CharaterHp = PowerMin;
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterHp = CharaterPropertyStatic.CharaterHp + PowerMin;
                                CharaterPropertyStatic.CharaterHpNow = CharaterPropertyStatic.CharaterHp;
                                CharaterPropertyStatic.CharaterHpNowRate = (CharaterPropertyStatic.CharaterHp / CharaterPropertyStatic.CharaterHpNow) * 100;
                                break;
                            }
                    }
                    break;
                }
            case 5:
                {
                    switch (CharaterPropertyStatic.CharaterMp == 0)
                    {
                        case true:
                            {
                                CharaterPropertyStatic.CharaterMp = PowerMin;
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterMp = CharaterPropertyStatic.CharaterMp + PowerMin;
                                CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMp;
                                CharaterPropertyStatic.CharaterMpNowRate = (CharaterPropertyStatic.CharaterMp / CharaterPropertyStatic.CharaterMpNow) * 100;
                                break;
                            }
                    }
                    break;
                }
            case 6:
                {
                    switch (CharaterPropertyStatic.CharaterPhysicalDamgeMin == 0)
                    {
                        case true:
                            {
                                CharaterPropertyStatic.CharaterPhysicalDamgeMin = PowerMin;
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterPhysicalDamgeMin = CharaterPropertyStatic.CharaterPhysicalDamgeMin + PowerMin;
                                break;
                            }
                    }
                    switch (CharaterPropertyStatic.CharaterPhysicalDamgeMax == 0)
                    {
                        case true:
                            {
                                CharaterPropertyStatic.CharaterPhysicalDamgeMax = PowerMax;
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterPhysicalDamgeMax = CharaterPropertyStatic.CharaterPhysicalDamgeMax + PowerMax;
                                break;
                            }
                    }
                    break;
                }
            case 7:
                {
                    switch (CharaterPropertyStatic.CharaterMagicDamgeMin == 0)
                    {
                        case true:
                            {
                                CharaterPropertyStatic.CharaterMagicDamgeMin = PowerMin;
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterMagicDamgeMin = CharaterPropertyStatic.CharaterMagicDamgeMin + PowerMin;
                                break;
                            }
                    }
                    switch (CharaterPropertyStatic.CharaterMagicDamgeMax == 0)
                    {
                        case true:
                            {
                                CharaterPropertyStatic.CharaterMagicDamgeMax = PowerMax;
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterMagicDamgeMax = CharaterPropertyStatic.CharaterMagicDamgeMax + PowerMax;
                                break;
                            }
                    }
                    break;
                }
            case 8:
                {
                    switch (CharaterPropertyStatic.CharaterHpRecover == 0)
                    {
                        case true:
                            {
                                CharaterPropertyStatic.CharaterHpRecover = PowerMin;
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterHpRecover = CharaterPropertyStatic.CharaterHpRecover + PowerMin;
                                break;
                            }
                    }
                    break;
                }
            case 9:
                {
                    switch (CharaterPropertyStatic.CharaterMpRecover == 0)
                    {
                        case true:
                            {
                                CharaterPropertyStatic.CharaterMpRecover = PowerMin;
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterMpRecover = CharaterPropertyStatic.CharaterMpRecover + PowerMin;
                                break;
                            }
                    }
                    break;
                }
            case 10:
                {
                    switch (CharaterPropertyStatic.CharaterPhysicalResist == 0)
                    {
                        case true:
                            {
                                CharaterPropertyStatic.CharaterPhysicalResist = PowerMin;
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterPhysicalResist = CharaterPropertyStatic.CharaterPhysicalResist + PowerMin;
                                break;
                            }
                    }
                    break;
                }
            case 11:
                {
                    switch (CharaterPropertyStatic.CharaterMagicShield == 0)
                    {
                        case true:
                            {
                                CharaterPropertyStatic.CharaterMagicShield = PowerMin;
                                CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterMagicShield = CharaterPropertyStatic.CharaterMagicShield + PowerMin;
                                CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                break;
                            }
                    }
                    break;
                }
            case 12:
                {
                    switch (CharaterPropertyStatic.CharaterDodge == 0)
                    {
                        case true:
                            {
                                CharaterPropertyStatic.CharaterDodge = PowerMin;
                                CharaterPropertyStatic.CharaterDodgeRate = (CharaterPropertyStatic.CharaterDodge / CharaterPropertyStatic.CharaterDodgeMax) * 100;
                                CharaterPropertyStatic.CharaterDodgeRate = Mathf.Round(CharaterPropertyStatic.CharaterDodgeRate);
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterDodge = CharaterPropertyStatic.CharaterDodge + PowerMin;
                                CharaterPropertyStatic.CharaterDodgeRate = (CharaterPropertyStatic.CharaterDodge / CharaterPropertyStatic.CharaterDodgeMax) * 100;
                                CharaterPropertyStatic.CharaterDodgeRate = Mathf.Round(CharaterPropertyStatic.CharaterDodgeRate);
                                break;
                            }
                    }
                    break;
                }
            case 13:
                {
                    switch (CharaterPropertyStatic.CharaterCritical == 0)
                    {
                        case true:
                            {
                                CharaterPropertyStatic.CharaterCritical = PowerMin;
                                CharaterPropertyStatic.CharaterCriticalRate = (CharaterPropertyStatic.CharaterCritical / CharaterPropertyStatic.CharaterCriticalMax) * 100;
                                CharaterPropertyStatic.CharaterCriticalRate = Mathf.Round(CharaterPropertyStatic.CharaterCriticalRate);
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterCritical = CharaterPropertyStatic.CharaterCritical + PowerMin;
                                CharaterPropertyStatic.CharaterCriticalRate = (CharaterPropertyStatic.CharaterCritical / CharaterPropertyStatic.CharaterCriticalMax) * 100;
                                CharaterPropertyStatic.CharaterCriticalRate = Mathf.Round(CharaterPropertyStatic.CharaterCriticalRate);
                                break;
                            }
                    }
                    break;
                }
        }
    }

    public void PowerSwitchIdNew()                                                                 //讀取每個裝備上每個詞綴的數值
    {
        for (int PowerId = 1; PowerId < 7; PowerId++)
        {
            switch (PowerId)
            {
                case 1:
                    {
                        int PowerNum = CharaterArmStatic.ArmPower_1;
                        PublicFunctionClone.ReadArmPower(PowerNum);
                        PowerListSwitchIdNew(PowerNum, CharaterArmStatic.PowerMin_1, CharaterArmStatic.PowerMax_1);
                        break;
                    }
                case 2:
                    {
                        int PowerNum = CharaterArmStatic.ArmPower_2;
                        PublicFunctionClone.ReadArmPower(PowerNum);
                        PowerListSwitchIdNew(PowerNum, CharaterArmStatic.PowerMin_2, CharaterArmStatic.PowerMax_2);
                        break;
                    }
                case 3:
                    {
                        int PowerNum = CharaterArmStatic.ArmPower_3;
                        PublicFunctionClone.ReadArmPower(PowerNum);
                        PowerListSwitchIdNew(PowerNum, CharaterArmStatic.PowerMin_3, CharaterArmStatic.PowerMax_3);
                        break;
                    }
                case 4:
                    {
                        int PowerNum = CharaterArmStatic.ArmPower_4;
                        PublicFunctionClone.ReadArmPower(PowerNum);
                        PowerListSwitchIdNew(PowerNum, CharaterArmStatic.PowerMin_4, CharaterArmStatic.PowerMax_4);
                        break;
                    }
                case 5:
                    {
                        int PowerNum = CharaterArmStatic.ArmPower_5;
                        PublicFunctionClone.ReadArmPower(PowerNum);
                        PowerListSwitchIdNew(PowerNum, CharaterArmStatic.PowerMin_5, CharaterArmStatic.PowerMax_5);
                        break;
                    }
                case 6:
                    {
                        int PowerNum = CharaterArmStatic.ArmPower_6;
                        PublicFunctionClone.ReadArmPower(PowerNum);
                        PowerListSwitchIdNew(PowerNum, CharaterArmStatic.PowerMin_6, CharaterArmStatic.PowerMax_6);
                        break;
                    }
            }
        }
    }

    public void CreateCharaterBasicFile(int FileName)
	{
        CharaterBasic CharaterBasicStaticClone = new CharaterBasic();

        PublicFunctionClone.ReadCharaterPropertyFileFunction(CharaterPropertyStatic.CharaterNumber);
        CharaterBasicStaticClone.CharaterBasic_Level = CharaterPropertyStatic.CharaterLevel;

        CharaterBasicStaticClone.CharaterBasic_Strength = CharaterPropertyStatic.CharaterProperty_Strength;
        CharaterBasicStaticClone.CharaterBasic_Intelligence = CharaterPropertyStatic.CharaterProperty_Intelligence;
        CharaterBasicStaticClone.CharaterBasic_Dexterity = CharaterPropertyStatic.CharaterProperty_Dexterity;

        CharaterBasicStaticClone.CharaterBasic_Hp = CharaterPropertyStatic.CharaterHp;
        CharaterBasicStaticClone.CharaterBasic_Mp = CharaterPropertyStatic.CharaterMp;

        CharaterBasicStaticClone.CharaterBasic_PhysicalDamgeMin = CharaterPropertyStatic.CharaterPhysicalDamgeMin;
        CharaterBasicStaticClone.CharaterBasic_PhysicalDamgeMax = CharaterPropertyStatic.CharaterPhysicalDamgeMax;
        CharaterBasicStaticClone.CharaterBasic_MagicDamgeMin = CharaterPropertyStatic.CharaterMagicDamgeMin;
        CharaterBasicStaticClone.CharaterBasic_MagicDamgeMax = CharaterPropertyStatic.CharaterMagicDamgeMax;

        CharaterBasicStaticClone.CharaterBasic_Dodge = CharaterPropertyStatic.CharaterDodge;
        CharaterBasicStaticClone.CharaterBasic_PhysicalResist = CharaterPropertyStatic.CharaterPhysicalResist;
        CharaterBasicStaticClone.CharaterBasic_MagicShield = CharaterPropertyStatic.CharaterMagicShield;

        CharaterBasicStaticClone.CharaterBasic_Critical = CharaterPropertyStatic.CharaterCritical;
        CharaterBasicStaticClone.CharaterBasic_AttackSpeed = CharaterPropertyStatic.CharaterAttackSpeed;

        CharaterBasicStaticClone.CharaterBasic_HpRecover = CharaterPropertyStatic.CharaterHpRecover;
        CharaterBasicStaticClone.CharaterBasic_MpRecover = CharaterPropertyStatic.CharaterMpRecover;

        Debug.Log("看這裡看這裡看這裡看這裡看這裡" + CharaterPropertyStatic.CharaterNumber);

        string DataName = "Charater_" + FileName + "_Basic";
             
        string BasicData = JsonUtility.ToJson(CharaterBasicStaticClone);
        PublicFunctionClone.ReadPlatformpersistentDataPath(DataName);
        Debug.Log("路徑:" + PublicFunction.persistentFilePath);
        File.WriteAllText(PublicFunction.persistentFilePath, BasicData);
    }
}
