using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NPCStatic
{
    public static int Id;                  //NPC編號
    public static string NPCName;          //NPC名稱
    public static int NPCType;             //NPC類型，0 = 一般NPC，1 = 商人，2 = 技能導師，3 = 可製作的NPC
    public static int NPCFirstDialog;      //NPC第一句對話，此編號為StringUI的編號
}
