using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MsgBoxEvent
{

    //現在改成使用Json檔案的StringUI.json來讀取需要的UI字串，所以此script算作廢


    //這個程式碼是用來儲存靜態變數，主要儲存MsgBox的值

    public static int MsgEvent = 0;

    //MsgEvent = 0 是代表沒有呼叫任何MsgBox
    //MsgEvent = 1 是代表關閉遊戲

    public static string TextLeave = "是否確定要離開遊戲?\n按下確認關閉遊戲!";
}
