using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Page_1_4 : MonoBehaviour {

    public Button button;
    public List<RawImage> imageList;

    public string[] imagePathList;
    private bool isPlay = false;
    private float endTime;
    private int Index;
	// Use this for initialization
	void Start () {
        GameTools.AddClickEvent(button.gameObject, this.backButton_ClickEvent);
        //学校荣誉
        StartCoroutine(GameRoot.Instance.LoadData(2, "6", InitData));
	}

    private void InitData(string str)
    {
        JsonData jsonData = JsonMapper.ToObject(str);
        JsonData dataList = jsonData["data"];

        JsonData jData = dataList[0];
        string imgsStr = jData["imgs"].ToString();
        imagePathList = imgsStr.Split('|');
        endTime = Time.time + 0.5f;
        Index = 0;
        isPlay = true;
   
    }
    void Update()
    {
        if (isPlay && Time.time > this.endTime)
        {
            if (imagePathList.Length > Index)
            {
                string imagePath = imagePathList[Index];

                if (Index == 0)
                {
                    GameTools.Instance.LoadRawImage(imageList[0], imagePath, 4, 4);
                }
                else if (Index == 1)
                {
                    GameTools.Instance.LoadRawImage(imageList[1], imagePath, 4, 4);
                }
                else if (Index == 2)
                {
                    GameTools.Instance.LoadRawImage(imageList[2], imagePath, 4, 4);
                }
                else if (Index == 3)
                {
                    GameTools.Instance.LoadRawImage(imageList[3], imagePath, 4, 4);
                }
                else if (Index == 4)
                {
                    GameTools.Instance.LoadRawImage(imageList[4], imagePath, 4, 4);
                }
                else
                {
                    isPlay = false;
                }
                Index++;
                endTime = Time.time;
            }
            else
            {
                isPlay = false;
            }

        }
    }

	// Update is called once per frame
    void backButton_ClickEvent()
    {
        UIMgr.ShowUI<ScreenPage_1>("Page_1", this.transform.parent.gameObject);
        UIMgr.Delete<Page_1_4>(this);
    }
}
