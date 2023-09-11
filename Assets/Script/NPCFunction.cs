using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCFunction : MonoBehaviour
{
    public int NPCId;   
    public GameObject Scroll_NPCListClone;
    public GameObject Scroll_NPCFunctionClone;
    public GameObject Btn_CraftClone;
    public GameObject Btn_StoreClone;
    public GameObject Btn_SkillClone;
    public GameObject Charater_Ani;
    public GameObject NPC_Ani;

    public GameObject DialogPrefab;

    public PublicFunction PublicFunctionClone;

    public int CharaterAndNPCState = 0;

    public Animator Ani_Charater;

    //public Animator Ani_NPC;

    private GameObject ParentPrefab;
    private GameObject DialogNameClone;
    private GameObject DialogContentClone;
    private GameObject DialogObjectClone;
    private Dialog DialogClone;

    private Text DialogNameText;
    private Text DialogContentText;

    //private int State = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickNPC()
	{
        PublicFunctionClone.ReadNPC(NPCId);
        ParentPrefab = GameObject.Find("UI");
        Instantiate(DialogPrefab, ParentPrefab.transform);
        //DialobBlockObject = GameObject.Find("UI/Prefab_Dialog(Clone)/Load_DialogBlock");
        DialogNameClone = GameObject.Find("UI/Prefab_Dialog(Clone)/Load_NPCName");
        DialogNameText = DialogNameClone.GetComponent<Text>();
        DialogContentClone = GameObject.Find("UI/Prefab_Dialog(Clone)/Load_Dialog");
        DialogContentText = DialogContentClone.GetComponent<Text>();
        DialogNameText.text = NPCStatic.NPCName;
        PublicFunctionClone.ReadStringUI(NPCStatic.NPCFirstDialog);
        DialogContentText.text = PublicFunction.ReturnString;
        DialogObjectClone = GameObject.Find("Prefab_Dialog(Clone)");
        DialogClone = DialogObjectClone.GetComponent<Dialog>();
        DialogClone.DialogStringUI = NPCStatic.NPCFirstDialog;
        NPCAniChange(NPCStatic.Id);
        CharaterAndNPC();
        switch (NPCStatic.NPCType)
		{
            case 0:
				{
                    Scroll_NPCFunctionClone.SetActive(true);
                    Scroll_NPCListClone.SetActive(false);
                    Btn_CraftClone.SetActive(false);
                    Btn_StoreClone.SetActive(false);
                    Btn_SkillClone.SetActive(false);
                    break;
				}
            case 1:
				{
                    Scroll_NPCFunctionClone.SetActive(true);
                    Scroll_NPCListClone.SetActive(false);
                    Btn_CraftClone.SetActive(false);
                    Btn_StoreClone.SetActive(true);
                    Btn_SkillClone.SetActive(false);
                    break;
				}
            case 2:
				{
                    Scroll_NPCFunctionClone.SetActive(true);
                    Scroll_NPCListClone.SetActive(false);
                    Btn_CraftClone.SetActive(false);
                    Btn_StoreClone.SetActive(false);
                    Btn_SkillClone.SetActive(true);
                    break;
				}
            case 3:
                {
                    Scroll_NPCFunctionClone.SetActive(true);
                    Scroll_NPCListClone.SetActive(false);
                    Btn_CraftClone.SetActive(true);
                    Btn_StoreClone.SetActive(true);
                    Btn_SkillClone.SetActive(true);
                    break;
                }
        }
	}

    public void ClickBtn_Back()
	{
        Scroll_NPCFunctionClone.SetActive(false);
        Scroll_NPCListClone.SetActive(true);
    }

    public void CharaterAndNPC()
	{
        StartCoroutine(CharaterMove());
        StartCoroutine(NPCMove());
    }

    public void CharaterAndNPCForFunction()
	{
        StartCoroutine(CharaterMoveForFunction());
        StartCoroutine(NPCMoveForFunction());
    }

    IEnumerator CharaterMove()
	{
        switch(CharaterAndNPCState)
		{
            case 0:
				{
                    //Ani_Charater.GetComponent<Animator>().SetBool("Charater_Walk", true);
                    while (Charater_Ani.transform.localPosition.x != -88)
                    {
                        Charater_Ani.transform.localPosition = Vector3.MoveTowards(Charater_Ani.transform.localPosition, new Vector3(-88, 143, 0), 10f);
                    }
                    //Ani_Charater.GetComponent<Animator>().SetBool("Charater_Rest", false);
                    yield return null;
                    CharaterAndNPCState = 1;
                    break;
				}
            case 1:
				{
                   // Ani_Charater.GetComponent<Animator>().SetBool("Charater_Walk", false);
                    while (Charater_Ani.transform.localPosition.x != 87)
                    {
                        Charater_Ani.transform.localPosition = Vector3.MoveTowards(Charater_Ani.transform.localPosition, new Vector3(87, 143, 0), 10f);
                        //Ani_Charater.GetComponent<Animator>().SetBool("Charater_Rest", true);
                    }
                    yield return null;
                    CharaterAndNPCState = 0;
                    break;
				}
		}
	}
    IEnumerator NPCMove()
    {
        switch(CharaterAndNPCState)
		{
            case 0:
				{
                    while (NPC_Ani.transform.localPosition.x != 175)
                    {
                        NPC_Ani.transform.localPosition = Vector3.MoveTowards(NPC_Ani.transform.localPosition, new Vector3(175, 142, 0), 12f);
                    }
                    yield return null;
                    CharaterAndNPCState = 1;
                    break;
				}
            case 1:
				{
                    while (NPC_Ani.transform.localPosition.x != 500)
                    {
                        NPC_Ani.transform.localPosition = Vector3.MoveTowards(NPC_Ani.transform.localPosition, new Vector3(500, 142, 0), 12f);
                    }
                    yield return null; 
                    CharaterAndNPCState = 0;
                    break;
				}
		}
    }

    IEnumerator CharaterMoveForFunction()
    {
        switch (CharaterAndNPCState)
        {
            case 0:
                {
                    break;
                }
            case 1:
                {
                    while (Charater_Ani.transform.localPosition.x != 87)
                    {
                        Charater_Ani.transform.localPosition = Vector3.MoveTowards(Charater_Ani.transform.localPosition, new Vector3(87, 143, 0), 10f);
                    }
                    yield return null;
                    CharaterAndNPCState = 0;
                    break;
                }
        }
    }
    IEnumerator NPCMoveForFunction()
    {
        switch (CharaterAndNPCState)
        {
            case 0:
                {
                    break;
                }
            case 1:
                {
                    while (NPC_Ani.transform.localPosition.x != 500)
                    {
                        NPC_Ani.transform.localPosition = Vector3.MoveTowards(NPC_Ani.transform.localPosition, new Vector3(500, 142, 0), 12f);
                    }
                    yield return null;
                    CharaterAndNPCState = 0;
                    break;
                }
        }
    }

    public void NPCAniChange(int NPCId)
	{
        switch(NPCId)
		{
            case 0:
				{
                    NPC_Ani.GetComponent<Animator>().SetBool("NPC_0", false);
                    NPC_Ani.GetComponent<Animator>().SetBool("NPC_1", true);
                    NPC_Ani.GetComponent<Animator>().SetBool("NPC_2", false);
                    break;
				}
            case 7:
				{
                    NPC_Ani.GetComponent<Animator>().SetBool("NPC_0", true);
                    NPC_Ani.GetComponent<Animator>().SetBool("NPC_1", false);
                    NPC_Ani.GetComponent<Animator>().SetBool("NPC_2", false);
                    break;
				}
            case 12:
				{
                    NPC_Ani.GetComponent<Animator>().SetBool("NPC_0", false);
                    NPC_Ani.GetComponent<Animator>().SetBool("NPC_1", false);
                    NPC_Ani.GetComponent<Animator>().SetBool("NPC_2", true);
                    break;
				}
		}
	}
}
