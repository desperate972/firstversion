using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharaterPropertyStatic
{
    public static string Charater;
    public static int CharaterSex;                     // 1 = 男 0 = 女
    public static float CharaterProperty_Strength;     // 角色力量數值
    public static float CharaterProperty_Intelligence; // 角色智力數值
    public static float CharaterProperty_Dexterity;    // 角色敏捷數值
    public static string HeadSprite;                   // 角色頭部外觀，Atlas裡面圖的名稱
    public static string BodySprite;                   // 角色身體外觀，Atlas裡面圖的名稱
    public static string FootSprite;                   // 角色腿部外觀，Atlas裡面圖的名稱
    public static int CharaterLevel;                   // 角色等級
    public static string CharaterName;                 // 角色名稱
    public static string CharaterJobName;              // 角色職業(無實質作用，只是稱號)

    public static float CharaterPhysicalDamgeMin;      // 角色最小物理攻擊力
    public static float CharaterPhysicalDamgeMax;      // 角色最大物理攻擊力
    public static float CharaterDodge;                 // 角色閃避值
    public static float CharaterDodgeRate;             // 角色閃避率
    public static float CharaterDodgeMax;              // 角色最大閃避值
    public static float CharaterCritical;              // 角色爆擊值
    public static float CharaterCriticalRate;          // 角色爆擊率
    public static float CharaterCriticalMax;           // 角色最大爆擊值
    public static float CharaterMagicDamgeMin;         // 角色最小魔法攻擊力
    public static float CharaterMagicDamgeMax;         // 角色最大魔法攻擊力
    public static float CharaterHp;                    // 角色血量
    public static float CharaterMp;                    // 角色魔力
    public static float CharaterHpRecover;             // 角色回血速度
    public static float CharaterMpRecover;             // 角色回魔速度
    public static float CharaterPhysicalResist;        // 角色物理抵抗值
    public static float CharaterPhysicalResistRate;    // 角色物理抵抗率
    public static float CharaterPhysicalResistMax;     // 角色最大物理抵抗值
    public static float CharaterMagicShield;           // 角色魔法護盾值
    public static float CharaterMagicShieldRecover;    // 角色每秒魔法護盾回復數
    public static float CharaterExp;                   // 角色經驗值
    public static float CharaterHpNow;                 // 角色當前血量
    public static float CharaterMpNow;                 // 角色當前魔力

    public static int CharaterNumber;                  // 角色順序
    public static int CharaterLastPoint;               // 角色尚未分配的點數
    public static float CharaterHpNowRate;             // 目前角色的血量百分比
    public static float CharaterMpNowRate;             // 目前角色的魔力百分比
    public static int CharaterExpNow;                  // 目前角色的經驗值
    public static float CharaterMagicShieldNow;        // 角色當前魔法護盾值
    public static float CharaterAttackSpeed;           // 角色攻擊速度
    public static int CharaterMoney;                   // 角色擁有金錢
    public static int CharaterLastMap;                 // 角色最後所在的地圖，注意的是野圖不算，所以這裡只會紀錄城鎮的地圖
    public static int CharaterNowMap;                  // 角色當前所在的地圖，但重新開啟遊戲後就會改成最後所在的城鎮地圖
}
