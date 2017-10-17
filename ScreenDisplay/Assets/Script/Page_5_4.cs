using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class videoData
{
    public string id;
    public string videoPath;
    public string imagePath;
    public string videName;
    public string full;
}
public class Page_5_4 : MonoBehaviour {
    public Button backBtn;
    public GameObject prefab;
    public Button UpButton;
    public Button page1Button;
    public Button page2Button;
    public Button page3Button;
    public Button pageMoreButton;
    public Button pageNextButton;
    public List<videoData> videoDataList;
    public List<Page_5_4_Item> items;
    public Video_Player videoPlayer;
    public Button videoBackButton;

    private int TotalNum;
    private int onePageNum = 6;
    private int totalPageNum;
    private int curPageIndex = 1;

    void Awake()
    { 
        for(int i = 0; i < items.Count; i++)
        {
            items[i].gameObject.SetActive(false);
        }
    }

	// Use this for initialization
	void Start () {
        videoDataList = new List<videoData>();
        GameTools.AddClickEvent(backBtn.gameObject, this.BackButton_ClickEvent);
        GameTools.AddClickEvent(UpButton.gameObject, this.UpButton_ClickEvent);
        GameTools.AddClickEvent(page1Button.gameObject, this.page1Button_ClickEvent);
        GameTools.AddClickEvent(page2Button.gameObject, this.page2Button_ClickEvent);
        GameTools.AddClickEvent(page3Button.gameObject, this.page3Button_ClickEvent);
        GameTools.AddClickEvent(pageNextButton.gameObject, this.pageNextButton_ClickEvent);
        GameTools.AddClickEvent(videoBackButton.gameObject, this.videoBackButton_ClickEvent);
        GameTools.AddClickEvent(videoPlayer.gameObject, this.videoBackButton_ClickEvent);
        
        StartCoroutine(GameRoot.Instance.LoadData(1, DataMgr.spjk, InitData));
	}


    private void InitData(string str)
    {
        JsonData jsonData = JsonMapper.ToObject(str);
        JsonData dataList = jsonData["data"];

        for (int i = 0; i < dataList.Count; i++)
        {
            string id = dataList[i]["id"].ToString();
            string title = dataList[i]["title"].ToString();
            string video_img = dataList[i]["video_img"].ToString();
            string video_url = dataList[i]["video_url"].ToString();
            string full = dataList[i]["full"].ToString();
            videoData data = new videoData();
            data.id = id;
            data.videName = title;
            data.imagePath = video_img;
            data.videoPath = video_url;
            data.full = full;
            videoDataList.Add(data);
        }

        foreach (var v in items)
        {
            v.page_5_4 = this;
        }

        Init();
    }


    public void videoBackButton_ClickEvent()
    {
        videoPlayer.gameObject.SetActive(false);
    }

    public void PlayVideo(string url,string full)
    {
        videoPlayer.OnPlay(url);
        if (full == "1")
        {
            RectTransform rt = videoPlayer.gameObject.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2( -(1920*2), 0);
            rt.sizeDelta = new Vector2(9600, 1080);
        }
        else 
        {
            RectTransform rt = videoPlayer.gameObject.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(0, 0);
            rt.sizeDelta = new Vector2(1920, 1080);
        }
        videoPlayer.gameObject.SetActive(true);
    }


    public void Init()
    {
        TotalNum = videoDataList.Count;
        if (TotalNum % onePageNum > 0)
        {
            totalPageNum = TotalNum / onePageNum + 1;
        }
        else
        {
            totalPageNum = TotalNum / onePageNum;
        }
        RefreshCurPage(curPageIndex);
    }


	// Update is called once per frame
    void BackButton_ClickEvent()
    {
        UIMgr.ShowUI<ScreenPage_5>("Page_5", this.transform.parent.gameObject);
        UIMgr.Delete<Page_5_4>(this);
	}
    
    void UpButton_ClickEvent()
    {
        RefreshCurPage(curPageIndex-1);
    }
    void page1Button_ClickEvent()
    {
        RefreshCurPage(curPageIndex);
    }
    void page2Button_ClickEvent()
   {
        RefreshCurPage(curPageIndex+1);
    }
    void page3Button_ClickEvent()
    {
        RefreshCurPage(curPageIndex+2);
    }
    void pageNextButton_ClickEvent()
    {
        RefreshCurPage(curPageIndex +1);
    }


    //初始化当前页的数据
    public void RefreshCurPage(int pageIndex)
    {
        if (pageIndex < 0)
            return;

        if (pageIndex > totalPageNum)
            return;

        curPageIndex = pageIndex;
        int index = 0;
        int num = 0;
        if (curPageIndex < totalPageNum)
        {
            index = (curPageIndex - 1) * onePageNum;
            num = curPageIndex * onePageNum;
        }
        else
        {
            index = (curPageIndex - 1) * onePageNum;
            num = TotalNum;
        }
        for (int k = 0; k < items.Count; k++)
        {
            items[k].gameObject.SetActive(false);
        }
        int temp = 0;
        for (int k = index; k < num; k++)
        {
            if (videoDataList.Count >= k)
            {
                items[temp].gameObject.SetActive(true);
                items[temp].InitData(videoDataList[k], temp);
                temp++;
            }
        }

        //刷新分页按钮
        if (curPageIndex == 1)
        {
            UpButton.gameObject.SetActive(false);
        }
        else
        {
            UpButton.gameObject.SetActive(true);
        }

        if (curPageIndex == totalPageNum)
        {
            pageNextButton.gameObject.SetActive(false);
        }
        else
        {
            pageNextButton.gameObject.SetActive(true);
        }

        if (totalPageNum - curPageIndex > 1)
        {
            page1Button.gameObject.SetActive(true);
            page1Button.transform.Find("Text").GetComponent<Text>().text = curPageIndex + "";
        }
        else
        {
            page1Button.gameObject.SetActive(false);
        }

        if (totalPageNum - curPageIndex > 2)
        {
            page2Button.gameObject.SetActive(true);
            page2Button.transform.Find("Text").GetComponent<Text>().text = curPageIndex + 1 + "";
        }
        else
        {
            page2Button.gameObject.SetActive(false);
        }

        if (totalPageNum - curPageIndex > 3)
        {
            page3Button.gameObject.SetActive(true);
            page3Button.transform.Find("Text").GetComponent<Text>().text = curPageIndex + 2 + "";
        }
        else
        {
            page3Button.gameObject.SetActive(false);
        }

        if (totalPageNum - curPageIndex > 4)
        {
            pageMoreButton.gameObject.SetActive(true);
        }
        else
        {
            pageMoreButton.gameObject.SetActive(false);
        }
          
    }
}
