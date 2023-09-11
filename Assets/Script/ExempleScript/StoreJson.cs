using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class StoreJson : MonoBehaviour
{

    public PublicFunction New;
    
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewOneClick()
    {
        New.ReadStringUI(1);
    }

    public void NewTwoClick()
    {
        New.ReadStringUI(2);
    }

    public void NewClick(int i)
    {
        string jsonpath = Application.dataPath + "/Json";
        string jsonfile = "StoreString.json";
        string datapath = Path.Combine(jsonpath, jsonfile);

        string dataread = File.ReadAllText(datapath); 

        dataread = "{ \"StringUI\": " + dataread + "}";  //這邊所加上的字串必須跟List所宣告的字串一樣，不然就會造成錯誤，StringUI對JsonRead<T>裡面的List<T> StringUI

        JsonRead<StoreString> FileJson = JsonUtility.FromJson<JsonRead<StoreString>>(dataread);

        foreach(StoreString data in FileJson.StringUI)
        {
            if(data.id == i)
            {
                Debug.Log(data.name);
            }
        }

        /*讀取json檔案轉成字串，但因為json檔案格式無法被JsonUtility反序列化(JsonUtility沒有支援多維陣列)，但JsonUtility可以反序列化List，所以把讀取檔案的字串包進一個名稱為StringUI的List裡面
        讓JsonUtility去反序列化StringUI這個List，這樣就可以反序列化Json檔案裡的多維陣列，因為對JsonUtility而言StringUI這個List是一個一維陣列*/

        /*
            在JsonUtility的眼裡StringUI這個List是長以下樣子，JsonUtility沒有在在意[]裡面是甚麼
            
            {
              "StringUI":
              []
            } 

         */

    }

    public class JsonRead<T>
    {
        public List<T> StringUI;
    }
}
