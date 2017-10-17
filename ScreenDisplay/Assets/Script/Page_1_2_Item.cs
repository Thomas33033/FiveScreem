using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class page_1_2_Data
{
    public string id;
    public string title;
    public List<string> images = new List<string>();
    public string content;
    public string openTime;
}

public class Page_1_2_Item : MonoBehaviour
{
    public List<Sprite> sprites;
    public List<Sprite> bgSprites;
    public Text text;
    public Text text_1;
    public Image bgImg;
    public Image icon;
    private page_1_2_Data mData;
    private GameObject UIParent;
    // Use this for initialization
    void Start()
    {
        GameTools.AddClickEvent(bgImg.gameObject, this.BackBtn_ClickEvent);
    }

    void BackBtn_ClickEvent()
    {
        Page_1_2_1 page12 = UIMgr.ShowUI<Page_1_2_1>("Page_1_2_1", UIParent);
        if(mData.images != null && mData.images.Count > 0)
        {
            page12.InitData(mData.title,mData.content,mData.images[0]);
        }
        else
        {
            page12.InitData(mData.title,mData.content,"");
        }
    }

    public void Init(int index, page_1_2_Data data,GameObject p_UIParent)
    {
        this.gameObject.transform.localPosition = new Vector3(
            this.gameObject.transform.localPosition.x,
            this.gameObject.transform.localPosition.y,
            0);

        mData = data;
        text.text = data.openTime;
        text_1.text = data.title;
        UIParent = p_UIParent;
        RectTransform rt = bgImg.transform.GetComponent<RectTransform>();

        if (index % 2 == 0)
        {
            rt.anchoredPosition = new Vector2(74, 88);
        }
        else
        {
            rt.anchoredPosition = new Vector2(74, -250);
        }

        bgImg.sprite = sprites[index % sprites.Count];
        icon.sprite = bgSprites[index % bgSprites.Count];
    }
   
}
