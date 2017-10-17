﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreenPage_4 : MonoBehaviour
{

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    void Awake()
    {
        GameTools.AddClickEvent(button1.gameObject, this.button_1_ClickEvent);
        GameTools.AddClickEvent(button2.gameObject, this.button_2_ClickEvent);
        GameTools.AddClickEvent(button3.gameObject, this.button_3_ClickEvent);
        GameTools.AddClickEvent(button4.gameObject, this.button_4_ClickEvent);

    }

    public void button_1_ClickEvent()
    {
        UIMgr.ShowUI<Page_4_1>("Page_4_1", this.transform.parent.gameObject);
        UIMgr.Delete<ScreenPage_4>(this);
    }

    public void button_2_ClickEvent()
    {
        UIMgr.ShowUI<Page_4_2>("Page_4_2", this.transform.parent.gameObject);
        UIMgr.Delete<ScreenPage_4>(this);
    }

    public void button_3_ClickEvent()
    {
        UIMgr.ShowUI<Page_4_3>("Page_4_3", this.transform.parent.gameObject);
        UIMgr.Delete<ScreenPage_4>(this);
    }

    public void button_4_ClickEvent()
    {
        UIMgr.ShowUI<Page_4_4>("Page_4_4", this.transform.parent.gameObject);
        UIMgr.Delete<ScreenPage_4>(this);
    }

}