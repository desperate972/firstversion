using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using System;
using System.IO;

public class CharaterInfo : MonoBehaviour
{

    public PublicFunction PublicFunctionClone;
    public OpenMsgBox OpenMsgBoxClone;
    public GameObject EmptyGameObject;
    private MainGameControl MainGameControlClone;
    public GameObject PropertyClone;
    public GameObject PropertyListClone;

    public Text Load_Hp;
    public Text Load_Mp;
    public Text Load_MagicShield;
    public Text CharaterStrength;
    public Text CharaterIntelligence;
    public Text CharaterDexterity;
    public Text CharaterLastPoint;

    public SpriteAtlas SpriteChange;
    public SpriteAtlas SpriteArmIcon;

    public GameObject Load_Sprite_Hp;
    public GameObject Load_Sprite_Mp;
    public GameObject Load_Sprite_MagicShield;

    public Image MainWeapon;
    public Image SecondWeapon;
    public Image Head;
    public Image Body;
    public Image MainRing;
    public Image SecondRing;
    public Image Necklace;
    public Image Hand;
    public Image Belt;
    public Image Foot;

    public Text MainWeaponCharaterArmId;
    public Text SecondWeaponCharaterArmId;
    public Text HeadCharaterArmId;
    public Text BodyCharaterArmId;
    public Text MainRingCharaterArmId;
    public Text SecondRingCharaterArmId;
    public Text NecklaceCharaterArmId;
    public Text HandCharaterArmId;
    public Text BeltCharaterArmId;
    public Text FootCharaterArmId;

    public GameObject MagicShield_Frame;
    public GameObject MagicShield_Text;
    public GameObject MagicShield_Load;
    public GameObject MagicShield_FrameOutside;

    private GameObject BtnAdd_Strength;
    private GameObject BtnLess_Strength;
    private GameObject BtnAdd_Intelligence;
    private GameObject BtnLess_Intelligence;
    private GameObject BtnAdd_Dexterity;
    private GameObject BtnLess_Dexterity;
    private GameObject Load_Sprite_LastPointBack;

    private int StrengthNum;
    private int IntelligenceNum;
    private int DexterityNum;
    private int DodgeNum;
    private int CriticalNum;

    public static int LastPoint;
    public static int LastPointMax;

    private GameObject PropertyNameCloneObj;
    private GameObject PropertyNumCloneObj;
    private Text PropertyNameClone;
    private Text PropertyNumClone;

    private GameObject CharaterInfoPropertyButton;
    private GameObject CharaterInfoArmButton;

    private GameObject CharaterInfoProperty;
    private GameObject CharaterInfoArm;
    private GameObject CharaterInfoArmLoad_Num;
    private GameObject CharaterInfoArmBtn_Reflash;

    private Image CharaterInfoPropertyImage;
    private Image CharaterInfoArmImage;

    private GameObject CharaterArmClone;
    private GameObject CharaterArmEquip;
    private GameObject CharaterArmListObj;
    private GameObject CharaterArmIconClone;

    private Image ArmIconClone;

    private GameObject ArmNumClone;
    private Text ArmNumCloneText;

    private GameObject ArmList;

    private GameObject Arm_0;
    private GameObject Arm_1;
    private GameObject Arm_2;
    private GameObject Arm_3;
    private GameObject Arm_4;
    private GameObject Arm_5;
    private GameObject Arm_6;
    private GameObject Arm_7;
    private GameObject Arm_8;
    private GameObject Arm_9;

    public static int[] CharaterArm;
    public static int CharaterArmCount;

    public void Awake()
    {
        CharaterInfoPropertyButton = GameObject.Find("Btn_Property");
        CharaterInfoPropertyImage = CharaterInfoPropertyButton.GetComponent<Image>();

        CharaterInfoArmButton = GameObject.Find("Btn_Arm");
        CharaterInfoArmImage = CharaterInfoArmButton.GetComponent<Image>();

        CharaterInfoProperty = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_Property");
        CharaterInfoArm = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList");
        CharaterInfoArmLoad_Num = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Load_ArmNum");
        CharaterInfoArmBtn_Reflash = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Btn_Reflash");

        CharaterArmClone = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Load_Arm");
        CharaterArmIconClone = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Load_Arm/Load_ArmIcon");
        CharaterArmEquip = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Load_Arm/Load_Equip");
        CharaterArmListObj = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList");

        ArmNumClone = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Load_ArmNum");

        Arm_0 = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_0");
        Arm_1 = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_1");
        Arm_2 = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_2");
        Arm_3 = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_3");
        Arm_4 = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_4");
        Arm_5 = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_5");
        Arm_6 = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_6");
        Arm_7 = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_7");
        Arm_8 = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_8");
        Arm_9 = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_9");

        StrengthNum = Convert.ToInt32(CharaterPropertyStatic.CharaterProperty_Strength);
        IntelligenceNum = Convert.ToInt32(CharaterPropertyStatic.CharaterProperty_Intelligence);
        DexterityNum = Convert.ToInt32(CharaterPropertyStatic.CharaterProperty_Dexterity);

        CheckCharaterArmList();
        LoadCharaterProperty();
        IfLastPoint();
        InputCharaterProperty();
        CharaterArmList();
        InputEquipmentArm();
        FlashCharaterInfo();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadCharaterProperty()
    {
        switch (CharaterPropertyStatic.CharaterMagicShield != 0)
        {
            case true:
                {
                    Load_Sprite_MagicShield.SetActive(true);
                    MagicShield_Frame.SetActive(true);
                    MagicShield_Text.SetActive(true);
                    MagicShield_Load.SetActive(true);
                    MagicShield_FrameOutside.SetActive(true);
                    PublicFunctionClone.ChangeSpriteSize(Load_Sprite_MagicShield, CharaterPropertyStatic.CharaterMagicShieldNow, CharaterPropertyStatic.CharaterMagicShieldNow, CharaterPropertyStatic.CharaterMagicShield, 0);
                    Load_MagicShield.text = CharaterPropertyStatic.CharaterMagicShieldNow + "/" + CharaterPropertyStatic.CharaterMagicShield;
                    break;
                }
            case false:
                {
                    Load_Sprite_MagicShield.SetActive(false);
                    MagicShield_Frame.SetActive(false);
                    MagicShield_Text.SetActive(false);
                    MagicShield_Load.SetActive(false);
                    MagicShield_FrameOutside.SetActive(false);
                    break;
                }
        }
        PublicFunctionClone.ChangeSpriteSize(Load_Sprite_Hp, CharaterPropertyStatic.CharaterHpNow, CharaterPropertyStatic.CharaterHpNow, CharaterPropertyStatic.CharaterHp, 0);
        PublicFunctionClone.ChangeSpriteSize(Load_Sprite_Mp, CharaterPropertyStatic.CharaterMpNow, CharaterPropertyStatic.CharaterMpNow, CharaterPropertyStatic.CharaterMp, 0);
        Load_Hp.text = CharaterPropertyStatic.CharaterHpNow + "/" + CharaterPropertyStatic.CharaterHp;
        Load_Mp.text = CharaterPropertyStatic.CharaterMpNow + "/" + CharaterPropertyStatic.CharaterMp;
        CharaterStrength.text = CharaterPropertyStatic.CharaterProperty_Strength.ToString();
        CharaterIntelligence.text = CharaterPropertyStatic.CharaterProperty_Intelligence.ToString();
        CharaterDexterity.text = CharaterPropertyStatic.CharaterProperty_Dexterity.ToString();
        CharaterLastPoint.text = CharaterPropertyStatic.CharaterLastPoint.ToString();
        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 0);
    }

    public void IfLastPoint()
    {
        BtnAdd_Strength = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_CharaterPower/CharaterPower_Strength/Btn_Add");
        BtnLess_Strength = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_CharaterPower/CharaterPower_Strength/Btn_Less");
        BtnAdd_Intelligence = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_CharaterPower/CharaterPower_Intelligence/Btn_Add");
        BtnLess_Intelligence = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_CharaterPower/CharaterPower_Intelligence/Btn_Less");
        BtnAdd_Dexterity = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_CharaterPower/CharaterPower_Dexterity/Btn_Add");
        BtnLess_Dexterity = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_CharaterPower/CharaterPower_Dexterity/Btn_Less");
        Load_Sprite_LastPointBack = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_CharaterPower/Load_Sprite_LastPointBack");

        switch (CharaterPropertyStatic.CharaterLastPoint != 0)
        {
            case true:
                {
                    BtnAdd_Strength.SetActive(true);
                    BtnLess_Strength.SetActive(true);
                    BtnAdd_Intelligence.SetActive(true);
                    BtnLess_Intelligence.SetActive(true);
                    BtnAdd_Dexterity.SetActive(true);
                    BtnLess_Dexterity.SetActive(true);
                    Load_Sprite_LastPointBack.SetActive(false);
                    break;
                }
            case false:
                {
                    BtnAdd_Strength.SetActive(false);
                    BtnLess_Strength.SetActive(false);
                    BtnAdd_Intelligence.SetActive(false);
                    BtnLess_Intelligence.SetActive(false);
                    BtnAdd_Dexterity.SetActive(false);
                    BtnLess_Dexterity.SetActive(false);
                    Load_Sprite_LastPointBack.SetActive(true);
                    Debug.Log("點數都已被分配!");
                    break;
                }
        }
    }

    public void StrengthAddClick()
    {
        LastPoint = Convert.ToInt32(CharaterLastPoint.text);
        switch (StrengthNum == Convert.ToInt32(CharaterPropertyStatic.CharaterProperty_Strength))
        {
            case true:
                {
                    StrengthNum = Convert.ToInt32(CharaterPropertyStatic.CharaterProperty_Strength);
                    break;
                }
            case false:
                {
                    break;
                }
        }
        if (LastPoint == 0)
        {
            return;
        }
        else
        {
            StrengthNum++;
            CharaterStrength.text = StrengthNum.ToString();
            LastPoint -= 1;
            CharaterLastPoint.text = LastPoint.ToString();
        }
    }

    public void StrengthLessClick()
    {
        LastPoint = Convert.ToInt32(CharaterLastPoint.text);
        LastPointMax = Convert.ToInt32(CharaterPropertyStatic.CharaterLastPoint);
        switch (StrengthNum == Convert.ToInt32(CharaterPropertyStatic.CharaterProperty_Strength))
        {
            case true:
                {
                    StrengthNum = Convert.ToInt32(CharaterPropertyStatic.CharaterProperty_Strength);
                    break;
                }
            case false:
                {
                    break;
                }
        }
        if (LastPoint == LastPointMax || StrengthNum == 0 || StrengthNum == CharaterPropertyStatic.CharaterProperty_Strength)
        {
            return;
        }
        else
        {
            StrengthNum -= 1;
            CharaterStrength.text = StrengthNum.ToString();
            LastPoint++;
            CharaterLastPoint.text = LastPoint.ToString();
        }
    }

    public void IntelligenceAddClick()
    {
        LastPoint = Convert.ToInt32(CharaterLastPoint.text);
        switch (IntelligenceNum == Convert.ToInt32(CharaterPropertyStatic.CharaterProperty_Intelligence))
        {
            case true:
                {
                    IntelligenceNum = Convert.ToInt32(CharaterPropertyStatic.CharaterProperty_Intelligence);
                    break;
                }
            case false:
                {
                    break;
                }
        }
        if (LastPoint == 0)
        {
            return;
        }
        else
        {
            IntelligenceNum++;
            CharaterIntelligence.text = IntelligenceNum.ToString();
            LastPoint -= 1;
            CharaterLastPoint.text = LastPoint.ToString();
        }
    }

    public void IntelligenceLessClick()
    {
        LastPoint = Convert.ToInt32(CharaterLastPoint.text);
        LastPointMax = Convert.ToInt32(CharaterPropertyStatic.CharaterLastPoint);
        switch (IntelligenceNum == Convert.ToInt32(CharaterPropertyStatic.CharaterProperty_Intelligence))
        {
            case true:
                {
                    IntelligenceNum = Convert.ToInt32(CharaterPropertyStatic.CharaterProperty_Intelligence);
                    break;
                }
            case false:
                {
                    break;
                }
        }
        if (LastPoint == LastPointMax || IntelligenceNum == 0 || IntelligenceNum == CharaterPropertyStatic.CharaterProperty_Intelligence)
        {
            return;
        }
        else
        {
            IntelligenceNum -= 1;
            CharaterIntelligence.text = IntelligenceNum.ToString();
            LastPoint++;
            CharaterLastPoint.text = LastPoint.ToString();
        }
    }

    public void DexterityAddClick()
    {
        LastPoint = Convert.ToInt32(CharaterLastPoint.text);
        switch (DexterityNum == Convert.ToInt32(CharaterPropertyStatic.CharaterProperty_Dexterity))
        {
            case true:
                {
                    DexterityNum = Convert.ToInt32(CharaterPropertyStatic.CharaterProperty_Dexterity);
                    break;
                }
            case false:
                {
                    break;
                }
        }
        if (LastPoint == 0)
        {
            return;
        }
        else
        {
            DexterityNum++;
            DodgeNum++;
            CriticalNum++;
            CharaterDexterity.text = DexterityNum.ToString();
            LastPoint -= 1;
            CharaterLastPoint.text = LastPoint.ToString();
        }
    }

    public void DexterityLessClick()
    {
        LastPoint = Convert.ToInt32(CharaterLastPoint.text);
        LastPointMax = Convert.ToInt32(CharaterPropertyStatic.CharaterLastPoint);
        switch (DexterityNum == Convert.ToInt32(CharaterPropertyStatic.CharaterProperty_Dexterity))
        {
            case true:
                {
                    DexterityNum = Convert.ToInt32(CharaterPropertyStatic.CharaterProperty_Dexterity);
                    break;
                }
            case false:
                {
                    break;
                }
        }
        if (LastPoint == LastPointMax || DexterityNum == 0 || DexterityNum == CharaterPropertyStatic.CharaterProperty_Dexterity)
        {
            return;
        }
        else
        {
            DexterityNum -= 1;
            DodgeNum -= 1;
            CriticalNum -= 1;
            CharaterDexterity.text = DexterityNum.ToString();
            LastPoint++;
            CharaterLastPoint.text = LastPoint.ToString();
        }
    }

    public void ConfirmClick()
    {
        LastPoint = Convert.ToInt32(CharaterLastPoint.text);
        LastPointMax = Convert.ToInt32(CharaterPropertyStatic.CharaterLastPoint);

        if (LastPoint != 0 && LastPoint != LastPointMax)
        {
            OpenMsgBoxClone.CreateMsgBox(12);
        }
        if (LastPoint == 0)
        {
            OpenMsgBoxClone.CreateMsgBox(13);
        }
        if (LastPoint == LastPointMax)
        {
            OpenMsgBoxClone.CreateMsgBox(14);
        }
        else
        {
            Debug.Log("確認有誤!");
        }
    }

    public void SussceConfirm()                                                     //當修改角色能力時，也要修改介面上顯示的能力數值
    {
        LastPoint = Convert.ToInt32(CharaterLastPoint.text);
        LastPointMax = Convert.ToInt32(CharaterPropertyStatic.CharaterLastPoint);

        int OldStrength = Convert.ToInt32(CharaterPropertyStatic.CharaterProperty_Strength);
        int OldIntelligence = Convert.ToInt32(CharaterPropertyStatic.CharaterProperty_Intelligence);
        int OldDexterity = Convert.ToInt32(CharaterPropertyStatic.CharaterProperty_Dexterity);

        if (StrengthNum == 0)
        {

        }
        if (StrengthNum != 0)
        {
            CharaterPropertyStatic.CharaterProperty_Strength = StrengthNum;
        }
        if (IntelligenceNum == 0)
        {

        }
        if (IntelligenceNum != 0)
        {
            CharaterPropertyStatic.CharaterProperty_Intelligence = IntelligenceNum;
        }
        if (DexterityNum == 0)
        {

        }
        if (DexterityNum != 0)
        {
            CharaterPropertyStatic.CharaterProperty_Dexterity = DexterityNum;
        }
        CharaterPropertyStatic.CharaterLastPoint = LastPoint;

        Debug.Log("當前血量百分比:" + PublicFunction.CharaterPropertyValue.CharaterHpNowRate);

        PublicFunctionClone.CharaterPropertyStaticChange();
        PublicFunctionClone.CharaterFileCalculate(OldStrength, OldIntelligence, OldDexterity);
        PublicFunctionClone.CharaterPropertyConversion();

        string FilePath = "Charater_" + CharaterPropertyStatic.CharaterNumber;
        string FileInside;

        PublicFunctionClone.ReadPlatformpersistentDataPath(FilePath);
        FileInside = JsonUtility.ToJson(PublicFunction.CharaterPropertyValue);
        File.WriteAllText(PublicFunction.persistentFilePath, FileInside);

        Debug.Log("當前血量百分比:" + PublicFunction.CharaterPropertyValue.CharaterHpNowRate);

        LoadCharaterProperty();
        IfLastPoint();
        ChangeCharaterProperty();

        EmptyGameObject = GameObject.Find("UI/Prefab_Control");
        MainGameControlClone = EmptyGameObject.GetComponent<MainGameControl>();
        MainGameControlClone.LoadCharaterProperty();

        /*PublicFunctionClone.ReadPlatformpersistentDataPath(FilePath);
        FileInside = JsonUtility.ToJson(PublicFunction.CharaterPropertyValue);
        File.WriteAllText(PublicFunction.persistentFilePath, FileInside);*/

        //-----將角色戰鬥的數值做計算並儲存到CharaterBattleProperty的檔案裡

        //-----
    }

    public void InputCharaterProperty()                                             //載入角色能力數值
    {
        PropertyNameCloneObj = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_Property/Scroll_PropertyList/Mask/Gird_PropertyList/Load_Property/Load_PropertyName");
        PropertyNameClone = PropertyNameCloneObj.GetComponent<Text>();
        PropertyNumCloneObj = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_Property/Scroll_PropertyList/Mask/Gird_PropertyList/Load_Property/Load_PropertyNum");
        PropertyNumClone = PropertyNumCloneObj.GetComponent<Text>();
        PropertyNameClone.text = "血量";
        PropertyNumClone.text = CharaterPropertyStatic.CharaterHp.ToString();
        for (int CloneNum = 1; CloneNum <= 15; CloneNum++)
        {
            EmptyGameObject = Instantiate(PropertyClone, PropertyListClone.transform);
            EmptyGameObject.name = "Load_Property_" + CloneNum;
            PropertyNameCloneObj = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_Property/Scroll_PropertyList/Mask/Gird_PropertyList/Load_Property_" + CloneNum + "/Load_PropertyName");
            PropertyNameClone = PropertyNameCloneObj.GetComponent<Text>();
            PropertyNumCloneObj = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_Property/Scroll_PropertyList/Mask/Gird_PropertyList/Load_Property_" + CloneNum + "/Load_PropertyNum");
            PropertyNumClone = PropertyNumCloneObj.GetComponent<Text>();
            if (CloneNum == 1)
            {
                PropertyNameClone.text = "魔力";
                PropertyNumClone.text = CharaterPropertyStatic.CharaterMp.ToString();
            }
            if (CloneNum == 2)
            {
                PropertyNameClone.text = "物理攻擊";
                PropertyNumClone.text = CharaterPropertyStatic.CharaterPhysicalDamgeMin + "~" + CharaterPropertyStatic.CharaterPhysicalDamgeMax;
            }
            if (CloneNum == 3)
            {
                PropertyNameClone.text = "魔法攻擊";
                PropertyNumClone.text = CharaterPropertyStatic.CharaterMagicDamgeMin + "~" + CharaterPropertyStatic.CharaterMagicDamgeMax;
            }
            if (CloneNum == 4)
            {
                PropertyNameClone.text = "攻擊速度";
                PropertyNumClone.text = CharaterPropertyStatic.CharaterAttackSpeed.ToString();
                Debug.Log("攻擊速度:" + CharaterPropertyStatic.CharaterAttackSpeed);
            }
            if (CloneNum == 5)
            {
                PropertyNameClone.text = "爆擊率";
                PropertyNumClone.text = CharaterPropertyStatic.CharaterCriticalRate + "%";
            }
            if (CloneNum == 6)
            {
                PropertyNameClone.text = "爆擊值";
                PropertyNumClone.text = CharaterPropertyStatic.CharaterCritical + "/" + CharaterPropertyStatic.CharaterCriticalMax;
            }
            if (CloneNum == 7)
            {
                PropertyNameClone.text = "血量回復";
                PropertyNumClone.text = "每秒回復 : " + CharaterPropertyStatic.CharaterHpRecover;
            }
            if (CloneNum == 8)
            {
                PropertyNameClone.text = "魔力回復";
                PropertyNumClone.text = "每秒回復 : " + CharaterPropertyStatic.CharaterMpRecover;
            }
            if (CloneNum == 9)
            {
                PropertyNameClone.text = "物理抵抗率";
                PropertyNumClone.text = CharaterPropertyStatic.CharaterPhysicalResistRate + "%";
            }
            if (CloneNum == 10)
            {
                PropertyNameClone.text = "物理抵抗值";
                PropertyNumClone.text = CharaterPropertyStatic.CharaterPhysicalResist + "/" + CharaterPropertyStatic.CharaterPhysicalResistMax;
            }
            if (CloneNum == 11)
            {
                PropertyNameClone.text = "魔法護盾值";
                PropertyNumClone.text = CharaterPropertyStatic.CharaterMagicShield.ToString();
            }
            if (CloneNum == 12)
            {
                PropertyNameClone.text = "魔法護盾回復";
                PropertyNumClone.text = "每秒回復 : " + CharaterPropertyStatic.CharaterMagicShieldRecover;
            }
            if (CloneNum == 13)
            {
                PropertyNameClone.text = "閃避率";
                PropertyNumClone.text = CharaterPropertyStatic.CharaterDodgeRate + "%";
            }
            if (CloneNum == 14)
            {
                PropertyNameClone.text = "閃避值";
                PropertyNumClone.text = CharaterPropertyStatic.CharaterDodge + "/" + CharaterPropertyStatic.CharaterDodgeMax;
            }
            if (CloneNum == 15)
            {
                PropertyNameClone.text = "經驗值";
                PropertyNumClone.text = CharaterPropertyStatic.CharaterExpNow + "/" + CharaterPropertyStatic.CharaterExp;
            }
        }
    }

    public void ChangeCharaterProperty()                                            //當有角色能力數值更動，使用此功能修改介面上顯示的數值
    {
        PropertyNameCloneObj = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_Property/Scroll_PropertyList/Mask/Gird_PropertyList/Load_Property/Load_PropertyName");
        PropertyNameClone = PropertyNameCloneObj.GetComponent<Text>();
        PropertyNumCloneObj = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_Property/Scroll_PropertyList/Mask/Gird_PropertyList/Load_Property/Load_PropertyNum");
        PropertyNumClone = PropertyNumCloneObj.GetComponent<Text>();
        PropertyNameClone.text = "血量";
        PropertyNumClone.text = CharaterPropertyStatic.CharaterHp.ToString();
        for (int CloneNum = 1; CloneNum <= 14; CloneNum++)
        {
            //EmptyGameObject.name = "Load_Property_" + CloneNum;
            PropertyNameCloneObj = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_Property/Scroll_PropertyList/Mask/Gird_PropertyList/Load_Property_" + CloneNum + "/Load_PropertyName");
            PropertyNameClone = PropertyNameCloneObj.GetComponent<Text>();
            PropertyNumCloneObj = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_Property/Scroll_PropertyList/Mask/Gird_PropertyList/Load_Property_" + CloneNum + "/Load_PropertyNum");
            PropertyNumClone = PropertyNumCloneObj.GetComponent<Text>();
            if (CloneNum == 1)
            {
                PropertyNameClone.text = "魔力";
                PropertyNumClone.text = CharaterPropertyStatic.CharaterMp.ToString();
            }
            if (CloneNum == 2)
            {
                PropertyNameClone.text = "物理攻擊";
                PropertyNumClone.text = CharaterPropertyStatic.CharaterPhysicalDamgeMin + "~" + CharaterPropertyStatic.CharaterPhysicalDamgeMax;
            }
            if (CloneNum == 3)
            {
                PropertyNameClone.text = "魔法攻擊";
                PropertyNumClone.text = CharaterPropertyStatic.CharaterMagicDamgeMin + "~" + CharaterPropertyStatic.CharaterMagicDamgeMax;
            }
            if (CloneNum == 4)
            {
                PropertyNameClone.text = "攻擊速度";
                PropertyNumClone.text = CharaterPropertyStatic.CharaterAttackSpeed.ToString();
                Debug.Log("攻擊速度:" + CharaterPropertyStatic.CharaterAttackSpeed);
            }
            if (CloneNum == 5)
            {
                PropertyNameClone.text = "爆擊率";
                PropertyNumClone.text = CharaterPropertyStatic.CharaterCriticalRate + "%";
            }
            if (CloneNum == 6)
            {
                PropertyNameClone.text = "爆擊值";
                PropertyNumClone.text = CharaterPropertyStatic.CharaterCritical + "/" + CharaterPropertyStatic.CharaterCriticalMax;
            }
            if (CloneNum == 7)
            {
                PropertyNameClone.text = "血量回復";
                PropertyNumClone.text = "每秒回復 : " + CharaterPropertyStatic.CharaterHpRecover;
            }
            if (CloneNum == 8)
            {
                PropertyNameClone.text = "魔力回復";
                PropertyNumClone.text = "每秒回復 : " + CharaterPropertyStatic.CharaterMpRecover;
            }
            if (CloneNum == 9)
            {
                PropertyNameClone.text = "物理抵抗率";
                PropertyNumClone.text = CharaterPropertyStatic.CharaterPhysicalResistRate + "%";
            }
            if (CloneNum == 10)
            {
                PropertyNameClone.text = "物理抵抗值";
                PropertyNumClone.text = CharaterPropertyStatic.CharaterPhysicalResist + "/" + CharaterPropertyStatic.CharaterPhysicalResistMax;
            }
            if (CloneNum == 11)
            {
                PropertyNameClone.text = "魔法護盾值";
                PropertyNumClone.text = CharaterPropertyStatic.CharaterMagicShield.ToString();
            }
            if (CloneNum == 12)
            {
                PropertyNameClone.text = "魔法護盾回復";
                PropertyNumClone.text = "每秒回復 : " + CharaterPropertyStatic.CharaterMagicShieldRecover;
            }
            if (CloneNum == 13)
            {
                PropertyNameClone.text = "閃避率";
                PropertyNumClone.text = CharaterPropertyStatic.CharaterDodgeRate + "%";
            }
            if (CloneNum == 14)
            {
                PropertyNameClone.text = "閃避值";
                PropertyNumClone.text = CharaterPropertyStatic.CharaterDodge + "/" + CharaterPropertyStatic.CharaterDodgeMax;
            }
            if (CloneNum == 15)
            {
                PropertyNameClone.text = "經驗值";
                PropertyNumClone.text = CharaterPropertyStatic.CharaterExp + "/" + 100;
            }
        }
    }

    public void ChangeCharaterInfoProperty()                                        //切換成數值，角色頁面上數值跟裝備頁籤按鈕切換的變換
    {
        CharaterInfoPropertyImage.sprite = SpriteChange.GetSprite("button_ready_on_1");
        CharaterInfoArmImage.sprite = SpriteChange.GetSprite("button_ready_off");

        CharaterInfoProperty.SetActive(true);
        CharaterInfoArm.SetActive(false);
        CharaterInfoArmLoad_Num.SetActive(false);
        //CharaterInfoArmBtn_Reflash.SetActive(false);
    }

    public void ChangeCharaterInfoArm()                                             //切換成裝備，角色頁面上數值跟裝備頁籤按鈕切換的變換
    {
        CharaterInfoPropertyImage.sprite = SpriteChange.GetSprite("button_ready_off");
        CharaterInfoArmImage.sprite = SpriteChange.GetSprite("button_ready_on_1");

        CharaterInfoProperty.SetActive(false);
        CharaterInfoArm.SetActive(true);
        CharaterInfoArmLoad_Num.SetActive(true);
        //CharaterInfoArmBtn_Reflash.SetActive(true);
    }

    public void CharaterArmList()                                                   //顯示裝備列表
    {
        CheckCharaterArmList();
        //Debug.Log("排序前的陣列內的數字跟排序:" + CharaterArm[0] + "\n" + CharaterArm[1] + "\n" + CharaterArm[2] + "\n" + CharaterArm[3] + "\n" + CharaterArm[4]);

        //-----泡沫排序法，將按照小排到大
        for (int oldnum = CharaterArmCount; oldnum >= 0; oldnum--)
        {
            for (int arrayNum = 0; arrayNum < CharaterArmCount - 1; arrayNum++)
            {
                if (CharaterArm[arrayNum + 1] < CharaterArm[arrayNum])
                {
                    int OldNum = CharaterArm[arrayNum];
                    CharaterArm[arrayNum] = CharaterArm[arrayNum + 1];
                    CharaterArm[arrayNum + 1] = OldNum;
                }
            }
        }

        for(int num = 0; num < CharaterArmCount; num++)
		{
            int numadd = num + 1;
            Debug.Log("陣列裡第" + numadd + "個裝備編號是:" + CharaterArm[num]);
		}

        /*for (int arrayNum = 0; arrayNum < CharaterArmCount-1; arrayNum++)             //這邊的做法是可以進行排序，但不清楚為什麼可以。所以決定先註解掉
        {
            if(CharaterArm[CharaterArmCount-1] < CharaterArm[CharaterArmCount - 2])
            {
                int OldNum = CharaterArm[CharaterArmCount - 2];
                CharaterArm[CharaterArmCount - 2] = CharaterArm[CharaterArmCount - 1];
                CharaterArm[CharaterArmCount - 1] = OldNum;
            }
            if (CharaterArm[arrayNum + 1] < CharaterArm[arrayNum])
            {
                int OldNum = CharaterArm[arrayNum];
                CharaterArm[arrayNum] = CharaterArm[arrayNum + 1];
                CharaterArm[arrayNum + 1] = OldNum;
            }
        }*/
        //-----
        //Debug.Log("陣列內的數字跟排序:" + CharaterArm[0] + "\n" + CharaterArm[1] + "\n" + CharaterArm[2] + "\n" + CharaterArm[3] + "\n" + CharaterArm[4]);

        ArmNumCloneText = ArmNumClone.GetComponent<Text>();
        ArmNumCloneText.text = "數量:" + CharaterArmCount + "/100";

        for (int Num = 0; Num < CharaterArmCount; Num++)
        {
            PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, CharaterArm[Num]);
            PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
            switch (CharaterArmStatic.ArmEquip)
            {
                case true:
                    {
                        EmptyGameObject = Instantiate(CharaterArmClone, CharaterArmListObj.transform);
                        EmptyGameObject.name = "Load_Arm_" + CharaterArm[Num] + "_New";
                        CharaterArmIconClone = EmptyGameObject.transform.GetChild(1).gameObject;
                        ArmIconClone = CharaterArmIconClone.GetComponent<Image>();
                        CharaterArmEquip = EmptyGameObject.transform.GetChild(2).gameObject;
                        ArmIconClone.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                        CharaterInfo_ArmList ArmListScritp = EmptyGameObject.GetComponent<CharaterInfo_ArmList>();
                        ArmListScritp.ArmNum = CharaterArm[Num];
                        CharaterArmEquip.SetActive(true);
                        break;
                    }
                case false:
                    {
                        EmptyGameObject = Instantiate(CharaterArmClone, CharaterArmListObj.transform);
                        EmptyGameObject.name = "Load_Arm_" + CharaterArm[Num] + "_NotEquip";
                        CharaterArmIconClone = EmptyGameObject.transform.GetChild(1).gameObject;
                        ArmIconClone = CharaterArmIconClone.GetComponent<Image>();
                        CharaterArmEquip = EmptyGameObject.transform.GetChild(2).gameObject;
                        ArmIconClone.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                        CharaterInfo_ArmList ArmListScritp = EmptyGameObject.GetComponent<CharaterInfo_ArmList>();
                        ArmListScritp.ArmNum = CharaterArm[Num];
                        CharaterArmEquip.SetActive(false);
                        break;
                    }
            }
        }

        /*for (int Num = 0; Num < CharaterArmCount; Num++)
        {
            PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, CharaterArm[Num]);
            PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
            switch (CharaterArmStatic.ArmEquip)
            {
                case true:
                    {
                        break;
                    }
                case false:
                    {
                        EmptyGameObject = Instantiate(CharaterArmClone, CharaterArmListObj.transform);
                        EmptyGameObject.name = "Load_Arm_" + CharaterArm[Num] + "_NotEquip";
                        CharaterArmIconClone = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + CharaterArm[Num] + "_NotEquip" + "/Load_ArmIcon");
                        ArmIconClone = CharaterArmIconClone.GetComponent<Image>();
                        CharaterArmEquip = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + CharaterArm[Num] + "_NotEquip" + "/Load_Equip");
                        ArmIconClone.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                        ArmList = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + CharaterArm[Num] + "_NotEquip");
                        CharaterInfo_ArmList ArmListScritp = ArmList.GetComponent<CharaterInfo_ArmList>();
                        ArmListScritp.ArmNum = CharaterArm[Num];
                        CharaterArmEquip.SetActive(false);
                        break;
                    }
            }
        }*/

        //-----這個辦法本來是用裝備id來區分該裝備是否有被裝備以及該裝備是裝備在哪個欄位，但後來發現太複雜容易造成錯誤，故此放棄此方法
        /*for (int ArmNum = 0; ArmNum < CharaterArmCount; ArmNum++)
        {
            PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, CharaterArm[ArmNum]);
            PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);

            switch (CharaterArm[ArmNum])
            {
                case 0:
                    {
                        Arm_0.SetActive(true);
                        CharaterArmIconClone = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + CharaterArm[ArmNum] + "/Load_ArmIcon");
                        ArmIconClone = CharaterArmIconClone.GetComponent<Image>();
                        CharaterArmEquip = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + CharaterArm[ArmNum] + "/Load_Equip");
                        ArmIconClone.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                        CharaterArmEquip.SetActive(true);
                        break;
                    }
                case 1:
                    {
                        Arm_1.SetActive(true);
                        CharaterArmIconClone = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + CharaterArm[ArmNum] + "/Load_ArmIcon");
                        ArmIconClone = CharaterArmIconClone.GetComponent<Image>();
                        CharaterArmEquip = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + CharaterArm[ArmNum] + "/Load_Equip");
                        ArmIconClone.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                        CharaterArmEquip.SetActive(true);
                        break;
                    }
                case 2:
                    {
                        Arm_2.SetActive(true);
                        CharaterArmIconClone = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + CharaterArm[ArmNum] + "/Load_ArmIcon");
                        ArmIconClone = CharaterArmIconClone.GetComponent<Image>();
                        CharaterArmEquip = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + CharaterArm[ArmNum] + "/Load_Equip");
                        ArmIconClone.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                        CharaterArmEquip.SetActive(true);
                        break;
                    }
                case 3:
                    {
                        Arm_3.SetActive(true);
                        CharaterArmIconClone = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + CharaterArm[ArmNum] + "/Load_ArmIcon");
                        ArmIconClone = CharaterArmIconClone.GetComponent<Image>();
                        CharaterArmEquip = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + CharaterArm[ArmNum] + "/Load_Equip");
                        ArmIconClone.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                        CharaterArmEquip.SetActive(true);
                        break;
                    }
                case 4:
                    {
                        Arm_4.SetActive(true);
                        CharaterArmIconClone = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + CharaterArm[ArmNum] + "/Load_ArmIcon");
                        ArmIconClone = CharaterArmIconClone.GetComponent<Image>();
                        CharaterArmEquip = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + CharaterArm[ArmNum] + "/Load_Equip");
                        ArmIconClone.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                        CharaterArmEquip.SetActive(true);
                        break;
                    }
                case 5:
                    {
                        Arm_5.SetActive(true);
                        CharaterArmIconClone = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + CharaterArm[ArmNum] + "/Load_ArmIcon");
                        ArmIconClone = CharaterArmIconClone.GetComponent<Image>();
                        CharaterArmEquip = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + CharaterArm[ArmNum] + "/Load_Equip");
                        ArmIconClone.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                        CharaterArmEquip.SetActive(true);
                        break;
                    }
                case 6:
                    {
                        Arm_6.SetActive(true);
                        CharaterArmIconClone = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + CharaterArm[ArmNum] + "/Load_ArmIcon");
                        ArmIconClone = CharaterArmIconClone.GetComponent<Image>();
                        CharaterArmEquip = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + CharaterArm[ArmNum] + "/Load_Equip");
                        ArmIconClone.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                        CharaterArmEquip.SetActive(true);
                        break;
                    }
                case 7:
                    {
                        Arm_7.SetActive(true);
                        CharaterArmIconClone = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + CharaterArm[ArmNum] + "/Load_ArmIcon");
                        ArmIconClone = CharaterArmIconClone.GetComponent<Image>();
                        CharaterArmEquip = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + CharaterArm[ArmNum] + "/Load_Equip");
                        ArmIconClone.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                        CharaterArmEquip.SetActive(true);
                        break;
                    }
                case 8:
                    {
                        Arm_8.SetActive(true);
                        CharaterArmIconClone = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + CharaterArm[ArmNum] + "/Load_ArmIcon");
                        ArmIconClone = CharaterArmIconClone.GetComponent<Image>();
                        CharaterArmEquip = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + CharaterArm[ArmNum] + "/Load_Equip");
                        ArmIconClone.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                        CharaterArmEquip.SetActive(true);
                        break;
                    }
                case 9:
                    {
                        Arm_9.SetActive(true);
                        CharaterArmIconClone = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + CharaterArm[ArmNum] + "/Load_ArmIcon");
                        ArmIconClone = CharaterArmIconClone.GetComponent<Image>();
                        CharaterArmEquip = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + CharaterArm[ArmNum] + "/Load_Equip");
                        ArmIconClone.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                        CharaterArmEquip.SetActive(true);
                        break;
                    }
                default:
                    {
                        EmptyGameObject = Instantiate(CharaterArmClone, CharaterArmListObj.transform);
                        EmptyGameObject.name = "Load_Arm_" + CharaterArm[ArmNum];
                        CharaterArmIconClone = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + CharaterArm[ArmNum] + "/Load_ArmIcon");
                        ArmIconClone = CharaterArmIconClone.GetComponent<Image>();
                        CharaterArmEquip = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + CharaterArm[ArmNum] + "/Load_Equip");
                        ArmIconClone.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                        ArmList = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + CharaterArm[ArmNum]);
                        CharaterInfo_ArmList ArmListScritp = ArmList.GetComponent<CharaterInfo_ArmList>();
                        ArmListScritp.ArmNum = CharaterArmStatic.id;
                        CharaterArmEquip.SetActive(false);
                        break;
                    }
            }
        }*/
    }

    public void InputEquipmentArm()                                                 //載入裝備欄位上的裝備ICON圖
    {
        for (int ArmNum = 0; ArmNum < CharaterArmCount; ArmNum++)
        {
            PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, CharaterArm[ArmNum]);
            PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);

            switch (CharaterArmStatic.ArmEquip)
            {
                case true:
                    {
                        switch (ArmStatic.ArmType)
                        {
                            case 0:
                                {
                                    switch (CharaterArmStatic.ArmMain)
                                    {
                                        case 0:
                                            {
                                                MainWeapon.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                                MainWeaponCharaterArmId.text = CharaterArm[ArmNum].ToString();
                                                break;
                                            }
                                        case 1:
                                            {
                                                SecondWeapon.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                                SecondWeaponCharaterArmId.text = CharaterArm[ArmNum].ToString();
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    Head.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                    HeadCharaterArmId.text = CharaterArm[ArmNum].ToString();
                                    break;
                                }
                            case 2:
                                {
                                    Body.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                    BodyCharaterArmId.text = CharaterArm[ArmNum].ToString();
                                    break;
                                }
                            case 3:
                                {
                                    switch (CharaterArmStatic.ArmMain)
                                    {
                                        case 0:
                                            {
                                                MainRing.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                                MainRingCharaterArmId.text = CharaterArm[ArmNum].ToString();
                                                break;
                                            }
                                        case 1:
                                            {
                                                SecondRing.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                                SecondRingCharaterArmId.text = CharaterArm[ArmNum].ToString();
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 4:
                                {
                                    Necklace.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                    NecklaceCharaterArmId.text = CharaterArm[ArmNum].ToString();
                                    break;
                                }
                            case 5:
                                {
                                    Hand.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                    HandCharaterArmId.text = CharaterArm[ArmNum].ToString();
                                    break;
                                }
                            case 6:
                                {
                                    Belt.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                    BeltCharaterArmId.text = CharaterArm[ArmNum].ToString();
                                    break;
                                }
                            case 7:
                                {
                                    Foot.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                    FootCharaterArmId.text = CharaterArm[ArmNum].ToString();
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

            //-----原本是打算用角色裝備的ID來判斷那些裝備是有被裝備上的，但這個方法有點多餘，所以要改成用Equip來判斷
            /*switch(CharaterArmStatic.id)
			{
                case 0:
					{
                        MainWeapon.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                        break;
					}
                case 1:
                    {
                        SecondWeapon.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                        break;
                    }
                case 2:
                    {
                        Head.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                        break;
                    }
                case 3:
                    {
                        Body.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                        break;
                    }
                case 4:
                    {
                        MainRing.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                        break;
                    }
                case 5:
                    {
                        SecondRing.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                        break;
                    }
                case 6:
                    {
                        Necklace.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                        break;
                    }
                case 7:
                    {
                        Hand.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                        break;
                    }
                case 8:
                    {
                        Belt.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                        break;
                    }
                case 9:
                    {
                        Foot.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                        break;
                    }
                default:
					{
                        break;
					}

            }*/

            //-----原本是使用if來做裝備ICON上的顯示判斷，但改成switch會比較好，也不容易有意料之外的情況產生
            /*if (CharaterArmStatic.id == 0)
            {
                MainWeapon.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
            }
            if (CharaterArmStatic.id == 1)
            {
                SecondWeapon.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
            }
            if (CharaterArmStatic.id == 2)
            {
                Head.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
            }
            if (CharaterArmStatic.id == 3)
            {
                Body.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
            }
            if (CharaterArmStatic.id == 4)
            {
                MainRing.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
            }
            if (CharaterArmStatic.id == 5)
            {
                SecondRing.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
            }
            if (CharaterArmStatic.id == 6)
            {
                Necklace.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
            }
            if (CharaterArmStatic.id == 7)
            {
                Hand.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
            }
            if (CharaterArmStatic.id == 8)
            {
                Belt.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
            }
            if (CharaterArmStatic.id == 9)
            {
                Foot.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
            }*/
            //-----
        }
    }

    public class JsonArm<T>                                                         //角色裝備表所使用的List，來協助unity可以讀取陣列(Array)裡的資料
    {
        public List<T> CharaterArm;
    }

    public void ChangeArmListNew(int ArmNum, int NewArmId)
    {
        EmptyGameObject = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + ArmNum);
        switch (ArmNum)
        {
            case 0:
                {
                    EmptyGameObject.SetActive(false);
                    MainWeapon.sprite = SpriteArmIcon.GetSprite("Unequip");
                    break;
                }
            case 1:
                {
                    EmptyGameObject.SetActive(false);
                    SecondWeapon.sprite = SpriteArmIcon.GetSprite("Unequip");
                    break;
                }
            case 2:
                {
                    EmptyGameObject.SetActive(false);
                    Head.sprite = SpriteArmIcon.GetSprite("Unequip");
                    break;
                }
            case 3:
                {
                    EmptyGameObject.SetActive(false);
                    Body.sprite = SpriteArmIcon.GetSprite("Unequip");
                    break;
                }
            case 4:
                {
                    EmptyGameObject.SetActive(false);
                    MainRing.sprite = SpriteArmIcon.GetSprite("Unequip");
                    break;
                }
            case 5:
                {
                    EmptyGameObject.SetActive(false);
                    SecondRing.sprite = SpriteArmIcon.GetSprite("Unequip");
                    break;
                }
            case 6:
                {
                    EmptyGameObject.SetActive(false);
                    Necklace.sprite = SpriteArmIcon.GetSprite("Unequip");
                    break;
                }
            case 7:
                {
                    EmptyGameObject.SetActive(false);
                    Hand.sprite = SpriteArmIcon.GetSprite("Unequip");
                    break;
                }
            case 8:
                {
                    EmptyGameObject.SetActive(false);
                    Belt.sprite = SpriteArmIcon.GetSprite("Unequip");
                    break;
                }
            case 9:
                {
                    EmptyGameObject.SetActive(false);
                    Foot.sprite = SpriteArmIcon.GetSprite("Unequip");
                    break;
                }
            default:
                {
                    Destroy(EmptyGameObject);
                    break;
                }
        }
        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, NewArmId);
        PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
        switch (NewArmId)
        {
            case 0:
                {
                    Arm_0.SetActive(true);
                    CharaterArmIconClone = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + NewArmId + "/Load_ArmIcon");
                    ArmIconClone = CharaterArmIconClone.GetComponent<Image>();
                    CharaterArmEquip = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + NewArmId + "/Load_Equip");
                    ArmIconClone.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                    CharaterArmEquip.SetActive(true);
                    break;
                }
            case 1:
                {
                    Arm_1.SetActive(true);
                    CharaterArmIconClone = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + NewArmId + "/Load_ArmIcon");
                    ArmIconClone = CharaterArmIconClone.GetComponent<Image>();
                    CharaterArmEquip = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + NewArmId + "/Load_Equip");
                    ArmIconClone.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                    CharaterArmEquip.SetActive(true);
                    break;
                }
            case 2:
                {
                    Arm_2.SetActive(true);
                    CharaterArmIconClone = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + NewArmId + "/Load_ArmIcon");
                    ArmIconClone = CharaterArmIconClone.GetComponent<Image>();
                    CharaterArmEquip = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + NewArmId + "/Load_Equip");
                    ArmIconClone.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                    CharaterArmEquip.SetActive(true);
                    break;
                }
            case 3:
                {
                    Arm_3.SetActive(true);
                    CharaterArmIconClone = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + NewArmId + "/Load_ArmIcon");
                    ArmIconClone = CharaterArmIconClone.GetComponent<Image>();
                    CharaterArmEquip = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + NewArmId + "/Load_Equip");
                    ArmIconClone.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                    CharaterArmEquip.SetActive(true);
                    break;
                }
            case 4:
                {
                    Arm_4.SetActive(true);
                    CharaterArmIconClone = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + NewArmId + "/Load_ArmIcon");
                    ArmIconClone = CharaterArmIconClone.GetComponent<Image>();
                    CharaterArmEquip = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + NewArmId + "/Load_Equip");
                    ArmIconClone.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                    CharaterArmEquip.SetActive(true);
                    break;
                }
            case 5:
                {
                    Arm_5.SetActive(true);
                    CharaterArmIconClone = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + NewArmId + "/Load_ArmIcon");
                    ArmIconClone = CharaterArmIconClone.GetComponent<Image>();
                    CharaterArmEquip = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + NewArmId + "/Load_Equip");
                    ArmIconClone.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                    CharaterArmEquip.SetActive(true);
                    break;
                }
            case 6:
                {
                    Arm_6.SetActive(true);
                    CharaterArmIconClone = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + NewArmId + "/Load_ArmIcon");
                    ArmIconClone = CharaterArmIconClone.GetComponent<Image>();
                    CharaterArmEquip = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + NewArmId + "/Load_Equip");
                    ArmIconClone.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                    CharaterArmEquip.SetActive(true);
                    break;
                }
            case 7:
                {
                    Arm_7.SetActive(true);
                    CharaterArmIconClone = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + NewArmId + "/Load_ArmIcon");
                    ArmIconClone = CharaterArmIconClone.GetComponent<Image>();
                    CharaterArmEquip = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + NewArmId + "/Load_Equip");
                    ArmIconClone.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                    CharaterArmEquip.SetActive(true);
                    break;
                }
            case 8:
                {
                    Arm_8.SetActive(true);
                    CharaterArmIconClone = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + NewArmId + "/Load_ArmIcon");
                    ArmIconClone = CharaterArmIconClone.GetComponent<Image>();
                    CharaterArmEquip = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + NewArmId + "/Load_Equip");
                    ArmIconClone.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                    CharaterArmEquip.SetActive(true);
                    break;
                }
            case 9:
                {
                    Arm_9.SetActive(true);
                    CharaterArmIconClone = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + NewArmId + "/Load_ArmIcon");
                    ArmIconClone = CharaterArmIconClone.GetComponent<Image>();
                    CharaterArmEquip = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + NewArmId + "/Load_Equip");
                    ArmIconClone.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                    CharaterArmEquip.SetActive(true);
                    break;
                }
            default:
                {
                    EmptyGameObject = Instantiate(CharaterArmClone, CharaterArmListObj.transform);
                    EmptyGameObject.name = "Load_Arm_" + NewArmId;
                    CharaterArmIconClone = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + NewArmId + "/Load_ArmIcon");
                    ArmIconClone = CharaterArmIconClone.GetComponent<Image>();
                    CharaterArmEquip = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + NewArmId + "/Load_Equip");
                    ArmIconClone.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                    ArmList = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/Load_Arm_" + NewArmId);
                    CharaterInfo_ArmList ArmListScritp = ArmList.GetComponent<CharaterInfo_ArmList>();
                    ArmListScritp.ArmNum = NewArmId;
                    CharaterArmEquip.SetActive(false);
                    break;
                }
        }
    }

    public void InputEquipmentArmOther(int NewArmId)                                //載入裝備欄位上的裝備ICON圖
    {
        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, NewArmId);
        PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);

        switch (CharaterArmStatic.ArmEquip)
        {
            case true:
                {
                    switch (ArmStatic.ArmType)
                    {
                        case 0:
                            {
                                switch (CharaterArmStatic.ArmMain)
                                {
                                    case 0:
                                        {
                                            MainWeapon.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                            break;
                                        }
                                    case 1:
                                        {
                                            SecondWeapon.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                            break;
                                        }
                                }
                                break;
                            }
                        case 1:
                            {
                                Head.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                break;
                            }
                        case 2:
                            {
                                Body.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                break;
                            }
                        case 3:
                            {
                                switch (CharaterArmStatic.ArmMain)
                                {
                                    case 0:
                                        {
                                            MainRing.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                            break;
                                        }
                                    case 1:
                                        {
                                            SecondRing.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                            break;
                                        }
                                }
                                break;
                            }
                        case 4:
                            {
                                Necklace.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                break;
                            }
                        case 5:
                            {
                                Hand.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                break;
                            }
                        case 6:
                            {
                                Belt.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                break;
                            }
                        case 7:
                            {
                                Foot.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
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

        //-----原本是打算用角色裝備的ID來判斷那些裝備是有被裝備上的，但這個方法有點多餘，所以要改成用Equip來判斷
        /*if (CharaterArmStatic.id == 0)
        {
            MainWeapon.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
        }
        if (CharaterArmStatic.id == 1)
        {
            SecondWeapon.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
        }
        if (CharaterArmStatic.id == 2)
        {
            Head.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
        }
        if (CharaterArmStatic.id == 3)
        {
            Body.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
        }
        if (CharaterArmStatic.id == 4)
        {
            MainRing.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
        }
        if (CharaterArmStatic.id == 5)
        {
            SecondRing.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
        }
        if (CharaterArmStatic.id == 6)
        {
            Necklace.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
        }
        if (CharaterArmStatic.id == 7)
        {
            Hand.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
        }
        if (CharaterArmStatic.id == 8)
        {
            Belt.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
        }
        if (CharaterArmStatic.id == 9)
        {
            Foot.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
        }*/
        //-----
    }

    public void CheckCharaterArmList()                                              //用來檢查裝備檔案裡有多少裝備數量，記得之後製作獲得道具和失去道具功能後要使用此功能來修改裝備數量
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

        CharaterArmCount = FileJson.CharaterArm.Count;
        CharaterArm = new int[CharaterArmCount];

        for (int i = 0; i < CharaterArmCount; i++)
        {
            CharaterArm[i] = FileJson.CharaterArm[i].id;
        }
    }

    public void ChangArmNum(int ArmNum)                                             //用來處理卸下裝備後裝備ID的變動，這個功能之後不會使用
    {
        string CharaterArmFileName = "Charater_" + CharaterPropertyStatic.CharaterNumber + "_Arm.json";
        string CharaterArmFilePath;

        if (Application.platform == RuntimePlatform.Android)
        {
            string jsonpath = Application.persistentDataPath;
            string datapath = Path.Combine(jsonpath, CharaterArmFileName);

            CharaterArmFilePath = datapath;
        }
        else
        {
            string jsonpath = Application.persistentDataPath;
            string datapath = Path.Combine(jsonpath, CharaterArmFileName);

            CharaterArmFilePath = datapath;
        }

        string DataRead = File.ReadAllText(CharaterArmFilePath);

        JsonArm<CharaterArm> FileJson = JsonUtility.FromJson<JsonArm<CharaterArm>>(DataRead);

        CharaterArmCount = FileJson.CharaterArm.Count;
        CharaterArm = new int[CharaterArmCount];

        for (int i = 0; i < CharaterArmCount; i++)
        {
            CharaterArm[i] = FileJson.CharaterArm[i].id;
        }

        Debug.Log("陣列數量:" + CharaterArmCount);
        Debug.Log(CharaterArm[0]);

        for (int arrayNum = 0; arrayNum < CharaterArmCount - 1; arrayNum++)
        {
            if (CharaterArm[arrayNum + 1] < CharaterArm[arrayNum])
            {
                int OldNum = CharaterArm[arrayNum];
                CharaterArm[arrayNum] = CharaterArm[arrayNum + 1];
                CharaterArm[arrayNum + 1] = OldNum;
            }
        }

        foreach (CharaterArm Data in FileJson.CharaterArm)
        {
            if (Data.id == ArmNum)
            {
                Data.ArmEquip = false;
            }
        }

        /*foreach (CharaterArm Data in FileJson.CharaterArm)
        {
            if (Data.id == ArmNum)
            {
                if (CharaterArmCount <= 10)
                {
                    if (CharaterArm[CharaterArmCount - 1] < 10)
                    {
                        Data.id = 10;
                        Data.ArmEquip = false;
                    }
                    if (CharaterArm[CharaterArmCount - 1] == 10)
                    {
                        Data.id = 11;
                        Data.ArmEquip = false;
                    }
                    if (CharaterArm[CharaterArmCount - 1] > 10)
                    {
                        Data.id = CharaterArm[CharaterArmCount - 1] + 1;
                        Data.ArmEquip = false;
                    }
                }
                if (CharaterArmCount > 10)
                {
                    Data.id = CharaterArm[CharaterArmCount - 1] + 1;
                    Data.ArmEquip = false;
                }
            }
        }*/
        DataRead = JsonUtility.ToJson(FileJson);
        File.WriteAllText(CharaterArmFilePath, DataRead);
    }

    public void PlusArmInfoNew(int CharaterNum)                                     //將所有裝備上的數值都加到CharaterPropertyStatic裡
    {
        CheckCharaterArmList();
        for (int arrayNum = 0; arrayNum < CharaterArmCount - 1; arrayNum++)
        {
            if (CharaterArm[CharaterArmCount - 1] < CharaterArm[CharaterArmCount - 2])
            {
                int OldNum = CharaterArm[CharaterArmCount - 2];
                CharaterArm[CharaterArmCount - 2] = CharaterArm[CharaterArmCount - 1];
                CharaterArm[CharaterArmCount - 1] = OldNum;
            }
            if (CharaterArm[arrayNum + 1] < CharaterArm[arrayNum])
            {
                int OldNum = CharaterArm[arrayNum];
                CharaterArm[arrayNum] = CharaterArm[arrayNum + 1];
                CharaterArm[arrayNum + 1] = OldNum;
            }
        }

        for (int ArmNum = 0; ArmNum < CharaterArmCount; ArmNum++)
        {
            PublicFunctionClone.ReadCharaterArm(CharaterNum, CharaterArm[ArmNum]);
            PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
            switch (CharaterArm[ArmNum])
            {
                case 0:
                    {
                        Debug.Log("最小物理攻擊值" + ArmStatic.WeaponDamageMin + "最大物理攻擊值" + ArmStatic.WeaponDamageMin);
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
                        switch (CharaterPropertyStatic.CharaterAttackSpeed > ArmStatic.WeaponSpeed)
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
                case 1:
                    {
                        Debug.Log("最小物理攻擊值" + ArmStatic.WeaponDamageMin + "最大物理攻擊值" + ArmStatic.WeaponDamageMin);
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
                        switch (CharaterPropertyStatic.CharaterAttackSpeed > ArmStatic.WeaponSpeed)
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
                case 2:
                    {
                        Debug.Log("護甲" + ArmStatic.ArmArmor + "法術護盾" + ArmStatic.ArmMagicShield + "閃避值" + ArmStatic.ArmDodge);
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
                        Debug.Log("護甲" + ArmStatic.ArmArmor + "法術護盾" + ArmStatic.ArmMagicShield + "閃避值" + ArmStatic.ArmDodge);
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
                        Debug.Log("護甲" + ArmStatic.ArmArmor + "法術護盾" + ArmStatic.ArmMagicShield + "閃避值" + ArmStatic.ArmDodge);
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
                        Debug.Log("護甲" + ArmStatic.ArmArmor + "法術護盾" + ArmStatic.ArmMagicShield + "閃避值" + ArmStatic.ArmDodge);
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
                        Debug.Log("護甲" + ArmStatic.ArmArmor + "法術護盾" + ArmStatic.ArmMagicShield + "閃避值" + ArmStatic.ArmDodge);
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
                        Debug.Log("護甲" + ArmStatic.ArmArmor + "法術護盾" + ArmStatic.ArmMagicShield + "閃避值" + ArmStatic.ArmDodge);
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
                        Debug.Log("護甲" + ArmStatic.ArmArmor + "法術護盾" + ArmStatic.ArmMagicShield + "閃避值" + ArmStatic.ArmDodge);
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
                        Debug.Log("護甲" + ArmStatic.ArmArmor + "法術護盾" + ArmStatic.ArmMagicShield + "閃避值" + ArmStatic.ArmDodge);
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

    public void PowerListSwitchIdNew(int PowerId, float PowerMin, float PowerMax)   //將該裝備上擁有的詞綴數值加到CharaterProperty裡
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

    public void PowerSwitchIdNew()                                                  //讀取每個裝備上每個詞綴的數值
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

    public void UnEquipInputICON()                                                  //卸下裝備後更新裝備欄位上的裝備ICON圖
    {
        ClearArmICON();

        for (int ArmNum = 0; ArmNum < CharaterArmCount; ArmNum++)
        {
            PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, CharaterArm[ArmNum]);
            PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
            Debug.Log("目前處理的裝備編號:" + CharaterArm[ArmNum]);
            Debug.Log("是否有裝備上:" + CharaterArmStatic.ArmEquip);
            switch (CharaterArmStatic.ArmEquip)
            {
                case true:
                    {
                        switch (ArmStatic.ArmType)
                        {
                            case 0:
                                {
                                    switch (CharaterArmStatic.ArmMain)
                                    {
                                        case 0:
                                            {
                                                MainWeapon.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                                MainWeaponCharaterArmId.text = CharaterArm[ArmNum].ToString();
                                                break;
                                            }
                                        case 1:
                                            {
                                                SecondWeapon.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                                SecondWeaponCharaterArmId.text = CharaterArm[ArmNum].ToString();
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    Head.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                    HeadCharaterArmId.text = CharaterArm[ArmNum].ToString();
                                    break;
                                }
                            case 2:
                                {
                                    Body.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                    BodyCharaterArmId.text = CharaterArm[ArmNum].ToString();
                                    break;
                                }
                            case 3:
                                {
                                    switch (CharaterArmStatic.ArmMain)
                                    {
                                        case 0:
                                            {
                                                MainRing.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                                MainRingCharaterArmId.text = CharaterArm[ArmNum].ToString();
                                                break;
                                            }
                                        case 1:
                                            {
                                                SecondRing.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                                SecondRingCharaterArmId.text = CharaterArm[ArmNum].ToString();
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 4:
                                {
                                    Necklace.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                    NecklaceCharaterArmId.text = CharaterArm[ArmNum].ToString();
                                    break;
                                }
                            case 5:
                                {
                                    Hand.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                    HandCharaterArmId.text = CharaterArm[ArmNum].ToString();
                                    break;
                                }
                            case 6:
                                {
                                    Belt.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                    BeltCharaterArmId.text = CharaterArm[ArmNum].ToString();
                                    break;
                                }
                            case 7:
                                {
                                    Foot.sprite = SpriteArmIcon.GetSprite(ArmStatic.ArmIconName);
                                    FootCharaterArmId.text = CharaterArm[ArmNum].ToString();
                                    break;
                                }
                        }
                        break;
                    }
                case false:
                    {
                        /*switch (ArmStatic.ArmType)   找不到原因的錯誤寫法，但原本的問題已解決
                        {
                            case 0:
                                {
                                    switch (CharaterArmStatic.ArmMain)
                                    {
                                        case 0:
                                            {
                                                MainWeapon.sprite = SpriteArmIcon.GetSprite("Unequip");
                                                break;
                                            }
                                        case 1:
                                            {
                                                SecondWeapon.sprite = SpriteArmIcon.GetSprite("Unequip");
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    Head.sprite = SpriteArmIcon.GetSprite("Arm_1");
                                    break;
                                }
                            case 2:
                                {
                                    Body.sprite = SpriteArmIcon.GetSprite("Unequip");
                                    break;
                                }
                            case 3:
                                {
                                    switch (CharaterArmStatic.ArmMain)
                                    {
                                        case 0:
                                            {
                                                MainRing.sprite = SpriteArmIcon.GetSprite("Unequip");
                                                break;
                                            }
                                        case 1:
                                            {
                                                SecondRing.sprite = SpriteArmIcon.GetSprite("Unequip");
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 4:
                                {
                                    Necklace.sprite = SpriteArmIcon.GetSprite("Unequip");
                                    break;
                                }
                            case 5:
                                {
                                    Hand.sprite = SpriteArmIcon.GetSprite("Unequip");
                                    break;
                                }
                            case 6:
                                {
                                    Belt.sprite = SpriteArmIcon.GetSprite("Unequip");
                                    break;
                                }
                            case 7:
                                {
                                    Foot.sprite = SpriteArmIcon.GetSprite("Unequip");
                                    break;
                                }
                        }*/
                        break;
                    }
            }       
        }
    }

    public void UnEquipArmList()                                                    //卸下裝備後在刷新裝備列表之前把原本的舊物件刪除
	{
        for (int num = 0; num < CharaterArmListObj.transform.childCount; num++)
		{
            GameObject ChildObject = CharaterArmListObj.transform.GetChild(num).gameObject;
            Destroy(ChildObject);
        }
    }

    public void ClearArmICON()                                                      //把裝備欄位上的裝備編號跟ICON清空
    {
        MainWeapon.sprite = SpriteArmIcon.GetSprite("Unequip");
        MainWeaponCharaterArmId.text = "101";

        SecondWeapon.sprite = SpriteArmIcon.GetSprite("Unequip");
        SecondWeaponCharaterArmId.text = "101";

        Head.sprite = SpriteArmIcon.GetSprite("Unequip");
        HeadCharaterArmId.text = "101";

        Body.sprite = SpriteArmIcon.GetSprite("Unequip");
        BodyCharaterArmId.text = "101";

        MainRing.sprite = SpriteArmIcon.GetSprite("Unequip");
        MainRingCharaterArmId.text = "101";

        SecondRing.sprite = SpriteArmIcon.GetSprite("Unequip");
        SecondRingCharaterArmId.text = "101";

        Necklace.sprite = SpriteArmIcon.GetSprite("Unequip");
        NecklaceCharaterArmId.text = "101";

        Hand.sprite = SpriteArmIcon.GetSprite("Unequip");
        HandCharaterArmId.text = "101";

        Belt.sprite = SpriteArmIcon.GetSprite("Unequip");
        BeltCharaterArmId.text = "101";

        Foot.sprite = SpriteArmIcon.GetSprite("Unequip");
        FootCharaterArmId.text = "101";
    }

    public void FlashCharaterInfo()                                                 //更新角色狀態
	{
        switch(CharaterPropertyStatic.CharaterHpNow != 0)
		{
            case true:
				{
                    InvokeRepeating("CharaterRecoverInfo", 1, 0.1f);
                    break;
				}
            case false:
				{
                    break;
				}
		}
	}

    public void CharaterRecoverInfo()
	{
        switch (CharaterPropertyStatic.CharaterMagicShield != 0)
        {
            case true:
                {
                    PublicFunctionClone.ChangeSpriteSize(Load_Sprite_MagicShield, CharaterPropertyStatic.CharaterMagicShieldNow, CharaterPropertyStatic.CharaterMagicShieldNow, CharaterPropertyStatic.CharaterMagicShield, 0);
                    Load_MagicShield.text = CharaterPropertyStatic.CharaterMagicShieldNow + "/" + CharaterPropertyStatic.CharaterMagicShield;
                    break;
                }
            case false:
                {
                    break;
                }
        }
        PublicFunctionClone.ChangeSpriteSize(Load_Sprite_Hp, CharaterPropertyStatic.CharaterHpNow, CharaterPropertyStatic.CharaterHpNow, CharaterPropertyStatic.CharaterHp, 0);
        PublicFunctionClone.ChangeSpriteSize(Load_Sprite_Mp, CharaterPropertyStatic.CharaterMpNow, CharaterPropertyStatic.CharaterMpNow, CharaterPropertyStatic.CharaterMp, 0);
        Load_Hp.text = CharaterPropertyStatic.CharaterHpNow + "/" + CharaterPropertyStatic.CharaterHp;
        Load_Mp.text = CharaterPropertyStatic.CharaterMpNow + "/" + CharaterPropertyStatic.CharaterMp;
    }
}
