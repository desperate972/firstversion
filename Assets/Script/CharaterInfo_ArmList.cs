using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using System;
using System.IO;

public class CharaterInfo_ArmList : MonoBehaviour
{
    public int ArmNum;

    public GameObject EquipArm;
    public GameObject UnEquipArm;
    public PublicFunction PublicFunctionClone;
    public CharaterInfo CharaterInfoClone;
    public GameObject EmptyGameObject;

    public GameObject Btn_UnEquip;
    public GameObject Btn_Second;
    public GameObject Btn_UnEquipAlone;

    public SpriteAtlas CharaterArmIcon;

    public Text MainSecondSwitch;

    private int EquipNum;
    private int ArmType;
    private GameObject Equip_ArmId_AlwaysFalse;
    private Text Equip_ArmId_AlwaysFalseClone;
    private GameObject ArmId_AlwaysFalse;
    private Text ArmId_AlwaysFalseClone;

    private GameObject ArmNameObj;
    private GameObject ArmRequsetLevelObj;
    private GameObject ArmRequestPowerObj;
    private GameObject ArmBasicObj_0;
    private GameObject ArmBasicObj_1;
    private GameObject ArmBasicObj_2;
    private GameObject ArmExtraObj_0;
    private GameObject ArmExtraObj_1;
    private GameObject ArmExtraObj_2;
    private GameObject ArmExtraObj_3;
    private GameObject ArmExtraObj_4;
    private GameObject ArmExtraObj_5;
    private GameObject ArmExtraObj_None;
    private GameObject ArmIconObj;

    private Text ArmName;
    private Text ArmRequsetLevel;
    private Text ArmRequestPower;
    private Text ArmBasic_0;
    private Text ArmBasic_1;
    private Text ArmBasic_2;
    private Text ArmExtra_0;
    private Text ArmExtra_1;
    private Text ArmExtra_2;
    private Text ArmExtra_3;
    private Text ArmExtra_4;
    private Text ArmExtra_5;
    private Text ArmExtra_None;
    private Image ArmIcon;

    private GameObject EquipArmNameObj;
    private GameObject EquipArmRequsetLevelObj;
    private GameObject EquipArmRequestPowerObj;
    private GameObject EquipArmBasicObj_0;
    private GameObject EquipArmBasicObj_1;
    private GameObject EquipArmBasicObj_2;
    private GameObject EquipArmExtraObj_0;
    private GameObject EquipArmExtraObj_1;
    private GameObject EquipArmExtraObj_2;
    private GameObject EquipArmExtraObj_3;
    private GameObject EquipArmExtraObj_4;
    private GameObject EquipArmExtraObj_5;
    private GameObject EquipArmExtraObj_None;
    private GameObject EquipArmIconObj;

    private Text EquipArmName;
    private Text EquipArmRequsetLevel;
    private Text EquipArmRequestPower;
    private Text EquipArmBasic_0;
    private Text EquipArmBasic_1;
    private Text EquipArmBasic_2;
    private Text EquipArmExtra_0;
    private Text EquipArmExtra_1;
    private Text EquipArmExtra_2;
    private Text EquipArmExtra_3;
    private Text EquipArmExtra_4;
    private Text EquipArmExtra_5;
    private Text EquipArmExtra_None;
    private Image EquipArmIcon;

    private string EmptyArmExtra;
    private string ArmExtraPower_0;
    private string ArmExtraPower_1;
    private string ArmExtraPower_2;
    private string ArmExtraPower_3;
    private string ArmExtraPower_4;
    private string ArmExtraPower_5;

    private static int[] CharaterArm;
    private static int CharaterArmCount;
    private bool weaponsecond = false;
    private bool ringsecond = false;

    private GameObject CharaterArmClone;
    private GameObject CharaterArmListObj;

    private GameObject Load_NotEquipObj;
    private GameObject Load_NotEquipIconObj;
    private GameObject Load_NotEquipEquipObj;

    private Image Load_NotEquipIcon;

    private GameObject Load_EquipObj;
    private GameObject Load_EquipIconObj;
    private GameObject Load_EquipEquipObj;

    private Image Load_EquipIcon;

    private GameObject ArmNumClone;
    private Text ArmNumCloneText;

    private int JudgeEquipArmIdOrNot;

    private int ArmHereCount;
    private int ArmHereArrayCount;
    private int[] ArmHereArray;

    private void Awake()
    {
        ArmNameObj = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Arm/Sprite_ArmName/Load_ArmName");
        ArmName = ArmNameObj.GetComponent<Text>();
        ArmRequsetLevelObj = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Arm/Sprite_ArmName/Load_ArmRequest");
        ArmRequsetLevel = ArmRequsetLevelObj.GetComponent<Text>();
        ArmRequestPowerObj = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Arm/Scroll_Property/Mask/Grid_ArmProperty/Load_ArmCharaterRequest");
        ArmRequestPower = ArmRequestPowerObj.GetComponent<Text>();
        ArmBasicObj_0 = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Arm/Scroll_Property/Mask/Grid_ArmProperty/Load_ArmBasic_0");
        ArmBasic_0 = ArmBasicObj_0.GetComponent<Text>();
        ArmBasicObj_1 = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Arm/Scroll_Property/Mask/Grid_ArmProperty/Load_ArmBasic_1");
        ArmBasic_1 = ArmBasicObj_1.GetComponent<Text>();
        ArmBasicObj_2 = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Arm/Scroll_Property/Mask/Grid_ArmProperty/Load_ArmBasic_2");
        ArmBasic_2 = ArmBasicObj_2.GetComponent<Text>();
        ArmExtraObj_0 = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Arm/Scroll_Property/Mask/Grid_ArmProperty/Load_ArmExtra_0");
        ArmExtra_0 = ArmExtraObj_0.GetComponent<Text>();
        ArmExtraObj_1 = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Arm/Scroll_Property/Mask/Grid_ArmProperty/Load_ArmExtra_1");
        ArmExtra_1 = ArmExtraObj_1.GetComponent<Text>();
        ArmExtraObj_2 = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Arm/Scroll_Property/Mask/Grid_ArmProperty/Load_ArmExtra_2");
        ArmExtra_2 = ArmExtraObj_2.GetComponent<Text>();
        ArmExtraObj_3 = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Arm/Scroll_Property/Mask/Grid_ArmProperty/Load_ArmExtra_3");
        ArmExtra_3 = ArmExtraObj_3.GetComponent<Text>();
        ArmExtraObj_4 = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Arm/Scroll_Property/Mask/Grid_ArmProperty/Load_ArmExtra_4");
        ArmExtra_4 = ArmExtraObj_4.GetComponent<Text>();
        ArmExtraObj_5 = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Arm/Scroll_Property/Mask/Grid_ArmProperty/Load_ArmExtra_5");
        ArmExtra_5 = ArmExtraObj_5.GetComponent<Text>();
        ArmExtraObj_None = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Arm/Scroll_Property/Mask/Grid_ArmProperty/Load_ArmExtra_None");
        ArmExtra_None = ArmExtraObj_None.GetComponent<Text>();
        ArmIconObj = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Arm/Sprite_ArmIcon/Load_ArmIcon");
        ArmIcon = ArmIconObj.GetComponent<Image>();

        EquipArmNameObj = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Equip/Sprite_ArmName/Load_ArmName");
        EquipArmName = EquipArmNameObj.GetComponent<Text>();
        EquipArmRequsetLevelObj = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Equip/Sprite_ArmName/Load_ArmRequest");
        EquipArmRequsetLevel = EquipArmRequsetLevelObj.GetComponent<Text>();
        EquipArmRequestPowerObj = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Equip/Scroll_Property/Mask/Grid_ArmProperty/Load_ArmCharaterRequest");
        EquipArmRequestPower = EquipArmRequestPowerObj.GetComponent<Text>();
        EquipArmBasicObj_0 = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Equip/Scroll_Property/Mask/Grid_ArmProperty/Load_ArmBasic_0");
        EquipArmBasic_0 = EquipArmBasicObj_0.GetComponent<Text>();
        EquipArmBasicObj_1 = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Equip/Scroll_Property/Mask/Grid_ArmProperty/Load_ArmBasic_1");
        EquipArmBasic_1 = EquipArmBasicObj_1.GetComponent<Text>();
        EquipArmBasicObj_2 = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Equip/Scroll_Property/Mask/Grid_ArmProperty/Load_ArmBasic_2");
        EquipArmBasic_2 = EquipArmBasicObj_2.GetComponent<Text>();
        EquipArmExtraObj_0 = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Equip/Scroll_Property/Mask/Grid_ArmProperty/Load_ArmExtra_0");
        EquipArmExtra_0 = EquipArmExtraObj_0.GetComponent<Text>();
        EquipArmExtraObj_1 = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Equip/Scroll_Property/Mask/Grid_ArmProperty/Load_ArmExtra_1");
        EquipArmExtra_1 = EquipArmExtraObj_1.GetComponent<Text>();
        EquipArmExtraObj_2 = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Equip/Scroll_Property/Mask/Grid_ArmProperty/Load_ArmExtra_2");
        EquipArmExtra_2 = EquipArmExtraObj_2.GetComponent<Text>();
        EquipArmExtraObj_3 = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Equip/Scroll_Property/Mask/Grid_ArmProperty/Load_ArmExtra_3");
        EquipArmExtra_3 = EquipArmExtraObj_3.GetComponent<Text>();
        EquipArmExtraObj_4 = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Equip/Scroll_Property/Mask/Grid_ArmProperty/Load_ArmExtra_4");
        EquipArmExtra_4 = EquipArmExtraObj_4.GetComponent<Text>();
        EquipArmExtraObj_5 = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Equip/Scroll_Property/Mask/Grid_ArmProperty/Load_ArmExtra_5");
        EquipArmExtra_5 = EquipArmExtraObj_5.GetComponent<Text>();
        EquipArmExtraObj_None = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Equip/Scroll_Property/Mask/Grid_ArmProperty/Load_ArmExtra_None");
        EquipArmExtra_None = EquipArmExtraObj_None.GetComponent<Text>();
        EquipArmIconObj = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Equip/Sprite_ArmIcon/Load_ArmIcon");
        EquipArmIcon = EquipArmIconObj.GetComponent<Image>();

        Equip_ArmId_AlwaysFalse = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Equip/Load_ArmType_AlwaysFalse");
        Equip_ArmId_AlwaysFalseClone = Equip_ArmId_AlwaysFalse.GetComponent<Text>();

        ArmId_AlwaysFalse = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Function_ShowArm/Load_Frame_Arm/Load_ArmId_AlwaysFalse");
        ArmId_AlwaysFalseClone = ArmId_AlwaysFalse.GetComponent<Text>();

        EmptyArmExtra = "";

        ArmNumClone = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Load_ArmNum");
        CharaterArmClone = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Load_Arm");
        CharaterArmListObj = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList");
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClickArmIcon()                                                      //點擊裝備列表上的裝備ICON圖來顯示該裝備內容
    {
        CheckCharaterArmList();
        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, ArmNum);
        PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
        Debug.Log("裝備對應編號:" + CharaterArmStatic.ArmBasicId);
        Debug.Log("裝備數字:" + ArmNum);
        ArmType = ArmStatic.ArmType;

        Debug.Log("裝備類型:" + ArmType);
        //JudgeEquipArmId();
        //JudgeArmNumType();
        JudgeArmTypeEquipNot(ArmNum);
        InputEquipArm(JudgeEquipArmIdOrNot);
        SecondArmChange();
        InputArm(ArmNum);
    }

    public void JudgeArmBasic()                                                     //判斷防具裝備有哪些能力
    {
        if (ArmStatic.ArmArmor != 0 && ArmStatic.ArmMagicShield != 0 && ArmStatic.ArmDodge != 0)
        {
            ArmBasicObj_0.SetActive(true);
            ArmBasicObj_1.SetActive(true);
            ArmBasicObj_2.SetActive(false);
            ArmBasic_0.text = "護甲:" + ArmStatic.ArmArmor;
            ArmBasic_1.text = "魔法護盾:" + ArmStatic.ArmMagicShield;
            ArmBasic_2.text = "閃避值:" + ArmStatic.ArmDodge;
        }
        if (ArmStatic.ArmArmor == 0 && ArmStatic.ArmMagicShield != 0 && ArmStatic.ArmDodge != 0)
        {
            ArmBasicObj_0.SetActive(true);
            ArmBasicObj_1.SetActive(true);
            ArmBasicObj_2.SetActive(false);
            ArmBasic_0.text = "魔法護盾:" + ArmStatic.ArmMagicShield;
            ArmBasic_1.text = "閃避值:" + ArmStatic.ArmDodge;
        }
        if (ArmStatic.ArmMagicShield == 0 && ArmStatic.ArmArmor != 0 && ArmStatic.ArmDodge != 0)
        {
            ArmBasicObj_0.SetActive(true);
            ArmBasicObj_1.SetActive(true);
            ArmBasicObj_2.SetActive(false);
            ArmBasic_0.text = "護甲:" + ArmStatic.ArmArmor;
            ArmBasic_1.text = "閃避值:" + ArmStatic.ArmDodge;
        }
        if (ArmStatic.ArmDodge == 0 && ArmStatic.ArmArmor != 0 && ArmStatic.ArmMagicShield != 0)
        {
            ArmBasicObj_0.SetActive(true);
            ArmBasicObj_1.SetActive(true);
            ArmBasicObj_2.SetActive(false);
            ArmBasic_0.text = "護甲:" + ArmStatic.ArmArmor;
            ArmBasic_1.text = "魔法護盾:" + ArmStatic.ArmMagicShield;
        }
        if (ArmStatic.ArmArmor == 0 && ArmStatic.ArmMagicShield == 0 && ArmStatic.ArmDodge != 0)
        {
            ArmBasicObj_0.SetActive(true);
            ArmBasicObj_1.SetActive(false);
            ArmBasicObj_2.SetActive(false);
            ArmBasic_0.text = "閃避值:" + ArmStatic.ArmDodge;
        }
        if (ArmStatic.ArmArmor == 0 && ArmStatic.ArmDodge == 0 && ArmStatic.ArmMagicShield != 0)
        {
            ArmBasicObj_0.SetActive(true);
            ArmBasicObj_1.SetActive(false);
            ArmBasicObj_2.SetActive(false);
            ArmBasic_0.text = "魔法護盾:" + ArmStatic.ArmMagicShield;
        }
        if (ArmStatic.ArmMagicShield == 0 && ArmStatic.ArmDodge == 0 && ArmStatic.ArmArmor != 0)
        {
            ArmBasicObj_0.SetActive(true);
            ArmBasicObj_1.SetActive(false);
            ArmBasicObj_2.SetActive(false);
            ArmBasic_0.text = "護甲:" + ArmStatic.ArmArmor;
        }
        if (ArmStatic.ArmMagicShield == 0 && ArmStatic.ArmDodge == 0 && ArmStatic.ArmArmor == 0)
        {
            ArmBasicObj_0.SetActive(true);
            ArmBasicObj_1.SetActive(false);
            ArmBasicObj_2.SetActive(false);
            ArmBasic_0.text = "無";
        }
    }

    public void JudgeEquipArmId()                                                   //判斷當前點選的裝備，裝備ID是為何?
    {
        switch (CharaterArmStatic.id)
        {
            case 0:
                {
                    EquipNum = 0;
                    break;
                }
            case 1:
                {
                    EquipNum = 1;
                    break;
                }
            case 2:
                {
                    EquipNum = 2;
                    break;
                }
            case 3:
                {
                    EquipNum = 3;
                    break;
                }
            case 4:
                {
                    EquipNum = 4;
                    break;
                }
            case 5:
                {
                    EquipNum = 5;
                    break;
                }
            case 6:
                {
                    EquipNum = 6;
                    break;
                }
            case 7:
                {
                    EquipNum = 7;
                    break;
                }
            case 8:
                {
                    EquipNum = 8;
                    break;
                }
            case 9:
                {
                    EquipNum = 9;
                    break;
                }
            default:
                {
                    EquipNum = 101;
                    break;
                }
        }
    }

    public void JudgeArmNumType()                                                   //判斷裝備欄位上是否已經有裝備上相同類型的裝備
    {
        int[] Equiparray = new int[10];
        int EquioNum = 0;
        int[] EquipTypearray = new int[10];

        for (int Num = 0; Num < CharaterArmCount; Num++)
        {
            Debug.Log("有被裝備上的裝備數量:" + EquioNum);
            PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, CharaterArm[Num]);
            PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
            switch (CharaterArmStatic.ArmEquip)
			{
                case true:
					{
                        Equiparray[EquioNum] = CharaterArm[Num];
                        EquipTypearray[EquioNum] = ArmStatic.ArmType;
                        Debug.Log("已裝備的裝備編號，第" + EquioNum + "個裝備編號:" + Equiparray[EquioNum]);
                        Debug.Log("已裝備的裝備類型，第" + EquioNum + "個裝備類型:" + EquipTypearray[EquioNum]);
                        EquioNum++;                 
                        break;
					}
                case false:
					{
                        break;
					}
			}
        }

        Equiparray = new int[EquioNum];
        EquipTypearray = new int[EquioNum];
        for (int Num = 0; Num < EquioNum; Num++)
        {
            Debug.Log("整理之後的-有被裝備上的裝備數量:" + EquioNum);
            PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, CharaterArm[Num]);
            PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
            switch (CharaterArmStatic.ArmEquip)
            {
                case true:
                    {
                        Equiparray[Num] = CharaterArm[Num];
                        EquipTypearray[Num] = ArmStatic.ArmType;
                        Debug.Log("整理之後的-已裝備的裝備編號，第" + Num + "個裝備編號:" + Equiparray[Num]);
                        Debug.Log("整理之後的-已裝備的裝備類型，第" + Num + "個裝備類型:" + EquipTypearray[Num]);
                        break;
                    }
                case false:
                    {
                        break;
                    }
            }
        }

        //-----判斷是否有副手欄位有裝上裝備
        /*for(int Num = 0; Num < EquioNum; Num++)
		{
            switch(EquipTypearray[Num])
			{
                case 0:
					{
                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, Equiparray[Num]);
                        switch(CharaterArmStatic.ArmMain == 1)
						{
                            case true:
								{
                                    weaponsecond = true;               //這是判斷已裝備的武器類型裡是有副手武器，但不代表是這個ID就是副手武器的編號
                                    MainSecondSwitch.text = "主手";
                                    break;
								}
                            case false:
								{
                                    MainSecondSwitch.text = "副手";
                                    break;
								}
						}
                        break;
					}
                case 3:
					{
                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, Equiparray[Num]);
                        switch(CharaterArmStatic.ArmMain == 1)
						{
                            case true:
								{
                                    ringsecond = true;
                                    MainSecondSwitch.text = "主手";
                                    break;
								}
                            case false:
								{
                                    MainSecondSwitch.text = "副手";
                                    break;
								}
						}
                        break;
					}
			}
		}*/
        //-----

        int reallyarmid = 101;
        for(int Num = 0; Num < EquioNum; Num++)
		{
            switch(Equiparray[Num] == ArmNum)
			{
                case true:
					{
                        reallyarmid = ArmNum;
                        break;
					}
                case false:
					{
                        break;
					}
			}
		}

        switch (reallyarmid == ArmNum)     //判斷該裝備有可能是已經裝備上的裝備
        {
            case true:
                {
                    Debug.Log("True-目前排序到的的裝備編號為" + reallyarmid);
                    Debug.Log("目前點擊的裝備編號為" + ArmNum);
                    EquipNum = ArmNum;
                    EquipArm.SetActive(true);
                    UnEquipArm.SetActive(false);
                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, reallyarmid);
                    PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                    switch (ArmStatic.ArmType)    //判斷該裝備是不是有副手的裝備
                    {
                        /*case 0:
                            {
                                switch (weaponsecond)
                                {
                                    case true:
                                        {
                                            EquipArm.SetActive(true);
                                            UnEquipArm.SetActive(false);
                                            Btn_UnEquip.SetActive(true);
                                            Btn_Second.SetActive(true);
                                            Btn_UnEquipAlone.SetActive(false);
                                            break;
                                        }
                                    case false:
                                        {
                                            EquipArm.SetActive(true);
                                            UnEquipArm.SetActive(false);
                                            Btn_UnEquip.SetActive(false);
                                            Btn_Second.SetActive(false);
                                            Btn_UnEquipAlone.SetActive(true);
                                            break;
                                        }
                                }
                                break;
                            }
                        case 3:
                            {
                                switch (ringsecond)
                                {
                                    case true:
                                        {
                                            EquipArm.SetActive(true);
                                            UnEquipArm.SetActive(false);
                                            Btn_UnEquip.SetActive(true);
                                            Btn_Second.SetActive(true);
                                            Btn_UnEquipAlone.SetActive(false);
                                            break;
                                        }
                                    case false:
                                        {
                                            EquipArm.SetActive(true);
                                            UnEquipArm.SetActive(false);
                                            Btn_UnEquip.SetActive(false);
                                            Btn_Second.SetActive(false);
                                            Btn_UnEquipAlone.SetActive(true);
                                            break;
                                        }
                                }
                                break;
                            }*/
                        default:
                            {
                                EquipArm.SetActive(true);
                                UnEquipArm.SetActive(false);
                                Btn_UnEquip.SetActive(false);
                                Btn_Second.SetActive(false);
                                Btn_UnEquipAlone.SetActive(true);
                                break;
                            }
                    }
                    break;
                }
            case false:
                {
                    Debug.Log("False-目前排序到的的裝備編號為" + reallyarmid);
                    Debug.Log("目前點擊的裝備編號為" + ArmNum);
                    EquipArm.SetActive(false);
                    UnEquipArm.SetActive(true);
                    break;
                }
        }

        //-----因為這邊會把所有已裝備上的裝備編號都讀過一遍，導致後面的編號取代掉前面的編號，就會造成實際上顯示的物件不是點擊的裝備編號
        /*for (int Num = 0; Num < EquioNum; Num++)
		{
            switch(Equiparray[Num] == ArmNum)     //判斷該裝備有可能是已經裝備上的裝備
			{
                case true:
					{
                        Debug.Log("True-目前排序到的的裝備編號為" + Equiparray[Num]);
                        Debug.Log("目前點擊的裝備編號為" + ArmNum);
                        EquipNum = ArmNum;
                        EquipArm.SetActive(true);
                        UnEquipArm.SetActive(false);
                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, Equiparray[Num]);
                        PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                        switch(ArmStatic.ArmType)    //判斷該裝備是不是有副手的裝備
						{
                            case 0:
								{
                                    switch(weaponsecond)
									{
                                        case true:
											{
                                                EquipArm.SetActive(true);
                                                UnEquipArm.SetActive(false);
                                                Btn_UnEquip.SetActive(true);
                                                Btn_Second.SetActive(true);
                                                Btn_UnEquipAlone.SetActive(false);
                                                break;
											}
                                        case false:
											{
                                                EquipArm.SetActive(true);
                                                UnEquipArm.SetActive(false);
                                                Btn_UnEquip.SetActive(false);
                                                Btn_Second.SetActive(false);
                                                Btn_UnEquipAlone.SetActive(true);
                                                break;
											}
									}
                                    break;
								}
                            case 3:
								{
                                    switch (ringsecond)
                                    {
                                        case true:
                                            {
                                                EquipArm.SetActive(true);
                                                UnEquipArm.SetActive(false);
                                                Btn_UnEquip.SetActive(true);
                                                Btn_Second.SetActive(true);
                                                Btn_UnEquipAlone.SetActive(false);
                                                break;
                                            }
                                        case false:
                                            {
                                                EquipArm.SetActive(true);
                                                UnEquipArm.SetActive(false);
                                                Btn_UnEquip.SetActive(false);
                                                Btn_Second.SetActive(false);
                                                Btn_UnEquipAlone.SetActive(true);
                                                break;
                                            }
                                    }
                                    break;
								}
                            default:
								{
                                    EquipArm.SetActive(true);
                                    UnEquipArm.SetActive(false);
                                    Btn_UnEquip.SetActive(false);
                                    Btn_Second.SetActive(false);
                                    Btn_UnEquipAlone.SetActive(true);
                                    break;
								}
						}
                        break;
					}
                case false:
					{
                        Debug.Log("False-目前排序到的的裝備編號為" + Equiparray[Num]);
                        Debug.Log("目前點擊的裝備編號為" + ArmNum);
                        EquipArm.SetActive(false);
                        UnEquipArm.SetActive(true);
                        break;
					}
			}
		}*/
        //-----

        //-----以下本來是用來判斷被點擊裝備ICON的該裝備是否為裝備欄位上的裝備，如果是那該裝備是不是有副手裝備欄位?又如果是那該裝備的副手欄位是否有裝備上裝備?
        //但為了改變作法而不用以下作法
        /*if (EquipNum == ArmNum)
        {
            EquipArm.SetActive(true);
            UnEquipArm.SetActive(false);
            if(EquipNum == 0)
            {
                bool SecondEquip;
                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 1);
                SecondEquip = CharaterArmStatic.ArmEquip;
                if (SecondEquip == false)
                {
                    Btn_UnEquip.SetActive(false);
                    Btn_Second.SetActive(false);
                    Btn_UnEquipAlone.SetActive(true);
                }
                if (SecondEquip == true)
                {
                    Btn_UnEquip.SetActive(true);
                    Btn_Second.SetActive(true);
                    Btn_UnEquipAlone.SetActive(false);
                }
            }
            if (EquipNum == 1)
            {
                bool MainEquip;
                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 0);
                MainEquip = CharaterArmStatic.ArmEquip;
                if (MainEquip == false)
                {
                    Btn_UnEquip.SetActive(false);
                    Btn_Second.SetActive(false);
                    Btn_UnEquipAlone.SetActive(true);
                }
                if (MainEquip == true)
                {
                    Btn_UnEquip.SetActive(true);
                    Btn_Second.SetActive(true);
                    Btn_UnEquipAlone.SetActive(false);
                }
            }
            if (EquipNum == 4)
            {
                bool SecondEquip;
                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 5);
                SecondEquip = CharaterArmStatic.ArmEquip;
                if (SecondEquip == false)
                {
                    Btn_UnEquip.SetActive(false);
                    Btn_Second.SetActive(false);
                    Btn_UnEquipAlone.SetActive(true);
                }
                if (SecondEquip == true)
                {
                    Btn_UnEquip.SetActive(true);
                    Btn_Second.SetActive(true);
                    Btn_UnEquipAlone.SetActive(false);
                }
            }
            if (EquipNum == 5)
            {
                bool MainEquip;
                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 4);
                MainEquip = CharaterArmStatic.ArmEquip;
                if (MainEquip == false)
                {
                    Btn_UnEquip.SetActive(false);
                    Btn_Second.SetActive(false);
                    Btn_UnEquipAlone.SetActive(true);
                }
                if (MainEquip == true)
                {
                    Btn_UnEquip.SetActive(true);
                    Btn_Second.SetActive(true);
                    Btn_UnEquipAlone.SetActive(false);
                }
            }
            if(EquipNum != 0 && EquipNum != 1 && EquipNum != 4 && EquipNum != 5)
            {
                Btn_UnEquip.SetActive(false);
                Btn_Second.SetActive(false);
                Btn_UnEquipAlone.SetActive(true);
            }
        }
        if (EquipNum != ArmNum)
        {
            EquipArm.SetActive(false);
            UnEquipArm.SetActive(true);
        }*/
        //-----
    }

    public void InputEquipArm(int EquipId)                                          //顯示裝備欄上裝備資訊
    {
        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipId);
        PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
        EquipArmName.text = ArmStatic.ArmName;
        EquipArmRequsetLevel.text = "等級需求:" + ArmStatic.ArmLv;
        EquipArmRequestPower.text = "能力需求:" + "\n" + "力量:" + ArmStatic.ArmRequest_Strength + "智慧:" + ArmStatic.ArmRequest_Intelligence + "敏捷:" + ArmStatic.ArmRequest_Dexterity;
        Equip_ArmId_AlwaysFalseClone.text = EquipId.ToString();
        switch (ArmStatic.ArmType)
        {
            case 0:
                {
                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipId);
                    PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                    EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    switch (ArmStatic.WeaponSpeed != 0)
					{
                        case true:
							{
                                EquipArmBasicObj_0.SetActive(true);
                                EquipArmBasicObj_1.SetActive(true);
                                EquipArmBasicObj_2.SetActive(false);
                                EquipArmBasic_0.text = "攻擊速度:" + ArmStatic.WeaponSpeed;
                                EquipArmBasic_1.text = "物理攻擊:" + ArmStatic.WeaponDamageMin + "~" + ArmStatic.WeaponDamageMax;
                                break;
							}
                        case false:
							{
                                Debug.Log("該裝備是武器類型，但攻擊速度為0，是資料填錯造成的錯誤!");
                                break;
							}
					}                 
                    switch(ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                EquipArmExtraObj_0.SetActive(false);
                                EquipArmExtraObj_1.SetActive(false);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(true);
                                PowerId();
                                EquipArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(true);
                                EquipArmExtraObj_5.SetActive(true);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                EquipArmExtra_4.text = ArmExtraPower_4;
                                EquipArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
            case 1:
                {
                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipId);
                    PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                    EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeEquipArmBasic();
                    switch(ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                EquipArmExtraObj_0.SetActive(false);
                                EquipArmExtraObj_1.SetActive(false);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(true);
                                PowerId();
                                EquipArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(true);
                                EquipArmExtraObj_5.SetActive(true);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                EquipArmExtra_4.text = ArmExtraPower_4;
                                EquipArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
            case 2:
                {
                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipId);
                    PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                    EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeEquipArmBasic();
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                EquipArmExtraObj_0.SetActive(false);
                                EquipArmExtraObj_1.SetActive(false);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(true);
                                PowerId();
                                EquipArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(true);
                                EquipArmExtraObj_5.SetActive(true);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                EquipArmExtra_4.text = ArmExtraPower_4;
                                EquipArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
            case 3:
                {
                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipId);
                    PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                    EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeEquipArmBasic();
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                EquipArmExtraObj_0.SetActive(false);
                                EquipArmExtraObj_1.SetActive(false);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(true);
                                PowerId();
                                EquipArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(true);
                                EquipArmExtraObj_5.SetActive(true);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                EquipArmExtra_4.text = ArmExtraPower_4;
                                EquipArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
            case 4:
                {
                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipId);
                    PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                    EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeEquipArmBasic();
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                EquipArmExtraObj_0.SetActive(false);
                                EquipArmExtraObj_1.SetActive(false);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(true);
                                PowerId();
                                EquipArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(true);
                                EquipArmExtraObj_5.SetActive(true);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                EquipArmExtra_4.text = ArmExtraPower_4;
                                EquipArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
            case 5:
                {
                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipId);
                    PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                    EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeEquipArmBasic();
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                EquipArmExtraObj_0.SetActive(false);
                                EquipArmExtraObj_1.SetActive(false);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(true);
                                PowerId();
                                EquipArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(true);
                                EquipArmExtraObj_5.SetActive(true);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                EquipArmExtra_4.text = ArmExtraPower_4;
                                EquipArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
            case 6:
                {
                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipId);
                    PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                    EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeEquipArmBasic();
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                EquipArmExtraObj_0.SetActive(false);
                                EquipArmExtraObj_1.SetActive(false);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(true);
                                PowerId();
                                EquipArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(true);
                                EquipArmExtraObj_5.SetActive(true);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                EquipArmExtra_4.text = ArmExtraPower_4;
                                EquipArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
            case 7:
                {
                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipId);
                    PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                    EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeEquipArmBasic();
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                EquipArmExtraObj_0.SetActive(false);
                                EquipArmExtraObj_1.SetActive(false);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(true);
                                PowerId();
                                EquipArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(true);
                                EquipArmExtraObj_5.SetActive(true);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                EquipArmExtra_4.text = ArmExtraPower_4;
                                EquipArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
        }
    }

    public void JudgeEquipArmBasic()                                                //顯示已經裝上的裝備基本數值內容
    {
        if (ArmStatic.ArmArmor != 0 && ArmStatic.ArmMagicShield != 0 && ArmStatic.ArmDodge != 0)
        {
            EquipArmBasicObj_0.SetActive(true);
            EquipArmBasicObj_1.SetActive(true);
            EquipArmBasicObj_2.SetActive(true);
            EquipArmBasic_0.text = "護甲:" + ArmStatic.ArmArmor;
            EquipArmBasic_1.text = "魔法護盾:" + ArmStatic.ArmMagicShield;
            EquipArmBasic_2.text = "閃避值:" + ArmStatic.ArmDodge;
        }
        if (ArmStatic.ArmArmor == 0 && ArmStatic.ArmMagicShield != 0 && ArmStatic.ArmDodge != 0)
        {
            EquipArmBasicObj_0.SetActive(true);
            EquipArmBasicObj_1.SetActive(true);
            EquipArmBasicObj_2.SetActive(false);
            EquipArmBasic_0.text = "魔法護盾:" + ArmStatic.ArmMagicShield;
            EquipArmBasic_1.text = "閃避值:" + ArmStatic.ArmDodge;
        }
        if (ArmStatic.ArmMagicShield == 0 && ArmStatic.ArmArmor != 0 && ArmStatic.ArmDodge != 0)
        {
            EquipArmBasicObj_0.SetActive(true);
            EquipArmBasicObj_1.SetActive(true);
            EquipArmBasicObj_2.SetActive(false);
            EquipArmBasic_0.text = "護甲:" + ArmStatic.ArmArmor;
            EquipArmBasic_1.text = "閃避值:" + ArmStatic.ArmDodge;
        }
        if (ArmStatic.ArmDodge == 0 && ArmStatic.ArmArmor != 0 && ArmStatic.ArmMagicShield != 0)
        {
            EquipArmBasicObj_0.SetActive(true);
            EquipArmBasicObj_1.SetActive(true);
            EquipArmBasicObj_2.SetActive(false);
            EquipArmBasic_0.text = "護甲:" + ArmStatic.ArmArmor;
            EquipArmBasic_1.text = "魔法護盾:" + ArmStatic.ArmMagicShield;
        }
        if (ArmStatic.ArmArmor == 0 && ArmStatic.ArmMagicShield == 0 && ArmStatic.ArmDodge != 0)
        {
            EquipArmBasicObj_0.SetActive(true);
            EquipArmBasicObj_1.SetActive(false);
            EquipArmBasicObj_2.SetActive(false);
            EquipArmBasic_0.text = "閃避值:" + ArmStatic.ArmDodge;
        }
        if (ArmStatic.ArmArmor == 0 && ArmStatic.ArmDodge == 0 && ArmStatic.ArmMagicShield != 0)
        {
            EquipArmBasicObj_0.SetActive(true);
            EquipArmBasicObj_1.SetActive(false);
            EquipArmBasicObj_2.SetActive(false);
            EquipArmBasic_0.text = "魔法護盾:" + ArmStatic.ArmMagicShield;
        }
        if (ArmStatic.ArmMagicShield == 0 && ArmStatic.ArmDodge == 0 && ArmStatic.ArmArmor != 0)
        {
            EquipArmBasicObj_0.SetActive(true);
            EquipArmBasicObj_1.SetActive(false);
            EquipArmBasicObj_2.SetActive(false);
            EquipArmBasic_0.text = "護甲:" + ArmStatic.ArmArmor;
        }
        if (ArmStatic.ArmMagicShield == 0 && ArmStatic.ArmDodge == 0 && ArmStatic.ArmArmor == 0)
        {
            EquipArmBasicObj_0.SetActive(true);
            EquipArmBasicObj_1.SetActive(false);
            EquipArmBasicObj_2.SetActive(false);
            EquipArmBasic_0.text = "無";
        }
    }

    public void InputArm(int ArmId)                                                 //顯示裝備列表裡的裝備資訊
    {
        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, ArmId);
        PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
        ArmName.text = ArmStatic.ArmName;
        ArmRequsetLevel.text = "等級需求:" + ArmStatic.ArmLv;
        ArmRequestPower.text = "能力需求:" + "\n" + "力量:" + ArmStatic.ArmRequest_Strength + "智慧:" + ArmStatic.ArmRequest_Intelligence + "敏捷:" + ArmStatic.ArmRequest_Dexterity;
        ArmId_AlwaysFalseClone.text = ArmId.ToString();
        switch (ArmStatic.ArmType)
        {
            case 0:
                {
                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, ArmId);
                    PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                    ArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    switch(ArmStatic.WeaponSpeed != 0)
					{
                        case true:
							{
                                ArmBasicObj_0.SetActive(true);
                                ArmBasicObj_1.SetActive(true);
                                ArmBasicObj_2.SetActive(false);
                                ArmBasic_0.text = "攻擊速度:" + ArmStatic.WeaponSpeed;
                                ArmBasic_1.text = "物理攻擊:" + ArmStatic.WeaponDamageMin + "~" + ArmStatic.WeaponDamageMax;
                                break;
							}
                        case false:
							{
                                Debug.Log("該裝備是武器類型，但攻擊速度為0，是資料填錯造成的錯誤!");
                                break;
							}
					}                  
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                ArmExtraObj_0.SetActive(false);
                                ArmExtraObj_1.SetActive(false);
                                ArmExtraObj_2.SetActive(false);
                                ArmExtraObj_3.SetActive(false);
                                ArmExtraObj_4.SetActive(false);
                                ArmExtraObj_5.SetActive(false);
                                ArmExtraObj_None.SetActive(true);
                                PowerId();
                                ArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                ArmExtraObj_0.SetActive(true);
                                ArmExtraObj_1.SetActive(true);
                                ArmExtraObj_2.SetActive(false);
                                ArmExtraObj_3.SetActive(false);
                                ArmExtraObj_4.SetActive(false);
                                ArmExtraObj_5.SetActive(false);
                                ArmExtraObj_None.SetActive(false);
                                PowerId();
                                ArmExtra_0.text = ArmExtraPower_0;
                                ArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                ArmExtraObj_0.SetActive(true);
                                ArmExtraObj_1.SetActive(true);
                                ArmExtraObj_2.SetActive(true);
                                ArmExtraObj_3.SetActive(true);
                                ArmExtraObj_4.SetActive(false);
                                ArmExtraObj_5.SetActive(false);
                                ArmExtraObj_None.SetActive(false);
                                PowerId();
                                ArmExtra_0.text = ArmExtraPower_0;
                                ArmExtra_1.text = ArmExtraPower_1;
                                ArmExtra_2.text = ArmExtraPower_2;
                                ArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                ArmExtraObj_0.SetActive(true);
                                ArmExtraObj_1.SetActive(true);
                                ArmExtraObj_2.SetActive(true);
                                ArmExtraObj_3.SetActive(true);
                                ArmExtraObj_4.SetActive(true);
                                ArmExtraObj_5.SetActive(true);
                                ArmExtraObj_None.SetActive(false);
                                PowerId();
                                ArmExtra_0.text = ArmExtraPower_0;
                                ArmExtra_1.text = ArmExtraPower_1;
                                ArmExtra_2.text = ArmExtraPower_2;
                                ArmExtra_3.text = ArmExtraPower_3;
                                ArmExtra_4.text = ArmExtraPower_4;
                                ArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
            case 1:
                {
                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, ArmId);
                    PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                    ArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeArmBasic();
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                ArmExtraObj_0.SetActive(false);
                                ArmExtraObj_1.SetActive(false);
                                ArmExtraObj_2.SetActive(false);
                                ArmExtraObj_3.SetActive(false);
                                ArmExtraObj_4.SetActive(false);
                                ArmExtraObj_5.SetActive(false);
                                ArmExtraObj_None.SetActive(true);
                                PowerId();
                                ArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                ArmExtraObj_0.SetActive(true);
                                ArmExtraObj_1.SetActive(true);
                                ArmExtraObj_2.SetActive(false);
                                ArmExtraObj_3.SetActive(false);
                                ArmExtraObj_4.SetActive(false);
                                ArmExtraObj_5.SetActive(false);
                                ArmExtraObj_None.SetActive(false);
                                PowerId();
                                ArmExtra_0.text = ArmExtraPower_0;
                                ArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                ArmExtraObj_0.SetActive(true);
                                ArmExtraObj_1.SetActive(true);
                                ArmExtraObj_2.SetActive(true);
                                ArmExtraObj_3.SetActive(true);
                                ArmExtraObj_4.SetActive(false);
                                ArmExtraObj_5.SetActive(false);
                                ArmExtraObj_None.SetActive(false);
                                PowerId();
                                ArmExtra_0.text = ArmExtraPower_0;
                                ArmExtra_1.text = ArmExtraPower_1;
                                ArmExtra_2.text = ArmExtraPower_2;
                                ArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                ArmExtraObj_0.SetActive(true);
                                ArmExtraObj_1.SetActive(true);
                                ArmExtraObj_2.SetActive(true);
                                ArmExtraObj_3.SetActive(true);
                                ArmExtraObj_4.SetActive(true);
                                ArmExtraObj_5.SetActive(true);
                                ArmExtraObj_None.SetActive(false);
                                PowerId();
                                ArmExtra_0.text = ArmExtraPower_0;
                                ArmExtra_1.text = ArmExtraPower_1;
                                ArmExtra_2.text = ArmExtraPower_2;
                                ArmExtra_3.text = ArmExtraPower_3;
                                ArmExtra_4.text = ArmExtraPower_4;
                                ArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
            case 2:
                {
                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, ArmId);
                    PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                    ArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeArmBasic();
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                ArmExtraObj_0.SetActive(false);
                                ArmExtraObj_1.SetActive(false);
                                ArmExtraObj_2.SetActive(false);
                                ArmExtraObj_3.SetActive(false);
                                ArmExtraObj_4.SetActive(false);
                                ArmExtraObj_5.SetActive(false);
                                ArmExtraObj_None.SetActive(true);
                                PowerId();
                                ArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                ArmExtraObj_0.SetActive(true);
                                ArmExtraObj_1.SetActive(true);
                                ArmExtraObj_2.SetActive(false);
                                ArmExtraObj_3.SetActive(false);
                                ArmExtraObj_4.SetActive(false);
                                ArmExtraObj_5.SetActive(false);
                                ArmExtraObj_None.SetActive(false);
                                PowerId();
                                ArmExtra_0.text = ArmExtraPower_0;
                                ArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                ArmExtraObj_0.SetActive(true);
                                ArmExtraObj_1.SetActive(true);
                                ArmExtraObj_2.SetActive(true);
                                ArmExtraObj_3.SetActive(true);
                                ArmExtraObj_4.SetActive(false);
                                ArmExtraObj_5.SetActive(false);
                                ArmExtraObj_None.SetActive(false);
                                PowerId();
                                ArmExtra_0.text = ArmExtraPower_0;
                                ArmExtra_1.text = ArmExtraPower_1;
                                ArmExtra_2.text = ArmExtraPower_2;
                                ArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                ArmExtraObj_0.SetActive(true);
                                ArmExtraObj_1.SetActive(true);
                                ArmExtraObj_2.SetActive(true);
                                ArmExtraObj_3.SetActive(true);
                                ArmExtraObj_4.SetActive(true);
                                ArmExtraObj_5.SetActive(true);
                                ArmExtraObj_None.SetActive(false);
                                PowerId();
                                ArmExtra_0.text = ArmExtraPower_0;
                                ArmExtra_1.text = ArmExtraPower_1;
                                ArmExtra_2.text = ArmExtraPower_2;
                                ArmExtra_3.text = ArmExtraPower_3;
                                ArmExtra_4.text = ArmExtraPower_4;
                                ArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
            case 3:
                {
                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, ArmId);
                    PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                    ArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeArmBasic();
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                ArmExtraObj_0.SetActive(false);
                                ArmExtraObj_1.SetActive(false);
                                ArmExtraObj_2.SetActive(false);
                                ArmExtraObj_3.SetActive(false);
                                ArmExtraObj_4.SetActive(false);
                                ArmExtraObj_5.SetActive(false);
                                ArmExtraObj_None.SetActive(true);
                                PowerId();
                                ArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                ArmExtraObj_0.SetActive(true);
                                ArmExtraObj_1.SetActive(true);
                                ArmExtraObj_2.SetActive(false);
                                ArmExtraObj_3.SetActive(false);
                                ArmExtraObj_4.SetActive(false);
                                ArmExtraObj_5.SetActive(false);
                                ArmExtraObj_None.SetActive(false);
                                PowerId();
                                ArmExtra_0.text = ArmExtraPower_0;
                                ArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                ArmExtraObj_0.SetActive(true);
                                ArmExtraObj_1.SetActive(true);
                                ArmExtraObj_2.SetActive(true);
                                ArmExtraObj_3.SetActive(true);
                                ArmExtraObj_4.SetActive(false);
                                ArmExtraObj_5.SetActive(false);
                                ArmExtraObj_None.SetActive(false);
                                PowerId();
                                ArmExtra_0.text = ArmExtraPower_0;
                                ArmExtra_1.text = ArmExtraPower_1;
                                ArmExtra_2.text = ArmExtraPower_2;
                                ArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                ArmExtraObj_0.SetActive(true);
                                ArmExtraObj_1.SetActive(true);
                                ArmExtraObj_2.SetActive(true);
                                ArmExtraObj_3.SetActive(true);
                                ArmExtraObj_4.SetActive(true);
                                ArmExtraObj_5.SetActive(true);
                                ArmExtraObj_None.SetActive(false);
                                PowerId();
                                ArmExtra_0.text = ArmExtraPower_0;
                                ArmExtra_1.text = ArmExtraPower_1;
                                ArmExtra_2.text = ArmExtraPower_2;
                                ArmExtra_3.text = ArmExtraPower_3;
                                ArmExtra_4.text = ArmExtraPower_4;
                                ArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
            case 4:
                {
                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, ArmId);
                    PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                    ArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeArmBasic();
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                ArmExtraObj_0.SetActive(false);
                                ArmExtraObj_1.SetActive(false);
                                ArmExtraObj_2.SetActive(false);
                                ArmExtraObj_3.SetActive(false);
                                ArmExtraObj_4.SetActive(false);
                                ArmExtraObj_5.SetActive(false);
                                ArmExtraObj_None.SetActive(true);
                                PowerId();
                                ArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                ArmExtraObj_0.SetActive(true);
                                ArmExtraObj_1.SetActive(true);
                                ArmExtraObj_2.SetActive(false);
                                ArmExtraObj_3.SetActive(false);
                                ArmExtraObj_4.SetActive(false);
                                ArmExtraObj_5.SetActive(false);
                                ArmExtraObj_None.SetActive(false);
                                PowerId();
                                ArmExtra_0.text = ArmExtraPower_0;
                                ArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                ArmExtraObj_0.SetActive(true);
                                ArmExtraObj_1.SetActive(true);
                                ArmExtraObj_2.SetActive(true);
                                ArmExtraObj_3.SetActive(true);
                                ArmExtraObj_4.SetActive(false);
                                ArmExtraObj_5.SetActive(false);
                                ArmExtraObj_None.SetActive(false);
                                PowerId();
                                ArmExtra_0.text = ArmExtraPower_0;
                                ArmExtra_1.text = ArmExtraPower_1;
                                ArmExtra_2.text = ArmExtraPower_2;
                                ArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                ArmExtraObj_0.SetActive(true);
                                ArmExtraObj_1.SetActive(true);
                                ArmExtraObj_2.SetActive(true);
                                ArmExtraObj_3.SetActive(true);
                                ArmExtraObj_4.SetActive(true);
                                ArmExtraObj_5.SetActive(true);
                                ArmExtraObj_None.SetActive(false);
                                PowerId();
                                ArmExtra_0.text = ArmExtraPower_0;
                                ArmExtra_1.text = ArmExtraPower_1;
                                ArmExtra_2.text = ArmExtraPower_2;
                                ArmExtra_3.text = ArmExtraPower_3;
                                ArmExtra_4.text = ArmExtraPower_4;
                                ArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
            case 5:
                {
                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, ArmId);
                    PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                    ArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeArmBasic();
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                ArmExtraObj_0.SetActive(false);
                                ArmExtraObj_1.SetActive(false);
                                ArmExtraObj_2.SetActive(false);
                                ArmExtraObj_3.SetActive(false);
                                ArmExtraObj_4.SetActive(false);
                                ArmExtraObj_5.SetActive(false);
                                ArmExtraObj_None.SetActive(true);
                                PowerId();
                                ArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                ArmExtraObj_0.SetActive(true);
                                ArmExtraObj_1.SetActive(true);
                                ArmExtraObj_2.SetActive(false);
                                ArmExtraObj_3.SetActive(false);
                                ArmExtraObj_4.SetActive(false);
                                ArmExtraObj_5.SetActive(false);
                                ArmExtraObj_None.SetActive(false);
                                PowerId();
                                ArmExtra_0.text = ArmExtraPower_0;
                                ArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                ArmExtraObj_0.SetActive(true);
                                ArmExtraObj_1.SetActive(true);
                                ArmExtraObj_2.SetActive(true);
                                ArmExtraObj_3.SetActive(true);
                                ArmExtraObj_4.SetActive(false);
                                ArmExtraObj_5.SetActive(false);
                                ArmExtraObj_None.SetActive(false);
                                PowerId();
                                ArmExtra_0.text = ArmExtraPower_0;
                                ArmExtra_1.text = ArmExtraPower_1;
                                ArmExtra_2.text = ArmExtraPower_2;
                                ArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                ArmExtraObj_0.SetActive(true);
                                ArmExtraObj_1.SetActive(true);
                                ArmExtraObj_2.SetActive(true);
                                ArmExtraObj_3.SetActive(true);
                                ArmExtraObj_4.SetActive(true);
                                ArmExtraObj_5.SetActive(true);
                                ArmExtraObj_None.SetActive(false);
                                PowerId();
                                ArmExtra_0.text = ArmExtraPower_0;
                                ArmExtra_1.text = ArmExtraPower_1;
                                ArmExtra_2.text = ArmExtraPower_2;
                                ArmExtra_3.text = ArmExtraPower_3;
                                ArmExtra_4.text = ArmExtraPower_4;
                                ArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
            case 6:
                {
                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, ArmId);
                    PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                    ArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeArmBasic();
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                ArmExtraObj_0.SetActive(false);
                                ArmExtraObj_1.SetActive(false);
                                ArmExtraObj_2.SetActive(false);
                                ArmExtraObj_3.SetActive(false);
                                ArmExtraObj_4.SetActive(false);
                                ArmExtraObj_5.SetActive(false);
                                ArmExtraObj_None.SetActive(true);
                                PowerId();
                                ArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                ArmExtraObj_0.SetActive(true);
                                ArmExtraObj_1.SetActive(true);
                                ArmExtraObj_2.SetActive(false);
                                ArmExtraObj_3.SetActive(false);
                                ArmExtraObj_4.SetActive(false);
                                ArmExtraObj_5.SetActive(false);
                                ArmExtraObj_None.SetActive(false);
                                PowerId();
                                ArmExtra_0.text = ArmExtraPower_0;
                                ArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                ArmExtraObj_0.SetActive(true);
                                ArmExtraObj_1.SetActive(true);
                                ArmExtraObj_2.SetActive(true);
                                ArmExtraObj_3.SetActive(true);
                                ArmExtraObj_4.SetActive(false);
                                ArmExtraObj_5.SetActive(false);
                                ArmExtraObj_None.SetActive(false);
                                PowerId();
                                ArmExtra_0.text = ArmExtraPower_0;
                                ArmExtra_1.text = ArmExtraPower_1;
                                ArmExtra_2.text = ArmExtraPower_2;
                                ArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                ArmExtraObj_0.SetActive(true);
                                ArmExtraObj_1.SetActive(true);
                                ArmExtraObj_2.SetActive(true);
                                ArmExtraObj_3.SetActive(true);
                                ArmExtraObj_4.SetActive(true);
                                ArmExtraObj_5.SetActive(true);
                                ArmExtraObj_None.SetActive(false);
                                PowerId();
                                ArmExtra_0.text = ArmExtraPower_0;
                                ArmExtra_1.text = ArmExtraPower_1;
                                ArmExtra_2.text = ArmExtraPower_2;
                                ArmExtra_3.text = ArmExtraPower_3;
                                ArmExtra_4.text = ArmExtraPower_4;
                                ArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
            case 7:
                {
                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, ArmId);
                    PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                    ArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeArmBasic();
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                ArmExtraObj_0.SetActive(false);
                                ArmExtraObj_1.SetActive(false);
                                ArmExtraObj_2.SetActive(false);
                                ArmExtraObj_3.SetActive(false);
                                ArmExtraObj_4.SetActive(false);
                                ArmExtraObj_5.SetActive(false);
                                ArmExtraObj_None.SetActive(true);
                                PowerId();
                                ArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                ArmExtraObj_0.SetActive(true);
                                ArmExtraObj_1.SetActive(true);
                                ArmExtraObj_2.SetActive(false);
                                ArmExtraObj_3.SetActive(false);
                                ArmExtraObj_4.SetActive(false);
                                ArmExtraObj_5.SetActive(false);
                                ArmExtraObj_None.SetActive(false);
                                PowerId();
                                ArmExtra_0.text = ArmExtraPower_0;
                                ArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                ArmExtraObj_0.SetActive(true);
                                ArmExtraObj_1.SetActive(true);
                                ArmExtraObj_2.SetActive(true);
                                ArmExtraObj_3.SetActive(true);
                                ArmExtraObj_4.SetActive(false);
                                ArmExtraObj_5.SetActive(false);
                                ArmExtraObj_None.SetActive(false);
                                PowerId();
                                ArmExtra_0.text = ArmExtraPower_0;
                                ArmExtra_1.text = ArmExtraPower_1;
                                ArmExtra_2.text = ArmExtraPower_2;
                                ArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                ArmExtraObj_0.SetActive(true);
                                ArmExtraObj_1.SetActive(true);
                                ArmExtraObj_2.SetActive(true);
                                ArmExtraObj_3.SetActive(true);
                                ArmExtraObj_4.SetActive(true);
                                ArmExtraObj_5.SetActive(true);
                                ArmExtraObj_None.SetActive(false);
                                PowerId();
                                ArmExtra_0.text = ArmExtraPower_0;
                                ArmExtra_1.text = ArmExtraPower_1;
                                ArmExtra_2.text = ArmExtraPower_2;
                                ArmExtra_3.text = ArmExtraPower_3;
                                ArmExtra_4.text = ArmExtraPower_4;
                                ArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
        }
    }

    public void SecondArmChange()                                                   //判斷該裝備欄位是否有分主手跟副手
    {
        int ChangeNum = Convert.ToInt32(Equip_ArmId_AlwaysFalseClone.text);
        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, ChangeNum);
        PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
        int armidconfirm = 0;

        switch (ArmStatic.ArmType)
		{
            case 0:
                {
                    switch (weaponsecond)
                    {
                        case true:
                            {
                                switch(CharaterArmStatic.ArmMain)
								{
                                    case 0:
										{
                                            armidconfirm = 0;     //該裝備為主手武器
                                            break;
										}
                                    case 1:
										{
                                            armidconfirm = 1;     //該裝備為副手武器
                                            break;
										}
								}
                                break;
                            }
                        case false:
                            {
                                armidconfirm = 2;                 //副手武器欄位沒有被裝備
                                break;
                            }
                    }
                    break;
                }
            case 3:
				{
                    switch (ringsecond)
                    {
                        case true:
                            {
                                switch (CharaterArmStatic.ArmMain)
                                {
                                    case 0:
                                        {
                                            armidconfirm = 3;    //該裝備為主手戒指
                                            break;
                                        }
                                    case 1:
                                        {
                                            armidconfirm = 4;    //該裝備為主手戒指
                                            break;
                                        }
                                }
                                break;
                            }
                        case false:
                            {
                                armidconfirm = 5;                //副手戒指欄位沒有被裝備
                                break;
                            }
                    }
                    break;
				}
            default:
				{
                    armidconfirm = 101;
                    break;
				}
		}

        switch(armidconfirm)
		{
            case 0:
				{                    
                    //WeaponChange(ChangeNum);
                    Btn_UnEquip.SetActive(true);
                    Btn_Second.SetActive(true);
                    Btn_UnEquipAlone.SetActive(false);
                    MainSecondSwitch.text = "副手";
                    break;
				}
            case 1:
				{                 
                    //WeaponChange(ChangeNum);
                    Btn_UnEquip.SetActive(true);
                    Btn_Second.SetActive(true);
                    Btn_UnEquipAlone.SetActive(false);
                    MainSecondSwitch.text = "主手";
                    break;
				}
            case 2:
				{
                    Btn_UnEquip.SetActive(false);
                    Btn_Second.SetActive(false);
                    Btn_UnEquipAlone.SetActive(true);
                    break;
				}
            case 3:
				{                 
                    //RingChange(ChangeNum);
                    Btn_UnEquip.SetActive(true);
                    Btn_Second.SetActive(true);
                    Btn_UnEquipAlone.SetActive(false);
                    MainSecondSwitch.text = "副手";
                    break;
				}
            case 4:
                {
                    //RingChange(ChangeNum);
                    Btn_UnEquip.SetActive(true);
                    Btn_Second.SetActive(true);
                    Btn_UnEquipAlone.SetActive(false);
                    MainSecondSwitch.text = "主手";
                    break;
                }
            case 5:
                {
                    Btn_UnEquip.SetActive(false);
                    Btn_Second.SetActive(false);
                    Btn_UnEquipAlone.SetActive(true);
                    break;
                }
            default:
				{
                    break;
				}
		}

       


        /*
        //-----舊做法，但裝備相關code已經全部改掉，故此作法不適用
        if (ChangeNum == 0)
        {
            WeaponChange(1);
        }
        if (ChangeNum == 1)
        {
            WeaponChange(0);
        }
        if (ChangeNum == 4)
        {
            RingChange(5);
        }
        if (ChangeNum == 5)
        {
            RingChange(4);
        }
        //-----
        */
    }

    public void WeaponChange(int Id)                                                //武器的主副手欄位切換功能
    {
        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, Id);
        PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
        JudgeEquipArm(Id);
    }

    public void RingChange(int Id)                                                  //戒指的主副手欄位切換功能
    {
        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, Id);
        PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
        JudgeEquipArm(Id);
    }

    public void UnEquipArmChange()                                                  //卸下裝備
    {
        //-----取得目前選擇的裝備是甚麼角色裝備編號
        int ChangeNum = Convert.ToInt32(Equip_ArmId_AlwaysFalseClone.text);
        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, ChangeNum);
        PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
        //-----

        //-----給卸下裝備後的角色數值修改
        UnEquipArmCharaterPropertyChanger();
        ChangeCharaterProperty();

        CharaterInfoClone.CheckCharaterArmList();
        CharaterInfoClone.ChangArmNum(ChangeNum);
        CharaterInfoClone.CheckCharaterArmList();

        /*for (int arrayNum = 0; arrayNum < CharaterInfo.CharaterArmCount - 1; arrayNum++)
        {
            if (CharaterInfo.CharaterArm[CharaterInfo.CharaterArmCount - 1] < CharaterInfo.CharaterArm[CharaterInfo.CharaterArmCount - 2])
            {
                int OldNum = CharaterInfo.CharaterArm[CharaterInfo.CharaterArmCount - 2];
                CharaterInfo.CharaterArm[CharaterInfo.CharaterArmCount - 2] = CharaterInfo.CharaterArm[CharaterInfo.CharaterArmCount - 1];
                CharaterInfo.CharaterArm[CharaterInfo.CharaterArmCount - 1] = OldNum;
            }
            if (CharaterInfo.CharaterArm[arrayNum + 1] < CharaterInfo.CharaterArm[arrayNum])
            {
                int OldNum = CharaterInfo.CharaterArm[arrayNum];
                CharaterInfo.CharaterArm[arrayNum] = CharaterInfo.CharaterArm[arrayNum + 1];
                CharaterInfo.CharaterArm[arrayNum + 1] = OldNum;
            }
        }*/

        CharaterInfoClone.UnEquipInputICON();


        /*int NewArmId = CharaterInfo.CharaterArm[CharaterInfo.CharaterArmCount - 1];

        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, NewArmId);

        CharaterInfoClone.ChangeArmListNew(ChangeNum, NewArmId);
        CharaterInfoClone.InputEquipmentArm();*/
        EquipArm.SetActive(false);
        //ArmNum = CharaterArmStatic.id;
    }

    public void ArmChangeEquip()                                                    //裝上裝備
    {
        int ArmIdWantChange = Convert.ToInt32(ArmId_AlwaysFalseClone.text);
        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, ArmIdWantChange);
        PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
        int EquipArmNow = Convert.ToInt32(Equip_ArmId_AlwaysFalseClone.text);
        switch (ArmStatic.ArmType)
        {
            case 0:
                {
                    bool MainEquip, SecondEquip;
                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 0);
                    MainEquip = CharaterArmStatic.ArmEquip;
                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 1);
                    SecondEquip = CharaterArmStatic.ArmEquip;
                    if (MainEquip == false && SecondEquip == false)
                    {
                        int LodArmId = CharaterArmStatic.id;
                        ArmChangeEquipNum(LodArmId, 0);
                        EquipArm.SetActive(true);
                        UnEquipArm.SetActive(false);
                        Btn_UnEquip.SetActive(false);
                        Btn_Second.SetActive(false);
                        Btn_UnEquipAlone.SetActive(true);
                        ArmEquipChangeAfterShowEquip(0);
                        CharaterInfoClone.ChangeArmListNew(LodArmId, 0);
                        CharaterInfoClone.InputEquipmentArmOther(0);
                        PlusArmInfo(0);
                        ChangeCharaterProperty();
                        return;
                    }
                    if (MainEquip == true && SecondEquip == false)
                    {
                        int LodArmId = CharaterArmStatic.id;
                        UnEquipArmChangeForEquip(1);
                        ArmChangeEquipNum(LodArmId, 1);
                        EquipArm.SetActive(true);
                        UnEquipArm.SetActive(false);
                        Btn_UnEquip.SetActive(true);
                        Btn_Second.SetActive(true);
                        Btn_UnEquipAlone.SetActive(false);
                        ArmEquipChangeAfterShowEquip(1);
                        ArmEquipChangeAfterShowArm(CharaterInfo.CharaterArm[CharaterInfo.CharaterArmCount - 1]);
                        CharaterInfoClone.ChangeArmListNew(LodArmId, 1);
                        CharaterInfoClone.InputEquipmentArmOther(1);
                        PlusArmInfo(1);
                        ChangeCharaterProperty();
                        return;
                    }
                    if(MainEquip == false && SecondEquip == true)
                    {
                        int LodArmId = CharaterArmStatic.id;
                        ArmChangeEquipNum(LodArmId, 0);
                        EquipArm.SetActive(true);
                        UnEquipArm.SetActive(false);
                        Btn_UnEquip.SetActive(true);
                        Btn_Second.SetActive(true);
                        Btn_UnEquipAlone.SetActive(false);
                        ArmEquipChangeAfterShowEquip(0);
                        CharaterInfoClone.ChangeArmListNew(LodArmId, 0);
                        CharaterInfoClone.InputEquipmentArmOther(0);
                        PlusArmInfo(0);
                        ChangeCharaterProperty();
                        return;
                    }
                    if (MainEquip == true && SecondEquip == true)
                    {
                        if(EquipArmNow == 0)
                        {
                            int LodArmId = CharaterArmStatic.id;
                            UnEquipArmChangeForEquip(0);
                            ArmChangeEquipNum(LodArmId, 0);
                            EquipArm.SetActive(true);
                            UnEquipArm.SetActive(true);
                            Btn_UnEquip.SetActive(true);
                            Btn_Second.SetActive(true);
                            Btn_UnEquipAlone.SetActive(false);
                            ArmEquipChangeAfterShowEquip(0);
                            CharaterInfoClone.ChangeArmListNew(LodArmId, 0);
                            CharaterInfoClone.InputEquipmentArmOther(0);
                            PlusArmInfo(0);
                            ChangeCharaterProperty();
                            return;
                        }
                        if (EquipArmNow == 1)
                        {
                            int LodArmId = CharaterArmStatic.id;
                            UnEquipArmChangeForEquip(1);
                            ArmChangeEquipNum(LodArmId, 1);
                            EquipArm.SetActive(true);
                            UnEquipArm.SetActive(true);
                            Btn_UnEquip.SetActive(true);
                            Btn_Second.SetActive(true);
                            Btn_UnEquipAlone.SetActive(false);
                            ArmEquipChangeAfterShowEquip(1);
                            CharaterInfoClone.ChangeArmListNew(LodArmId, 1);
                            CharaterInfoClone.InputEquipmentArmOther(1);
                            PlusArmInfo(1);
                            ChangeCharaterProperty();
                            return;
                        }
                    }
                    break;
                }
            case 1:
                {
                    if (CharaterArmStatic.ArmEquip == false)
                    {
                        int LodArmId = CharaterArmStatic.id;
                        ArmChangeEquipNum(LodArmId, 2);
                        ArmEquipChangeAfterShowEquip(2);
                        CharaterInfoClone.ChangeArmListNew(LodArmId, 2);
                        CharaterInfoClone.InputEquipmentArmOther(2);
                        EquipArm.SetActive(true);
                        UnEquipArm.SetActive(false);
                        Btn_UnEquip.SetActive(false);
                        Btn_Second.SetActive(false);
                        Btn_UnEquipAlone.SetActive(true);
                        PlusArmInfo(2);
                        ChangeCharaterProperty();
                        return;
                    }
                    if (CharaterArmStatic.ArmEquip == true)
                    {
                        int LodArmId = CharaterArmStatic.id;
                        UnEquipArmChangeForEquip(2);
                        ArmChangeEquipNum(LodArmId, 2);
                        ArmEquipChangeAfterShowEquip(2);
                        ArmEquipChangeAfterShowArm(CharaterInfo.CharaterArm[CharaterInfo.CharaterArmCount - 1]);
                        EquipArm.SetActive(true);
                        UnEquipArm.SetActive(true);
                        Btn_UnEquip.SetActive(false);
                        Btn_Second.SetActive(false);
                        Btn_UnEquipAlone.SetActive(true);
                        CharaterInfoClone.ChangeArmListNew(LodArmId, 2);
                        CharaterInfoClone.InputEquipmentArmOther(2);
                        PlusArmInfo(2);
                        ChangeCharaterProperty();
                        return;
                    }
                    break;
                }
            case 2:
                {
                    if (CharaterArmStatic.ArmEquip == false)
                    {
                        int LodArmId = CharaterArmStatic.id;
                        ArmChangeEquipNum(LodArmId, 3);
                        EquipArm.SetActive(true);
                        UnEquipArm.SetActive(false);
                        Btn_UnEquip.SetActive(false);
                        Btn_Second.SetActive(false);
                        Btn_UnEquipAlone.SetActive(true);
                        ArmEquipChangeAfterShowEquip(3);
                        CharaterInfoClone.ChangeArmListNew(LodArmId, 3);
                        CharaterInfoClone.InputEquipmentArmOther(3);
                        PlusArmInfo(3);
                        ChangeCharaterProperty();
                        return;
                    }
                    if (CharaterArmStatic.ArmEquip == true)
                    {
                        int LodArmId = CharaterArmStatic.id;
                        UnEquipArmChangeForEquip(3);
                        ArmChangeEquipNum(LodArmId, 3);
                        EquipArm.SetActive(true);
                        UnEquipArm.SetActive(true);
                        Btn_UnEquip.SetActive(false);
                        Btn_Second.SetActive(false);
                        Btn_UnEquipAlone.SetActive(true);
                        ArmEquipChangeAfterShowEquip(3);
                        ArmEquipChangeAfterShowArm(CharaterInfo.CharaterArm[CharaterInfo.CharaterArmCount - 1]);
                        CharaterInfoClone.ChangeArmListNew(LodArmId, 3);
                        CharaterInfoClone.InputEquipmentArmOther(3);
                        PlusArmInfo(3);
                        ChangeCharaterProperty();
                        return;
                    }
                    break;
                }
            case 3:
                {
                    bool MainEquip, SecondEquip;
                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 0);
                    MainEquip = CharaterArmStatic.ArmEquip;
                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 1);
                    SecondEquip = CharaterArmStatic.ArmEquip;
                    if (MainEquip == false && SecondEquip == false)
                    {
                        int LodArmId = CharaterArmStatic.id;
                        ArmChangeEquipNum(LodArmId, 4);
                        EquipArm.SetActive(true);
                        UnEquipArm.SetActive(false);
                        Btn_UnEquip.SetActive(false);
                        Btn_Second.SetActive(false);
                        Btn_UnEquipAlone.SetActive(true);
                        ArmEquipChangeAfterShowEquip(4);
                        CharaterInfoClone.ChangeArmListNew(LodArmId, 4);
                        CharaterInfoClone.InputEquipmentArmOther(4);
                        PlusArmInfo(4);
                        ChangeCharaterProperty();
                        return;
                    }
                    if (MainEquip == true && SecondEquip == false)
                    {
                        int LodArmId = CharaterArmStatic.id;
                        UnEquipArmChangeForEquip(5);
                        ArmChangeEquipNum(LodArmId, 5);
                        EquipArm.SetActive(true);
                        UnEquipArm.SetActive(false);
                        Btn_UnEquip.SetActive(true);
                        Btn_Second.SetActive(true);
                        Btn_UnEquipAlone.SetActive(false);
                        ArmEquipChangeAfterShowEquip(5);
                        ArmEquipChangeAfterShowArm(CharaterInfo.CharaterArm[CharaterInfo.CharaterArmCount - 1]);
                        CharaterInfoClone.ChangeArmListNew(LodArmId, 5);
                        CharaterInfoClone.InputEquipmentArmOther(5);
                        PlusArmInfo(5);
                        ChangeCharaterProperty();
                        return;
                    }
                    if (MainEquip == false && SecondEquip == true)
                    {
                        int LodArmId = CharaterArmStatic.id;
                        ArmChangeEquipNum(LodArmId, 4);
                        EquipArm.SetActive(true);
                        UnEquipArm.SetActive(false);
                        Btn_UnEquip.SetActive(true);
                        Btn_Second.SetActive(true);
                        Btn_UnEquipAlone.SetActive(false);
                        ArmEquipChangeAfterShowEquip(4);
                        CharaterInfoClone.ChangeArmListNew(LodArmId, 4);
                        CharaterInfoClone.InputEquipmentArmOther(4);
                        PlusArmInfo(4);
                        ChangeCharaterProperty();
                        return;
                    }
                    if (MainEquip == false && SecondEquip == false)
                    {
                        if(EquipArmNow == 4)
                        {
                            int LodArmId = CharaterArmStatic.id;
                            UnEquipArmChangeForEquip(4);
                            ArmChangeEquipNum(LodArmId, 4);
                            EquipArm.SetActive(true);
                            UnEquipArm.SetActive(true);
                            Btn_UnEquip.SetActive(true);
                            Btn_Second.SetActive(true);
                            Btn_UnEquipAlone.SetActive(false);
                            ArmEquipChangeAfterShowEquip(4);
                            CharaterInfoClone.ChangeArmListNew(LodArmId, 4);
                            CharaterInfoClone.InputEquipmentArmOther(4);
                            PlusArmInfo(4);
                            ChangeCharaterProperty();
                            return;
                        }
                        if (EquipArmNow == 5)
                        {
                            int LodArmId = CharaterArmStatic.id;
                            UnEquipArmChangeForEquip(5);
                            ArmChangeEquipNum(LodArmId, 5);
                            EquipArm.SetActive(true);
                            UnEquipArm.SetActive(true);
                            Btn_UnEquip.SetActive(true);
                            Btn_Second.SetActive(true);
                            Btn_UnEquipAlone.SetActive(false);
                            ArmEquipChangeAfterShowEquip(5);
                            CharaterInfoClone.ChangeArmListNew(LodArmId, 5);
                            CharaterInfoClone.InputEquipmentArmOther(5);
                            PlusArmInfo(5);
                            ChangeCharaterProperty();
                            return;
                        }
                    }
                    break;
                }
            case 4:
                {
                    if (CharaterArmStatic.ArmEquip == false)
                    {
                        int LodArmId = CharaterArmStatic.id;
                        ArmChangeEquipNum(LodArmId, 6);
                        EquipArm.SetActive(true);
                        UnEquipArm.SetActive(false);
                        Btn_UnEquip.SetActive(false);
                        Btn_Second.SetActive(false);
                        Btn_UnEquipAlone.SetActive(true);
                        ArmEquipChangeAfterShowEquip(6);
                        CharaterInfoClone.ChangeArmListNew(LodArmId, 6);
                        CharaterInfoClone.InputEquipmentArmOther(6);
                        PlusArmInfo(6);
                        ChangeCharaterProperty();
                        return;
                    }
                    if (CharaterArmStatic.ArmEquip == true)
                    {
                        int LodArmId = CharaterArmStatic.id;
                        UnEquipArmChangeForEquip(6);
                        ArmChangeEquipNum(LodArmId, 6);
                        EquipArm.SetActive(true);
                        UnEquipArm.SetActive(true);
                        Btn_UnEquip.SetActive(false);
                        Btn_Second.SetActive(false);
                        Btn_UnEquipAlone.SetActive(true);
                        ArmEquipChangeAfterShowEquip(6);
                        ArmEquipChangeAfterShowArm(CharaterInfo.CharaterArm[CharaterInfo.CharaterArmCount - 1]);
                        CharaterInfoClone.ChangeArmListNew(LodArmId, 6);
                        CharaterInfoClone.InputEquipmentArmOther(6);
                        PlusArmInfo(6);
                        ChangeCharaterProperty();
                        return;
                    }
                    break;
                }
            case 5:
                {
                    if (CharaterArmStatic.ArmEquip == false)
                    {
                        int LodArmId = CharaterArmStatic.id;
                        ArmChangeEquipNum(LodArmId, 7);
                        EquipArm.SetActive(true);
                        UnEquipArm.SetActive(false);
                        Btn_UnEquip.SetActive(false);
                        Btn_Second.SetActive(false);
                        Btn_UnEquipAlone.SetActive(true);
                        ArmEquipChangeAfterShowEquip(7);
                        CharaterInfoClone.ChangeArmListNew(LodArmId, 7);
                        CharaterInfoClone.InputEquipmentArmOther(7);
                        PlusArmInfo(7);
                        ChangeCharaterProperty();
                        return;
                    }
                    if (CharaterArmStatic.ArmEquip == true)
                    {
                        int LodArmId = CharaterArmStatic.id;
                        UnEquipArmChangeForEquip(7);
                        ArmChangeEquipNum(LodArmId, 7);
                        EquipArm.SetActive(true);
                        UnEquipArm.SetActive(true);
                        Btn_UnEquip.SetActive(false);
                        Btn_Second.SetActive(false);
                        Btn_UnEquipAlone.SetActive(true);
                        ArmEquipChangeAfterShowEquip(7);
                        ArmEquipChangeAfterShowArm(CharaterInfo.CharaterArm[CharaterInfo.CharaterArmCount - 1]);
                        CharaterInfoClone.ChangeArmListNew(LodArmId, 7);
                        CharaterInfoClone.InputEquipmentArmOther(7);
                        PlusArmInfo(7);
                        ChangeCharaterProperty();
                        return;
                    }
                    break;
                }
            case 6:
                {
                    if (CharaterArmStatic.ArmEquip == false)
                    {
                        int LodArmId = CharaterArmStatic.id;
                        ArmChangeEquipNum(LodArmId, 8);
                        EquipArm.SetActive(true);
                        UnEquipArm.SetActive(false);
                        Btn_UnEquip.SetActive(false);
                        Btn_Second.SetActive(false);
                        Btn_UnEquipAlone.SetActive(true);
                        ArmEquipChangeAfterShowEquip(8);
                        CharaterInfoClone.ChangeArmListNew(LodArmId, 8);
                        CharaterInfoClone.InputEquipmentArmOther(8);
                        PlusArmInfo(8);
                        ChangeCharaterProperty();
                        return;
                    }
                    if (CharaterArmStatic.ArmEquip == true)
                    {
                        int LodArmId = CharaterArmStatic.id;
                        UnEquipArmChangeForEquip(8);
                        ArmChangeEquipNum(LodArmId, 8);
                        EquipArm.SetActive(true);
                        UnEquipArm.SetActive(true);
                        Btn_UnEquip.SetActive(false);
                        Btn_Second.SetActive(false);
                        Btn_UnEquipAlone.SetActive(true);
                        ArmEquipChangeAfterShowEquip(8);
                        ArmEquipChangeAfterShowArm(CharaterInfo.CharaterArm[CharaterInfo.CharaterArmCount - 1]);
                        CharaterInfoClone.ChangeArmListNew(LodArmId, 8);
                        CharaterInfoClone.InputEquipmentArmOther(8);
                        PlusArmInfo(8);
                        ChangeCharaterProperty();
                        return;
                    }
                    break;
                }
            case 7:
                {
                    if (CharaterArmStatic.ArmEquip == false)
                    {
                        int LodArmId = CharaterArmStatic.id;
                        ArmChangeEquipNum(LodArmId, 9);
                        EquipArm.SetActive(true);
                        UnEquipArm.SetActive(false);
                        Btn_UnEquip.SetActive(false);
                        Btn_Second.SetActive(false);
                        Btn_UnEquipAlone.SetActive(true);
                        ArmEquipChangeAfterShowEquip(9);
                        CharaterInfoClone.ChangeArmListNew(LodArmId, 9);
                        CharaterInfoClone.InputEquipmentArmOther(9);
                        PlusArmInfo(9);
                        ChangeCharaterProperty();
                        return;
                    }
                    if (CharaterArmStatic.ArmEquip == true)
                    {
                        int LodArmId = CharaterArmStatic.id;
                        UnEquipArmChangeForEquip(9);
                        ArmChangeEquipNum(LodArmId, 9);
                        EquipArm.SetActive(true);
                        UnEquipArm.SetActive(true);
                        Btn_UnEquip.SetActive(false);
                        Btn_Second.SetActive(false);
                        Btn_UnEquipAlone.SetActive(true);
                        ArmEquipChangeAfterShowEquip(9);
                        ArmEquipChangeAfterShowArm(CharaterInfo.CharaterArm[CharaterInfo.CharaterArmCount - 1]);
                        CharaterInfoClone.ChangeArmListNew(LodArmId, 9);
                        CharaterInfoClone.InputEquipmentArmOther(9);
                        PlusArmInfo(9);
                        ChangeCharaterProperty();
                        return;
                    }
                    break;
                }
        }
    }

    public void ShowEquipArm_0()                                                    //當玩家點擊裝備欄位上的裝備時要顯示該裝備的資訊界面
    {
        int CharaterArmId = Convert.ToInt32(CharaterInfoClone.MainWeaponCharaterArmId.text);
        JudgeEquipArm(CharaterArmId);
    }

    public void ShowEquipArm_1()                                                    //當玩家點擊裝備欄位上的裝備時要顯示該裝備的資訊界面
    {
        int CharaterArmId = Convert.ToInt32(CharaterInfoClone.SecondWeaponCharaterArmId.text);
        JudgeEquipArm(CharaterArmId);
    }

    public void ShowEquipArm_2()                                                    //當玩家點擊裝備欄位上的裝備時要顯示該裝備的資訊界面
    {
        int CharaterArmId = Convert.ToInt32(CharaterInfoClone.HeadCharaterArmId.text);
        JudgeEquipArm(CharaterArmId);
    }

    public void ShowEquipArm_3()                                                    //當玩家點擊裝備欄位上的裝備時要顯示該裝備的資訊界面
    {
        int CharaterArmId = Convert.ToInt32(CharaterInfoClone.BodyCharaterArmId.text);
        JudgeEquipArm(CharaterArmId);
    }

    public void ShowEquipArm_4()                                                    //當玩家點擊裝備欄位上的裝備時要顯示該裝備的資訊界面
    {
        int CharaterArmId = Convert.ToInt32(CharaterInfoClone.MainRingCharaterArmId.text);
        JudgeEquipArm(CharaterArmId);
    }

    public void ShowEquipArm_5()                                                    //當玩家點擊裝備欄位上的裝備時要顯示該裝備的資訊界面
    {
        int CharaterArmId = Convert.ToInt32(CharaterInfoClone.SecondRingCharaterArmId.text);
        JudgeEquipArm(CharaterArmId);
    }

    public void ShowEquipArm_6()                                                    //當玩家點擊裝備欄位上的裝備時要顯示該裝備的資訊界面
    {
        int CharaterArmId = Convert.ToInt32(CharaterInfoClone.NecklaceCharaterArmId.text);
        JudgeEquipArm(CharaterArmId);
    }

    public void ShowEquipArm_7()                                                    //當玩家點擊裝備欄位上的裝備時要顯示該裝備的資訊界面
    {
        int CharaterArmId = Convert.ToInt32(CharaterInfoClone.HandCharaterArmId.text);
        JudgeEquipArm(CharaterArmId);
    }

    public void ShowEquipArm_8()                                                    //當玩家點擊裝備欄位上的裝備時要顯示該裝備的資訊界面
    {
        int CharaterArmId = Convert.ToInt32(CharaterInfoClone.BeltCharaterArmId.text);
        JudgeEquipArm(CharaterArmId);
    }

    public void ShowEquipArm_9()                                                    //當玩家點擊裝備欄位上的裝備時要顯示該裝備的資訊界面
    {
        int CharaterArmId = Convert.ToInt32(CharaterInfoClone.FootCharaterArmId.text);
        JudgeEquipArm(CharaterArmId);
    }

    public void newtest(int CharaterArmId)
    {
        EquipArm.SetActive(true);
        UnEquipArm.SetActive(false);
        Btn_UnEquip.SetActive(false);
        Btn_Second.SetActive(false);
        Btn_UnEquipAlone.SetActive(true);
        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, CharaterArmId);
        PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
        EquipArmName.text = ArmStatic.ArmName;
        EquipArmRequsetLevel.text = "等級需求:" + ArmStatic.ArmLv;
        EquipArmRequestPower.text = "能力需求:" + "\n" + "力量:" + ArmStatic.ArmRequest_Strength + "智慧:" + ArmStatic.ArmRequest_Intelligence + "敏捷:" + ArmStatic.ArmRequest_Dexterity;
        Equip_ArmId_AlwaysFalseClone.text = CharaterArmId.ToString();    //紀錄目前顯示出裝備資訊的裝備ID，用途是用來辨認這是哪個裝備，卸下裝備，切換副手等功能需要
        switch (ArmStatic.ArmType)
        {
            case 0:
                {
                    switch(weaponsecond)
					{
                        case true:
							{
                                Btn_Second.SetActive(true);
                                break;
							}
                        case false:
							{
                                Btn_Second.SetActive(false);
                                break;
							}
					}
                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, CharaterArmStatic.id);
                    EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    switch (ArmStatic.WeaponSpeed != 0)
                    {
                        case true:
                            {
                                EquipArmBasicObj_0.SetActive(true);
                                EquipArmBasicObj_1.SetActive(true);
                                EquipArmBasicObj_2.SetActive(false);
                                EquipArmBasic_0.text = "攻擊速度:" + ArmStatic.WeaponSpeed;
                                EquipArmBasic_1.text = "物理攻擊:" + ArmStatic.WeaponDamageMin + "~" + ArmStatic.WeaponDamageMax;
                                break;
                            }
                        case false:
                            {
                                Debug.Log("該裝備是武器類型，但攻擊速度為0，是資料填錯造成的錯誤!");
                                break;
                            }
                    }
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {                                
                                EquipArmExtraObj_0.SetActive(false);
                                EquipArmExtraObj_1.SetActive(false);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(true);
                                PowerId();
                                EquipArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(true);
                                EquipArmExtraObj_5.SetActive(true);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                EquipArmExtra_4.text = ArmExtraPower_4;
                                EquipArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
            case 1:
                {
                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, CharaterArmStatic.id);
                    EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeEquipArmBasic();
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 2);
                                EquipArmExtraObj_0.SetActive(false);
                                EquipArmExtraObj_1.SetActive(false);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(true);
                                PowerId();
                                EquipArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 2);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 2);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 2);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(true);
                                EquipArmExtraObj_5.SetActive(true);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                EquipArmExtra_4.text = ArmExtraPower_4;
                                EquipArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
            case 2:
                {
                    EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeEquipArmBasic();
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 3);
                                EquipArmExtraObj_0.SetActive(false);
                                EquipArmExtraObj_1.SetActive(false);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(true);
                                PowerId();
                                EquipArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 3);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 3);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 3);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(true);
                                EquipArmExtraObj_5.SetActive(true);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                EquipArmExtra_4.text = ArmExtraPower_4;
                                EquipArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
            case 3:
                {
                    EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeEquipArmBasic();
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                switch (CharaterArmStatic.id)
                                {
                                    case 0:
                                        {
                                            PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 4);
                                            EquipArmExtraObj_0.SetActive(false);
                                            EquipArmExtraObj_1.SetActive(false);
                                            EquipArmExtraObj_2.SetActive(false);
                                            EquipArmExtraObj_3.SetActive(false);
                                            EquipArmExtraObj_4.SetActive(false);
                                            EquipArmExtraObj_5.SetActive(false);
                                            EquipArmExtraObj_None.SetActive(true);
                                            PowerId();
                                            EquipArmExtra_None.text = "無";
                                            break;
                                        }
                                    case 1:
                                        {
                                            PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 5);
                                            EquipArmExtraObj_0.SetActive(false);
                                            EquipArmExtraObj_1.SetActive(false);
                                            EquipArmExtraObj_2.SetActive(false);
                                            EquipArmExtraObj_3.SetActive(false);
                                            EquipArmExtraObj_4.SetActive(false);
                                            EquipArmExtraObj_5.SetActive(false);
                                            EquipArmExtraObj_None.SetActive(true);
                                            PowerId();
                                            EquipArmExtra_None.text = "無";
                                            break;
                                        }
                                }
                                break;
                            }
                        case 1:
                            {
                                switch (CharaterArmStatic.id)
                                {
                                    case 0:
                                        {
                                            PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 4);
                                            EquipArmExtraObj_0.SetActive(true);
                                            EquipArmExtraObj_1.SetActive(true);
                                            EquipArmExtraObj_2.SetActive(false);
                                            EquipArmExtraObj_3.SetActive(false);
                                            EquipArmExtraObj_4.SetActive(false);
                                            EquipArmExtraObj_5.SetActive(false);
                                            EquipArmExtraObj_None.SetActive(false);
                                            PowerId();
                                            EquipArmExtra_0.text = ArmExtraPower_0;
                                            EquipArmExtra_1.text = ArmExtraPower_1;
                                            break;
                                        }
                                    case 1:
                                        {
                                            PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 5);
                                            EquipArmExtraObj_0.SetActive(true);
                                            EquipArmExtraObj_1.SetActive(true);
                                            EquipArmExtraObj_2.SetActive(false);
                                            EquipArmExtraObj_3.SetActive(false);
                                            EquipArmExtraObj_4.SetActive(false);
                                            EquipArmExtraObj_5.SetActive(false);
                                            EquipArmExtraObj_None.SetActive(false);
                                            PowerId();
                                            EquipArmExtra_0.text = ArmExtraPower_0;
                                            EquipArmExtra_1.text = ArmExtraPower_1;
                                            break;
                                        }
                                }
                                break;
                            }
                        case 2:
                            {
                                switch (CharaterArmStatic.id)
                                {
                                    case 0:
                                        {
                                            PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 4);
                                            EquipArmExtraObj_0.SetActive(true);
                                            EquipArmExtraObj_1.SetActive(true);
                                            EquipArmExtraObj_2.SetActive(true);
                                            EquipArmExtraObj_3.SetActive(true);
                                            EquipArmExtraObj_4.SetActive(false);
                                            EquipArmExtraObj_5.SetActive(false);
                                            EquipArmExtraObj_None.SetActive(false);
                                            PowerId();
                                            EquipArmExtra_0.text = ArmExtraPower_0;
                                            EquipArmExtra_1.text = ArmExtraPower_1;
                                            EquipArmExtra_2.text = ArmExtraPower_2;
                                            EquipArmExtra_3.text = ArmExtraPower_3;
                                            break;
                                        }
                                    case 1:
                                        {
                                            PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 5);
                                            EquipArmExtraObj_0.SetActive(true);
                                            EquipArmExtraObj_1.SetActive(true);
                                            EquipArmExtraObj_2.SetActive(true);
                                            EquipArmExtraObj_3.SetActive(true);
                                            EquipArmExtraObj_4.SetActive(false);
                                            EquipArmExtraObj_5.SetActive(false);
                                            EquipArmExtraObj_None.SetActive(false);
                                            PowerId();
                                            EquipArmExtra_0.text = ArmExtraPower_0;
                                            EquipArmExtra_1.text = ArmExtraPower_1;
                                            EquipArmExtra_2.text = ArmExtraPower_2;
                                            EquipArmExtra_3.text = ArmExtraPower_3;
                                            break;
                                        }
                                }
                                break;
                            }
                        case 3:
                            {
                                switch (CharaterArmStatic.id)
                                {
                                    case 0:
                                        {
                                            PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 4);
                                            EquipArmExtraObj_0.SetActive(true);
                                            EquipArmExtraObj_1.SetActive(true);
                                            EquipArmExtraObj_2.SetActive(true);
                                            EquipArmExtraObj_3.SetActive(true);
                                            EquipArmExtraObj_4.SetActive(true);
                                            EquipArmExtraObj_5.SetActive(true);
                                            EquipArmExtraObj_None.SetActive(false);
                                            PowerId();
                                            EquipArmExtra_0.text = ArmExtraPower_0;
                                            EquipArmExtra_1.text = ArmExtraPower_1;
                                            EquipArmExtra_2.text = ArmExtraPower_2;
                                            EquipArmExtra_3.text = ArmExtraPower_3;
                                            EquipArmExtra_4.text = ArmExtraPower_4;
                                            EquipArmExtra_5.text = ArmExtraPower_5;
                                            break;
                                        }
                                    case 1:
                                        {
                                            PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 5);
                                            EquipArmExtraObj_0.SetActive(true);
                                            EquipArmExtraObj_1.SetActive(true);
                                            EquipArmExtraObj_2.SetActive(true);
                                            EquipArmExtraObj_3.SetActive(true);
                                            EquipArmExtraObj_4.SetActive(true);
                                            EquipArmExtraObj_5.SetActive(true);
                                            EquipArmExtraObj_None.SetActive(false);
                                            PowerId();
                                            EquipArmExtra_0.text = ArmExtraPower_0;
                                            EquipArmExtra_1.text = ArmExtraPower_1;
                                            EquipArmExtra_2.text = ArmExtraPower_2;
                                            EquipArmExtra_3.text = ArmExtraPower_3;
                                            EquipArmExtra_4.text = ArmExtraPower_4;
                                            EquipArmExtra_5.text = ArmExtraPower_5;
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                    break;
                }
            case 4:
                {
                    EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeEquipArmBasic();
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 6);
                                EquipArmExtraObj_0.SetActive(false);
                                EquipArmExtraObj_1.SetActive(false);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(true);
                                PowerId();
                                EquipArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 6);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 6);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 6);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(true);
                                EquipArmExtraObj_5.SetActive(true);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                EquipArmExtra_4.text = ArmExtraPower_4;
                                EquipArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
            case 5:
                {
                    EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeEquipArmBasic();
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 7);
                                EquipArmExtraObj_0.SetActive(false);
                                EquipArmExtraObj_1.SetActive(false);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(true);
                                PowerId();
                                EquipArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 7);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 7);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 7);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(true);
                                EquipArmExtraObj_5.SetActive(true);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                EquipArmExtra_4.text = ArmExtraPower_4;
                                EquipArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
            case 6:
                {
                    EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeEquipArmBasic();
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 8);
                                EquipArmExtraObj_0.SetActive(false);
                                EquipArmExtraObj_1.SetActive(false);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(true);
                                PowerId();
                                EquipArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 8);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 8);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 8);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(true);
                                EquipArmExtraObj_5.SetActive(true);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                EquipArmExtra_4.text = ArmExtraPower_4;
                                EquipArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
            case 7:
                {
                    EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeEquipArmBasic();
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 9);
                                EquipArmExtraObj_0.SetActive(false);
                                EquipArmExtraObj_1.SetActive(false);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(true);
                                PowerId();
                                EquipArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 9);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 9);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 9);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(true);
                                EquipArmExtraObj_5.SetActive(true);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                EquipArmExtra_4.text = ArmExtraPower_4;
                                EquipArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
        }
    }

    public void JudgeEquipArm(int EquipArmID)                                       //判斷當前玩家點選的裝備是哪個欄位，該裝備的資料又是那些
    {
        CharaterInfoClone.CheckCharaterArmList();
        for (int EquipArmId = 0; EquipArmId < CharaterInfo.CharaterArmCount; EquipArmId++)
        {
            if (CharaterInfo.CharaterArm[EquipArmId] == EquipArmID)
            {
                EquipArm.SetActive(true);
                UnEquipArm.SetActive(false);
                Btn_UnEquip.SetActive(false);
                Btn_Second.SetActive(false);
                Btn_UnEquipAlone.SetActive(true);
                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                EquipArmName.text = ArmStatic.ArmName;
                EquipArmRequsetLevel.text = "等級需求:" + ArmStatic.ArmLv;
                EquipArmRequestPower.text = "能力需求:" + "\n" + "力量:" + ArmStatic.ArmRequest_Strength + "智慧:" + ArmStatic.ArmRequest_Intelligence + "敏捷:" + ArmStatic.ArmRequest_Dexterity;
                Equip_ArmId_AlwaysFalseClone.text = CharaterArmStatic.id.ToString();      //紀錄目前顯示出裝備資訊的裝備ID，用途是用來辨認這是哪個裝備，卸下裝備，切換副手等功能需要
                switch (ArmStatic.ArmType)
                {
                    case 0:
                        {
                            EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                            switch (ArmStatic.WeaponSpeed != 0)
                            {
                                case true:
                                    {
                                        EquipArmBasicObj_0.SetActive(true);
                                        EquipArmBasicObj_1.SetActive(true);
                                        EquipArmBasicObj_2.SetActive(false);
                                        EquipArmBasic_0.text = "攻擊速度:" + ArmStatic.WeaponSpeed;
                                        EquipArmBasic_1.text = "物理攻擊:" + ArmStatic.WeaponDamageMin + "~" + ArmStatic.WeaponDamageMax;
                                        break;
                                    }
                                case false:
                                    {
                                        JudgeEquipArmBasic();
                                        break;
                                    }
                            }
                            switch (ArmStatic.ArmRank)
                            {
                                case 0:
                                    {
                                        switch (CharaterArmStatic.ArmMain)
                                        {
                                            case 0:
                                                {
                                                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                                    EquipArmExtraObj_0.SetActive(false);
                                                    EquipArmExtraObj_1.SetActive(false);
                                                    EquipArmExtraObj_2.SetActive(false);
                                                    EquipArmExtraObj_3.SetActive(false);
                                                    EquipArmExtraObj_4.SetActive(false);
                                                    EquipArmExtraObj_5.SetActive(false);
                                                    EquipArmExtraObj_None.SetActive(true);
                                                    PowerId();
                                                    EquipArmExtra_None.text = "無";
                                                    break;
                                                }
                                            case 1:
                                                {
                                                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                                    EquipArmExtraObj_0.SetActive(false);
                                                    EquipArmExtraObj_1.SetActive(false);
                                                    EquipArmExtraObj_2.SetActive(false);
                                                    EquipArmExtraObj_3.SetActive(false);
                                                    EquipArmExtraObj_4.SetActive(false);
                                                    EquipArmExtraObj_5.SetActive(false);
                                                    EquipArmExtraObj_None.SetActive(true);
                                                    PowerId();
                                                    EquipArmExtra_None.text = "無";
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                                case 1:
                                    {
                                        switch (CharaterArmStatic.ArmMain)
                                        {
                                            case 0:
                                                {
                                                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                                    EquipArmExtraObj_0.SetActive(true);
                                                    EquipArmExtraObj_1.SetActive(true);
                                                    EquipArmExtraObj_2.SetActive(false);
                                                    EquipArmExtraObj_3.SetActive(false);
                                                    EquipArmExtraObj_4.SetActive(false);
                                                    EquipArmExtraObj_5.SetActive(false);
                                                    EquipArmExtraObj_None.SetActive(false);
                                                    PowerId();
                                                    EquipArmExtra_0.text = ArmExtraPower_0;
                                                    EquipArmExtra_1.text = ArmExtraPower_1;
                                                    break;
                                                }
                                            case 1:
                                                {
                                                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                                    EquipArmExtraObj_0.SetActive(true);
                                                    EquipArmExtraObj_1.SetActive(true);
                                                    EquipArmExtraObj_2.SetActive(false);
                                                    EquipArmExtraObj_3.SetActive(false);
                                                    EquipArmExtraObj_4.SetActive(false);
                                                    EquipArmExtraObj_5.SetActive(false);
                                                    EquipArmExtraObj_None.SetActive(false);
                                                    PowerId();
                                                    EquipArmExtra_0.text = ArmExtraPower_0;
                                                    EquipArmExtra_1.text = ArmExtraPower_1;
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        switch (CharaterArmStatic.ArmMain)
                                        {
                                            case 0:
                                                {

                                                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                                    EquipArmExtraObj_0.SetActive(true);
                                                    EquipArmExtraObj_1.SetActive(true);
                                                    EquipArmExtraObj_2.SetActive(true);
                                                    EquipArmExtraObj_3.SetActive(true);
                                                    EquipArmExtraObj_4.SetActive(false);
                                                    EquipArmExtraObj_5.SetActive(false);
                                                    EquipArmExtraObj_None.SetActive(false);
                                                    PowerId();
                                                    EquipArmExtra_0.text = ArmExtraPower_0;
                                                    EquipArmExtra_1.text = ArmExtraPower_1;
                                                    EquipArmExtra_2.text = ArmExtraPower_2;
                                                    EquipArmExtra_3.text = ArmExtraPower_3;
                                                    break;
                                                }
                                            case 1:
                                                {
                                                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                                    EquipArmExtraObj_0.SetActive(true);
                                                    EquipArmExtraObj_1.SetActive(true);
                                                    EquipArmExtraObj_2.SetActive(true);
                                                    EquipArmExtraObj_3.SetActive(true);
                                                    EquipArmExtraObj_4.SetActive(false);
                                                    EquipArmExtraObj_5.SetActive(false);
                                                    EquipArmExtraObj_None.SetActive(false);
                                                    PowerId();
                                                    EquipArmExtra_0.text = ArmExtraPower_0;
                                                    EquipArmExtra_1.text = ArmExtraPower_1;
                                                    EquipArmExtra_2.text = ArmExtraPower_2;
                                                    EquipArmExtra_3.text = ArmExtraPower_3;
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        switch (CharaterArmStatic.ArmMain)
                                        {
                                            case 0:
                                                {
                                                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                                    EquipArmExtraObj_0.SetActive(true);
                                                    EquipArmExtraObj_1.SetActive(true);
                                                    EquipArmExtraObj_2.SetActive(true);
                                                    EquipArmExtraObj_3.SetActive(true);
                                                    EquipArmExtraObj_4.SetActive(true);
                                                    EquipArmExtraObj_5.SetActive(true);
                                                    EquipArmExtraObj_None.SetActive(false);
                                                    PowerId();
                                                    EquipArmExtra_0.text = ArmExtraPower_0;
                                                    EquipArmExtra_1.text = ArmExtraPower_1;
                                                    EquipArmExtra_2.text = ArmExtraPower_2;
                                                    EquipArmExtra_3.text = ArmExtraPower_3;
                                                    EquipArmExtra_4.text = ArmExtraPower_4;
                                                    EquipArmExtra_5.text = ArmExtraPower_5;
                                                    break;
                                                }
                                            case 1:
                                                {
                                                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                                    EquipArmExtraObj_0.SetActive(true);
                                                    EquipArmExtraObj_1.SetActive(true);
                                                    EquipArmExtraObj_2.SetActive(true);
                                                    EquipArmExtraObj_3.SetActive(true);
                                                    EquipArmExtraObj_4.SetActive(true);
                                                    EquipArmExtraObj_5.SetActive(true);
                                                    EquipArmExtraObj_None.SetActive(false);
                                                    PowerId();
                                                    EquipArmExtra_0.text = ArmExtraPower_0;
                                                    EquipArmExtra_1.text = ArmExtraPower_1;
                                                    EquipArmExtra_2.text = ArmExtraPower_2;
                                                    EquipArmExtra_3.text = ArmExtraPower_3;
                                                    EquipArmExtra_4.text = ArmExtraPower_4;
                                                    EquipArmExtra_5.text = ArmExtraPower_5;
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                            }
                            break;
                        }
                    case 1:
                        {
                            EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                            JudgeEquipArmBasic();
                            switch (ArmStatic.ArmRank)
                            {
                                case 0:
                                    {
                                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                        EquipArmExtraObj_0.SetActive(false);
                                        EquipArmExtraObj_1.SetActive(false);
                                        EquipArmExtraObj_2.SetActive(false);
                                        EquipArmExtraObj_3.SetActive(false);
                                        EquipArmExtraObj_4.SetActive(false);
                                        EquipArmExtraObj_5.SetActive(false);
                                        EquipArmExtraObj_None.SetActive(true);
                                        PowerId();
                                        EquipArmExtra_None.text = "無";
                                        break;
                                    }
                                case 1:
                                    {
                                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                        EquipArmExtraObj_0.SetActive(true);
                                        EquipArmExtraObj_1.SetActive(true);
                                        EquipArmExtraObj_2.SetActive(false);
                                        EquipArmExtraObj_3.SetActive(false);
                                        EquipArmExtraObj_4.SetActive(false);
                                        EquipArmExtraObj_5.SetActive(false);
                                        EquipArmExtraObj_None.SetActive(false);
                                        PowerId();
                                        EquipArmExtra_0.text = ArmExtraPower_0;
                                        EquipArmExtra_1.text = ArmExtraPower_1;
                                        break;
                                    }
                                case 2:
                                    {
                                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                        EquipArmExtraObj_0.SetActive(true);
                                        EquipArmExtraObj_1.SetActive(true);
                                        EquipArmExtraObj_2.SetActive(true);
                                        EquipArmExtraObj_3.SetActive(true);
                                        EquipArmExtraObj_4.SetActive(false);
                                        EquipArmExtraObj_5.SetActive(false);
                                        EquipArmExtraObj_None.SetActive(false);
                                        PowerId();
                                        EquipArmExtra_0.text = ArmExtraPower_0;
                                        EquipArmExtra_1.text = ArmExtraPower_1;
                                        EquipArmExtra_2.text = ArmExtraPower_2;
                                        EquipArmExtra_3.text = ArmExtraPower_3;
                                        break;
                                    }
                                case 3:
                                    {
                                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                        EquipArmExtraObj_0.SetActive(true);
                                        EquipArmExtraObj_1.SetActive(true);
                                        EquipArmExtraObj_2.SetActive(true);
                                        EquipArmExtraObj_3.SetActive(true);
                                        EquipArmExtraObj_4.SetActive(true);
                                        EquipArmExtraObj_5.SetActive(true);
                                        EquipArmExtraObj_None.SetActive(false);
                                        PowerId();
                                        EquipArmExtra_0.text = ArmExtraPower_0;
                                        EquipArmExtra_1.text = ArmExtraPower_1;
                                        EquipArmExtra_2.text = ArmExtraPower_2;
                                        EquipArmExtra_3.text = ArmExtraPower_3;
                                        EquipArmExtra_4.text = ArmExtraPower_4;
                                        EquipArmExtra_5.text = ArmExtraPower_5;
                                        break;
                                    }
                            }
                            break;
                        }
                    case 2:
                        {
                            EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                            JudgeEquipArmBasic();
                            switch (ArmStatic.ArmRank)
                            {
                                case 0:
                                    {
                                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                        EquipArmExtraObj_0.SetActive(false);
                                        EquipArmExtraObj_1.SetActive(false);
                                        EquipArmExtraObj_2.SetActive(false);
                                        EquipArmExtraObj_3.SetActive(false);
                                        EquipArmExtraObj_4.SetActive(false);
                                        EquipArmExtraObj_5.SetActive(false);
                                        EquipArmExtraObj_None.SetActive(true);
                                        PowerId();
                                        EquipArmExtra_None.text = "無";
                                        break;
                                    }
                                case 1:
                                    {
                                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                        EquipArmExtraObj_0.SetActive(true);
                                        EquipArmExtraObj_1.SetActive(true);
                                        EquipArmExtraObj_2.SetActive(false);
                                        EquipArmExtraObj_3.SetActive(false);
                                        EquipArmExtraObj_4.SetActive(false);
                                        EquipArmExtraObj_5.SetActive(false);
                                        EquipArmExtraObj_None.SetActive(false);
                                        PowerId();
                                        EquipArmExtra_0.text = ArmExtraPower_0;
                                        EquipArmExtra_1.text = ArmExtraPower_1;
                                        break;
                                    }
                                case 2:
                                    {
                                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                        EquipArmExtraObj_0.SetActive(true);
                                        EquipArmExtraObj_1.SetActive(true);
                                        EquipArmExtraObj_2.SetActive(true);
                                        EquipArmExtraObj_3.SetActive(true);
                                        EquipArmExtraObj_4.SetActive(false);
                                        EquipArmExtraObj_5.SetActive(false);
                                        EquipArmExtraObj_None.SetActive(false);
                                        PowerId();
                                        EquipArmExtra_0.text = ArmExtraPower_0;
                                        EquipArmExtra_1.text = ArmExtraPower_1;
                                        EquipArmExtra_2.text = ArmExtraPower_2;
                                        EquipArmExtra_3.text = ArmExtraPower_3;
                                        break;
                                    }
                                case 3:
                                    {
                                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                        EquipArmExtraObj_0.SetActive(true);
                                        EquipArmExtraObj_1.SetActive(true);
                                        EquipArmExtraObj_2.SetActive(true);
                                        EquipArmExtraObj_3.SetActive(true);
                                        EquipArmExtraObj_4.SetActive(true);
                                        EquipArmExtraObj_5.SetActive(true);
                                        EquipArmExtraObj_None.SetActive(false);
                                        PowerId();
                                        EquipArmExtra_0.text = ArmExtraPower_0;
                                        EquipArmExtra_1.text = ArmExtraPower_1;
                                        EquipArmExtra_2.text = ArmExtraPower_2;
                                        EquipArmExtra_3.text = ArmExtraPower_3;
                                        EquipArmExtra_4.text = ArmExtraPower_4;
                                        EquipArmExtra_5.text = ArmExtraPower_5;
                                        break;
                                    }
                            }
                            break;
                        }
                    case 3:
                        {
                            EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                            JudgeEquipArmBasic();
                            switch (ArmStatic.ArmRank)
                            {
                                case 0:
                                    {
                                        switch (CharaterArmStatic.ArmMain)
                                        {
                                            case 0:
                                                {
                                                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                                    EquipArmExtraObj_0.SetActive(false);
                                                    EquipArmExtraObj_1.SetActive(false);
                                                    EquipArmExtraObj_2.SetActive(false);
                                                    EquipArmExtraObj_3.SetActive(false);
                                                    EquipArmExtraObj_4.SetActive(false);
                                                    EquipArmExtraObj_5.SetActive(false);
                                                    EquipArmExtraObj_None.SetActive(true);
                                                    PowerId();
                                                    EquipArmExtra_None.text = "無";
                                                    break;
                                                }
                                            case 1:
                                                {
                                                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                                    EquipArmExtraObj_0.SetActive(false);
                                                    EquipArmExtraObj_1.SetActive(false);
                                                    EquipArmExtraObj_2.SetActive(false);
                                                    EquipArmExtraObj_3.SetActive(false);
                                                    EquipArmExtraObj_4.SetActive(false);
                                                    EquipArmExtraObj_5.SetActive(false);
                                                    EquipArmExtraObj_None.SetActive(true);
                                                    PowerId();
                                                    EquipArmExtra_None.text = "無";
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                                case 1:
                                    {
                                        switch (CharaterArmStatic.ArmMain)
                                        {
                                            case 0:
                                                {
                                                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                                    EquipArmExtraObj_0.SetActive(true);
                                                    EquipArmExtraObj_1.SetActive(true);
                                                    EquipArmExtraObj_2.SetActive(false);
                                                    EquipArmExtraObj_3.SetActive(false);
                                                    EquipArmExtraObj_4.SetActive(false);
                                                    EquipArmExtraObj_5.SetActive(false);
                                                    EquipArmExtraObj_None.SetActive(false);
                                                    PowerId();
                                                    EquipArmExtra_0.text = ArmExtraPower_0;
                                                    EquipArmExtra_1.text = ArmExtraPower_1;
                                                    break;
                                                }
                                            case 1:
                                                {
                                                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                                    EquipArmExtraObj_0.SetActive(true);
                                                    EquipArmExtraObj_1.SetActive(true);
                                                    EquipArmExtraObj_2.SetActive(false);
                                                    EquipArmExtraObj_3.SetActive(false);
                                                    EquipArmExtraObj_4.SetActive(false);
                                                    EquipArmExtraObj_5.SetActive(false);
                                                    EquipArmExtraObj_None.SetActive(false);
                                                    PowerId();
                                                    EquipArmExtra_0.text = ArmExtraPower_0;
                                                    EquipArmExtra_1.text = ArmExtraPower_1;
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        switch (CharaterArmStatic.ArmMain)
                                        {
                                            case 0:
                                                {                                               
                                                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                                    EquipArmExtraObj_0.SetActive(true);
                                                    EquipArmExtraObj_1.SetActive(true);
                                                    EquipArmExtraObj_2.SetActive(true);
                                                    EquipArmExtraObj_3.SetActive(true);
                                                    EquipArmExtraObj_4.SetActive(false);
                                                    EquipArmExtraObj_5.SetActive(false);
                                                    EquipArmExtraObj_None.SetActive(false);
                                                    PowerId();
                                                    EquipArmExtra_0.text = ArmExtraPower_0;
                                                    EquipArmExtra_1.text = ArmExtraPower_1;
                                                    EquipArmExtra_2.text = ArmExtraPower_2;
                                                    EquipArmExtra_3.text = ArmExtraPower_3;
                                                    break;
                                                }
                                            case 1:
                                                {
                                                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                                    EquipArmExtraObj_0.SetActive(true);
                                                    EquipArmExtraObj_1.SetActive(true);
                                                    EquipArmExtraObj_2.SetActive(true);
                                                    EquipArmExtraObj_3.SetActive(true);
                                                    EquipArmExtraObj_4.SetActive(false);
                                                    EquipArmExtraObj_5.SetActive(false);
                                                    EquipArmExtraObj_None.SetActive(false);
                                                    PowerId();
                                                    EquipArmExtra_0.text = ArmExtraPower_0;
                                                    EquipArmExtra_1.text = ArmExtraPower_1;
                                                    EquipArmExtra_2.text = ArmExtraPower_2;
                                                    EquipArmExtra_3.text = ArmExtraPower_3;
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        switch (CharaterArmStatic.ArmMain)
                                        {
                                            case 0:
                                                {
                                                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                                    EquipArmExtraObj_0.SetActive(true);
                                                    EquipArmExtraObj_1.SetActive(true);
                                                    EquipArmExtraObj_2.SetActive(true);
                                                    EquipArmExtraObj_3.SetActive(true);
                                                    EquipArmExtraObj_4.SetActive(true);
                                                    EquipArmExtraObj_5.SetActive(true);
                                                    EquipArmExtraObj_None.SetActive(false);
                                                    PowerId();
                                                    EquipArmExtra_0.text = ArmExtraPower_0;
                                                    EquipArmExtra_1.text = ArmExtraPower_1;
                                                    EquipArmExtra_2.text = ArmExtraPower_2;
                                                    EquipArmExtra_3.text = ArmExtraPower_3;
                                                    EquipArmExtra_4.text = ArmExtraPower_4;
                                                    EquipArmExtra_5.text = ArmExtraPower_5;
                                                    break;
                                                }
                                            case 1:
                                                {
                                                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                                    EquipArmExtraObj_0.SetActive(true);
                                                    EquipArmExtraObj_1.SetActive(true);
                                                    EquipArmExtraObj_2.SetActive(true);
                                                    EquipArmExtraObj_3.SetActive(true);
                                                    EquipArmExtraObj_4.SetActive(true);
                                                    EquipArmExtraObj_5.SetActive(true);
                                                    EquipArmExtraObj_None.SetActive(false);
                                                    PowerId();
                                                    EquipArmExtra_0.text = ArmExtraPower_0;
                                                    EquipArmExtra_1.text = ArmExtraPower_1;
                                                    EquipArmExtra_2.text = ArmExtraPower_2;
                                                    EquipArmExtra_3.text = ArmExtraPower_3;
                                                    EquipArmExtra_4.text = ArmExtraPower_4;
                                                    EquipArmExtra_5.text = ArmExtraPower_5;
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                            }
                            break;
                        }
                    case 4:
                        {
                            EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                            JudgeEquipArmBasic();
                            switch (ArmStatic.ArmRank)
                            {
                                case 0:
                                    {
                                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                        EquipArmExtraObj_0.SetActive(false);
                                        EquipArmExtraObj_1.SetActive(false);
                                        EquipArmExtraObj_2.SetActive(false);
                                        EquipArmExtraObj_3.SetActive(false);
                                        EquipArmExtraObj_4.SetActive(false);
                                        EquipArmExtraObj_5.SetActive(false);
                                        EquipArmExtraObj_None.SetActive(true);
                                        PowerId();
                                        EquipArmExtra_None.text = "無";
                                        break;
                                    }
                                case 1:
                                    {
                                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                        EquipArmExtraObj_0.SetActive(true);
                                        EquipArmExtraObj_1.SetActive(true);
                                        EquipArmExtraObj_2.SetActive(false);
                                        EquipArmExtraObj_3.SetActive(false);
                                        EquipArmExtraObj_4.SetActive(false);
                                        EquipArmExtraObj_5.SetActive(false);
                                        EquipArmExtraObj_None.SetActive(false);
                                        PowerId();
                                        EquipArmExtra_0.text = ArmExtraPower_0;
                                        EquipArmExtra_1.text = ArmExtraPower_1;
                                        break;
                                    }
                                case 2:
                                    {
                                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                        EquipArmExtraObj_0.SetActive(true);
                                        EquipArmExtraObj_1.SetActive(true);
                                        EquipArmExtraObj_2.SetActive(true);
                                        EquipArmExtraObj_3.SetActive(true);
                                        EquipArmExtraObj_4.SetActive(false);
                                        EquipArmExtraObj_5.SetActive(false);
                                        EquipArmExtraObj_None.SetActive(false);
                                        PowerId();
                                        EquipArmExtra_0.text = ArmExtraPower_0;
                                        EquipArmExtra_1.text = ArmExtraPower_1;
                                        EquipArmExtra_2.text = ArmExtraPower_2;
                                        EquipArmExtra_3.text = ArmExtraPower_3;
                                        break;
                                    }
                                case 3:
                                    {
                                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                        EquipArmExtraObj_0.SetActive(true);
                                        EquipArmExtraObj_1.SetActive(true);
                                        EquipArmExtraObj_2.SetActive(true);
                                        EquipArmExtraObj_3.SetActive(true);
                                        EquipArmExtraObj_4.SetActive(true);
                                        EquipArmExtraObj_5.SetActive(true);
                                        EquipArmExtraObj_None.SetActive(false);
                                        PowerId();
                                        EquipArmExtra_0.text = ArmExtraPower_0;
                                        EquipArmExtra_1.text = ArmExtraPower_1;
                                        EquipArmExtra_2.text = ArmExtraPower_2;
                                        EquipArmExtra_3.text = ArmExtraPower_3;
                                        EquipArmExtra_4.text = ArmExtraPower_4;
                                        EquipArmExtra_5.text = ArmExtraPower_5;
                                        break;
                                    }
                            }
                            break;
                        }
                    case 5:
                        {
                            EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                            JudgeEquipArmBasic();
                            switch (ArmStatic.ArmRank)
                            {
                                case 0:
                                    {
                                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                        EquipArmExtraObj_0.SetActive(false);
                                        EquipArmExtraObj_1.SetActive(false);
                                        EquipArmExtraObj_2.SetActive(false);
                                        EquipArmExtraObj_3.SetActive(false);
                                        EquipArmExtraObj_4.SetActive(false);
                                        EquipArmExtraObj_5.SetActive(false);
                                        EquipArmExtraObj_None.SetActive(true);
                                        PowerId();
                                        EquipArmExtra_None.text = "無";
                                        break;
                                    }
                                case 1:
                                    {
                                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                        EquipArmExtraObj_0.SetActive(true);
                                        EquipArmExtraObj_1.SetActive(true);
                                        EquipArmExtraObj_2.SetActive(false);
                                        EquipArmExtraObj_3.SetActive(false);
                                        EquipArmExtraObj_4.SetActive(false);
                                        EquipArmExtraObj_5.SetActive(false);
                                        EquipArmExtraObj_None.SetActive(false);
                                        PowerId();
                                        EquipArmExtra_0.text = ArmExtraPower_0;
                                        EquipArmExtra_1.text = ArmExtraPower_1;
                                        break;
                                    }
                                case 2:
                                    {
                                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                        EquipArmExtraObj_0.SetActive(true);
                                        EquipArmExtraObj_1.SetActive(true);
                                        EquipArmExtraObj_2.SetActive(true);
                                        EquipArmExtraObj_3.SetActive(true);
                                        EquipArmExtraObj_4.SetActive(false);
                                        EquipArmExtraObj_5.SetActive(false);
                                        EquipArmExtraObj_None.SetActive(false);
                                        PowerId();
                                        EquipArmExtra_0.text = ArmExtraPower_0;
                                        EquipArmExtra_1.text = ArmExtraPower_1;
                                        EquipArmExtra_2.text = ArmExtraPower_2;
                                        EquipArmExtra_3.text = ArmExtraPower_3;
                                        break;
                                    }
                                case 3:
                                    {
                                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                        EquipArmExtraObj_0.SetActive(true);
                                        EquipArmExtraObj_1.SetActive(true);
                                        EquipArmExtraObj_2.SetActive(true);
                                        EquipArmExtraObj_3.SetActive(true);
                                        EquipArmExtraObj_4.SetActive(true);
                                        EquipArmExtraObj_5.SetActive(true);
                                        EquipArmExtraObj_None.SetActive(false);
                                        PowerId();
                                        EquipArmExtra_0.text = ArmExtraPower_0;
                                        EquipArmExtra_1.text = ArmExtraPower_1;
                                        EquipArmExtra_2.text = ArmExtraPower_2;
                                        EquipArmExtra_3.text = ArmExtraPower_3;
                                        EquipArmExtra_4.text = ArmExtraPower_4;
                                        EquipArmExtra_5.text = ArmExtraPower_5;
                                        break;
                                    }
                            }
                            break;
                        }
                    case 6:
                        {
                            EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                            JudgeEquipArmBasic();
                            switch (ArmStatic.ArmRank)
                            {
                                case 0:
                                    {
                                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                        EquipArmExtraObj_0.SetActive(false);
                                        EquipArmExtraObj_1.SetActive(false);
                                        EquipArmExtraObj_2.SetActive(false);
                                        EquipArmExtraObj_3.SetActive(false);
                                        EquipArmExtraObj_4.SetActive(false);
                                        EquipArmExtraObj_5.SetActive(false);
                                        EquipArmExtraObj_None.SetActive(true);
                                        PowerId();
                                        EquipArmExtra_None.text = "無";
                                        break;
                                    }
                                case 1:
                                    {
                                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                        EquipArmExtraObj_0.SetActive(true);
                                        EquipArmExtraObj_1.SetActive(true);
                                        EquipArmExtraObj_2.SetActive(false);
                                        EquipArmExtraObj_3.SetActive(false);
                                        EquipArmExtraObj_4.SetActive(false);
                                        EquipArmExtraObj_5.SetActive(false);
                                        EquipArmExtraObj_None.SetActive(false);
                                        PowerId();
                                        EquipArmExtra_0.text = ArmExtraPower_0;
                                        EquipArmExtra_1.text = ArmExtraPower_1;
                                        break;
                                    }
                                case 2:
                                    {
                                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                        EquipArmExtraObj_0.SetActive(true);
                                        EquipArmExtraObj_1.SetActive(true);
                                        EquipArmExtraObj_2.SetActive(true);
                                        EquipArmExtraObj_3.SetActive(true);
                                        EquipArmExtraObj_4.SetActive(false);
                                        EquipArmExtraObj_5.SetActive(false);
                                        EquipArmExtraObj_None.SetActive(false);
                                        PowerId();
                                        EquipArmExtra_0.text = ArmExtraPower_0;
                                        EquipArmExtra_1.text = ArmExtraPower_1;
                                        EquipArmExtra_2.text = ArmExtraPower_2;
                                        EquipArmExtra_3.text = ArmExtraPower_3;
                                        break;
                                    }
                                case 3:
                                    {
                                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                        EquipArmExtraObj_0.SetActive(true);
                                        EquipArmExtraObj_1.SetActive(true);
                                        EquipArmExtraObj_2.SetActive(true);
                                        EquipArmExtraObj_3.SetActive(true);
                                        EquipArmExtraObj_4.SetActive(true);
                                        EquipArmExtraObj_5.SetActive(true);
                                        EquipArmExtraObj_None.SetActive(false);
                                        PowerId();
                                        EquipArmExtra_0.text = ArmExtraPower_0;
                                        EquipArmExtra_1.text = ArmExtraPower_1;
                                        EquipArmExtra_2.text = ArmExtraPower_2;
                                        EquipArmExtra_3.text = ArmExtraPower_3;
                                        EquipArmExtra_4.text = ArmExtraPower_4;
                                        EquipArmExtra_5.text = ArmExtraPower_5;
                                        break;
                                    }
                            }
                            break;
                        }
                    case 7:
                        {
                            EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                            JudgeEquipArmBasic();
                            switch (ArmStatic.ArmRank)
                            {
                                case 0:
                                    {
                                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                        EquipArmExtraObj_0.SetActive(false);
                                        EquipArmExtraObj_1.SetActive(false);
                                        EquipArmExtraObj_2.SetActive(false);
                                        EquipArmExtraObj_3.SetActive(false);
                                        EquipArmExtraObj_4.SetActive(false);
                                        EquipArmExtraObj_5.SetActive(false);
                                        EquipArmExtraObj_None.SetActive(true);
                                        PowerId();
                                        EquipArmExtra_None.text = "無";
                                        break;
                                    }
                                case 1:
                                    {
                                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                        EquipArmExtraObj_0.SetActive(true);
                                        EquipArmExtraObj_1.SetActive(true);
                                        EquipArmExtraObj_2.SetActive(false);
                                        EquipArmExtraObj_3.SetActive(false);
                                        EquipArmExtraObj_4.SetActive(false);
                                        EquipArmExtraObj_5.SetActive(false);
                                        EquipArmExtraObj_None.SetActive(false);
                                        PowerId();
                                        EquipArmExtra_0.text = ArmExtraPower_0;
                                        EquipArmExtra_1.text = ArmExtraPower_1;
                                        break;
                                    }
                                case 2:
                                    {
                                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                        EquipArmExtraObj_0.SetActive(true);
                                        EquipArmExtraObj_1.SetActive(true);
                                        EquipArmExtraObj_2.SetActive(true);
                                        EquipArmExtraObj_3.SetActive(true);
                                        EquipArmExtraObj_4.SetActive(false);
                                        EquipArmExtraObj_5.SetActive(false);
                                        EquipArmExtraObj_None.SetActive(false);
                                        PowerId();
                                        EquipArmExtra_0.text = ArmExtraPower_0;
                                        EquipArmExtra_1.text = ArmExtraPower_1;
                                        EquipArmExtra_2.text = ArmExtraPower_2;
                                        EquipArmExtra_3.text = ArmExtraPower_3;
                                        break;
                                    }
                                case 3:
                                    {
                                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmID);
                                        EquipArmExtraObj_0.SetActive(true);
                                        EquipArmExtraObj_1.SetActive(true);
                                        EquipArmExtraObj_2.SetActive(true);
                                        EquipArmExtraObj_3.SetActive(true);
                                        EquipArmExtraObj_4.SetActive(true);
                                        EquipArmExtraObj_5.SetActive(true);
                                        EquipArmExtraObj_None.SetActive(false);
                                        PowerId();
                                        EquipArmExtra_0.text = ArmExtraPower_0;
                                        EquipArmExtra_1.text = ArmExtraPower_1;
                                        EquipArmExtra_2.text = ArmExtraPower_2;
                                        EquipArmExtra_3.text = ArmExtraPower_3;
                                        EquipArmExtra_4.text = ArmExtraPower_4;
                                        EquipArmExtra_5.text = ArmExtraPower_5;
                                        break;
                                    }
                            }
                            break;
                        }
                }
                if (CharaterInfo.CharaterArm[EquipArmId] != EquipArmID)
                {

                }
            }
        }
    }

    public void ArmEquipChangeAfterShowEquip(int EquipArmId)                        //將裝備穿上後要顯示該裝備的內容
    {
        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
        PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
        EquipArmName.text = ArmStatic.ArmName;
        EquipArmRequsetLevel.text = "等級需求:" + ArmStatic.ArmLv;
        EquipArmRequestPower.text = "能力需求:" + "\n" + "力量:" + ArmStatic.ArmRequest_Strength + "智慧:" + ArmStatic.ArmRequest_Intelligence + "敏捷:" + ArmStatic.ArmRequest_Dexterity;
        Equip_ArmId_AlwaysFalseClone.text = EquipArmId.ToString();      //紀錄目前顯示出裝備資訊的裝備ID，用途是用來辨認這是哪個裝備，卸下裝備，切換副手等功能需要
        switch (ArmStatic.ArmType)
        {
            case 0:
                {
                    EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    switch (ArmStatic.WeaponSpeed != 0)
                    {
                        case true:
                            {
                                EquipArmBasicObj_0.SetActive(true);
                                EquipArmBasicObj_1.SetActive(true);
                                EquipArmBasicObj_2.SetActive(false);
                                EquipArmBasic_0.text = "攻擊速度:" + ArmStatic.WeaponSpeed;
                                EquipArmBasic_1.text = "物理攻擊:" + ArmStatic.WeaponDamageMin + "~" + ArmStatic.WeaponDamageMax;
                                break;
                            }
                        case false:
                            {
                                JudgeEquipArmBasic();
                                break;
                            }
                    }

                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                switch (CharaterArmStatic.ArmMain)
                                {
                                    case 0:
                                        {
                                            PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                            EquipArmExtraObj_0.SetActive(false);
                                            EquipArmExtraObj_1.SetActive(false);
                                            EquipArmExtraObj_2.SetActive(false);
                                            EquipArmExtraObj_3.SetActive(false);
                                            EquipArmExtraObj_4.SetActive(false);
                                            EquipArmExtraObj_5.SetActive(false);
                                            EquipArmExtraObj_None.SetActive(true);
                                            PowerId();
                                            EquipArmExtra_None.text = "無";
                                            break;
                                        }
                                    case 1:
                                        {
                                            PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                            EquipArmExtraObj_0.SetActive(false);
                                            EquipArmExtraObj_1.SetActive(false);
                                            EquipArmExtraObj_2.SetActive(false);
                                            EquipArmExtraObj_3.SetActive(false);
                                            EquipArmExtraObj_4.SetActive(false);
                                            EquipArmExtraObj_5.SetActive(false);
                                            EquipArmExtraObj_None.SetActive(true);
                                            PowerId();
                                            EquipArmExtra_None.text = "無";
                                            break;
                                        }
                                }
                                break;
                            }
                        case 1:
                            {
                                switch (CharaterArmStatic.ArmMain)
                                {
                                    case 0:
                                        {
                                            PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                            EquipArmExtraObj_0.SetActive(true);
                                            EquipArmExtraObj_1.SetActive(true);
                                            EquipArmExtraObj_2.SetActive(false);
                                            EquipArmExtraObj_3.SetActive(false);
                                            EquipArmExtraObj_4.SetActive(false);
                                            EquipArmExtraObj_5.SetActive(false);
                                            EquipArmExtraObj_None.SetActive(false);
                                            PowerId();
                                            EquipArmExtra_0.text = ArmExtraPower_0;
                                            EquipArmExtra_1.text = ArmExtraPower_1;
                                            break;
                                        }
                                    case 1:
                                        {
                                            PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                            EquipArmExtraObj_0.SetActive(true);
                                            EquipArmExtraObj_1.SetActive(true);
                                            EquipArmExtraObj_2.SetActive(false);
                                            EquipArmExtraObj_3.SetActive(false);
                                            EquipArmExtraObj_4.SetActive(false);
                                            EquipArmExtraObj_5.SetActive(false);
                                            EquipArmExtraObj_None.SetActive(false);
                                            PowerId();
                                            EquipArmExtra_0.text = ArmExtraPower_0;
                                            EquipArmExtra_1.text = ArmExtraPower_1;
                                            break;
                                        }
                                }
                                break;
                            }
                        case 2:
                            {
                                switch (CharaterArmStatic.ArmMain)
                                {
                                    case 0:
                                        {

                                            PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                            EquipArmExtraObj_0.SetActive(true);
                                            EquipArmExtraObj_1.SetActive(true);
                                            EquipArmExtraObj_2.SetActive(true);
                                            EquipArmExtraObj_3.SetActive(true);
                                            EquipArmExtraObj_4.SetActive(false);
                                            EquipArmExtraObj_5.SetActive(false);
                                            EquipArmExtraObj_None.SetActive(false);
                                            PowerId();
                                            EquipArmExtra_0.text = ArmExtraPower_0;
                                            EquipArmExtra_1.text = ArmExtraPower_1;
                                            EquipArmExtra_2.text = ArmExtraPower_2;
                                            EquipArmExtra_3.text = ArmExtraPower_3;
                                            break;
                                        }
                                    case 1:
                                        {
                                            PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                            EquipArmExtraObj_0.SetActive(true);
                                            EquipArmExtraObj_1.SetActive(true);
                                            EquipArmExtraObj_2.SetActive(true);
                                            EquipArmExtraObj_3.SetActive(true);
                                            EquipArmExtraObj_4.SetActive(false);
                                            EquipArmExtraObj_5.SetActive(false);
                                            EquipArmExtraObj_None.SetActive(false);
                                            PowerId();
                                            EquipArmExtra_0.text = ArmExtraPower_0;
                                            EquipArmExtra_1.text = ArmExtraPower_1;
                                            EquipArmExtra_2.text = ArmExtraPower_2;
                                            EquipArmExtra_3.text = ArmExtraPower_3;
                                            break;
                                        }
                                }
                                break;
                            }
                        case 3:
                            {
                                switch (CharaterArmStatic.ArmMain)
                                {
                                    case 0:
                                        {
                                            PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                            EquipArmExtraObj_0.SetActive(true);
                                            EquipArmExtraObj_1.SetActive(true);
                                            EquipArmExtraObj_2.SetActive(true);
                                            EquipArmExtraObj_3.SetActive(true);
                                            EquipArmExtraObj_4.SetActive(true);
                                            EquipArmExtraObj_5.SetActive(true);
                                            EquipArmExtraObj_None.SetActive(false);
                                            PowerId();
                                            EquipArmExtra_0.text = ArmExtraPower_0;
                                            EquipArmExtra_1.text = ArmExtraPower_1;
                                            EquipArmExtra_2.text = ArmExtraPower_2;
                                            EquipArmExtra_3.text = ArmExtraPower_3;
                                            EquipArmExtra_4.text = ArmExtraPower_4;
                                            EquipArmExtra_5.text = ArmExtraPower_5;
                                            break;
                                        }
                                    case 1:
                                        {
                                            PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                            EquipArmExtraObj_0.SetActive(true);
                                            EquipArmExtraObj_1.SetActive(true);
                                            EquipArmExtraObj_2.SetActive(true);
                                            EquipArmExtraObj_3.SetActive(true);
                                            EquipArmExtraObj_4.SetActive(true);
                                            EquipArmExtraObj_5.SetActive(true);
                                            EquipArmExtraObj_None.SetActive(false);
                                            PowerId();
                                            EquipArmExtra_0.text = ArmExtraPower_0;
                                            EquipArmExtra_1.text = ArmExtraPower_1;
                                            EquipArmExtra_2.text = ArmExtraPower_2;
                                            EquipArmExtra_3.text = ArmExtraPower_3;
                                            EquipArmExtra_4.text = ArmExtraPower_4;
                                            EquipArmExtra_5.text = ArmExtraPower_5;
                                            break;
                                        }
                                }
                                break;
                            }
					}
                    break;
                }
            case 1:
                {
                    EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeEquipArmBasic();
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                EquipArmExtraObj_0.SetActive(false);
                                EquipArmExtraObj_1.SetActive(false);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(true);
                                PowerId();
                                EquipArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(true);
                                EquipArmExtraObj_5.SetActive(true);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                EquipArmExtra_4.text = ArmExtraPower_4;
                                EquipArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
            case 2:
                {
                    EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeEquipArmBasic();
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                EquipArmExtraObj_0.SetActive(false);
                                EquipArmExtraObj_1.SetActive(false);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(true);
                                PowerId();
                                EquipArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(true);
                                EquipArmExtraObj_5.SetActive(true);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                EquipArmExtra_4.text = ArmExtraPower_4;
                                EquipArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
            case 3:
                {
                    EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeEquipArmBasic();
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                EquipArmExtraObj_0.SetActive(false);
                                EquipArmExtraObj_1.SetActive(false);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(true);
                                PowerId();
                                EquipArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(true);
                                EquipArmExtraObj_5.SetActive(true);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                EquipArmExtra_4.text = ArmExtraPower_4;
                                EquipArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
            case 4:
                {
                    EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeEquipArmBasic();
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                EquipArmExtraObj_0.SetActive(false);
                                EquipArmExtraObj_1.SetActive(false);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(true);
                                PowerId();
                                EquipArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(true);
                                EquipArmExtraObj_5.SetActive(true);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                EquipArmExtra_4.text = ArmExtraPower_4;
                                EquipArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
            case 5:
                {
                    EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeEquipArmBasic();
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                EquipArmExtraObj_0.SetActive(false);
                                EquipArmExtraObj_1.SetActive(false);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(true);
                                PowerId();
                                EquipArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(true);
                                EquipArmExtraObj_5.SetActive(true);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                EquipArmExtra_4.text = ArmExtraPower_4;
                                EquipArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
            case 6:
                {
                    EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeEquipArmBasic();
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                EquipArmExtraObj_0.SetActive(false);
                                EquipArmExtraObj_1.SetActive(false);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(true);
                                PowerId();
                                EquipArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(true);
                                EquipArmExtraObj_5.SetActive(true);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                EquipArmExtra_4.text = ArmExtraPower_4;
                                EquipArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
            case 7:
                {
                    EquipArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeEquipArmBasic();
                    switch (ArmStatic.ArmRank)
                    {
                        case 0:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                EquipArmExtraObj_0.SetActive(false);
                                EquipArmExtraObj_1.SetActive(false);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(true);
                                PowerId();
                                EquipArmExtra_None.text = "無";
                                break;
                            }
                        case 1:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(false);
                                EquipArmExtraObj_3.SetActive(false);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                break;
                            }
                        case 2:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(false);
                                EquipArmExtraObj_5.SetActive(false);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                break;
                            }
                        case 3:
                            {
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmId);
                                EquipArmExtraObj_0.SetActive(true);
                                EquipArmExtraObj_1.SetActive(true);
                                EquipArmExtraObj_2.SetActive(true);
                                EquipArmExtraObj_3.SetActive(true);
                                EquipArmExtraObj_4.SetActive(true);
                                EquipArmExtraObj_5.SetActive(true);
                                EquipArmExtraObj_None.SetActive(false);
                                PowerId();
                                EquipArmExtra_0.text = ArmExtraPower_0;
                                EquipArmExtra_1.text = ArmExtraPower_1;
                                EquipArmExtra_2.text = ArmExtraPower_2;
                                EquipArmExtra_3.text = ArmExtraPower_3;
                                EquipArmExtra_4.text = ArmExtraPower_4;
                                EquipArmExtra_5.text = ArmExtraPower_5;
                                break;
                            }
                    }
                    break;
                }
        }
    }

    public void ArmEquipChangeAfterShowArm(int ArmId)                               //如果當前欄位上已經有裝備，則在裝上新裝備做替換時，將原本裝備欄位上卸下的裝備內容顯示在一般裝備的地方(就是顯示一般沒有裝上裝備的地方)
    {
        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, ArmId);
        PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
        ArmName.text = ArmStatic.ArmName;
        ArmRequsetLevel.text = "等級需求:" + ArmStatic.ArmLv;
        ArmRequestPower.text = "能力需求:" + "\n" + "力量:" + ArmStatic.ArmRequest_Strength + "智慧:" + ArmStatic.ArmRequest_Intelligence + "敏捷:" + ArmStatic.ArmRequest_Dexterity;
        ArmId_AlwaysFalseClone.text = CharaterArmStatic.id.ToString();
        switch (ArmStatic.ArmType)
        {
            case 0:
                {
                    ArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    switch (ArmStatic.WeaponSpeed != 0)
                    {
                        case true:
                            {
                                ArmBasicObj_0.SetActive(true);
                                ArmBasicObj_1.SetActive(true);
                                ArmBasicObj_2.SetActive(false);
                                ArmBasic_0.text = "攻擊速度:" + ArmStatic.WeaponSpeed;
                                ArmBasic_1.text = "物理攻擊:" + ArmStatic.WeaponDamageMin + "~" + ArmStatic.WeaponDamageMax;
                                break;
                            }
                        case false:
                            {
                                JudgeArmBasic();
                                break;
                            }
                    }
                    break;
                }
            case 1:
                {
                    ArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeArmBasic();
                    break;
                }
            case 2:
                {
                    ArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeArmBasic();
                    break;
                }
            case 3:
                {
                    ArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeArmBasic();
                    break;
                }
            case 4:
                {
                    ArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeArmBasic();
                    break;
                }
            case 5:
                {
                    ArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeArmBasic();
                    break;
                }
            case 6:
                {
                    ArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeArmBasic();
                    break;
                }
            case 7:
                {
                    ArmIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                    JudgeArmBasic();
                    break;
                }
        }
    }

    public void UnEquipArmChangeForEquip(int ChangeArmId)                           //卸下裝備，給裝備功能使用
    {
        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, ChangeArmId);
        CharaterInfoClone.CheckCharaterArmList();
        CharaterInfoClone.ChangArmNum(ChangeArmId);
        CharaterInfoClone.CheckCharaterArmList();

        for (int arrayNum = 0; arrayNum < CharaterInfo.CharaterArmCount - 1; arrayNum++)
        {
            if (CharaterInfo.CharaterArm[CharaterInfo.CharaterArmCount - 1] < CharaterInfo.CharaterArm[CharaterInfo.CharaterArmCount - 2])
            {
                int OldNum = CharaterInfo.CharaterArm[CharaterInfo.CharaterArmCount - 2];
                CharaterInfo.CharaterArm[CharaterInfo.CharaterArmCount - 2] = CharaterInfo.CharaterArm[CharaterInfo.CharaterArmCount - 1];
                CharaterInfo.CharaterArm[CharaterInfo.CharaterArmCount - 1] = OldNum;
            }
            if (CharaterInfo.CharaterArm[arrayNum + 1] < CharaterInfo.CharaterArm[arrayNum])
            {
                int OldNum = CharaterInfo.CharaterArm[arrayNum];
                CharaterInfo.CharaterArm[arrayNum] = CharaterInfo.CharaterArm[arrayNum + 1];
                CharaterInfo.CharaterArm[arrayNum + 1] = OldNum;
            }
        }

        int NewArmId = CharaterInfo.CharaterArm[CharaterInfo.CharaterArmCount - 1];

        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, NewArmId);

        CharaterInfoClone.ChangeArmListNew(ChangeArmId, NewArmId);
        CharaterInfoClone.InputEquipmentArm();
        EquipArm.SetActive(false);
        ArmNum = CharaterArmStatic.id;
    }

    public void ArmChangeEquipNum(int ArmId, int WantToChangeArmId)                 //當裝備上不同裝備後，裝備ID也會跟著變更
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

        foreach (CharaterArm Data in FileJson.CharaterArm)
        {
            if (Data.id == ArmId)
            {
                Data.id = WantToChangeArmId;
                Data.ArmEquip = true;
            }
            for(int IdNum = Data.id; IdNum < CharaterInfo.CharaterArmCount; IdNum++)
            {
                if(IdNum > 9 && Data.id > ArmId)
                {
                    int NewDataId, OldDataId;
                    OldDataId = Data.id;
                    Data.id = Data.id - 1;
                    NewDataId = Data.id;
                    CharaterInfoClone.ChangeArmListNew(OldDataId, NewDataId);
                }
            }
        }
        DataRead = JsonUtility.ToJson(FileJson);
        File.WriteAllText(CharaterArmFilePath, DataRead);
    }

    public class JsonArm<T>                                                         //角色裝備表所使用的List，來協助unity可以讀取陣列(Array)裡的資料
    {
        public List<T> CharaterArm;
    }

    public void UnEquipArmCharaterPropertyChanger()                                 //角色卸下裝備後的數值修改
    {
        PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
        switch (CharaterArmStatic.id)
        {           
            case 0:
                {
                    switch (ArmStatic.WeaponDamageMin == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterPhysicalDamgeMin = CharaterPropertyStatic.CharaterPhysicalDamgeMin - ArmStatic.WeaponDamageMin;
                                break;
                            }
                    }
                    switch (ArmStatic.WeaponDamageMax == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterPhysicalDamgeMax = CharaterPropertyStatic.CharaterPhysicalDamgeMax - ArmStatic.WeaponDamageMax;
                                break;
                            }
                    }
                    //-----檢查副手武器有沒有被裝備，並計算攻擊速度的部分
                    float mainweaponspeed = ArmStatic.WeaponSpeed;
                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 1);
                    PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                    float secondweaponspeed = ArmStatic.WeaponSpeed;
                    bool secondweaponequip = CharaterArmStatic.ArmEquip;
                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 0);
                    PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                    switch (secondweaponequip)
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
                    switch (ArmStatic.WeaponDamageMin == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterPhysicalDamgeMin = CharaterPropertyStatic.CharaterPhysicalDamgeMin - ArmStatic.WeaponDamageMin;
                                break;
                            }
                    }
                    switch (ArmStatic.WeaponDamageMax == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterPhysicalDamgeMax = CharaterPropertyStatic.CharaterPhysicalDamgeMax - ArmStatic.WeaponDamageMax;
                                break;
                            }
                    }
                    //-----檢查主手武器有沒有被裝備，並計算攻擊速度的部分
                    float secondweaponspeed = ArmStatic.WeaponSpeed;
                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 0);
                    PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                    float mainweaponspeed = ArmStatic.WeaponSpeed;
                    bool mainweaponequip = CharaterArmStatic.ArmEquip;
                    PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, 1);
                    PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                    switch (mainweaponequip)
                    {
                        case true:
                            {
                                switch (mainweaponspeed > secondweaponspeed)
                                {
                                    case true:
                                        {
                                            CharaterPropertyStatic.CharaterAttackSpeed = mainweaponspeed;
                                            break;
                                        }
                                    case false:
                                        {
                                            CharaterPropertyStatic.CharaterAttackSpeed = secondweaponspeed;
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
                    switch (ArmStatic.ArmArmor == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterPhysicalResist = CharaterPropertyStatic.CharaterPhysicalResist - ArmStatic.ArmArmor;
                                break;
                            }
                    }
                    CharaterPropertyStatic.CharaterPhysicalResistRate = (CharaterPropertyStatic.CharaterPhysicalResist / CharaterPropertyStatic.CharaterPhysicalResistMax) * 100;
                    switch (ArmStatic.ArmMagicShield == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterMagicShield = CharaterPropertyStatic.CharaterMagicShield - ArmStatic.ArmMagicShield;
                                CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                break;
                            }
                    }
                    switch (ArmStatic.ArmDodge == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterDodge = CharaterPropertyStatic.CharaterDodge - ArmStatic.ArmDodge;
                                break;
                            }
                    }
                    CharaterPropertyStatic.CharaterDodgeRate = (CharaterPropertyStatic.CharaterDodge / CharaterPropertyStatic.CharaterDodgeMax) * 100;
                    PowerSwitchIdNew();
                    break;
                }
            case 3:
                {
                    switch (ArmStatic.ArmArmor == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterPhysicalResist = CharaterPropertyStatic.CharaterPhysicalResist - ArmStatic.ArmArmor;
                                break;
                            }
                    }
                    CharaterPropertyStatic.CharaterPhysicalResistRate = (CharaterPropertyStatic.CharaterPhysicalResist / CharaterPropertyStatic.CharaterPhysicalResistMax) * 100;
                    switch (ArmStatic.ArmMagicShield == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterMagicShield = CharaterPropertyStatic.CharaterMagicShield - ArmStatic.ArmMagicShield;
                                CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                break;
                            }
                    }
                    switch (ArmStatic.ArmDodge == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterDodge = CharaterPropertyStatic.CharaterDodge - ArmStatic.ArmDodge;
                                break;
                            }
                    }
                    CharaterPropertyStatic.CharaterDodgeRate = (CharaterPropertyStatic.CharaterDodge / CharaterPropertyStatic.CharaterDodgeMax) * 100;
                    PowerSwitchIdNew();
                    break;
                }
            case 4:
                {
                    switch (ArmStatic.ArmArmor == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterPhysicalResist = CharaterPropertyStatic.CharaterPhysicalResist - ArmStatic.ArmArmor;
                                break;
                            }
                    }
                    CharaterPropertyStatic.CharaterPhysicalResistRate = (CharaterPropertyStatic.CharaterPhysicalResist / CharaterPropertyStatic.CharaterPhysicalResistMax) * 100;
                    switch (ArmStatic.ArmMagicShield == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterMagicShield = CharaterPropertyStatic.CharaterMagicShield - ArmStatic.ArmMagicShield;
                                CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                break;
                            }
                    }
                    switch (ArmStatic.ArmDodge == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterDodge = CharaterPropertyStatic.CharaterDodge - ArmStatic.ArmDodge;
                                break;
                            }
                    }
                    CharaterPropertyStatic.CharaterDodgeRate = (CharaterPropertyStatic.CharaterDodge / CharaterPropertyStatic.CharaterDodgeMax) * 100;
                    PowerSwitchIdNew();
                    break;
                }
            case 5:
                {
                    switch (ArmStatic.ArmArmor == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterPhysicalResist = CharaterPropertyStatic.CharaterPhysicalResist - ArmStatic.ArmArmor;
                                break;
                            }
                    }
                    CharaterPropertyStatic.CharaterPhysicalResistRate = (CharaterPropertyStatic.CharaterPhysicalResist / CharaterPropertyStatic.CharaterPhysicalResistMax) * 100;
                    switch (ArmStatic.ArmMagicShield == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterMagicShield = CharaterPropertyStatic.CharaterMagicShield - ArmStatic.ArmMagicShield;
                                CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                break;
                            }
                    }
                    switch (ArmStatic.ArmDodge == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterDodge = CharaterPropertyStatic.CharaterDodge - ArmStatic.ArmDodge;
                                break;
                            }
                    }
                    CharaterPropertyStatic.CharaterDodgeRate = (CharaterPropertyStatic.CharaterDodge / CharaterPropertyStatic.CharaterDodgeMax) * 100;
                    PowerSwitchIdNew();
                    break;
                }
            case 6:
                {
                    switch (ArmStatic.ArmArmor == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterPhysicalResist = CharaterPropertyStatic.CharaterPhysicalResist - ArmStatic.ArmArmor;
                                break;
                            }
                    }
                    CharaterPropertyStatic.CharaterPhysicalResistRate = (CharaterPropertyStatic.CharaterPhysicalResist / CharaterPropertyStatic.CharaterPhysicalResistMax) * 100;
                    switch (ArmStatic.ArmMagicShield == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterMagicShield = CharaterPropertyStatic.CharaterMagicShield - ArmStatic.ArmMagicShield;
                                CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                break;
                            }
                    }
                    switch (ArmStatic.ArmDodge == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterDodge = CharaterPropertyStatic.CharaterDodge - ArmStatic.ArmDodge;
                                break;
                            }
                    }
                    CharaterPropertyStatic.CharaterDodgeRate = (CharaterPropertyStatic.CharaterDodge / CharaterPropertyStatic.CharaterDodgeMax) * 100;
                    PowerSwitchIdNew();
                    break;
                }
            case 7:
                {
                    switch (ArmStatic.ArmArmor == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterPhysicalResist = CharaterPropertyStatic.CharaterPhysicalResist - ArmStatic.ArmArmor;
                                break;
                            }
                    }
                    CharaterPropertyStatic.CharaterPhysicalResistRate = (CharaterPropertyStatic.CharaterPhysicalResist / CharaterPropertyStatic.CharaterPhysicalResistMax) * 100;
                    switch (ArmStatic.ArmMagicShield == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterMagicShield = CharaterPropertyStatic.CharaterMagicShield - ArmStatic.ArmMagicShield;
                                CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                break;
                            }
                    }
                    switch (ArmStatic.ArmDodge == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterDodge = CharaterPropertyStatic.CharaterDodge - ArmStatic.ArmDodge;
                                break;
                            }
                    }
                    CharaterPropertyStatic.CharaterDodgeRate = (CharaterPropertyStatic.CharaterDodge / CharaterPropertyStatic.CharaterDodgeMax) * 100;
                    PowerSwitchIdNew();
                    break;
                }
            case 8:
                {
                    switch (ArmStatic.ArmArmor == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterPhysicalResist = CharaterPropertyStatic.CharaterPhysicalResist - ArmStatic.ArmArmor;
                                break;
                            }
                    }
                    CharaterPropertyStatic.CharaterPhysicalResistRate = (CharaterPropertyStatic.CharaterPhysicalResist / CharaterPropertyStatic.CharaterPhysicalResistMax) * 100;
                    switch (ArmStatic.ArmMagicShield == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterMagicShield = CharaterPropertyStatic.CharaterMagicShield - ArmStatic.ArmMagicShield;
                                CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                break;
                            }
                    }
                    switch (ArmStatic.ArmDodge == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterDodge = CharaterPropertyStatic.CharaterDodge - ArmStatic.ArmDodge;
                                break;
                            }
                    }
                    CharaterPropertyStatic.CharaterDodgeRate = (CharaterPropertyStatic.CharaterDodge / CharaterPropertyStatic.CharaterDodgeMax) * 100;
                    PowerSwitchIdNew();
                    break;
                }
            case 9:
                {
                    switch (ArmStatic.ArmArmor == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterPhysicalResist = CharaterPropertyStatic.CharaterPhysicalResist - ArmStatic.ArmArmor;
                                break;
                            }
                    }
                    CharaterPropertyStatic.CharaterPhysicalResistRate = (CharaterPropertyStatic.CharaterPhysicalResist / CharaterPropertyStatic.CharaterPhysicalResistMax) * 100;
                    switch (ArmStatic.ArmMagicShield == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterMagicShield = CharaterPropertyStatic.CharaterMagicShield - ArmStatic.ArmMagicShield;
                                CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                break;
                            }
                    }
                    switch (ArmStatic.ArmDodge == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterDodge = CharaterPropertyStatic.CharaterDodge - ArmStatic.ArmDodge;
                                break;
                            }
                    }
                    CharaterPropertyStatic.CharaterDodgeRate = (CharaterPropertyStatic.CharaterDodge / CharaterPropertyStatic.CharaterDodgeMax) * 100;
                    PowerSwitchIdNew();
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

    public void PowerListSwitchIdNew(int PowerId, float PowerMin, float PowerMax)   //將該裝備上擁有的詞綴數值加到CharaterBattleProperty裡
    {
        switch (PowerId)
        {
            case 1:
                {
                    CharaterPropertyStatic.CharaterProperty_Strength = CharaterPropertyStatic.CharaterProperty_Strength - PowerMin;
                    CharaterPropertyStatic.CharaterHp = 10 + (CharaterPropertyStatic.CharaterProperty_Strength * 10);
                    CharaterPropertyStatic.CharaterHpNow = CharaterPropertyStatic.CharaterHp;
                    CharaterPropertyStatic.CharaterPhysicalDamgeMax = 1 + (CharaterPropertyStatic.CharaterProperty_Strength * 10);
                    break;
                }
            case 2:
                {
                    CharaterPropertyStatic.CharaterProperty_Intelligence = CharaterPropertyStatic.CharaterProperty_Intelligence - PowerMin;
                    CharaterPropertyStatic.CharaterMp = 10 + (CharaterPropertyStatic.CharaterProperty_Intelligence * 10);
                    CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMp * (CharaterPropertyStatic.CharaterMpNowRate / 100);
                    CharaterPropertyStatic.CharaterMagicDamgeMin = CharaterPropertyStatic.CharaterProperty_Intelligence * 5;
                    CharaterPropertyStatic.CharaterMagicDamgeMax = CharaterPropertyStatic.CharaterProperty_Intelligence * 10;
                    break;
                }
            case 3:
                {
                    int OldDex = Convert.ToInt32(CharaterPropertyStatic.CharaterProperty_Dexterity);
                    CharaterPropertyStatic.CharaterProperty_Dexterity = CharaterPropertyStatic.CharaterProperty_Dexterity - PowerMin;
                    CharaterPropertyStatic.CharaterDodge = CharaterPropertyStatic.CharaterProperty_Dexterity + (CharaterPropertyStatic.CharaterDodge - OldDex);
                    CharaterPropertyStatic.CharaterDodgeRate = (CharaterPropertyStatic.CharaterDodge / CharaterPropertyStatic.CharaterDodgeMax) * 100;
                    CharaterPropertyStatic.CharaterDodgeRate = Mathf.Round(CharaterPropertyStatic.CharaterDodgeRate);
                    CharaterPropertyStatic.CharaterCritical = CharaterPropertyStatic.CharaterProperty_Dexterity + (CharaterPropertyStatic.CharaterCritical - OldDex);
                    CharaterPropertyStatic.CharaterCriticalRate = (CharaterPropertyStatic.CharaterCritical / CharaterPropertyStatic.CharaterCriticalMax) * 100;
                    CharaterPropertyStatic.CharaterCriticalRate = Mathf.Round(CharaterPropertyStatic.CharaterCriticalRate);
                    break;
                }
            case 4:
                {
                    CharaterPropertyStatic.CharaterHp = CharaterPropertyStatic.CharaterHp - PowerMin;
                    CharaterPropertyStatic.CharaterHpNow = CharaterPropertyStatic.CharaterHp;
                    CharaterPropertyStatic.CharaterHpNowRate = (CharaterPropertyStatic.CharaterHp / CharaterPropertyStatic.CharaterHpNow) * 100;
                    break;
                }
            case 5:
                {
                    CharaterPropertyStatic.CharaterMp = CharaterPropertyStatic.CharaterMp - PowerMin;
                    CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMp;
                    CharaterPropertyStatic.CharaterMpNowRate = (CharaterPropertyStatic.CharaterMp / CharaterPropertyStatic.CharaterMpNow) * 100;
                    break;
                }
            case 6:
                {
                    CharaterPropertyStatic.CharaterPhysicalDamgeMin = CharaterPropertyStatic.CharaterPhysicalDamgeMin - PowerMin;
                    CharaterPropertyStatic.CharaterPhysicalDamgeMax = CharaterPropertyStatic.CharaterPhysicalDamgeMax - PowerMax;
                    break;
                }
            case 7:
                {
                    CharaterPropertyStatic.CharaterMagicDamgeMin = CharaterPropertyStatic.CharaterMagicDamgeMin - PowerMin;
                    CharaterPropertyStatic.CharaterMagicDamgeMax = CharaterPropertyStatic.CharaterMagicDamgeMax - PowerMax;
                    break;
                }
            case 8:
                {
                    CharaterPropertyStatic.CharaterHpRecover = CharaterPropertyStatic.CharaterHpRecover - PowerMin;
                    break;
                }
            case 9:
                {
                    CharaterPropertyStatic.CharaterMpRecover = CharaterPropertyStatic.CharaterMpRecover - PowerMin;
                    break;
                }
            case 10:
                {
                    CharaterPropertyStatic.CharaterPhysicalResist = CharaterPropertyStatic.CharaterPhysicalResist - PowerMin;
                    break;
                }
            case 11:
                {
                    CharaterPropertyStatic.CharaterMagicShield = CharaterPropertyStatic.CharaterMagicShield - PowerMin;
                    CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                    break;
                }
            case 12:
                {
                    CharaterPropertyStatic.CharaterDodge = CharaterPropertyStatic.CharaterDodge - PowerMin;
                    CharaterPropertyStatic.CharaterDodgeRate = (CharaterPropertyStatic.CharaterDodge / CharaterPropertyStatic.CharaterDodgeMax) * 100;
                    CharaterPropertyStatic.CharaterDodgeRate = Mathf.Round(CharaterPropertyStatic.CharaterDodgeRate);
                    break;
                }
            case 13:
                {
                    CharaterPropertyStatic.CharaterCritical = CharaterPropertyStatic.CharaterCritical - PowerMin;
                    CharaterPropertyStatic.CharaterCriticalRate = (CharaterPropertyStatic.CharaterCritical / CharaterPropertyStatic.CharaterCriticalMax) * 100;
                    CharaterPropertyStatic.CharaterCriticalRate = Mathf.Round(CharaterPropertyStatic.CharaterCriticalRate);
                    break;
                }
        }
    }

    public void PlusArmInfo(int Armid)                                              //將所有裝備上的數值都加到CharaterPropertyStatic裡
    {
        switch (Armid)
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
                    PowerSwitchId();
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
                    PowerSwitchId();
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
                    PowerSwitchId();
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
                    PowerSwitchId();
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
                    PowerSwitchId();
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
                    PowerSwitchId();
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
                    PowerSwitchId();
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
                    PowerSwitchId();
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
                    PowerSwitchId();
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
                    PowerSwitchId();
                    break;
                }
        }
    }

    public void PowerListSwitchId(int PowerId, float PowerMin, float PowerMax)      //將該裝備上擁有的詞綴數值加到CharaterProperty裡
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
                                CharaterPropertyStatic.CharaterHp = 10 + (CharaterPropertyStatic.CharaterProperty_Strength * 10);
                                CharaterPropertyStatic.CharaterHpNow = CharaterPropertyStatic.CharaterHp;
                                CharaterPropertyStatic.CharaterPhysicalDamgeMax = 1 + (CharaterPropertyStatic.CharaterProperty_Strength * 10);
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterProperty_Strength = CharaterPropertyStatic.CharaterProperty_Strength + PowerMin;
                                CharaterPropertyStatic.CharaterHp = 10 + (CharaterPropertyStatic.CharaterProperty_Strength * 10);
                                CharaterPropertyStatic.CharaterHpNow = CharaterPropertyStatic.CharaterHp;
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
                                CharaterPropertyStatic.CharaterMp = 10 + (CharaterPropertyStatic.CharaterProperty_Intelligence * 10);
                                CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMp * (CharaterPropertyStatic.CharaterMpNowRate / 100);
                                CharaterPropertyStatic.CharaterMagicDamgeMin = CharaterPropertyStatic.CharaterProperty_Intelligence * 5;
                                CharaterPropertyStatic.CharaterMagicDamgeMax = CharaterPropertyStatic.CharaterProperty_Intelligence * 10;
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
                                CharaterPropertyStatic.CharaterDodge = CharaterPropertyStatic.CharaterProperty_Dexterity + (CharaterPropertyStatic.CharaterDodge - OldDex);
                                CharaterPropertyStatic.CharaterDodgeRate = (CharaterPropertyStatic.CharaterDodge / CharaterPropertyStatic.CharaterDodgeMax) * 100;
                                CharaterPropertyStatic.CharaterDodgeRate = Mathf.Round(CharaterPropertyStatic.CharaterDodgeRate);
                                CharaterPropertyStatic.CharaterCritical = CharaterPropertyStatic.CharaterProperty_Dexterity + (CharaterPropertyStatic.CharaterCritical - OldDex);
                                CharaterPropertyStatic.CharaterCriticalRate = (CharaterPropertyStatic.CharaterCritical / CharaterPropertyStatic.CharaterCriticalMax) * 100;
                                CharaterPropertyStatic.CharaterCriticalRate = Mathf.Round(CharaterPropertyStatic.CharaterCriticalRate);
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
                                CharaterPropertyStatic.CharaterHpNow = CharaterPropertyStatic.CharaterHp;
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterHp = CharaterPropertyStatic.CharaterHp + PowerMin;
                                CharaterPropertyStatic.CharaterHpNow = CharaterPropertyStatic.CharaterHp;
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
                                CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMp;
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterMp = CharaterPropertyStatic.CharaterMp + PowerMin;
                                CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMp;
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

    public void PowerSwitchId()                                                     //讀取每個裝備上每個詞綴的數值
    {
        for (int PowerId = 1; PowerId < 7; PowerId++)
        {
            switch (PowerId)
            {
                case 1:
                    {
                        int PowerNum = CharaterArmStatic.ArmPower_1;
                        PublicFunctionClone.ReadArmPower(PowerNum);
                        PowerListSwitchId(PowerNum, CharaterArmStatic.PowerMin_1, CharaterArmStatic.PowerMax_1);
                        break;
                    }
                case 2:
                    {
                        int PowerNum = CharaterArmStatic.ArmPower_2;
                        PublicFunctionClone.ReadArmPower(PowerNum);
                        PowerListSwitchId(PowerNum, CharaterArmStatic.PowerMin_2, CharaterArmStatic.PowerMax_2);
                        break;
                    }
                case 3:
                    {
                        int PowerNum = CharaterArmStatic.ArmPower_3;
                        PublicFunctionClone.ReadArmPower(PowerNum);
                        PowerListSwitchId(PowerNum, CharaterArmStatic.PowerMin_3, CharaterArmStatic.PowerMax_3);
                        break;
                    }
                case 4:
                    {
                        int PowerNum = CharaterArmStatic.ArmPower_4;
                        PublicFunctionClone.ReadArmPower(PowerNum);
                        PowerListSwitchId(PowerNum, CharaterArmStatic.PowerMin_4, CharaterArmStatic.PowerMax_4);
                        break;
                    }
                case 5:
                    {
                        int PowerNum = CharaterArmStatic.ArmPower_5;
                        PublicFunctionClone.ReadArmPower(PowerNum);
                        PowerListSwitchId(PowerNum, CharaterArmStatic.PowerMin_5, CharaterArmStatic.PowerMax_5);
                        break;
                    }
                case 6:
                    {
                        int PowerNum = CharaterArmStatic.ArmPower_6;
                        PublicFunctionClone.ReadArmPower(PowerNum);
                        PowerListSwitchId(PowerNum, CharaterArmStatic.PowerMin_6, CharaterArmStatic.PowerMax_6);
                        break;
                    }
            }
        }
    }

    public void ChangeCharaterProperty()                                            //給卸下裝備後的角色數值修改
    {
        PublicFunctionClone.CharaterPropertyStaticChange();
        string filename = "Charater_" + CharaterPropertyStatic.CharaterNumber;
        PublicFunctionClone.ReadPlatformpersistentDataPath(filename);
        string file = JsonUtility.ToJson(PublicFunction.CharaterPropertyValue);
        File.WriteAllText(PublicFunction.persistentFilePath, file);
        string fileread = File.ReadAllText(PublicFunction.persistentFilePath);
        PublicFunction.CharaterPropertyValue = JsonUtility.FromJson<CharaterProperty>(fileread);
        PublicFunctionClone.CharaterPropertyConversion();
        CharaterInfoClone.LoadCharaterProperty();
        CharaterInfoClone.IfLastPoint();
        CharaterInfoClone.ChangeCharaterProperty();
        EmptyGameObject = GameObject.Find("UI/Prefab_Control");
        MainGameControl MainGameControlClone = EmptyGameObject.GetComponent<MainGameControl>();
        MainGameControlClone.LoadCharaterProperty();
    }

    public void PowerId()                                                           //讀取裝備上每個詞綴的數值
    {
        for (int PowerId = 1; PowerId < 7; PowerId++)
        {
            switch (PowerId)
            {
                case 1:
                    {
                        int PowerNum = CharaterArmStatic.ArmPower_1;
                        PublicFunctionClone.ReadArmPower(PowerNum);
                        ShowPower(PowerNum, CharaterArmStatic.PowerMin_1, CharaterArmStatic.PowerMax_1);
                        ArmExtraPower_0 = EmptyArmExtra;
                        break;
                    }
                case 2:
                    {
                        int PowerNum = CharaterArmStatic.ArmPower_2;
                        PublicFunctionClone.ReadArmPower(PowerNum);
                        ShowPower(PowerNum, CharaterArmStatic.PowerMin_2, CharaterArmStatic.PowerMax_2);
                        ArmExtraPower_1 = EmptyArmExtra;
                        break;
                    }
                case 3:
                    {
                        int PowerNum = CharaterArmStatic.ArmPower_3;
                        PublicFunctionClone.ReadArmPower(PowerNum);
                        ShowPower(PowerNum, CharaterArmStatic.PowerMin_3, CharaterArmStatic.PowerMax_3);
                        ArmExtraPower_2 = EmptyArmExtra;
                        break;
                    }
                case 4:
                    {
                        int PowerNum = CharaterArmStatic.ArmPower_4;
                        PublicFunctionClone.ReadArmPower(PowerNum);
                        ShowPower(PowerNum, CharaterArmStatic.PowerMin_4, CharaterArmStatic.PowerMax_4);
                        ArmExtraPower_3 = EmptyArmExtra;
                        break;
                    }
                case 5:
                    {
                        int PowerNum = CharaterArmStatic.ArmPower_5;
                        PublicFunctionClone.ReadArmPower(PowerNum);
                        ShowPower(PowerNum, CharaterArmStatic.PowerMin_5, CharaterArmStatic.PowerMax_5);
                        ArmExtraPower_4 = EmptyArmExtra;
                        break;
                    }
                case 6:
                    {
                        int PowerNum = CharaterArmStatic.ArmPower_6;
                        PublicFunctionClone.ReadArmPower(PowerNum);
                        ShowPower(PowerNum, CharaterArmStatic.PowerMin_6, CharaterArmStatic.PowerMax_6);
                        ArmExtraPower_5 = EmptyArmExtra;
                        break;
                    }
            }
        }
    }

    public void ShowPower(int PowerId, float PowerMin, float PowerMax)              //將該裝備上擁有的詞綴數值顯示道裝備資料上
    {
        switch (PowerId)
        {
            case 1:
                {
                    PublicFunctionClone.ReadArmPower(1);
                    Debug.Log("該裝備額外屬性名稱:" + ArmPowerListStatic.PowerName);
                    EmptyArmExtra = ArmPowerListStatic.PowerName + ":" + PowerMin;
                    break;
                }
            case 2:
                {
                    PublicFunctionClone.ReadArmPower(2);
                    EmptyArmExtra = ArmPowerListStatic.PowerName + ":" + PowerMin;
                    break;
                }
            case 3:
                {
                    PublicFunctionClone.ReadArmPower(3);
                    EmptyArmExtra = ArmPowerListStatic.PowerName + ":" + PowerMin;
                    break;
                }
            case 4:
                {
                    PublicFunctionClone.ReadArmPower(4);
                    EmptyArmExtra = ArmPowerListStatic.PowerName + ":" + PowerMin;
                    break;
                }
            case 5:
                {
                    PublicFunctionClone.ReadArmPower(5);
                    EmptyArmExtra = ArmPowerListStatic.PowerName + ":" + PowerMin;
                    break;
                }
            case 6:
                {
                    PublicFunctionClone.ReadArmPower(6);
                    EmptyArmExtra = ArmPowerListStatic.PowerName + ":" + PowerMin + "~" + PowerMax;
                    break;
                }
            case 7:
                {
                    PublicFunctionClone.ReadArmPower(7);
                    EmptyArmExtra = ArmPowerListStatic.PowerName + ":" + PowerMin + "~" + PowerMax;
                    break;
                }
            case 8:
                {
                    PublicFunctionClone.ReadArmPower(8);
                    EmptyArmExtra = ArmPowerListStatic.PowerName + ":" + PowerMin;
                    break;
                }
            case 9:
                {
                    PublicFunctionClone.ReadArmPower(9);
                    EmptyArmExtra = ArmPowerListStatic.PowerName + ":" + PowerMin;
                    break;
                }
            case 10:
                {
                    PublicFunctionClone.ReadArmPower(10);
                    EmptyArmExtra = ArmPowerListStatic.PowerName + ":" + PowerMin;
                    break;
                }
            case 11:
                {
                    PublicFunctionClone.ReadArmPower(11);
                    EmptyArmExtra = ArmPowerListStatic.PowerName + ":" + PowerMin;
                    break;
                }
            case 12:
                {
                    PublicFunctionClone.ReadArmPower(12);
                    EmptyArmExtra = ArmPowerListStatic.PowerName + ":" + PowerMin;
                    break;
                }
            case 13:
                {
                    PublicFunctionClone.ReadArmPower(13);
                    EmptyArmExtra = ArmPowerListStatic.PowerName + ":" + PowerMin;
                    break;
                }
        }
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

    public void UnEquip()                                                           //卸下裝備
	{
        //-----確認要卸下的裝備ID
        int EquipId = Convert.ToInt32(Equip_ArmId_AlwaysFalseClone.text);
        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipId);
        PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
        //-----

        EquipArm.SetActive(false);

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

        foreach (CharaterArm Data in FileJson.CharaterArm)
		{
            if(Data.id == EquipId)
			{
                Data.ArmEquip = false;
			}
		}
        DataRead = JsonUtility.ToJson(FileJson);
        File.WriteAllText(CharaterArmFilePath, DataRead);


        CheckCharaterArmList();

        //-----因為卸下裝備導致數值變化
        UnEquipArmLessProperty(EquipId);
        ChangeCharaterProperty();
        //-----

        //-----修改裝備欄位上的ICON圖顯示
        CharaterInfoClone.CheckCharaterArmList();
        CharaterInfoClone.UnEquipInputICON();
        CharaterInfoClone.UnEquipArmList();
        CheckCharaterArmList();
        FlashArmList();
        Debug.Log("有執行到這裡嗎?");
    }

    public void FlashArmList()                                                      //刷新裝備列表裡的裝備
    {
        //-----刷新裝備列表裡的裝備
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

        for (int num = 0; num < CharaterArmCount; num++)
        {
            int numadd = num + 1;
            Debug.Log("陣列裡第" + numadd + "個裝備編號是:" + CharaterArm[num]);
        }

        Debug.Log("裝備數量:" + CharaterArmCount);

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
                        Load_EquipIconObj = EmptyGameObject.transform.GetChild(1).gameObject;
                        //Load_EquipIconObj = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/" + armname + "/Load_ArmIcon"); //因為GameObject.Fine不能抓取本來不在場景中的物件，所以無法使用
                        Load_EquipIcon = Load_EquipIconObj.GetComponent<Image>();
                        Load_EquipEquipObj = EmptyGameObject.transform.GetChild(2).gameObject;
                        //Load_EquipEquipObj = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/" + armname + "/Load_Equip");  //因為GameObject.Fine不能抓取本來不在場景中的物件，所以無法使用
                        Load_EquipIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                        CharaterInfo_ArmList ArmListScritp = EmptyGameObject.GetComponent<CharaterInfo_ArmList>();
                        ArmListScritp.ArmNum = CharaterArm[Num];
                        Debug.Log("已裝上的裝備編號確認:" + ArmListScritp.ArmNum);
                        Load_EquipEquipObj.SetActive(true);
                        break;
                    }
                case false:
                    {
                        EmptyGameObject = Instantiate(CharaterArmClone, CharaterArmListObj.transform);
                        EmptyGameObject.name = "Load_Arm_" + CharaterArm[Num] + "_NotEquip";
                        Load_NotEquipIconObj = EmptyGameObject.transform.GetChild(1).gameObject;
                        //Load_NotEquipIconObj = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/" + armname + "/Load_ArmIcon");  //因為GameObject.Fine不能抓取本來不在場景中的物件，所以無法使用
                        Load_NotEquipIcon = Load_NotEquipIconObj.GetComponent<Image>();
                        Load_NotEquipEquipObj = EmptyGameObject.transform.GetChild(2).gameObject;
                        //Load_NotEquipEquipObj = GameObject.Find("UI/Prefab_CharaterInfo(Clone)/Scroll_ArmList/Mask/Gird_ArmList/" + armname + "/Load_Equip");   //因為GameObject.Fine不能抓取本來不在場景中的物件，所以無法使用
                        Load_NotEquipIcon.sprite = CharaterArmIcon.GetSprite(ArmStatic.ArmIconName);
                        CharaterInfo_ArmList ArmListScritp = EmptyGameObject.GetComponent<CharaterInfo_ArmList>();
                        ArmListScritp.ArmNum = CharaterArm[Num];
                        Debug.Log("沒裝上的裝備編號確認:" + ArmListScritp.ArmNum);
                        Load_NotEquipEquipObj.SetActive(false);
                        break;
                    }
            }
        }
        //-----
    }

    public void Equip()                                                             //裝上裝備
	{
        int ArmIdWantChange = Convert.ToInt32(ArmId_AlwaysFalseClone.text);
        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, ArmIdWantChange);
        PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
        int ArmTypeNum = ArmStatic.ArmType;
        //-----判斷是否有相同類型的裝備已裝上
        int EquipArmNow = Convert.ToInt32(Equip_ArmId_AlwaysFalseClone.text);
        bool HaveEquipAlready = false;
        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmNow);
        PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
        switch(CharaterArmStatic.ArmEquip)
		{
            case true:
				{
                    switch (ArmStatic.ArmType == ArmTypeNum)
                    {
                        case true:
                            {
                                HaveEquipAlready = true;
                                break;
                            }
                        case false:
                            {
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

        int WeaponRingMainSecond = 100;
        //1.WeaponRingMainSecond = 0，有裝備主手武器，但沒有裝備副手武器
        //2.WeaponRingMainSecond = 1，有裝備主手武器，也有裝備副手武器，但現在選擇的是主手武器
        //3.WeaponRingMainSecond = 2，有裝備主手武器，也有裝備副手武器，但現在選擇的是副手武器
        //4.WeaponRingMainSecond = 3，有裝備主手戒指，但沒有裝備副手戒指
        //5.WeaponRingMainSecond = 4，有裝備主手戒指，也有裝備副手戒指，但現在選擇的是主手戒指
        //6.WeaponRingMainSecond = 5，有裝備主手戒指，也有裝備副手戒指，但現在選擇的是副手戒指
        //7.WeaponRingMainSecond = 6，其他裝備類型的情況

        CheckSomeTypeArm(ArmIdWantChange);   //列出也裝備上的裝備跟現在選擇的裝備是同類型(Type)的陣列

        switch(HaveEquipAlready)
		{
            case true:
				{
                    switch (ArmStatic.ArmType)
					{
                        case 0:
							{
                                break;
							}
                        case 3:
							{
                                break;
							}
                        default:
							{
                                WeaponRingMainSecond = 6;
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

        //0 = 主手武器，1 = 副手武器，2 = 主手戒指，3 = 副手戒指
        switch(HaveEquipAlready)
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
                                            WeaponRingMainSecond = 0;
                                            break;
                                        }
                                    case 1:
                                        {
                                            WeaponRingMainSecond = 1;
                                            break;
                                        }
                                }
                                break;
                            }
                        case 3:
                            {
                                switch (CharaterArmStatic.ArmMain)
                                {
                                    case 0:
                                        {
                                            WeaponRingMainSecond = 2;
                                            break;
                                        }
                                    case 1:
                                        {
                                            WeaponRingMainSecond = 3;
                                            break;
                                        }
                                }
                                break;
                            }
                        default:
							{
                                WeaponRingMainSecond = 4;     //只除了武器跟戒指之外的其他裝備類型
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
        //-----

        //-----裝上裝備
        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, ArmIdWantChange);
        PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);

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

        switch(HaveEquipAlready)
		{
            case true:
				{
                    switch(WeaponRingMainSecond)
					{
                        /*case 0:   //已有裝備是主手武器的情況下，裝上新裝備，並且將原本的裝備卸下
							{
                                MainSecondSwitch.text = "副手";
                                Btn_UnEquip.SetActive(true);
                                Btn_Second.SetActive(true);
                                Btn_UnEquipAlone.SetActive(false);
                                EquipArm.SetActive(true);
                                UnEquipArm.SetActive(false);
                                foreach (CharaterArm Data in FileJson.CharaterArm)
                                {
                                    if (Data.id == ArmIdWantChange)
                                    {
                                        Data.ArmEquip = true;
                                    }
                                    if(Data.id == EquipArmNow)
									{
                                        Data.ArmEquip = false;
                                    }
                                }
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmNow);
                                PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                                UnEquipArmLessProperty(EquipArmNow);
                                break;
							}
                        case 1:   //已有裝備是副手武器的情況下，裝上新裝備，並且將原本的裝備卸下
                            {
                                MainSecondSwitch.text = "主手";
                                Btn_UnEquip.SetActive(true);
                                Btn_Second.SetActive(true);
                                Btn_UnEquipAlone.SetActive(false);
                                EquipArm.SetActive(true);
                                UnEquipArm.SetActive(false);
                                foreach (CharaterArm Data in FileJson.CharaterArm)
                                {
                                    if (Data.id == ArmIdWantChange)
                                    {
                                        Data.ArmEquip = true;
                                        Data.ArmMain = 1;
                                    }
                                    if (Data.id == EquipArmNow)
                                    {
                                        Data.ArmEquip = false;
                                        Data.ArmMain = 0;
                                    }
                                }
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmNow);
                                PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                                UnEquipArmLessProperty(EquipArmNow);
                                break;
							}
                        case 2:
							{
                                MainSecondSwitch.text = "副手";
                                Btn_UnEquip.SetActive(true);
                                Btn_Second.SetActive(true);
                                Btn_UnEquipAlone.SetActive(false);
                                EquipArm.SetActive(true);
                                UnEquipArm.SetActive(false);
                                foreach (CharaterArm Data in FileJson.CharaterArm)
                                {
                                    if (Data.id == ArmIdWantChange)
                                    {
                                        Data.ArmEquip = true;
                                    }
                                    if (Data.id == EquipArmNow)
                                    {
                                        Data.ArmEquip = false;
                                    }
                                }
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmNow);
                                PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                                UnEquipArmLessProperty(EquipArmNow);
                                break;
							}
                        case 3:
							{
                                MainSecondSwitch.text = "主手";
                                Btn_UnEquip.SetActive(true);
                                Btn_Second.SetActive(true);
                                Btn_UnEquipAlone.SetActive(false);
                                EquipArm.SetActive(true);
                                UnEquipArm.SetActive(false);
                                foreach (CharaterArm Data in FileJson.CharaterArm)
                                {
                                    if (Data.id == ArmIdWantChange)
                                    {
                                        Data.ArmEquip = true;
                                        Data.ArmMain = 1;
                                    }
                                    if (Data.id == EquipArmNow)
                                    {
                                        Data.ArmEquip = false;
                                        Data.ArmMain = 0;
                                    }
                                }
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmNow);
                                PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                                UnEquipArmLessProperty(EquipArmNow);
                                break;                               
							}*/
                        case 4:  //已有裝備的情況下，裝上新裝備，並且將原本的裝備卸下
                            {
                                Btn_UnEquip.SetActive(false);
                                Btn_Second.SetActive(false);
                                Btn_UnEquipAlone.SetActive(true);
                                EquipArm.SetActive(true);
                                UnEquipArm.SetActive(false);
                                foreach (CharaterArm Data in FileJson.CharaterArm)
                                {
                                    if (Data.id == ArmIdWantChange)
                                    {
                                        Data.ArmEquip = true;
                                    }
                                    if (Data.id == EquipArmNow)
                                    {
                                        Data.ArmEquip = false;
                                    }
                                }
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, EquipArmNow);
                                PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                                UnEquipArmLessProperty(EquipArmNow);
                                break;
                            }
                    }
                    break;
				}
            case false:   //未有相同類型的裝備，單純裝上裝備
				{
                    Btn_UnEquip.SetActive(false);
                    Btn_Second.SetActive(false);
                    Btn_UnEquipAlone.SetActive(true);
                    EquipArm.SetActive(true);
                    UnEquipArm.SetActive(false);
                    foreach (CharaterArm Data in FileJson.CharaterArm)
                    {
                        if (Data.id == ArmIdWantChange)
                        {
                            Data.ArmEquip = true;
                        }
                    }
                    break;
				}
		}
        DataRead = JsonUtility.ToJson(FileJson);
        File.WriteAllText(CharaterArmFilePath, DataRead);
        //-----

        //-----裝上的裝備要加數值到角色上
        ArmEquipChangeAfterShowEquip(ArmIdWantChange);    //這個是顯示裝備的內容
        EquipArmPlusProperty(ArmIdWantChange);            //將裝備上的裝備數值加到角色數值上
        ChangeCharaterProperty();                         //將修改後的角色數值儲存
        //-----

        //-----修改裝備欄位上的ICON圖顯示
        CharaterInfoClone.CheckCharaterArmList();
        CharaterInfoClone.UnEquipInputICON();
        CharaterInfoClone.UnEquipArmList();
        CheckCharaterArmList();
        FlashArmList();
        //-----
    }

    public void JudgeArmTypeEquipNot(int ArmId)                                     //判斷裝備欄位上是否有同類型的裝備
	{
        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, ArmId);
        PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
        int ArmType = ArmStatic.ArmType;
        JudgeEquipArmIdOrNot = 0;
        bool JudgeEquipArmIdOrNotIsTrue = false;
        int TyptState = 101; //0 = ICON是已裝備ICON，1 = ICON是未裝備ICON且沒已裝備，2 = ICON是未裝備ICON但已有裝備

        for (int num = 0; num < CharaterArmCount; num++)
		{
            PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, CharaterArm[num]);
            PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
            if(ArmStatic.ArmType == ArmType)
			{
                if(CharaterArmStatic.ArmEquip == true)
				{
                    JudgeEquipArmIdOrNot = CharaterArm[num];
                    JudgeEquipArmIdOrNotIsTrue = true;
                }
            }
        }

        switch (JudgeEquipArmIdOrNotIsTrue)
        {
            case true:
                {
                    TyptState = 2;
                    break;
                }
            case false:
                {
                    TyptState = 1;                
                    break;
                }
        }

        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, ArmId);
        PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
        switch (CharaterArmStatic.ArmEquip)
        {
            case true:
                {
                    TyptState = 0;
                    break;
                }
            case false:
                {
                    break;
                }
        }

        switch (TyptState)
		{
            case 0:
				{
                    EquipArm.SetActive(true);
                    UnEquipArm.SetActive(false);
                    break;
				}
            case 1:
				{
                    EquipArm.SetActive(false);
                    UnEquipArm.SetActive(true);
                    break;
				}
            case 2:
				{
                    EquipArm.SetActive(true);
                    UnEquipArm.SetActive(true);
                    break;
				}
		}
    }

    public void EquipArmPlusProperty(int ArmId)                                     //將裝備上的裝備數值加到角色數值上
    {
        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, ArmId);
        PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
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
                    PowerSwitchId();
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
                    PowerSwitchId();
                    break;
				}
		}
	}

    public void UnEquipArmLessProperty(int ArmId)                                   //卸下裝備後的角色數值變化
	{
        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, ArmId);
        PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
        int ArmType = ArmStatic.ArmType;
        int AnotherArmId = 100;
        int TyptState = 101; //1 = 表示有副手武器的裝備

        for (int num = 0; num < CharaterArmCount; num++)
        {
            PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, CharaterArm[num]);
            PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
            if (ArmStatic.ArmType == ArmType)
            {
                if (CharaterArmStatic.ArmEquip == true)
                {
                    AnotherArmId = CharaterArm[num];
                    switch (ArmStatic.ArmType)
					{
                        case 0:
							{
                                if(CharaterArmStatic.ArmMain == 1)
								{
                                    TyptState = 1;
                                }
                                break;
							}
					}
                }
            }
        }

        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, ArmId);
        PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);

        switch (ArmStatic.ArmType)
		{
            case 0:
                {
                    switch (ArmStatic.WeaponDamageMin == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterPhysicalDamgeMin = CharaterPropertyStatic.CharaterPhysicalDamgeMin - ArmStatic.WeaponDamageMin;
                                break;
                            }
                    }
                    switch (ArmStatic.WeaponDamageMax == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterPhysicalDamgeMax = CharaterPropertyStatic.CharaterPhysicalDamgeMax - ArmStatic.WeaponDamageMax;
                                break;
                            }
                    }
                    float mainspeed = ArmStatic.WeaponSpeed;
                    switch(TyptState == 1)
					{
                        case true:
							{
                                PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, AnotherArmId);
                                PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                                switch(ArmStatic.WeaponSpeed > mainspeed)
								{
                                    case true:
										{
                                            CharaterPropertyStatic.CharaterAttackSpeed = mainspeed;
                                            break;
										}
                                    case false:
										{
                                            CharaterPropertyStatic.CharaterAttackSpeed = ArmStatic.WeaponSpeed;
                                            break;
										}
								}
                                break;
							}
                        case false:
							{
                                CharaterPropertyStatic.CharaterAttackSpeed = 1;
                                break;
							}
					}
                    PowerSwitchIdNew();
                    break;
                }
            default:
                {
                    switch (ArmStatic.ArmArmor == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterPhysicalResist = CharaterPropertyStatic.CharaterPhysicalResist - ArmStatic.ArmArmor;
                                break;
                            }
                    }
                    CharaterPropertyStatic.CharaterPhysicalResistRate = (CharaterPropertyStatic.CharaterPhysicalResist / CharaterPropertyStatic.CharaterPhysicalResistMax) * 100;
                    switch (ArmStatic.ArmMagicShield == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterMagicShield = CharaterPropertyStatic.CharaterMagicShield - ArmStatic.ArmMagicShield;
                                CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                                break;
                            }
                    }
                    switch (ArmStatic.ArmDodge == 0)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                CharaterPropertyStatic.CharaterDodge = CharaterPropertyStatic.CharaterDodge - ArmStatic.ArmDodge;
                                break;
                            }
                    }
                    CharaterPropertyStatic.CharaterDodgeRate = (CharaterPropertyStatic.CharaterDodge / CharaterPropertyStatic.CharaterDodgeMax) * 100;
                    PowerSwitchIdNew();
                    break;
                }
        }
    }       

    public void CheckSomeTypeArm(int ArmId)
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

        ArmHereCount = FileJson.CharaterArm.Count;

        for (int i = 0; i < ArmHereCount; i++)
        {
            PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, i);
            PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
            int UmequipArmType = ArmStatic.ArmType;
            switch (CharaterArmStatic.ArmEquip)
			{
                case true:
					{
                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, ArmId);
                        PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                        switch(UmequipArmType == ArmStatic.ArmType)
						{
                            case true:
								{
                                    ArmHereArrayCount++;
                                    break;
								}
                            case false:
								{
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

        ArmHereArray = new int[ArmHereArrayCount];

        for (int i = 0; i < ArmHereArrayCount; i++)
        {
            PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, i);
            PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
            int UmequipArmType = ArmStatic.ArmType;
            switch (CharaterArmStatic.ArmEquip)
            {
                case true:
                    {
                        PublicFunctionClone.ReadCharaterArm(CharaterPropertyStatic.CharaterNumber, ArmId);
                        PublicFunctionClone.ReadArm(CharaterArmStatic.ArmBasicId);
                        switch (UmequipArmType == ArmStatic.ArmType)
                        {
                            case true:
                                {
                                    ArmHereArray[i] = FileJson.CharaterArm[i].id;
                                    break;
                                }
                            case false:
                                {
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
}
