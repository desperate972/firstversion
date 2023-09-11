using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CreateFunction : MonoBehaviour
{

    public Button Male;
    public Button Female;
    public GameObject MaleActive;
    public GameObject FemaleActive;
    public GameObject PopTextPrefab;
    //public GameObject ParentPrefab;
    public PublicFunction PublicFunctionClone;
    public PopUp PopUpClone;
    public Text Load_StrengthText;
    public Text Load_IntelligenceText;
    public Text Load_DexterityText;
    public Text Load_FewText;
    public static int CharaterSex;
    public static int Few = 5;

    private int StrengthNum;
    private int IntelligenceNum = 0;
    private int DexterityNum = 0;
    //private int Few = 5;
    private Text Load_PopText;
    private GameObject Parent;


    public void Awake()
    {
        Load_FewText.text = Few.ToString();
        CharaterSex = 1;
        Parent = GameObject.Find("Prefab_CreateCharater(Clone)");
    }

    // Use this for initialization
    void Start ()
    {
        //Parent = ParentPrefab.transform.gameObject;                        //取得要複製介面的父物件的transform
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void MaleClick()                                              //創角決定性別，如果玩家點擊的是男，會勾選男的框框，隱藏女的框框
    {
        CharaterSex = 1;
        MaleActive.SetActive(true);
        FemaleActive.SetActive(false);

        Debug.Log(CharaterSex);
    }

    public void FemaleClick()                                           //創角決定性別，如果玩家點擊的是女，會勾選女的框框，隱藏男的框框
    {
        CharaterSex = 0;
        MaleActive.SetActive(false);
        FemaleActive.SetActive(true);

        Debug.Log(CharaterSex);
    }

    public void StrengthClickAdd()                                       //創角時的屬性配點，加力量1點
    {
        Few = Convert.ToInt32(Load_FewText.text);
        StrengthNum = Convert.ToInt32(Load_StrengthText.text);

        if (Few == 0)
        {
            return;
        }

        else
        {
            StrengthNum += 1;
            Load_StrengthText.text = StrengthNum.ToString();
            Few -= 1;
            Load_FewText.text = Few.ToString();
        }
    }
    public void StrengthClickLess()                                       //創角時的屬性配點，減力量1點
    {
        Few = Convert.ToInt32(Load_FewText.text);
        StrengthNum = Convert.ToInt32(Load_StrengthText.text);

        if (Few == 5 || StrengthNum <= 0)
        {
            return;
        }

        else
        {
            StrengthNum -= 1;
            Load_StrengthText.text = StrengthNum.ToString();
            Few += 1;
            Load_FewText.text = Few.ToString();
        }
    }

    public void IntelligenceClickAdd()                                        //創角時的屬性配點，加智力1點
    {
        Few = Convert.ToInt32(Load_FewText.text);
        IntelligenceNum = Convert.ToInt32(Load_IntelligenceText.text);

        if (Few == 0)
        {
            return;
        }

        else
        {
            IntelligenceNum += 1;
            Load_IntelligenceText.text = IntelligenceNum.ToString();
            Few -= 1;
            Load_FewText.text = Few.ToString();
        }
    }
    public void IntelligenceClickLess()                                        //創角時的屬性配點，減智力1點
    {
        Few = Convert.ToInt32(Load_FewText.text);
        IntelligenceNum = Convert.ToInt32(Load_IntelligenceText.text);

        if (Few == 5 || IntelligenceNum <= 0)
        {
            return;
        }

        else
        {
            IntelligenceNum -= 1;
            Load_IntelligenceText.text = IntelligenceNum.ToString();
            Few += 1;
            Load_FewText.text = Few.ToString();
        }
    }

    public void DexterityClickAdd()                                            //創角時的屬性配點，加敏捷1點
    {
        Few = Convert.ToInt32(Load_FewText.text);
        DexterityNum = Convert.ToInt32(Load_DexterityText.text);

        if (Few == 0)
        {
            return;
        }

        else
        {
            DexterityNum += 1;
            Load_DexterityText.text = DexterityNum.ToString();
            Few -= 1;
            Load_FewText.text = Few.ToString();
        }
    }
    public void DexterityClickLess()                                               //創角時的屬性配點，減敏捷1點
    {
        Few = Convert.ToInt32(Load_FewText.text);
        DexterityNum = Convert.ToInt32(Load_DexterityText.text);

        if (Few == 5 || DexterityNum <= 0)
        {
            return;
        }

        else
        {
            DexterityNum -= 1;
            Load_DexterityText.text = DexterityNum.ToString();
            Few += 1;
            Load_FewText.text = Few.ToString();
        }
    }

    public void PopStrengthText()                                                //玩家點擊屬性旁邊的力量問號按鈕，會跳出提示訊息來說明該屬性
    {
        string StrengthText;

        Instantiate(PopTextPrefab, Parent.transform);
        PublicFunctionClone.ReadStringUI(4);
        StrengthText = PublicFunction.ReturnString;
        PopUpClone.PopUp_Load_String(StrengthText);
    }

    public void PopIntelligenceText()                                             //玩家點擊屬性旁邊的智力問號按鈕，會跳出提示訊息來說明該屬性
    {
        string IntelligenceText;

        Instantiate(PopTextPrefab, Parent.transform);
        PublicFunctionClone.ReadStringUI(5);
        IntelligenceText = PublicFunction.ReturnString;
        PopUpClone.PopUp_Load_String(IntelligenceText);
    }

    public void PopDexterityText()                                                //玩家點擊屬性旁邊的敏捷問號按鈕，會跳出提示訊息來說明該屬性
    {
        string DexterityText;

        Instantiate(PopTextPrefab, Parent.transform);
        PublicFunctionClone.ReadStringUI(6);
        DexterityText = PublicFunction.ReturnString;
        PopUpClone.PopUp_Load_String(DexterityText);
    }
}
