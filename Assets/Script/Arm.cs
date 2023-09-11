﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Arm
{
	public int BasicId;                       //裝備的ID
	public string ArmName;                    //裝備名稱
    public string ArmIconName;                //裝備ICON圖的名稱
    public int ArmType;                       //用來判斷該裝備是哪個部位，0 = 武器，1 = 頭部，2 = 身體，3 = 戒指，4 = 項鍊，5 = 手套，6 = 腰帶，7 = 腿部
    public int ArmLv;                         //該裝備的需求等級
    public int WeaponDamageMin;               //該裝備的最小物理攻擊
    public int WeaponDamageMax;               //該裝備的最大物理攻擊
    public float WeaponSpeed;                 //該裝備的攻擊速度
    public int ArmRequest_Strength;           //該裝備的力量需求裝備
    public int ArmRequest_Intelligence;       //該裝備的智力需求裝備
    public int ArmRequest_Dexterity;          //該裝備的敏捷需求裝備
    public float ArmArmor;                    //該裝備的護甲數值
    public float ArmMagicShield;              //該裝備的法術護盾數值
    public float ArmDodge;                    //該裝備的閃避數值
    public int ArmRank;                       //該裝備的品階，品階決定裝備有的詞綴數量，0 = 0條詞綴，1 = 2條詞綴，2 = 4條詞綴，3 = 6條詞綴
    public int[] ArmPower;                    //該裝備可能會獲得的詞綴陣列
}