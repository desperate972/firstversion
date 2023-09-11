using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPC 
{
    public int Id;                  //NPC編號
    public string NPCName;          //NPC名稱
    public int NPCType;             //NPC類型，0 = 一般NPC，1 = 商人，2 = 技能導師
    public int NPCFirstDialog;      //NPC第一句對話，此編號為StringUI的編號
}
