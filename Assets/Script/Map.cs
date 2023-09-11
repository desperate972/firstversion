using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class Map 
{
	public int MapId;                 //地圖編號
	public string MapSprite;          //地圖用圖名稱
	public int MapType;               //地圖類型，是城鎮還是野外圖
	public int MapNpcList;            //地圖內含有的NPC，先讀取NPCList這張表來確定這張地圖裡有那些NPC，再從這裡把每個NPC的編號都讀取出來
	public int MonsterList;           //跟NPCList很像，先讀取MonsterList這張表來確定這張地圖會產生哪些Monster，再透過怪物產生的程式來產生怪物
	public string MapName;            //地圖名稱
	public string MapContent;         //地圖敘述
}
