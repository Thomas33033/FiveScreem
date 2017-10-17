using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Page_3_2 : MonoBehaviour {

    public Button backButton;
    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;
    public Text text;
    public string[] ImagePathList;

    bool isPlay = false;
    float endTime = 0;
    void Awake()
    {
        text.text = "";
    }

    // Use this for initialization
    void Start()
    {
        GameTools.AddClickEvent(backButton.gameObject, this.backButton_ClickEvent);
        //活力团队
        StartCoroutine(GameRoot.Instance.LoadData(2, "16", InitData));
    }

    private void InitData(string str)
    {
        JsonData jsonData = JsonMapper.ToObject(str);
        JsonData dataList = jsonData["data"];
        
        JsonData jData = dataList[0];
        string content = jData["content"].ToString();
        string title = jData["title"].ToString();
        text.text = content;

        LayoutElement rt = text.gameObject.transform.parent.GetComponent<LayoutElement>();
        rt.preferredHeight = text.preferredHeight;

        string imagePath = jData["imgs"].ToJson();
        ImagePathList = imagePath.Split('|');

        isPlay = true;
        endTime = Time.time;
    }

    void Update()
    {
        if (isPlay && Time.time > endTime)
        {
            isPlay = false;
            if (ImagePathList.Length > 0)
            {
                GameTools.Instance.LoadImage(image1, ImagePathList[0],4,4);
            }

            if (ImagePathList.Length > 1)
            {
                GameTools.Instance.LoadImage(image2, ImagePathList[1], 4, 4);
            }

            if (ImagePathList.Length > 2)
            {
                GameTools.Instance.LoadImage(image3, ImagePathList[2], 4, 4);
            }

            if (ImagePathList.Length > 3)
            {
                GameTools.Instance.LoadImage(image4, ImagePathList[3], 4, 4);
            }


            
        }
    }

   

    // Update is called once per frame
    void backButton_ClickEvent()
    {
        UIMgr.Delete<Page_3_2>(this);
        ScreenPage_3 page12 = UIMgr.ShowUI<ScreenPage_3>("Page_3", this.transform.parent.gameObject);
    }
}
