using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class CharaterList : MonoBehaviour
{

    public GameObject Prefab_CharaterListClone;
    public PublicFunction PublicFunctionClone;
    public OpenMsgBox OpenMsgBoxClone;
    public CharaterList CharaterListClone;
    public GameObject CreateGameObjectClone;
    public GameBackManager GameBackManagerClone;

    private GameObject EmptyGameObject;

    private string DeleteCharaterFilePath;

    private Text Load_CharaterName;
    private Text Load_CharaterLevel;
    private Text Load_CharaterJobName;

    public string CharaterNum;

    private Store StoreValueClone;
    private CharaterProperty CharaterPropertyClone;
    private int Num;
    private int DeleteNum;

    private void Awake()
    {
        CheckCharaterCreate();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckCharaterCreate()
    {
        string StoreName = "Store";

        PublicFunctionClone.ReadPlatformpersistentDataPath(StoreName);   //找出在persistentDataPath裡面的Store.json檔案路徑

        string FileRead = File.ReadAllText(PublicFunction.persistentFilePath);

        StoreValueClone = JsonUtility.FromJson<Store>(FileRead);

        for (Num = 0; Num < 5; Num++)
        {
            if (StoreValueClone.CharaterList[Num] == 1)
            {
                CharaterNum = "Charater_" + (Num + 1);
                string ReadFilePath;

                PublicFunctionClone.ReadCharaterPropertyFileFunction(Num + 1);
                ReadFilePath = PublicFunction.ReadCharaterPropertyFile;
                CharaterListClone.LoadCharaterInfo(ReadFilePath, CharaterNum);
                CreateGameObjectClone = GameObject.Find("UI/Prefab_CharaterList(Clone)" + "/Charater" + "/" + CharaterNum + "/Create");
                CharaterListClone.CreateGameObjectClone.SetActive(false);
            }
            if (StoreValueClone.CharaterList[Num] == 0)
            {
                CharaterNum = "Charater_" + (Num + 1);
                CreateGameObjectClone = GameObject.Find("UI/Prefab_CharaterList(Clone)" + "/Charater" + "/" + CharaterNum + "/Create");
                CharaterListClone.CreateGameObjectClone.SetActive(true);
                Debug.Log("尚未建立此角色!");
            }
            else
            {
                Debug.Log("迴圈跑到底!或是有錯誤");
            }
        }
    }

    public void LoadCharaterInfo(string FileName, string LoadCharaterNum)
    {
        CharaterPropertyClone = JsonUtility.FromJson<CharaterProperty>(FileName);

        string CharaterLevelClone = Convert.ToString(CharaterPropertyClone.CharaterLevel);

        EmptyGameObject = GameObject.Find(LoadCharaterNum);

        GameObject Load_CharaterNameClone, Load_CharaterLevelClone, Load_CharaterJobNameClone;

        Load_CharaterNameClone = GameObject.Find("UI/Prefab_CharaterList(Clone)" + "/Charater" + "/" + LoadCharaterNum + "/Already" + "/Load_CharaterName");
        Load_CharaterLevelClone = GameObject.Find("UI/Prefab_CharaterList(Clone)" + "/Charater" + "/" + LoadCharaterNum + "/Already" + "/Load_Level");
        Load_CharaterJobNameClone = GameObject.Find("UI/Prefab_CharaterList(Clone)" + "/Charater" + "/" + LoadCharaterNum + "/Already" + "/Load_SkillJobName");

        Load_CharaterName = Load_CharaterNameClone.GetComponent<Text>();
        Load_CharaterLevel = Load_CharaterLevelClone.GetComponent<Text>();
        Load_CharaterJobName = Load_CharaterJobNameClone.GetComponent<Text>();

        Load_CharaterName.text = CharaterPropertyClone.CharaterName;
        Load_CharaterLevel.text = CharaterLevelClone;
        Load_CharaterJobName.text = CharaterPropertyClone.CharaterJobName;
    }

    public void EnterGameCheck(int input)
    {
        OpenMsgBoxClone.CreateMsgBox(9);

        string filename = "Charater_" + input;
        string fileinside;
        string jsonpath;
        string jsonfile;
        string datapath;

        if (Application.platform == RuntimePlatform.Android)
        {
            jsonpath = Application.persistentDataPath;
            jsonfile = filename + ".json";
            datapath = Path.Combine(jsonpath, jsonfile);
        }
        else
        {
            jsonpath = Application.persistentDataPath;
            jsonfile = filename + ".json";
            datapath = Path.Combine(jsonpath, jsonfile);
        }

        fileinside = File.ReadAllText(datapath);

        PublicFunction.CharaterPropertyValue = JsonUtility.FromJson<CharaterProperty>(fileinside);
        PublicFunctionClone.CharaterPropertyConversion();
        PublicFunctionClone.ReadCharaterExp();
        /*PublicFunctionClone.CharaterFileCalculate(0, 0, 0);
        PublicFunctionClone.CharaterPropertyConversion();

        fileinside = JsonUtility.ToJson(PublicFunction.CharaterPropertyValue);
        File.WriteAllText(datapath, fileinside); */

         Debug.Log("登入的角色是Charater_" + CharaterPropertyStatic.CharaterNumber);
    }

    public void CharaterClick_1()
    {
        EnterGameCheck(1);
    }
    public void CharaterClick_2()
    {
        EnterGameCheck(2);
    }
    public void CharaterClick_3()
    {
        EnterGameCheck(3);
    }
    public void CharaterClick_4()
    {
        EnterGameCheck(4);
    }
    public void CharaterClick_5()
    {
        EnterGameCheck(5);
    }

    public void OpenMainScenes()
    {
        EmptyGameObject = GameObject.FindWithTag("GameBackManager");
        GameBackManagerClone = EmptyGameObject.GetComponent<GameBackManager>();
        GameBackManagerClone.LoadingScenes();
    }

    public void DeleteCharater(int DeleteCharaterNum)                   //刪除角色資料
    {
        PublicFunctionClone.ReadCharaterPropertyFileFunction(DeleteCharaterNum);
        DeleteCharaterFilePath = PublicFunction.persistentFilePath;

        //-----這段是將Store.json裡面的用來判斷角色是否被建立的編號修改成沒有建立的狀態
        string StoreName = "Store";
        PublicFunctionClone.ReadPlatformpersistentDataPath(StoreName);                   //找出在persistentDataPath裡面的Store.json檔案路徑
        string FileRead = File.ReadAllText(PublicFunction.persistentFilePath);
        StoreValueClone = JsonUtility.FromJson<Store>(FileRead);
        StoreValueClone.CharaterList[DeleteCharaterNum - 1] = 0;
        string file = JsonUtility.ToJson(StoreValueClone);
        File.WriteAllText(PublicFunction.persistentFilePath, file);
        //-----

        //-----刪除角色檔案
        File.Delete(DeleteCharaterFilePath);
        //-----

        //-----刪除角色裝備檔案
        string ArmFilePath = "Charater_" + DeleteCharaterNum + "_Arm.json";

        if (Application.platform == RuntimePlatform.Android)
        {
            string jsonpath = Application.persistentDataPath;
            string datapath = Path.Combine(jsonpath, ArmFilePath);

            ArmFilePath = datapath;
        }
        if (Application.platform != RuntimePlatform.Android)
        {
            string jsonpath = Application.persistentDataPath;
            string datapath = Path.Combine(jsonpath, ArmFilePath);

            ArmFilePath = datapath;
        }
        File.Delete(ArmFilePath);
        //-----

        //-----刪除角色道具檔案
        string ItemFilePath = "Charater_" + DeleteCharaterNum + "_Item.json";

        if (Application.platform == RuntimePlatform.Android)
        {
            string jsonpath = Application.persistentDataPath;
            string datapath = Path.Combine(jsonpath, ItemFilePath);

            ItemFilePath = datapath;
        }
        if (Application.platform != RuntimePlatform.Android)
        {
            string jsonpath = Application.persistentDataPath;
            string datapath = Path.Combine(jsonpath, ItemFilePath);

            ItemFilePath = datapath;
        }
        File.Delete(ItemFilePath);
        //-----

        //----刪除角色戰鬥技能表
        string BattleSkillFilePath = "Charater_" + DeleteCharaterNum + "_BattleSkill.json";

        if (Application.platform == RuntimePlatform.Android)
        {
            string jsonpath = Application.persistentDataPath;
            string datapath = Path.Combine(jsonpath, BattleSkillFilePath);

            BattleSkillFilePath = datapath;
        }
        if (Application.platform != RuntimePlatform.Android)
        {
            string jsonpath = Application.persistentDataPath;
            string datapath = Path.Combine(jsonpath, BattleSkillFilePath);

            BattleSkillFilePath = datapath;
        }
        File.Delete(BattleSkillFilePath);
        //----

        //----刪除角色技能表
        string SkillFilePath = "Charater_" + DeleteCharaterNum + "_Skill.json";

        if (Application.platform == RuntimePlatform.Android)
        {
            string jsonpath = Application.persistentDataPath;
            string datapath = Path.Combine(jsonpath, SkillFilePath);

            SkillFilePath = datapath;
        }
        if (Application.platform != RuntimePlatform.Android)
        {
            string jsonpath = Application.persistentDataPath;
            string datapath = Path.Combine(jsonpath, SkillFilePath);

            SkillFilePath = datapath;
        }
        File.Delete(SkillFilePath);
        //-----

        //-----刪除角色基本能力表
        string BasicFilePath = "Charater_" + DeleteCharaterNum + "_Basic.json";

        if (Application.platform == RuntimePlatform.Android)
        {
            string jsonpath = Application.persistentDataPath;
            string datapath = Path.Combine(jsonpath, BasicFilePath);

            BasicFilePath = datapath;
        }
        if (Application.platform != RuntimePlatform.Android)
        {
            string jsonpath = Application.persistentDataPath;
            string datapath = Path.Combine(jsonpath, BasicFilePath);

            BasicFilePath = datapath;
        }
        File.Delete(BasicFilePath);
        //-----

        CheckCharaterCreate();
        ChangeCharaterFile(DeleteCharaterNum);
    }

    public void DeleteCharaterFumction()
    {
        DeleteCharater(DeleteNum);
        OpenMsgBoxClone.CreateMsgBox(11);
    }

    public void DeleteCharaterNum_1()
    {
        DeleteNum = 1;
        OpenMsgBoxClone.CreateMsgBox(10);
    }
    public void DeleteCharaterNum_2()
    {
        DeleteNum = 2;
        OpenMsgBoxClone.CreateMsgBox(10);
    }
    public void DeleteCharaterNum_3()
    {
        DeleteNum = 3;
        OpenMsgBoxClone.CreateMsgBox(10);
    }
    public void DeleteCharaterNum_4()
    {
        DeleteNum = 4;
        OpenMsgBoxClone.CreateMsgBox(10);
    }
    public void DeleteCharaterNum_5()
    {
        DeleteNum = 5;
        OpenMsgBoxClone.CreateMsgBox(10);
    }

    public void ChangeCharaterFile(int DeleteCharaterNum)
    {
        //-----這段是將Store.json裡面的用來判斷角色是否被建立的編號修改成沒有建立的狀態
        string StoreName = "Store";
        PublicFunctionClone.ReadPlatformpersistentDataPath(StoreName);                             //找出在persistentDataPath裡面的Store.json檔案路徑
        string FileRead = File.ReadAllText(PublicFunction.persistentFilePath);
        StoreValueClone = JsonUtility.FromJson<Store>(FileRead);
        //-----

        if (DeleteCharaterNum == 1)                                                                //當要刪除的角色是第一隻角色時的情況
        {
           if(StoreValueClone.CharaterList[1] == 1 && StoreValueClone.CharaterList[2] == 0)        //當有第二隻角色要替補，但沒有第三隻角色的情況
            {
                ModifyCharaterFile(1);
                CheckCharaterCreate();
            }
            if (StoreValueClone.CharaterList[2] == 1 && StoreValueClone.CharaterList[3] == 0)      //當有第二，三隻角色要替補，但沒有第四隻角色的情況
            {
                ModifyCharaterFileSecond(1);
                ModifyCharaterFile(2);
                CheckCharaterCreate();
            }
            if (StoreValueClone.CharaterList[3] == 1 && StoreValueClone.CharaterList[4] == 0)      //當有第二，三，四隻角色，但沒有第五隻角色的情況
            {
                ModifyCharaterFileSecond(1);
                ModifyCharaterFileSecond(2);
                ModifyCharaterFile(3);
                CheckCharaterCreate();
            }
            if (StoreValueClone.CharaterList[4] == 1)                                             //當有第二，三，四，五隻角色的情況
            {
                ModifyCharaterFileSecond(1);
                ModifyCharaterFileSecond(2);
                ModifyCharaterFileSecond(3);
                ModifyCharaterFile(4);
                CheckCharaterCreate();
            }
        }
        if (DeleteCharaterNum == 2)                                                               //當要刪除的角色是第二隻角色時的情況
        {
            if (StoreValueClone.CharaterList[2] == 1 && StoreValueClone.CharaterList[3] == 0)     //當有第三隻角色要替補，但沒有第四隻角色的情況
            {
                ModifyCharaterFile(2);
                CheckCharaterCreate();
            }
            if (StoreValueClone.CharaterList[3] == 1 && StoreValueClone.CharaterList[4] == 0)     //當有第三，四隻角色，但沒有第五隻角色的情況
            {
                ModifyCharaterFileSecond(2);
                ModifyCharaterFile(3);
                CheckCharaterCreate();
            }
            if (StoreValueClone.CharaterList[4] == 1)                                             //當有第三，四，五隻角色的情況
            {
                ModifyCharaterFileSecond(2);
                ModifyCharaterFileSecond(3);
                ModifyCharaterFile(4);
                CheckCharaterCreate();
            }
        }
        if (DeleteCharaterNum == 3)                                                               //當要刪除的角色是第三隻角色時的情況
        {
            if (StoreValueClone.CharaterList[3] == 1 && StoreValueClone.CharaterList[4] == 0)     //當有第四隻角色要替補，但沒有第五隻角色的情況
            {
                ModifyCharaterFile(3);
                CheckCharaterCreate();
            }
            if (StoreValueClone.CharaterList[4] == 1)                                             //當有第四，五隻角色要替補
            {
                ModifyCharaterFileSecond(3);
                ModifyCharaterFile(4);
                CheckCharaterCreate();
            }
        }
        if (DeleteCharaterNum == 4)                                                               //當要刪除的角色是第四隻角色時的情況
        {
            if (StoreValueClone.CharaterList[4] == 1)                                             //當有第五隻角色要替補
            {
                ModifyCharaterFile(4);
                CheckCharaterCreate();
            }
        }
    }

    public void ModifyCharaterFile(int DeleteCharaterNum)
    {
        //-----查詢Store.json檔案裡的資料
        string StoreName = "Store";
        PublicFunctionClone.ReadPlatformpersistentDataPath(StoreName);                                 //找出在persistentDataPath裡面的Store.json檔案路徑
        string FileRead = File.ReadAllText(PublicFunction.persistentFilePath);
        StoreValueClone = JsonUtility.FromJson<Store>(FileRead);
        //-----

        //-----執行修改要替補檔案的內容
        int CharaterNum = DeleteCharaterNum + 1;
        PublicFunctionClone.ReadCharaterPropertyFileFunction(CharaterNum);                             //因為原本就已經加1了，所以不用再加1
        string ReadCharaterFile = PublicFunction.ReadCharaterPropertyFile;                             //找到要修改角色資料的檔案路徑
        CharaterPropertyClone = JsonUtility.FromJson<CharaterProperty>(ReadCharaterFile);              //將讀取到的檔案轉換成unity可以辨識的資料
        CharaterPropertyClone.Charater = "Charater_" + (CharaterNum - 1);                              //因為刪除角色後要將後面角色的資料往前替補，所以才要在這裡更改檔案內容
        CharaterPropertyClone.CharaterNumber = CharaterNum - 1;
        StoreValueClone.CharaterList[CharaterNum - 2] = 1;
        StoreValueClone.CharaterList[CharaterNum - 1] = 0;                                             //因為已經將角色的資料往前替補，所以原本的資料就要改成0，也就是沒有被建立角色的狀態
        CharaterPropertyStatic.Charater = CharaterPropertyClone.Charater;
        CharaterPropertyStatic.CharaterNumber = CharaterPropertyClone.CharaterNumber;
        //-----

        //-----儲存Store的檔案
        PublicFunctionClone.ReadPlatformpersistentDataPath(StoreName);
        string storefile = JsonUtility.ToJson(StoreValueClone);
        File.WriteAllText(PublicFunction.persistentFilePath, storefile);
        //-----

        //-----將修改完的檔案新增成藥往前替補的檔案，並刪掉原本的
        string file = JsonUtility.ToJson(CharaterPropertyClone);
        string jsonpath = Application.persistentDataPath;
        string jsonfile = CharaterPropertyClone.Charater + ".json";
        string datapath = Path.Combine(jsonpath, jsonfile);
        string deletefilename = "Charater_" + CharaterNum + ".json";
        string deletefilepath = Path.Combine(jsonpath, deletefilename);
        File.WriteAllText(datapath, file);
        File.Delete(deletefilepath);
        //-----

        //-----修改裝備的檔案
        string armfilename = "Charater_" + (DeleteCharaterNum + 1) + "_Arm";
        PublicFunctionClone.ReadPlatformpersistentDataPath(armfilename);
        string armfile = File.ReadAllText(PublicFunction.persistentFilePath);
        string armfilenameafter = "Charater_" + DeleteCharaterNum + "_Arm";
        PublicFunctionClone.ReadPlatformpersistentDataPath(armfilenameafter);
        File.WriteAllText(PublicFunction.persistentFilePath, armfile);
        PublicFunctionClone.ReadPlatformpersistentDataPath(armfilename);
        File.Delete(PublicFunction.persistentFilePath);
        //-----

        //-----修改道具的檔案
        string Itemfilename = "Charater_" + (DeleteCharaterNum + 1) + "_Item";
        PublicFunctionClone.ReadPlatformpersistentDataPath(Itemfilename);
        string Itemfile = File.ReadAllText(PublicFunction.persistentFilePath);
        string Itemfilenameafter = "Charater_" + DeleteCharaterNum + "_Item";
        PublicFunctionClone.ReadPlatformpersistentDataPath(Itemfilenameafter);
        File.WriteAllText(PublicFunction.persistentFilePath, Itemfile);
        PublicFunctionClone.ReadPlatformpersistentDataPath(Itemfilename);
        File.Delete(PublicFunction.persistentFilePath);
        //-----

        //-----修改角色戰鬥技能的檔案
        string BattleSkillfilename = "Charater_" + (DeleteCharaterNum + 1) + "_BattleSkill";
        PublicFunctionClone.ReadPlatformpersistentDataPath(BattleSkillfilename);
        string BattleSkillfile = File.ReadAllText(PublicFunction.persistentFilePath);
        string BattleSkillfilenameafter = "Charater_" + DeleteCharaterNum + "_BattleSkill";
        PublicFunctionClone.ReadPlatformpersistentDataPath(BattleSkillfilenameafter);
        File.WriteAllText(PublicFunction.persistentFilePath, BattleSkillfile);
        PublicFunctionClone.ReadPlatformpersistentDataPath(BattleSkillfilename);
        File.Delete(PublicFunction.persistentFilePath);
        //-----

        //-----修改角色技能的檔案
        string Skillfilename = "Charater_" + (DeleteCharaterNum + 1) + "_Skill";
        PublicFunctionClone.ReadPlatformpersistentDataPath(Skillfilename);
        string Skillfile = File.ReadAllText(PublicFunction.persistentFilePath);
        string Skillfilenameafter = "Charater_" + DeleteCharaterNum + "_Skill";
        PublicFunctionClone.ReadPlatformpersistentDataPath(Skillfilenameafter);
        File.WriteAllText(PublicFunction.persistentFilePath, Skillfile);
        PublicFunctionClone.ReadPlatformpersistentDataPath(Skillfilename);
        File.Delete(PublicFunction.persistentFilePath);
        //-----
    }

    public void ModifyCharaterFileSecond(int DeleteCharaterNum)
    {
        //-----查詢Store.json檔案裡的資料
        string StoreName = "Store";
        PublicFunctionClone.ReadPlatformpersistentDataPath(StoreName);                                 //找出在persistentDataPath裡面的Store.json檔案路徑
        string FileRead = File.ReadAllText(PublicFunction.persistentFilePath);
        StoreValueClone = JsonUtility.FromJson<Store>(FileRead);
        //-----

        //-----執行修改要替補檔案的內容
        int CharaterNum = DeleteCharaterNum + 1;
        PublicFunctionClone.ReadCharaterPropertyFileFunction(CharaterNum);                             //因為原本就已經加1了，所以不用再加1
        string ReadCharaterFile = PublicFunction.ReadCharaterPropertyFile;                             //找到要修改角色資料的檔案路徑
        CharaterPropertyClone = JsonUtility.FromJson<CharaterProperty>(ReadCharaterFile);              //將讀取到的檔案轉換成unity可以辨識的資料
        CharaterPropertyClone.Charater = "Charater_" + (CharaterNum - 1);                              //因為刪除角色後要將後面角色的資料往前替補，所以才要在這裡更改檔案內容
        CharaterPropertyClone.CharaterNumber = CharaterNum - 1;
        StoreValueClone.CharaterList[CharaterNum - 2] = 1;
        StoreValueClone.CharaterList[CharaterNum - 1] = 0;                                             //因為已經將角色的資料往前替補，所以原本的資料就要改成0，也就是沒有被建立角色的狀態
        CharaterPropertyStatic.Charater = CharaterPropertyClone.Charater;
        CharaterPropertyStatic.CharaterNumber = CharaterPropertyClone.CharaterNumber;
        //-----

        //-----儲存Store的檔案
        PublicFunctionClone.ReadPlatformpersistentDataPath(StoreName);
        string storefile = JsonUtility.ToJson(StoreValueClone);
        File.WriteAllText(PublicFunction.persistentFilePath, storefile);
        //-----

        //-----將修改完的檔案新增成藥往前替補的檔案
        string file = JsonUtility.ToJson(CharaterPropertyClone);
        string jsonpath = Application.persistentDataPath;
        string jsonfile = CharaterPropertyClone.Charater + ".json";
        string datapath = Path.Combine(jsonpath, jsonfile);
        File.WriteAllText(datapath, file);
        //-----

        //-----修改裝備的檔案
        string armfilename = "Charater_" + (DeleteCharaterNum + 1) + "_Arm";
        PublicFunctionClone.ReadPlatformpersistentDataPath(armfilename);
        string armfile = File.ReadAllText(PublicFunction.persistentFilePath);
        string armfilenameafter = "Charater_" + DeleteCharaterNum + "_Arm";
        PublicFunctionClone.ReadPlatformpersistentDataPath(armfilenameafter);
        File.WriteAllText(PublicFunction.persistentFilePath, armfile);
        //-----

        //-----修改道具的檔案
        string Itemfilename = "Charater_" + (DeleteCharaterNum + 1) + "_Item";
        PublicFunctionClone.ReadPlatformpersistentDataPath(Itemfilename);
        string Itemfile = File.ReadAllText(PublicFunction.persistentFilePath);
        string Itemfilenameafter = "Charater_" + DeleteCharaterNum + "_Item";
        PublicFunctionClone.ReadPlatformpersistentDataPath(Itemfilenameafter);
        File.WriteAllText(PublicFunction.persistentFilePath, Itemfile);
        //-----

        //-----修改角色戰鬥技能的檔案
        string BattleSkillfilename = "Charater_" + (DeleteCharaterNum + 1) + "_BattleSkill";
        PublicFunctionClone.ReadPlatformpersistentDataPath(BattleSkillfilename);
        string BattleSkillfile = File.ReadAllText(PublicFunction.persistentFilePath);
        string BattleSkillfilenameafter = "Charater_" + DeleteCharaterNum + "_BattleSkill";
        PublicFunctionClone.ReadPlatformpersistentDataPath(BattleSkillfilenameafter);
        File.WriteAllText(PublicFunction.persistentFilePath, BattleSkillfile);
        //-----

        //-----修改角色技能的檔案
        string Skillfilename = "Charater_" + (DeleteCharaterNum + 1) + "_Skill";
        PublicFunctionClone.ReadPlatformpersistentDataPath(Skillfilename);
        string Skillfile = File.ReadAllText(PublicFunction.persistentFilePath);
        string Skillfilenameafter = "Charater_" + DeleteCharaterNum + "_Skill";
        PublicFunctionClone.ReadPlatformpersistentDataPath(Skillfilenameafter);
        File.WriteAllText(PublicFunction.persistentFilePath, Skillfile);
        //-----
    }
}
