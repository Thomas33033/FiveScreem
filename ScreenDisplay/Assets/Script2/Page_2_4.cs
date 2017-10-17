using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Page_2_4 : MonoBehaviour {

    public Button backButton;
    public GameObject prefab;
    List<Page_2_4_ItemData> list = new List<Page_2_4_ItemData>();

    // Use this for initialization
    void Start()
    {
        prefab.gameObject.SetActive(false);
        GameTools.AddClickEvent(backButton.gameObject, this.BackButton_ClickEvent);
        StartCoroutine(GameRoot.Instance.LoadData(1, DataMgr.wcap, InitData));
    }

    private void InitData(string str)
    {
        JsonData jsonData = JsonMapper.ToObject(str);
        JsonData dataList = jsonData["data"];
        Dictionary<string, string> dic = new Dictionary<string, string>();
        
        for (int i = 0; i < dataList.Count; i++)
        {
            JsonData jData = dataList[i];

            if (jData.IsArray)
            {
                break;
            }

            string id = jData["id"].ToString();
            string riqi = jData["riqi"].ToString();
            string week = jData["week"].ToString();
            string times = jData["times"].ToString();
            string content = jData["content"].ToString();
            string address = jData["address"].ToString();
            string enters = jData["enters"].ToString();
            string classStr = jData["class"].ToString();

            Page_2_4_ItemData itemData = new Page_2_4_ItemData();
            itemData.id = id;
            itemData.riqi = float.Parse(riqi)+"";

            itemData.week = week;
            itemData.times = times;
            itemData.content = content;
            itemData.address = address;
            itemData.enters = enters;
            itemData.classStr = classStr;

            list.Add(itemData);
        }

        for (int i = 0; i < list.Count; i++)
        {
            GameObject go = GameObject.Instantiate(prefab, prefab.transform.parent);
            Page_2_3_Item item = go.gameObject.GetComponent<Page_2_3_Item>();
            item.InitData2(list[i]);
            go.gameObject.SetActive(true);

        }

    }


    // Update is called once per frame
    void BackButton_ClickEvent()
    {
        ScreenPage_2 page12 = UIMgr.ShowUI<ScreenPage_2>("Page_2", this.transform.parent.gameObject);
        UIMgr.Delete<Page_2_4>(this);
    }
}
