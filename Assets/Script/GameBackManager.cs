using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBackManager : MonoBehaviour {

    public PublicFunction PublicFunctionClone;
    public GameObject LoadingPrefab;
    public GameObject LoadingBarSprite;
    public GameObject LoadingFinishText;
    public GameObject GameBackUI;
    public Text LoadingText;

    public static GameBackManager GameBackManagerClone;

    private void Awake()
    {
        CheckGameBackManager();
        CheckStoreFile();
        test();
    }

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }    

    public void CheckStoreFile()
    {
        string StoreName = "Store";
        PublicFunctionClone.ReadPlatformpersistentDataPath(StoreName);
        if (!File.Exists(PublicFunction.persistentFilePath))
        {
            PublicFunctionClone.CreateStorepersistentDataPath();
        }
        else
            return;
    }

    public void CheckGameBackManager()
    {
        if(GameBackManagerClone == null)
        {
            GameBackManagerClone = this;
            DontDestroyOnLoad(gameObject);
        }
        if(GameBackManagerClone != this)
        {
            Destroy(gameObject);
        }
    }

    public void test()
    {
        Debug.Log("測試");
    }

    public void LoadingScenes()
    {
        Instantiate(LoadingPrefab, GameBackUI.transform);
        LoadingBarSprite.GetComponent<RectTransform>().sizeDelta = new Vector2(650, 70);                 //每次複製此介面時要重置進度條sprite圖片的長寬大小，避免之後的修改會永久影響原本prefab的大小
        StartCoroutine(LoadingScenesFunction());
        //LoadingScenesFunctionSecond();
    }

    IEnumerator LoadingScenesFunction()
    {
        AsyncOperation LoadingAsync = SceneManager.LoadSceneAsync("MainGame");

        float RectWidth = LoadingBarSprite.GetComponent<RectTransform>().rect.width;
        float RealHeight = LoadingBarSprite.GetComponent<RectTransform>().rect.height;
        float LoadingWidth = RectWidth / 100;

        if(!LoadingAsync.isDone)
        {
            while (!LoadingAsync.isDone)
            {
                float RealWidth = (LoadingAsync.progress * 100) * LoadingWidth;

                Debug.Log(LoadingAsync.progress);

                Debug.Log("修改前的圖片寬度 : " + RectWidth);
                Debug.Log("修改前的進度條大小 : " + RealWidth);

                LoadingText.text = (LoadingAsync.progress * 100) + "%";                                                 //顯示在Loading介面上的百分比
                string LoadingTextString = LoadingText.text;

                Debug.Log("修改前的進度條進度百分比 : " + LoadingTextString);

                LoadingBarSprite.GetComponent<RectTransform>().sizeDelta = new Vector2(RealWidth, RealHeight);            //顯示進度條圖的大小

                Debug.Log("修改後的圖片寬度 : " + RectWidth);
                Debug.Log("修改後的進度條大小 : " + RealWidth);
                Debug.Log("修改後的進度條進度百分比 : " + LoadingTextString);

                yield return null;
            }
        }
        if(LoadingAsync.isDone)
        {
            float RealWidthDone = (LoadingAsync.progress * 100) * LoadingWidth;
            LoadingText.text = (LoadingAsync.progress * 100) + "%";                                                 //顯示在Loading介面上的百分比
            string LoadingTextStringDone = LoadingText.text;
            LoadingBarSprite.GetComponent<RectTransform>().sizeDelta = new Vector2(RealWidthDone, RealHeight);
            LoadingFinishText.SetActive(true);

            //Time.timeScale = 0;
        }
    }

    public void LoadingScenesFunctionSecond()                                                                              //使用非StartCoroutine來執行的function
    {
        AsyncOperation LoadingAsync = SceneManager.LoadSceneAsync("MainGame");

        float RectWidth = LoadingBarSprite.GetComponent<RectTransform>().rect.width;
        float RealHeight = LoadingBarSprite.GetComponent<RectTransform>().rect.height;
        float LoadingWidth = RectWidth / 100;

        if (!LoadingAsync.isDone)
        {
            while (!LoadingAsync.isDone)
            {

                float RealWidth = (LoadingAsync.progress * 100) * LoadingWidth;

                Debug.Log(LoadingAsync.progress);

                Debug.Log("修改前的圖片寬度 : " + RectWidth);
                Debug.Log("修改前的進度條大小 : " + RealWidth);

                LoadingText.text = (LoadingAsync.progress * 100) + "%";                                                 //顯示在Loading介面上的百分比
                string LoadingTextString = LoadingText.text;

                Debug.Log("修改前的進度條進度百分比 : " + LoadingTextString);

                LoadingBarSprite.GetComponent<RectTransform>().sizeDelta = new Vector2(RealWidth, RealHeight);            //顯示進度條圖的大小

                Debug.Log("修改後的圖片寬度 : " + RectWidth);
                Debug.Log("修改後的進度條大小 : " + RealWidth);
                Debug.Log("修改後的進度條進度百分比 : " + LoadingTextString);

                break;
            }
        }
        if (LoadingAsync.isDone)
        {
            float RealWidthDone = (LoadingAsync.progress * 100) * LoadingWidth;
            LoadingText.text = (LoadingAsync.progress * 100) + "%";                                                 //顯示在Loading介面上的百分比
            string LoadingTextStringDone = LoadingText.text;
            LoadingBarSprite.GetComponent<RectTransform>().sizeDelta = new Vector2(RealWidthDone, RealHeight);
            LoadingFinishText.SetActive(true);

            Time.timeScale = 0;
        }
    }
}
