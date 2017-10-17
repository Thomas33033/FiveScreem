using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Page_2_3 : MonoBehaviour {
    public Button backButton;
    public Button button2;
    public GameObject prefab;
    public GameObject prefab2;
    private List<Page_2_3_ItemData> list = new List<Page_2_3_ItemData>();
    private List<Page_2_3_1_Data> listData1s = new List<Page_2_3_1_Data>();
	// Use this for initialization
	void Start () {
        prefab.gameObject.SetActive(false);
        prefab2.gameObject.SetActive(false);
        GameTools.AddClickEvent(backButton.gameObject, this.BackButton_ClickEvent);
        GameTools.AddClickEvent(button2.gameObject, this.ButtonEvent);
        StartCoroutine(GameRoot.Instance.LoadData(1, DataMgr.mzgz, InitData));
	}

    private void InitData(string str)
    {
        Debug.LogError(str);
        JsonData jsonData = JsonMapper.ToObject(str);
        JsonData dataList = jsonData["data"];
        Dictionary<string, string> dic = new Dictionary<string, string>();

        for (int i = 0; i < dataList.Count; i++)
        {
            JsonData jData = dataList[i];

            if (jData.IsArray)
            {
                parsePoints(jData);
                break;
            }

            string id = jData["id"].ToString();
            string riqi = jData["riqi"].ToString();
            string week = jData["week"].ToString();
            string times = jData["times"].ToString();
            string address = jData["address"].ToString();
            string owner = jData["owner"].ToString();
            string emphases = jData["emphases"].ToString();

            Page_2_3_ItemData itemData = new Page_2_3_ItemData();
            itemData.id = id;
            itemData.riqi = riqi;
            itemData.week = week;
            itemData.times = times;
            itemData.address = address;
            itemData.owner = owner;
            itemData.emphases = emphases;

            list.Add(itemData);
        }




        string lastStr = "";
        for (int i = 0; i < list.Count; i++)
        {
            GameObject go = GameObject.Instantiate(prefab, prefab.transform.parent);
            Page_2_3_Item item = go.gameObject.GetComponent<Page_2_3_Item>();
            item.InitData(list[i]);
            go.gameObject.SetActive(true);
            if (lastStr != list[i].emphases)
            {
                GameObject go2 = GameObject.Instantiate(prefab2, prefab2.transform.parent);
                Text text = go2.transform.Find("Item_1/Text_1").gameObject.GetComponent<Text>();
                text.text = list[i].emphases;
                go2.gameObject.SetActive(true);
                lastStr = list[i].emphases;
            }
            
            
        }
        
    }

    void parsePoints(JsonData dataList)
    {
        for (int i = 0; i < dataList.Count; i++)
        {
            JsonData jData = dataList[i];

            if (jData.IsArray)
            {
                break;
            }

            string id = jData["id"].ToString();
            string content = jData["point"].ToString();
            Page_2_3_1_Data itemData = new Page_2_3_1_Data();
            itemData.content = content;
            listData1s.Add(itemData);
        }
    }



	// Update is called once per frame
    void BackButton_ClickEvent()
    {
        ScreenPage_2 page12 = UIMgr.ShowUI<ScreenPage_2>("Page_2", this.transform.parent.gameObject);
        UIMgr.Delete<Page_2_3>(this);
	}
    void ButtonEvent()
    {
        Page_2_3_1 page_2_3_1 = UIMgr.ShowUI<Page_2_3_1>("Page_2_3_1", this.transform.parent.gameObject);
        page_2_3_1.InitData(listData1s);
	}
    
}
