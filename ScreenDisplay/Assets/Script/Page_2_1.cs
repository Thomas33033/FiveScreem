using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Page_2_1 : MonoBehaviour {

    public Text text;
    public Button button1;
    public Image titleImage;
	// Use this for initialization
	void Start () {
        GameTools.AddClickEvent(button1.gameObject, this.BackButton_ClickEvent);
        //GameTools.Instance.LoadImage(titleImage, "title1.png", 4, 4);
        text.text = "";
        
        //招生考试
        StartCoroutine(GameRoot.Instance.LoadData(2, "9", InitData));
	}

    private void InitData(string str)
    {
        Debug.LogError(str);
        JsonData jsonData = JsonMapper.ToObject(str);
        JsonData dataList = jsonData["data"];

        JsonData jData = dataList[0];
        string content = jData["content"].ToString();

        text.text = content;
        LayoutElement rt = text.gameObject.transform.parent.GetComponent<LayoutElement>();
        rt.preferredHeight = text.preferredHeight;
    }

	// Update is called once per frame
    void BackButton_ClickEvent()
    {
        ScreenPage_2 page12 = UIMgr.ShowUI<ScreenPage_2>("Page_2", this.transform.parent.gameObject);
        UIMgr.Delete<Page_2_1>(this);
	}
}
