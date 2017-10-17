using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Page_3_1_ItemData
{
    public string title;
    public string content;
    public string[] imgs;
}

public class Page_3_1 : MonoBehaviour {
    public Button backButton;
    public GameObject prefab1;
    public GameObject prefab2;

    public List<Page_3_1_ItemData> itemDataList = new List<Page_3_1_ItemData>();

    bool isPlay = false;
    float endTime = 0;

    void Awake()
    {
        prefab1.gameObject.SetActive(false);
        prefab2.gameObject.SetActive(false);
    }

	// Use this for initialization
	void Start () {
        
        GameTools.AddClickEvent(backButton.gameObject, this.backButton_ClickEvent);
        //相约工会
        StartCoroutine(GameRoot.Instance.LoadData(2, "17", InitData));
	}

    private void InitData(string str)
    {
        JsonData jsonData = JsonMapper.ToObject(str);
        JsonData dataList = jsonData["data"];
        Debug.LogError(dataList.Count);
        for(int i = 0; i < dataList.Count; i++)
        {
            try
            {
                JsonData jData = dataList[i];
                string content = jData["content"].ToString();
                string title = jData["title"].ToString();
                string imagePath = jData["imgs"].ToJson();
                string[] imgs = imagePath.Split('|');
                Page_3_1_ItemData itemData = new Page_3_1_ItemData();
                itemData.title = title;
                itemData.content = content;
                itemData.imgs = imgs;
                itemDataList.Add(itemData);
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.ToString());
            }
        }
        
        isPlay = true;
        endTime = Time.time;
    }

    void Update()
    {
        if (isPlay && Time.time > endTime)
        {
            isPlay = false;
            for (int i = 0; i < itemDataList.Count; i++)
            {
                GameObject go = null;
                if (i % 2 == 0)
                {
                    go = GameObject.Instantiate(prefab1, prefab1.transform.parent).gameObject;
                }
                else
                {
                    go = GameObject.Instantiate(prefab2, prefab2.transform.parent).gameObject;
                }
                go.gameObject.SetActive(true);
                Page_3_1_ItemData itemData = itemDataList[i];
                go.transform.Find("txt_content").GetComponent<Text>().text = itemDataList[i].content;
                Image image = go.transform.Find("Img/Img_content").GetComponent<Image>();
                if(itemData.imgs != null && itemData.imgs.Length > 0)
                {
                    GameTools.Instance.LoadImage(image, itemData.imgs[0], 4, 4);
                }
                GameTools.AddClickEvent(image.gameObject, () =>
                {
                    ClickItem(itemData);
                });
            }
        }
    }

    void ClickItem(Page_3_1_ItemData data)
    {
        Page4_3_1 ui = UIMgr.ShowUI<Page4_3_1>("Page_4_3_1", this.transform.parent.gameObject);
        Page_4_3_ItemData itemData = new Page_4_3_ItemData();
        itemData.title = data.title;
        itemData.content = data.content;
        itemData.imgs = data.imgs;

        ui.InitData(itemData);
        ui.ShowBar();
    }

	// Update is called once per frame
    void backButton_ClickEvent()
    {
        UIMgr.Delete<Page_3_1>(this);
        ScreenPage_3 page12 = UIMgr.ShowUI<ScreenPage_3>("Page_3", this.transform.parent.gameObject);
	}
}
