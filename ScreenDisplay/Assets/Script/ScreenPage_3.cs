using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreenPage_3 : MonoBehaviour
{

    public Button button1;
    public Button button2;
    public Button button3;

    void Awake()
    {
        GameTools.AddClickEvent(button1.gameObject, this.button_1_ClickEvent);
        GameTools.AddClickEvent(button2.gameObject, this.button_2_ClickEvent);
        GameTools.AddClickEvent(button3.gameObject, this.button_3_ClickEvent);
    }

    public void button_1_ClickEvent()
    {
        UIMgr.ShowUI<Page_3_1>("Page_3_1", this.transform.parent.gameObject);
        UIMgr.Delete<ScreenPage_3>(this); 
    }

    public void button_2_ClickEvent()
    {
        UIMgr.ShowUI<Page_3_2>("Page_3_2", this.transform.parent.gameObject);
        UIMgr.Delete<ScreenPage_3>(this); 
    }

    public void button_3_ClickEvent()
    {
        UIMgr.ShowUI<Page_3_3>("Page_3_3", this.transform.parent.gameObject);
        UIMgr.Delete<ScreenPage_3>(this);
    }

}