using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreenPage_2 : MonoBehaviour {
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
	// Use this for initialization
	void Start () {
        GameTools.AddClickEvent(button1.gameObject, this.button_1_ClickEvent);
        GameTools.AddClickEvent(button2.gameObject, this.button_2_ClickEvent);
        GameTools.AddClickEvent(button3.gameObject, this.button_3_ClickEvent);
        GameTools.AddClickEvent(button4.gameObject, this.button_4_ClickEvent);
        GameTools.AddClickEvent(button5.gameObject, this.button_5_ClickEvent);
	}

    void button_1_ClickEvent()
    {
        Page_2_1 page12 = UIMgr.ShowUI<Page_2_1>("Page_2_1", this.transform.parent.gameObject);
        UIMgr.Delete<ScreenPage_2>(this);
    }
    void button_2_ClickEvent()
    {
        Page_2_2 page22 = UIMgr.ShowUI<Page_2_2>("Page_2_2", this.transform.parent.gameObject);
        UIMgr.Delete<ScreenPage_2>(this);
    }
    void button_3_ClickEvent()
    {
        Page_2_3 page23 = UIMgr.ShowUI<Page_2_3>("Page_2_3", this.transform.parent.gameObject);
        UIMgr.Delete<ScreenPage_2>(this);
    }
    void button_4_ClickEvent()
    {
        Page_2_4 page24 = UIMgr.ShowUI<Page_2_4>("Page_2_4", this.transform.parent.gameObject);
        UIMgr.Delete<ScreenPage_2>(this);
    }
    void button_5_ClickEvent()
    {
        Page_2_5 page25 = UIMgr.ShowUI<Page_2_5>("Page_2_5", this.transform.parent.gameObject);
        UIMgr.Delete<ScreenPage_2>(this);
    }
}
