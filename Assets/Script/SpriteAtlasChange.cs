using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class SpriteAtlasChange : MonoBehaviour
{

    public SpriteAtlas SpriteChange;

    public Image HeadImage;
    public Image BodyImage;
    public Image FootImage;

    public static int Head;     //靜態類別會在程式啟動時塞靜態變數進記憶體，直到程式關閉，但其他變數不會，即使有同名的變數，可能會造成多個同名變數的產生，自然無法達到共用變數的結果
    public static int Body;
    public static int Foot;

    private void Awake()
    {
        HeadImage = HeadImage.GetComponent<Image>();
        BodyImage = BodyImage.GetComponent<Image>();
        FootImage = FootImage.GetComponent<Image>();

        Head = 1;
        HeadImage.sprite = SpriteChange.GetSprite("Head_"+ Head);

        Body = 1;
        BodyImage.sprite = SpriteChange.GetSprite("Body_" + Body);

        Foot = 1;
        FootImage.sprite = SpriteChange.GetSprite("Foot_" + Foot);
    }

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ChangeSpriteHeadAdd()         //換下一個頭部外觀
    {
        /*if (Head == 3)             
        {
            Head = 1;
            HeadImage.sprite = SpriteChange.GetSprite("Head_1");
            Debug.Log("從3~1");
        }
        else
        {
            Head += 1;
            HeadImage.sprite = SpriteChange.GetSprite("Head_" + Head);
            Debug.Log("從"+(Head - 1)+"到"+ Head);
        }*/

        //原本的寫法在上面註解，簡化成下面

        Head = (Head == 3) ? Head = 1 : Head += 1;    //三元條件運算子
        ChangeHeadSprite(Head);
    }

    public void ChangeSpriteHeadLess()        //換前一個頭部外觀
    {
        /*if (Head == 1)
        {
            Head = 3;
            HeadImage.sprite = SpriteChange.GetSprite("Head_3");
            Debug.Log("從1~3");
        }
        else
        {
            Head -= 1;
            HeadImage.sprite = SpriteChange.GetSprite("Head_" + Head);
            Debug.Log("從" + (Head + 1) + "到" + Head);
        }*/

        //原本的寫法在上面註解，簡化成下面

        Head = (Head == 1) ? Head = 3 : Head -= 1;    //三元條件運算子
        ChangeHeadSprite(Head);
    }

    public void ChangeHeadSprite(int Num)
    {
        HeadImage.sprite = SpriteChange.GetSprite("Head_" + Head);
    }

    public void ChangeSpriteBodyAdd()
    {
        Body = (Body == 3) ? Body = 1 : Body += 1;    //三元條件運算子
        ChangeBodySprite(Body);
    }

    public void ChangeSpriteBodyLess()
    {
        Body = (Body == 1) ? Body = 3 : Body -= 1;    //三元條件運算子
        ChangeBodySprite(Body);
    }

    public void ChangeBodySprite(int Num)
    {
        BodyImage.sprite = SpriteChange.GetSprite("Body_" + Body);
    }

    public void ChangeSpritePantsAdd()
    {
        Foot = (Foot == 3) ? Foot = 1 : Foot += 1;    //三元條件運算子
        ChangePantsSprite(Foot);
    }

    public void ChangeSpritePantsLess()
    {
        Foot = (Foot == 1) ? Foot = 3 : Foot -= 1;    //三元條件運算子
        ChangePantsSprite(Body);
    }

    public void ChangePantsSprite(int Num)
    {
        FootImage.sprite = SpriteChange.GetSprite("Foot_" + Foot);
    }

}
