using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Page_1_5_ItemData 
{
    public string id;
    public string title;
    public string cat_id;
    public string imgs;
    public string content;
    public string ct_time;
}

public class Page_1_5 : MonoBehaviour {
    public ScrollPage scrollPage;
    public Button button;
    public GameObject prefab;
    public Text text;
    private bool isPlay;
    private float endTime;
    public List<Page_1_5_ItemData> ItemDataList = new List<Page_1_5_ItemData>();

    void Awake()
    {
        scrollPage.enabled = false;
        text.text = "";
    }

	// Use this for initialization
	void Start () {
        GameTools.AddClickEvent(button.gameObject, this.backButton_ClickEvent);
        
        prefab.gameObject.SetActive(false);
        
        scrollPage.OnPageChanged = OnPageChanged;
        //学校荣誉
        StartCoroutine(GameRoot.Instance.LoadData(2, "7", InitData));
	}

    private void OnPageChanged(int total, int index)
    {
        text.text = ItemDataList[index].content;
    }

    private void InitData(string str)
    {
        Debug.LogError(str);
        JsonData jsonData = JsonMapper.ToObject(str);
        JsonData dataList = jsonData["data"];
        for (int i = 0; i < dataList.Count; i++)
        {
            JsonData jData = dataList[i];
            Debug.LogError(jData.ToJson());
            try
            {
                string id = jData["id"].ToString();
                string title = jData["title"].ToString();
                string cat_id = jData["cat_id"].ToString();
                string imgs = jData["imgs"].ToString();
                string content = jData["content"].ToString();
                Page_1_5_ItemData ItemData = new Page_1_5_ItemData();
                ItemData.id = id;
                ItemData.title = title;
                ItemData.cat_id = cat_id;
                ItemData.imgs = imgs;
                ItemData.content = content;
                ItemDataList.Add(ItemData);
            }
            catch (Exception ex)
            { 
            }
            
        }
        if (ItemDataList.Count > 0)
        {
            text.text = ItemDataList[0].content;
        }
        isPlay = true;
        endTime = Time.time;
    }

    void Update()
    {
        if (isPlay && Time.time > endTime)
        {
            for (int i = 0; i < ItemDataList.Count; i++)
            {
                GameObject go = GameObject.Instantiate(prefab, prefab.transform.parent);
                go.gameObject.SetActive(true);
                Image image = go.transform.Find("Image").gameObject.GetComponent<Image>();
                GameTools.Instance.LoadImage(image, ItemDataList[i].imgs, 4, 4);
            }
            scrollPage.enabled = true;
            isPlay = false;
        }
    }

	// Update is called once per frame
    void backButton_ClickEvent()
    {
        UIMgr.ShowUI<ScreenPage_1>("Page_1", this.transform.parent.gameObject);
        UIMgr.Delete<Page_1_5>(this);
	}

    void button_1_ClickEvent()
    { 

    }
}
