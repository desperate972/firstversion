using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.U2D;

public class CharaterBag_ItemList : MonoBehaviour
{
	public int ItemId;

	public PublicFunction PublicFunctionClone;
	public CharaterBag CharaterBagClone;

	public GameObject EmptyGameObject;

	public SpriteAtlas SpriteItem;

	private GameObject GridObject;
	private GameObject ItemObject;
	private GameObject Load_ItemIcon;
	private GameObject Load_Equip;
	private GameObject Load_ItemNum;
	private GameObject ItemList;

	private Image ItemIcon;
	private Text ItemNumText;

	private int[] CharaterItemArray;
	private int CharaterItemCount;

	public void Awake()
	{

	}

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void ClickItemIcon()                    //點擊道具列表裡的道具ICON，上方的道具資訊介面就會顯示點擊的道具資訊
	{
		PublicFunctionClone.ReadCharaterItem(CharaterPropertyStatic.CharaterNumber, ItemId);
		PublicFunctionClone.ReadItem(ItemId);
		PublicFunctionClone.ItemTagSwitch(ItemId);
		CharaterBagClone.BtnClickChangeItemPowerExplain();

		CharaterBagClone.Load_ItemName.text = ItemStatic.ItemName;
		CharaterBagClone.Load_ItemRequest.text = "等級需求:" + ItemStatic.ItemRequest.ToString();
		CharaterBagClone.Load_ItemTag.text = PublicFunction.ItemTagName;
		CharaterBagClone.Load_ItemSell.text = ItemStatic.ItemSell.ToString();
		CharaterBagClone.Load_ItemExplain.text = ItemStatic.ItemExplain;
		CharaterBagClone.Load_ItemPowerExplain.text = ItemStatic.ItemPowerExplain;
		CharaterBagClone.Load_ItemIcon.sprite = SpriteItem.GetSprite(ItemStatic.ItemIcon);
	}

	public void CheckItemCount()                   //用來計算角色擁有多少道具，以及為道具編號來做排序，以方便在介面上顯示道具的順序
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

	public void LoadItemList()                     //顯示道具列表裡的所有道具
	{
		CheckItemCount();
		for (int ItemNum = 0; ItemNum < CharaterItemCount; ItemNum++)
		{
			PublicFunctionClone.ReadCharaterItem(CharaterPropertyStatic.CharaterNumber, CharaterItemArray[ItemNum]);
			PublicFunctionClone.ReadItem(CharaterItemArray[ItemNum]);
			ItemObject = GameObject.Find("UI/Prefab_Bag(Clone)/Load_Item");
			GridObject = GameObject.Find("UI/Prefab_Bag(Clone)/Scroll_ItemList/Mask/Grid_ItemList");
			EmptyGameObject = Instantiate(ItemObject, GridObject.transform);
			EmptyGameObject.name = "Load_Item_" + CharaterItemArray[ItemNum];
			Load_ItemIcon = GameObject.Find("UI/Prefab_Bag(Clone)/Scroll_ItemList/Mask/Grid_ItemList/Load_Item_" + CharaterItemArray[ItemNum] + "/Load_ItemIcon");
			ItemIcon = Load_ItemIcon.GetComponent<Image>();
			ItemIcon.sprite = SpriteItem.GetSprite(ItemStatic.ItemIcon);
			ItemList = GameObject.Find("UI/Prefab_Bag(Clone)/Scroll_ItemList/Mask/Grid_ItemList/Load_Item_" + CharaterItemArray[ItemNum]);
			CharaterBag_ItemList ItemListItem = ItemList.GetComponent<CharaterBag_ItemList>();
			ItemListItem.ItemId = CharaterItemArray[ItemNum];
			Load_ItemNum = GameObject.Find("UI/Prefab_Bag(Clone)/Scroll_ItemList/Mask/Grid_ItemList/Load_Item_" + CharaterItemArray[ItemNum] + "/Load_ItemNum");
			ItemNumText = Load_ItemNum.GetComponent<Text>();
			ItemNumText.text = CharaterItemStatic.ItemNum.ToString();
			Load_Equip = GameObject.Find("UI/Prefab_Bag(Clone)/Scroll_ItemList/Mask/Grid_ItemList/Load_Item_" + CharaterItemArray[ItemNum] + "/Load_Equip");
			switch (CharaterItemStatic.ItemEquip)
			{
				case true:
					{
						Load_Equip.SetActive(true);
						break;
					}
				case false:
					{
						Load_Equip.SetActive(false);
						break;
					}
			}
		}
	}
}
