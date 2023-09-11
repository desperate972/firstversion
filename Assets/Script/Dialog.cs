using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public int DialogStringUI;
    private GameObject DialogPrefab;

	public void Awake()
	{
        DialogPrefab = GameObject.Find("Prefab_Dialog(Clone)");
    }

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickDialog()
	{
        switch (DialogStringUI)
		{
            case 20:
				{
                    Destroy(DialogPrefab);
                    break;
				}
            case 21:
                {
                    Destroy(DialogPrefab);
                    break;
                }
            case 22:
                {
                    Destroy(DialogPrefab);
                    break;
                }
            case 23:
                {
                    Destroy(DialogPrefab);
                    break;
                }
            case 24:
                {
                    Destroy(DialogPrefab);
                    break;
                }
            case 25:
                {
                    Destroy(DialogPrefab);
                    break;
                }
            case 26:
                {
                    Destroy(DialogPrefab);
                    break;
                }
            case 27:
                {
                    Destroy(DialogPrefab);
                    break;
                }
            case 28:
                {
                    Destroy(DialogPrefab);
                    break;
                }
            case 29:
                {
                    Destroy(DialogPrefab);
                    break;
                }
        }
    }
}
