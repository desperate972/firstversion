using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterList 
{
	public int ListId;                       //怪物列表的編號
	public int[] MonsterIdList;              //怪物列表裡會包含哪些怪物的編號
	public int[] MonsterIdListRate;          //怪物列表裡各個怪物編號生產的機率
}
