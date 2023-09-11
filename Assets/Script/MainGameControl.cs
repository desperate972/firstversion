using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using System.IO;

public class MainGameControl : MonoBehaviour
{

    public PublicFunction PublicfunctionClone;
    public GameObject HpSprite;
    public GameObject MpSprite;
    public GameObject EXPSprite;
    public GameObject MagicShieldSrpite;
    public GameObject Btn_NPC;
    public GameObject Grid_NPC;
    public GameObject CharaterMotionClone;
    public OpenMsgBox OpenMsgBoxClone;
    public GameObject BattlePrefab;
    public GameObject MagicShieldFrme;

    public Text Load_LV;
    public Text Load_Hp;
    public Text Load_Mp;
    public Text Load_EXP;
    public Text Load_MagicShield;

    public SpriteAtlas SpriteAtlaseChange;
    public SpriteAtlas SpriteAtlaseMap;

    public Image Image_Map;

    public GameObject MagicShield_Frame;
    public GameObject MagicShield_Text;
    public GameObject MagicShield_Load;
    public GameObject MagicShield_FrameOutside;

    public static int CharaterNumber;

    public Animator Ani_CharaterMotion;

    public NPCFunction NPCFunctionClone;

    public GameObject CharaterSprite;
    public GameObject NPCSprite;

    public GameObject BattleSenceClone;

    public GameObject Load_MapObject;
    public GameObject Map_City_Prefab;
    public GameObject Map_Wild_Prefab;
    public GameObject EmptyPrefab;
    public int Mapcount;

    private GameObject NPCList;
    private GameObject NPCFunction;

    private GameObject CharaterInfo;
    private GameObject Skill;
    private GameObject Bag;
    private GameObject Mission;
    private GameObject Map;
    private GameObject Setting;

    private GameObject NPCListButton;
    private GameObject FunctionButton;

    private Image NPCListButtonImage;
    private Image FunctionButtonImage;

    private GameObject Btn_NPCClone;
    private GameObject NPCNameObj;
    private Text Load_NPCName;

    private GameObject ParentPrafab;   
    private int state = 0;

    private GameObject EmptyGameObject;

    private void Awake()
    {
        //以下內容為主畫面上切換功能按鈕或是NPC列表
        NPCListButton = GameObject.Find("Btn_NPCList");
        NPCListButtonImage = NPCListButton.GetComponent<Image>();

        FunctionButton = GameObject.Find("Btn_Function");
        FunctionButtonImage = FunctionButton.GetComponent<Image>();

        FunctionButtonImage.sprite = SpriteAtlaseChange.GetSprite("button_ready_on_1");
        NPCListButtonImage.sprite = SpriteAtlaseChange.GetSprite("button_ready_off");

        NPCList = GameObject.Find("UI/Prefab_Control/Scroll_NPCList");
        NPCFunction = GameObject.Find("UI/Prefab_Control/Scroll_NPCFunction");
        CharaterInfo = GameObject.Find("Btn_CharaterInfo");
        Skill = GameObject.Find("Btn_Skill");
        Bag = GameObject.Find("Btn_Bag");
        Mission = GameObject.Find("Btn_Mission");
        Map = GameObject.Find("Btn_Map");
        Setting = GameObject.Find("Btn_Setting");

        ParentPrafab = GameObject.Find("UI");
        //------------------------------------------
        LoadCharaterProperty();         //載入角色資料
        LoadMapData();                  //載入地圖背景圖
        LoadNPC();                      //載入NPC內容  
        Instantiate(Map_City_Prefab, Load_MapObject.transform);
        ChangeMapCharaterAndNPCAni();
    }
    // Use this for initialization
    void Start ()
    {
        if(CharaterPropertyStatic.CharaterHpNow < CharaterPropertyStatic.CharaterHp || CharaterPropertyStatic.CharaterMpNow < CharaterPropertyStatic.CharaterMp || CharaterPropertyStatic.CharaterMagicShieldNow < CharaterPropertyStatic.CharaterMagicShield)

        {
            InvokeRepeating("CharaterRecover", 1, 0.1f);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void LoadCharaterProperty()                                                  //更新主介面上的角色資訊，角色血量，角色魔力，角色等級，角色經驗值
    {
        switch(CharaterPropertyStatic.CharaterMagicShield != 0)
		{
            case true:
				{
                    MagicShieldSrpite.SetActive(true);
                    MagicShield_Frame.SetActive(true);
                    MagicShield_Load.SetActive(true);
                    MagicShield_Text.SetActive(true);
                    MagicShield_FrameOutside.SetActive(true);
                    PublicfunctionClone.ChangeSpriteSize(MagicShieldSrpite, CharaterPropertyStatic.CharaterMagicShieldNow, CharaterPropertyStatic.CharaterMagicShieldNow, CharaterPropertyStatic.CharaterMagicShield, 0);
                    Load_MagicShield.text = CharaterPropertyStatic.CharaterMagicShieldNow.ToString("0") + "/" + CharaterPropertyStatic.CharaterMagicShield;
                    break;
				}
            case false:
				{
                    MagicShieldSrpite.SetActive(false);
                    MagicShield_Frame.SetActive(false);
                    MagicShield_Load.SetActive(false);
                    MagicShield_Text.SetActive(false);
                    MagicShield_FrameOutside.SetActive(false);
                    break;
				}
		}
        PublicfunctionClone.ChangeSpriteSize(HpSprite, CharaterPropertyStatic.CharaterHpNow, CharaterPropertyStatic.CharaterHpNow, CharaterPropertyStatic.CharaterHp, 0);
        PublicfunctionClone.ChangeSpriteSize(MpSprite, CharaterPropertyStatic.CharaterMpNow, CharaterPropertyStatic.CharaterMpNow, CharaterPropertyStatic.CharaterMp, 0);
        PublicfunctionClone.ChangeSpriteSize(EXPSprite, CharaterPropertyStatic.CharaterExpNow, CharaterPropertyStatic.CharaterExpNow, CharaterPropertyStatic.CharaterExp, 0);
        Load_LV.text = CharaterPropertyStatic.CharaterLevel.ToString();
        Load_Hp.text = CharaterPropertyStatic.CharaterHpNow.ToString("0") + "/" + CharaterPropertyStatic.CharaterHp.ToString();
        Load_Mp.text = CharaterPropertyStatic.CharaterMpNow.ToString("0") + "/" + CharaterPropertyStatic.CharaterMp.ToString();
        Load_EXP.text = CharaterPropertyStatic.CharaterExpNow.ToString("0") + "/" + CharaterPropertyStatic.CharaterExp;
        ChangeMapCharaterAndNPCAni();
    }

    public void ChangeNPCList()                                                         //切換NPC列表跟功能按鈕的頁籤
    {
        NPCListButtonImage.sprite = SpriteAtlaseChange.GetSprite("button_ready_on_1");
        FunctionButtonImage.sprite = SpriteAtlaseChange.GetSprite("button_ready_off");

        NPCList.SetActive(true);
        NPCFunction.SetActive(false);

        CharaterInfo.SetActive(false);
        Skill.SetActive(false);
        Bag.SetActive(false);
        Mission.SetActive(false);
        Map.SetActive(false);
        Setting.SetActive(false);

        NPCFunctionClone.CharaterAndNPCState = 1;
    }

    public void ChangeFunction()                                                        //切換NPC列表跟功能按鈕的頁籤
    {
        FunctionButtonImage.sprite = SpriteAtlaseChange.GetSprite("button_ready_on_1");
        NPCListButtonImage.sprite = SpriteAtlaseChange.GetSprite("button_ready_off");

        NPCList.SetActive(false);
        NPCFunction.SetActive(false);

        CharaterInfo.SetActive(true);
        Skill.SetActive(true);
        Bag.SetActive(true);
        Mission.SetActive(true);
        Map.SetActive(true);
        Setting.SetActive(true);

        NPCFunctionClone.CharaterAndNPCForFunction();
    }

    public void LoadMapData()                                                           //顯示當前城市的背景圖
	{
        PublicfunctionClone.ReadMap(CharaterPropertyStatic.CharaterLastMap);
        Image_Map.sprite = SpriteAtlaseMap.GetSprite(MapStatic.MapSprite);

        CharaterPropertyStatic.CharaterNowMap = CharaterPropertyStatic.CharaterLastMap;
        PublicfunctionClone.CharaterPropertyStaticChange();
        string FilePath = "Charater_" + CharaterPropertyStatic.CharaterNumber;
        string FileInside;

        PublicfunctionClone.ReadPlatformpersistentDataPath(FilePath);
        FileInside = JsonUtility.ToJson(PublicFunction.CharaterPropertyValue);
        File.WriteAllText(PublicFunction.persistentFilePath, FileInside);    
    }

    public void LoadMapAgain()                                                          //載入當前角色所在的地圖背景圖(通常都是野外圖)
	{
        PublicfunctionClone.ReadMap(CharaterPropertyStatic.CharaterNowMap);
        Image_Map.sprite = SpriteAtlaseMap.GetSprite(MapStatic.MapSprite);        
    }

    public void LoadNPC()                                                               //將該城市的NPC列表顯示出來
	{
        PublicfunctionClone.ReadNPCList(MapStatic.MapNpcList);
        for(int NPCNum = 0; NPCNum < NPCListStatic.NpcList.Length; NPCNum++)
		{
            PublicfunctionClone.ReadNPC(NPCListStatic.NpcList[NPCNum]);
            Btn_NPCClone = Instantiate(Btn_NPC, Grid_NPC.transform);
            Btn_NPCClone.name = "Btn_NPCFunction_" + NPCNum;
            NPCNameObj = GameObject.Find("UI/Prefab_Control/Scroll_NPCList/Mask/Grid_NpcList/Btn_NPCFunction_" + NPCNum + "/Load_NPC");
            Load_NPCName = NPCNameObj.GetComponent<Text>();
            Load_NPCName.text = NPCStatic.NPCName;
            NPCFunction NPCFunctionClone = Btn_NPCClone.GetComponent<NPCFunction>();
            NPCFunctionClone.NPCId = NPCStatic.Id;
        }

        for (int NPCNum = NPCListStatic.NpcList.Length; NPCNum < Grid_NPC.transform.childCount; NPCNum++)
        {
            EmptyGameObject = Grid_NPC.transform.GetChild(NPCNum).gameObject;
            Destroy(EmptyGameObject);
        }
    }

    public void Test()                                                                  //動畫切換測試
	{           
        switch (state)
		{
            case 1:
				{
                    Ani_CharaterMotion.GetComponent<Animator>().SetBool("Charater_Walk", false);
                    Ani_CharaterMotion.GetComponent<Animator>().SetBool("Charater_Rest", true);
                    state = 0;
                    Debug.Log("現在執行的動畫是:Charater_Rest");
                    break;
				}
            case 0:
				{
                    Ani_CharaterMotion.GetComponent<Animator>().SetBool("Charater_Rest", false);
                    Ani_CharaterMotion.GetComponent<Animator>().SetBool("Charater_Walk", true);
                    state = 1;
                    Debug.Log("現在執行的動畫是:Charater_Walk");
                    break;
				}
		}
    }

    public void IfCharaterDie()                                                         //如果角色死去回到城鎮，會跳訊息說明
	{
        Debug.Log("有沒有觸發到角色死亡的功能?");
        LoadCharaterProperty();   
        LoadMapData();            
        LoadNPC();    
        switch (CharaterPropertyStatic.CharaterMagicShield != 0)
		{
            case true:
				{
                    CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                    string MagicShieldNow = CharaterPropertyStatic.CharaterMagicShieldNow.ToString("0.0");
                    CharaterPropertyStatic.CharaterMagicShieldNow = float.Parse(MagicShieldNow);
                    break;
				}
            case false:
				{
                    break;
				}
		}
        CharaterPropertyStatic.CharaterHpNow = CharaterPropertyStatic.CharaterHp * 0.1f;
        CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMp * 0.1f;       

        string HpNow = CharaterPropertyStatic.CharaterHpNow.ToString("0.0");
        string MpNow = CharaterPropertyStatic.CharaterMpNow.ToString("0.0");        
        CharaterPropertyStatic.CharaterHpNow = float.Parse(HpNow);
        CharaterPropertyStatic.CharaterMpNow = float.Parse(MpNow);      
        FlashCharaterInfo();
        SaveCharaterFile();
        InvokeRepeating("CharaterRecover", 1, 0.1f);
    }

    public void MsgUse()
	{
        InvokeRepeating("CharaterRecover", 1, 0.1f);
    }

    public void CharaterRecover()                                                       //判斷角色的狀態回復
	{
        Debug.Log("成功觸發回復功能!");
        switch (CharaterPropertyStatic.CharaterMagicShield != 0)
        {
            case true:
                {
                    CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
                    string MagicShieldNow = CharaterPropertyStatic.CharaterMagicShieldNow.ToString("0.0");
                    CharaterPropertyStatic.CharaterMagicShieldNow = float.Parse(MagicShieldNow);
                    break;
                }
            case false:
                {
                    break;
                }
        }
        CharaterPropertyStatic.CharaterHpNow = CharaterPropertyStatic.CharaterHpNow + (CharaterPropertyStatic.CharaterHp * 0.1f);
        CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMpNow + (CharaterPropertyStatic.CharaterMp * 0.1f);
        string HpNow = CharaterPropertyStatic.CharaterHpNow.ToString("0.0");
        string MpNow = CharaterPropertyStatic.CharaterMpNow.ToString("0.0");
        CharaterPropertyStatic.CharaterHpNow = float.Parse(HpNow);
        CharaterPropertyStatic.CharaterMpNow = float.Parse(MpNow);

        if (CharaterPropertyStatic.CharaterHpNow >= CharaterPropertyStatic.CharaterHp)
        {
            CharaterPropertyStatic.CharaterHpNow = CharaterPropertyStatic.CharaterHp;
        }
        if (CharaterPropertyStatic.CharaterMpNow >= CharaterPropertyStatic.CharaterMp)
        {
            CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMp;
        }
        if(CharaterPropertyStatic.CharaterHpNow >= CharaterPropertyStatic.CharaterHp && CharaterPropertyStatic.CharaterMpNow >= CharaterPropertyStatic.CharaterMp)
		{
            CancelInvoke();
            Debug.Log("角色狀態已經完全回復!");
		}
        FlashCharaterInfo();
        SaveCharaterFile();
    }

    public void FlashCharaterInfo()                                                     //用來刷新角色資訊的功能
	{
        Debug.Log("角色當前血量:" + CharaterPropertyStatic.CharaterHpNow);
        Debug.Log("角色當前魔力:" + CharaterPropertyStatic.CharaterMpNow);
        
        switch (CharaterPropertyStatic.CharaterMagicShield != 0)
		{
            case true:
                {
                    PublicfunctionClone.ChangeSpriteSize(MagicShieldSrpite, CharaterPropertyStatic.CharaterMagicShieldNow, CharaterPropertyStatic.CharaterMagicShield, CharaterPropertyStatic.CharaterMagicShield, 0);
                    Load_MagicShield.text = CharaterPropertyStatic.CharaterMagicShieldNow + "/" + CharaterPropertyStatic.CharaterMagicShield;
                    Debug.Log("角色當前法術護盾:" + CharaterPropertyStatic.CharaterMagicShieldNow);
                    break; 
                }
            case false:
				{
                    break;
				}
		}

        PublicfunctionClone.ChangeSpriteSize(HpSprite, CharaterPropertyStatic.CharaterHpNow, CharaterPropertyStatic.CharaterHp, CharaterPropertyStatic.CharaterHp, 0);
        PublicfunctionClone.ChangeSpriteSize(MpSprite, CharaterPropertyStatic.CharaterMpNow, CharaterPropertyStatic.CharaterMp, CharaterPropertyStatic.CharaterMp, 0);
        PublicfunctionClone.ChangeSpriteSize(EXPSprite, CharaterPropertyStatic.CharaterExpNow, CharaterPropertyStatic.CharaterExp, CharaterPropertyStatic.CharaterExp, 0);       
        Load_LV.text = CharaterPropertyStatic.CharaterLevel.ToString();
        Load_Hp.text = CharaterPropertyStatic.CharaterHpNow.ToString("0") + "/" + CharaterPropertyStatic.CharaterHp.ToString();
        Load_Mp.text = CharaterPropertyStatic.CharaterMpNow.ToString("0") + "/" + CharaterPropertyStatic.CharaterMp.ToString();
        Load_EXP.text = CharaterPropertyStatic.CharaterExpNow.ToString("0") + "/" + CharaterPropertyStatic.CharaterExp;       
    }

    public void SaveCharaterFile()                                                      //每次修改到角色資訊時都要重新存檔，避免中途遊戲死當或是退出遊戲時造成檔案錯誤
    {
        PublicfunctionClone.CharaterPropertyStaticChange();
        string FileName = "Charater_" + CharaterPropertyStatic.CharaterNumber;
        string data = JsonUtility.ToJson(PublicFunction.CharaterPropertyValue);
        PublicfunctionClone.ReadPlatformpersistentDataPath(FileName);
        System.IO.File.WriteAllText(PublicFunction.persistentFilePath, data);
        Debug.Log("成功儲存角色檔案");
    }

    public void CreateBattlePrefab()
	{
        Instantiate(BattlePrefab, ParentPrafab.transform);
	}

    public void ChangeMapCharaterAndNPCAni()                                            //判斷當前角色所在地圖，來判斷當前要使用那些動畫顯示
	{
        PublicfunctionClone.ReadCharaterPropertyFileFunction(CharaterPropertyStatic.CharaterNumber);
        switch(CharaterPropertyStatic.CharaterNowMap)
		{
            case 0:
				{
                    CharaterSprite.SetActive(true);
                    NPCSprite.SetActive(true);
                    break;
				}
            case 1:
				{
                    CharaterSprite.SetActive(false);
                    NPCSprite.SetActive(false);
                    break;
				}
		}
	}

    public void Load_City_Prefab()
	{
        Mapcount = Load_MapObject.transform.childCount;
        for (int n = 0; n < Mapcount; n++)
        {
            EmptyPrefab = Load_MapObject.transform.GetChild(n).gameObject;
            Destroy(EmptyPrefab);
        }
        Instantiate(Map_City_Prefab, Load_MapObject.transform);
    }

    public void Load_Wild_Prefab()
    {
        Mapcount = Load_MapObject.transform.childCount;
        for (int n = 0; n < Mapcount; n++)
        {
            EmptyPrefab = Load_MapObject.transform.GetChild(n).gameObject;
            Destroy(EmptyPrefab);
        }
        Instantiate(Map_Wild_Prefab, Load_MapObject.transform);
    }
}
