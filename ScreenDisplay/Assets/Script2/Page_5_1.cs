using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Page_5_1 : MonoBehaviour {
    public Button backBtn;
    public GameObject prefab;


    private List<Page_5_2_ItemData> List = new List<Page_5_2_ItemData>();
    private bool isPlay = false;
    private float endTime = 0;

    void Awake()
    {
        prefab.gameObject.SetActive(false);
    }
	// Use this for initialization
	void Start () {
        GameTools.AddClickEvent(backBtn.gameObject, this.backButton_ClickEvent);
        prefab.gameObject.SetActive(false);
        //特色课程
        StartCoroutine(GameRoot.Instance.LoadData(2, "24", InitData));
	}
    private void InitData(string str)
    {
        Debug.LogError(str);
        JsonData jsonData = JsonMapper.ToObject(str);
        JsonData dataList = jsonData["data"];
        for (int i = 0; i < dataList.Count; i++)
        {
            try
            {
                JsonData jData = dataList[i];
                string id = jData["id"].ToString();
                string content = jData["content"].ToString();
                string title = jData["title"].ToString();
                string imgs = jData["imgs"].ToString();

                Page_5_2_ItemData itemData = new Page_5_2_ItemData();
                itemData.id = id;
                itemData.content = content;
                itemData.title = title;
                itemData.imgs = imgs.Split('|');
                List.Add(itemData);
            }
            catch (Exception ex)
            {

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
            for (int i = 0; i < List.Count; i++)
            {
                GameObject go = GameObject.Instantiate(prefab, prefab.transform.parent);
                Image img_bg = go.transform.Find("img_bg").gameObject.GetComponent<Image>();
                Image image = go.transform.Find("img_Icon").gameObject.GetComponent<Image>();
                Text text = go.transform.Find("Text").gameObject.GetComponent<Text>();
                Text title = go.transform.Find("title").gameObject.GetComponent<Text>();
                go.gameObject.SetActive(true);

                GameTools.Instance.LoadImage(image, List[i].imgs[0], 4, 4);
                text.text = List[i].content;
                title.text = List[i].title;
                Page_5_2_ItemData data = List[i];
                GameTools.AddClickEvent(image.gameObject, () =>
                {
                    ClickItem(data);
                });
                GameTools.AddClickEvent(img_bg.gameObject, () =>
                {
                    ClickItem(data);
                });
            }
        }
    }
	// Update is called once per frame
    void backButton_ClickEvent()
    {
        UIMgr.ShowUI<ScreenPage_5>("Page_5", this.transform.parent.gameObject);
        UIMgr.Delete<Page_5_1>(this);
    }

    void ClickItem(Page_5_2_ItemData data)
    {
        Page_5_2_1 Page_5_2_1 = UIMgr.ShowUI<Page_5_2_1>("Page_5_2_1", this.transform.parent.gameObject);
        Page_5_2_1.InitData(data);
    }
}
