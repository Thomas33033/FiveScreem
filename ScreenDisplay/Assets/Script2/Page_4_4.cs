using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Page_4_4 : MonoBehaviour {

    public Button backButton;
    public GameObject prefab1;
    public GameObject prefab2;

    bool isPlay = false;
    float endTime = 0;
    public List<Page_3_1_ItemData> itemDataList = new List<Page_3_1_ItemData>();

    void Awake()
    {
        prefab1.gameObject.SetActive(false);
        prefab2.gameObject.SetActive(false);
    }

    // Use this for initialization
    void Start()
    {
        GameTools.AddClickEvent(backButton.gameObject, this.backButton_ClickEvent);
        
        //家校互动
        StartCoroutine(GameRoot.Instance.LoadData(2, "21", InitData));
    }


    private void InitData(string str)
    {
        JsonData jsonData = JsonMapper.ToObject(str);
        JsonData dataList = jsonData["data"];
        Debug.LogError(str);
        for (int i = 0; i < dataList.Count; i++)
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
                if (itemData.imgs != null && itemData.imgs.Length > 0)
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
    }

    // Update is called once per frame
    void backButton_ClickEvent()
    {
        UIMgr.Delete<Page_4_4>(this);
        UIMgr.ShowUI<ScreenPage_4>("Page_4", this.transform.parent.gameObject);
    }
}
