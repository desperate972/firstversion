using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SkillStatic 
{
	public static int SkillId;                     //技能編號
	public static int SkillType;                   //技能類型，0 = 物理，1 = 魔法
	public static int SkillCharaterMonster;        //技能是給誰用，0 = 只給角色用，1 = 只給怪物用，2 = 角色跟怪物都可用
	public static float[] SkillLevelNum;           //技能個等級的數值
	public static string SkillName;                //技能名稱
	public static int SkillBattleType;             //技能是否吟唱，0 = 不用吟唱，1 = 需要吟唱
	public static float[] SkillTime;               //技能所需的施放時間
	public static int[] SkillCost;                 //技能需要消耗的魔力
	public static string SkillICONName;            //技能ICON
	//public static string SkillContent_0;         //技能敘述
	//public static string SkillContent_1;         //技能敘述
    //public static int SkillExtraType;            //技能額外效果，0 = 沒有額外效果，1 = 灼傷，2 = 冰凍，3 = 中毒
    //public static int[] SkillExtraLevelNum;      //技能額外效果，每等級會造成的機率
}
