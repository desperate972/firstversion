using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMsgBox : MonoBehaviour
{
    //共用function，用來開啟訊息(MsgBox)

    public GameObject Parent;
    public GameObject MsgBoxPrefab;
    public GameObject CancelButtonClone;
    public GameObject AcceptButtonClone;
    public GameObject AcceptAloneButtonClone;
    public PublicFunction PublicFunctionClone;
    public Text Load_Msg;
    public static int InputNum;

    private CreateCharater CreateCharaterClone;
    private CharaterList CharaterListClone;
    private CharaterInfo CharaterInfoClone;
    private MainGameControl MainGameControlClone;
    private MapFunction MapFunctionClone;
    private OpenPrefab OpenPrefabClone;
    private Battle BattleClone;

    // Use this for initialization
    private void Awake()
    {

    }
    
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void MsgBoxClick()
    {
        CreateMsgBox(3);
    }

    public void AcceptClick()
    {
        switch(InputNum)
        {
            case 3:
                {
                    Application.Quit();
                    break;
                }
            case 7:
                {
                    Parent = GameObject.Find("UI/Prefab_CreateCharater(Clone)");
                    CreateCharaterClone = Parent.GetComponent<CreateCharater>();
                    CreateCharaterClone.CreateCharaterFunction();
                    break;
                }
            case 8:
                {
                    Destroy(MsgBoxPrefab);
                    break;
                }
            case 9:
                {
                    Parent = GameObject.Find("UI/Prefab_CharaterList(Clone)");
                    CharaterListClone = Parent.GetComponent<CharaterList>();
                    CharaterListClone.OpenMainScenes();
                    break;
                }
            case 10:
                {
                    Destroy(MsgBoxPrefab);
                    Parent = GameObject.Find("UI/Prefab_CharaterList(Clone)");
                    CharaterListClone = Parent.GetComponent<CharaterList>();
                    CharaterListClone.DeleteCharaterFumction();
                    break;
                }
            case 11:
                {
                    Destroy(MsgBoxPrefab);
                    break;
                }
            case 12:
                {
                    Destroy(MsgBoxPrefab);
                    Parent = GameObject.Find("UI/Prefab_CharaterInfo(Clone)");
                    CharaterInfoClone = Parent.GetComponent<CharaterInfo>();
                    CharaterInfoClone.SussceConfirm();
                    break;
                }
            case 13:
                {
                    Destroy(MsgBoxPrefab);
                    Parent = GameObject.Find("UI/Prefab_CharaterInfo(Clone)");
                    CharaterInfoClone = Parent.GetComponent<CharaterInfo>();
                    CharaterInfoClone.SussceConfirm();
                    break;
                }
            case 14:
                {
                    Destroy(MsgBoxPrefab);
                    Parent = GameObject.Find("UI/Prefab_CharaterInfo(Clone)");
                    CharaterInfoClone = Parent.GetComponent<CharaterInfo>();
                    CharaterInfoClone.SussceConfirm();
                    break;
                }
            case 30:
				{
                    Destroy(MsgBoxPrefab);
                    Parent = GameObject.Find("UI/Prefab_Control");
                    MainGameControlClone = Parent.GetComponent<MainGameControl>();
                    MainGameControlClone.LoadCharaterProperty();
                    MainGameControlClone.LoadMapAgain();
                    MainGameControlClone.LoadNPC();
                    MainGameControlClone.CreateBattlePrefab();
                    MainGameControlClone.Load_Wild_Prefab();
                    MainGameControlClone.ChangeMapCharaterAndNPCAni();
                    Parent = GameObject.Find("UI/Prefab_Map(Clone)");
                    Destroy(Parent);
                    break;
				}
            case 31:
                {
                    Destroy(MsgBoxPrefab);
                    Parent = GameObject.Find("UI/Prefab_Control");
                    MainGameControlClone = Parent.GetComponent<MainGameControl>();
                    MainGameControlClone.LoadCharaterProperty();
                    MainGameControlClone.LoadMapAgain();
                    MainGameControlClone.LoadNPC();
                    MainGameControlClone.MsgUse();
                    MainGameControlClone.Load_City_Prefab();
                    MainGameControlClone.ChangeMapCharaterAndNPCAni();
                    Parent = GameObject.Find("UI/Prefab_Map(Clone)");
                    Destroy(Parent);
                    break;
                }
            case 32:
                {
                    Destroy(MsgBoxPrefab);
                    Parent = GameObject.Find("UI/Prefab_Control");
                    MainGameControlClone = Parent.GetComponent<MainGameControl>();
                    MainGameControlClone.IfCharaterDie();
                    MainGameControlClone.Load_City_Prefab();
                    MainGameControlClone.ChangeMapCharaterAndNPCAni();
                    Parent = GameObject.Find("UI/Prefab_Battle(Clone)");
                    BattleClone = Parent.GetComponent<Battle>();
                    BattleClone.DeleteBattlePrerfab();
                    Parent = GameObject.Find("UI/Prefab_Battle(Clone)");
                    Destroy(Parent);
                    break;
                }
            case 33:
                {
                    Destroy(MsgBoxPrefab);
                    break;
                }

            case 35:
				{
                    Destroy(MsgBoxPrefab);
                    Parent = GameObject.Find("UI/Prefab_Control");
                    MainGameControlClone = Parent.GetComponent<MainGameControl>();
                    MainGameControlClone.LoadCharaterProperty();
                    MainGameControlClone.LoadMapAgain();
                    MainGameControlClone.LoadNPC();
                    MainGameControlClone.MsgUse();
                    MainGameControlClone.Load_City_Prefab();
                    MainGameControlClone.ChangeMapCharaterAndNPCAni();
                    Parent = GameObject.Find("UI/Prefab_Battle(Clone)");
                    Destroy(Parent);
                    break;
				}
            default:
                {
                    Debug.Log("跳出訊息的最後，或是取得有誤!");
                    break;
                }
        }
    }

    public void CancelClick()
    {
        Destroy(MsgBoxPrefab);
    }

    public void CreateMsgBox(int i)
    {
        InputNum = i;
        CheckMsgBoxType();
        PublicFunctionClone.ReadStringUI(i);
        string ReadStringUI = PublicFunction.ReturnString;
        Load_Msg.text = ReadStringUI;
        Instantiate(MsgBoxPrefab, Parent.transform);
    }


    public void CheckMsgBoxType()                                   //檢查MsgBox是否要變換按鈕位置
    {
        switch(InputNum)
        {
            case 3:
                {
                    MsgBoxType(1);
                    break;
                }
            case 7:
                {
                    MsgBoxType(1);
                    break;
                }
            case 8:
                {
                    MsgBoxType(2);
                    break;
                }
            case 9:
                {
                    MsgBoxType(1);
                    break;
                }
            case 10:
                {
                    MsgBoxType(1);
                    break;
                }
            case 11:
                {
                    MsgBoxType(2);
                    break;
                }
            case 12:
                {
                    MsgBoxType(1);
                    break;
                }
            case 13:
                {
                    MsgBoxType(1);
                    break;
                }
            case 14:
                {
                    MsgBoxType(2);
                    break;
                }
            case 30:
				{
                    MsgBoxType(1);
                    break;
				}
            case 31:
                {
                    MsgBoxType(2);
                    break;
                }
            case 32:
                {
                    MsgBoxType(2);
                    break;
                }
            case 33:
                {
                    MsgBoxType(2);
                    break;
                }
            case 35:
				{
                    MsgBoxType(1);
                    break;
				}
            default:
                {
                    MsgBoxType(1);
                    break;
                }
        }
    }

    public void MsgBoxType(int Type)                               //檢查MsgBox變換位置的功能
    {
        switch(Type)
        {
            case 1:
                {
                    CancelButtonClone.SetActive(true);
                    AcceptButtonClone.SetActive(true);
                    AcceptAloneButtonClone.SetActive(false);
                    break;
                }
            case 2:
                {
                    CancelButtonClone.SetActive(false);
                    AcceptButtonClone.SetActive(false);
                    AcceptAloneButtonClone.SetActive(true);
                    break;
                }
        }
    }
}
