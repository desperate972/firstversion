using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Monster 
{
    public int MonsterId;                        // 怪物編號
    public float MonsterPhysicalDamgeMin;        // 怪物最小物理攻擊力，隨怪物等級改變
    public float MonsterPhysicalDamgeMax;        // 怪物最大物理攻擊力，隨怪物等級改變
    public float MonsterPhysicalDamgeLevel;      // 怪物的物理攻擊力，隨等級成長的數值
    public float MonsterDodgeRate;               // 怪物閃避率，固定機率，不會隨怪物等級改變
    public float MonsterCriticalRate;            // 怪物爆擊率，固定機率，不會隨怪物等級改變
    public float MonsterMagicDamgeMin;           // 怪物最小魔法攻擊力，隨怪物等級改變
    public float MonsterMagicDamgeMax;           // 怪物最大魔法攻擊力，隨怪物等級改變
    public float MonsterMagicDamgeLevel;         // 怪物的魔法攻擊力，隨等級成長的數值
    public float MonsterHp;                      // 怪物血量，隨怪物等級改變
    public float MonsterHpLevel;                 // 怪物的成長血量，隨等級成長的數值
    public float MonsterMp;                      // 怪物魔力，隨怪物等級改變
    public float MonsterMpLevel;                 // 怪物的成長魔力，隨等級成長的數值
    public float MonsterHpRateRecover;           // 怪物每秒回血比率，不會隨怪物等級改變
    public float MonsterMpRateRecover;           // 怪物每秒回魔比率，不會隨怪物等級改變
    public float MonsterPhysicalResistRate;      // 怪物物理抵抗率，固定機率，不會隨怪物等級改變
    public float MonsterMagicShield;             // 怪物魔法護盾值，隨怪物等級改變
    public float MpnsterMagixShieldLevel;        // 怪物的成長魔法護盾，隨等級成長的數值
    public float MonsterMagicShieldRateRecover;  // 怪物每秒魔法護盾回復比率，不會隨怪物等級改變
    public int MonsterLevelMin;                  // 怪物等級最小值
    public int MonsterLevelMax;                  // 怪物等級最大值
    public int[] MonsterSkill;                   // 怪物技能
    public int[] MonsterSkillLevel;              // 怪物技能的等級
    public float MonsterHpNow;                   // 怪物當前血量，用來顯示在介面上，並會隨著受到的傷害改變
    public float MonsterMpNow;                   // 怪物當前魔力，用來顯示在介面上，並會隨著使用技能的消耗改變
    public float MonsterMagicShieldNow;          // 怪物當前法術護盾，用來顯示在介面上，並隨著受到的傷害改變
    public string MonsterName;                   // 怪物名稱
    public int[] MonsterDieItem;                 // 怪物會掉落的東西
    public int[] MonsterDieItemRate;             // 怪物掉落東西的各個機率
    public int[] MonsterDieItemNum;              // 怪物掉落東西的數量
    public int[] MonsterDieArm;                  // 怪物掉落的裝備
    public int[] MonsterDieArmRate;              // 怪物掉落裝備的各個機率
    public int[] MonsterDieArmNum;               // 怪物掉落裝備的數量
    public string MonsterIcon;                   // 怪物的圖
}
