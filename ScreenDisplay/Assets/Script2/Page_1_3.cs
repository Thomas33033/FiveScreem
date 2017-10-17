using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Page_1_3 : MonoBehaviour {
    public Button button;
    public RawImage image1;
    public RawImage image2;
    public RawImage image3;
    public RawImage image4;
    public RawImage image5;

    public string[] imageList;
    private bool isPlay = false;
    private float endTime;
    private int Index;
    // Use this for initialization
	void Start () {
        GameTools.AddClickEvent(button.gameObject, this.backButton_ClickEvent);

        //学校荣誉
        StartCoroutine(GameRoot.Instance.LoadData(2, "5", InitData));
	}
	private void InitData(string str)
    {
        JsonData jsonData = JsonMapper.ToObject(str);
        JsonData dataList = jsonData["data"];

        JsonData jData = dataList[0];
        string imgsStr = jData["imgs"].ToString();
        imageList = imgsStr.Split('|');
        endTime = Time.time + 0.5f;
        Index = 0;
        isPlay = true;
        Debug.LogError(imageList.Length);
    }
    void Update()
    {
        if (isPlay && Time.time >  this.endTime)
        {
            if (imageList.Length > Index)
            {
                string imagePath = imageList[Index];
                
                if (Index == 0)
                {
                    GameTools.Instance.LoadRawImage(image1, imagePath, 4, 4);
                }
                else if (Index == 1)
                {
                    GameTools.Instance.LoadRawImage(image2, imagePath, 4, 4);
                }
                else if (Index == 2)
                {
                    GameTools.Instance.LoadRawImage(image3, imagePath, 4, 4);
                }
                else if (Index == 3)
                {
                    GameTools.Instance.LoadRawImage(image4, imagePath, 4, 4);
                }
                else if (Index == 4)
                {
                    GameTools.Instance.LoadRawImage(image5, imagePath, 4, 4);
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
        UIMgr.Delete<Page_1_3>(this);
	}
}
