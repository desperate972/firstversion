using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;
using System.Net;
using UnityEngine.Networking;
using System.Linq;

public class PublicFunction : MonoBehaviour
{

    public static string ReturnString;             //使用UI字串時需要的變數，StringUI.json在反序列化使用

    public static string Armid;                    //獲取裝備id時使用，Charater_X_Arm.json在反序列化使用

    public static Store StoreValue;
    public static string CharaterDataPath;
    public static string StoreFile;
    public static string StoreFilePath;
    public static string CharaterPropertyFile;
    public static string ReadCharaterPropertyFile;
    public static string CharaterPropertyBasicFile;
    public static string ReadCharaterPropertyBasicFile;

    public static string streamingFilePath;
    public static string persistentFilePath;

    public static CharaterProperty CharaterPropertyValue;
    public static string persistentStoreFile;
    public static string persistentCharaterFile;

    public static WWW StringUIFile;

    public static Vector2 ChangeSprite;

    public static string ItemTagName;

    public static int CharaterBattleSkillCount;
    public static int[] CharaterBattleSkillArray;

    public static CharaterBasic CharaterBasicValue;

    private void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReadStringUI(int i)                                                                //讀StringUI的檔案使用UnityWebRequest
    {
        string jsonfile = "StringUI";
        ReadPlatformStreamingAssets(jsonfile);
        string datapath = streamingFilePath;
        var StringUIFile = new UnityWebRequest(datapath);
        StringUIFile.downloadHandler = new DownloadHandlerBuffer();
        var something = StringUIFile.SendWebRequest();
        while(!something.isDone)
        { }
        string dataread = StringUIFile.downloadHandler.text;                    
        JsonRead<StringUI> FileJson = JsonUtility.FromJson<JsonRead<StringUI>>(dataread);
        foreach (StringUI data in FileJson.StringUI)
        {
            if (data.id == i)
            {
                Debug.Log("從PublicFuniction呼叫而來的功能\n" + data.stringui);
                ReturnString = data.stringui;
            }
        }
    }

    public void ReadStringUIOrigin(int i)                                                          //讀StringUI的檔案使用WWW
    {
        string jsonfile = "StringUI";

        ReadPlatformStreamingAssets(jsonfile);

        string datapath = streamingFilePath;

        //var StringUIFile = new UnityWebRequest(datapath);
        //StringUIFile.downloadHandler = new DownloadHandlerBuffer();

        StringUIFile = new WWW(datapath);
        while (!StringUIFile.isDone)
        {      }
        string dataread = StringUIFile.text;

        //string dataread = StringUIFile.downloadHandler.text;

        //string fileinside = File.ReadAllText(datapath);

        Debug.Log("STRING的字串內容" + dataread);

        //dataread = "{ \"StringUI\": " + dataread + "}";                                    //這邊所加上的字串必須跟List所宣告的字串一樣，不然就會造成錯誤，StringUI對JsonRead<T>裡面的List<T> StringUI

        JsonRead<StringUI> FileJson = JsonUtility.FromJson<JsonRead<StringUI>>(dataread);

        Debug.Log("STRING的字串內容" + dataread);

        foreach (StringUI data in FileJson.StringUI)
        {
            if (data.id == i)
            {
                Debug.Log("從PublicFuniction呼叫而來的功能\n" + data.stringui);
                ReturnString = data.stringui;
            }
        }

        //讀取json檔案轉成字串，但因為json檔案格式無法被JsonUtility反序列化(JsonUtility沒有支援多維陣列)，但JsonUtility可以反序列化List，所以把讀取檔案的字串包進一個名稱為StringUI的List裡面
        //讓JsonUtility去反序列化StringUI這個List，這樣就可以反序列化Json檔案裡的多維陣列，因為對JsonUtility而言StringUI這個List是一個一維陣列*/

        //在JsonUtility的眼裡StringUI這個List是長以下樣子，JsonUtility沒有在在意[]裡面是甚麼

        //{
        //  "StringUI":
        //  []
       // } 
    }

    public void ReadCharaterArm(int CharaterNum, int Armid)                                        //用來讀取角色裝備的指定ID裝備
    {
        string CharaterArmFileName = "Charater_" + CharaterNum + "_Arm";
        ReadPlatformpersistentDataPath(CharaterArmFileName);
        string DataRead = File.ReadAllText(persistentFilePath);

        JsonCharaterArm<CharaterArm> FileJson = JsonUtility.FromJson<JsonCharaterArm<CharaterArm>>(DataRead);

        foreach (CharaterArm Data in FileJson.CharaterArm)
        {
            if(Data.id == Armid)
            {
                Debug.Log("裝備id:" + Data.id);

                CharaterArmStatic.id = Data.id;
                CharaterArmStatic.ArmPower_1 = Data.ArmPower_1;
                CharaterArmStatic.ArmPower_2 = Data.ArmPower_2;
                CharaterArmStatic.ArmPower_3 = Data.ArmPower_3;
                CharaterArmStatic.ArmPower_4 = Data.ArmPower_4;
                CharaterArmStatic.ArmPower_5 = Data.ArmPower_5;
                CharaterArmStatic.ArmPower_6 = Data.ArmPower_6;
                CharaterArmStatic.ArmBasicId = Data.ArmBasicId;
                CharaterArmStatic.ArmEquip = Data.ArmEquip;
                CharaterArmStatic.ArmMain = Data.ArmMain;
                CharaterArmStatic.PowerMin_1 = Data.PowerMin_1;
                CharaterArmStatic.PowerMax_1 = Data.PowerMax_1;
                CharaterArmStatic.PowerMin_2 = Data.PowerMin_2;
                CharaterArmStatic.PowerMax_2 = Data.PowerMax_2;
                CharaterArmStatic.PowerMin_3 = Data.PowerMin_3;
                CharaterArmStatic.PowerMax_3 = Data.PowerMax_3;
                CharaterArmStatic.PowerMin_4 = Data.PowerMin_4;
                CharaterArmStatic.PowerMax_4 = Data.PowerMax_4;
                CharaterArmStatic.PowerMin_5 = Data.PowerMin_5;
                CharaterArmStatic.PowerMax_5 = Data.PowerMax_5;
                CharaterArmStatic.PowerMin_6 = Data.PowerMin_6;
                CharaterArmStatic.PowerMax_6 = Data.PowerMax_6;
            }
        }
    }

    public void CreateCharaterArmFile(int CharaterNum)                                             //用來在建立角色時，一起建立角色裝備的檔案
    {
        string filename = "Charater_" + CharaterNum + "_Arm";
        ReadPlatformStreamingAssets(filename);
        string datapath = streamingFilePath;

        var ArmFile = new UnityWebRequest(datapath);
        ArmFile.downloadHandler = new DownloadHandlerBuffer();
        var something = ArmFile.SendWebRequest();
        while(!something.isDone)
        { }
        string filenew = ArmFile.downloadHandler.text;

        JsonCharaterArm< CharaterArm> FileJson = JsonUtility.FromJson<JsonCharaterArm<CharaterArm>>(filenew);
        ReadPlatformpersistentDataPath(filename);
        filenew = JsonUtility.ToJson(FileJson);
        File.WriteAllText(persistentFilePath, filenew);
    }

    public void ReadCharaterPropertyFileFunction(int CharaterNum)                                  //讀取角色資料CharaterProperty
    {
        CharaterPropertyFile = "Charater_" + CharaterNum;
        ReadPlatformpersistentDataPath(CharaterPropertyFile);
        ReadCharaterPropertyFile = File.ReadAllText(persistentFilePath);
        CharaterPropertyValue = JsonUtility.FromJson<CharaterProperty>(ReadCharaterPropertyFile);
        CharaterPropertyConversion();
    }

    public void ReadPlatformStreamingAssets(string FileName)                                       //因為平台的不同會導致程式讀取檔案的路徑不同，所以特定寫一個判斷目前是用甚麼平台來開啟此app
    {
        //此function用來找在streamingAssets裡面的檔案路徑

        if (Application.platform == RuntimePlatform.Android)
        {
            string jsonpath = Application.streamingAssetsPath + "/Json";
            string jsonfile = FileName + ".json";
            string datapath = Path.Combine(jsonpath, jsonfile);

            streamingFilePath = datapath;
        }
        if (Application.platform != RuntimePlatform.Android)
        {
            string jsonpath = Application.dataPath + "/StreamingAssets" + "/Json";
            string jsonfile = FileName + ".json";
            string datapath = Path.Combine(jsonpath, jsonfile);

            streamingFilePath = datapath;
        }
    }

    public void ReadPlatformpersistentDataPath(string FileName)                                    //因為平台的不同會導致程式讀取檔案的路徑不同，所以特定寫一個判斷目前是用甚麼平台來開啟此app
    {
        //此function用來找在persistentDataPath裡面的檔案路徑

        if (Application.platform == RuntimePlatform.Android)
        {
            string jsonpath = Application.persistentDataPath;
            string jsonfile = FileName + ".json";
            string datapath = Path.Combine(jsonpath, jsonfile);

            persistentFilePath = datapath;
        }
        if (Application.platform != RuntimePlatform.Android)
        {
            string jsonpath = Application.persistentDataPath;
            string jsonfile = FileName + ".json";
            string datapath = Path.Combine(jsonpath, jsonfile);

            persistentFilePath = datapath;
        }
    }

    public void CreateStorepersistentDataPath()                                                    //因為存在StreamingAsset的檔案只能讀取無法寫入，所以要複製一份檔案出來給persistentDataPath路徑裡的新檔案來做之後讀取寫入的檔案
    {
        //這個function只有用在建立Store.json這個檔案
        string StoreFileName = "Store";
        ReadPlatformStreamingAssets(StoreFileName);                                                //判斷開啟app的平台
        string datapath = streamingFilePath;

        var StoreSile = new UnityWebRequest(datapath);                                             //原本檔案在StreamingAssets裡是只能使用WWW來賭取檔案，但WWW已經是過時的用法，要改成使用UnityWebRequest來讀取檔案
        StoreSile.downloadHandler = new DownloadHandlerBuffer();
        var something = StoreSile.SendWebRequest();
        while(!something.isDone)
        { }
        ReadPlatformpersistentDataPath(StoreFileName);
        File.WriteAllText(persistentFilePath, StoreSile.downloadHandler.text);
    }

    public void CharaterPropertyConversion()                                                       //讀取CharaterProperty的Json檔案，並且轉成靜態資料
    {
        CharaterPropertyStatic.CharaterSex = CharaterPropertyValue.CharaterSex;
        CharaterPropertyStatic.CharaterProperty_Strength = CharaterPropertyValue.CharaterProperty_Strength;
        CharaterPropertyStatic.CharaterProperty_Intelligence = CharaterPropertyValue.CharaterProperty_Intelligence;
        CharaterPropertyStatic.CharaterProperty_Dexterity = CharaterPropertyValue.CharaterProperty_Dexterity;
        CharaterPropertyStatic.HeadSprite = CharaterPropertyValue.HeadSprite;
        CharaterPropertyStatic.BodySprite = CharaterPropertyValue.BodySprite;
        CharaterPropertyStatic.FootSprite = CharaterPropertyValue.FootSprite;
        CharaterPropertyStatic.CharaterLevel = CharaterPropertyValue.CharaterLevel;
        CharaterPropertyStatic.CharaterName = CharaterPropertyValue.CharaterName;
        CharaterPropertyStatic.CharaterJobName = CharaterPropertyValue.CharaterJobName;

        CharaterPropertyStatic.CharaterPhysicalDamgeMin = CharaterPropertyValue.CharaterPhysicalDamgeMin;
        CharaterPropertyStatic.CharaterPhysicalDamgeMax = CharaterPropertyValue.CharaterPhysicalDamgeMax;
        CharaterPropertyStatic.CharaterDodge = CharaterPropertyValue.CharaterDodge;
        CharaterPropertyStatic.CharaterDodgeRate = CharaterPropertyValue.CharaterDodgeRate;
        CharaterPropertyStatic.CharaterDodgeMax = CharaterPropertyValue.CharaterDodgeMax;
        CharaterPropertyStatic.CharaterCritical = CharaterPropertyValue.CharaterCritical;
        CharaterPropertyStatic.CharaterCriticalRate = CharaterPropertyValue.CharaterCriticalRate;
        CharaterPropertyStatic.CharaterCriticalMax = CharaterPropertyValue.CharaterCriticalMax;
        CharaterPropertyStatic.CharaterMagicDamgeMin = CharaterPropertyValue.CharaterMagicDamgeMin;
        CharaterPropertyStatic.CharaterMagicDamgeMax = CharaterPropertyValue.CharaterMagicDamgeMax;
        CharaterPropertyStatic.CharaterHp = CharaterPropertyValue.CharaterHp;
        CharaterPropertyStatic.CharaterMp = CharaterPropertyValue.CharaterMp;
        CharaterPropertyStatic.CharaterHpRecover = CharaterPropertyValue.CharaterHpRecover;
        CharaterPropertyStatic.CharaterMpRecover = CharaterPropertyValue.CharaterMpRecover;
        CharaterPropertyStatic.CharaterPhysicalResist = CharaterPropertyValue.CharaterPhysicalResist;
        CharaterPropertyStatic.CharaterPhysicalResistRate = CharaterPropertyValue.CharaterPhysicalResistRate;
        CharaterPropertyStatic.CharaterPhysicalResistMax = CharaterPropertyValue.CharaterPhysicalResistMax;
        CharaterPropertyStatic.CharaterMagicShield = CharaterPropertyValue.CharaterMagicShield;
        CharaterPropertyStatic.CharaterMagicShieldRecover = CharaterPropertyValue.CharaterMagicShieldRecover;
        CharaterPropertyStatic.CharaterExp = CharaterPropertyValue.CharaterExp;
        CharaterPropertyStatic.CharaterHpNow = CharaterPropertyValue.CharaterHpNow;
        CharaterPropertyStatic.CharaterMpNow = CharaterPropertyValue.CharaterMpNow;
        CharaterPropertyStatic.CharaterNumber = CharaterPropertyValue.CharaterNumber;
        CharaterPropertyStatic.CharaterLastPoint = CharaterPropertyValue.CharaterLastPoint;
        CharaterPropertyStatic.CharaterHpNowRate = CharaterPropertyValue.CharaterHpNowRate;
        CharaterPropertyStatic.CharaterMpNowRate = CharaterPropertyValue.CharaterMpNowRate;
        CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyValue.CharaterMagicShieldNow;
        CharaterPropertyStatic.CharaterAttackSpeed = CharaterPropertyValue.CharaterAttackSpeed;
        CharaterPropertyStatic.CharaterMoney = CharaterPropertyValue.CharaterMoney;
        CharaterPropertyStatic.CharaterLastMap = CharaterPropertyValue.CharaterLastMap;
        CharaterPropertyStatic.CharaterNowMap = CharaterPropertyValue.CharaterNowMap;
    }
    
    public void CharaterPropertyStaticChange()                                                     //當靜態資料有更動，並且需要存檔，就要將靜態資料先轉成可序列化資料再儲存成Json檔案
    {
        CharaterPropertyValue.Charater = CharaterPropertyStatic.Charater;
        CharaterPropertyValue.CharaterSex = CharaterPropertyStatic.CharaterSex;
        CharaterPropertyValue.CharaterProperty_Strength = CharaterPropertyStatic.CharaterProperty_Strength;
        CharaterPropertyValue.CharaterProperty_Intelligence = CharaterPropertyStatic.CharaterProperty_Intelligence;
        CharaterPropertyValue.CharaterProperty_Dexterity = CharaterPropertyStatic.CharaterProperty_Dexterity;
        CharaterPropertyValue.HeadSprite = CharaterPropertyStatic.HeadSprite;
        CharaterPropertyValue.BodySprite = CharaterPropertyStatic.BodySprite;
        CharaterPropertyValue.FootSprite = CharaterPropertyStatic.FootSprite;
        CharaterPropertyValue.CharaterLevel = CharaterPropertyStatic.CharaterLevel;
        CharaterPropertyValue.CharaterName = CharaterPropertyStatic.CharaterName;
        CharaterPropertyValue.CharaterJobName = CharaterPropertyStatic.CharaterJobName;

        CharaterPropertyValue.CharaterPhysicalDamgeMin = CharaterPropertyStatic.CharaterPhysicalDamgeMin;
        CharaterPropertyValue.CharaterPhysicalDamgeMax = CharaterPropertyStatic.CharaterPhysicalDamgeMax;
        CharaterPropertyValue.CharaterDodge = CharaterPropertyStatic.CharaterDodge;
        CharaterPropertyValue.CharaterDodgeRate = CharaterPropertyStatic.CharaterDodgeRate;
        CharaterPropertyValue.CharaterDodgeMax = CharaterPropertyStatic.CharaterDodgeMax;
        CharaterPropertyValue.CharaterCritical = CharaterPropertyStatic.CharaterCritical;
        CharaterPropertyValue.CharaterCriticalRate = CharaterPropertyStatic.CharaterCriticalRate;
        CharaterPropertyValue.CharaterCriticalMax = CharaterPropertyStatic.CharaterCriticalMax;
        CharaterPropertyValue.CharaterMagicDamgeMin = CharaterPropertyStatic.CharaterMagicDamgeMin;
        CharaterPropertyValue.CharaterMagicDamgeMax = CharaterPropertyStatic.CharaterMagicDamgeMax;
        CharaterPropertyValue.CharaterHp = CharaterPropertyStatic.CharaterHp;
        CharaterPropertyValue.CharaterMp = CharaterPropertyStatic.CharaterMp;
        CharaterPropertyValue.CharaterHpRecover = CharaterPropertyStatic.CharaterHpRecover;
        CharaterPropertyValue.CharaterMpRecover = CharaterPropertyStatic.CharaterMpRecover;
        CharaterPropertyValue.CharaterPhysicalResist = CharaterPropertyStatic.CharaterPhysicalResist;
        CharaterPropertyValue.CharaterPhysicalResistRate = CharaterPropertyStatic.CharaterPhysicalResistRate;
        CharaterPropertyValue.CharaterPhysicalResistMax = CharaterPropertyStatic.CharaterPhysicalResistMax;
        CharaterPropertyValue.CharaterMagicShield = CharaterPropertyStatic.CharaterMagicShield;
        CharaterPropertyValue.CharaterMagicShieldRecover = CharaterPropertyStatic.CharaterMagicShieldRecover;
        CharaterPropertyValue.CharaterExp = CharaterPropertyStatic.CharaterExp;
        CharaterPropertyValue.CharaterHpNow = CharaterPropertyStatic.CharaterHpNow;
        CharaterPropertyValue.CharaterMpNow = CharaterPropertyStatic.CharaterMpNow;
        CharaterPropertyValue.CharaterNumber = CharaterPropertyStatic.CharaterNumber;
        CharaterPropertyValue.CharaterLastPoint = CharaterPropertyStatic.CharaterLastPoint;
        CharaterPropertyValue.CharaterHpNowRate = CharaterPropertyStatic.CharaterHpNowRate;
        CharaterPropertyValue.CharaterMpNowRate = CharaterPropertyStatic.CharaterMpNowRate;
        CharaterPropertyValue.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShieldNow;
        CharaterPropertyValue.CharaterAttackSpeed = CharaterPropertyStatic.CharaterAttackSpeed;
        CharaterPropertyValue.CharaterMoney = CharaterPropertyStatic.CharaterMoney;
        CharaterPropertyValue.CharaterLastMap = CharaterPropertyStatic.CharaterLastMap;
        CharaterPropertyValue.CharaterNowMap = CharaterPropertyStatic.CharaterNowMap;
    }

    public void ChangeSpriteSize(GameObject SpriteName, float InputRealWidth, float InputRealHeight , float InputOtherNum , int ChooseChangeSize)    //當圖片需要依照數值的百分比做圖片大小的變化
    {
        float InputWidth;
        //float InputHeight;
        //float SpriteWidth, SpriteHeight;
        //SpriteWidth = SpriteName.GetComponent<RectTransform>().rect.width;
        //SpriteHeight = SpriteName.GetComponent<RectTransform>().rect.height;

        switch (ChooseChangeSize)
		{
            case 0:           //需要改變的只有圖片的寬Width
                {
                    InputWidth = InputRealWidth / InputOtherNum;
                    string InputWidthString = InputWidth.ToString("0.00");
                    float InputWidthFloat = float.Parse(InputWidthString);
                    //SpriteName.GetComponent<RectTransform>().sizeDelta = new Vector2(InputWidthFloat * SpriteWidth, SpriteHeight);   //這是改變物件的長寬，但有可能會導致數值越來越小
                    SpriteName.GetComponent<RectTransform>().localScale = new Vector3(InputWidthFloat, 1, 1);                      //改成使用物件的Scale來顯示，改善本來圖片會負值的可能
                    break;
				}
            case 1:           //需要改變的只有圖片的高Height
                {
                    break;
				}
            case 2:           //需要改變的圖片的寬跟高
                {
                    break;
				}
		}
    }

    public void CharaterFileCalculate(int OldS, int OldI, int OldD)                                //給創角色的計算用，之後則各別寫，用來當角色能力有所修改時，這裡可以計算受到影響的其他角色能力，並計算成正確的數值讓其他地方可以取用
    {
        switch(CharaterPropertyValue.CharaterProperty_Strength == OldS)
        {
            case true:
                {
                    break;
                }
            case false:
                {
                    float OldHp =CharaterPropertyValue.CharaterHp - (10 + (OldS * 10));
                    CharaterPropertyValue.CharaterHp = OldHp + 10 + (CharaterPropertyValue.CharaterProperty_Strength * 10);
                    float OldMax = CharaterPropertyValue.CharaterPhysicalDamgeMax - (1 + (OldS * 10));
                    CharaterPropertyValue.CharaterPhysicalDamgeMax = OldMax + 1 + (CharaterPropertyValue.CharaterProperty_Strength * 10);
                    CharaterPropertyValue.CharaterHpNow = CharaterPropertyValue.CharaterHp * (CharaterPropertyValue.CharaterHpNowRate / 100);
                    CharaterPropertyValue.CharaterHpNow = Mathf.Round(CharaterPropertyValue.CharaterHpNow);
                    break;
                }
        }
        switch(CharaterPropertyValue.CharaterProperty_Intelligence == OldI)
        {
            case true:
                {
                    break;
                }
            case false:
                {
                    float OldMp = CharaterPropertyValue.CharaterMp - (10 + (OldI * 10));
                    CharaterPropertyValue.CharaterMp = OldMp + 10 + (CharaterPropertyValue.CharaterProperty_Intelligence * 10);
                    float OldMMin = CharaterPropertyValue.CharaterMagicDamgeMin - (OldI * 5);
                    CharaterPropertyValue.CharaterMagicDamgeMin = OldMMin + (CharaterPropertyValue.CharaterProperty_Intelligence * 5);
                    float OldMMax = CharaterPropertyValue.CharaterMagicDamgeMax - (OldI * 10);
                    CharaterPropertyValue.CharaterMagicDamgeMax = OldMMax + (CharaterPropertyValue.CharaterProperty_Intelligence * 10);
                    CharaterPropertyValue.CharaterMpNow = CharaterPropertyValue.CharaterMp * (CharaterPropertyValue.CharaterMpNowRate / 100);
                    CharaterPropertyValue.CharaterMpNow = Mathf.Round(CharaterPropertyValue.CharaterMpNow);
                    break;
                }
        }
        switch(CharaterPropertyValue.CharaterProperty_Dexterity == OldD)
        {
            case true:
                {
                    break;
                }
            case false:
                {
                    CharaterPropertyValue.CharaterDodge = CharaterPropertyValue.CharaterProperty_Dexterity;
                    CharaterPropertyValue.CharaterDodgeRate = (CharaterPropertyValue.CharaterDodge / CharaterPropertyValue.CharaterDodgeMax) * 100;
                    CharaterPropertyValue.CharaterDodgeRate = Mathf.Round(CharaterPropertyValue.CharaterDodgeRate);
                    CharaterPropertyValue.CharaterCritical = CharaterPropertyValue.CharaterProperty_Dexterity;
                    CharaterPropertyValue.CharaterCriticalRate = (CharaterPropertyValue.CharaterCritical / CharaterPropertyValue.CharaterCriticalMax) * 100;
                    CharaterPropertyValue.CharaterCriticalRate = Mathf.Round(CharaterPropertyValue.CharaterCriticalRate);
                    CharaterPropertyValue.CharaterDodgeMax = CharaterPropertyValue.CharaterLevel * 10;
                    CharaterPropertyValue.CharaterCriticalMax = CharaterPropertyValue.CharaterLevel * 10;
                    break;
                }
        }
        switch(CharaterPropertyValue.CharaterPhysicalResistRate == (CharaterPropertyValue.CharaterPhysicalResist / CharaterPropertyValue.CharaterPhysicalResistMax) * 100)
        {
            case true:
                {
                    break;
                }
            case false:
                {
                    CharaterPropertyValue.CharaterPhysicalResistRate = (CharaterPropertyValue.CharaterPhysicalResist / CharaterPropertyValue.CharaterPhysicalResistMax) * 100;
                    break;
                }
        }
        
        
        /*//-----力量相關計算
        if (CharaterPropertyValue.CharaterHp == 10 + (CharaterPropertyValue.CharaterProperty_Strength * 10))
        {
            //CharaterPropertyValue.CharaterHp = 10 + (CharaterPropertyValue.CharaterProperty_Strength * 10);
        }
        if (CharaterPropertyValue.CharaterPhysicalDamgeMax == 1 + (CharaterPropertyValue.CharaterProperty_Strength * 10))
        {
            //CharaterPropertyValue.CharaterPhysicalDamgeMax = 1 + (CharaterPropertyValue.CharaterProperty_Strength * 10);
        }
        if (CharaterPropertyValue.CharaterHpNow == CharaterPropertyValue.CharaterHp)
        {
            //CharaterPropertyValue.CharaterHpNow = CharaterPropertyValue.CharaterHp * (CharaterPropertyValue.CharaterHpNowRate / 100);
            //CharaterPropertyValue.CharaterHpNow = Mathf.Round(CharaterPropertyValue.CharaterHpNow);
        }
        if (CharaterPropertyValue.CharaterHp != 10 + (CharaterPropertyValue.CharaterProperty_Strength * 10))
        {
            CharaterPropertyValue.CharaterHp = CharaterPropertyValue.CharaterHp - (10 + (OldS * 10));
            CharaterPropertyValue.CharaterHp = CharaterPropertyValue.CharaterHp + 10 + (CharaterPropertyValue.CharaterProperty_Strength * 10);
        }
        if(CharaterPropertyValue.CharaterPhysicalDamgeMax != 1 + (CharaterPropertyValue.CharaterProperty_Strength * 10))
        {
            CharaterPropertyValue.CharaterPhysicalDamgeMax = CharaterPropertyValue.CharaterPhysicalDamgeMax - (1 + (OldS * 10));
            CharaterPropertyValue.CharaterPhysicalDamgeMax = CharaterPropertyValue.CharaterPhysicalDamgeMax + 1 + (CharaterPropertyValue.CharaterProperty_Strength * 10);
        }
        if (CharaterPropertyValue.CharaterHpNow != CharaterPropertyValue.CharaterHp)
        {
            CharaterPropertyValue.CharaterHpNow = CharaterPropertyValue.CharaterHp * (CharaterPropertyValue.CharaterHpNowRate / 100);
            CharaterPropertyValue.CharaterHpNow = Mathf.Round(CharaterPropertyValue.CharaterHpNow);
        }
        //-----

        //-----智力相關計算
        if (CharaterPropertyValue.CharaterMp == 10 + (CharaterPropertyValue.CharaterProperty_Intelligence * 10))
        {
            //CharaterPropertyValue.CharaterMp = 10 + (CharaterPropertyValue.CharaterProperty_Intelligence * 10);
        }
        if (CharaterPropertyValue.CharaterMagicDamgeMin == CharaterPropertyValue.CharaterProperty_Intelligence * 5)
        {
            //CharaterPropertyValue.CharaterMagicDamgeMin = CharaterPropertyValue.CharaterProperty_Intelligence * 5;
        }
        if (CharaterPropertyValue.CharaterMagicDamgeMax == CharaterPropertyValue.CharaterProperty_Intelligence * 10)
        {
            //CharaterPropertyValue.CharaterMagicDamgeMax = CharaterPropertyValue.CharaterProperty_Intelligence * 10;
        }
        if (CharaterPropertyValue.CharaterMpNow == CharaterPropertyValue.CharaterMp)
        {
            //CharaterPropertyValue.CharaterMpNow = CharaterPropertyValue.CharaterMp * (CharaterPropertyValue.CharaterMpNowRate / 100);
            //CharaterPropertyValue.CharaterMpNow = Mathf.Round(CharaterPropertyValue.CharaterMpNow);
        }
        if (CharaterPropertyValue.CharaterMp != 10 + (CharaterPropertyValue.CharaterProperty_Intelligence * 10))
        {
            CharaterPropertyValue.CharaterMp = CharaterPropertyValue.CharaterMp - (10 + (OldI * 10));
            CharaterPropertyValue.CharaterMp = CharaterPropertyValue.CharaterMp + (CharaterPropertyValue.CharaterProperty_Intelligence * 10);
        }
        if (CharaterPropertyValue.CharaterMagicDamgeMin != CharaterPropertyValue.CharaterProperty_Intelligence * 5)
        {
            CharaterPropertyValue.CharaterMagicDamgeMin = CharaterPropertyValue.CharaterMagicDamgeMin - (OldI * 5);
            CharaterPropertyValue.CharaterMagicDamgeMin = CharaterPropertyValue.CharaterProperty_Intelligence * 5;
        }
        if (CharaterPropertyValue.CharaterMagicDamgeMax != CharaterPropertyValue.CharaterProperty_Intelligence * 10)
        {
            CharaterPropertyValue.CharaterMagicDamgeMax = CharaterPropertyValue.CharaterMagicDamgeMax - (OldI * 10);
            CharaterPropertyValue.CharaterMagicDamgeMax = CharaterPropertyValue.CharaterProperty_Intelligence * 10;
        }
        if (CharaterPropertyValue.CharaterMpNow != CharaterPropertyValue.CharaterMp)
        {
            CharaterPropertyValue.CharaterMpNow = CharaterPropertyValue.CharaterMp * (CharaterPropertyValue.CharaterMpNowRate / 100);
            CharaterPropertyValue.CharaterMpNow = Mathf.Round(CharaterPropertyValue.CharaterMpNow);
        }
        //-----

        //-----敏捷相關計算
        if (CharaterPropertyValue.CharaterDodgeRate == (CharaterPropertyValue.CharaterDodge / CharaterPropertyValue.CharaterDodgeMax) * 100)
        {
            //CharaterPropertyValue.CharaterDodgeRate = (CharaterPropertyValue.CharaterDodge / CharaterPropertyValue.CharaterDodgeMax) * 100;
        }
        if (CharaterPropertyValue.CharaterCriticalRate == (CharaterPropertyValue.CharaterCritical / CharaterPropertyValue.CharaterCriticalMax) * 100)
        {
            //CharaterPropertyValue.CharaterCriticalRate = (CharaterPropertyValue.CharaterCritical / CharaterPropertyValue.CharaterCriticalMax) * 100;
        }
        if (CharaterPropertyValue.CharaterDodgeMax == CharaterPropertyValue.CharaterLevel * 10)
        {
            //CharaterPropertyValue.CharaterDodgeMax = CharaterPropertyValue.CharaterLevel * 10;
        }
        if (CharaterPropertyValue.CharaterCriticalMax == CharaterPropertyValue.CharaterLevel * 10)
        {
            //CharaterPropertyValue.CharaterCriticalMax = CharaterPropertyValue.CharaterLevel * 10;
        }
        if (CharaterPropertyValue.CharaterDodgeRate != (CharaterPropertyValue.CharaterDodge/ CharaterPropertyValue.CharaterDodgeMax) * 100)
        {
            CharaterPropertyValue.CharaterDodge = (CharaterPropertyValue.CharaterDodge - OldD) + CharaterPropertyValue.CharaterProperty_Dexterity;
            CharaterPropertyValue.CharaterDodgeRate = (CharaterPropertyValue.CharaterDodge / CharaterPropertyValue.CharaterDodgeMax) * 100;
        }
        if (CharaterPropertyValue.CharaterCriticalRate != (CharaterPropertyValue.CharaterCritical / CharaterPropertyValue.CharaterCriticalMax) * 100)
        {
            CharaterPropertyValue.CharaterCritical = (CharaterPropertyValue.CharaterCritical - OldD) + CharaterPropertyValue.CharaterProperty_Dexterity;
            CharaterPropertyValue.CharaterCriticalRate = (CharaterPropertyValue.CharaterCritical / CharaterPropertyValue.CharaterCriticalMax) * 100;
        }
        if (CharaterPropertyValue.CharaterDodgeMax != CharaterPropertyValue.CharaterLevel * 10)
        {
            CharaterPropertyValue.CharaterDodgeMax = CharaterPropertyValue.CharaterLevel * 10;
        }
        if (CharaterPropertyValue.CharaterCriticalMax != CharaterPropertyValue.CharaterLevel * 10)
        {
            CharaterPropertyValue.CharaterCriticalMax = CharaterPropertyValue.CharaterLevel * 10;
        }
        //-----

        //-----其餘計算
        if (CharaterPropertyValue.CharaterPhysicalResistRate == (CharaterPropertyValue.CharaterPhysicalResist / CharaterPropertyValue.CharaterPhysicalResistMax) * 100)
        {
            //CharaterPropertyValue.CharaterPhysicalResistRate = (CharaterPropertyValue.CharaterPhysicalResist / CharaterPropertyValue.CharaterPhysicalResistMax) * 100;
        }
        if (CharaterPropertyValue.CharaterPhysicalResistRate != (CharaterPropertyValue.CharaterPhysicalResist / CharaterPropertyValue.CharaterPhysicalResistMax) * 100)
        {
            CharaterPropertyValue.CharaterPhysicalResistRate = (CharaterPropertyValue.CharaterPhysicalResist / CharaterPropertyValue.CharaterPhysicalResistMax) * 100;
        }
        //-----   */   
    }

    public void ReadCharaterExp()                                                                  //用來讀取角色升級所需要的經驗值
    {
        string ExpFileName = "CharaterExp";
        string FilePath;
        string FileInside;

        if (Application.platform == RuntimePlatform.Android)
        {
            string jsonpath = Application.streamingAssetsPath + "/Json";
            string jsonfile = ExpFileName + ".json";
            string datapath = Path.Combine(jsonpath, jsonfile);

            FilePath = datapath;
        }
        else
        {
            string jsonpath = Application.dataPath + "/StreamingAssets" + "/Json";
            string jsonfile = ExpFileName + ".json";
            string datapath = Path.Combine(jsonpath, jsonfile);

            FilePath = datapath;
        }

        FileInside = File.ReadAllText(FilePath);
        FileInside = "{ \"CharaterExp\": " + FileInside + "}";
        JsonExp<CharaterExp> CharaterExpFile = JsonUtility.FromJson <JsonExp<CharaterExp>> (FileInside);

        foreach(CharaterExp data in CharaterExpFile.CharaterExp)
        {
            if(data.CharaterLevel == CharaterPropertyStatic.CharaterLevel)
            {
                CharaterPropertyStatic.CharaterExp = data.CharaterNeedExp;
            }
        }
    }

    public void ReadArmPower(int PowerId)                                                          //讀取特定詞綴的內容
    {
        string jsonfile = "PowerList";
        ReadPlatformStreamingAssets(jsonfile);
        string datapath = streamingFilePath;

        var newfile = new UnityWebRequest(datapath);
        newfile.downloadHandler = new DownloadHandlerBuffer();
        var something = newfile.SendWebRequest();
        while(!something.isDone)
        { }
        string newfileinsdie = newfile.downloadHandler.text;      

        JsonPower<ArmPowerList> FileJson = JsonUtility.FromJson<JsonPower<ArmPowerList>>(newfileinsdie);

        foreach(ArmPowerList Data in FileJson.ArmPowerList)
        {
            if(Data.Id == PowerId)
            {
                ArmPowerListStatic.Id = Data.Id;
                ArmPowerListStatic.PowerLevelMin = Data.PowerLevelMin;
                ArmPowerListStatic.PowerLevelMax = Data.PowerLevelMax;
                ArmPowerListStatic.PowerType = Data.PowerType;
                ArmPowerListStatic.PowerName = Data.PowerName;
                ArmPowerListStatic.Power_0_Min = Data.Power_0_Min;
                ArmPowerListStatic.Power_0_Max = Data.Power_0_Max;
                ArmPowerListStatic.Power_1_Min = Data.Power_1_Min;
                ArmPowerListStatic.Power_1_Max = Data.Power_1_Max;
            }
        }
    }
   
    public void RandonArmPower(int CharaterNum, int ArmId)                                         //用來給予特定裝備上詞綴的數值
    {
        string CharaterArmFileName = "Charater_" + CharaterNum + "_Arm";
        ReadPlatformpersistentDataPath(CharaterArmFileName);
        string ArmFile = File.ReadAllText(persistentFilePath);

        JsonCharaterArm<CharaterArm> FileJson = JsonUtility.FromJson<JsonCharaterArm<CharaterArm>>(ArmFile);

        foreach (CharaterArm Data in FileJson.CharaterArm)
        {
            if(Data.id == ArmId)
            {
                for(int PowerId = 1; PowerId < 7; PowerId++)
                {
                    switch(PowerId)
                    {
                        case 1:
                            {
                                int PowerNum = Data.ArmPower_1;
                                if(PowerNum == 0)
                                {

                                }
                                if(PowerNum != 0)
                                {
                                    ReadArmPower(PowerNum);
                                    switch(ArmPowerListStatic.PowerType)
                                    {
                                        case 0:
                                            {
                                                float RandomPowerNum = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max + 1);
                                                Data.PowerMin_1 = Mathf.Round(RandomPowerNum);
                                                break;
                                            }
                                        case 1:
                                            {
                                                float RandomPowerNum_0 = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max + 1);
                                                float RandomPowerNum_1 = UnityEngine.Random.Range(ArmPowerListStatic.Power_1_Min, ArmPowerListStatic.Power_1_Max + 1);
                                                Data.PowerMin_1 = Mathf.Round(RandomPowerNum_0);
                                                Data.PowerMax_1 = Mathf.Round(RandomPowerNum_1);
                                                break;
                                            }
                                    }
                                }
                                break;
                            }
                        case 2:
                            {
                                int PowerNum = Data.ArmPower_2;
                                if (PowerNum == 0)
                                {

                                }
                                if (PowerNum != 0)
                                {
                                    ReadArmPower(PowerNum);
                                    switch(ArmPowerListStatic.PowerType)
                                    {
                                        case 0:
                                            {
                                                float RandomPowerNum = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max + 1);
                                                Data.PowerMin_2 = Mathf.Round(RandomPowerNum);
                                                break;
                                            }
                                        case 1:
                                            {
                                                float RandomPowerNum_0 = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max + 1);
                                                float RandomPowerNum_1 = UnityEngine.Random.Range(ArmPowerListStatic.Power_1_Min, ArmPowerListStatic.Power_1_Max + 1);
                                                Data.PowerMin_2 = Mathf.Round(RandomPowerNum_0);
                                                Data.PowerMax_2 = Mathf.Round(RandomPowerNum_1);
                                                break;
                                            }
                                    }
                                }
                                break;
                            }
                        case 3:
                            {
                                int PowerNum = Data.ArmPower_3;
                                if (PowerNum == 0)
                                {

                                }
                                if (PowerNum != 0)
                                {
                                    ReadArmPower(PowerNum);
                                    switch(ArmPowerListStatic.PowerType)
                                    {
                                        case 0:
                                            {
                                                float RandomPowerNum = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max + 1);
                                                Data.PowerMin_3 = Mathf.Round(RandomPowerNum);
                                                break;
                                            }
                                        case 1:
                                            {
                                                float RandomPowerNum_0 = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max + 1);
                                                float RandomPowerNum_1 = UnityEngine.Random.Range(ArmPowerListStatic.Power_1_Min, ArmPowerListStatic.Power_1_Max + 1);
                                                Data.PowerMin_3 = Mathf.Round(RandomPowerNum_0);
                                                Data.PowerMax_3 = Mathf.Round(RandomPowerNum_1);
                                                break;
                                            }
                                    }
                                }
                                break;
                            }
                        case 4:
                            {
                                int PowerNum = Data.ArmPower_4;
                                if (PowerNum == 0)
                                {

                                }
                                if (PowerNum != 0)
                                {
                                    ReadArmPower(PowerNum);
                                    switch(ArmPowerListStatic.PowerType)
                                    {
                                        case 0:
                                            {
                                                float RandomPowerNum = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max + 1);
                                                Data.PowerMin_4 = Mathf.Round(RandomPowerNum);
                                                break;
                                            }
                                        case 1:
                                            {
                                                float RandomPowerNum_0 = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max + 1);
                                                float RandomPowerNum_1 = UnityEngine.Random.Range(ArmPowerListStatic.Power_1_Min, ArmPowerListStatic.Power_1_Max + 1);
                                                Data.PowerMin_4 = Mathf.Round(RandomPowerNum_0);
                                                Data.PowerMax_4 = Mathf.Round(RandomPowerNum_1);
                                                break;
                                            }
                                    }
                                }
                                break;
                            }
                        case 5:
                            {
                                int PowerNum = Data.ArmPower_5;
                                if (PowerNum == 0)
                                {

                                }
                                if (PowerNum != 0)
                                {
                                    ReadArmPower(PowerNum);
                                    switch(ArmPowerListStatic.PowerType)
                                    {
                                        case 0:
                                            {
                                                float RandomPowerNum = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max + 1);
                                                Data.PowerMin_5 = Mathf.Round(RandomPowerNum);
                                                break;
                                            }
                                        case 1:
                                            {
                                                float RandomPowerNum_0 = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max + 1);
                                                float RandomPowerNum_1 = UnityEngine.Random.Range(ArmPowerListStatic.Power_1_Min, ArmPowerListStatic.Power_1_Max + 1);
                                                Data.PowerMin_5 = Mathf.Round(RandomPowerNum_0);
                                                Data.PowerMax_5 = Mathf.Round(RandomPowerNum_1);
                                                break;
                                            }
                                    }
                                }
                                break;
                            }
                        case 6:
                            {
                                int PowerNum = Data.ArmPower_6;
                                if (PowerNum == 0)
                                {

                                }
                                if (PowerNum != 0)
                                {
                                    ReadArmPower(PowerNum);
                                    switch(ArmPowerListStatic.PowerType)
                                    {
                                        case 0:
                                            {
                                                float RandomPowerNum = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max + 1);
                                                Data.PowerMin_6 = Mathf.Round(RandomPowerNum);
                                                break;
                                            }
                                        case 1:
                                            {
                                                float RandomPowerNum_0 = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max + 1);
                                                float RandomPowerNum_1 = UnityEngine.Random.Range(ArmPowerListStatic.Power_1_Min, ArmPowerListStatic.Power_1_Max + 1);
                                                Data.PowerMin_6 = Mathf.Round(RandomPowerNum_0);
                                                Data.PowerMax_6 = Mathf.Round(RandomPowerNum_1);
                                                break;
                                            }
                                    }
                                }
                                    
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
            }
        }
        ArmFile = JsonUtility.ToJson(FileJson);
        File.WriteAllText(persistentFilePath, ArmFile);
    }

    public void CreateCharaterItemFile(int CharaterNum)                                            //建立角色道具表
	{
        string filename = "Charater_" + CharaterNum + "_Item";
        ReadPlatformStreamingAssets(filename);

        var ItemFile = new UnityWebRequest(streamingFilePath);
        ItemFile.downloadHandler = new DownloadHandlerBuffer();
        var something = ItemFile.SendWebRequest();
        while(!something.isDone)
        { }
        ReadPlatformpersistentDataPath(filename);
        File.WriteAllText(persistentFilePath, ItemFile.downloadHandler.text);
    }

    public void ReadCharaterItem(int CharaterNum, int ItemNum)                                     //讀取角色身上特定編號的道具
	{
        string ItemFileName = "Charater_" + CharaterNum + "_Item";
        ReadPlatformpersistentDataPath(ItemFileName);
        string ItemFile = File.ReadAllText(persistentFilePath);
        JsonCharaterItem<CharaterItem> ItemFileJson = JsonUtility.FromJson<JsonCharaterItem<CharaterItem>>(ItemFile);

        foreach(CharaterItem data in ItemFileJson.CharaterItem)
		{
            if(data.Id == ItemNum)
			{
                CharaterItemStatic.Id = data.Id;
                CharaterItemStatic.ItemNum = data.ItemNum;
                CharaterItemStatic.ItemEquip = data.ItemEquip;
            }      
        }
    }

    public void ReadItem(int ItemNum)                                                              //從道具表裡讀取特定編號的道具
	{
        string FileName = "Item";
        ReadPlatformStreamingAssets(FileName);
        string datapath = streamingFilePath;

        var newfile = new UnityWebRequest(datapath);
        newfile.downloadHandler = new DownloadHandlerBuffer();
        var something = newfile.SendWebRequest();
        while(!something.isDone)
        { }
        string newfileinside = newfile.downloadHandler.text;

        //string ItemFile = File.ReadAllText(streamingFilePath);
        //ItemFile = "{ \"Item\": " + ItemFile + "}";

        JsonItem<Item> FileItem = JsonUtility.FromJson<JsonItem<Item>>(newfileinside);

        foreach(Item data in FileItem.Item)
		{
            if(data.Id == ItemNum)
			{
                ItemStatic.Id = data.Id;
                ItemStatic.ItemName = data.ItemName;
                ItemStatic.ItemIcon = data.ItemIcon;
                ItemStatic.ItemTag = data.ItemTag;
                ItemStatic.ItemStack = data.ItemStack;
                ItemStatic.ItemPower = data.ItemPower;
                ItemStatic.ItemPowerMin = data.ItemPowerMin;
                ItemStatic.ItemPowerMax = data.ItemPowerMax;
                ItemStatic.ItemExplain = data.ItemExplain;
                ItemStatic.ItemPowerExplain = data.ItemPowerExplain;
                ItemStatic.ItemRequest = data.ItemRequest;
                ItemStatic.ItemSell = data.ItemSell;
            }
        }
    }

    public void ItemTagSwitch(int ItemNum)                                                         //區分目前讀取道具的標籤是哪個類型
	{
        ReadItem(ItemNum);

        switch(ItemStatic.ItemTag)
		{
            case 0:
				{
                    ItemTagName = "一般道具";
                    break;
				}
            case 1:
				{
                    ItemTagName = "材料";
                    break;
				}
            case 2:
				{
                    ItemTagName = "任務道具";
                    break;
				}
		}
    }

    public void ReadMap(int Mapid)                                                                 //讀取地圖的相關資訊
	{
        string FileName = "Map";
        ReadPlatformStreamingAssets(FileName);
        string datapath = streamingFilePath;

        var newfile = new UnityWebRequest(datapath);
        newfile.downloadHandler = new DownloadHandlerBuffer();
        var something = newfile.SendWebRequest();
        while (!something.isDone)
        { }
        string newfileinside = newfile.downloadHandler.text;

        JsonMap<Map> FileItem = JsonUtility.FromJson<JsonMap<Map>>(newfileinside);

        foreach(Map data in FileItem.Map)
		{
            if(data.MapId == Mapid)
			{
                MapStatic.MapId = data.MapId;
                MapStatic.MapSprite = data.MapSprite;
                MapStatic.MapType = data.MapType;
                MapStatic.MapNpcList = data.MapNpcList;
                MapStatic.MonsterList = data.MonsterList;
                MapStatic.MapName = data.MapName;
                MapStatic.MapContent = data.MapContent;
            }
		}
    }

    public void ReadNPCList(int NpcListNum)                                                        //從NPCList裡面讀取裡面有哪些NPC編號，並將其作成陣列
	{
        string FileName = "NPCList";
        ReadPlatformStreamingAssets(FileName);
        string datapath = streamingFilePath;

        var newfile = new UnityWebRequest(datapath);
        newfile.downloadHandler = new DownloadHandlerBuffer();
        var something = newfile.SendWebRequest();
        while (!something.isDone)
        { }
        string newfileinside = newfile.downloadHandler.text;

        JsonNPCList<NPCList> FileItem = JsonUtility.FromJson<JsonNPCList<NPCList>>(newfileinside);

        foreach(NPCList data in FileItem.NPCList)
		{
            if(data.ListId == NpcListNum)
			{
                NPCListStatic.ListId = data.ListId;
                NPCListStatic.NpcList = new int[data.NpcList.Length];
                for (int Num = 0; Num < data.NpcList.Length; Num++)
				{
                    NPCListStatic.NpcList[Num] = data.NpcList[Num];
                }            
            }
		}
    }

    public void ReadNPC(int NPCNum)                                                                //從NPC表裡讀取特定編號的NPC內容
	{
        string FileName = "NPC";
        ReadPlatformStreamingAssets(FileName);
        string datapath = streamingFilePath;

        var newfile = new UnityWebRequest(datapath);
        newfile.downloadHandler = new DownloadHandlerBuffer();
        var something = newfile.SendWebRequest();
        while (!something.isDone)
        { }
        string newfileinside = newfile.downloadHandler.text;

        JsonNPC<NPC> FileItem = JsonUtility.FromJson<JsonNPC<NPC>>(newfileinside);

        foreach(NPC data in FileItem.NPC)
		{
            if(data.Id == NPCNum)
			{
                NPCStatic.Id = data.Id;
                NPCStatic.NPCName = data.NPCName;
                NPCStatic.NPCType = data.NPCType;
                NPCStatic.NPCFirstDialog = data.NPCFirstDialog;
            }
		}
    }

    public void CreateCharaterBattleSkill(int CharaterNum)                                         //建立角色戰鬥技能表
	{
        string filename = "Charater_" + CharaterNum + "_BattleSkill";
        ReadPlatformStreamingAssets(filename);
        string datapath = streamingFilePath;

        var CharaterBattleSkillFile = new UnityWebRequest(datapath);
        CharaterBattleSkillFile.downloadHandler = new DownloadHandlerBuffer();
        var something = CharaterBattleSkillFile.SendWebRequest();
        while (!something.isDone)
        { }
        string filenew = CharaterBattleSkillFile.downloadHandler.text;

        ReadPlatformpersistentDataPath(filename);
        File.WriteAllText(persistentFilePath, filenew);
    }

    public void CreateCharaterSkill(int CharaterNum)                                               //建立角色技能表
    {
        string filename = "Charater_" + CharaterNum + "_Skill";
        ReadPlatformStreamingAssets(filename);
        string datapath = streamingFilePath;

        var CharaterSkillFile = new UnityWebRequest(datapath);
        CharaterSkillFile.downloadHandler = new DownloadHandlerBuffer();
        var something = CharaterSkillFile.SendWebRequest();
        while (!something.isDone)
        { }
        string filenew = CharaterSkillFile.downloadHandler.text;

        JsonCharaterSkill<CharaterSkill> FileJson = JsonUtility.FromJson<JsonCharaterSkill<CharaterSkill>>(filenew);
        ReadPlatformpersistentDataPath(filename);
        filenew = JsonUtility.ToJson(FileJson);
        File.WriteAllText(persistentFilePath, filenew);
    }

    public void ReadMonsterList(int MonsterListId)                                                 //讀取怪物列表的資料
	{
        string FileName = "MonsterList";
        ReadPlatformStreamingAssets(FileName);
        string datapath = streamingFilePath;

        var newfile = new UnityWebRequest(datapath);
        newfile.downloadHandler = new DownloadHandlerBuffer();
        var something = newfile.SendWebRequest();
        while (!something.isDone)
        { }
        string newfileinside = newfile.downloadHandler.text;

        JsonMonsterList<MonsterList> FileItem = JsonUtility.FromJson<JsonMonsterList<MonsterList>>(newfileinside);

        foreach(MonsterList data in FileItem.MonsterList)
		{
            if(data.ListId == MonsterListId)
			{
                MonsterListStatic.ListId = data.ListId;
                MonsterListStatic.MonsterIdList = new int[data.MonsterIdList.Length];
                MonsterListStatic.MonsterIdListRate = new int[data.MonsterIdListRate.Length];
                for (int Num = 0; Num < data.MonsterIdList.Length; Num++)
                {
                    MonsterListStatic.MonsterIdList[Num] = data.MonsterIdList[Num];
                }
                for (int Num = 0; Num < data.MonsterIdListRate.Length; Num++)
                {
                    MonsterListStatic.MonsterIdListRate[Num] = data.MonsterIdListRate[Num];
                }
            }
		}
    }

    public void ReadMonster(int MonsterId)                                                         //讀取怪物的數值
    {
        string FileName = "Monster";
        ReadPlatformStreamingAssets(FileName);
        string datapath = streamingFilePath;

        var newfile = new UnityWebRequest(datapath);
        newfile.downloadHandler = new DownloadHandlerBuffer();
        var something = newfile.SendWebRequest();
        while (!something.isDone)
        { }
        string newfileinside = newfile.downloadHandler.text;

        JsonMonster<Monster> FileItem = JsonUtility.FromJson<JsonMonster<Monster>>(newfileinside);

        foreach (Monster data in FileItem.Monster)
        {
            if (data.MonsterId == MonsterId)
            {
                MonsterStatic.MonsterId = data.MonsterId;
                MonsterStatic.MonsterPhysicalDamgeMin = data.MonsterPhysicalDamgeMin;
                MonsterStatic.MonsterPhysicalDamgeMax = data.MonsterPhysicalDamgeMax;
                MonsterStatic.MonsterPhysicalDamgeLevel = data.MonsterPhysicalDamgeLevel;
                MonsterStatic.MonsterCriticalRate = data.MonsterCriticalRate;
                MonsterStatic.MonsterMagicDamgeMin = data.MonsterMagicDamgeMin;
                MonsterStatic.MonsterMagicDamgeMax = data.MonsterMagicDamgeMax;
                MonsterStatic.MonsterMagicDamgeLevel = data.MonsterMagicDamgeLevel;
                MonsterStatic.MonsterHp = data.MonsterHp;
                MonsterStatic.MonsterHpLevel = data.MonsterHpLevel;
                MonsterStatic.MonsterMp = data.MonsterMp;
                MonsterStatic.MonsterMpLevel = data.MonsterMpLevel;
                MonsterStatic.MonsterHpRateRecover = data.MonsterHpRateRecover;
                MonsterStatic.MonsterMpRateRecover = data.MonsterMpRateRecover;
                MonsterStatic.MonsterPhysicalResistRate = data.MonsterPhysicalResistRate;
                MonsterStatic.MonsterMagicShield = data.MonsterMagicShield;
                MonsterStatic.MpnsterMagixShieldLevel = data.MpnsterMagixShieldLevel;
                MonsterStatic.MonsterMagicShieldRateRecover = data.MonsterMagicShieldRateRecover;
                MonsterStatic.MonsterLevelMin = data.MonsterLevelMin;
                MonsterStatic.MonsterLevelMax = data.MonsterLevelMax;
                MonsterStatic.MonsterHpNow = data.MonsterHpNow;
                MonsterStatic.MonsterMpNow = data.MonsterMpNow;
                MonsterStatic.MonsterName = data.MonsterName;
                MonsterStatic.MonsterIcon = data.MonsterIcon;

                MonsterStatic.MonsterSkill = new int[data.MonsterSkill.Length];
                for(int Num = 0; Num < data.MonsterSkill.Length; Num++)
				{
                    MonsterStatic.MonsterSkill[Num] = data.MonsterSkill[Num];
                }

                MonsterStatic.MonsterSkillLevel = new int[data.MonsterSkillLevel.Length];
                for (int Num = 0; Num < data.MonsterSkillLevel.Length; Num++)
                {
                    MonsterStatic.MonsterSkillLevel[Num] = data.MonsterSkillLevel[Num];
                }

                MonsterStatic.MonsterDieItem = new int[data.MonsterDieItem.Length];
                for (int Num = 0; Num < data.MonsterDieItem.Length; Num++)
                {
                    MonsterStatic.MonsterDieItem[Num] = data.MonsterDieItem[Num];
                }

                MonsterStatic.MonsterDieItemRate = new int[data.MonsterDieItemRate.Length];
                for (int Num = 0; Num < data.MonsterDieItemRate.Length; Num++)
                {
                    MonsterStatic.MonsterDieItemRate[Num] = data.MonsterDieItemRate[Num];
                }

                MonsterStatic.MonsterDieItemNum = new int[data.MonsterDieItemNum.Length];
                for (int Num = 0; Num < data.MonsterDieItemNum.Length; Num++)
                {
                    MonsterStatic.MonsterDieItemNum[Num] = data.MonsterDieItemNum[Num];
                }

                MonsterStatic.MonsterDieArm = new int[data.MonsterDieArm.Length];
                for(int Num = 0; Num < data.MonsterDieArm.Length; Num++)
				{
                    MonsterStatic.MonsterDieArm[Num] = data.MonsterDieArm[Num];
                }

                MonsterStatic.MonsterDieArmRate = new int[data.MonsterDieArmRate.Length];
                for (int Num = 0; Num < data.MonsterDieArmRate.Length; Num++)
                {
                    MonsterStatic.MonsterDieArmRate[Num] = data.MonsterDieArmRate[Num];
                }

                MonsterStatic.MonsterDieArmNum = new int[data.MonsterDieArmNum.Length];
                for (int Num = 0; Num < data.MonsterDieArmNum.Length; Num++)
                {
                    MonsterStatic.MonsterDieArmNum[Num] = data.MonsterDieArmNum[Num];
                }
            }
        }
    }

    public void ReadCharaterSkill(int SkillId)                                                     //讀取角色會的技能以及該技能的等級
    {
        string CharaterSkillFileName = "Charater_" + CharaterPropertyStatic.CharaterNumber + "_Skill";
        ReadPlatformpersistentDataPath(CharaterSkillFileName);
        string CharaterSkillFile = File.ReadAllText(persistentFilePath);
        JsonCharaterSkill<CharaterSkill> CharaterSkillFileJson = JsonUtility.FromJson<JsonCharaterSkill<CharaterSkill>>(CharaterSkillFile);

        foreach (CharaterSkill data in CharaterSkillFileJson.CharaterSkill)
        {
            if (data.SkillId == SkillId)
            {
                CharaterSkillStatic.SkillId = data.SkillId;
                CharaterSkillStatic.SkillLevel = data.SkillLevel;
            }
        }
    }

    public void ReadCharaterBattleSkill()                                                          //讀取角色裝備到戰鬥套路上的技能
    {
        string CharaterBattleSkillFileName = "Charater_" + CharaterPropertyStatic.CharaterNumber + "_BattleSkill";
        ReadPlatformpersistentDataPath(CharaterBattleSkillFileName);
        string CharaterBattleSkillFile = File.ReadAllText(persistentFilePath);
        CharaterBattleSkill CharaterBattleSkillFileJson = JsonUtility.FromJson<CharaterBattleSkill>(CharaterBattleSkillFile);
        CharaterBattleSkillCount = CharaterBattleSkillFileJson.BattleSkill.Length;
        CharaterBattleSkillArray = new int[CharaterBattleSkillCount];
        
        for(int Num = 0; Num < CharaterBattleSkillCount; Num++)
		{
            CharaterBattleSkillArray[Num] = CharaterBattleSkillFileJson.BattleSkill[Num];
        }
    }

    public void ReadSkill(int SkillId)                                                             //讀取特定技能編號的內容
    {
        string FileName = "Skill";
        ReadPlatformStreamingAssets(FileName);
        string datapath = streamingFilePath;

        var newfile = new UnityWebRequest(datapath);
        newfile.downloadHandler = new DownloadHandlerBuffer();
        var something = newfile.SendWebRequest();
        while (!something.isDone)
        { }
        string newfileinside = newfile.downloadHandler.text;

        JsonSkill<Skill> FileItem = JsonUtility.FromJson<JsonSkill<Skill>>(newfileinside);

        foreach (Skill data in FileItem.Skill)
        {
            if (data.SkillId == SkillId)
            {
                SkillStatic.SkillId = data.SkillId;
                SkillStatic.SkillType = data.SkillType;
                SkillStatic.SkillCharaterMonster = data.SkillCharaterMonster;
                SkillStatic.SkillLevelNum = new float[data.SkillLevelNum.Length];
                for (int Num = 0; Num < data.SkillLevelNum.Length; Num++)
				{
                    SkillStatic.SkillLevelNum[Num] = data.SkillLevelNum[Num];
                }
                SkillStatic.SkillName = data.SkillName;
                SkillStatic.SkillBattleType = data.SkillBattleType;
                SkillStatic.SkillTime = new float[data.SkillTime.Length];
                for (int Num = 0; Num < data.SkillTime.Length; Num++)
				{
                    SkillStatic.SkillTime[Num] = data.SkillTime[Num];
                }
                SkillStatic.SkillCost = new int[data.SkillCost.Length];
                for(int Num = 0; Num < data.SkillCost.Length; Num++)
				{
                    SkillStatic.SkillCost[Num] = data.SkillCost[Num];
                }
                SkillStatic.SkillICONName = data.SkillICONName;
            }
        }
    }

    public void ReadArm(int ArmId)                                                                 //讀取特定裝備編號的內容
    {
        string FileName = "Arm";
        ReadPlatformStreamingAssets(FileName);
        string datapath = streamingFilePath;

        var newfile = new UnityWebRequest(datapath);
        newfile.downloadHandler = new DownloadHandlerBuffer();
        var something = newfile.SendWebRequest();
        while (!something.isDone)
        { }
        string newfileinside = newfile.downloadHandler.text;

        JsonArm<Arm> FileItem = JsonUtility.FromJson<JsonArm<Arm>>(newfileinside);

        foreach(Arm data in FileItem.Arm)
		{
            if(data.BasicId == ArmId)
			{
                ArmStatic.BasicId = data.BasicId;
                ArmStatic.ArmName = data.ArmName;
                ArmStatic.ArmIconName = data.ArmIconName;
                ArmStatic.ArmType = data.ArmType;
                ArmStatic.ArmLv = data.ArmLv;
                ArmStatic.WeaponDamageMin = data.WeaponDamageMin;
                ArmStatic.WeaponDamageMax = data.WeaponDamageMax;
                ArmStatic.WeaponSpeed = data.WeaponSpeed;
                ArmStatic.ArmRequest_Strength = data.ArmRequest_Strength;
                ArmStatic.ArmRequest_Intelligence = data.ArmRequest_Intelligence;
                ArmStatic.ArmRequest_Dexterity = data.ArmRequest_Dexterity;
                ArmStatic.ArmArmor = data.ArmArmor;
                ArmStatic.ArmMagicShield = data.ArmMagicShield;
                ArmStatic.ArmDodge = data.ArmDodge;
                ArmStatic.ArmRank = data.ArmRank;
                ArmStatic.ArmPower = new int[data.ArmPower.Length];
                for(int Num = 0; Num < data.ArmPower.Length; Num++)
				{
                    ArmStatic.ArmPower[Num] = data.ArmPower[Num];
                }
            }           
        }
    }

    public void ReadCharaterBasic()                                                                //讀取角色基本能力數值
	{
        string FileName = "Charater" + CharaterPropertyStatic.CharaterNumber + "CharaterBasic";
        ReadPlatformpersistentDataPath(FileName);
        string FileInside = File.ReadAllText(persistentFilePath);

        CharaterBasicValue = JsonUtility.FromJson<CharaterBasic>(FileInside);
        CharaterBasicConversion();
    }

    public void CharaterBasicConversion()                                                          //將角色基本能力數值轉換成靜態資料
	{
        CharaterBasicStatic.CharaterBasic_Level = CharaterBasicValue.CharaterBasic_Level;

        CharaterBasicStatic.CharaterBasic_Strength = CharaterBasicValue.CharaterBasic_Strength;
        CharaterBasicStatic.CharaterBasic_Intelligence = CharaterBasicValue.CharaterBasic_Intelligence;
        CharaterBasicStatic.CharaterBasic_Dexterity = CharaterBasicValue.CharaterBasic_Dexterity;

        CharaterBasicStatic.CharaterBasic_Hp = CharaterBasicValue.CharaterBasic_Hp;
        CharaterBasicStatic.CharaterBasic_Mp = CharaterBasicValue.CharaterBasic_Mp;

        CharaterBasicStatic.CharaterBasic_PhysicalDamgeMin = CharaterBasicValue.CharaterBasic_PhysicalDamgeMin;
        CharaterBasicStatic.CharaterBasic_PhysicalDamgeMax = CharaterBasicValue.CharaterBasic_PhysicalDamgeMax;
        CharaterBasicStatic.CharaterBasic_MagicDamgeMin = CharaterBasicValue.CharaterBasic_MagicDamgeMin;
        CharaterBasicStatic.CharaterBasic_MagicDamgeMax = CharaterBasicValue.CharaterBasic_MagicDamgeMax;

        CharaterBasicStatic.CharaterBasic_Dodge = CharaterBasicValue.CharaterBasic_Dodge;
        CharaterBasicStatic.CharaterBasic_PhysicalResist = CharaterBasicValue.CharaterBasic_PhysicalResist;
        CharaterBasicStatic.CharaterBasic_MagicShield = CharaterBasicValue.CharaterBasic_MagicShield;

        CharaterBasicStatic.CharaterBasic_Critical = CharaterBasicValue.CharaterBasic_Critical;
        CharaterBasicStatic.CharaterBasic_AttackSpeed = CharaterBasicValue.CharaterBasic_AttackSpeed;

        CharaterBasicStatic.CharaterBasic_HpRecover = CharaterBasicValue.CharaterBasic_HpRecover;
        CharaterBasicStatic.CharaterBasic_MpRecover = CharaterBasicValue.CharaterBasic_MpRecover;
    }

    public void CharaterBasicChange()                                                              //將角色基本能力數值的靜態資料轉成可以儲存的資料
    {
        CharaterBasicValue.CharaterBasic_Level = CharaterBasicStatic.CharaterBasic_Level;

        CharaterBasicValue.CharaterBasic_Strength = CharaterBasicStatic.CharaterBasic_Strength;
        CharaterBasicValue.CharaterBasic_Intelligence = CharaterBasicStatic.CharaterBasic_Intelligence;
        CharaterBasicValue.CharaterBasic_Dexterity = CharaterBasicStatic.CharaterBasic_Dexterity;

        CharaterBasicValue.CharaterBasic_Hp = CharaterBasicStatic.CharaterBasic_Hp;
        CharaterBasicValue.CharaterBasic_Mp = CharaterBasicStatic.CharaterBasic_Mp;

        CharaterBasicValue.CharaterBasic_PhysicalDamgeMin = CharaterBasicStatic.CharaterBasic_PhysicalDamgeMin;
        CharaterBasicValue.CharaterBasic_PhysicalDamgeMax = CharaterBasicStatic.CharaterBasic_PhysicalDamgeMax;
        CharaterBasicValue.CharaterBasic_MagicDamgeMin = CharaterBasicStatic.CharaterBasic_MagicDamgeMin;
        CharaterBasicValue.CharaterBasic_MagicDamgeMax = CharaterBasicStatic.CharaterBasic_MagicDamgeMax;

        CharaterBasicValue.CharaterBasic_Dodge = CharaterBasicStatic.CharaterBasic_Dodge;
        CharaterBasicValue.CharaterBasic_PhysicalResist = CharaterBasicStatic.CharaterBasic_PhysicalResist;
        CharaterBasicValue.CharaterBasic_MagicShield = CharaterBasicStatic.CharaterBasic_MagicShield;

        CharaterBasicValue.CharaterBasic_Critical = CharaterBasicStatic.CharaterBasic_Critical;
        CharaterBasicValue.CharaterBasic_AttackSpeed = CharaterBasicStatic.CharaterBasic_AttackSpeed;

        CharaterBasicValue.CharaterBasic_HpRecover = CharaterBasicStatic.CharaterBasic_HpRecover;
        CharaterBasicValue.CharaterBasic_MpRecover = CharaterBasicStatic.CharaterBasic_MpRecover;
    }

    public class JsonRead<T>                                                                       //因為unity的JsonUtility的序列化無法處理多維陣列，所以要先把json檔案轉成List來做反序列化
    {
        public List<T> StringUI;
    }

    public class JsonCharaterArm<T>                                                                //角色裝備表所使用的List，來協助unity可以讀取陣列(Array)裡的資料
    {
        public List<T> CharaterArm;
    }

    public class JsonExp<T>                                                                        //角色經驗表所使用的List，來協助unity可以讀取陣列(Array)裡的資料
    {
        public List<T> CharaterExp;
    }

    public class JsonPower<T>                                                                      //詞綴表所使用的List，來協助unity可以讀取陣列(Array)裡的資料
    {
        public List<T> ArmPowerList;
    }

    public class JsonCharaterItem<T>                                                               //角色道具表所使用的List
    {
        public List<T> CharaterItem;
    }

    public class JsonItem<T>                                                                       //道具表所使用的List
    {
        public List<T> Item;
    }

    public class JsonMap<T>                                                                        //地圖表所使用的List
    {
        public List<T> Map;
    }

    public class JsonNPCList<T>                                                                    //NPC列表所使用的List
    {
        public List<T> NPCList;
    }

    public class JsonNPC<T>                                                                        //NPC表所使用的List
    {
        public List<T> NPC;
    }

    public class JsonCharaterSkill<T>                                                              //角色技能表所使用的List
    {
        public List<T> CharaterSkill;
    }

    public class JsonMonsterList<T>                                                                //怪物列表所使用的List
    {
        public List<T> MonsterList;
    }

    public class JsonMonster<T>                                                                    //怪物表所使用的List
    {
        public List<T> Monster;
    }

    public class JsonSkill<T>                                                                      //技能表所使用的List
    {
        public List<T> Skill;
    }

    public class JsonArm<T>                                                                        //裝備表所使用的List
	{
        public List<T> Arm;
	}
}
