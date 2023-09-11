using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllGoodScript : MonoBehaviour
{
    public PublicFunction PublicFunctionClone;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void first()                                           //用來幫JSON檔案裡的資料編號做排序
	{
        string ItemFileName = "Charater_" + CharaterPropertyStatic.CharaterNumber + "_Item";
        PublicFunctionClone.ReadPlatformpersistentDataPath(ItemFileName);
        string ItemFile = System.IO.File.ReadAllText(PublicFunction.persistentFilePath);
        JsonCharaterItem<CharaterItem> ItemFileJson = JsonUtility.FromJson<JsonCharaterItem<CharaterItem>>(ItemFile);

        int[] newitemarray = new int[ItemFileJson.CharaterItem.Count];
        int newnum = 0;

        foreach (CharaterItem data in ItemFileJson.CharaterItem)
        {
            newitemarray[newnum] = data.Id;
            newnum++;
            Debug.Log(data.Id);
        }
        for (int num = 0; num < ItemFileJson.CharaterItem.Count; num++)
        {
            Debug.Log("整理前的陣列第" + num + "個編號:" + newitemarray[num]);
        }

        int nowid = 0, nowitemnum = 0, nextid = 0, nextitemnum = 0, stayid = 0, stayitemnum = 0;
        bool nowequip = false, nextequip = false, stayequip = false;

        for (int oldNum = ItemFileJson.CharaterItem.Count; oldNum >= 0; oldNum--)
        {
            for (int Num = 0; Num < ItemFileJson.CharaterItem.Count; Num++)
            {
                newnum = 0;
                foreach (CharaterItem data in ItemFileJson.CharaterItem)
                {
                    newitemarray[newnum] = data.Id;
                    newnum++;
                }
                switch (Num == ItemFileJson.CharaterItem.Count - 1)
                {
                    case true:
                        {
                            foreach (CharaterItem data in ItemFileJson.CharaterItem)
                            {
                                if (data.Id == newitemarray[Num - 1])
                                {
                                    nowid = data.Id;
                                    nowitemnum = data.ItemNum;
                                    nowequip = data.ItemEquip;
                                }
                                if (data.Id == newitemarray[Num])
                                {
                                    nextid = data.Id;
                                    nextitemnum = data.ItemNum;
                                    nextequip = data.ItemEquip;
                                    stayid = nextid;
                                    stayitemnum = nextitemnum;
                                    stayequip = nextequip;
                                }
                            }
                            if (nextid < nowid)
                            {
                                foreach (CharaterItem data in ItemFileJson.CharaterItem)
                                {
                                    if (data.Id == nowid)
                                    {
                                        data.Id = nowid + 1024;
                                    }
                                    if (data.Id == nextid)
                                    {
                                        data.Id = nextid + 2048;
                                    }
                                }
                                foreach (CharaterItem data in ItemFileJson.CharaterItem)
                                {
                                    if (data.Id == nextid + 2048)
                                    {
                                        data.Id = nowid;
                                        data.ItemNum = nowitemnum;
                                        data.ItemEquip = nowequip;
                                    }
                                    if (data.Id == nowid + 1024)
                                    {
                                        data.Id = stayid;
                                        data.ItemNum = stayitemnum;
                                        data.ItemEquip = stayequip;
                                    }
                                }
                            }
                            break;
                        }
                    case false:
                        {
                            foreach (CharaterItem data in ItemFileJson.CharaterItem)
                            {
                                if (data.Id == newitemarray[Num])
                                {
                                    nowid = data.Id;
                                    nowitemnum = data.ItemNum;
                                    nowequip = data.ItemEquip;
                                }
                                if (data.Id == newitemarray[Num + 1])
                                {
                                    nextid = data.Id;
                                    nextitemnum = data.ItemNum;
                                    nextequip = data.ItemEquip;
                                    stayid = nextid;
                                    stayitemnum = nextitemnum;
                                    stayequip = nextequip;
                                }
                            }
                            if (nextid < nowid)
                            {
                                foreach (CharaterItem data in ItemFileJson.CharaterItem)
                                {
                                    if (data.Id == nowid)
                                    {
                                        data.Id = nowid + 1024;
                                    }
                                    if (data.Id == nextid)
                                    {
                                        data.Id = nextid + 2048;
                                    }
                                }
                                foreach (CharaterItem data in ItemFileJson.CharaterItem)
                                {
                                    if (data.Id == nextid + 2048)
                                    {
                                        data.Id = nowid;
                                        data.ItemNum = nowitemnum;
                                        data.ItemEquip = nowequip;
                                    }
                                    if (data.Id == nowid + 1024)
                                    {
                                        data.Id = stayid;
                                        data.ItemNum = stayitemnum;
                                        data.ItemEquip = stayequip;
                                    }
                                }
                            }
                            break;
                        }
                }
            }
        }
        newnum = 0;
        foreach (CharaterItem data in ItemFileJson.CharaterItem)
        {
            newitemarray[newnum] = data.Id;
            newnum++;
            Debug.Log(data.Id);
        }
        for (int num = 0; num < ItemFileJson.CharaterItem.Count; num++)
        {
            Debug.Log("整理後的陣列第" + num + "個編號:" + newitemarray[num]);
        }
    }

    public class JsonCharaterItem<T>
    {
        public List<T> CharaterItem;
    }
}
