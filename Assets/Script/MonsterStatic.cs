using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MonsterStatic
{
    public static int MonsterId;                        // 怪物編號
    public static float MonsterPhysicalDamgeMin;        // 怪物最小物理攻擊力，隨怪物等級改變
    public static float MonsterPhysicalDamgeMax;        // 怪物最大物理攻擊力，隨怪物等級改變
    public static float MonsterPhysicalDamgeLevel;      // 怪物的物理攻擊力，隨等級成長的數值
    public static float MonsterDodgeRate;               // 怪物閃避率，固定機率，不會隨怪物等級改變
    public static float MonsterCriticalRate;            // 怪物爆擊率，固定機率，不會隨怪物等級改變
    public static float MonsterMagicDamgeMin;           // 怪物最小魔法攻擊力，隨怪物等級改變
    public static float MonsterMagicDamgeMax;           // 怪物最大魔法攻擊力，隨怪物等級改變
    public static float MonsterMagicDamgeLevel;         // 怪物的魔法攻擊力，隨等級成長的數值
    public static float MonsterHp;                      // 怪物血量，隨怪物等級改變
    public static float MonsterHpLevel;                 // 怪物的成長血量，隨等級成長的數值
    public static float MonsterMp;                      // 怪物魔力，隨怪物等級改變
    public static float MonsterMpLevel;                 // 怪物的成長魔力，隨等級成長的數值
    public static float MonsterHpRateRecover;           // 怪物每秒回血比率，不會隨怪物等級改變
    public static float MonsterMpRateRecover;           // 怪物每秒回魔比率，不會隨怪物等級改變
    public static float MonsterPhysicalResistRate;      // 怪物物理抵抗率，固定機率，不會隨怪物等級改變
    public static float MonsterMagicShield;             // 怪物魔法護盾值，隨怪物等級改變
    public static float MpnsterMagixShieldLevel;        // 怪物的成長魔法護盾，隨等級成長的數值
    public static float MonsterMagicShieldRateRecover;  // 怪物每秒魔法護盾回復比率，不會隨怪物等級改變
    public static int MonsterLevelMin;                  // 怪物等級最小值
    public static int MonsterLevelMax;                  // 怪物等級最大值
    public static int[] MonsterSkill;                   // 怪物技能
    public static int[] MonsterSkillLevel;              // 怪物技能的等級
    public static float MonsterHpNow;                   // 怪物當前血量，用來顯示在介面上，並會隨著受到的傷害改變
    public static float MonsterMpNow;                   // 怪物當前魔力，用來顯示在介面上，並會隨著使用技能的消耗改變
    public static float MonsterMagicShieldNow;          // 怪物當前法術護盾，用來顯示在介面上，並隨著受到的傷害改變
    public static string MonsterName;                   // 怪物名稱
    public static int[] MonsterDieItem;                 // 怪物會掉落的東西
    public static int[] MonsterDieItemRate;             // 怪物掉落東西的各個機率
    public static int[] MonsterDieItemNum;              // 怪物掉落東西的數量
    public static int[] MonsterDieArm;                  // 怪物掉落的裝備
    public static int[] MonsterDieArmRate;              // 怪物掉落裝備的各個機率
    public static int[] MonsterDieArmNum;               // 怪物掉落裝備的數量
    public static string MonsterIcon;                   // 怪物的圖
}
