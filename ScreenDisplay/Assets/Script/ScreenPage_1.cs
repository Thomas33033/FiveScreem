using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenPage_1 : MonoBehaviour {

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;
    void Awake()
    {
        GameTools.AddClickEvent(button1.gameObject, this.button_1_ClickEvent);
        GameTools.AddClickEvent(button2.gameObject, this.button_2_ClickEvent);
        GameTools.AddClickEvent(button3.gameObject, this.button_3_ClickEvent);
        GameTools.AddClickEvent(button4.gameObject, this.button_4_ClickEvent);
        GameTools.AddClickEvent(button5.gameObject, this.button_5_ClickEvent);
        GameTools.AddClickEvent(button6.gameObject, this.button_6_ClickEvent);
    }

    public void button_1_ClickEvent()
    {
        Page_1_1 page12 = UIMgr.ShowUI<Page_1_1>("Page_1_1", this.transform.parent.gameObject);
        UIMgr.Delete<ScreenPage_1>(this);
    }
    public void button_2_ClickEvent()
    {
        Page_1_2 page12 = UIMgr.ShowUI<Page_1_2>("Page_1_2", this.transform.parent.gameObject);
        UIMgr.Delete<ScreenPage_1>(this);
    }

    public void button_3_ClickEvent()
    {
        Page_1_3 page13 = UIMgr.ShowUI<Page_1_3>("Page_1_3", this.transform.parent.gameObject);
        UIMgr.Delete<ScreenPage_1>(this);
    }

    public void button_4_ClickEvent()
    {
        Page_1_4 page14 = UIMgr.ShowUI<Page_1_4>("Page_1_4", this.transform.parent.gameObject);
        UIMgr.Delete<ScreenPage_1>(this);
    }

    public void button_5_ClickEvent()
    {
        Page_1_5 page15 = UIMgr.ShowUI<Page_1_5>("Page_1_5", this.transform.parent.gameObject);
        UIMgr.Delete<ScreenPage_1>(this);
    }

    public void button_6_ClickEvent()
    {
        Page_1_6 page12 = UIMgr.ShowUI<Page_1_6>("Page_1_6", this.transform.parent.gameObject);
        UIMgr.Delete<ScreenPage_1>(this);

    }
} 
