using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharaterProperty
{
    public string Charater;
    public int CharaterSex;                     // 1 = 男 0 = 女
    public float CharaterProperty_Strength;     // 角色力量數值
    public float CharaterProperty_Intelligence; // 角色智力數值
    public float CharaterProperty_Dexterity;    // 角色敏捷數值
    public string HeadSprite;                   // 角色頭部外觀，Atlas裡面圖的名稱
    public string BodySprite;                   // 角色身體外觀，Atlas裡面圖的名稱
    public string FootSprite;                   // 角色腿部外觀，Atlas裡面圖的名稱
    public int CharaterLevel;                   // 角色等級
    public string CharaterName;                 // 角色名稱
    public string CharaterJobName;              // 角色職業(無實質作用，只是稱號)

    public float CharaterPhysicalDamgeMin;      // 角色最小物理攻擊力
    public float CharaterPhysicalDamgeMax;      // 角色最大物理攻擊力
    public float CharaterDodge;                 // 角色閃避值
    public float CharaterDodgeRate;             // 角色閃避率
    public float CharaterDodgeMax;              // 角色最大閃避值
    public float CharaterCritical;              // 角色爆擊值
    public float CharaterCriticalRate;          // 角色爆擊率
    public float CharaterCriticalMax;           // 角色最大爆擊值
    public float CharaterMagicDamgeMin;         // 角色最小魔法攻擊力
    public float CharaterMagicDamgeMax;         // 角色最大魔法攻擊力
    public float CharaterHp;                    // 角色血量
    public float CharaterMp;                    // 角色魔力
    public float CharaterHpRecover;             // 角色每秒回血數
    public float CharaterMpRecover;             // 角色每秒回魔數
    public float CharaterPhysicalResist;        // 角色物理抵抗值
    public float CharaterPhysicalResistRate;    // 角色物理抵抗率
    public float CharaterPhysicalResistMax;     // 角色最大物理抵抗值
    public float CharaterMagicShield;           // 角色魔法護盾值
    public float CharaterMagicShieldRecover;    // 角色每秒魔法護盾回復數
    public float CharaterExp;                   // 角色經驗值
    public float CharaterHpNow;                 // 角色當前血量
    public float CharaterMpNow;                 // 角色當前魔力

    public int CharaterNumber;                  // 角色順序
    public int CharaterLastPoint;               // 角色尚未分配的點數
    public float CharaterHpNowRate;             // 目前角色的血量百分比
    public float CharaterMpNowRate;             // 目前角色的魔力百分比
    public int CharaterExpNow;                  // 目前角色的經驗值
    public float CharaterMagicShieldNow;        // 角色當前魔法護盾值
    public float CharaterAttackSpeed;           // 角色攻擊速度
    public int CharaterMoney;                   // 角色擁有的金錢
    public int CharaterLastMap;                 // 角色最後所在的地圖，注意的是野圖不算，所以這裡只會紀錄城鎮的地圖
    public int CharaterNowMap;                  // 角色當前所在的地圖，但重新開啟遊戲後就會改成最後所在的城鎮地圖
}
