using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item 
{
	public int Id;                    //道具編號
	public string ItemName;           //道具名稱
	public string ItemIcon;           //道具圖示
	public int ItemTag;               //道具標籤
	public int ItemStack;             //道具可堆疊數量
	public int ItemPower;             //道具的效果
	public float ItemPowerMin;        //道具效果的最小數值
	public float ItemPowerMax;        //道具效果的最大數值
	public string ItemExplain;        //道具說明
	public string ItemPowerExplain;   //道具效果描述
	public int ItemRequest;           //道具需求角色等級
	public int ItemSell;              //出售道具價格
}
