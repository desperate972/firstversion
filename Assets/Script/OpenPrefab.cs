using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPrefab : MonoBehaviour
{
    //共用function，用來打開介面(Prefab)
    public GameObject CharaterInfo_Child;

    private GameObject ParentPrefab;

    private void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {

    }
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OpenCharaterList()
    {
        ParentPrefab = GameObject.Find("UI");
        Instantiate(CharaterInfo_Child, ParentPrefab.transform);
    }

    public void CloseCharaterList()
    {
        Destroy(CharaterInfo_Child);
    }

    public void OpenCreateCharater()
    {
        ParentPrefab = GameObject.Find("UI");
        Instantiate(CharaterInfo_Child, ParentPrefab.transform);
    }

    public void CloseCreateCharater()
    {
        Destroy(CharaterInfo_Child);
    }

    public void OpenCharaterInfoPrefab()
    {
        ParentPrefab = GameObject.Find("UI");
        Instantiate(CharaterInfo_Child, ParentPrefab.transform);
    }

    public void CloseCharaterInfoPrefab()
    {
        Destroy(CharaterInfo_Child);
    }

    public void CharaterInfo_ArmList_Close()
    {
        CharaterInfo_Child.SetActive(false);
    }

    public void OpenCharaterBag()
    {
        ParentPrefab = GameObject.Find("UI");
        Instantiate(CharaterInfo_Child, ParentPrefab.transform);
    }

    public void CloseCharaterBag()
	{
        Destroy(CharaterInfo_Child);
    }

    public void OpenMapPrefab()
	{
        ParentPrefab = GameObject.Find("UI");
        Instantiate(CharaterInfo_Child, ParentPrefab.transform);
    }

    public void CloseMapPrefab()
	{
        Destroy(CharaterInfo_Child);
    }
}
