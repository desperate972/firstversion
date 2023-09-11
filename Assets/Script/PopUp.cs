using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PopUp : MonoBehaviour
{

    public GameObject PopUpPrefab;

    private Text Load_PopUpText;
    
    // Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void PopUp_Load_String(string Load_PopUpString)
    {
        //Load_String.text = Load_PopUpString;
        PopUpPrefab = GameObject.Find("Load_PopText");
        Load_PopUpText = PopUpPrefab.GetComponent<Text>();
        Load_PopUpText.text = Load_PopUpString;
    }

    public void ClosePopUpPrefab()
    {
        Destroy(PopUpPrefab);
    }
}
