using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreenPage_5 : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button backShouYe;
    void Awake()
    {
        GameTools.AddClickEvent(button1.gameObject, this.button_1_ClickEvent);
        GameTools.AddClickEvent(button2.gameObject, this.button_2_ClickEvent);
        GameTools.AddClickEvent(button3.gameObject, this.button_3_ClickEvent);
        GameTools.AddClickEvent(button4.gameObject, this.button_4_ClickEvent);
        GameTools.AddClickEvent(backShouYe.gameObject, this.BackShouYe_ClickEvent);


    }
    // Use this for initialization
    void Start()
    {

    }
    //特色课程
    public void button_1_ClickEvent()
    {
        UIMgr.ShowUI<Page_5_1>("Page_5_1", this.transform.parent.gameObject);
        UIMgr.Delete<ScreenPage_5>(this);
    }

    //课堂风采
    public void button_2_ClickEvent()
    {
        UIMgr.ShowUI<Page_5_2>("Page_5_2", this.transform.parent.gameObject);
        UIMgr.Delete<ScreenPage_5>(this);
    }

    //校园天气
    public void button_3_ClickEvent()
    {
        UIMgr.ShowUI<Page_5_3>("Page_5_3", this.transform.parent.gameObject);
        UIMgr.Delete<ScreenPage_5>(this);
    }

    //视频播放
    public void button_4_ClickEvent()
    {
        UIMgr.ShowUI<Page_5_4>("Page_5_4", this.transform.parent.gameObject);
        UIMgr.Delete<ScreenPage_5>(this);
    }

    //返回首页
    public void BackShouYe_ClickEvent()
    {
        GameRoot.Instance.DeleteUI();
    }
}
