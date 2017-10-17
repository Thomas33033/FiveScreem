using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Page_4_1_ItemData
{
    public List<string> list = new List<string>();
    
}

public class Page_4_1 : MonoBehaviour {
    public Button backButton;
    public Page_4_1_Item Item1;
    public Page_4_1_Item Item2;
    public Page_4_1_Item Item3;
    public Page_4_1_Item Item4;
    public Page_4_1_Item Item5;
    public Page_4_1_Item Item6;

    private Page_4_1_ItemData data1 = new Page_4_1_ItemData();
    private Page_4_1_ItemData data2 = new Page_4_1_ItemData();
    private Page_4_1_ItemData data3 = new Page_4_1_ItemData();
    private Page_4_1_ItemData data4 = new Page_4_1_ItemData();
    private Page_4_1_ItemData data5 = new Page_4_1_ItemData();
    private Page_4_1_ItemData data6 = new Page_4_1_ItemData();
	// Use this for initialization
	void Start () 
    {
        GameTools.AddClickEvent(backButton.gameObject, this.backButton_ClickEvent);
        StartCoroutine(GameRoot.Instance.LoadData(1, DataMgr.xgjy, InitData));
	}

    private void InitData(string str)
    {
        Debug.LogError(str);
        JsonData jsonData = JsonMapper.ToObject(str);
        JsonData dataList = jsonData["data"];
        
        for (int i = 0; i < dataList.Count; i++)
        {
            string id = dataList[i]["id"].ToString();
            string clean = dataList[i]["clean"].ToString();
            string propriety = dataList[i]["propriety"].ToString();
            string rest = dataList[i]["rest"].ToString();
            string exercise = dataList[i]["exercise"].ToString();
            string dining = dataList[i]["dining"].ToString();
            string preparation = dataList[i]["preparation"].ToString();

            data1.list.Add(clean);
            data2.list.Add(propriety);
            data3.list.Add(rest);
            data4.list.Add(exercise);
            data5.list.Add(dining);
            data6.list.Add(preparation);
        }

        Item1.InitData(data1);
        Item2.InitData(data2);
        Item3.InitData(data3);
        Item4.InitData(data4);
        Item5.InitData(data5);
        Item6.InitData(data6);
    }


	// Update is called once per frame
    void backButton_ClickEvent()
    {
        UIMgr.ShowUI<ScreenPage_4>("Page_4", this.transform.parent.gameObject);
        UIMgr.Delete<Page_4_1>(this);
	}
}
