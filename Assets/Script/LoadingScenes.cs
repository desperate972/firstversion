using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScenes : MonoBehaviour
{

    public GameObject LoadingScencsClone;

    private void Awake()
    {
        Debug.Log("有成功生成此介面!");
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void TouchLoadingPrefab()
    {
        Destroy(LoadingScencsClone);
    }
}
