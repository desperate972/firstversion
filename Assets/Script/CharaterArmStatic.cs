using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharaterArmStatic
{
    public static int id;                 //用來當作角色裝備欄位上的編號，0 = 主手武器，1 = 副手武器，2 = 頭部，3 = 身體，4 = 主手戒指，5 = 副手戒指，6 = 項鍊，7 = 手套，8 = 腰帶，9 = 腿部
    public static int ArmPower_1;
    public static int ArmPower_2;
    public static int ArmPower_3;
    public static int ArmPower_4;
    public static int ArmPower_5;
    public static int ArmPower_6;
    public static bool ArmEquip;
    public static int ArmMain;            //用於判斷該裝備會是主手還是副手，0 = 該裝備沒有主手跟副手之分，1 = 主手，2 = 副手
    public static int ArmBasicId;         //每種裝備都會有特定的外觀跟擁有的基礎數值，所以此變數就是要讀該裝備是哪個
    public static float PowerMin_1;
    public static float PowerMax_1;
    public static float PowerMin_2;
    public static float PowerMax_2;
    public static float PowerMin_3;
    public static float PowerMax_3;
    public static float PowerMin_4;
    public static float PowerMax_4;
    public static float PowerMin_5;
    public static float PowerMax_5;
    public static float PowerMin_6;
    public static float PowerMax_6;
}
