using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mission_Hint : MonoBehaviour
{
    private int HintNum;
    private GameObject MissionHint;

    public void Awake()
    {
        HintNum = 0;
        MissionHint = GameObject.Find("Function_Mission");
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Changeone()
    {
        if(HintNum == 0)
        {
            StartCoroutine(OpenMissionHint());
        }
        if (HintNum == 1)
        {
            StartCoroutine(CloseMissionHint());
        }

    }

    IEnumerator OpenMissionHint()
    {
        while (MissionHint.transform.localPosition.x != -200)
        {
            MissionHint.transform.localPosition = Vector3.MoveTowards(MissionHint.transform.localPosition, new Vector3(-200, 380, 0), 10f);
            yield return null;
        }
        HintNum = 1;
    }

    IEnumerator CloseMissionHint()
    {
        while (MissionHint.transform.localPosition.x != -512)
        {
            MissionHint.transform.localPosition = Vector3.MoveTowards(MissionHint.transform.localPosition, new Vector3(-512, 380, 0), 10f);
            yield return null;
        }
        HintNum = 0;
    }
}
