using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;

public class MapFunction : MonoBehaviour
{
    public int MapId;
    
    public GameObject MapName;
    public GameObject MapType;
    public GameObject MapContent;
    //public GameObject MapCityPoint;
    //public GameObject MapWildPoint;
    public PublicFunction PublicFunctionClone;
    public GameBackManager GameBackManagerClone;
    public MainGameControl MainGameControlClone;
    //public GameObject CityObject;
    //public GameObject WildObject;
    //public GameObject PointSpwan;

    public OpenMsgBox OpenMsgBoxClone;

    public Text MapNameText;
    public Text MapTypeText;
    public Text MapContentText;

    public static int[] MapPoint;
    public static int MapCount;

    public static int MapNowPoint;

    private GameObject LocationObject;
    private GameObject EmptyGameObject;

    public void Awake()
	{
        PublicFunctionClone.ReadMap(CharaterPropertyStatic.CharaterLastMap);
        MapNowPoint = CharaterPropertyStatic.CharaterLastMap;
        Debug.Log("現在選擇的地圖點是:" + MapStatic.MapName);
        Debug.Log("現在的地圖:" + MapNowPoint);
        InputMapContent();
    }

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LocationMapPoint()
	{
        switch(CharaterPropertyStatic.CharaterLastMap)
		{
            case 0:
				{
                    break;
				}
            case 2:
				{
                    break;
				}
		}
	}

    public void ClickMapPoint()
	{
        switch(MapId)
		{
            case 0:
				{
                    PublicFunctionClone.ReadMap(0);
                    InputMapContent();
                    MapNowPoint = 0;
                    Debug.Log("現在選擇的地圖點是:" + MapStatic.MapName);
                    Debug.Log("現在的地圖:" + MapNowPoint);
                    break;
				}
            case 1:
				{
                    PublicFunctionClone.ReadMap(1);
                    InputMapContent();
                    MapNowPoint = 1;
                    Debug.Log("現在選擇的地圖點是:" + MapStatic.MapName);
                    Debug.Log("現在的地圖:" + MapNowPoint);
                    break;
				}
            case 2:
				{
                    PublicFunctionClone.ReadMap(2);
                    InputMapContent();
                    MapNowPoint = 2;
                    Debug.Log("現在選擇的地圖點是:" + MapStatic.MapName);
                    Debug.Log("現在的地圖:" + MapNowPoint);
                    break;
				}
            case 3:
				{
                    PublicFunctionClone.ReadMap(3);
                    InputMapContent();
                    MapNowPoint = 3;
                    Debug.Log("現在選擇的地圖點是:" + MapStatic.MapName);
                    Debug.Log("現在的地圖:" + MapNowPoint);
                    break;
				}
		}
	}

    public void ReadMapCount()
    {
        string FileName = "Map";
        PublicFunctionClone.ReadPlatformStreamingAssets(FileName);
        string datapath = PublicFunction.streamingFilePath;

        var newfile = new UnityWebRequest(datapath);
        newfile.downloadHandler = new DownloadHandlerBuffer();
        var something = newfile.SendWebRequest();
        while (!something.isDone)
        { }
        string newfileinside = newfile.downloadHandler.text;

        JsonMap<Map> FileItem = JsonUtility.FromJson<JsonMap<Map>>(newfileinside);

        MapCount = FileItem.Map.Count;
        MapPoint = new int[MapCount];

        for (int M = 0; M < MapCount; M++)
		{
            MapPoint[M] = FileItem.Map[M].MapId; 
        }
    }

    public class JsonMap<T>
    {
        public List<T> Map;
    }

    public void LoadMapPoint()                                   //原本預期是來顯示地圖點的功能，目前先閒置
	{
        /*for (int M = 0; M < MapCount; M++)
        {
            PublicFunctionClone.ReadMap(MapPoint[M]);
            switch(MapStatic.MapType)
			{
                case 0:
					{
                        Instantiate(CityObject, PointSpwan.transform);
                        break;
					}
                case 1:
					{
                        Instantiate(WildObject, PointSpwan.transform);
                        break;
					}
			}
        }*/
    }

    public void InputMapContent()
	{
        MapNameText = MapName.GetComponent<Text>();
        MapTypeText = MapType.GetComponent<Text>();
        MapContentText = MapContent.GetComponent<Text>();
        MapNameText.text = MapStatic.MapName;
        MapContentText.text = MapStatic.MapContent;
        switch (MapStatic.MapType)
        {
            case 0:
                {
                    MapTypeText.text = "城鎮區";
                    break;
                }
            case 1:
                {
                    MapTypeText.text = "戰鬥區";
                    break;
                }
        }
    }

    public void ClickIntoPoint()
	{
        PublicFunctionClone.ReadMap(MapNowPoint);
        switch (MapStatic.MapType)
        {
            case 0:
				{
                    CharaterPropertyStatic.CharaterLastMap = MapNowPoint;
                    CharaterPropertyStatic.CharaterNowMap = MapNowPoint;
                    PublicFunctionClone.CharaterPropertyStaticChange();
                    string FilePath = "Charater_" + CharaterPropertyStatic.CharaterNumber;
                    string FileInside;

                    PublicFunctionClone.ReadPlatformpersistentDataPath(FilePath);
                    FileInside = JsonUtility.ToJson(PublicFunction.CharaterPropertyValue);
                    File.WriteAllText(PublicFunction.persistentFilePath, FileInside);
                    OpenMsgBoxClone.CreateMsgBox(31);
                    EmptyGameObject = GameObject.Find("UI/Prefab_Battle(Clone)");
                    Destroy(EmptyGameObject);
                    break;
				}
            case 1:
				{
                    CharaterPropertyStatic.CharaterNowMap = MapNowPoint;
                    PublicFunctionClone.CharaterPropertyStaticChange();
                    string FilePath = "Charater_" + CharaterPropertyStatic.CharaterNumber;
                    string FileInside;

                    PublicFunctionClone.ReadPlatformpersistentDataPath(FilePath);
                    FileInside = JsonUtility.ToJson(PublicFunction.CharaterPropertyValue);
                    File.WriteAllText(PublicFunction.persistentFilePath, FileInside);
                    OpenMsgBoxClone.CreateMsgBox(30);
                    break;
				}
		}
	}
}
