using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Page_1_1 : MonoBehaviour {

    public Text text;
    public Image image;
    public Button button;
    private bool isPlay = false;
    private float endTime = 1;
    private string imagePath;
    private string content;
    void Awake()
    {
        text.text = "";
    }
	// Use this for initialization
	void Start () {
        GameTools.AddClickEvent(button.gameObject, this.button_1_ClickEvent);
        //学校介绍
        StartCoroutine(GameRoot.Instance.LoadData(2, "4", InitData));
	}
    private void InitData(string str)
    {
        JsonData jsonData = JsonMapper.ToObject(str);
        JsonData dataList = jsonData["data"];

        JsonData jData = dataList[0];
        imagePath = jData["imgs"].ToString();
        content = jData["content"].ToString();
        endTime = Time.time;
        isPlay = true;
        text.text = content;
        LayoutElement rt = text.gameObject.transform.parent.GetComponent<LayoutElement>();
        rt.preferredHeight = text.preferredHeight;
    }


    void Update()
    { 
        if(isPlay && Time.time > endTime)
        {
            GameTools.Instance.LoadImage(image,imagePath,4,4);
            isPlay = false;
        }
    }

	// Update is called once per frame
    void button_1_ClickEvent()
    {
        UIMgr.ShowUI<ScreenPage_1>("Page_1", this.transform.parent.gameObject);
        UIMgr.Delete<Page_1_1>(this);
	}
}
