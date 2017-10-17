using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Page_4_3_ItemData
{
    public string title;
    public string content;
    public string[] imgs;
}

public class Page_4_3 : MonoBehaviour {

    public EnhancelScrollView mEnhancelScrollView;
    public MyUGUIEnhanceItem prefab;

    public Button backButton;
    public List<RawImage> imageList;
    List<Page_4_3_ItemData> ItemDataList = new List<Page_4_3_ItemData>();

    public List<Text> textObjList;
    private bool isPlay = false;
    private float endTime;
    private int Index;


	// Use this for initialization
	void Start () {
        GameTools.AddClickEvent(backButton.gameObject, this.BackButton_ClickEvent);

        prefab.gameObject.SetActive(false);
        //学生互动
        StartCoroutine(GameRoot.Instance.LoadData(2, "20", InitData));
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
                string title = jData["title"].ToString();
                string imgsStr = jData["imgs"].ToString();
                string[] imgs = imgsStr.Split('|');
                string content = jData["content"].ToString();
                Page_4_3_ItemData data = new Page_4_3_ItemData();
                data.title = title;
                data.imgs = imgs;
                data.content = content;
                ItemDataList.Add(data);
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
        if (isPlay && Time.time > this.endTime)
        {
               mEnhancelScrollView.scrollViewItems = new List<EnhanceItem>();
               for (int i = 0; i < ItemDataList.Count; i++)
               {
                   Page_4_3_ItemData data = ItemDataList[i];
     
                   GameObject go = GameObject.Instantiate(prefab.gameObject,prefab.transform.parent).gameObject;
                   MyUGUIEnhanceItem ueItem = go.GetComponent<MyUGUIEnhanceItem>();
                   go.gameObject.SetActive(true);
                   mEnhancelScrollView.scrollViewItems.Add(ueItem);
                    string imagePath = "";
                   if(data.imgs != null && data.imgs.Length > 0)
                      imagePath =  data.imgs[0];
                   string content = data.content;

                   Image image = go.transform.Find("Img_1").GetComponent<Image>();
                   Text text = go.transform.Find("txt_1").GetComponent<Text>();

                   GameTools.Instance.LoadImage(image, imagePath, 4, 4);
                   text.text = content;

                   GameTools.AddClickEvent(image.gameObject, () =>
                   {
                       ClickItem(data);
                   });
               }
               
                isPlay = false;
                mEnhancelScrollView.gameObject.SetActive(true);
        }
    }

	// Update is called once per frame
    void BackButton_ClickEvent()
    {
        UIMgr.Delete<Page_4_3>(this);
        UIMgr.ShowUI<ScreenPage_4>("Page_4", this.transform.parent.gameObject);
	}

    void ClickItem(Page_4_3_ItemData data)
    {
        Page4_3_1 ui = UIMgr.ShowUI<Page4_3_1>("Page_4_3_1", this.transform.parent.gameObject);
        ui.InitData(data);
    }
}
