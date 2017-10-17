using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Page_1_2 : MonoBehaviour
{
    public ScrollRect scrollRect;
    public GameObject prefab;
    public Button backBtn;
    private GameObject grid;

    public List<page_1_2_Data> ItemDataList;

    void Awake()
    {
        ItemDataList = new List<page_1_2_Data>();
    }
    // Use this for initialization
    void Start()
    {
        if (prefab == null) return;
        prefab.gameObject.SetActive(false);
        GameTools.AddClickEvent(backBtn.gameObject, this.BackBtn_ClickEvent);
        StartCoroutine(GameRoot.Instance.LoadData(1, DataMgr.daShiJi, Init));
    }
    private void Init(string str)
    {
        Debug.LogError(str);
        JsonData jsonData = JsonMapper.ToObject(str);
        JsonData dataList = jsonData["data"];
        for (int i = 0; i < dataList.Count; i++)
        {
            string id = dataList[i]["id"].ToString();
            string title = dataList[i]["title"].ToString();
            JsonData imgs = dataList[i]["imgs"];
            string content = dataList[i]["content"].ToString();
            string open_time = dataList[i]["open_time"].ToString();

            page_1_2_Data data = new page_1_2_Data();
            data.id = id;
            data.title = title;
            data.content = content;
            data.openTime = open_time;
            if (imgs != null && imgs.ToString() != "")
            {
                for (int k = 0; k < imgs.Count; k++)
                {
                    string path = imgs[k].ToJson();
                    data.images.Add(path);
                }
            }
            
            ItemDataList.Add(data);
        }

        for (int i = 0; i < ItemDataList.Count; i++)
        {
            GameObject go = GameObject.Instantiate(prefab);
            go.SetActive(true);
            go.transform.parent = prefab.transform.parent;
            go.transform.localScale = Vector3.one;
            Page_1_2_Item pItem = go.GetComponent<Page_1_2_Item>();
            pItem.Init(i, ItemDataList[i],this.transform.parent.gameObject);
        }
    }
    // Update is called once per frame
    void BackBtn_ClickEvent()
    {
        UIMgr.Delete<Page_1_2>(this);
        ScreenPage_1 page12 = UIMgr.ShowUI<ScreenPage_1>("Page_1", this.transform.parent.gameObject);
       
    }


}
