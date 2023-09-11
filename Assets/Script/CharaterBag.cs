using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.U2D;

public class CharaterBag : MonoBehaviour 
{
	public PublicFunction PublicFunctionClone;
	public CharaterBag_ItemList CharaterBag_ItemListClone;

	public GameObject Btn_PowerExplain;
	public GameObject Btn_Explain;
	public GameObject Load_ExplainTitle;
	public GameObject Load_PowerExplainTitle;
	public GameObject Scroll_ItemExplain;
	public GameObject Scroll_ItemPowerExplain;

	public Text Load_CharaterMoney;
	public Text Load_ItemName;
	public Text Load_ItemRequest;
	public Text Load_ItemTag;
	public Text Load_ItemSell;
	public Text Load_ItemExplain;
	public Text Load_ItemPowerExplain;

	public Text Load_ItemExplainShowTest;
	public Text Load_ItemPowerExplainShowTest;

	public SpriteAtlas SpriteItem;

	public Image Load_ItemIcon;

	private int[] CharaterItemArray;
	private int CharaterItemCount;

	public void Awake()
	{
		Load_CharaterMoney.text = CharaterPropertyStatic.CharaterMoney.ToString();
		CheckItemCount();
		OpenPrefabItemShow();
		CharaterBag_ItemListClone.LoadItemList();
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void CheckItemCount()                          //用來計算角色擁有多少道具，以及為道具編號來做排序，以方便在介面上顯示道具的順序
	{
		string ItemFileName = "Charater_" + CharaterPropertyStatic.CharaterNumber + "_Item.json";
		string ItemPath = Application.persistentDataPath;

		if (Application.platform == RuntimePlatform.Android)
		{
			string jsonpath = Application.persistentDataPath;
			string datapath = Path.Combine(jsonpath, ItemFileName);

			ItemPath = datapath;
		}
		if (Application.platform != RuntimePlatform.Android)
		{
			string jsonpath = Application.persistentDataPath;
			string datapath = Path.Combine(jsonpath, ItemFileName);

			ItemPath = datapath;
		}

		string FileInside = File.ReadAllText(ItemPath);

		JsonItem<CharaterItem> FileItem = JsonUtility.FromJson<JsonItem<CharaterItem>>(FileInside);
		CharaterItemCount = FileItem.CharaterItem.Count;
		CharaterItemArray = new int[CharaterItemCount];
		for (int i = 0; i < CharaterItemCount; i++)
		{
			CharaterItemArray[i] = FileItem.CharaterItem[i].Id;
		}

		for (int arrayNum = 0; arrayNum < CharaterItemCount - 1; arrayNum++)
		{
			if (CharaterItemArray[CharaterItemCount - 1] < CharaterItemArray[CharaterItemCount - 2])
			{
				int OldNum = CharaterItemArray[CharaterItemCount - 2];
				CharaterItemArray[CharaterItemCount - 2] = CharaterItemArray[CharaterItemCount - 1];
				CharaterItemArray[CharaterItemCount - 1] = OldNum;
			}
			if (CharaterItemArray[arrayNum + 1] < CharaterItemArray[arrayNum])
			{
				int OldNum = CharaterItemArray[arrayNum];
				CharaterItemArray[arrayNum] = CharaterItemArray[arrayNum + 1];
				CharaterItemArray[arrayNum + 1] = OldNum;
			}
		}
	}

	public class JsonItem<T>
	{
		public List<T> CharaterItem;
	}

	public void OpenPrefabItemShow()                      //一打開背包介面時，介面上顯示的道具會是角色擁有道具的第一個
	{
		PublicFunctionClone.ReadItem(CharaterItemArray[0]);
		PublicFunctionClone.ItemTagSwitch(CharaterItemArray[0]);
		Load_ItemName.text = ItemStatic.ItemName;
		Load_ItemRequest.text = "等級需求:" + ItemStatic.ItemRequest.ToString();
		Load_ItemTag.text = PublicFunction.ItemTagName;
		Load_ItemSell.text = ItemStatic.ItemSell.ToString();
		Load_ItemExplain.text = ItemStatic.ItemExplain;                              
		Load_ItemPowerExplain.text = ItemStatic.ItemPowerExplain;
		Load_ItemIcon.sprite = SpriteItem.GetSprite(ItemStatic.ItemIcon);
	}

	public void BtnClickChangeItemExplain()               //切換到道具說明
	{
		Btn_PowerExplain.SetActive(true);
		Load_PowerExplainTitle.SetActive(false);
		Scroll_ItemPowerExplain.SetActive(false);

		Btn_Explain.SetActive(false);
		Load_ExplainTitle.SetActive(true);
		Scroll_ItemExplain.SetActive(true);

		Load_ItemExplain.text = ItemStatic.ItemExplain;
	}

	public void BtnClickChangeItemPowerExplain()          //切換到道具效果
	{
		Btn_PowerExplain.SetActive(false);
		Load_PowerExplainTitle.SetActive(true);
		Scroll_ItemPowerExplain.SetActive(true);

		Btn_Explain.SetActive(true);
		Load_ExplainTitle.SetActive(false);
		Scroll_ItemExplain.SetActive(false);

		Load_ItemPowerExplain.text = ItemStatic.ItemPowerExplain;
	}
}
