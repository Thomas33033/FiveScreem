using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Page_2_5 : MonoBehaviour {

    public Button backButton;
    public Text text;
    public Text title;

    void Awake()
    {
        text.text = "";
    }

    // Use this for initialization
    void Start()
    {
        GameTools.AddClickEvent(backButton.gameObject, this.backButton_ClickEvent);

        //公示公告
        StartCoroutine(GameRoot.Instance.LoadData(2, "13", InitData));
    }

    private void InitData(string str)
    {
        Debug.LogError(str);
        JsonData jsonData = JsonMapper.ToObject(str);
        JsonData dataList = jsonData["data"];

        JsonData jData = dataList[0];
        string content = jData["content"].ToString();
        string titleStr = jData["title"].ToString();
        text.text = content;
        title.text = titleStr;
        LayoutElement rt = text.gameObject.transform.parent.GetComponent<LayoutElement>();
        rt.preferredHeight = text.preferredHeight;
    }
    // Update is called once per frame
    void backButton_ClickEvent()
    {
        ScreenPage_2 page12 = UIMgr.ShowUI<ScreenPage_2>("Page_2", this.transform.parent.gameObject);
        UIMgr.Delete<Page_2_5>(this);
    }
}
