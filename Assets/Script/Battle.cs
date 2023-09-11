using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using System.IO;
using System.Linq;

public class Battle : MonoBehaviour
{
    public PublicFunction PublicFunctionClone;
    public OpenMsgBox OpenMsgBoxClone;
    public MainGameControl MainGameControlClone;

    public GameObject BattleButton;
    public GameObject BlockButton;
    public Image BattleButtonSprite;

    public GameObject HpSprite;
    public GameObject MpSprite;
    public GameObject MagicShieldSrpite;

    public Text Load_Hp;
    public Text Load_Mp;
    public Text Load_MagicShield;

    public SpriteAtlas SpriteAtlaseChange;

    public GameObject MagicShield_Frame;
    public GameObject MagicShield_Text;
    public GameObject MagicShield_Load;
    public GameObject MagicShield_FrameOutside;

    public GameObject HpSprite_Monster;
    public GameObject MpSprite_Monster;
    public GameObject MagicShieldSrpite_Monster;
    public GameObject MS_Frame_Monster;

    public GameObject MonsterName;
    public Text MonsterNameText;
    public GameObject MonsterLevelObject;
    public Text MonssterLevelText;

    public Text Load_Hp_Monster;
    public Text Load_Mp_Monster;
    public Text Load_MagicShield_Monster;

    public GameObject MagicShield_Frame_Monster;
    public GameObject MagicShield_Text_Monster;
    public GameObject MagicShield_Load_Monster;
    public GameObject HPMP_Frame_Monster;

    private GameObject BattlePrefab;

    public static float[] CharaterBattleSkillTime;
    public static float[] MonsterSkillTime;

    public GameObject CharaterDamge;
    public Text CharaterDamgeNum;
    public Text CharaterSkillNameObj;

    public GameObject MonsterDamge;
    public Text MonsterDamgeNum;
    public Text MonsterSkillNameObj;

    public SpriteAtlas MonsterAtlas;
    public GameObject MonsterIconObject;
    public Image MonsterICON;

    private float BattleTime;
    //private int BattleSkillNowNum;
    private int CharaterSkillTurn;
    private int MonsterSkillTurn;
    private float CharaterAttackDamge;
    private float MonsterAttackDamage;
    private int MonsterIdRandom;
    private int MonsterLevel;

    private float[] CharaterBattleSkillTimeAlways;
    private float[] MonsterSkillTimeAlways;

    private int[] DodgeArray;
    private bool DodgeSucces;

    private int[] CritArray;
    private bool CritSucces;

    private int[] MonsterDodgeArray;
    private bool MonsterDodgeSucces;

    private int[] MonsterCritArray;
    private bool MonsterCritSucces;

    private int[] CharaterSkillLevel;
    private int[] MonsterSkillLevel;

    private int[] MonsterDieItemRateArray;
    private int[] CharaterGetItemId;
    private int[] CharaterGetItemNum;
    private int CharaterGetItemIdNum;
    public Text Load_BattleWinStringUI;
    public GameObject Load_Item_Object;
    public GameObject BattleWinObject;
    private GameObject Grid_Load_Item;
    public Image Load_ItemIcon;
    public Text Load_ItemNum;
    private GameObject EmptyGameObject;
    public SpriteAtlas SpriteItem;
    private GameObject Load_ItemIconObject;
    private GameObject Load_ItemNumObject;

    private int[] CreateMonsterArray;

    private int CharaterGetArmIdNum;
    private int[] CharaterGetArmNum;
    private int[] CharaterGetArmId;
    private int[] MonsterDieArmRateArray;
    private int[] CharaterArmIdArray;
    public GameObject Load_Arm_Object;
    public Image Load_ArmIcon;
    public Text Load_ArmNum;
    public SpriteAtlas SpriteArm;
    private GameObject Load_ArmIconObject;
    private GameObject Load_ArmNumObject;

    public SpriteAtlas SpriteSkillIcon;

    public Image PlayerSkill_1;
    public Image PlayerSkill_2;
    public Image PlayerSkill_3;
    public Image PlayerSkill_4;
    public Image PlayerSkill_5;

    public Image MonaterSkill_1;
    public Image MonaterSkill_2;
    public Image MonaterSkill_3;
    public Image MonaterSkill_4;
    public Image MonaterSkill_5;

    public Text Load_Time;

    public Text PlayerSkillCount_1;
    public Image PlayerSkillReady_1;
    public GameObject PlayerSkillCountObj_1;
    public GameObject PlayerSkillReadytObj_1;
    public GameObject PlayerHighLight_1;
    public Text PlayerSkillCount_2;
    public Image PlayerSkillReady_2;
    public GameObject PlayerSkillCountObj_2;
    public GameObject PlayerSkillReadytObj_2;
    public GameObject PlayerHighLight_2;
    public Text PlayerSkillCount_3;
    public Image PlayerSkillReady_3;
    public GameObject PlayerSkillCountObj_3;
    public GameObject PlayerSkillReadytObj_3;
    public GameObject PlayerHighLight_3;
    public Text PlayerSkillCount_4;
    public Image PlayerSkillReady_4;
    public GameObject PlayerSkillCountObj_4;
    public GameObject PlayerSkillReadytObj_4;
    public GameObject PlayerHighLight_4;
    public Text PlayerSkillCount_5;
    public Image PlayerSkillReady_5;
    public GameObject PlayerSkillCountObj_5;
    public GameObject PlayerSkillReadytObj_5;
    public GameObject PlayerHighLight_5;

    public Text MonsterSkillCount_1;
    public Image MonsterSkillReady_1;
    public GameObject MonsterSkillCountObj_1;
    public GameObject MonsterSkillReadytObj_1;
    public GameObject MonsterHighLight_1;
    public Text MonsterSkillCount_2;
    public Image MonsterSkillReady_2;
    public GameObject MonsterSkillCountObj_2;
    public GameObject MonsterSkillReadytObj_2;
    public GameObject MonsterHighLight_2;
    public Text MonsterSkillCount_3;
    public Image MonsterSkillReady_3;
    public GameObject MonsterSkillCountObj_3;
    public GameObject MonsterSkillReadytObj_3;
    public GameObject MonsterHighLight_3;
    public Text MonsterSkillCount_4;
    public Image MonsterSkillReady_4;
    public GameObject MonsterSkillCountObj_4;
    public GameObject MonsterSkillReadytObj_4;
    public GameObject MonsterHighLight_4;
    public Text MonsterSkillCount_5;
    public Image MonsterSkillReady_5;
    public GameObject MonsterSkillCountObj_5;
    public GameObject MonsterSkillReadytObj_5;
    public GameObject MonsterHighLight_5;

    public static int CloseCountNum;

    public static float PlayerSkillCoolDown_1;
    public static float PlayerSkillCoolDown_2;
    public static float PlayerSkillCoolDown_3;
    public static float PlayerSkillCoolDown_4;
    public static float PlayerSkillCoolDown_5;

    public static float MonsterSkillCoolDown_1;
    public static float MonsterSkillCoolDown_2;
    public static float MonsterSkillCoolDown_3;
    public static float MonsterSkillCoolDown_4;
    public static float MonsterSkillCoolDown_5;

    public Animator Player_Ani;
    public Animator Monster_Ani;

    public void Awake()
    {
        BlockButton = GameObject.Find("UI/Prefab_Battle(Clone)/Load_BlockButton");
        //Grid_Load_Item = GameObject.Find("UI/Prefab_Battle(Clone)/BattleWin/Scroll_BattleWinItemList/Mask/Grid_BattleWinItemList");
        LoadCharaterProperty();
        BattleReady();
        CloseCountNum = 0;
        MainGameControlClone.ChangeMapCharaterAndNPCAni();
        Player_Ani.GetComponent<Animator>();
        Monster_Ani.GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("BattleStart", 0, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BattleReady()
    {
        //BattleSkillNowNum = 0;
        BattleTime = 0;
        CharaterSkillTurn = 0;
        MonsterSkillTurn = 0;
        CreateMonster();
        ReadCharaterSkillTime();
        ReadMonsterSkillTime();
        LoadMonsterProperty();
        LoadMonsterAni();
    }

    public void CreateMonster()                                                         //生成本次戰鬥的怪物所有數值
    {
        PublicFunctionClone.ReadMonsterList(MapStatic.MonsterList);

        CreateMonsterExtraFunction();
        int CreateMonsterId = UnityEngine.Random.Range(0, 100);
        MonsterIdRandom = CreateMonsterArray[CreateMonsterId];
        //MonsterIdRandom = UnityEngine.Random.Range(MonsterListStatic.MonsterIdList[0], (MonsterListStatic.MonsterIdList[MonsterListStatic.MonsterIdList.Length - 1] + 1));
        PublicFunctionClone.ReadMonster(MonsterIdRandom);
        MonsterLevel = UnityEngine.Random.Range(MonsterStatic.MonsterLevelMin, MonsterStatic.MonsterLevelMax + 1);

        //-----計算怪物因等級成長的數值
        MonsterStatic.MonsterPhysicalDamgeMin = MonsterStatic.MonsterPhysicalDamgeMin + (MonsterStatic.MonsterPhysicalDamgeLevel * MonsterLevel);
        MonsterStatic.MonsterPhysicalDamgeMax = MonsterStatic.MonsterPhysicalDamgeMax + (MonsterStatic.MonsterPhysicalDamgeLevel * MonsterLevel);
        MonsterStatic.MonsterHp = MonsterStatic.MonsterHp + (MonsterStatic.MonsterHpLevel * MonsterLevel);
        MonsterStatic.MonsterMp = MonsterStatic.MonsterMp + (MonsterStatic.MonsterMpLevel * MonsterLevel);
        MonsterStatic.MonsterMagicDamgeMin = MonsterStatic.MonsterMagicDamgeMin + (MonsterStatic.MonsterMagicDamgeLevel * MonsterLevel);
        MonsterStatic.MonsterMagicDamgeMax = MonsterStatic.MonsterMagicDamgeMax + (MonsterStatic.MonsterMagicDamgeLevel * MonsterLevel);
        MonsterStatic.MonsterMagicShield = MonsterStatic.MonsterMagicShield + (MonsterStatic.MpnsterMagixShieldLevel * MonsterLevel);
        MonsterStatic.MonsterHpNow = MonsterStatic.MonsterHp;
        MonsterStatic.MonsterMpNow = MonsterStatic.MonsterMp;
        MonsterStatic.MonsterMagicShieldNow = MonsterStatic.MonsterMagicShield;
        //-----

        Debug.Log("顯示怪物數值" + "\n" + "怪物血量:" + MonsterStatic.MonsterHp + "\n" + "怪物魔力:" + MonsterStatic.MonsterMp + "\n" + "怪物法術護盾:" + MonsterStatic.MonsterMagicShield);
        MonsterNameText = MonsterName.GetComponent<Text>();
        MonsterNameText.text = MonsterStatic.MonsterName;
        MonssterLevelText = MonsterLevelObject.GetComponent<Text>();
        MonssterLevelText.text = MonsterLevel.ToString();
        MonsterICON.sprite = MonsterAtlas.GetSprite(MonsterStatic.MonsterIcon);
    }

    public void ClickBattleStart()                                                      //點擊來觸發"BattleStart"的function
    {
        Debug.Log("是否有被觸發到?");
        BattleButtonSprite = BattleButton.GetComponent<Image>();
        BattleButtonSprite.sprite = SpriteAtlaseChange.GetSprite("button_ready_on_2");
        BlockButton.SetActive(true);
        InvokeRepeating("BattleStart", 0, 0.1f);
    }

    public void BattleStart()                                                           //戰鬥開始
    {
        Debug.Log("是否有被觸發到? - 2");
        Debug.Log("當前時間" + BattleTime);
        Debug.Log("角色技能順序:" + CharaterSkillTurn + "\n" + "怪物技能順序:" + MonsterSkillTurn);
        Debug.Log("角色下一個技能的時間:" + CharaterBattleSkillTime[CharaterSkillTurn]);
        Debug.Log("怪物下一個技能的時間:" + MonsterSkillTime[MonsterSkillTurn]);
        if (CharaterSkillTurn == 5)
        {
            CharaterSkillTurn = 0;
        }
        if (MonsterSkillTurn == 5)
        {
            MonsterSkillTurn = 0;
        }
        RandomCharaterDamage(PublicFunction.CharaterBattleSkillArray[CharaterSkillTurn], out CharaterAttackDamge);  //用來計算角色本次的傷害
        RandomMonsterDamage(MonsterStatic.MonsterSkill[MonsterSkillTurn], out MonsterAttackDamage);                 //用來計算怪物本次的傷害
        Debug.Log("角色本次傷害:" + CharaterAttackDamge);
        Debug.Log("怪物本次傷害:" + MonsterAttackDamage);
        if (BattleTime == CharaterBattleSkillTime[CharaterSkillTurn] && BattleTime != MonsterSkillTime[MonsterSkillTurn])                     //如果角色玩家可以攻擊，但怪獸無法攻擊的情況
        {          
            PublicFunctionClone.ReadSkill(PublicFunction.CharaterBattleSkillArray[CharaterSkillTurn]);   //再次讀取技能的內容，避免有技能內容讀取錯誤的問題
            Debug.Log("本次攻擊技能的編號:" + PublicFunction.CharaterBattleSkillArray[CharaterSkillTurn]);
            Debug.Log("此次角色使用技能所需的魔力數:" + SkillStatic.SkillCost[CharaterSkillLevel[CharaterSkillTurn]]);
            switch (CharaterPropertyStatic.CharaterMpNow > SkillStatic.SkillCost[CharaterSkillLevel[CharaterSkillTurn]])
            {
                case true:
                    {
                        CritChange(out CritSucces);
                        switch (CritSucces)
                        {
                            case true:
                                {
                                    CharaterAttackDamge = CharaterAttackDamge * 2;
                                    Debug.Log("角色攻擊成功造成爆擊，傷害兩倍，造成:" + CharaterAttackDamge + "傷害");
                                    CharaterAttackMonsterNot();        //角色進行攻擊，但怪物沒有的情況                                  
                                    break;
                                }
                            case false:
                                {
                                    CharaterAttackMonsterNot();        //角色進行攻擊，但怪物沒有的情況
                                    break;
                                }
                        }
                        break;
                    }
                case false:
                    {
                        Debug.Log("角色魔力不足以施放技能，本次攻擊失敗");
                        CharaterBattleSkillTime[CharaterSkillTurn] = CharaterBattleSkillTime[CharaterSkillTurn] + CharaterBattleSkillTimeAlways[PublicFunction.CharaterBattleSkillCount - 1];
                        Debug.Log("角色技能冷卻時間為:" + CharaterBattleSkillTime[CharaterSkillTurn]);
                        PlayerSkillCoolDown();
                        CharaterSkillTurn++;
                        if (CharaterSkillTurn >= 5)
                        {
                            CharaterSkillTurn = 0;
                        }
                        break;
                    }
            }
        }
        if (BattleTime != CharaterBattleSkillTime[CharaterSkillTurn] && BattleTime == MonsterSkillTime[MonsterSkillTurn])     //如果怪獸可以攻擊，但角色玩家無法攻擊的情況
        {
            PublicFunctionClone.ReadSkill(MonsterStatic.MonsterSkill[MonsterSkillTurn]);                 //再次讀取技能的內容，避免有技能內容讀取錯誤的問題
            switch (MonsterStatic.MonsterMpNow > SkillStatic.SkillCost[MonsterSkillLevel[MonsterSkillTurn]])
            {
                case true:
                    {
                        MonsterCritChange(out MonsterCritSucces);
                        switch (MonsterCritSucces)
                        {
                            case true:
                                {
                                    MonsterAttackDamage = MonsterAttackDamage * 2;
                                    Debug.Log("怪物攻擊成功造成爆擊，傷害兩倍，造成:" + MonsterAttackDamage + "傷害");
                                    MonsterAttackCharaterNot();
                                    break;
                                }
                            case false:
                                {
                                    MonsterAttackCharaterNot();
                                    break;
                                }
                        }
                        break;
                    }
                case false:
                    {
                        Debug.Log("怪物魔力不足以施放技能，本次攻擊失敗");
                        MonsterSkillTime[MonsterSkillTurn] = MonsterSkillTime[MonsterSkillTurn] + MonsterSkillTimeAlways[MonsterStatic.MonsterSkill.Length - 1];
                        Debug.Log("怪物技能冷卻時間為:" + MonsterSkillTime[MonsterSkillTurn]);
                        MonsterSkillCoolDown();
                        MonsterSkillTurn++;
                        if (MonsterSkillTurn >= 5)
                        {
                            MonsterSkillTurn = 0;
                        }
                        break;
                    }
            }
        }
        if (BattleTime == CharaterBattleSkillTime[CharaterSkillTurn] && BattleTime == MonsterSkillTime[MonsterSkillTurn])     //角色跟怪物互相攻擊
        {
            bool CharaterCanAttack = true;
            bool MonsterCanAttack = true;
            PublicFunctionClone.ReadSkill(PublicFunction.CharaterBattleSkillArray[CharaterSkillTurn]);
            switch (CharaterPropertyStatic.CharaterMpNow > SkillStatic.SkillCost[CharaterSkillLevel[CharaterSkillTurn]])
            {
                case true:
                    {
                        CharaterCanAttack = true;                       
                        break;
                    }
                case false:
                    {
                        CharaterCanAttack = false;
                        break;
                    }
            }
            PublicFunctionClone.ReadSkill(MonsterStatic.MonsterSkill[MonsterSkillTurn]);
            switch (MonsterStatic.MonsterMpNow > SkillStatic.SkillCost[MonsterSkillLevel[MonsterSkillTurn]])
            {
                case true:
                    {
                        MonsterCanAttack = true;
                        break;
                    }
                case false:
                    {
                        MonsterCanAttack = false;
                        break;
                    }
            }

            if (CharaterCanAttack == true && MonsterCanAttack == false)   //角色有足夠魔力可以攻擊，但怪物沒有
            {
                MonsterDodgeChange(out MonsterDodgeSucces);
                switch (MonsterDodgeSucces)
                {
                    case true:
                        {
                            Debug.Log("雙方互擊，角色有足夠魔力可以攻擊，但怪物沒有，而怪物成功閃躲角色攻擊!");
                            PublicFunctionClone.ReadSkill(PublicFunction.CharaterBattleSkillArray[CharaterSkillTurn]);
                            Debug.Log("此次角色使用技能所需的魔力數:" + SkillStatic.SkillCost[CharaterSkillLevel[CharaterSkillTurn]]);
                            CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMpNow - SkillStatic.SkillCost[CharaterSkillLevel[CharaterSkillTurn]];  //扣除角色發動技能的魔力
                            CharaterBattleSkillTime[CharaterSkillTurn] = CharaterBattleSkillTime[CharaterSkillTurn] + CharaterBattleSkillTimeAlways[PublicFunction.CharaterBattleSkillCount - 1];
                            PlayerSkillCoolDown();
                            CharaterSkillTurn++;
                            if (CharaterSkillTurn >= 5)
                            {
                                CharaterSkillTurn = 0;
                            }
                            PublicFunctionClone.ReadSkill(MonsterStatic.MonsterSkill[MonsterSkillTurn]);
                            MonsterSkillTime[MonsterSkillTurn] = MonsterSkillTime[MonsterSkillTurn] + MonsterSkillTimeAlways[MonsterStatic.MonsterSkill.Length - 1];
                            MonsterSkillCoolDown();
                            MonsterSkillTurn++;
                            if (MonsterSkillTurn >= 5)
                            {
                                MonsterSkillTurn = 0;
                            }
                            break;
                        }
                    case false:
                        {
                            CritChange(out CritSucces);
                            switch (CritSucces)
                            {
                                case true:
                                    {
                                        CharaterAttackDamge = CharaterAttackDamge * 2;
                                        Debug.Log("角色攻擊成功造成爆擊，傷害兩倍，造成:" + CharaterAttackDamge + "傷害");
                                        break;
                                    }
                                case false:
                                    {
                                        break;
                                    }
                            }
                            CharaterAndMonsterBothAttack(0);
                            break;
                        }
                }
            }
            if (CharaterCanAttack == true && MonsterCanAttack == true)    //雙方都有魔力可以造成傷害
            {
                DodgeChange(out DodgeSucces);
                MonsterDodgeChange(out MonsterDodgeSucces);
                if (DodgeSucces == true && MonsterDodgeSucces == false)       //角色閃避成功，怪物閃避失敗
                {
                    Debug.Log("雙方互擊，雙方都有足夠魔力可以攻擊，角色閃避成功，怪物閃避失敗");
                    CritChange(out CritSucces);
                    switch (CritSucces)
                    {
                        case true:
                            {
                                CharaterAttackDamge = CharaterAttackDamge * 2;
                                Debug.Log("角色攻擊成功造成爆擊，傷害兩倍，造成:" + CharaterAttackDamge + "傷害");
                                break;
                            }
                        case false:
                            {
                                break;
                            }
                    }
                    CharaterAndMonsterBothAttack(1);
                }
                if (DodgeSucces == true && MonsterDodgeSucces == true)         //雙方都閃避成功
                {
                    Debug.Log("雙方互擊，雙方都有足夠魔力可以攻擊，但雙方都閃避成功");
                    PublicFunctionClone.ReadSkill(PublicFunction.CharaterBattleSkillArray[CharaterSkillTurn]);
                    CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMpNow - SkillStatic.SkillCost[CharaterSkillLevel[CharaterSkillTurn]];  //扣除角色發動技能的魔力
                    CharaterBattleSkillTime[CharaterSkillTurn] = CharaterBattleSkillTime[CharaterSkillTurn] + CharaterBattleSkillTimeAlways[PublicFunction.CharaterBattleSkillCount - 1];
                    PlayerSkillCoolDown();
                    PlayerSkillCoolDown();
                    CharaterSkillTurn++;
                    if (CharaterSkillTurn >= 5)
                    {
                        CharaterSkillTurn = 0;
                    }
                    PublicFunctionClone.ReadSkill(MonsterStatic.MonsterSkill[MonsterSkillTurn]);
                    MonsterStatic.MonsterMpNow = MonsterStatic.MonsterMpNow - SkillStatic.SkillCost[MonsterSkillLevel[MonsterSkillTurn]];    //扣除怪獸發動技能的魔力
                    MonsterSkillTime[MonsterSkillTurn] = MonsterSkillTime[MonsterSkillTurn] + MonsterSkillTimeAlways[MonsterStatic.MonsterSkill.Length - 1];
                    MonsterSkillCoolDown();
                    MonsterSkillTurn++;
                    if (MonsterSkillTurn >= 5)
                    {
                        MonsterSkillTurn = 0;
                    }
                }
                if (DodgeSucces == false && MonsterDodgeSucces == true)        //角色閃避失敗，怪物閃避成功
                {
                    Debug.Log("雙方互擊，雙方都有足夠魔力可以攻擊，角色閃避失敗，怪物閃避成功");
                    MonsterCritChange(out MonsterCritSucces);
                    switch (MonsterCritSucces)
                    {
                        case true:
                            {
                                MonsterAttackDamage = MonsterAttackDamage * 2;
                                Debug.Log("怪物攻擊成功造成爆擊，傷害兩倍，造成:" + MonsterAttackDamage + "傷害");
                                break;
                            }
                        case false:
                            {
                                break;
                            }
                    }
                    CharaterAndMonsterBothAttack(2);
                }
                if (DodgeSucces == false && MonsterDodgeSucces == false)       //雙方都閃避失敗
                {
                    Debug.Log("雙方互擊，雙方都有足夠魔力可以攻擊，雙方都閃避失敗");
                    CritChange(out CritSucces);
                    switch (CritSucces)
                    {
                        case true:
                            {
                                CharaterAttackDamge = CharaterAttackDamge * 2;
                                Debug.Log("角色攻擊成功造成爆擊，傷害兩倍，造成:" + CharaterAttackDamge + "傷害");
                                break;
                            }
                        case false:
                            {
                                break;
                            }
                    }
                    MonsterCritChange(out MonsterCritSucces);
                    switch (MonsterCritSucces)
                    {
                        case true:
                            {
                                MonsterAttackDamage = MonsterAttackDamage * 2;
                                Debug.Log("怪物攻擊成功造成爆擊，傷害兩倍，造成:" + MonsterAttackDamage + "傷害");
                                break;
                            }
                        case false:
                            {
                                break;
                            }
                    }
                    CharaterAndMonsterBothAttack(3);
                }
            }
            if (CharaterCanAttack == false && MonsterCanAttack == true)
            {
                DodgeChange(out DodgeSucces);
                switch (DodgeSucces)
                {
                    case true:
                        {
                            Debug.Log("雙方互擊，怪物有足夠魔力可以攻擊，但角色沒有，而角色成功閃躲怪物攻擊!");
                            CharaterBattleSkillTime[CharaterSkillTurn] = CharaterBattleSkillTime[CharaterSkillTurn] + CharaterBattleSkillTimeAlways[PublicFunction.CharaterBattleSkillCount - 1];
                            PlayerSkillCoolDown();
                            CharaterSkillTurn++;
                            if (CharaterSkillTurn >= 5)
                            {
                                CharaterSkillTurn = 0;
                            }
                            MonsterSkillTime[MonsterSkillTurn] = MonsterSkillTime[MonsterSkillTurn] + MonsterSkillTimeAlways[MonsterStatic.MonsterSkill.Length - 1];
                            MonsterSkillCoolDown();
                            MonsterSkillTurn++;
                            if (MonsterSkillTurn >= 5)
                            {
                                MonsterSkillTurn = 0;
                            }
                            break;
                        }
                    case false:
                        {
                            MonsterCritChange(out MonsterCritSucces);
                            switch (MonsterCritSucces)
                            {
                                case true:
                                    {
                                        MonsterAttackDamage = MonsterAttackDamage * 2;
                                        Debug.Log("怪物攻擊成功造成爆擊，傷害兩倍，造成:" + MonsterAttackDamage + "傷害");
                                        break;
                                    }
                                case false:
                                    {
                                        break;
                                    }
                            }
                            CharaterAndMonsterBothAttack(4);
                            break;
                        }
                }
            }
            if (CharaterCanAttack == false && MonsterCanAttack == false)
            {
                Debug.Log("雙方互擊，雙方都沒有足夠魔力可以攻擊");
                CharaterBattleSkillTime[CharaterSkillTurn] = CharaterBattleSkillTime[CharaterSkillTurn] + CharaterBattleSkillTimeAlways[PublicFunction.CharaterBattleSkillCount - 1];
                PlayerSkillCoolDown();
                CharaterSkillTurn++;
                if (CharaterSkillTurn >= 5)
                {
                    CharaterSkillTurn = 0;
                }
                MonsterSkillTime[MonsterSkillTurn] = MonsterSkillTime[MonsterSkillTurn] + MonsterSkillTimeAlways[MonsterStatic.MonsterSkill.Length - 1];
                MonsterSkillCoolDown();
                MonsterSkillTurn++;
                if (MonsterSkillTurn >= 5)
                {
                    MonsterSkillTurn = 0;
                }

            }
        }

        SaveCharaterFile();
        CharaterAndMonsterHpMpMagicShieldRecover();
        BattleTime = BattleTime + 0.1f;
        Load_Time.text = BattleTime.ToString();
        string BattleString = BattleTime.ToString("0.0");
        PlayerSkillCountDown();
        MonsterSkillCountDown();
        BattleTime = float.Parse(BattleString);

        if (MonsterStatic.MonsterHpNow <= 0 && CharaterPropertyStatic.CharaterHpNow > 0)     //怪物血量歸零
        {
            Debug.Log("怪物血量歸零，此次戰鬥角色勝利，角色剩餘血量為:" + CharaterPropertyStatic.CharaterHpNow);
            BattleTime = 0;
            Load_Time.text = "0";
            BattleButtonSprite = BattleButton.GetComponent<Image>();
            BattleButtonSprite.sprite = SpriteAtlaseChange.GetSprite("button_ready_off");
            BlockButton.SetActive(false);
            MonsterDieCharaterGetItem();
            CharaterGetItem();
            MonsterDieArm();
            CharaterGetArm();
            JudgeArmItemNum();
            BattleReady();
            SaveCharaterFile();
            CancelInvoke("BattleStart");
        }
        if (CharaterPropertyStatic.CharaterHpNow <= 0 && MonsterStatic.MonsterHpNow > 0)   //角色血量歸零
        {
            Debug.Log("角色血量歸零，此次戰鬥怪物勝利，怪物剩餘血量為:" + MonsterStatic.MonsterHpNow);
            CharaterPropertyStatic.CharaterHpNow = 0;
            CharaterPropertyStatic.CharaterMpNow = 0;
            CharaterPropertyStatic.CharaterMagicShieldNow = 0;
            FlashCharaterInfo();
            BattleTime = 0;
            Load_Time.text = "0";
            BattleButtonSprite = BattleButton.GetComponent<Image>();
            BattleButtonSprite.sprite = SpriteAtlaseChange.GetSprite("button_ready_off");
            BlockButton.SetActive(false);
            Invoke("CharaterDie", 1);          
            SaveCharaterFile();
            CancelInvoke("BattleStart");
        }
        if (CharaterPropertyStatic.CharaterHpNow <= 0 && MonsterStatic.MonsterHpNow <= 0)   //角色跟怪物雙方同時歸零
        {
            Debug.Log("雙方同時血量歸零，判斷本次戰鬥角色未能勝利");
            CharaterPropertyStatic.CharaterHpNow = 0;
            CharaterPropertyStatic.CharaterMpNow = 0;
            CharaterPropertyStatic.CharaterMagicShieldNow = 0;
            FlashCharaterInfo();
            BattleTime = 0;
            Load_Time.text = "0";
            BattleButtonSprite = BattleButton.GetComponent<Image>();
            BattleButtonSprite.sprite = SpriteAtlaseChange.GetSprite("button_ready_off");
            BlockButton.SetActive(false);
            OpenMsgBoxClone.CreateMsgBox(32);
            SaveCharaterFile();
            CancelInvoke("BattleStart");
        }


        /*SaveCharaterFile();
        CharaterAndMonsterHpMpMagicShieldRecover();
        BattleTime = BattleTime + 0.1f;
        Load_Time.text = BattleTime.ToString();
        string BattleString = BattleTime.ToString("0.0");
        BattleTime = float.Parse(BattleString);*/
    }

    public void ReadCharaterSkillTime()                                                 //讀取角色所使用的技能施放技能時間
    {
        PublicFunctionClone.ReadCharaterBattleSkill();
        CharaterBattleSkillTime = new float[PublicFunction.CharaterBattleSkillCount];
        CharaterBattleSkillTimeAlways = new float[PublicFunction.CharaterBattleSkillCount];
        CharaterSkillLevel = new int[PublicFunction.CharaterBattleSkillCount];
        for (int Num = 0; Num < PublicFunction.CharaterBattleSkillCount; Num++)
        {
            PublicFunctionClone.ReadCharaterSkill(PublicFunction.CharaterBattleSkillArray[Num]);
            PublicFunctionClone.ReadSkill(CharaterSkillStatic.SkillId);
            CharaterBattleSkillTime[Num] = SkillStatic.SkillTime[CharaterSkillStatic.SkillLevel - 1];
            CharaterBattleSkillTimeAlways[Num] = SkillStatic.SkillTime[CharaterSkillStatic.SkillLevel - 1];
            CharaterSkillLevel[Num] = CharaterSkillStatic.SkillLevel;
        }
        for (int AddNum = 1; AddNum < PublicFunction.CharaterBattleSkillCount; AddNum++)
        {
            CharaterBattleSkillTime[AddNum] = CharaterBattleSkillTime[AddNum] + CharaterBattleSkillTime[AddNum - 1];
        }
        for (int NumAlways = 0; NumAlways < PublicFunction.CharaterBattleSkillCount; NumAlways++)
        {
            CharaterBattleSkillTimeAlways[NumAlways] = CharaterBattleSkillTime[NumAlways];
        }
        for(int SkillNum = 0; SkillNum < PublicFunction.CharaterBattleSkillCount; SkillNum++)
		{
            PublicFunctionClone.ReadSkill(PublicFunction.CharaterBattleSkillArray[SkillNum]);
            Debug.Log(SkillStatic.SkillICONName);
            switch (SkillNum)
            {
                case 0:
                    {
                        PlayerSkill_1.sprite = SpriteSkillIcon.GetSprite(SkillStatic.SkillICONName);
                        break;
                    }
                case 1:
                    {
                        PlayerSkill_2.sprite = SpriteSkillIcon.GetSprite(SkillStatic.SkillICONName);
                        break;
                    }
                case 2:
                    {
                        PlayerSkill_3.sprite = SpriteSkillIcon.GetSprite(SkillStatic.SkillICONName);
                        break;
                    }
                case 3:
                    {
                        PlayerSkill_4.sprite = SpriteSkillIcon.GetSprite(SkillStatic.SkillICONName);
                        break;
                    }
                case 4:
                    {
                        PlayerSkill_5.sprite = SpriteSkillIcon.GetSprite(SkillStatic.SkillICONName);
                        break;
                    }
            }
        }

        //-----顯示角色技能倒數
        PlayerSkillCount_1.text = CharaterBattleSkillTime[0] - BattleTime + "";
        PlayerSkillCount_2.text = CharaterBattleSkillTime[1] - BattleTime + "";
        PlayerSkillCount_3.text = CharaterBattleSkillTime[2] - BattleTime + "";
        PlayerSkillCount_4.text = CharaterBattleSkillTime[3] - BattleTime + "";
        PlayerSkillCount_5.text = CharaterBattleSkillTime[4] - BattleTime + "";

        //當作技能倒數的分母
        PlayerSkillCoolDown_1 = CharaterBattleSkillTime[0];
        PlayerSkillCoolDown_2 = CharaterBattleSkillTime[1];
        PlayerSkillCoolDown_3 = CharaterBattleSkillTime[2];
        PlayerSkillCoolDown_4 = CharaterBattleSkillTime[3];
        PlayerSkillCoolDown_5 = CharaterBattleSkillTime[4];
        //-----

        //-----顯示下一個要施放的技能
        PlayerHighLight_1.SetActive(true);
        PlayerHighLight_2.SetActive(false);
        PlayerHighLight_3.SetActive(false);
        PlayerHighLight_4.SetActive(false);
        PlayerHighLight_5.SetActive(false);
        //-----

        //-----顯示角色技能倒數的圖示
        PlayerSkillReady_1.fillAmount = 1;
        PlayerSkillReady_2.fillAmount = 1;
        PlayerSkillReady_3.fillAmount = 1;
        PlayerSkillReady_4.fillAmount = 1;
        PlayerSkillReady_5.fillAmount = 1;
        //-----
    }

    public void ReadMonsterSkillTime()                                                  //讀取怪物所使用的技能施放時間
    {
        MonsterSkillTime = new float[MonsterStatic.MonsterSkill.Length];
        MonsterSkillTimeAlways = new float[MonsterStatic.MonsterSkill.Length];
        MonsterSkillLevel = new int[MonsterStatic.MonsterSkill.Length];
        for (int Num = 0; Num < MonsterStatic.MonsterSkill.Length; Num++)
        {
            PublicFunctionClone.ReadSkill(MonsterStatic.MonsterSkill[Num]);
            MonsterSkillTime[Num] = SkillStatic.SkillTime[MonsterStatic.MonsterSkillLevel[Num] - 1];
            MonsterSkillTimeAlways[Num] = SkillStatic.SkillTime[MonsterStatic.MonsterSkillLevel[Num] - 1];
            MonsterSkillLevel[Num] = MonsterStatic.MonsterSkillLevel[Num];
        }
        for (int AddNum = 1; AddNum < MonsterStatic.MonsterSkill.Length; AddNum++)
        {
            MonsterSkillTime[AddNum] = MonsterSkillTime[AddNum] + MonsterSkillTime[AddNum - 1];
        }
        for (int NumAlways = 0; NumAlways < MonsterStatic.MonsterSkill.Length; NumAlways++)
        {
            MonsterSkillTimeAlways[NumAlways] = MonsterSkillTime[NumAlways];
        }
        for(int SkillNum = 0; SkillNum < MonsterStatic.MonsterSkill.Length; SkillNum++)
		{
            PublicFunctionClone.ReadSkill(MonsterStatic.MonsterSkill[SkillNum]);
            switch (SkillNum)
			{
                case 0:
					{
                        MonaterSkill_1.sprite = SpriteSkillIcon.GetSprite(SkillStatic.SkillICONName);
                        break;
					}
                case 1:
                    {
                        MonaterSkill_2.sprite = SpriteSkillIcon.GetSprite(SkillStatic.SkillICONName);
                        break;
                    }
                case 2:
                    {
                        MonaterSkill_3.sprite = SpriteSkillIcon.GetSprite(SkillStatic.SkillICONName);
                        break;
                    }
                case 3:
                    {
                        MonaterSkill_4.sprite = SpriteSkillIcon.GetSprite(SkillStatic.SkillICONName);
                        break;
                    }
                case 4:
                    {
                        MonaterSkill_5.sprite = SpriteSkillIcon.GetSprite(SkillStatic.SkillICONName);
                        break;
                    }
            }
		}

        //-----顯示怪獸技能倒數
        MonsterSkillCount_1.text = MonsterSkillTime[0] - BattleTime + "";
        MonsterSkillCount_2.text = MonsterSkillTime[1] - BattleTime + "";
        MonsterSkillCount_3.text = MonsterSkillTime[2] - BattleTime + "";
        MonsterSkillCount_4.text = MonsterSkillTime[3] - BattleTime + "";
        MonsterSkillCount_5.text = MonsterSkillTime[4] - BattleTime + "";

        //當作技能倒數的分母
        PlayerSkillCoolDown_1 = MonsterSkillTime[0];
        PlayerSkillCoolDown_2 = MonsterSkillTime[1];
        PlayerSkillCoolDown_3 = MonsterSkillTime[2];
        PlayerSkillCoolDown_4 = MonsterSkillTime[3];
        PlayerSkillCoolDown_5 = MonsterSkillTime[4];
        //-----

        //-----顯示下一個要施放的技能
        MonsterHighLight_1.SetActive(true);
        MonsterHighLight_2.SetActive(false);
        MonsterHighLight_3.SetActive(false);
        MonsterHighLight_4.SetActive(false);
        MonsterHighLight_5.SetActive(false);
        //----

        //-----顯示怪獸技能倒數的圖示
        MonsterSkillReady_1.fillAmount = 1;
        MonsterSkillReady_2.fillAmount = 1;
        MonsterSkillReady_3.fillAmount = 1;
        MonsterSkillReady_4.fillAmount = 1;
        MonsterSkillReady_5.fillAmount = 1;
        //-----
    }

    public void RandomCharaterDamage(int SkillId, out float AttackDamageCharater)       //計算角色造成的傷害
    {
        AttackDamageCharater = 0;  //暫代用，用來消除error
        PublicFunctionClone.ReadSkill(SkillId);
        switch (SkillStatic.SkillBattleType)
        {
            case 0:
                {
                    AttackDamageCharater = UnityEngine.Random.Range(CharaterPropertyStatic.CharaterPhysicalDamgeMin, CharaterPropertyStatic.CharaterPhysicalDamgeMax + 1);
                    AttackDamageCharater = AttackDamageCharater * (SkillStatic.SkillLevelNum[CharaterSkillLevel[CharaterSkillTurn]] / 100);
                    string AttackString = AttackDamageCharater.ToString("0.0");
                    AttackDamageCharater = float.Parse(AttackString);
                    break;
                }
            case 1:
                {
                    AttackDamageCharater = UnityEngine.Random.Range(CharaterPropertyStatic.CharaterMagicDamgeMin, CharaterPropertyStatic.CharaterMagicDamgeMax + 1);
                    AttackDamageCharater = AttackDamageCharater * (SkillStatic.SkillLevelNum[CharaterSkillLevel[CharaterSkillTurn]] / 100);
                    string AttackString = AttackDamageCharater.ToString("0.0");
                    AttackDamageCharater = float.Parse(AttackString);
                    break;
                }
        }
    }

    public void RandomMonsterDamage(int SkillId, out float AttackDamageMonster)         //計算怪物造成的傷害
    {
        AttackDamageMonster = 0;
        PublicFunctionClone.ReadSkill(SkillId);
        switch (SkillStatic.SkillBattleType)
        {
            case 0:
                {
                    AttackDamageMonster = UnityEngine.Random.Range(MonsterStatic.MonsterPhysicalDamgeMin, MonsterStatic.MonsterPhysicalDamgeMax + 1);
                    AttackDamageMonster = AttackDamageMonster * (SkillStatic.SkillLevelNum[MonsterSkillLevel[MonsterSkillTurn]] / 100);
                    string AttackString = AttackDamageMonster.ToString("0.0");
                    AttackDamageMonster = float.Parse(AttackString);
                    break;
                }
            case 1:
                {
                    AttackDamageMonster = UnityEngine.Random.Range(MonsterStatic.MonsterMagicDamgeMin, MonsterStatic.MonsterMagicDamgeMax + 1);
                    AttackDamageMonster = AttackDamageMonster * (SkillStatic.SkillLevelNum[MonsterSkillLevel[MonsterSkillTurn]] / 100);
                    string AttackString = AttackDamageMonster.ToString("0.0");
                    AttackDamageMonster = float.Parse(AttackString);
                    break;
                }
        }
    }

    public void CharaterAttackMonsterNot()                                              //角色進行攻擊，但怪物沒有的情況
    {
        Debug.Log("角色對怪物進行攻擊，戰鬥進行時間:" + BattleTime);
        MonsterDodgeChange(out MonsterDodgeSucces);
        switch (MonsterDodgeSucces)
        {
            case true:
                {
                    Debug.Log("怪物成功閃避掉角色的攻擊，並未受到任何傷害");
                    CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMpNow - SkillStatic.SkillCost[CharaterSkillLevel[CharaterSkillTurn]];  //扣除角色發動技能的魔力
                    CharaterBattleSkillTime[CharaterSkillTurn] = CharaterBattleSkillTime[CharaterSkillTurn] + CharaterBattleSkillTimeAlways[PublicFunction.CharaterBattleSkillCount - 1];
                    Debug.Log("角色施放完技能後的技能冷卻時間為:" + CharaterBattleSkillTime[CharaterSkillTurn]);
                    PlayerSkillCoolDown();
                    CharaterSkillTurn++;
                    if (CharaterSkillTurn >= 5)
                    {
                        CharaterSkillTurn = 0;
                    }
                    break;
                }
            case false:
                {
                    switch (SkillStatic.SkillBattleType)
                    {
                        case 0:
                            {
                                MonsterStatic.MonsterHpNow = MonsterStatic.MonsterHpNow - (CharaterAttackDamge * (1 - (MonsterStatic.MonsterPhysicalResistRate / 100)));
                                string HpNow = MonsterStatic.MonsterHpNow.ToString("0.0");
                                MonsterStatic.MonsterHpNow = float.Parse(HpNow);
                                Debug.Log("角色發動技能:" + SkillStatic.SkillName + "，對怪物造成物理攻擊:" + CharaterAttackDamge + "，怪物物理抵抗值為:" + MonsterStatic.MonsterPhysicalResistRate + "%，" + "怪物血量剩餘:" + MonsterStatic.MonsterHpNow + "戰鬥進行時間:" + BattleTime);
                                string skillname = SkillStatic.SkillName;
                                AttackNeedChant(0);
                                CharaterBattleSkillTime[CharaterSkillTurn] = CharaterBattleSkillTime[CharaterSkillTurn] + CharaterBattleSkillTimeAlways[PublicFunction.CharaterBattleSkillCount - 1];
                                Debug.Log("角色施放完技能後的技能冷卻時間為:" + CharaterBattleSkillTime[CharaterSkillTurn]);
                                PlayerSkillCoolDown();
                                CharaterSkillTurn++;
                                if (CharaterSkillTurn >= 5)
                                {
                                    CharaterSkillTurn = 0;
                                }
                                float ShowMonsterDamgeNum = (CharaterAttackDamge * (1 - (MonsterStatic.MonsterPhysicalResistRate / 100)));
                                ShowMonsterDamge(ShowMonsterDamgeNum, skillname);
                                FlashCharaterInfo();
                                FlashMonsterInfo();
                                SaveCharaterFile();
                                break;
                            }
                        case 1:
                            {
                                if (CharaterAttackDamge > MonsterStatic.MonsterMagicShieldNow)
                                {
                                    MonsterStatic.MonsterMagicShieldNow = MonsterStatic.MonsterMagicShieldNow - CharaterAttackDamge;
                                    MonsterStatic.MonsterHpNow = MonsterStatic.MonsterHpNow + MonsterStatic.MonsterMagicShieldNow;
                                    MonsterStatic.MonsterMagicShieldNow = 0;
                                    string HpNow = MonsterStatic.MonsterHpNow.ToString("0.0");
                                    MonsterStatic.MonsterHpNow = float.Parse(HpNow);
                                    Debug.Log("角色發動技能:" + SkillStatic.SkillName + "，對怪物造成魔法攻擊:" + CharaterAttackDamge + "，造成傷害大於怪物法術護盾值，怪物法術護盾剩餘:" + MonsterStatic.MonsterMagicShieldNow + "，怪物血量剩餘:" + MonsterStatic.MonsterHpNow + "戰鬥進行時間:" + BattleTime);
                                    CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMpNow - SkillStatic.SkillCost[CharaterSkillLevel[CharaterSkillTurn]];  //扣除角色發動技能的魔力
                                    AttackNeedChant(0);
                                    CharaterBattleSkillTime[CharaterSkillTurn] = CharaterBattleSkillTime[CharaterSkillTurn] + CharaterBattleSkillTimeAlways[PublicFunction.CharaterBattleSkillCount - 1];
                                    Debug.Log("角色施放完技能後的技能冷卻時間為:" + CharaterBattleSkillTime[CharaterSkillTurn]);
                                    PlayerSkillCoolDown();
                                    CharaterSkillTurn++;
                                    if (CharaterSkillTurn >= 5)
                                    {
                                        CharaterSkillTurn = 0;
                                    }
                                }
                                string skillname = SkillStatic.SkillName;
                                if (CharaterAttackDamge <= MonsterStatic.MonsterMagicShieldNow)
                                {
                                    MonsterStatic.MonsterMagicShieldNow = MonsterStatic.MonsterMagicShieldNow - CharaterAttackDamge;
                                    string MagicShieldNow = MonsterStatic.MonsterMagicShieldNow.ToString("0.0");
                                    MonsterStatic.MonsterMagicShieldNow = float.Parse(MagicShieldNow);
                                    Debug.Log("角色發動技能:" + SkillStatic.SkillName + "，對怪物造成魔法攻擊:" + CharaterAttackDamge + "，怪物法術護盾剩餘:" + MonsterStatic.MonsterMagicShieldNow + "，怪物血量剩餘:" + MonsterStatic.MonsterHpNow + "戰鬥進行時間:" + BattleTime);
                                    skillname = SkillStatic.SkillName;
                                    CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMpNow - SkillStatic.SkillCost[CharaterSkillLevel[CharaterSkillTurn]];  //扣除角色發動技能的魔力
                                    AttackNeedChant(0);
                                    CharaterBattleSkillTime[CharaterSkillTurn] = CharaterBattleSkillTime[CharaterSkillTurn] + CharaterBattleSkillTimeAlways[PublicFunction.CharaterBattleSkillCount - 1];
                                    Debug.Log("角色施放完技能後的技能冷卻時間為:" + CharaterBattleSkillTime[CharaterSkillTurn]);
                                    PlayerSkillCoolDown();
                                    CharaterSkillTurn++;
                                    if (CharaterSkillTurn >= 5)
                                    {
                                        CharaterSkillTurn = 0;
                                    }
                                }
                                ShowMonsterDamge(CharaterAttackDamge, skillname);
                                FlashCharaterInfo();
                                FlashMonsterInfo();
                                SaveCharaterFile();
                                break;
                            }
                    }
                    break;
                }
        }
    }

    public void MonsterAttackCharaterNot()                                              //怪物進行攻擊，但角色沒有的情況
    {
        Debug.Log("怪物對角色進行攻擊，戰鬥進行時間:" + BattleTime);
        DodgeChange(out DodgeSucces);
        switch (DodgeSucces)
        {
            case true:
                {
                    Debug.Log("角色成功閃避掉怪物的攻擊，並未受到任何傷害");
                    MonsterStatic.MonsterMpNow = MonsterStatic.MonsterMpNow - SkillStatic.SkillCost[MonsterSkillLevel[MonsterSkillTurn]];    //扣除怪獸發動技能的魔力
                    MonsterSkillTime[MonsterSkillTurn] = MonsterSkillTime[MonsterSkillTurn] + MonsterSkillTimeAlways[MonsterStatic.MonsterSkill.Length - 1];
                    Debug.Log("怪物施放完技能後的技能冷卻時間為:" + MonsterSkillTime[MonsterSkillTurn]);
                    MonsterSkillCoolDown();
                    MonsterSkillTurn++;
                    if (MonsterSkillTurn >= 5)
                    {
                        MonsterSkillTurn = 0;
                    }
                    break;
                }
            case false:
                {
                    switch (SkillStatic.SkillBattleType)
                    {
                        case 0:
                            {
                                CharaterPropertyStatic.CharaterHpNow = CharaterPropertyStatic.CharaterHpNow - (MonsterAttackDamage * (1 - (CharaterPropertyStatic.CharaterPhysicalResistRate / 100)));
                                string HpNow = CharaterPropertyStatic.CharaterHpNow.ToString("0.0");
                                CharaterPropertyStatic.CharaterHpNow = float.Parse(HpNow);                              
                                Debug.Log("怪物發動技能:" + SkillStatic.SkillName + "，對角色造成物理攻擊:" + MonsterAttackDamage + "，角色物理抵抗值為:" + CharaterPropertyStatic.CharaterPhysicalResistRate + "%，" + "角色血量剩餘:" + CharaterPropertyStatic.CharaterHpNow + "戰鬥進行時間:" + BattleTime);
                                string skillname = SkillStatic.SkillName;
                                MonsterStatic.MonsterMpNow = MonsterStatic.MonsterMpNow - SkillStatic.SkillCost[MonsterSkillLevel[MonsterSkillTurn]];    //扣除怪獸發動技能的魔力
                                AttackNeedChant(1);
                                MonsterSkillTime[MonsterSkillTurn] = MonsterSkillTime[MonsterSkillTurn] + MonsterSkillTimeAlways[MonsterStatic.MonsterSkill.Length - 1];
                                Debug.Log("怪物施放完技能後的技能冷卻時間為:" + MonsterSkillTime[MonsterSkillTurn]);
                                MonsterSkillCoolDown();
                                MonsterSkillTurn++;
                                if (MonsterSkillTurn >= 5)
                                {
                                    MonsterSkillTurn = 0;
                                }
                                float ShowCharaterDamgeNum = (MonsterAttackDamage * (1 - (CharaterPropertyStatic.CharaterPhysicalResistRate / 100)));
                                ShowCharaterDamge(ShowCharaterDamgeNum, skillname);
                                FlashCharaterInfo();
                                FlashMonsterInfo();
                                SaveCharaterFile();
                                break;
                            }
                        case 1:
                            {
                                if (MonsterAttackDamage > CharaterPropertyStatic.CharaterMagicShieldNow)
                                {
                                    CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShieldNow - MonsterAttackDamage;
                                    CharaterPropertyStatic.CharaterHpNow = CharaterPropertyStatic.CharaterHpNow + CharaterPropertyStatic.CharaterMagicShieldNow;
                                    CharaterPropertyStatic.CharaterMagicShieldNow = 0;
                                    string HpNow = CharaterPropertyStatic.CharaterHpNow.ToString("0.0");
                                    CharaterPropertyStatic.CharaterHpNow = float.Parse(HpNow);
                                    Debug.Log("怪物發動技能:" + SkillStatic.SkillName + "，對角色造成魔法攻擊:" + MonsterAttackDamage + "，造成傷害大於角色法術護盾值，角色法術護盾剩餘:" + CharaterPropertyStatic.CharaterMagicShieldNow + "，角色血量剩餘:" + CharaterPropertyStatic.CharaterHpNow + "戰鬥進行時間:" + BattleTime);
                                    MonsterStatic.MonsterMpNow = MonsterStatic.MonsterMpNow - SkillStatic.SkillCost[MonsterSkillLevel[MonsterSkillTurn]];    //扣除怪獸發動技能的魔力
                                    AttackNeedChant(1);
                                    MonsterSkillTime[MonsterSkillTurn] = MonsterSkillTime[MonsterSkillTurn] + MonsterSkillTimeAlways[MonsterStatic.MonsterSkill.Length - 1];
                                    Debug.Log("怪物施放完技能後的技能冷卻時間為:" + MonsterSkillTime[MonsterSkillTurn]);
                                    MonsterSkillCoolDown();
                                    MonsterSkillTurn++;
                                    if (MonsterSkillTurn >= 5)
                                    {
                                        MonsterSkillTurn = 0;
                                    }
                                }
                                string skillname = SkillStatic.SkillName;
                                if (MonsterAttackDamage <= CharaterPropertyStatic.CharaterMagicShieldNow)
                                {
                                    CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShieldNow - MonsterAttackDamage;
                                    string MagicShieldNow = CharaterPropertyStatic.CharaterMagicShieldNow.ToString("0.0");
                                    CharaterPropertyStatic.CharaterMagicShieldNow = float.Parse(MagicShieldNow);
                                    skillname = SkillStatic.SkillName;
                                    Debug.Log("怪物發動技能:" + SkillStatic.SkillName + "，對角色造成魔法攻擊:" + MonsterAttackDamage + "，角色法術護盾剩餘:" + CharaterPropertyStatic.CharaterMagicShieldNow + "，角色血量剩餘:" + CharaterPropertyStatic.CharaterHpNow + "戰鬥進行時間:" + BattleTime);
                                    MonsterStatic.MonsterMpNow = MonsterStatic.MonsterMpNow - SkillStatic.SkillCost[MonsterSkillLevel[MonsterSkillTurn]];    //扣除怪獸發動技能的魔力
                                    AttackNeedChant(1);
                                    MonsterSkillTime[MonsterSkillTurn] = MonsterSkillTime[MonsterSkillTurn] + MonsterSkillTimeAlways[MonsterStatic.MonsterSkill.Length - 1];
                                    Debug.Log("怪物施放完技能後的技能冷卻時間為:" + MonsterSkillTime[MonsterSkillTurn]);
                                    MonsterSkillCoolDown();
                                    MonsterSkillTurn++;
                                    if (MonsterSkillTurn >= 5)
                                    {
                                        MonsterSkillTurn = 0;
                                    }
                                }
                                ShowCharaterDamge(MonsterAttackDamage, skillname);
                                FlashCharaterInfo();
                                FlashMonsterInfo();
                                SaveCharaterFile();
                                break;
                            }
                    }
                    break;
                }
        }
    }

    public void AttackNeedChant(int AttackByWho)                                        //當詠唱時被攻擊，會造成詠唱增加時間
    {
        switch (AttackByWho)       //判斷是怪物被角色打，還是角色被怪物打
        {
            case 0:     //怪物被角色打
                {
                    PublicFunctionClone.ReadSkill(MonsterStatic.MonsterSkill[MonsterSkillTurn]);
                    switch (SkillStatic.SkillBattleType)
                    {
                        case 0:
                            {
                                break;
                            }
                        case 1:
                            {
                                for (int Num = 0; Num < MonsterStatic.MonsterSkill.Length; Num++)
                                {
                                    MonsterSkillTime[Num] = MonsterSkillTime[Num] + 1;
                                    Debug.Log("怪物在詠唱時被打斷!");
                                }
                                break;
                            }
                    }
                    break;
                }
            case 1:    //角色被怪物打
                {
                    PublicFunctionClone.ReadSkill(PublicFunction.CharaterBattleSkillArray[CharaterSkillTurn]);
                    switch (SkillStatic.SkillBattleType)
                    {
                        case 0:
                            {
                                break;
                            }
                        case 1:
                            {
                                for (int Num = 0; Num < PublicFunction.CharaterBattleSkillArray.Length; Num++)
                                {
                                    CharaterBattleSkillTime[Num] = CharaterBattleSkillTime[Num] + 1;
                                    Debug.Log("角色在詠唱時被打斷!");
                                }
                                break;
                            }
                    }
                    break;
                }
        }

    }

    public void CharaterAndMonsterHpMpMagicShieldRecover()                              //計算角色跟怪物的血量，魔力以及法術護盾回復
    {
        if (CharaterPropertyStatic.CharaterHpRecover > 0 && CharaterPropertyStatic.CharaterHpNow < CharaterPropertyStatic.CharaterHp)
        {
            string RecoverString = (CharaterPropertyStatic.CharaterHpRecover).ToString("0.0");
            string HpString = CharaterPropertyStatic.CharaterHpNow.ToString("0.0");
            float HpFloat = float.Parse(HpString);
            float RecoverFloat = float.Parse(RecoverString);
            CharaterPropertyStatic.CharaterHpNow = HpFloat + RecoverFloat;
            if (CharaterPropertyStatic.CharaterHpNow > CharaterPropertyStatic.CharaterHp)
            {
                CharaterPropertyStatic.CharaterHpNow = CharaterPropertyStatic.CharaterHp;
            }
            Debug.Log("角色血量每秒回復:" + CharaterPropertyStatic.CharaterHpRecover + "，目前角色血量為:" + CharaterPropertyStatic.CharaterHpNow);
        }
        if (CharaterPropertyStatic.CharaterMpRecover > 0 && CharaterPropertyStatic.CharaterMpNow < CharaterPropertyStatic.CharaterMp)
        {
            string RecoverString = (CharaterPropertyStatic.CharaterMpRecover).ToString("0.0");
            string MpString = CharaterPropertyStatic.CharaterMpNow.ToString("0.0");
            float RecoverFloat = float.Parse(RecoverString);
            float MpFloat = float.Parse(MpString);
            CharaterPropertyStatic.CharaterMpNow = MpFloat + RecoverFloat;
            if (CharaterPropertyStatic.CharaterMpNow > CharaterPropertyStatic.CharaterMp)
            {
                CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMp;
            }
            Debug.Log("角色魔力每秒回復:" + CharaterPropertyStatic.CharaterMpRecover + "，目前角色魔力為:" + CharaterPropertyStatic.CharaterMpNow);
        }
        if (CharaterPropertyStatic.CharaterMagicShieldRecover > 0 && CharaterPropertyStatic.CharaterMagicShieldNow < CharaterPropertyStatic.CharaterMagicShield)
        {
            string RecoverString = (CharaterPropertyStatic.CharaterMagicShieldRecover).ToString("0.0");
            string MagicShieldString = CharaterPropertyStatic.CharaterMagicShieldNow.ToString("0.0");
            float RecoverFloat = float.Parse(RecoverString);
            float MagicShieldFloat = float.Parse(MagicShieldString);
            CharaterPropertyStatic.CharaterMagicShieldNow = MagicShieldFloat + RecoverFloat;
            if (CharaterPropertyStatic.CharaterMagicShieldNow > CharaterPropertyStatic.CharaterMagicShield)
            {
                CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShield;
            }
            Debug.Log("角色法術護盾每秒回復:" + CharaterPropertyStatic.CharaterMagicShieldRecover + "，目前角色法術護盾為:" + CharaterPropertyStatic.CharaterMagicShieldNow);
        }

        if (MonsterStatic.MonsterHpRateRecover > 0 && MonsterStatic.MonsterHpNow < MonsterStatic.MonsterHp)
        {
            string RecoverString = (MonsterStatic.MonsterHp * (MonsterStatic.MonsterHpRateRecover / 1000)).ToString("0.0");
            string HpString = MonsterStatic.MonsterHpNow.ToString("0.0");
            float RecoverFloat = float.Parse(RecoverString);
            float HpFloat = float.Parse(HpString);
            MonsterStatic.MonsterHpNow = HpFloat + RecoverFloat;
            if (MonsterStatic.MonsterHpNow > MonsterStatic.MonsterHp)
            {
                MonsterStatic.MonsterHpNow = MonsterStatic.MonsterHp;
            }
            Debug.Log("怪物血量每秒回復:" + MonsterStatic.MonsterHpRateRecover + "，目前怪物血量為:" + MonsterStatic.MonsterHpNow);
        }
        if (MonsterStatic.MonsterMpRateRecover > 0 && MonsterStatic.MonsterMpNow < MonsterStatic.MonsterMp)
        {
            string RecoverString = (MonsterStatic.MonsterMp * (MonsterStatic.MonsterMpRateRecover / 1000)).ToString("0.0");
            string MpString = MonsterStatic.MonsterMpNow.ToString("0.0");
            float RecoverFloat = float.Parse(RecoverString);
            float MpFlaot = float.Parse(MpString);
            MonsterStatic.MonsterMpNow = MpFlaot + RecoverFloat;
            if (MonsterStatic.MonsterMpNow > MonsterStatic.MonsterMp)
            {
                MonsterStatic.MonsterMpNow = MonsterStatic.MonsterMp;
            }
            Debug.Log("怪物魔力每秒回復:" + MonsterStatic.MonsterMpRateRecover + "，目前怪物魔力為:" + MonsterStatic.MonsterMpNow);
        }
        if (MonsterStatic.MonsterMagicShieldRateRecover > 0 && MonsterStatic.MonsterMagicShieldNow < MonsterStatic.MonsterMagicShield)
        {
            string RecoverString = (MonsterStatic.MonsterMagicShield * (MonsterStatic.MonsterMagicShieldRateRecover / 1000)).ToString("0.0");
            string MagicShieldString = MonsterStatic.MonsterMagicShieldNow.ToString("0.0");
            float RecoverFloat = float.Parse(RecoverString);
            float MagicShieldFloat = float.Parse(MagicShieldString);
            MonsterStatic.MonsterMagicShieldNow = MagicShieldFloat + RecoverFloat;
            if (MonsterStatic.MonsterMagicShieldNow > MonsterStatic.MonsterMagicShield)
            {
                MonsterStatic.MonsterMagicShieldNow = MonsterStatic.MonsterMagicShield;
            }
            Debug.Log("怪物法術護盾每秒回復:" + MonsterStatic.MonsterMagicShieldRateRecover + "，目前怪物法術護盾為:" + MonsterStatic.MonsterMagicShieldNow);
        }
        FlashCharaterInfo();
        SaveCharaterFile();
    }

    public void CharaterAndMonsterBothAttack(int AttackNum)                             //計算角色跟怪物同時進行攻擊時的情況
    {
        /*
        AttackNum = 0 = 雙方互擊，角色有足夠魔力可以攻擊，但怪物沒有
        AttackNum = 1 = 雙方互擊，雙方都有足夠魔力可以攻擊，角色閃避成功，怪物閃避失敗
        AttackNum = 2 = 雙方互擊，雙方都有足夠魔力可以攻擊，角色閃避失敗，怪物閃避成功
        AttackNum = 3 = 雙方互擊，雙方都有足夠魔力可以攻擊，雙方都閃避失敗
        AttackNum = 4 = 雙方互擊，怪物有足夠魔力可以攻擊，但角色沒有
        */
        switch (AttackNum)
        {
            case 0:
                {
                    PublicFunctionClone.ReadSkill(PublicFunction.CharaterBattleSkillArray[CharaterSkillTurn]);
                    switch (SkillStatic.SkillBattleType)
                    {
                        case 0:
                            {
                                MonsterStatic.MonsterHpNow = MonsterStatic.MonsterHpNow - (CharaterAttackDamge * (1 - (MonsterStatic.MonsterPhysicalResistRate / 100)));
                                string HpNow = MonsterStatic.MonsterHpNow.ToString("0.0");
                                MonsterStatic.MonsterHpNow = float.Parse(HpNow);
                                Debug.Log("雙方互擊，角色有足夠魔力可以攻擊，但怪物沒有，所以角色發動技能:" + SkillStatic.SkillName + "對怪物造成物理攻擊: " + CharaterAttackDamge + "怪物物理抵抗值為: " + MonsterStatic.MonsterPhysicalResistRate + " %" + "怪物血量剩餘: " + MonsterStatic.MonsterHpNow + "戰鬥進行時間: " + BattleTime);
                                string skillname = SkillStatic.SkillName;
                                CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMpNow - SkillStatic.SkillCost[CharaterSkillLevel[CharaterSkillTurn]];  //扣除角色發動技能的魔力
                                CharaterBattleSkillTime[CharaterSkillTurn] = CharaterBattleSkillTime[CharaterSkillTurn] + CharaterBattleSkillTimeAlways[PublicFunction.CharaterBattleSkillCount - 1];
                                Debug.Log("角色施放完技能後的技能冷卻時間為:" + CharaterBattleSkillTime[CharaterSkillTurn]);
                                PlayerSkillCoolDown();
                                CharaterSkillTurn++;
                                if (CharaterSkillTurn >= 5)
                                {
                                    CharaterSkillTurn = 0;
                                }
                                MonsterSkillTime[MonsterSkillTurn] = MonsterSkillTime[MonsterSkillTurn] + MonsterSkillTimeAlways[MonsterStatic.MonsterSkill.Length - 1];
                                Debug.Log("怪物施放完技能後的技能冷卻時間為:" + MonsterSkillTime[MonsterSkillTurn]);
                                MonsterSkillCoolDown();
                                MonsterSkillTurn++;
                                if (MonsterSkillTurn >= 5)
                                {
                                    MonsterSkillTurn = 0;
                                }
                                float ShowMonsterDamgeNum = (CharaterAttackDamge * (1 - (MonsterStatic.MonsterPhysicalResistRate / 100)));
                                ShowMonsterDamge(ShowMonsterDamgeNum, skillname);
                                FlashCharaterInfo();
                                FlashMonsterInfo();
                                SaveCharaterFile();
                                break;
                            }
                        case 1:
                            {
                                if (CharaterAttackDamge > MonsterStatic.MonsterMagicShieldNow)
                                {
                                    MonsterStatic.MonsterMagicShieldNow = MonsterStatic.MonsterMagicShieldNow - CharaterAttackDamge;
                                    MonsterStatic.MonsterHpNow = MonsterStatic.MonsterHpNow + MonsterStatic.MonsterMagicShieldNow;
                                    MonsterStatic.MonsterMagicShieldNow = 0;
                                    string HpNow = MonsterStatic.MonsterHpNow.ToString("0.0");
                                    MonsterStatic.MonsterHpNow = float.Parse(HpNow);
                                    Debug.Log("雙方互擊，角色有足夠魔力可以攻擊，但怪物沒有，所以角色發動技能:" + SkillStatic.SkillName + "對怪物造成魔法攻擊:" + CharaterAttackDamge + "造成傷害大於怪物法術護盾值，怪物法術護盾剩餘:" + MonsterStatic.MonsterMagicShieldNow + "，怪物血量剩餘:" + MonsterStatic.MonsterHpNow + "戰鬥進行時間:" + BattleTime);
                                    CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMpNow - SkillStatic.SkillCost[CharaterSkillLevel[CharaterSkillTurn]];  //扣除角色發動技能的魔力
                                    CharaterBattleSkillTime[CharaterSkillTurn] = CharaterBattleSkillTime[CharaterSkillTurn] + CharaterBattleSkillTimeAlways[PublicFunction.CharaterBattleSkillCount - 1];
                                    Debug.Log("角色施放完技能後的技能冷卻時間為:" + CharaterBattleSkillTime[CharaterSkillTurn]);
                                    PlayerSkillCoolDown();
                                    CharaterSkillTurn++;
                                    if (CharaterSkillTurn >= 5)
                                    {
                                        CharaterSkillTurn = 0;
                                    }
                                    MonsterSkillTime[MonsterSkillTurn] = MonsterSkillTime[MonsterSkillTurn] + MonsterSkillTimeAlways[MonsterStatic.MonsterSkill.Length - 1];
                                    Debug.Log("怪物施放完技能後的技能冷卻時間為:" + MonsterSkillTime[MonsterSkillTurn]);
                                    MonsterSkillCoolDown();
                                    MonsterSkillTurn++;
                                    if (MonsterSkillTurn >= 5)
                                    {
                                        MonsterSkillTurn = 0;
                                    }
                                }
                                string skillname = SkillStatic.SkillName;
                                if (CharaterAttackDamge <= MonsterStatic.MonsterMagicShieldNow)
                                {
                                    MonsterStatic.MonsterMagicShieldNow = MonsterStatic.MonsterMagicShieldNow - CharaterAttackDamge;
                                    string MagicShield = MonsterStatic.MonsterMagicShieldNow.ToString("0.0");
                                    MonsterStatic.MonsterMagicShieldNow = float.Parse(MagicShield);
                                    Debug.Log("雙方互擊，角色有足夠魔力可以攻擊，但怪物沒有，所以角色發動技能:" + SkillStatic.SkillName + "對怪物造成魔法攻擊:" + CharaterAttackDamge + "怪物法術護盾剩餘:" + MonsterStatic.MonsterMagicShieldNow + "怪物血量剩餘:" + MonsterStatic.MonsterHpNow + "戰鬥進行時間:" + BattleTime);
                                    skillname = SkillStatic.SkillName;
                                    CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMpNow - SkillStatic.SkillCost[CharaterSkillLevel[CharaterSkillTurn]];  //扣除角色發動技能的魔力
                                    CharaterBattleSkillTime[CharaterSkillTurn] = CharaterBattleSkillTime[CharaterSkillTurn] + CharaterBattleSkillTimeAlways[PublicFunction.CharaterBattleSkillCount - 1];
                                    Debug.Log("角色施放完技能後的技能冷卻時間為:" + CharaterBattleSkillTime[CharaterSkillTurn]);
                                    PlayerSkillCoolDown();
                                    CharaterSkillTurn++;
                                    if (CharaterSkillTurn >= 5)
                                    {
                                        CharaterSkillTurn = 0;
                                    }
                                    MonsterSkillTime[MonsterSkillTurn] = MonsterSkillTime[MonsterSkillTurn] + MonsterSkillTimeAlways[MonsterStatic.MonsterSkill.Length - 1];
                                    Debug.Log("怪物施放完技能後的技能冷卻時間為:" + MonsterSkillTime[MonsterSkillTurn]);
                                    MonsterSkillCoolDown();
                                    MonsterSkillTurn++;
                                    if (MonsterSkillTurn >= 5)
                                    {
                                        MonsterSkillTurn = 0;
                                    }
                                }
                                ShowMonsterDamge(CharaterAttackDamge, skillname);
                                FlashCharaterInfo();
                                FlashMonsterInfo();
                                SaveCharaterFile();
                                break;
                            }
                    }
                    break;
                }
            case 1:
                {
                    PublicFunctionClone.ReadSkill(PublicFunction.CharaterBattleSkillArray[CharaterSkillTurn]);
                    switch (SkillStatic.SkillBattleType)
                    {
                        case 0:
                            {
                                MonsterStatic.MonsterHpNow = MonsterStatic.MonsterHpNow - (CharaterAttackDamge * (1 - (MonsterStatic.MonsterPhysicalResistRate / 100)));
                                string HpNow = MonsterStatic.MonsterHpNow.ToString("0.0");
                                MonsterStatic.MonsterHpNow = float.Parse(HpNow);
                                Debug.Log("雙方互擊，雙方都有足夠魔力可以攻擊，角色閃避成功，怪物閃避失敗，所以角色發動技能:" + SkillStatic.SkillName + "對怪物造成物理攻擊: " + CharaterAttackDamge + "怪物物理抵抗值為: " + MonsterStatic.MonsterPhysicalResistRate + " %" + "怪物血量剩餘: " + MonsterStatic.MonsterHpNow + "戰鬥進行時間: " + BattleTime);
                                string skillname = SkillStatic.SkillName;
                                CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMpNow - SkillStatic.SkillCost[CharaterSkillLevel[CharaterSkillTurn]];  //扣除角色發動技能的魔力
                                CharaterBattleSkillTime[CharaterSkillTurn] = CharaterBattleSkillTime[CharaterSkillTurn] + CharaterBattleSkillTimeAlways[PublicFunction.CharaterBattleSkillCount - 1];
                                Debug.Log("角色施放完技能後的技能冷卻時間為:" + CharaterBattleSkillTime[CharaterSkillTurn]);
                                PlayerSkillCoolDown();
                                CharaterSkillTurn++;
                                if (CharaterSkillTurn >= 5)
                                {
                                    CharaterSkillTurn = 0;
                                }
                                PublicFunctionClone.ReadSkill(MonsterStatic.MonsterSkill[MonsterSkillTurn]);
                                MonsterStatic.MonsterMpNow = MonsterStatic.MonsterMpNow - SkillStatic.SkillCost[MonsterSkillLevel[MonsterSkillTurn]];    //扣除怪獸發動技能的魔力
                                MonsterSkillTime[MonsterSkillTurn] = MonsterSkillTime[MonsterSkillTurn] + MonsterSkillTimeAlways[MonsterStatic.MonsterSkill.Length - 1];
                                Debug.Log("怪物施放完技能後的技能冷卻時間為:" + MonsterSkillTime[MonsterSkillTurn]);
                                MonsterSkillCoolDown();
                                MonsterSkillTurn++;
                                if (MonsterSkillTurn >= 5)
                                {
                                    MonsterSkillTurn = 0;
                                }
                                float ShowMonsterDamgeNum = (CharaterAttackDamge * (1 - (MonsterStatic.MonsterPhysicalResistRate / 100)));
                                ShowMonsterDamge(ShowMonsterDamgeNum, skillname);
                                FlashCharaterInfo();
                                FlashMonsterInfo();
                                SaveCharaterFile();
                                break;
                            }
                        case 1:
                            {
                                if (CharaterAttackDamge > MonsterStatic.MonsterMagicShieldNow)
                                {
                                    MonsterStatic.MonsterMagicShieldNow = MonsterStatic.MonsterMagicShieldNow - CharaterAttackDamge;
                                    MonsterStatic.MonsterHpNow = MonsterStatic.MonsterHpNow + MonsterStatic.MonsterMagicShieldNow;
                                    MonsterStatic.MonsterMagicShieldNow = 0;
                                    string HpNow = MonsterStatic.MonsterHpNow.ToString("0.0");
                                    MonsterStatic.MonsterHpNow = float.Parse(HpNow);
                                    Debug.Log("雙方互擊，雙方都有足夠魔力可以攻擊，角色閃避成功，怪物閃避失敗，所以角色發動技能:" + SkillStatic.SkillName + "對怪物造成魔法攻擊:" + CharaterAttackDamge + "造成傷害大於怪物法術護盾值，怪物法術護盾剩餘:" + MonsterStatic.MonsterMagicShieldNow + "，怪物血量剩餘:" + MonsterStatic.MonsterHpNow + "戰鬥進行時間:" + BattleTime);
                                    CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMpNow - SkillStatic.SkillCost[CharaterSkillLevel[CharaterSkillTurn]];  //扣除角色發動技能的魔力
                                    CharaterBattleSkillTime[CharaterSkillTurn] = CharaterBattleSkillTime[CharaterSkillTurn] + CharaterBattleSkillTimeAlways[PublicFunction.CharaterBattleSkillCount - 1];
                                    Debug.Log("角色施放完技能後的技能冷卻時間為:" + CharaterBattleSkillTime[CharaterSkillTurn]);
                                    PlayerSkillCoolDown();
                                    CharaterSkillTurn++;
                                    if (CharaterSkillTurn >= 5)
                                    {
                                        CharaterSkillTurn = 0;
                                    }
                                    PublicFunctionClone.ReadSkill(MonsterStatic.MonsterSkill[MonsterSkillTurn]);
                                    MonsterStatic.MonsterMpNow = MonsterStatic.MonsterMpNow - SkillStatic.SkillCost[MonsterSkillLevel[MonsterSkillTurn]];    //扣除怪獸發動技能的魔力
                                    MonsterSkillTime[MonsterSkillTurn] = MonsterSkillTime[MonsterSkillTurn] + MonsterSkillTimeAlways[MonsterStatic.MonsterSkill.Length - 1];
                                    Debug.Log("怪物施放完技能後的技能冷卻時間為:" + MonsterSkillTime[MonsterSkillTurn]);
                                    MonsterSkillCoolDown();
                                    MonsterSkillTurn++;
                                    if (MonsterSkillTurn >= 5)
                                    {
                                        MonsterSkillTurn = 0;
                                    }
                                }
                                string skillname = SkillStatic.SkillName;
                                if (CharaterAttackDamge <= MonsterStatic.MonsterMagicShieldNow)
                                {
                                    MonsterStatic.MonsterMagicShieldNow = MonsterStatic.MonsterMagicShieldNow - CharaterAttackDamge;
                                    string MagicShield = MonsterStatic.MonsterMagicShieldNow.ToString("0.0");
                                    MonsterStatic.MonsterMagicShieldNow = float.Parse(MagicShield);
                                    Debug.Log("雙方互擊，雙方都有足夠魔力可以攻擊，角色閃避成功，怪物閃避失敗，所以角色發動技能:" + SkillStatic.SkillName + "對怪物造成魔法攻擊:" + CharaterAttackDamge + "怪物法術護盾剩餘:" + MonsterStatic.MonsterMagicShieldNow + "怪物血量剩餘:" + MonsterStatic.MonsterHpNow + "戰鬥進行時間:" + BattleTime);
                                    skillname = SkillStatic.SkillName;
                                    CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMpNow - SkillStatic.SkillCost[CharaterSkillLevel[CharaterSkillTurn]];  //扣除角色發動技能的魔力
                                    CharaterBattleSkillTime[CharaterSkillTurn] = CharaterBattleSkillTime[CharaterSkillTurn] + CharaterBattleSkillTimeAlways[PublicFunction.CharaterBattleSkillCount - 1];
                                    Debug.Log("角色施放完技能後的技能冷卻時間為:" + CharaterBattleSkillTime[CharaterSkillTurn]);
                                    PlayerSkillCoolDown();
                                    CharaterSkillTurn++;
                                    if (CharaterSkillTurn >= 5)
                                    {
                                        CharaterSkillTurn = 0;
                                    }
                                    PublicFunctionClone.ReadSkill(MonsterStatic.MonsterSkill[MonsterSkillTurn]);
                                    MonsterStatic.MonsterMpNow = MonsterStatic.MonsterMpNow - SkillStatic.SkillCost[MonsterSkillLevel[MonsterSkillTurn]];    //扣除怪獸發動技能的魔力
                                    MonsterSkillTime[MonsterSkillTurn] = MonsterSkillTime[MonsterSkillTurn] + MonsterSkillTimeAlways[MonsterStatic.MonsterSkill.Length - 1];
                                    Debug.Log("怪物施放完技能後的技能冷卻時間為:" + MonsterSkillTime[MonsterSkillTurn]);
                                    MonsterSkillCoolDown();
                                    MonsterSkillTurn++;
                                    if (MonsterSkillTurn >= 5)
                                    {
                                        MonsterSkillTurn = 0;
                                    }
                                }
                                ShowMonsterDamge(CharaterAttackDamge, skillname);
                                FlashCharaterInfo();
                                FlashMonsterInfo();
                                SaveCharaterFile();
                                break;
                            }
                    }
                    break;
                }
            case 2:
                {
                    PublicFunctionClone.ReadSkill(MonsterStatic.MonsterSkill[MonsterSkillTurn]);
                    switch (SkillStatic.SkillBattleType)
                    {
                        case 0:
                            {
                                CharaterPropertyStatic.CharaterHpNow = CharaterPropertyStatic.CharaterHpNow - (MonsterAttackDamage * (1 - (CharaterPropertyStatic.CharaterPhysicalResistRate / 100)));
                                string HpNow = CharaterPropertyStatic.CharaterHpNow.ToString("0.0");
                                CharaterPropertyStatic.CharaterHpNow = float.Parse(HpNow);
                                string skillname = SkillStatic.SkillName;
                                Debug.Log("雙方互擊，雙方都有足夠魔力可以攻擊，角色閃避失敗，怪物閃避成功，所以怪物發動技能:" + SkillStatic.SkillName + "對角色造成物理攻擊:" + MonsterAttackDamage + "角色物理抵抗值為:" + CharaterPropertyStatic.CharaterPhysicalResistRate + "%" + "角色血量剩餘:" + CharaterPropertyStatic.CharaterHpNow + "戰鬥進行時間:" + BattleTime);
                                MonsterStatic.MonsterMpNow = MonsterStatic.MonsterMpNow - SkillStatic.SkillCost[MonsterSkillLevel[MonsterSkillTurn]];    //扣除怪獸發動技能的魔力
                                MonsterSkillTime[MonsterSkillTurn] = MonsterSkillTime[MonsterSkillTurn] + MonsterSkillTimeAlways[MonsterStatic.MonsterSkill.Length - 1];
                                Debug.Log("怪物施放完技能後的技能冷卻時間為:" + MonsterSkillTime[MonsterSkillTurn]);
                                MonsterSkillCoolDown();
                                MonsterSkillTurn++;
                                if (MonsterSkillTurn >= 5)
                                {
                                    MonsterSkillTurn = 0;
                                }
                                PublicFunctionClone.ReadSkill(PublicFunction.CharaterBattleSkillArray[CharaterSkillTurn]);
                                CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMpNow - SkillStatic.SkillCost[CharaterSkillLevel[CharaterSkillTurn]];  //扣除角色發動技能的魔力
                                CharaterBattleSkillTime[CharaterSkillTurn] = CharaterBattleSkillTime[CharaterSkillTurn] + CharaterBattleSkillTimeAlways[PublicFunction.CharaterBattleSkillCount - 1];
                                Debug.Log("角色施放完技能後的技能冷卻時間為:" + CharaterBattleSkillTime[CharaterSkillTurn]);
                                PlayerSkillCoolDown();
                                CharaterSkillTurn++;
                                if (CharaterSkillTurn >= 5)
                                {
                                    CharaterSkillTurn = 0;
                                }
                                float ShowCharaterDamgeNum = (MonsterAttackDamage * (1 - (CharaterPropertyStatic.CharaterPhysicalResistRate / 100)));
                                ShowCharaterDamge(ShowCharaterDamgeNum, skillname);
                                FlashCharaterInfo();
                                FlashMonsterInfo();
                                SaveCharaterFile();
                                break;
                            }
                        case 1:
                            {
                                if (MonsterAttackDamage > CharaterPropertyStatic.CharaterMagicShieldNow)
                                {
                                    CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShieldNow - MonsterAttackDamage;
                                    CharaterPropertyStatic.CharaterHpNow = CharaterPropertyStatic.CharaterHpNow + CharaterPropertyStatic.CharaterMagicShieldNow;
                                    CharaterPropertyStatic.CharaterMagicShieldNow = 0;
                                    string HpNow = CharaterPropertyStatic.CharaterHpNow.ToString("0.0");
                                    CharaterPropertyStatic.CharaterHpNow = float.Parse(HpNow);
                                    Debug.Log("雙方互擊，雙方都有足夠魔力可以攻擊，角色閃避失敗，怪物閃避成功，所以怪物發動技能:" + SkillStatic.SkillName + "對角色造成魔法攻擊:" + MonsterAttackDamage + "造成傷害大於角色法術護盾值，角色法術護盾剩餘:" + CharaterPropertyStatic.CharaterMagicShieldNow + "角色血量剩餘:" + CharaterPropertyStatic.CharaterHpNow + "戰鬥進行時間:" + BattleTime);
                                    MonsterStatic.MonsterMpNow = MonsterStatic.MonsterMpNow - SkillStatic.SkillCost[MonsterSkillLevel[MonsterSkillTurn]];    //扣除怪獸發動技能的魔力
                                    MonsterSkillTime[MonsterSkillTurn] = MonsterSkillTime[MonsterSkillTurn] + MonsterSkillTimeAlways[MonsterStatic.MonsterSkill.Length - 1];
                                    Debug.Log("怪物施放完技能後的技能冷卻時間為:" + MonsterSkillTime[MonsterSkillTurn]);
                                    MonsterSkillCoolDown();
                                    MonsterSkillTurn++;
                                    if (MonsterSkillTurn >= 5)
                                    {
                                        MonsterSkillTurn = 0;
                                    }
                                    PublicFunctionClone.ReadSkill(PublicFunction.CharaterBattleSkillArray[CharaterSkillTurn]);
                                    CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMpNow - SkillStatic.SkillCost[CharaterSkillLevel[CharaterSkillTurn]];  //扣除角色發動技能的魔力
                                    CharaterBattleSkillTime[CharaterSkillTurn] = CharaterBattleSkillTime[CharaterSkillTurn] + CharaterBattleSkillTimeAlways[PublicFunction.CharaterBattleSkillCount - 1];
                                    Debug.Log("角色施放完技能後的技能冷卻時間為:" + CharaterBattleSkillTime[CharaterSkillTurn]);
                                    PlayerSkillCoolDown();
                                    CharaterSkillTurn++;
                                    if (CharaterSkillTurn >= 5)
                                    {
                                        CharaterSkillTurn = 0;
                                    }
                                }
                                string skillname = SkillStatic.SkillName;
                                if (MonsterAttackDamage <= CharaterPropertyStatic.CharaterMagicShieldNow)
                                {
                                    CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShieldNow - MonsterAttackDamage;
                                    string MagicShieldNow = CharaterPropertyStatic.CharaterMagicShieldNow.ToString("0.0");
                                    CharaterPropertyStatic.CharaterMagicShieldNow = float.Parse(MagicShieldNow);
                                    skillname = SkillStatic.SkillName;
                                    Debug.Log("雙方互擊，雙方都有足夠魔力可以攻擊，角色閃避失敗，怪物閃避成功，所以怪物發動技能:" + SkillStatic.SkillName + "對角色造成魔法攻擊:" + MonsterAttackDamage + "角色法術護盾剩餘:" + CharaterPropertyStatic.CharaterMagicShieldNow + "角色血量剩餘:" + CharaterPropertyStatic.CharaterHpNow + "戰鬥進行時間:" + BattleTime);
                                    MonsterStatic.MonsterMpNow = MonsterStatic.MonsterMpNow - SkillStatic.SkillCost[MonsterSkillLevel[MonsterSkillTurn]];    //扣除怪獸發動技能的魔力
                                    MonsterSkillTime[MonsterSkillTurn] = MonsterSkillTime[MonsterSkillTurn] + MonsterSkillTimeAlways[MonsterStatic.MonsterSkill.Length - 1];
                                    Debug.Log("怪物施放完技能後的技能冷卻時間為:" + MonsterSkillTime[MonsterSkillTurn]);
                                    MonsterSkillCoolDown();
                                    MonsterSkillTurn++;
                                    if (MonsterSkillTurn >= 5)
                                    {
                                        MonsterSkillTurn = 0;
                                    }
                                    PublicFunctionClone.ReadSkill(PublicFunction.CharaterBattleSkillArray[CharaterSkillTurn]);
                                    CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMpNow - SkillStatic.SkillCost[CharaterSkillLevel[CharaterSkillTurn]];  //扣除角色發動技能的魔力
                                    CharaterBattleSkillTime[CharaterSkillTurn] = CharaterBattleSkillTime[CharaterSkillTurn] + CharaterBattleSkillTimeAlways[PublicFunction.CharaterBattleSkillCount - 1];
                                    Debug.Log("角色施放完技能後的技能冷卻時間為:" + CharaterBattleSkillTime[CharaterSkillTurn]);
                                    PlayerSkillCoolDown();
                                    CharaterSkillTurn++;
                                    if (CharaterSkillTurn >= 5)
                                    {
                                        CharaterSkillTurn = 0;
                                    }
                                }
                                ShowCharaterDamge(MonsterAttackDamage, skillname);
                                FlashCharaterInfo();
                                FlashMonsterInfo();
                                SaveCharaterFile();
                                break;
                            }
                    }
                    break;
                }
            case 3:
                {
                    int AttackNow = 0;
                    if (CharaterAttackDamge == MonsterAttackDamage)
                    {
                        AttackNow = 0;
                    }
                    if (CharaterAttackDamge > MonsterAttackDamage)
                    {
                        AttackNow = 1;
                    }
                    if (CharaterAttackDamge < MonsterAttackDamage)
                    {
                        AttackNow = 2;
                    }
                    switch (AttackNow)
                    {
                        case 0:
                            {
                                Debug.Log("雙方互擊，並且造成傷害相同，故雙方無受損");
                                PublicFunctionClone.ReadSkill(PublicFunction.CharaterBattleSkillArray[CharaterSkillTurn]);
                                CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMpNow - SkillStatic.SkillCost[CharaterSkillLevel[CharaterSkillTurn]];  //扣除角色發動技能的魔力
                                CharaterBattleSkillTime[CharaterSkillTurn] = CharaterBattleSkillTime[CharaterSkillTurn] + CharaterBattleSkillTimeAlways[PublicFunction.CharaterBattleSkillCount - 1];
                                PlayerSkillCoolDown();
                                CharaterSkillTurn++;
                                if (CharaterSkillTurn >= 5)
                                {
                                    CharaterSkillTurn = 0;
                                }
                                PublicFunctionClone.ReadSkill(MonsterStatic.MonsterSkill[MonsterSkillTurn]);
                                MonsterStatic.MonsterMpNow = MonsterStatic.MonsterMpNow - SkillStatic.SkillCost[MonsterSkillLevel[MonsterSkillTurn]];    //扣除怪獸發動技能的魔力
                                MonsterSkillTime[MonsterSkillTurn] = MonsterSkillTime[MonsterSkillTurn] + MonsterSkillTimeAlways[MonsterStatic.MonsterSkill.Length - 1];
                                MonsterSkillCoolDown();
                                MonsterSkillTurn++;
                                if (MonsterSkillTurn >= 5)
                                {
                                    MonsterSkillTurn = 0;
                                }
                                break;
                            }
                        case 1:
                            {
                                CharaterAttackDamge = CharaterAttackDamge - MonsterAttackDamage;
                                PublicFunctionClone.ReadSkill(PublicFunction.CharaterBattleSkillArray[CharaterSkillTurn]);
                                switch (SkillStatic.SkillBattleType)
                                {
                                    case 0:
                                        {
                                            MonsterStatic.MonsterHpNow = MonsterStatic.MonsterHpNow - (CharaterAttackDamge * (1 - (MonsterStatic.MonsterPhysicalResistRate / 100)));
                                            string HpNow = MonsterStatic.MonsterHpNow.ToString("0.0");
                                            MonsterStatic.MonsterHpNow = float.Parse(HpNow);
                                            Debug.Log("雙方互擊，雙方都有足夠魔力可以攻擊，雙方都閃避失敗，角色造成的傷害比怪物高，所以角色發動技能:" + SkillStatic.SkillName + "對怪物造成物理攻擊:" + CharaterAttackDamge + "怪物物理抵抗值為:" + MonsterStatic.MonsterPhysicalResistRate + "%" + "怪物血量剩餘:" + MonsterStatic.MonsterHpNow + "戰鬥進行時間:" + BattleTime);
                                            PublicFunctionClone.ReadSkill(PublicFunction.CharaterBattleSkillArray[CharaterSkillTurn]);
                                            string skillname = SkillStatic.SkillName;
                                            CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMpNow - SkillStatic.SkillCost[CharaterSkillLevel[CharaterSkillTurn]];  //扣除角色發動技能的魔力
                                            CharaterBattleSkillTime[CharaterSkillTurn] = CharaterBattleSkillTime[CharaterSkillTurn] + CharaterBattleSkillTimeAlways[PublicFunction.CharaterBattleSkillCount - 1];
                                            Debug.Log("角色施放完技能後的技能冷卻時間為:" + CharaterBattleSkillTime[CharaterSkillTurn]);
                                            PlayerSkillCoolDown();
                                            CharaterSkillTurn++;
                                            if (CharaterSkillTurn >= 5)
                                            {
                                                CharaterSkillTurn = 0;
                                            }
                                            PublicFunctionClone.ReadSkill(MonsterStatic.MonsterSkill[MonsterSkillTurn]);
                                            MonsterStatic.MonsterMpNow = MonsterStatic.MonsterMpNow - SkillStatic.SkillCost[MonsterSkillLevel[MonsterSkillTurn]];    //扣除怪獸發動技能的魔力
                                            MonsterSkillTime[MonsterSkillTurn] = MonsterSkillTime[MonsterSkillTurn] + MonsterSkillTimeAlways[MonsterStatic.MonsterSkill.Length - 1];
                                            Debug.Log("怪物施放完技能後的技能冷卻時間為:" + MonsterSkillTime[MonsterSkillTurn]);
                                            MonsterSkillCoolDown();
                                            MonsterSkillTurn++;
                                            if (MonsterSkillTurn >= 5)
                                            {
                                                MonsterSkillTurn = 0;
                                            }
                                            float ShowMonsterDamgeNum = (CharaterAttackDamge * (1 - (MonsterStatic.MonsterPhysicalResistRate / 100)));
                                            ShowMonsterDamge(ShowMonsterDamgeNum, skillname);
                                            FlashCharaterInfo();
                                            FlashMonsterInfo();
                                            SaveCharaterFile();
                                            break;
                                        }
                                    case 1:
                                        {
                                            if (CharaterAttackDamge > MonsterStatic.MonsterMagicShieldNow)
                                            {
                                                MonsterStatic.MonsterMagicShieldNow = MonsterStatic.MonsterMagicShieldNow - CharaterAttackDamge;
                                                MonsterStatic.MonsterHpNow = MonsterStatic.MonsterHpNow + MonsterStatic.MonsterMagicShieldNow;
                                                MonsterStatic.MonsterMagicShieldNow = 0;
                                                string HpNow = MonsterStatic.MonsterHpNow.ToString("0.0");
                                                MonsterStatic.MonsterHpNow = float.Parse(HpNow);
                                                Debug.Log("雙方互擊，雙方都有足夠魔力可以攻擊，雙方都閃避失敗，角色造成的傷害比怪物高，所以角色發動技能:" + SkillStatic.SkillName + "對怪物造成魔法攻擊:" + CharaterAttackDamge + "造成傷害大於怪物法術護盾值，怪物法術護盾剩餘:" + MonsterStatic.MonsterMagicShieldNow + "怪物血量剩餘:" + MonsterStatic.MonsterHpNow + "戰鬥進行時間:" + BattleTime);
                                                PublicFunctionClone.ReadSkill(PublicFunction.CharaterBattleSkillArray[CharaterSkillTurn]);
                                                CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMpNow - SkillStatic.SkillCost[CharaterSkillLevel[CharaterSkillTurn]];  //扣除角色發動技能的魔力
                                                CharaterBattleSkillTime[CharaterSkillTurn] = CharaterBattleSkillTime[CharaterSkillTurn] + CharaterBattleSkillTimeAlways[PublicFunction.CharaterBattleSkillCount - 1];
                                                Debug.Log("角色施放完技能後的技能冷卻時間為:" + CharaterBattleSkillTime[CharaterSkillTurn]);
                                                PlayerSkillCoolDown();
                                                CharaterSkillTurn++;
                                                if (CharaterSkillTurn >= 5)
                                                {
                                                    CharaterSkillTurn = 0;
                                                }
                                                PublicFunctionClone.ReadSkill(MonsterStatic.MonsterSkill[MonsterSkillTurn]);
                                                MonsterStatic.MonsterMpNow = MonsterStatic.MonsterMpNow - SkillStatic.SkillCost[MonsterSkillLevel[MonsterSkillTurn]];    //扣除怪獸發動技能的魔力
                                                MonsterSkillTime[MonsterSkillTurn] = MonsterSkillTime[MonsterSkillTurn] + MonsterSkillTimeAlways[MonsterStatic.MonsterSkill.Length - 1];
                                                Debug.Log("怪物施放完技能後的技能冷卻時間為:" + MonsterSkillTime[MonsterSkillTurn]);
                                                MonsterSkillCoolDown();
                                                MonsterSkillTurn++;
                                                if (MonsterSkillTurn >= 5)
                                                {
                                                    MonsterSkillTurn = 0;
                                                }
                                            }
                                            string skillname = SkillStatic.SkillName;
                                            if (CharaterAttackDamge <= MonsterStatic.MonsterMagicShieldNow)
                                            {
                                                MonsterStatic.MonsterMagicShieldNow = MonsterStatic.MonsterMagicShieldNow - CharaterAttackDamge;
                                                string MagicShield = MonsterStatic.MonsterMagicShieldNow.ToString("0.0");
                                                MonsterStatic.MonsterMagicShieldNow = float.Parse(MagicShield);
                                                Debug.Log("雙方互擊，雙方都有足夠魔力可以攻擊，雙方都閃避失敗，角色造成的傷害比怪物高，所以角色發動技能:" + SkillStatic.SkillName + "對怪物造成魔法攻擊:" + CharaterAttackDamge + "怪物法術護盾剩餘:" + MonsterStatic.MonsterMagicShieldNow + "怪物血量剩餘:" + MonsterStatic.MonsterHpNow + "戰鬥進行時間:" + BattleTime);
                                                PublicFunctionClone.ReadSkill(PublicFunction.CharaterBattleSkillArray[CharaterSkillTurn]);
                                                skillname = SkillStatic.SkillName;
                                                CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMpNow - SkillStatic.SkillCost[CharaterSkillLevel[CharaterSkillTurn]];  //扣除角色發動技能的魔力
                                                CharaterBattleSkillTime[CharaterSkillTurn] = CharaterBattleSkillTime[CharaterSkillTurn] + CharaterBattleSkillTimeAlways[PublicFunction.CharaterBattleSkillCount - 1];
                                                Debug.Log("角色施放完技能後的技能冷卻時間為:" + CharaterBattleSkillTime[CharaterSkillTurn]);
                                                PlayerSkillCoolDown();
                                                CharaterSkillTurn++;
                                                if (CharaterSkillTurn >= 5)
                                                {
                                                    CharaterSkillTurn = 0;
                                                }
                                                PublicFunctionClone.ReadSkill(MonsterStatic.MonsterSkill[MonsterSkillTurn]);
                                                MonsterStatic.MonsterMpNow = MonsterStatic.MonsterMpNow - SkillStatic.SkillCost[MonsterSkillLevel[MonsterSkillTurn]];    //扣除怪獸發動技能的魔力
                                                MonsterSkillTime[MonsterSkillTurn] = MonsterSkillTime[MonsterSkillTurn] + MonsterSkillTimeAlways[MonsterStatic.MonsterSkill.Length - 1];
                                                Debug.Log("怪物施放完技能後的技能冷卻時間為:" + MonsterSkillTime[MonsterSkillTurn]);
                                                MonsterSkillCoolDown();
                                                MonsterSkillTurn++;
                                                if (MonsterSkillTurn >= 5)
                                                {
                                                    MonsterSkillTurn = 0;
                                                }
                                            }
                                            ShowMonsterDamge(CharaterAttackDamge, skillname);
                                            FlashCharaterInfo();
                                            FlashMonsterInfo();
                                            SaveCharaterFile();
                                            break;
                                        }
                                }
                                break;
                            }
                        case 2:
                            {
                                MonsterAttackDamage = MonsterAttackDamage - CharaterAttackDamge;
                                PublicFunctionClone.ReadSkill(MonsterStatic.MonsterSkill[MonsterSkillTurn]);
                                switch (SkillStatic.SkillBattleType)
                                {
                                    case 0:
                                        {
                                            CharaterPropertyStatic.CharaterHpNow = CharaterPropertyStatic.CharaterHpNow - (MonsterAttackDamage * (1 - (CharaterPropertyStatic.CharaterPhysicalResistRate / 100)));
                                            string HpNow = CharaterPropertyStatic.CharaterHpNow.ToString("0.0");
                                            CharaterPropertyStatic.CharaterHpNow = float.Parse(HpNow);
                                            Debug.Log("雙方互擊，雙方都有足夠魔力可以攻擊，雙方都閃避失敗，怪物造成的傷害比怪物高，所以怪物發動技能:" + SkillStatic.SkillName + "對角色造成物理攻擊:" + MonsterAttackDamage + "角色物理抵抗值為:" + CharaterPropertyStatic.CharaterPhysicalResistRate + "%" + "角色血量剩餘:" + CharaterPropertyStatic.CharaterHpNow + "戰鬥進行時間:" + BattleTime);
                                            string skillname = SkillStatic.SkillName;
                                            MonsterStatic.MonsterMpNow = MonsterStatic.MonsterMpNow - SkillStatic.SkillCost[MonsterSkillLevel[MonsterSkillTurn]];    //扣除怪獸發動技能的魔力
                                            MonsterSkillTime[MonsterSkillTurn] = MonsterSkillTime[MonsterSkillTurn] + MonsterSkillTimeAlways[MonsterStatic.MonsterSkill.Length - 1];
                                            Debug.Log("怪物施放完技能後的技能冷卻時間為:" + MonsterSkillTime[MonsterSkillTurn]);
                                            MonsterSkillCoolDown();
                                            MonsterSkillTurn++;
                                            if (MonsterSkillTurn >= 5)
                                            {
                                                MonsterSkillTurn = 0;
                                            }
                                            PublicFunctionClone.ReadSkill(PublicFunction.CharaterBattleSkillArray[CharaterSkillTurn]);
                                            CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMpNow - SkillStatic.SkillCost[CharaterSkillLevel[CharaterSkillTurn]];  //扣除角色發動技能的魔力
                                            CharaterBattleSkillTime[CharaterSkillTurn] = CharaterBattleSkillTime[CharaterSkillTurn] + CharaterBattleSkillTimeAlways[PublicFunction.CharaterBattleSkillCount - 1];
                                            Debug.Log("角色施放完技能後的技能冷卻時間為:" + CharaterBattleSkillTime[CharaterSkillTurn]);
                                            PlayerSkillCoolDown();
                                            CharaterSkillTurn++;
                                            if (CharaterSkillTurn >= 5)
                                            {
                                                CharaterSkillTurn = 0;
                                            }
                                            float ShowCharaterDamgeNum = (MonsterAttackDamage * (1 - (CharaterPropertyStatic.CharaterPhysicalResistRate / 100)));
                                            ShowCharaterDamge(ShowCharaterDamgeNum, skillname);
                                            FlashCharaterInfo();
                                            FlashMonsterInfo();
                                            SaveCharaterFile();
                                            break;
                                        }
                                    case 1:
                                        {
                                            if (MonsterAttackDamage > CharaterPropertyStatic.CharaterMagicShieldNow)
                                            {
                                                CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShieldNow - MonsterAttackDamage;
                                                CharaterPropertyStatic.CharaterHpNow = CharaterPropertyStatic.CharaterHpNow + CharaterPropertyStatic.CharaterMagicShieldNow;
                                                CharaterPropertyStatic.CharaterMagicShieldNow = 0;
                                                string HpNow = CharaterPropertyStatic.CharaterHpNow.ToString("0.0");
                                                CharaterPropertyStatic.CharaterHpNow = float.Parse(HpNow);
                                                Debug.Log("雙方互擊，雙方都有足夠魔力可以攻擊，雙方都閃避失敗，怪物造成的傷害比怪物高，所以怪物發動技能:" + SkillStatic.SkillName + "對角色造成魔法攻擊:" + MonsterAttackDamage + "造成傷害大於角色法術護盾值，角色法術護盾剩餘:" + CharaterPropertyStatic.CharaterMagicShieldNow + "角色血量剩餘:" + CharaterPropertyStatic.CharaterHpNow + "戰鬥進行時間:" + BattleTime);
                                                MonsterStatic.MonsterMpNow = MonsterStatic.MonsterMpNow - SkillStatic.SkillCost[MonsterSkillLevel[MonsterSkillTurn]];    //扣除怪獸發動技能的魔力
                                                MonsterSkillTime[MonsterSkillTurn] = MonsterSkillTime[MonsterSkillTurn] + MonsterSkillTimeAlways[MonsterStatic.MonsterSkill.Length - 1];
                                                Debug.Log("怪物施放完技能後的技能冷卻時間為:" + MonsterSkillTime[MonsterSkillTurn]);
                                                MonsterSkillCoolDown();
                                                MonsterSkillTurn++;
                                                if (MonsterSkillTurn >= 5)
                                                {
                                                    MonsterSkillTurn = 0;
                                                }
                                                PublicFunctionClone.ReadSkill(PublicFunction.CharaterBattleSkillArray[CharaterSkillTurn]);
                                                CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMpNow - SkillStatic.SkillCost[CharaterSkillLevel[CharaterSkillTurn]];  //扣除角色發動技能的魔力
                                                CharaterBattleSkillTime[CharaterSkillTurn] = CharaterBattleSkillTime[CharaterSkillTurn] + CharaterBattleSkillTimeAlways[PublicFunction.CharaterBattleSkillCount - 1];
                                                Debug.Log("角色施放完技能後的技能冷卻時間為:" + CharaterBattleSkillTime[CharaterSkillTurn]);
                                                PlayerSkillCoolDown();
                                                CharaterSkillTurn++;
                                                if (CharaterSkillTurn >= 5)
                                                {
                                                    CharaterSkillTurn = 0;
                                                }
                                            }
                                            string skillname = SkillStatic.SkillName;
                                            if (MonsterAttackDamage <= CharaterPropertyStatic.CharaterMagicShieldNow)
                                            {
                                                CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShieldNow - MonsterAttackDamage;
                                                string MagicShieldNow = CharaterPropertyStatic.CharaterMagicShieldNow.ToString("0.0");
                                                CharaterPropertyStatic.CharaterMagicShieldNow = float.Parse(MagicShieldNow);
                                                skillname = SkillStatic.SkillName;
                                                Debug.Log("雙方互擊，雙方都有足夠魔力可以攻擊，雙方都閃避失敗，怪物造成的傷害比怪物高，所以怪物發動技能:" + SkillStatic.SkillName + "對角色造成魔法攻擊:" + MonsterAttackDamage + "角色法術護盾剩餘:" + CharaterPropertyStatic.CharaterMagicShieldNow + "角色血量剩餘:" + CharaterPropertyStatic.CharaterHpNow + "戰鬥進行時間:" + BattleTime);
                                                MonsterStatic.MonsterMpNow = MonsterStatic.MonsterMpNow - SkillStatic.SkillCost[MonsterSkillLevel[MonsterSkillTurn]];    //扣除怪獸發動技能的魔力
                                                MonsterSkillTime[MonsterSkillTurn] = MonsterSkillTime[MonsterSkillTurn] + MonsterSkillTimeAlways[MonsterStatic.MonsterSkill.Length - 1];
                                                Debug.Log("怪物施放完技能後的技能冷卻時間為:" + MonsterSkillTime[MonsterSkillTurn]);
                                                MonsterSkillCoolDown();
                                                MonsterSkillTurn++;
                                                if (MonsterSkillTurn >= 5)
                                                {
                                                    MonsterSkillTurn = 0;
                                                }
                                                PublicFunctionClone.ReadSkill(PublicFunction.CharaterBattleSkillArray[CharaterSkillTurn]);
                                                CharaterPropertyStatic.CharaterMpNow = CharaterPropertyStatic.CharaterMpNow - SkillStatic.SkillCost[CharaterSkillLevel[CharaterSkillTurn]];  //扣除角色發動技能的魔力
                                                CharaterBattleSkillTime[CharaterSkillTurn] = CharaterBattleSkillTime[CharaterSkillTurn] + CharaterBattleSkillTimeAlways[PublicFunction.CharaterBattleSkillCount - 1];
                                                Debug.Log("角色施放完技能後的技能冷卻時間為:" + CharaterBattleSkillTime[CharaterSkillTurn]);
                                                PlayerSkillCoolDown();
                                                CharaterSkillTurn++;
                                                if (CharaterSkillTurn >= 5)
                                                {
                                                    CharaterSkillTurn = 0;
                                                }
                                            }
                                            ShowCharaterDamge(MonsterAttackDamage, skillname);
                                            FlashCharaterInfo();
                                            FlashMonsterInfo();
                                            SaveCharaterFile();
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
                    PublicFunctionClone.ReadSkill(MonsterStatic.MonsterSkill[MonsterSkillTurn]);
                    switch (SkillStatic.SkillBattleType)
                    {
                        case 0:
                            {
                                CharaterPropertyStatic.CharaterHpNow = CharaterPropertyStatic.CharaterHpNow - (MonsterAttackDamage * (1 - (CharaterPropertyStatic.CharaterPhysicalResistRate / 100)));
                                string HpNow = CharaterPropertyStatic.CharaterHpNow.ToString("0.0");
                                CharaterPropertyStatic.CharaterHpNow = float.Parse(HpNow);
                                Debug.Log("雙方互擊，怪物有足夠魔力可以攻擊，但角色沒有，所以怪物發動技能:" + SkillStatic.SkillName + "對角色造成物理攻擊:" + MonsterAttackDamage + "角色物理抵抗值為:" + CharaterPropertyStatic.CharaterPhysicalResistRate + "%" + "角色血量剩餘:" + CharaterPropertyStatic.CharaterHpNow + "戰鬥進行時間:" + BattleTime);
                                string skillname = SkillStatic.SkillName;
                                MonsterStatic.MonsterMpNow = MonsterStatic.MonsterMpNow - SkillStatic.SkillCost[MonsterSkillLevel[MonsterSkillTurn]];    //扣除怪獸發動技能的魔力
                                MonsterSkillTime[MonsterSkillTurn] = MonsterSkillTime[MonsterSkillTurn] + MonsterSkillTimeAlways[MonsterStatic.MonsterSkill.Length - 1];
                                Debug.Log("怪物施放完技能後的技能冷卻時間為:" + MonsterSkillTime[MonsterSkillTurn]);
                                MonsterSkillCoolDown();
                                MonsterSkillTurn++;
                                if (MonsterSkillTurn >= 5)
                                {
                                    MonsterSkillTurn = 0;
                                }
                                CharaterBattleSkillTime[CharaterSkillTurn] = CharaterBattleSkillTime[CharaterSkillTurn] + CharaterBattleSkillTimeAlways[PublicFunction.CharaterBattleSkillCount - 1];
                                Debug.Log("角色施放完技能後的技能冷卻時間為:" + CharaterBattleSkillTime[CharaterSkillTurn]);
                                PlayerSkillCoolDown();
                                CharaterSkillTurn++;
                                if (CharaterSkillTurn >= 5)
                                {
                                    CharaterSkillTurn = 0;
                                }
                                float ShowCharaterDamgeNum = (MonsterAttackDamage * (1 - (CharaterPropertyStatic.CharaterPhysicalResistRate / 100)));
                                ShowCharaterDamge(ShowCharaterDamgeNum, skillname);
                                FlashCharaterInfo();
                                FlashMonsterInfo();
                                SaveCharaterFile();
                                break;
                            }
                        case 1:
                            {
                                if (MonsterAttackDamage > CharaterPropertyStatic.CharaterMagicShieldNow)
                                {
                                    CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShieldNow - MonsterAttackDamage;
                                    CharaterPropertyStatic.CharaterHpNow = CharaterPropertyStatic.CharaterHpNow + CharaterPropertyStatic.CharaterMagicShieldNow;
                                    CharaterPropertyStatic.CharaterMagicShieldNow = 0;
                                    string HpNow = CharaterPropertyStatic.CharaterHpNow.ToString("0.0");
                                    CharaterPropertyStatic.CharaterHpNow = float.Parse(HpNow);
                                    Debug.Log("雙方互擊，怪物有足夠魔力可以攻擊，但角色沒有，所以怪物發動技能:" + SkillStatic.SkillName + "對角色造成魔法攻擊:" + MonsterAttackDamage + "造成傷害大於角色法術護盾值，角色法術護盾剩餘:" + CharaterPropertyStatic.CharaterMagicShieldNow + "角色血量剩餘:" + CharaterPropertyStatic.CharaterHpNow + "戰鬥進行時間:" + BattleTime);
                                    MonsterStatic.MonsterMpNow = MonsterStatic.MonsterMpNow - SkillStatic.SkillCost[MonsterSkillLevel[MonsterSkillTurn]];    //扣除怪獸發動技能的魔力
                                    MonsterSkillTime[MonsterSkillTurn] = MonsterSkillTime[MonsterSkillTurn] + MonsterSkillTimeAlways[MonsterStatic.MonsterSkill.Length - 1];
                                    Debug.Log("怪物施放完技能後的技能冷卻時間為:" + MonsterSkillTime[MonsterSkillTurn]);
                                    MonsterSkillCoolDown();
                                    MonsterSkillTurn++;
                                    if (MonsterSkillTurn >= 5)
                                    {
                                        MonsterSkillTurn = 0;
                                    }
                                    CharaterBattleSkillTime[CharaterSkillTurn] = CharaterBattleSkillTime[CharaterSkillTurn] + CharaterBattleSkillTimeAlways[PublicFunction.CharaterBattleSkillCount - 1];
                                    Debug.Log("角色施放完技能後的技能冷卻時間為:" + CharaterBattleSkillTime[CharaterSkillTurn]);
                                    PlayerSkillCoolDown();
                                    CharaterSkillTurn++;
                                    if (CharaterSkillTurn >= 5)
                                    {
                                        CharaterSkillTurn = 0;
                                    }
                                }
                                string skillname = SkillStatic.SkillName;
                                if (MonsterAttackDamage <= CharaterPropertyStatic.CharaterMagicShieldNow)
                                {
                                    CharaterPropertyStatic.CharaterMagicShieldNow = CharaterPropertyStatic.CharaterMagicShieldNow - MonsterAttackDamage;
                                    string MagicShieldNow = CharaterPropertyStatic.CharaterMagicShieldNow.ToString("0.0");
                                    CharaterPropertyStatic.CharaterMagicShieldNow = float.Parse(MagicShieldNow);
                                    Debug.Log("雙方互擊，怪物有足夠魔力可以攻擊，但角色沒有，所以怪物發動技能:" + SkillStatic.SkillName + "對角色造成魔法攻擊:" + MonsterAttackDamage + "角色法術護盾剩餘:" + CharaterPropertyStatic.CharaterMagicShieldNow + "角色血量剩餘:" + CharaterPropertyStatic.CharaterHpNow + "戰鬥進行時間:" + BattleTime);
                                    skillname = SkillStatic.SkillName;
                                    MonsterStatic.MonsterMpNow = MonsterStatic.MonsterMpNow - SkillStatic.SkillCost[MonsterSkillLevel[MonsterSkillTurn]];    //扣除怪獸發動技能的魔力
                                    MonsterSkillTime[MonsterSkillTurn] = MonsterSkillTime[MonsterSkillTurn] + MonsterSkillTimeAlways[MonsterStatic.MonsterSkill.Length - 1];
                                    Debug.Log("怪物施放完技能後的技能冷卻時間為:" + MonsterSkillTime[MonsterSkillTurn]);
                                    MonsterSkillCoolDown();
                                    MonsterSkillTurn++;
                                    if (MonsterSkillTurn >= 5)
                                    {
                                        MonsterSkillTurn = 0;
                                    }
                                    CharaterBattleSkillTime[CharaterSkillTurn] = CharaterBattleSkillTime[CharaterSkillTurn] + CharaterBattleSkillTimeAlways[PublicFunction.CharaterBattleSkillCount - 1];
                                    Debug.Log("角色施放完技能後的技能冷卻時間為:" + CharaterBattleSkillTime[CharaterSkillTurn]);
                                    PlayerSkillCoolDown();
                                    CharaterSkillTurn++;
                                    if (CharaterSkillTurn >= 5)
                                    {
                                        CharaterSkillTurn = 0;
                                    }
                                }
                                ShowCharaterDamge(MonsterAttackDamage, skillname);
                                FlashCharaterInfo();
                                FlashMonsterInfo();
                                SaveCharaterFile();
                                break;
                            }
                    }
                    break;
                }
        }
    }

    public void SaveCharaterFile()                                                      //每次修改到角色資訊時都要重新存檔，避免中途遊戲死當或是退出遊戲時造成檔案錯誤
    {
        PublicFunctionClone.CharaterPropertyStaticChange();
        string FileName = "Charater_" + CharaterPropertyStatic.CharaterNumber;
        string data = JsonUtility.ToJson(PublicFunction.CharaterPropertyValue);
        PublicFunctionClone.ReadPlatformpersistentDataPath(FileName);
        File.WriteAllText(PublicFunction.persistentFilePath, data);
        Debug.Log("成功儲存角色檔案");
    }

    public void DodgeChange(out bool DodgeChangeBool)                                   //計算角色是否有閃避成功的功能
    {
        DodgeChangeBool = true;
        DodgeArray = new int[10];
        for (int DNum = 0; DNum < CharaterPropertyStatic.CharaterDodgeRate / 10; DNum++)
        {
            DodgeArray[DNum] = 1;
        }
        int DodgeRandomNum = UnityEngine.Random.Range(0, 10);
        int DodgeRandom = DodgeArray[DodgeRandomNum];
        switch (DodgeRandom)
        {
            case 0:
                {
                    DodgeChangeBool = false;
                    break;
                }
            case 1:
                {
                    DodgeChangeBool = true;
                    break;
                }
        }
    }

    public void CritChange(out bool CritChangeBool)                                     //計算角色是否有閃避成功的功能
    {
        CritChangeBool = true;
        CritArray = new int[10];
        for (int CNum = 0; CNum < CharaterPropertyStatic.CharaterCriticalRate / 10; CNum++)
        {
            CritArray[CNum] = 1;
        }
        int CritRandomNum = UnityEngine.Random.Range(CritArray[0], CritArray[9]);
        int CritRandom = CritArray[CritRandomNum];
        switch (CritRandom)
        {
            case 0:
                {
                    CritChangeBool = false;
                    break;
                }
            case 1:
                {
                    CritChangeBool = true;
                    break;
                }
        }
    }

    public void MonsterDodgeChange(out bool DodgeChangeBool)                            //計算怪物是否有爆擊成功的功能
    {
        DodgeChangeBool = true;
        MonsterDodgeArray = new int[10];
        for (int DNum = 0; DNum < MonsterStatic.MonsterDodgeRate / 10; DNum++)
        {
            MonsterDodgeArray[DNum] = 1;
        }
        int DodgeRandom = UnityEngine.Random.Range(MonsterDodgeArray[0], MonsterDodgeArray[9]);
        switch (DodgeRandom)
        {
            case 0:
                {
                    DodgeChangeBool = false;
                    break;
                }
            case 1:
                {
                    DodgeChangeBool = true;
                    break;
                }
        }
    }

    public void MonsterCritChange(out bool CritChangeBool)                              //計算怪物是否有爆擊成功的功能
    {
        CritChangeBool = true;
        MonsterCritArray = new int[10];
        for (int CNum = 0; CNum < MonsterStatic.MonsterCriticalRate / 10; CNum++)
        {
            MonsterCritArray[CNum] = 1;
        }
        int CritRandom = UnityEngine.Random.Range(MonsterCritArray[0], MonsterCritArray[9]);
        switch (CritRandom)
        {
            case 0:
                {
                    CritChangeBool = false;
                    break;
                }
            case 1:
                {
                    CritChangeBool = true;
                    break;
                }
        }
    }

    public void FlashCharaterInfo()                                                     //用來刷新角色資訊的功能
    {
        Debug.Log("角色當前血量:" + CharaterPropertyStatic.CharaterHpNow);
        Debug.Log("角色當前魔力:" + CharaterPropertyStatic.CharaterMpNow);

        switch (CharaterPropertyStatic.CharaterMagicShield != 0)
        {
            case true:
                {
                    PublicFunctionClone.ChangeSpriteSize(MagicShieldSrpite, CharaterPropertyStatic.CharaterMagicShieldNow, CharaterPropertyStatic.CharaterMagicShield, CharaterPropertyStatic.CharaterMagicShield, 0);
                    Load_MagicShield.text = CharaterPropertyStatic.CharaterMagicShieldNow + "/" + CharaterPropertyStatic.CharaterMagicShield;
                    Debug.Log("角色當前法術護盾:" + CharaterPropertyStatic.CharaterMagicShieldNow);
                    break;
                }
            case false:
                {
                    break;
                }
        }

        PublicFunctionClone.ChangeSpriteSize(HpSprite, CharaterPropertyStatic.CharaterHpNow, CharaterPropertyStatic.CharaterHp, CharaterPropertyStatic.CharaterHp, 0);
        PublicFunctionClone.ChangeSpriteSize(MpSprite, CharaterPropertyStatic.CharaterMpNow, CharaterPropertyStatic.CharaterMp, CharaterPropertyStatic.CharaterMp, 0);
        Load_Hp.text = CharaterPropertyStatic.CharaterHpNow.ToString("0") + "/" + CharaterPropertyStatic.CharaterHp.ToString();
        Load_Mp.text = CharaterPropertyStatic.CharaterMpNow.ToString("0") + "/" + CharaterPropertyStatic.CharaterMp.ToString();
    }

    public void LoadCharaterProperty()                                                  //更新主介面上的角色資訊，角色血量，角色魔力，角色等級，角色經驗值
    {
        switch (CharaterPropertyStatic.CharaterMagicShield != 0)
        {
            case true:
                {
                    MagicShieldSrpite.SetActive(true);
                    MagicShield_Frame.SetActive(true);
                    MagicShield_Load.SetActive(true);
                    MagicShield_Text.SetActive(true);
                    MagicShield_FrameOutside.SetActive(true);
                    PublicFunctionClone.ChangeSpriteSize(MagicShieldSrpite, CharaterPropertyStatic.CharaterMagicShieldNow, CharaterPropertyStatic.CharaterMagicShieldNow, CharaterPropertyStatic.CharaterMagicShield, 0);
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
        PublicFunctionClone.ChangeSpriteSize(HpSprite, CharaterPropertyStatic.CharaterHpNow, CharaterPropertyStatic.CharaterHpNow, CharaterPropertyStatic.CharaterHp, 0);
        PublicFunctionClone.ChangeSpriteSize(MpSprite, CharaterPropertyStatic.CharaterMpNow, CharaterPropertyStatic.CharaterMpNow, CharaterPropertyStatic.CharaterMp, 0);
        Load_Hp.text = CharaterPropertyStatic.CharaterHpNow.ToString("0") + "/" + CharaterPropertyStatic.CharaterHp.ToString();
        Load_Mp.text = CharaterPropertyStatic.CharaterMpNow.ToString("0") + "/" + CharaterPropertyStatic.CharaterMp.ToString();
    }

    public void DeleteBattlePrerfab()                                                   //關閉戰鬥介面
    {
        BattlePrefab = GameObject.Find("Prefab_Battle(Clone)");
        Destroy(BattlePrefab);
    }

    public void LoadMonsterProperty()                                                   //更新主介面上的怪物資訊，怪物血量，怪物魔力
    {
        switch (MonsterStatic.MonsterMagicShield != 0)
        {
            case true:
                {
                    MagicShieldSrpite_Monster.SetActive(true);
                    MagicShield_Frame_Monster.SetActive(true);
                    MagicShield_Load_Monster.SetActive(true);
                    MagicShield_Text_Monster.SetActive(true);
                    MS_Frame_Monster.SetActive(true);
                    HPMP_Frame_Monster.SetActive(false);
                    PublicFunctionClone.ChangeSpriteSize(MagicShieldSrpite_Monster, MonsterStatic.MonsterMagicShieldNow, MonsterStatic.MonsterMagicShieldNow, MonsterStatic.MonsterMagicShield, 0);
                    Load_MagicShield_Monster.text = MonsterStatic.MonsterMagicShieldNow.ToString("0") + "/" + MonsterStatic.MonsterMagicShield;
                    break;
                }
            case false:
                {
                    MagicShieldSrpite_Monster.SetActive(false);
                    MagicShield_Frame_Monster.SetActive(false);
                    MagicShield_Load_Monster.SetActive(false);
                    MagicShield_Text_Monster.SetActive(false);
                    MS_Frame_Monster.SetActive(false);
                    HPMP_Frame_Monster.SetActive(true);
                    break;
                }
        }
        PublicFunctionClone.ChangeSpriteSize(HpSprite_Monster, MonsterStatic.MonsterHpNow, MonsterStatic.MonsterHpNow, MonsterStatic.MonsterHp, 0);
        PublicFunctionClone.ChangeSpriteSize(MpSprite_Monster, MonsterStatic.MonsterMpNow, MonsterStatic.MonsterMpNow, MonsterStatic.MonsterMp, 0);
        Load_Hp_Monster.text = MonsterStatic.MonsterHpNow.ToString("0") + "/" + MonsterStatic.MonsterHp.ToString();
        Load_Mp_Monster.text = MonsterStatic.MonsterMpNow.ToString("0") + "/" + MonsterStatic.MonsterMp.ToString();
    }

    public void FlashMonsterInfo()                                                      //用來刷新怪物資訊的功能
    {
        Debug.Log("怪物當前血量:" + MonsterStatic.MonsterHpNow);
        Debug.Log("怪物當前魔力:" + MonsterStatic.MonsterMpNow);

        switch (MonsterStatic.MonsterMagicShield != 0)
        {
            case true:
                {
                    PublicFunctionClone.ChangeSpriteSize(MagicShieldSrpite_Monster, MonsterStatic.MonsterMagicShieldNow, MonsterStatic.MonsterMagicShieldNow, MonsterStatic.MonsterMagicShield, 0);
                    Load_MagicShield_Monster.text = MonsterStatic.MonsterMagicShieldNow.ToString("0") + "/" + MonsterStatic.MonsterMagicShield;
                    Debug.Log("怪物當前法術護盾:" + MonsterStatic.MonsterMagicShieldNow);
                    break;
                }
            case false:
                {
                    break;
                }
        }

        PublicFunctionClone.ChangeSpriteSize(HpSprite_Monster, MonsterStatic.MonsterHpNow, MonsterStatic.MonsterHpNow, MonsterStatic.MonsterHp, 0);
        PublicFunctionClone.ChangeSpriteSize(MpSprite_Monster, MonsterStatic.MonsterMpNow, MonsterStatic.MonsterMpNow, MonsterStatic.MonsterMp, 0);
        Load_Hp_Monster.text = MonsterStatic.MonsterHpNow.ToString("0") + "/" + MonsterStatic.MonsterHp.ToString();
        Load_Mp_Monster.text = MonsterStatic.MonsterMpNow.ToString("0") + "/" + MonsterStatic.MonsterMp.ToString();
    }

    public void MonsterDieCharaterGetItem()                                             //打敗怪物後獲得道具
    {
        //-----隨機給玩家多少數量的道具
        CharaterGetItemIdNum = 0;
        CharaterGetItemIdNum = UnityEngine.Random.Range(0, MonsterStatic.MonsterDieItem.Length + 1);
        Debug.Log("本次戰鬥獲得道具數量" + CharaterGetItemIdNum);
        CharaterGetItemId = new int[CharaterGetItemIdNum];
        MonsterDieItemRateArrayList();

        for (int Num = 0; Num < CharaterGetItemId.Length; Num++)
		{
            /*if(UnityEngine.Random.value > MonsterStatic.MonsterDieItemRate[Num] / 100)               //依照各個道具獲得的機率來隨機給，這個功能不能使用，因為有可能會導致同一編號的可能性很高，因為是逐個隨機的，前面幾個編號的機率自然高
			{
                CharaterGetItemId[Num] = MonsterStatic.MonsterDieItem[Num];
            }*/
            int RandomId = 0;
            RandomId = UnityEngine.Random.Range(0, MonsterDieItemRateArray.Length);
            CharaterGetItemId[Num] = MonsterDieItemRateArray[RandomId];
            int RemoveId = MonsterDieItemRateArray[RandomId];
            MonsterDieItemRateArray = Array.FindAll(MonsterDieItemRateArray, oldnum => oldnum != RemoveId).ToArray();
            /*for(int NUM = 0; NUM < MonsterDieItemRateArray.Length; NUM++)
			{
                Debug.Log("陣列裡現在第" + NUM + "個數字的道具編號是:" + MonsterDieItemRateArray[NUM]);
			}*/
        }
        //-----

        //-----把角色獲得的道具編號陣列做排序，泡沫排序法
        for(int oldNum = CharaterGetItemId.Length; oldNum >= 0; oldNum--)
		{
            for (int Num = 0; Num < CharaterGetItemId.Length - 1; Num++)
            {
                if (CharaterGetItemId[Num + 1] < CharaterGetItemId[Num])
                {
                    int oldnum = CharaterGetItemId[Num + 1];
                    CharaterGetItemId[Num + 1] = CharaterGetItemId[Num];
                    CharaterGetItemId[Num] = oldnum;
                }
            }
        }       
        for (int Array = 0; Array < CharaterGetItemId.Length; Array++)
        {
            Debug.Log("陣列內的道具編號順序，第" + Array + "個編號是:" + CharaterGetItemId[Array]);
        }
        //-----



        //-----給予獲得道具的數量
        CharaterGetItemNum = new int[CharaterGetItemId.Length];
        for(int Num = 0; Num < MonsterStatic.MonsterDieItemNum.Length; Num++)
		{
            for (int DieItemNum = 0; DieItemNum < CharaterGetItemId.Length; DieItemNum++)
            {
                switch (CharaterGetItemId[DieItemNum] == Num)
                {
                    case true:
						{
                            CharaterGetItemNum[DieItemNum] = UnityEngine.Random.Range(1, MonsterStatic.MonsterDieItemNum[Num] + 1);
                            Debug.Log("這是獲得道具的數量，第" + DieItemNum + "個的數量:" + CharaterGetItemNum[DieItemNum]);
                            break;
                        }
                    case false:
						{
                            break;
						}
                }
            }
        }
        //-----
    }

    public void CharaterGetItem()                                                       //角色獲得道具，並儲存資料到角色道具檔案裡
	{
        string ItemFileName = "Charater_" + CharaterPropertyStatic.CharaterNumber + "_Item";
        PublicFunctionClone.ReadPlatformpersistentDataPath(ItemFileName);
        string ItemFile = File.ReadAllText(PublicFunction.persistentFilePath);
        JsonCharaterItem<CharaterItem> ItemFileJson = JsonUtility.FromJson<JsonCharaterItem<CharaterItem>>(ItemFile);

        bool ItemIdExsit = true;

        for (int Num = 0; Num < CharaterGetItemId.Length; Num++)
        {
            Debug.Log("總共會獲得幾個道具數量:" + CharaterGetItemId.Length);
            Debug.Log("顯示到第" + Num + "個道具編號:" + CharaterGetItemId[Num]);
            PublicFunctionClone.ReadCharaterItem(CharaterPropertyStatic.CharaterNumber, CharaterGetItemId[Num]);
            switch(CharaterItemStatic.Id == CharaterGetItemId[Num])
			{
                case true:
					{
                        ItemIdExsit = true;
                        break;
					}
                case false:
					{
                        ItemIdExsit = false;
                        break;
					}
			}
            Debug.Log("這個道具編號是否有存在?" + ItemIdExsit);
            switch (ItemIdExsit)
            {
                case true:
                    {
                        foreach (CharaterItem data in ItemFileJson.CharaterItem)
                        {
                            if (data.Id == CharaterGetItemId[Num])
                            {
                                data.ItemNum = data.ItemNum + CharaterGetItemNum[Num];
                            }
                        }
                        break;
                    }
                case false:
                    {
                        ItemFileJson.CharaterItem.Add(new CharaterItem()
                        {
                            Id = CharaterGetItemId[Num],
                            ItemNum = CharaterGetItemNum[Num],
                            ItemEquip = false
                        }) ;
                        break;
                    }
            }
        }

        ItemFile = JsonUtility.ToJson(ItemFileJson);
        File.WriteAllText(PublicFunction.persistentFilePath, ItemFile);
        /*switch (CharaterGetItemIdNum != 0)
        {
            case true:
                {
                    BattleWin();
                    break;
                }
            case false:
                {
                    OpenMsgBoxClone.CreateMsgBox(33);
                    break;
                }
        }*/

        int[] newitemarray = new int[ItemFileJson.CharaterItem.Count];
        int newnum = 0;

        foreach (CharaterItem data in ItemFileJson.CharaterItem)
        {
            newitemarray[newnum] = data.Id;
            newnum++;
            Debug.Log(data.Id);
        }
        for (int num = 0; num < ItemFileJson.CharaterItem.Count; num++)
        {
            Debug.Log("整理前的陣列第" + num + "個編號:" + newitemarray[num]);
        }

        int nowid = 0, nowitemnum = 0, nextid = 0, nextitemnum = 0, stayid = 0, stayitemnum = 0;
        bool nowequip = false, nextequip = false, stayequip = false;

        for (int oldNum = ItemFileJson.CharaterItem.Count; oldNum >= 0; oldNum--)
        {
            for (int Num = 0; Num < ItemFileJson.CharaterItem.Count; Num++)
            {
                newnum = 0;
                foreach (CharaterItem data in ItemFileJson.CharaterItem)
                {
                    newitemarray[newnum] = data.Id;
                    newnum++;
                }
                switch (Num == ItemFileJson.CharaterItem.Count - 1)
                {
                    case true:
                        {
                            foreach (CharaterItem data in ItemFileJson.CharaterItem)
                            {
                                if (data.Id == newitemarray[Num - 1])
                                {
                                    nowid = data.Id;
                                    nowitemnum = data.ItemNum;
                                    nowequip = data.ItemEquip;
                                }
                                if (data.Id == newitemarray[Num])
                                {
                                    nextid = data.Id;
                                    nextitemnum = data.ItemNum;
                                    nextequip = data.ItemEquip;
                                    stayid = nextid;
                                    stayitemnum = nextitemnum;
                                    stayequip = nextequip;
                                }
                            }
                            if (nextid < nowid)
                            {
                                foreach (CharaterItem data in ItemFileJson.CharaterItem)
                                {
                                    if (data.Id == nowid)
                                    {
                                        data.Id = nowid + 1024;
                                    }
                                    if (data.Id == nextid)
                                    {
                                        data.Id = nextid + 2048;
                                    }
                                }
                                foreach (CharaterItem data in ItemFileJson.CharaterItem)
                                {
                                    if (data.Id == nextid + 2048)
                                    {
                                        data.Id = nowid;
                                        data.ItemNum = nowitemnum;
                                        data.ItemEquip = nowequip;
                                    }
                                    if (data.Id == nowid + 1024)
                                    {
                                        data.Id = stayid;
                                        data.ItemNum = stayitemnum;
                                        data.ItemEquip = stayequip;
                                    }
                                }
                            }
                            break;
                        }
                    case false:
                        {
                            foreach (CharaterItem data in ItemFileJson.CharaterItem)
                            {
                                if (data.Id == newitemarray[Num])
                                {
                                    nowid = data.Id;
                                    nowitemnum = data.ItemNum;
                                    nowequip = data.ItemEquip;
                                }
                                if (data.Id == newitemarray[Num + 1])
                                {
                                    nextid = data.Id;
                                    nextitemnum = data.ItemNum;
                                    nextequip = data.ItemEquip;
                                    stayid = nextid;
                                    stayitemnum = nextitemnum;
                                    stayequip = nextequip;
                                }
                            }
                            if (nextid < nowid)
                            {
                                foreach (CharaterItem data in ItemFileJson.CharaterItem)
                                {
                                    if (data.Id == nowid)
                                    {
                                        data.Id = nowid + 1024;
                                    }
                                    if (data.Id == nextid)
                                    {
                                        data.Id = nextid + 2048;
                                    }
                                }
                                foreach (CharaterItem data in ItemFileJson.CharaterItem)
                                {
                                    if (data.Id == nextid + 2048)
                                    {
                                        data.Id = nowid;
                                        data.ItemNum = nowitemnum;
                                        data.ItemEquip = nowequip;
                                    }
                                    if (data.Id == nowid + 1024)
                                    {
                                        data.Id = stayid;
                                        data.ItemNum = stayitemnum;
                                        data.ItemEquip = stayequip;
                                    }
                                }
                            }
                            break;
                        }
                }
            }
        }
        ItemFile = JsonUtility.ToJson(ItemFileJson);
        File.WriteAllText(PublicFunction.persistentFilePath, ItemFile);
    }

    public class JsonCharaterItem<T>                                                    //角色道具表所使用的List，來協助unity可以讀取陣列(Array)裡的資料
    {
        public List<T> CharaterItem;
    }

    public void BattleWin()                                                             //當戰鬥成功時，顯示的是此功能，而非失敗的MsgBox
	{
        Debug.Log("角色獲得道具的陣列大小:" + CharaterGetItemId.Length);
        Debug.Log("角色獲得裝備的陣列大小:" + CharaterGetArmId.Length);
        int Itemarraysize = CharaterGetItemId.Length;
        int Armarraysize = CharaterGetArmId.Length;
        BattleWinObject.SetActive(true);
        PublicFunctionClone.ReadStringUI(34);
        Load_BattleWinStringUI.text = PublicFunction.ReturnString;
        for(int Num = 0; Num < Itemarraysize; Num++)
		{
            Grid_Load_Item = GameObject.Find("UI/Prefab_Battle(Clone)/BattleWin/Scroll_BattleWinItemList/Mask/Grid_BattleWinItemList");
            EmptyGameObject = Instantiate(Load_Item_Object, Grid_Load_Item.transform);
            EmptyGameObject.name = "Load_Item_" + Num;
            PublicFunctionClone.ReadItem(CharaterGetItemId[Num]);
            Load_ItemIconObject = GameObject.Find("UI/Prefab_Battle(Clone)/BattleWin/Scroll_BattleWinItemList/Mask/Grid_BattleWinItemList/Load_Item_" + Num + "/Load_ItemIcon");
            Load_ItemIcon = Load_ItemIconObject.GetComponent<Image>();
            Load_ItemIcon.sprite = SpriteItem.GetSprite(ItemStatic.ItemIcon);
            Load_ItemNumObject = GameObject.Find("UI/Prefab_Battle(Clone)/BattleWin/Scroll_BattleWinItemList/Mask/Grid_BattleWinItemList/Load_Item_" + Num + "/Load_ItemNum");
            Load_ItemNum = Load_ItemNumObject.GetComponent<Text>();
            Load_ItemNum.text = CharaterGetItemNum[Num].ToString();
        }
        for (int Num = 0; Num < Armarraysize; Num++)
        {
            Grid_Load_Item = GameObject.Find("UI/Prefab_Battle(Clone)/BattleWin/Scroll_BattleWinItemList/Mask/Grid_BattleWinItemList");
            EmptyGameObject = Instantiate(Load_Arm_Object, Grid_Load_Item.transform);
            EmptyGameObject.name = "Load_Arm_" + Num;
            PublicFunctionClone.ReadArm(CharaterGetArmId[Num]);
            Load_ArmIconObject = GameObject.Find("UI/Prefab_Battle(Clone)/BattleWin/Scroll_BattleWinItemList/Mask/Grid_BattleWinItemList/Load_Arm_" + Num + "/Load_ArmIcon");
            Load_ArmIcon = Load_ArmIconObject.GetComponent<Image>();
            Load_ArmIcon.sprite = SpriteArm.GetSprite(ArmStatic.ArmIconName);
            Load_ArmNumObject = GameObject.Find("UI/Prefab_Battle(Clone)/BattleWin/Scroll_BattleWinItemList/Mask/Grid_BattleWinItemList/Load_Arm_" + Num + "/Load_ArmNum");
            Load_ArmNum = Load_ArmNumObject.GetComponent<Text>();
            Load_ArmNum.text = CharaterGetArmNum[Num].ToString();
        }
    }

    public void CloseBattleWin()                                                        //用來關閉獲得道具得額外視窗的按鈕功能
	{
        int arraysize = CharaterGetItemId.Length;
        //ClearArmAndItemList();
        for (int Num = 0; Num < arraysize; Num++)
        {
            EmptyGameObject = GameObject.Find("UI/Prefab_Battle(Clone)/BattleWin/Scroll_BattleWinItemList/Mask/Grid_BattleWinItemList/Load_Item_" + Num);
            Destroy(EmptyGameObject);
        }
        int arrayArmsize = CharaterGetArmId.Length;
        for (int Num = 0; Num < arrayArmsize; Num++)
        {
            EmptyGameObject = GameObject.Find("UI/Prefab_Battle(Clone)/BattleWin/Scroll_BattleWinItemList/Mask/Grid_BattleWinItemList/Load_Arm_" + Num);
            Destroy(EmptyGameObject);
        }
        BattleWinObject.SetActive(false);
    }

    public void test()                                                                  //用來測試的功能，先不要刪除
	{
        MonsterDieArm();
    }

    public void CreateMonsterExtraFunction()                                            //產生怪物時各個機率陣列的列出功能
	{
        PublicFunctionClone.ReadMonsterList(MapStatic.MonsterList);
        CreateMonsterArray = new int[100];
        int NumNow = 0;
        for (int Num = 0; Num < MonsterListStatic.MonsterIdList.Length; Num++)
        {
            switch(Num != 0)
			{
                case true:
					{
                        for(int IdNum = 0; IdNum < MonsterListStatic.MonsterIdListRate[Num]; IdNum++)
						{
                            CreateMonsterArray[NumNow] = MonsterListStatic.MonsterIdList[Num];
                            NumNow++;
                            //Debug.Log("產生怪物的陣列，第" + NumNow + "個怪物的編號:" + MonsterListStatic.MonsterIdList[Num]);
                        }
                        break;
					}
                case false:
					{
                        for(int IdNum = 0; IdNum < MonsterListStatic.MonsterIdListRate[Num]; IdNum++)
						{
                            CreateMonsterArray[IdNum] = MonsterListStatic.MonsterIdList[Num];
                            NumNow++;
                            Debug.Log("產生怪物的陣列，第" + NumNow + "個怪物的編號:" + MonsterListStatic.MonsterIdList[Num]);
                        }
                        break;
					}
			}
        }
    }

    public void MonsterDieItemRateArrayList()                                           //擊殺怪物獲得道具機率陣列的列出功能
	{
        MonsterDieItemRateArray = new int[100];
        int NumNow = 0;
        for (int ItemId = 0; ItemId < MonsterStatic.MonsterDieItem.Length; ItemId++)
        {
            switch (ItemId != 0)
            {
                case true:
                    {
                        for (int ItemNum = 0; ItemNum < MonsterStatic.MonsterDieItemRate[ItemId]; ItemNum++)
                        {
                            MonsterDieItemRateArray[NumNow] = MonsterStatic.MonsterDieItem[ItemId];
                            NumNow++;
                            Debug.Log("擊敗怪物後獲得的道具編號百分比陣列，第" + NumNow + "個道具編號是:" + MonsterStatic.MonsterDieItem[ItemId]);
                        }
                        break;
                    }
                case false:
                    {
                        for (int ItemNum = 0; ItemNum < MonsterStatic.MonsterDieItemRate[ItemId]; ItemNum++)
                        {
                            MonsterDieItemRateArray[ItemNum] = MonsterStatic.MonsterDieItem[ItemId];
                            NumNow++;
                            Debug.Log("擊敗怪物後獲得的道具編號百分比陣列，第" + NumNow + "個道具編號是:" + MonsterStatic.MonsterDieItem[ItemId]);
                        }
                        break;
                    }
            }
        }
    }

    public void MonsterDieArm()                                                         //打敗怪物後獲得裝備
    {
        //-----隨機給玩家多少數量的裝備
        CharaterGetArmIdNum = 0;
        CharaterGetArmIdNum = UnityEngine.Random.Range(0, MonsterStatic.MonsterDieArm.Length + 1);
        Debug.Log("本次戰鬥獲得裝備數量" + CharaterGetArmIdNum);
        CharaterGetArmId = new int[CharaterGetArmIdNum];
        MonsterDieArmRateArrayList();

        
        for (int Num = 0; Num < CharaterGetArmId.Length; Num++)
        {
            int RandomId = 0;
            RandomId = UnityEngine.Random.Range(0, MonsterDieArmRateArray.Length);
            CharaterGetArmId[Num] = MonsterDieArmRateArray[RandomId];                                                      //從陣列中隨機選出這次獲得的裝備編號
            int RemoveId = MonsterDieArmRateArray[RandomId];
            MonsterDieArmRateArray = Array.FindAll(MonsterDieArmRateArray, oldnum => oldnum != RemoveId).ToArray();        //從陣列裡刪掉已經被選出的裝備編號
            Debug.Log("這是做啥的" + MonsterDieArmRateArray.Length);
            /*for(int NUM = 0; NUM < MonsterDieItemRateArray.Length; NUM++)
			{
                Debug.Log("陣列裡現在第" + NUM + "個數字的裝備編號是:" + MonsterDieItemRateArray[NUM]);
			}*/
        }
        //-----

        //-----把角色獲得的道具編號陣列做排序，泡沫排序法
        for (int oldNum = CharaterGetArmId.Length; oldNum >= 0; oldNum--)
        {
            for (int Num = 0; Num < CharaterGetArmId.Length - 1; Num++)
            {
                if (CharaterGetArmId[Num + 1] < CharaterGetArmId[Num])
                {
                    int oldnum = CharaterGetArmId[Num + 1];
                    CharaterGetArmId[Num + 1] = CharaterGetArmId[Num];
                    CharaterGetArmId[Num] = oldnum;
                }
            }
        }
        for (int Array = 0; Array < CharaterGetArmId.Length; Array++)
        {
            Debug.Log("陣列內的裝備編號順序，第" + Array + "個編號是:" + CharaterGetArmId[Array]);
        }
        //-----



        //-----給予獲得道具的數量
        CharaterGetArmNum = new int[CharaterGetArmId.Length];
        for (int Num = 0; Num < MonsterStatic.MonsterDieArmNum.Length; Num++)
        {
            for (int DieItemNum = 0; DieItemNum < CharaterGetArmId.Length; DieItemNum++)
            {
                switch (CharaterGetArmId[DieItemNum] == Num)
                {
                    case true:
                        {
                            CharaterGetArmNum[DieItemNum] = UnityEngine.Random.Range(1, MonsterStatic.MonsterDieArmNum[Num] + 1);
                            Debug.Log("這是獲得裝備的數量，第" + DieItemNum + "個的數量:" + CharaterGetArmNum[DieItemNum]);
                            break;
                        }
                    case false:
                        {
                            break;
                        }
                }
            }
        }
        //-----
    }

    public void MonsterDieArmRateArrayList()                                            //擊殺怪物獲得裝備機率陣列的列出功能
    {
        MonsterDieArmRateArray = new int[100];
        int NumNow = 0;
        for (int ItemId = 0; ItemId < MonsterStatic.MonsterDieArm.Length; ItemId++)
        {
            switch (ItemId != 0)
            {
                case true:
                    {
                        for (int ItemNum = 0; ItemNum < MonsterStatic.MonsterDieArmRate[ItemId]; ItemNum++)
                        {
                            MonsterDieArmRateArray[NumNow] = MonsterStatic.MonsterDieArm[ItemId];
                            NumNow++;
                            Debug.Log("擊敗怪物後獲得的裝備編號百分比陣列，第" + NumNow + "個裝備編號是:" + MonsterStatic.MonsterDieArm[ItemId]);
                        }
                        break;
                    }
                case false:
                    {
                        for (int ItemNum = 0; ItemNum < MonsterStatic.MonsterDieArmRate[ItemId]; ItemNum++)
                        {
                            MonsterDieArmRateArray[ItemNum] = MonsterStatic.MonsterDieArm[ItemId];
                            NumNow++;
                            Debug.Log("擊敗怪物後獲得的裝備編號百分比陣列，第" + NumNow + "個裝備編號是:" + MonsterStatic.MonsterDieArm[ItemId]);
                        }
                        break;
                    }
            }
        }
    }

    public void CharaterGetArm()                                                        //角色獲得裝備，並儲存資料到角色裝備檔案裡
    {
        string ArmFileName = "Charater_" + CharaterPropertyStatic.CharaterNumber + "_Arm";
        PublicFunctionClone.ReadPlatformpersistentDataPath(ArmFileName);
        string ArmFile = File.ReadAllText(PublicFunction.persistentFilePath);
        JsonCharaterArm<CharaterArm> ArmFileJson = JsonUtility.FromJson<JsonCharaterArm<CharaterArm>>(ArmFile);

        //-----把角色身上目前有的裝備編號都列成陣列
        int CharaterArmNum = 0;
        CharaterArmIdArray = new int[ArmFileJson.CharaterArm.Count];
        foreach(CharaterArm data in ArmFileJson.CharaterArm)
		{
            CharaterArmIdArray[CharaterArmNum] = data.id;
            CharaterArmNum++;
        }
        //-----

        int NewArmId = 0;

        NewArmId = CharaterArmIdArray[ArmFileJson.CharaterArm.Count - 1] + 1;

        for(int ArmNum = 0; ArmNum < ArmFileJson.CharaterArm.Count; ArmNum++)
		{
            switch(NewArmId == CharaterArmIdArray[ArmNum])
			{
                case true:
					{
                        NewArmId++;
                        break;
					}
                case false:
					{
                        break;
					}
			}
		}

        /*int AddCharaterArmId = 0;

        switch(CharaterArmIdArray[ItemFileJson.CharaterArm.Count - 1] > 9)
		{
            case true:
				{
                    AddCharaterArmId = CharaterArmIdArray[ItemFileJson.CharaterArm.Count - 1] + 1;
                    break;
				}
            case false:
				{
                    AddCharaterArmId = 10;
                    break;
				}
		}*/

        int NewArmPower_1 = 0, NewArmPower_2 = 0, NewArmPower_3 = 0, NewArmPower_4 = 0, NewArmPower_5 = 0, NewArmPower_6 = 0;
        float NewPowerMin_1 = 0, NewPowerMin_2 = 0, NewPowerMin_3 = 0, NewPowerMin_4 = 0, NewPowerMin_5 = 0, NewPowerMin_6 = 0, NewPowerMax_1 = 0, NewPowerMax_2 = 0, NewPowerMax_3 = 0, NewPowerMax_4 = 0, NewPowerMax_5 = 0, NewPowerMax_6 = 0;

        switch(CharaterGetArmId.Length == 0)
		{
            case true:
				{
                    break;
				}
            case false:
				{
                    for (int Num = 0; Num < CharaterGetArmId.Length; Num++)
                    {
                        Debug.Log("總共會獲得幾個裝備數量:" + CharaterGetArmId.Length);
                        Debug.Log("顯示到第" + Num + "個裝備編號:" + CharaterGetArmId[Num]);

                        PublicFunctionClone.ReadArm(CharaterGetArmId[Num]);

                        switch (ArmStatic.ArmRank)
                        {
                            case 0:
                                {
                                    NewArmPower_1 = 0;
                                    NewArmPower_2 = 0;
                                    NewArmPower_3 = 0;
                                    NewArmPower_4 = 0;
                                    NewArmPower_5 = 0;
                                    NewArmPower_6 = 0;
                                    NewPowerMin_1 = 0;
                                    NewPowerMin_2 = 0;
                                    NewPowerMin_3 = 0;
                                    NewPowerMin_4 = 0;
                                    NewPowerMin_5 = 0;
                                    NewPowerMin_6 = 0;
                                    NewPowerMax_1 = 0;
                                    NewPowerMax_2 = 0;
                                    NewPowerMax_3 = 0;
                                    NewPowerMax_4 = 0;
                                    NewPowerMax_5 = 0;
                                    NewPowerMax_6 = 0;
                                    break;
                                }
                            case 1:
                                {
                                    Debug.Log("裝備品階詞綴的數量" + ArmStatic.ArmPower.Length);
                                    int newarmpowerrandom_1 = UnityEngine.Random.Range(0, ArmStatic.ArmPower.Length - 1);
                                    int newarmpowerrandom_2 = UnityEngine.Random.Range(0, ArmStatic.ArmPower.Length - 1);
                                    Debug.Log("第一個數字:" + newarmpowerrandom_1);
                                    Debug.Log("第二個數字:" + newarmpowerrandom_2);
                                    NewArmPower_1 = ArmStatic.ArmPower[newarmpowerrandom_1];
                                    NewArmPower_2 = ArmStatic.ArmPower[newarmpowerrandom_2];
                                    Debug.Log("第一個詞綴數字:" + NewArmPower_1);
                                    Debug.Log("第二個詞綴數字:" + NewArmPower_2);
                                    PublicFunctionClone.ReadArmPower(NewArmPower_1);
                                    float newarmpowerrandomnum_1_min = 0, newarmpowerrandomnum_1_max = 0;
                                    switch (ArmPowerListStatic.PowerType)
                                    {
                                        case 0:
                                            {
                                                newarmpowerrandomnum_1_min = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max);
                                                newarmpowerrandomnum_1_min = Mathf.Round(newarmpowerrandomnum_1_min);
                                                break;
                                            }
                                        case 1:
                                            {
                                                newarmpowerrandomnum_1_min = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max);
                                                newarmpowerrandomnum_1_max = UnityEngine.Random.Range(ArmPowerListStatic.Power_1_Min, ArmPowerListStatic.Power_1_Max);
                                                newarmpowerrandomnum_1_min = Mathf.Round(newarmpowerrandomnum_1_min);
                                                newarmpowerrandomnum_1_max = Mathf.Round(newarmpowerrandomnum_1_max);
                                                break;
                                            }
                                    }
                                    PublicFunctionClone.ReadArmPower(NewArmPower_2);
                                    float newarmpowerrandomnum_2_min = 0, newarmpowerrandomnum_2_max = 0;
                                    switch (ArmPowerListStatic.PowerType)
                                    {
                                        case 0:
                                            {
                                                newarmpowerrandomnum_2_min = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max);
                                                newarmpowerrandomnum_2_min = Mathf.Round(newarmpowerrandomnum_2_min);
                                                break;
                                            }
                                        case 1:
                                            {
                                                newarmpowerrandomnum_2_min = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max);
                                                newarmpowerrandomnum_2_max = UnityEngine.Random.Range(ArmPowerListStatic.Power_1_Min, ArmPowerListStatic.Power_1_Max);
                                                newarmpowerrandomnum_2_min = Mathf.Round(newarmpowerrandomnum_2_min);
                                                newarmpowerrandomnum_2_max = Mathf.Round(newarmpowerrandomnum_2_max);
                                                break;
                                            }
                                    }
                                    NewArmPower_3 = 0;
                                    NewArmPower_4 = 0;
                                    NewArmPower_5 = 0;
                                    NewArmPower_6 = 0;
                                    NewPowerMin_1 = newarmpowerrandomnum_1_min;
                                    NewPowerMin_2 = newarmpowerrandomnum_2_min;
                                    NewPowerMin_3 = 0;
                                    NewPowerMin_4 = 0;
                                    NewPowerMin_5 = 0;
                                    NewPowerMin_6 = 0;
                                    NewPowerMax_1 = newarmpowerrandomnum_1_max;
                                    NewPowerMax_2 = newarmpowerrandomnum_2_max;
                                    NewPowerMax_3 = 0;
                                    NewPowerMax_4 = 0;
                                    NewPowerMax_5 = 0;
                                    NewPowerMax_6 = 0;
                                    break;
                                }
                            case 2:
                                {
                                    int newarmpowerrandom_1 = UnityEngine.Random.Range(0, ArmStatic.ArmPower[ArmStatic.ArmPower.Length - 1]);
                                    int newarmpowerrandom_2 = UnityEngine.Random.Range(0, ArmStatic.ArmPower[ArmStatic.ArmPower.Length - 1]);
                                    int newarmpowerrandom_3 = UnityEngine.Random.Range(0, ArmStatic.ArmPower[ArmStatic.ArmPower.Length - 1]);
                                    int newarmpowerrandom_4 = UnityEngine.Random.Range(0, ArmStatic.ArmPower[ArmStatic.ArmPower.Length - 1]);
                                    NewArmPower_1 = ArmStatic.ArmPower[newarmpowerrandom_1];
                                    NewArmPower_2 = ArmStatic.ArmPower[newarmpowerrandom_2];
                                    NewArmPower_3 = ArmStatic.ArmPower[newarmpowerrandom_3];
                                    NewArmPower_4 = ArmStatic.ArmPower[newarmpowerrandom_4];
                                    PublicFunctionClone.ReadArmPower(NewArmPower_1);
                                    float newarmpowerrandomnum_1_min = 0, newarmpowerrandomnum_1_max = 0;
                                    switch (ArmPowerListStatic.PowerType)
                                    {
                                        case 0:
                                            {
                                                newarmpowerrandomnum_1_min = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max);
                                                newarmpowerrandomnum_1_min = Mathf.Round(newarmpowerrandomnum_1_min);
                                                break;
                                            }
                                        case 1:
                                            {
                                                newarmpowerrandomnum_1_min = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max);
                                                newarmpowerrandomnum_1_max = UnityEngine.Random.Range(ArmPowerListStatic.Power_1_Min, ArmPowerListStatic.Power_1_Max);
                                                newarmpowerrandomnum_1_min = Mathf.Round(newarmpowerrandomnum_1_min);
                                                newarmpowerrandomnum_1_max = Mathf.Round(newarmpowerrandomnum_1_max);
                                                break;
                                            }
                                    }
                                    PublicFunctionClone.ReadArmPower(NewArmPower_2);
                                    float newarmpowerrandomnum_2_min = 0, newarmpowerrandomnum_2_max = 0;
                                    switch (ArmPowerListStatic.PowerType)
                                    {
                                        case 0:
                                            {
                                                newarmpowerrandomnum_2_min = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max);
                                                newarmpowerrandomnum_2_min = Mathf.Round(newarmpowerrandomnum_2_min);
                                                break;
                                            }
                                        case 1:
                                            {
                                                newarmpowerrandomnum_2_min = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max);
                                                newarmpowerrandomnum_2_max = UnityEngine.Random.Range(ArmPowerListStatic.Power_1_Min, ArmPowerListStatic.Power_1_Max);
                                                newarmpowerrandomnum_2_min = Mathf.Round(newarmpowerrandomnum_2_min);
                                                newarmpowerrandomnum_2_max = Mathf.Round(newarmpowerrandomnum_2_max);
                                                break;
                                            }
                                    }
                                    PublicFunctionClone.ReadArmPower(NewArmPower_3);
                                    float newarmpowerrandomnum_3_min = 0, newarmpowerrandomnum_3_max = 0;
                                    switch (ArmPowerListStatic.PowerType)
                                    {
                                        case 0:
                                            {
                                                newarmpowerrandomnum_3_min = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max);
                                                newarmpowerrandomnum_3_min = Mathf.Round(newarmpowerrandomnum_3_min);
                                                break;
                                            }
                                        case 1:
                                            {
                                                newarmpowerrandomnum_3_min = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max);
                                                newarmpowerrandomnum_3_max = UnityEngine.Random.Range(ArmPowerListStatic.Power_1_Min, ArmPowerListStatic.Power_1_Max);
                                                newarmpowerrandomnum_3_min = Mathf.Round(newarmpowerrandomnum_3_min);
                                                newarmpowerrandomnum_3_max = Mathf.Round(newarmpowerrandomnum_3_max);
                                                break;
                                            }
                                    }
                                    PublicFunctionClone.ReadArmPower(NewArmPower_4);
                                    float newarmpowerrandomnum_4_min = 0, newarmpowerrandomnum_4_max = 0;
                                    switch (ArmPowerListStatic.PowerType)
                                    {
                                        case 0:
                                            {
                                                newarmpowerrandomnum_4_min = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max);
                                                newarmpowerrandomnum_4_min = Mathf.Round(newarmpowerrandomnum_4_min);
                                                break;
                                            }
                                        case 1:
                                            {
                                                newarmpowerrandomnum_4_min = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max);
                                                newarmpowerrandomnum_4_max = UnityEngine.Random.Range(ArmPowerListStatic.Power_1_Min, ArmPowerListStatic.Power_1_Max);
                                                newarmpowerrandomnum_4_min = Mathf.Round(newarmpowerrandomnum_4_min);
                                                newarmpowerrandomnum_4_max = Mathf.Round(newarmpowerrandomnum_4_max);
                                                break;
                                            }
                                    }
                                    NewArmPower_5 = 0;
                                    NewArmPower_6 = 0;
                                    NewPowerMin_1 = newarmpowerrandomnum_1_min;
                                    NewPowerMin_2 = newarmpowerrandomnum_2_min;
                                    NewPowerMin_3 = newarmpowerrandomnum_3_min;
                                    NewPowerMin_4 = newarmpowerrandomnum_4_min;
                                    NewPowerMin_5 = 0;
                                    NewPowerMin_6 = 0;
                                    NewPowerMax_1 = newarmpowerrandomnum_1_max;
                                    NewPowerMax_2 = newarmpowerrandomnum_2_max;
                                    NewPowerMax_3 = newarmpowerrandomnum_3_max;
                                    NewPowerMax_4 = newarmpowerrandomnum_4_max;
                                    NewPowerMax_5 = 0;
                                    NewPowerMax_6 = 0;
                                    break;
                                }
                            case 3:
                                {
                                    int newarmpowerrandom_1 = UnityEngine.Random.Range(0, ArmStatic.ArmPower[ArmStatic.ArmPower.Length - 1]);
                                    int newarmpowerrandom_2 = UnityEngine.Random.Range(0, ArmStatic.ArmPower[ArmStatic.ArmPower.Length - 1]);
                                    int newarmpowerrandom_3 = UnityEngine.Random.Range(0, ArmStatic.ArmPower[ArmStatic.ArmPower.Length - 1]);
                                    int newarmpowerrandom_4 = UnityEngine.Random.Range(0, ArmStatic.ArmPower[ArmStatic.ArmPower.Length - 1]);
                                    int newarmpowerrandom_5 = UnityEngine.Random.Range(0, ArmStatic.ArmPower[ArmStatic.ArmPower.Length - 1]);
                                    int newarmpowerrandom_6 = UnityEngine.Random.Range(0, ArmStatic.ArmPower[ArmStatic.ArmPower.Length - 1]);
                                    NewArmPower_1 = ArmStatic.ArmPower[newarmpowerrandom_1];
                                    NewArmPower_2 = ArmStatic.ArmPower[newarmpowerrandom_2];
                                    NewArmPower_3 = ArmStatic.ArmPower[newarmpowerrandom_3];
                                    NewArmPower_4 = ArmStatic.ArmPower[newarmpowerrandom_4];
                                    NewArmPower_5 = ArmStatic.ArmPower[newarmpowerrandom_5];
                                    NewArmPower_6 = ArmStatic.ArmPower[newarmpowerrandom_6];
                                    PublicFunctionClone.ReadArmPower(NewArmPower_1);
                                    float newarmpowerrandomnum_1_min = 0, newarmpowerrandomnum_1_max = 0;
                                    switch (ArmPowerListStatic.PowerType)
                                    {
                                        case 0:
                                            {
                                                newarmpowerrandomnum_1_min = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max);
                                                newarmpowerrandomnum_1_min = Mathf.Round(newarmpowerrandomnum_1_min);
                                                break;
                                            }
                                        case 1:
                                            {
                                                newarmpowerrandomnum_1_min = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max);
                                                newarmpowerrandomnum_1_max = UnityEngine.Random.Range(ArmPowerListStatic.Power_1_Min, ArmPowerListStatic.Power_1_Max);
                                                newarmpowerrandomnum_1_min = Mathf.Round(newarmpowerrandomnum_1_min);
                                                newarmpowerrandomnum_1_max = Mathf.Round(newarmpowerrandomnum_1_max);
                                                break;
                                            }
                                    }
                                    PublicFunctionClone.ReadArmPower(NewArmPower_2);
                                    float newarmpowerrandomnum_2_min = 0, newarmpowerrandomnum_2_max = 0;
                                    switch (ArmPowerListStatic.PowerType)
                                    {
                                        case 0:
                                            {
                                                newarmpowerrandomnum_2_min = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max);
                                                newarmpowerrandomnum_2_min = Mathf.Round(newarmpowerrandomnum_2_min);
                                                break;
                                            }
                                        case 1:
                                            {
                                                newarmpowerrandomnum_2_min = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max);
                                                newarmpowerrandomnum_2_max = UnityEngine.Random.Range(ArmPowerListStatic.Power_1_Min, ArmPowerListStatic.Power_1_Max);
                                                newarmpowerrandomnum_2_min = Mathf.Round(newarmpowerrandomnum_2_min);
                                                newarmpowerrandomnum_2_max = Mathf.Round(newarmpowerrandomnum_2_max);
                                                break;
                                            }
                                    }
                                    PublicFunctionClone.ReadArmPower(NewArmPower_3);
                                    float newarmpowerrandomnum_3_min = 0, newarmpowerrandomnum_3_max = 0;
                                    switch (ArmPowerListStatic.PowerType)
                                    {
                                        case 0:
                                            {
                                                newarmpowerrandomnum_3_min = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max);
                                                newarmpowerrandomnum_3_min = Mathf.Round(newarmpowerrandomnum_3_min);
                                                break;
                                            }
                                        case 1:
                                            {
                                                newarmpowerrandomnum_3_min = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max);
                                                newarmpowerrandomnum_3_max = UnityEngine.Random.Range(ArmPowerListStatic.Power_1_Min, ArmPowerListStatic.Power_1_Max);
                                                newarmpowerrandomnum_3_min = Mathf.Round(newarmpowerrandomnum_3_min);
                                                newarmpowerrandomnum_3_max = Mathf.Round(newarmpowerrandomnum_3_max);
                                                break;
                                            }
                                    }
                                    PublicFunctionClone.ReadArmPower(NewArmPower_4);
                                    float newarmpowerrandomnum_4_min = 0, newarmpowerrandomnum_4_max = 0;
                                    switch (ArmPowerListStatic.PowerType)
                                    {
                                        case 0:
                                            {
                                                newarmpowerrandomnum_4_min = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max);
                                                newarmpowerrandomnum_4_min = Mathf.Round(newarmpowerrandomnum_4_min);
                                                break;
                                            }
                                        case 1:
                                            {
                                                newarmpowerrandomnum_4_min = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max);
                                                newarmpowerrandomnum_4_max = UnityEngine.Random.Range(ArmPowerListStatic.Power_1_Min, ArmPowerListStatic.Power_1_Max);
                                                newarmpowerrandomnum_4_min = Mathf.Round(newarmpowerrandomnum_4_min);
                                                newarmpowerrandomnum_4_max = Mathf.Round(newarmpowerrandomnum_4_max);
                                                break;
                                            }
                                    }
                                    PublicFunctionClone.ReadArmPower(NewArmPower_5);
                                    float newarmpowerrandomnum_5_min = 0, newarmpowerrandomnum_5_max = 0;
                                    switch (ArmPowerListStatic.PowerType)
                                    {
                                        case 0:
                                            {
                                                newarmpowerrandomnum_5_min = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max);
                                                newarmpowerrandomnum_5_min = Mathf.Round(newarmpowerrandomnum_5_min);
                                                break;
                                            }
                                        case 1:
                                            {
                                                newarmpowerrandomnum_5_min = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max);
                                                newarmpowerrandomnum_5_max = UnityEngine.Random.Range(ArmPowerListStatic.Power_1_Min, ArmPowerListStatic.Power_1_Max);
                                                newarmpowerrandomnum_5_min = Mathf.Round(newarmpowerrandomnum_5_min);
                                                newarmpowerrandomnum_5_max = Mathf.Round(newarmpowerrandomnum_5_max);
                                                break;
                                            }
                                    }
                                    PublicFunctionClone.ReadArmPower(NewArmPower_6);
                                    float newarmpowerrandomnum_6_min = 0, newarmpowerrandomnum_6_max = 0;
                                    switch (ArmPowerListStatic.PowerType)
                                    {
                                        case 0:
                                            {
                                                newarmpowerrandomnum_6_min = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max);
                                                newarmpowerrandomnum_6_min = Mathf.Round(newarmpowerrandomnum_6_min);
                                                break;
                                            }
                                        case 1:
                                            {
                                                newarmpowerrandomnum_6_min = UnityEngine.Random.Range(ArmPowerListStatic.Power_0_Min, ArmPowerListStatic.Power_0_Max);
                                                newarmpowerrandomnum_6_max = UnityEngine.Random.Range(ArmPowerListStatic.Power_1_Min, ArmPowerListStatic.Power_1_Max);
                                                newarmpowerrandomnum_6_min = Mathf.Round(newarmpowerrandomnum_6_min);
                                                newarmpowerrandomnum_6_max = Mathf.Round(newarmpowerrandomnum_6_max);
                                                break;
                                            }
                                    }
                                    NewPowerMin_1 = newarmpowerrandomnum_1_min;
                                    NewPowerMin_2 = newarmpowerrandomnum_2_min;
                                    NewPowerMin_3 = newarmpowerrandomnum_3_min;
                                    NewPowerMin_4 = newarmpowerrandomnum_4_min;
                                    NewPowerMin_5 = newarmpowerrandomnum_5_min;
                                    NewPowerMin_6 = newarmpowerrandomnum_6_min;
                                    NewPowerMax_1 = newarmpowerrandomnum_1_max;
                                    NewPowerMax_2 = newarmpowerrandomnum_2_max;
                                    NewPowerMax_3 = newarmpowerrandomnum_3_max;
                                    NewPowerMax_4 = newarmpowerrandomnum_4_max;
                                    NewPowerMax_5 = newarmpowerrandomnum_5_max;
                                    NewPowerMax_6 = newarmpowerrandomnum_6_max;
                                    break;
                                }
                        }

                        ArmFileJson.CharaterArm.Add(new CharaterArm()
                        {
                            id = NewArmId,
                            ArmPower_1 = NewArmPower_1,
                            ArmPower_2 = NewArmPower_2,
                            ArmPower_3 = NewArmPower_3,
                            ArmPower_4 = NewArmPower_4,
                            ArmPower_5 = NewArmPower_5,
                            ArmPower_6 = NewArmPower_6,
                            ArmMain = 0,
                            ArmEquip = false,
                            ArmBasicId = CharaterGetArmId[Num],
                            PowerMin_1 = NewPowerMin_1,
                            PowerMin_2 = NewPowerMin_2,
                            PowerMin_3 = NewPowerMin_3,
                            PowerMin_4 = NewPowerMin_4,
                            PowerMin_5 = NewPowerMin_5,
                            PowerMin_6 = NewPowerMin_6,
                            PowerMax_1 = NewPowerMax_1,
                            PowerMax_2 = NewPowerMax_2,
                            PowerMax_3 = NewPowerMax_3,
                            PowerMax_4 = NewPowerMax_4,
                            PowerMax_5 = NewPowerMax_5,
                            PowerMax_6 = NewPowerMax_6,
                        });
                        NewArmId++;
                    }
                    break;
				}
		}

        ArmFile = JsonUtility.ToJson(ArmFileJson);
        File.WriteAllText(PublicFunction.persistentFilePath, ArmFile);
        /*switch (CharaterGetArmIdNum != 0)
        {
            case true:
                {
                    BattleWin();
                    break;
                }
            case false:
                {
                    OpenMsgBoxClone.CreateMsgBox(33);
                    break;
                }
        }*/

        /*int[] newitemarray = new int[ItemFileJson.CharaterArm.Count];
        int newnum = 0;

        foreach (CharaterArm data in ItemFileJson.CharaterArm)
        {
            newitemarray[newnum] = data.Id;
            newnum++;
            Debug.Log(data.Id);
        }
        for (int num = 0; num < ItemFileJson.CharaterArm.Count; num++)
        {
            Debug.Log("整理前的陣列第" + num + "個編號:" + newitemarray[num]);
        }

        int nowid = 0, nowitemnum = 0, nextid = 0, nextitemnum = 0, stayid = 0, stayitemnum = 0;
        bool nowequip = false, nextequip = false, stayequip = false;

        for (int oldNum = ItemFileJson.CharaterArm.Count; oldNum >= 0; oldNum--)
        {
            for (int Num = 0; Num < ItemFileJson.CharaterArm.Count; Num++)
            {
                newnum = 0;
                foreach (CharaterArm data in ItemFileJson.CharaterArm)
                {
                    newitemarray[newnum] = data.Id;
                    newnum++;
                }
                switch (Num == ItemFileJson.CharaterArm.Count - 1)
                {
                    case true:
                        {
                            foreach (CharaterArm data in ItemFileJson.CharaterArm)
                            {
                                if (data.Id == newitemarray[Num - 1])
                                {
                                    nowid = data.Id;
                                    nowitemnum = data.ItemNum;
                                    nowequip = data.ItemEquip;
                                }
                                if (data.Id == newitemarray[Num])
                                {
                                    nextid = data.Id;
                                    nextitemnum = data.ItemNum;
                                    nextequip = data.ItemEquip;
                                    stayid = nextid;
                                    stayitemnum = nextitemnum;
                                    stayequip = nextequip;
                                }
                            }
                            if (nextid < nowid)
                            {
                                foreach (CharaterArm data in ItemFileJson.CharaterArm)
                                {
                                    if (data.Id == nowid)
                                    {
                                        data.Id = nowid + 1024;
                                    }
                                    if (data.Id == nextid)
                                    {
                                        data.Id = nextid + 2048;
                                    }
                                }
                                foreach (CharaterArm data in ItemFileJson.CharaterArm)
                                {
                                    if (data.Id == nextid + 2048)
                                    {
                                        data.Id = nowid;
                                        data.ItemNum = nowitemnum;
                                        data.ItemEquip = nowequip;
                                    }
                                    if (data.Id == nowid + 1024)
                                    {
                                        data.Id = stayid;
                                        data.ItemNum = stayitemnum;
                                        data.ItemEquip = stayequip;
                                    }
                                }
                            }
                            break;
                        }
                    case false:
                        {
                            foreach (CharaterArm data in ItemFileJson.CharaterArm)
                            {
                                if (data.Id == newitemarray[Num])
                                {
                                    nowid = data.Id;
                                    nowitemnum = data.ItemNum;
                                    nowequip = data.ItemEquip;
                                }
                                if (data.Id == newitemarray[Num + 1])
                                {
                                    nextid = data.Id;
                                    nextitemnum = data.ItemNum;
                                    nextequip = data.ItemEquip;
                                    stayid = nextid;
                                    stayitemnum = nextitemnum;
                                    stayequip = nextequip;
                                }
                            }
                            if (nextid < nowid)
                            {
                                foreach (CharaterArm data in ItemFileJson.CharaterArm)
                                {
                                    if (data.Id == nowid)
                                    {
                                        data.Id = nowid + 1024;
                                    }
                                    if (data.Id == nextid)
                                    {
                                        data.Id = nextid + 2048;
                                    }
                                }
                                foreach (CharaterArm data in ItemFileJson.CharaterArm)
                                {
                                    if (data.Id == nextid + 2048)
                                    {
                                        data.Id = nowid;
                                        data.ItemNum = nowitemnum;
                                        data.ItemEquip = nowequip;
                                    }
                                    if (data.Id == nowid + 1024)
                                    {
                                        data.Id = stayid;
                                        data.ItemNum = stayitemnum;
                                        data.ItemEquip = stayequip;
                                    }
                                }
                            }
                            break;
                        }
                }
            }
        }
        ItemFile = JsonUtility.ToJson(ItemFileJson);
        File.WriteAllText(PublicFunction.persistentFilePath, ItemFile);*/
    }

    public class JsonCharaterArm<T>                                                     //角色裝備表所使用的List，來協助unity可以讀取陣列(Array)裡的資料
    {
        public List<T> CharaterArm;
    }

    public void JudgeArmItemNum()                                                       //當玩家在戰鬥勝利後沒有獲得道具也沒有獲得裝備時的處理
	{
        switch(CharaterGetItemId.Length == 0 && CharaterGetArmId.Length == 0)
		{
            case true:
				{
                    Invoke("CharaterWin", 1);
                    break;
				}
            case false:
				{
                    Invoke("BattleWin", 1);
                    break;
				}
		}
	}

    public void EscapeBattle()                                                          //離開戰場
	{
        OpenMsgBoxClone.CreateMsgBox(35);
        PublicFunctionClone.ReadCharaterPropertyFileFunction(CharaterPropertyStatic.CharaterNumber);
        CharaterPropertyStatic.CharaterNowMap = CharaterPropertyStatic.CharaterLastMap;
        PublicFunctionClone.CharaterPropertyStaticChange();
        string FilePath = "Charater_" + CharaterPropertyStatic.CharaterNumber;
        string FileInside;

        PublicFunctionClone.ReadPlatformpersistentDataPath(FilePath);
        FileInside = JsonUtility.ToJson(PublicFunction.CharaterPropertyValue);
        File.WriteAllText(PublicFunction.persistentFilePath, FileInside);
    }   

    public void ShowCharaterDamge(float DamgeNum, string MonsterSkillName)              //顯示玩家受到的傷害
	{
        CharaterDamge.SetActive(true);
        float ShowDamge = Mathf.Round(DamgeNum);
        CharaterDamgeNum.text = ShowDamge.ToString();
        MonsterSkillNameObj.text = MonsterSkillName;
        Monster_Attack(MonsterStatic.MonsterId);
        Invoke("MonsterAttackFalse", 0.5f);
        Invoke("CharaterDamgeDisappear", 0.5f);
    }

    public void ShowMonsterDamge(float DamgeNum, string CharaterSkillName)              //顯示怪獸受到的傷害
    {
        MonsterDamge.SetActive(true);
        float ShowDamge = Mathf.Round(DamgeNum);
        MonsterDamgeNum.text = ShowDamge.ToString();
        CharaterSkillNameObj.text = CharaterSkillName;
        Player_Ani.SetBool("Attack_1", true);
        Invoke("PlayerAttackFalse", 0.5f);
        Invoke("MonsterDamgeDisappear", 1);
    }

    public void CharaterDamgeDisappear()                                                //把玩家受到傷害的顯示隱藏
	{
        CharaterDamge.SetActive(false);
    }

    public void MonsterDamgeDisappear()                                                 //把怪獸受到傷害的顯示隱藏
    {
        MonsterDamge.SetActive(false);
    }

    public void ClearArmAndItemList()                                                   //(保留，但未使用，這是另外一種處理方式)清除上一場戰鬥中獲得的道具和裝備物件
	{
        switch(Grid_Load_Item.transform.childCount == 0)
		{
            case true:
				{
                    break;
				}
            case false:
				{
                    for (int num = 0; num < Grid_Load_Item.transform.childCount; num++)
                    {
                        GameObject ChildObject = Grid_Load_Item.transform.GetChild(num).gameObject;
                        Destroy(ChildObject);
                    }
                    break;
				}
		}
        switch(Grid_Load_Item.transform.childCount == 0)
		{
            case true:
				{
                    break;
				}
            case false:
				{
                    for (int num = 0; num < Grid_Load_Item.transform.childCount; num++)
                    {
                        GameObject ChildObject = Grid_Load_Item.transform.GetChild(num).gameObject;
                        Destroy(ChildObject);
                    }
                    break;
				}
		}     
    }

    public void PlayerSkillCountDown()                                                  //角色顯示各個技能的倒數時間
	{
        //-----顯示角色技能倒數
        PlayerSkillCount_1.text = CharaterBattleSkillTime[0] - BattleTime + "";
        PlayerSkillCount_2.text = CharaterBattleSkillTime[1] - BattleTime + "";
        PlayerSkillCount_3.text = CharaterBattleSkillTime[2] - BattleTime + "";
        PlayerSkillCount_4.text = CharaterBattleSkillTime[3] - BattleTime + "";
        PlayerSkillCount_5.text = CharaterBattleSkillTime[4] - BattleTime + "";
        //-----

        //-----顯示下一個要施放的技能
        switch (CharaterSkillTurn)
		{
            case 0:
				{
                    PlayerHighLight_1.SetActive(true);
                    PlayerHighLight_2.SetActive(false);
                    PlayerHighLight_3.SetActive(false);
                    PlayerHighLight_4.SetActive(false);
                    PlayerHighLight_5.SetActive(false);
                    break;
				}
            case 1:
				{
                    PlayerHighLight_1.SetActive(false);
                    PlayerHighLight_2.SetActive(true);
                    PlayerHighLight_3.SetActive(false);
                    PlayerHighLight_4.SetActive(false);
                    PlayerHighLight_5.SetActive(false);
                    break;
				}
            case 2:
				{
                    PlayerHighLight_1.SetActive(false);
                    PlayerHighLight_2.SetActive(false);
                    PlayerHighLight_3.SetActive(true);
                    PlayerHighLight_4.SetActive(false);
                    PlayerHighLight_5.SetActive(false);
                    break;
				}
            case 3:
				{
                    PlayerHighLight_1.SetActive(false);
                    PlayerHighLight_2.SetActive(false);
                    PlayerHighLight_3.SetActive(false);
                    PlayerHighLight_4.SetActive(true);
                    PlayerHighLight_5.SetActive(false);
                    break;
				}
            case 4:
				{
                    PlayerHighLight_1.SetActive(false);
                    PlayerHighLight_2.SetActive(false);
                    PlayerHighLight_3.SetActive(false);
                    PlayerHighLight_4.SetActive(false);
                    PlayerHighLight_5.SetActive(true);
                    break;
				}
		}
        //-----

        //-----顯示角色技能倒數的圖示
        PlayerSkillReady_1.fillAmount = (CharaterBattleSkillTime[0] - BattleTime) / PlayerSkillCoolDown_1;
        PlayerSkillReady_2.fillAmount = (CharaterBattleSkillTime[1] - BattleTime) / PlayerSkillCoolDown_2;
        PlayerSkillReady_3.fillAmount = (CharaterBattleSkillTime[2] - BattleTime) / PlayerSkillCoolDown_3;
        PlayerSkillReady_4.fillAmount = (CharaterBattleSkillTime[3] - BattleTime) / PlayerSkillCoolDown_4;
        PlayerSkillReady_5.fillAmount = (CharaterBattleSkillTime[4] - BattleTime) / PlayerSkillCoolDown_5;
        //-----
    }

    public void MonsterSkillCountDown()                                                 //顯示怪獸各個技能的倒數時間
	{
        //-----顯示怪獸技能倒數
        MonsterSkillCount_1.text = MonsterSkillTime[0] - BattleTime + "";
        MonsterSkillCount_2.text = MonsterSkillTime[1] - BattleTime + "";
        MonsterSkillCount_3.text = MonsterSkillTime[2] - BattleTime + "";
        MonsterSkillCount_4.text = MonsterSkillTime[3] - BattleTime + "";
        MonsterSkillCount_5.text = MonsterSkillTime[4] - BattleTime + "";
        //-----

        //-----顯示下一個要施放的技能
        switch (MonsterSkillTurn)
        {
            case 0:
                {
                    MonsterHighLight_1.SetActive(true);
                    MonsterHighLight_2.SetActive(false);
                    MonsterHighLight_3.SetActive(false);
                    MonsterHighLight_4.SetActive(false);
                    MonsterHighLight_5.SetActive(false);
                    break;
                }
            case 1:
                {
                    MonsterHighLight_1.SetActive(false);
                    MonsterHighLight_2.SetActive(true);
                    MonsterHighLight_3.SetActive(false);
                    MonsterHighLight_4.SetActive(false);
                    MonsterHighLight_5.SetActive(false);
                    break;
                }
            case 2:
                {
                    MonsterHighLight_1.SetActive(false);
                    MonsterHighLight_2.SetActive(false);
                    MonsterHighLight_3.SetActive(true);
                    MonsterHighLight_4.SetActive(false);
                    MonsterHighLight_5.SetActive(false);
                    break;
                }
            case 3:
                {
                    MonsterHighLight_1.SetActive(false);
                    MonsterHighLight_2.SetActive(false);
                    MonsterHighLight_3.SetActive(false);
                    MonsterHighLight_4.SetActive(true);
                    MonsterHighLight_5.SetActive(false);
                    break;
                }
            case 4:
                {
                    MonsterHighLight_1.SetActive(false);
                    MonsterHighLight_2.SetActive(false);
                    MonsterHighLight_3.SetActive(false);
                    MonsterHighLight_4.SetActive(false);
                    MonsterHighLight_5.SetActive(true);
                    break;
                }
        }
        //-----

        //-----顯示怪獸技能倒數的圖示
        MonsterSkillReady_1.fillAmount = (MonsterSkillTime[0] - BattleTime) / MonsterSkillCoolDown_1;
        MonsterSkillReady_2.fillAmount = (MonsterSkillTime[1] - BattleTime) / MonsterSkillCoolDown_2;
        MonsterSkillReady_3.fillAmount = (MonsterSkillTime[2] - BattleTime) / MonsterSkillCoolDown_3;
        MonsterSkillReady_4.fillAmount = (MonsterSkillTime[3] - BattleTime) / MonsterSkillCoolDown_4;
        MonsterSkillReady_5.fillAmount = (MonsterSkillTime[4] - BattleTime) / MonsterSkillCoolDown_5;
        //-----
    }

    public void ClickCloseCount()                                                       //關閉倒數特效
	{
        switch(CloseCountNum)
		{
            case 0:
				{
                    PlayerSkillCountObj_1.SetActive(false);
                    PlayerSkillReadytObj_1.SetActive(false);
                    PlayerSkillCountObj_2.SetActive(false);
                    PlayerSkillReadytObj_2.SetActive(false);
                    PlayerSkillCountObj_3.SetActive(false);
                    PlayerSkillReadytObj_3.SetActive(false);
                    PlayerSkillCountObj_4.SetActive(false);
                    PlayerSkillReadytObj_4.SetActive(false);
                    PlayerSkillCountObj_5.SetActive(false);
                    PlayerSkillReadytObj_5.SetActive(false);

                    MonsterSkillCountObj_1.SetActive(false);
                    MonsterSkillReadytObj_1.SetActive(false);
                    MonsterSkillCountObj_2.SetActive(false);
                    MonsterSkillReadytObj_2.SetActive(false);
                    MonsterSkillCountObj_3.SetActive(false);
                    MonsterSkillReadytObj_3.SetActive(false);
                    MonsterSkillCountObj_4.SetActive(false);
                    MonsterSkillReadytObj_4.SetActive(false);
                    MonsterSkillCountObj_5.SetActive(false);
                    MonsterSkillReadytObj_5.SetActive(false);
                    CloseCountNum = 1;
                    break;
				}
            case 1:
				{
                    PlayerSkillCountObj_1.SetActive(true);
                    PlayerSkillReadytObj_1.SetActive(true);
                    PlayerSkillCountObj_2.SetActive(true);
                    PlayerSkillReadytObj_2.SetActive(true);
                    PlayerSkillCountObj_3.SetActive(true);
                    PlayerSkillReadytObj_3.SetActive(true);
                    PlayerSkillCountObj_4.SetActive(true);
                    PlayerSkillReadytObj_4.SetActive(true);
                    PlayerSkillCountObj_5.SetActive(true);
                    PlayerSkillReadytObj_5.SetActive(true);

                    MonsterSkillCountObj_1.SetActive(true);
                    MonsterSkillReadytObj_1.SetActive(true);
                    MonsterSkillCountObj_2.SetActive(true);
                    MonsterSkillReadytObj_2.SetActive(true);
                    MonsterSkillCountObj_3.SetActive(true);
                    MonsterSkillReadytObj_3.SetActive(true);
                    MonsterSkillCountObj_4.SetActive(true);
                    MonsterSkillReadytObj_4.SetActive(true);
                    MonsterSkillCountObj_5.SetActive(true);
                    MonsterSkillReadytObj_5.SetActive(true);
                    CloseCountNum = 0;
                    break;
				}
		}      
    }

    public void PlayerSkillCoolDown()                                                   //計算角色技能倒數時所使用的分母
	{
        switch (CharaterSkillTurn)
        {
            case 0:
                {
                    PlayerSkillCoolDown_1 = CharaterBattleSkillTime[CharaterSkillTurn] - BattleTime;
                    break;
                }
            case 1:
                {
                    PlayerSkillCoolDown_2 = CharaterBattleSkillTime[CharaterSkillTurn] - BattleTime;
                    break;
                }
            case 2:
                {
                    PlayerSkillCoolDown_3 = CharaterBattleSkillTime[CharaterSkillTurn] - BattleTime;
                    break;
                }
            case 3:
                {
                    PlayerSkillCoolDown_4 = CharaterBattleSkillTime[CharaterSkillTurn] - BattleTime;
                    break;
                }
            case 4:
                {
                    PlayerSkillCoolDown_5 = CharaterBattleSkillTime[CharaterSkillTurn] - BattleTime;
                    break;
                }
        }
    }

    public void MonsterSkillCoolDown()                                                  //計算怪獸技能倒數時所使用的分母
    {
        switch (MonsterSkillTurn)
        {
            case 0:
                {
                    MonsterSkillCoolDown_1 = MonsterSkillTime[MonsterSkillTurn] - BattleTime;
                    break;
                }
            case 1:
                {
                    MonsterSkillCoolDown_2 = MonsterSkillTime[MonsterSkillTurn] - BattleTime;
                    break;
                }
            case 2:
                {
                    MonsterSkillCoolDown_3 = MonsterSkillTime[MonsterSkillTurn] - BattleTime;
                    break;
                }
            case 3:
                {
                    MonsterSkillCoolDown_4 = MonsterSkillTime[MonsterSkillTurn] - BattleTime;
                    break;
                }
            case 4:
                {
                    MonsterSkillCoolDown_5 = MonsterSkillTime[MonsterSkillTurn] - BattleTime;
                    break;
                }
        }
    }

    public void PlayerAttackFalse()                                                     //關閉角色攻擊動畫
	{
        Player_Ani.GetComponent<Animator>().SetBool("Attack_1", false);
    }

    public void LoadMonsterAni()                                                        //載入怪物動畫
	{
        switch(MonsterStatic.MonsterId)
		{
            case 0:
				{
                    Monster_Ani.SetBool("Monster_Idle_1", true);
                    Monster_Ani.SetBool("Monster_Idle_2", false);
                    Monster_Ani.SetBool("Monster_Idle_3", false);
                    Monster_Ani.SetBool("Monster_Attack_1", false);
                    Monster_Ani.SetBool("Monster_Attack_2", false);
                    Monster_Ani.SetBool("Monster_Attack_3", false);
                    break;
				}
            case 1:
				{
                    Monster_Ani.SetBool("Monster_Idle_1", false);
                    Monster_Ani.SetBool("Monster_Idle_2", true);
                    Monster_Ani.SetBool("Monster_Idle_3", false);
                    Monster_Ani.SetBool("Monster_Attack_1", false);
                    Monster_Ani.SetBool("Monster_Attack_2", false);
                    Monster_Ani.SetBool("Monster_Attack_3", false);
                    break;
				}
            case 2:
				{
                    Monster_Ani.SetBool("Monster_Idle_1", false);
                    Monster_Ani.SetBool("Monster_Idle_2", false);
                    Monster_Ani.SetBool("Monster_Idle_3", true);
                    Monster_Ani.SetBool("Monster_Attack_1", false);
                    Monster_Ani.SetBool("Monster_Attack_2", false);
                    Monster_Ani.SetBool("Monster_Attack_3", false);
                    break;
				}
		}
	}

    public void Monster_Attack(int MonsterId)                                           //載入怪物攻擊動畫
	{
        switch (MonsterId)
        {
            case 0:
                {
                    Monster_Ani.SetBool("Monster_Idle_1", false);
                    Monster_Ani.SetBool("Monster_Idle_2", false);
                    Monster_Ani.SetBool("Monster_Idle_3", false);
                    Monster_Ani.SetBool("Monster_Attack_1", true);
                    Monster_Ani.SetBool("Monster_Attack_2", false);
                    Monster_Ani.SetBool("Monster_Attack_3", false);
                    break;
                }
            case 1:
                {
                    Monster_Ani.SetBool("Monster_Idle_1", false);
                    Monster_Ani.SetBool("Monster_Idle_2", false);
                    Monster_Ani.SetBool("Monster_Idle_3", false);
                    Monster_Ani.SetBool("Monster_Attack_1", false);
                    Monster_Ani.SetBool("Monster_Attack_2", true);
                    Monster_Ani.SetBool("Monster_Attack_3", false);
                    break;
                }
            case 2:
                {
                    Monster_Ani.SetBool("Monster_Idle_1", false);
                    Monster_Ani.SetBool("Monster_Idle_2", false);
                    Monster_Ani.SetBool("Monster_Idle_3", false);
                    Monster_Ani.SetBool("Monster_Attack_1", false);
                    Monster_Ani.SetBool("Monster_Attack_2", false);
                    Monster_Ani.SetBool("Monster_Attack_3", true);
                    break;
                }
        }
    }

    public void MonsterAttackFalse()                                                    //關閉怪物攻擊動畫
	{
        switch (MonsterStatic.MonsterId)
        {
            case 0:
                {
                    Monster_Ani.SetBool("Monster_Idle_1", true);
                    Monster_Ani.SetBool("Monster_Idle_2", false);
                    Monster_Ani.SetBool("Monster_Idle_3", false);
                    Monster_Ani.SetBool("Monster_Attack_1", false);
                    Monster_Ani.SetBool("Monster_Attack_2", false);
                    Monster_Ani.SetBool("Monster_Attack_3", false);
                    break;
                }
            case 1:
                {
                    Monster_Ani.SetBool("Monster_Idle_1", false);
                    Monster_Ani.SetBool("Monster_Idle_2", true);
                    Monster_Ani.SetBool("Monster_Idle_3", false);
                    Monster_Ani.SetBool("Monster_Attack_1", false);
                    Monster_Ani.SetBool("Monster_Attack_2", false);
                    Monster_Ani.SetBool("Monster_Attack_3", false);
                    break;
                }
            case 2:
                {
                    Monster_Ani.SetBool("Monster_Idle_1", false);
                    Monster_Ani.SetBool("Monster_Idle_2", false);
                    Monster_Ani.SetBool("Monster_Idle_3", true);
                    Monster_Ani.SetBool("Monster_Attack_1", false);
                    Monster_Ani.SetBool("Monster_Attack_2", false);
                    Monster_Ani.SetBool("Monster_Attack_3", false);
                    break;
                }
        }
    }

    public void CharaterDie()                                                           //延遲角色死亡訊息
	{
        OpenMsgBoxClone.CreateMsgBox(32);
    }

    public void CharaterWin()                                                           //延遲角色勝利訊息
	{
        OpenMsgBoxClone.CreateMsgBox(33);
    }
}
