using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ArmPowerListStatic
{
    public static int Id;                  //該詞墜的ID
    public static int PowerLevelMin;       //該詞墜給予數值的最小值
    public static int PowerLevelMax;       //該詞墜給予數值的最大值
    public static int PowerType;           //該詞贅數值是需要兩個值還是一個值的判斷，例如力量只需要一個值，就會從最小直到最大值隨機骰出一個值，若是物理攻擊，則會從Power_0的最小值到最大值骰出一個物理最小值，再從Power_1的最小值到最大值骰出一個物理最大值
    public static string PowerName;        //該詞墜的名稱
    public static float Power_0_Min;       //詞墜類型0所需要骰出數值的最小值
    public static float Power_0_Max;       //詞墜類型0所需要骰出數值的最大值
    public static float Power_1_Min;       //詞墜類型1需要先從詞墜類型0的最小值跟最大值骰出詞墜的最小值數值，再從詞墜類型1骰出詞墜的最大值數值
    public static float Power_1_Max;       //詞墜類型1需要先從詞墜類型0的最小值跟最大值骰出詞墜的最小值數值，再從詞墜類型1骰出詞墜的最大值數值
}
