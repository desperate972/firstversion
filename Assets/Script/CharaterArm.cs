using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharaterArm
{
    public int id;
    public int ArmPower_1;
    public int ArmPower_2;
    public int ArmPower_3;
    public int ArmPower_4;
    public int ArmPower_5;
    public int ArmPower_6;
    public bool ArmEquip;
    public int ArmMain;           //用於判斷該裝備會是主手還是副手，0 = 該裝備沒有主手跟副手之分，1 = 主手，2 = 副手
    public int ArmBasicId;
    public float PowerMin_1;
    public float PowerMax_1;
    public float PowerMin_2;
    public float PowerMax_2;
    public float PowerMin_3;
    public float PowerMax_3;
    public float PowerMin_4;
    public float PowerMax_4;
    public float PowerMin_5;
    public float PowerMax_5;
    public float PowerMin_6;
    public float PowerMax_6;
}
